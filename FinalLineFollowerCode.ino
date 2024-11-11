//Communication variables
const byte START = 255;
byte startByte = 0;
byte operation = 0;
byte calibrate = 0;
byte checkByte = 0;
byte checkSum = 0;

//DAC pins
const byte DACPIN1[8] = {9,8,7,6,5,4,3,2};
const byte DACPIN2[8] = {A2,A3,A4,A5,A1,A0,11,10};

//Sensor pins
int leftSensor = A6;
int rightSensor = A7;

int leftSenval = 0;// Sensor value variables
int rightSenval = 0;

int sensorThreshold = 700; //# CHANGE AFTER TESTING

//Direction variables
int direction = 0;
int lastdirection = 0;

//Errors and PID variables

static unsigned long previousMillis = 0;//millisecods for commination timing
unsigned long currentMillis = 0;

float error = 0.0; //variable for error
float pre_error = 0.0; // variable to remember last error

int OFFSET_leftsens = 0; //offset for the leftsensor
int OFFSET_rightsens = 0; //offset for the right sensor

//PID error variables
double p_Error = 0.0;
double i_Error = 0.0;
double d_Error = 0.0;

//PID gain variables
double Kp = 0.067;
double Ki = 0.0000005;
double Kd = 0.03;

//Duty variables
double Duty1 = 0.0;
double Duty2 = 0.0;

//DAC decimal values variables
int leftDACden = 0;
int rightDACden = 0;

//DAC decimal value for motor stop
int motorStop = 138;

/*############## SETUP CODE ##############*/
void setup() {

  for( int i = 0; i<=7; i++ )
  {
    pinMode( DACPIN1[i] , OUTPUT);
    pinMode( DACPIN2[i] , OUTPUT); //Initialise pins used for the DACs as outputs
  }

  pinMode(leftSensor,INPUT);
  pinMode(rightSensor,INPUT); //Initialise pins used for Sensors as inputs

  leftSenval = analogRead(leftSensor);
  rightSenval = analogRead(rightSensor);

  OFFSET_leftsens = leftSenval; //Calculate offset values for initial calibration
  OFFSET_rightsens = rightSenval;

  Serial.begin(9600); //Initialise serial communication with baude rate of 9600
}

/*############## MAIN LOOP ##############*/
void loop() {

  currentMillis = millis();
  if (currentMillis - previousMillis >= 5) { // Communication done each 5 ms
    previousMillis = currentMillis;          // to account for bluetooth delay
    serialCom();                             // and systmatic UART com
  }
  
  if (operation == 1) // Start moving if start button pressed
  {
    checkOut(); // Check the direction where sensors went out
    getError(); // Obtain the error value

    derivativeError();
    propotionalError();
    integralalError(); // Calculate the PID control values

    PID(); // Apply PID adjustements to the motors

    rightDAC(rightDACden);
    leftDAC(leftDACden); // Set values for digital pins for the motors
  }
  else if (operation == 0) //Stop the motors and any operations if st button pressed
  {
    rightDAC(motorStop); //Denary values at motors stop is applied
    leftDAC(motorStop);
  }
  if (calibrate == 1)  //Calibration for sensors for error calculation
  {
    OFFSET_leftsens = analogRead(leftSensor);
    OFFSET_rightsens = analogRead(rightSensor); // Obtain offset values
  }
}

/*############## CHECK ERROR DIRECTION ##############*/
void checkOut(){
  leftSenval = analogRead(leftSensor);
  rightSenval = analogRead(rightSensor);//Take reading from sensors 
  
  //According to the threshold determine whether the sensor is out of the line and assign a direction
  if (leftSenval <= sensorThreshold && rightSenval > sensorThreshold){
    direction = 1; //Direction 1 is the right side
    lastdirection = 1;
  }
  if (leftSenval > sensorThreshold && rightSenval <= sensorThreshold){
    direction = -1; //Direction -1 is the left side
    lastdirection = -1;
  }
  if (leftSenval <= sensorThreshold && rightSenval <= sensorThreshold){
    direction = 0; //If both sensors within the line
    lastdirection= 0;
  }
  if (leftSenval > sensorThreshold && rightSenval > sensorThreshold){
    direction = lastdirection; //Incase both sensors are out determine a direction based on which sensor went out first
  }

}

/*############## ERROR VALUE ##############*/
void getError(){

  if (direction == 1){ //error for right sensor out
    error = abs(rightSenval - OFFSET_rightsens);
  }
  if (direction == -1){ //error for left sensor out
    error = abs(leftSenval - OFFSET_leftsens);
  }
  
}


/*############## DERIVATIVE ERROR ##############*/
void derivativeError(){
  d_Error = error - pre_error;
}

/*############## PROPOTIONAL ERROR ##############*/
void propotionalError(){
  p_Error = error;
}

/*############## INTEGRAL ERROR ##############*/
void integralalError(){
  i_Error = i_Error + error;
}

/*############## PID CONTROL ##############*/
void PID(){
  double baseSpeed_S = 80.0;     // Slow base speed for tight corners with high errors
  double baseSpeed_F = 100.0;    // High base speed for straight lines with low errors
  double controlOutput = 0.0;    // Control output variable
  double maxspeed_S = 90.0;      // Maximum duty cycle for high errors
  double maxspeed_F = 100.0;     // Maximum duty cycle for low errors
  double minspeed = 10.0;        // Minimum duty cycle for motor 10% used for continous motion
  double motor1Speed = 0.0;      // Right motor duty cycle after control
  double motor2Speed = 0.0;      // Left motor duty cycle after control

  controlOutput = ((Kp * p_Error) + (Kd * d_Error) + (Ki * i_Error)); // PID control calculations

  if (controlOutput >= 30){//If the correction is high use the lower speeds
    motor1Speed = (baseSpeed_S + (controlOutput*direction)); // Calculate the duty cycle using the 
    motor2Speed = (baseSpeed_S - (controlOutput*direction)); // base speed and control output and direction.
    motor1Speed = constrain(motor1Speed, minspeed, maxspeed_S); // Limit the motor duty cycles
    motor2Speed = constrain(motor2Speed, minspeed, maxspeed_S);
  }
  if (controlOutput < 30){ //If the correction is low use the higher speeds
    motor1Speed = (baseSpeed_F + (controlOutput*direction));
    motor2Speed = (baseSpeed_F - (controlOutput*direction));
    motor1Speed = constrain(motor1Speed, minspeed, maxspeed_F); // Limit the motor duty cycles
    motor2Speed = constrain(motor2Speed, minspeed, maxspeed_F);
  }

  Duty1 = motor1Speed;
  Duty2 = motor2Speed;// Assign the calculated speeds to the duty variables

  rightDACden = map(Duty1,0.0,100.0,153,255); //153 give the duty cycle of 0% for positive duty cycle and 255 100%
  leftDACden = map(Duty2,0.0,100.0,153,255); //Map the obtained duty cycle to the denary value range for positive cycle
  
}

/*############## RIGHT DAC CODE ##############*/
void rightDAC( byte data ) //write the DAC pins for right motor high or low according to the denary value
{
  for( int i = 0; i<=7; i++ ) 
  {
    digitalWrite( DACPIN1[i] , ((data>>i)&1 ? HIGH : LOW));
  }
}

/*############## LEFTT DAC CODE ##############*/
void leftDAC( byte data ) //write the DAC pins for left motor high or low according to the denary value
{
  for( int i = 0; i<=7; i++ )
  {
    digitalWrite( DACPIN2[i] , ((data>>i)&1 ? HIGH : LOW));
  }
}


/*############## SERIAL COMMUNICATION CODE ##############*/
void serialCom(){
  static byte count = 10;

  if (Serial.available() >= 4) // Check that a full package of four bytes has arrived in the buffer.
  {
    startByte = Serial.read(); // Get the first available byte from the buffer

    if(startByte == START) // Confirm that the first byte was the start byte
    {
      
      //Read the remaining three bytes 
      operation = Serial.read();
      calibrate = Serial.read();
      checkByte = Serial.read();

      checkSum = startByte + operation + calibrate; // Calculate the check sum
      
      while (Serial.available() > 0) {
        Serial.read();  // Read and discard any incoming bytes
      }

      if(checkByte == checkSum) //Check if the calculated and sent check sum matches
      {
        Serial.write(START); //Send the start byte for tranmitting data

        byte leftSensor_byte = 0;
        byte rightSensor_byte = 0;

        if (leftSenval >= sensorThreshold){ //Comparing the threshold check if sensor is in or out
          leftSensor_byte = 0;
        }
        if (leftSenval < sensorThreshold){
          leftSensor_byte = 1;
        }
        Serial.write(leftSensor_byte); //Send the byte holding data about left sensor IN or OUT

        if (rightSenval >= sensorThreshold){
          rightSensor_byte = 0;
        }
        if (rightSenval < sensorThreshold){
          rightSensor_byte = 1;
        }
        Serial.write(rightSensor_byte); //Send the byte holding data about right sensor IN or OUT

        byte Duty1_byte = Duty1; // Convert int to byte before sending
        byte Duty2_byte = Duty2;
        Serial.write(Duty1_byte); // Send the right motor duty for GUI
        Serial.write(Duty2_byte); // Send the left motor duty for GUI
        byte checkSum1 = START + leftSensor_byte + rightSensor_byte + Duty1_byte + Duty2_byte;
        Serial.write(checkSum1);  
        
      }
    }    
  }
  else {
    // Start transmitting for intial transmission or disconnection
    if(count >= 10) {
      count=0;  // Reset counter

      // The below is thr normal transmission code
      Serial.write(START);

      byte leftSensor_byte = 0;
      byte rightSensor_byte = 0;

      if (leftSenval >= sensorThreshold){
        leftSensor_byte = 0;
      }
      if (leftSenval < sensorThreshold){
        leftSensor_byte = 1;
      }
      Serial.write(leftSensor_byte);

      if (rightSenval >= sensorThreshold){
        rightSensor_byte = 0;
      }
      if (rightSenval < sensorThreshold){
        rightSensor_byte = 1;
      }
      Serial.write(rightSensor_byte);

      byte Duty1_byte = Duty1;
      byte Duty2_byte = Duty2;
      Serial.write(Duty1_byte);
      Serial.write(Duty2_byte);
      byte checkSum1 = START + leftSensor_byte + rightSensor_byte + Duty1_byte + Duty2_byte;
      Serial.write(checkSum1); 
    }
    count++;
  }
}