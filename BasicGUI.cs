//MXEN 3000 line follower GUI
//Members - Lewhan Balasooriya, Oneli Haloluwa, Adithya Kulasekaram, Lushane de Silva, Laksika Panditharatne

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SerialGUISample
{    

    public partial class Form1 : Form
    {
        // Declare variables to store inputs and outputs.
        bool runSerial = true;
        bool byteRead = false;
        int Input1 = 0;
        int Input2 = 0;
        int Input3 = 0;
        int Input4 = 0;

        string Input1String;
        string Input2String;
        string Input3String;
        string Input4String;

        byte[] Outputs = new byte[4];
        byte[] Inputs = new byte[6];

        const byte START = 255;
        const byte ZERO = 0;
        byte OPERATION = 0;
        byte CALIBRATE = 0;

        private Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            // Initialize required for form controls.
            InitializeComponent();

            // Establish connection with serial
            if (runSerial == true)
            {
                if (!serial.IsOpen)                                  // Check if the serial has been connected.
                {
                    try
                    {
                        serial.Open();                               //Try to connect to the serial.
                    }
                    catch
                    {
                        statusBox.Enabled = false;
                        statusBox.Text ="ERROR: Failed to connect.";     //If the serial does not connect return an error.
                    }
                }
            }
        }

        private void Send1_Click(object sender, EventArgs e) //Press the button to send the value to start
        {
            OPERATION = 1; // The value 2 indicates Output1, value for output set in OutputBox1.
            sendIO(OPERATION, CALIBRATE);//send data transmission
            statusBox.Text = "Running";
            stopwatch.Reset(); // Reset the stopwatch
            stopwatch.Start(); // Start the stopwatch
            stopWatchTimer.Start(); // Start the timer
        }

        private void Send2_Click(object sender, EventArgs e) //Press the button to send the value to stop
        {
            OPERATION = 0;
            sendIO(OPERATION, CALIBRATE); //send data transmission
            statusBox.Text = "Stopping";
            stopwatch.Stop(); // Stop the stopwatch
            stopWatchTimer.Stop(); // Stop the timer
        }

        private void button1_Click(object sender, EventArgs e) //Press the button to send the value to calibrate sensors
        {
            CALIBRATE = 1;
            sendIO(OPERATION, CALIBRATE); //send data transmission
            statusBox.Text = "Calibrating";
        }

        private void sendIO(int STARTSTOP, int CALIBRATION)
        {
            Outputs[0] = START;    //Start value that indicates the beginning of the message.
            Outputs[1] = (byte)STARTSTOP;     //The value for the operation, start/stop
            Outputs[2] = (byte)CALIBRATION;  //The value for calibration
            Outputs[3] = (byte)(START + (byte)STARTSTOP + (byte)CALIBRATION); //The checksum byte to confirm the message was received correctly.

            if (serial.IsOpen)
            {
                serial.Write(Outputs, 0, 4); //Send all four bytes.                      
            }
        }

        

        private void getIOtimer_Tick(object sender, EventArgs e) //It is best to continuously check for incoming data as handling the buffer or waiting for event is not practical in C#.
        {

            if (serial.IsOpen) //Check that a serial connection exists.
            {
                
                if (serial.BytesToRead >= 6) //Check that the buffer contains a full four byte package.
                {
                    statusBox.Text = "Incoming"; 
                    Inputs[0] = (byte)serial.ReadByte(); //Read the first byte of the package.

                    if (Inputs[0] == START) //Check if the first byte is the start byte.
                    {
                        statusBox.Text = "Start Accepted";

                        //Read the data to varaibles
                        Inputs[1] = (byte)serial.ReadByte();
                        Inputs[2] = (byte)serial.ReadByte();
                        Inputs[3] = (byte)serial.ReadByte();
                        Inputs[4] = (byte)serial.ReadByte();
                        Inputs[5] = (byte)serial.ReadByte();

                        //Calculate the checksum.
                        byte checkSum = (byte)(Inputs[0] + Inputs[1] + Inputs[2] + Inputs[3] + Inputs[4]);
                        statusBox.Text = checkSum.ToString();
                        //Check that the calculated check sum matches the checksum sent with the message.
                        if (Inputs[5] == checkSum)
                        {
                            statusBox.Text = "Data Recieved";//indicating message recived is correct

                          
                            Input1 = Inputs[1];// indiacte the postion of the left sensor
                            if (Input1 == 0)
                            {
                                InputBox1.Text = "OUT";
                            }
                            else if(Input1 == 1)
                            {
                                InputBox1.Text = "IN";
                            }
                            else 
                            {
                                InputBox1.Text = "ERROR";
                            }

                            Input2 = Inputs[2];// indiacte the postion of the right sensor
                            if (Input2 == 0)
                            {
                                InputBox2.Text = "OUT";
                            }
                            else if(Input2 == 1)
                            {
                                InputBox2.Text = "IN";
                            }
                            else 
                            {
                                InputBox2.Text = "ERROR";
                            }

                            Input3 = Inputs[3];// display the duty cycle on a progressbar and textbox
                            
                            Input3String = Input3.ToString();
                            InputBox3.Text = Input3String;
                            progressBar1.Value = Input3;

                            Input4 = Inputs[4];// display the duty cycle on a progressbar and textbox

                            Input4String = Input4.ToString();
                            InputBox4.Text = Input4String;
                            progressBar2.Value = Input4;
                        
                            CALIBRATE = 0; //Reset calibration variable
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Obtain com port names
        {
            string[] ports= SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // This allows the user to select the desiered COM port, if multiple COM ports are available
        {
            if (comboBox1.SelectedItem != null)
            {
                serial.PortName = comboBox1.SelectedItem.ToString();  // Set the COM port to the selected value
                statusBox.Text = "Port set to " + serial.PortName;

                try
                {
                    if (!serial.IsOpen) //Check if Serial port is not already open
                    {
                        serial.Open();  // Try to open the serial connection
                        statusBox.Text = "Connected to " + serial.PortName; // If Serial connection is established shows the COM port name on the statusbox
                    }
                }
                catch 
                {
                    statusBox.Enabled = false;
                    statusBox.Text = "ERROR: Failed to connect."; //display the connection error
                }
            }
        }

        private void stopWatchTimer_Tick(object sender, EventArgs e)
        {
            textBox1.Text = stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff"); //Display the stop watch time on text box
        }

        

    }
    
}
