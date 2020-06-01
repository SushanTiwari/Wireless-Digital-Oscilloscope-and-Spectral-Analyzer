using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using ZedGraph;

namespace final_GUI
{
    public partial class Form1 : Form
    {
        private Setting _setting = new Setting();   //creating object for secondary form

        UInt32 temp_data = 0;    //variable to store temporary data for calculation

        #region Plot Buffers, signals

        private static Int16 BUFFER_SIZE= 200;  //Buffer size for all signals

        
        double[] time_domain_signal_buffer = new double[BUFFER_SIZE];   //buffer that hols time domain signal
        Int16 time_domain_signal_index = 0; //index for time domain signal buffer
            
        double[] DFT_amplitude_signal_buffer = new double[BUFFER_SIZE]; //buffer that holds DFT amplitude signal

        double[] DFT_phase_signal_buffer = new double[BUFFER_SIZE]; //buffer that holds DFT phase signal
        Boolean DFT_phase = true;   //flag that determines if DFT phase is to be shown or DFT magnitude

        Boolean start_pressed = false;      //signal that determines if start button is pressed
        Boolean clear_pressed = false;      //signal that determines if clear button is pressed
        Boolean single_pressed = false;     //signal that determines if single_button is pressed

        float max_sampling_frequency = 174662;  //intial value for max_sampling_frequency

        double max_value = 0;  //used to find peak-peak value
        double min_value = 0;  //also used to find peak-peak value

        Boolean linear_plot = true;     //flag that determines if DFT amplitde is to be shown in linear scale of logarithmic scale 
        #endregion

        #region Zedgraph Declaration Starts Here


        GraphPane mypane_1 = new GraphPane();   //for 1st plot representing time domain signal

        GraphPane mypane_2 = new GraphPane();   //for 2nd plot representing DFT 

        PointPairList listA = new PointPairList();  //continous time signal
        PointPairList listB = new PointPairList();  //DFT amplitude signal
        PointPairList listC = new PointPairList();  //DFT phase signal

        LineItem teamAcurve;    //Time domain signal plot
        LineItem teamBcurve;    //DFT magnitude signal plot
        LineItem teamCcurve;    //DFT phase signal plot

        private delegate void CalldrawGraph();      //initializing a delegate to ensure safe cross thread call for plotting data in backgroundworker

        /// Zedgraph Declaration Ends here

        #endregion

        public Form1()
        {
            InitializeComponent();
            graph_init();   //intializing zed graphs 
            trigger_value.Text = ((float)trackBar2.Value*5.0/255).ToString("0.0");
            textBox1.Text = trackBar1.Value.ToString();
            freq_box.Text = "1";
        }
       

        #region Zedgraph
        private double[] teamA()    //method used to extract raw adc samples 
        {
            double[] a = new double[BUFFER_SIZE];
            for (int i = 0; i < BUFFER_SIZE; i++)
            {
                //store values from continous time signal buffer
                
                a[i] = time_domain_signal_buffer[i] * 5 / 255.0;

                

                calculate_dft_magnitude_phase(i);   //calculates DFT magnitude and phase
            }
            max_value = a.Max();    //finding maximum value from the array
            min_value = a.Min();    //finding minimum value from the array

            float amplitude = (float)(max_value - min_value);   //finding peak-peak value
            peak_to_peak.Text = amplitude.ToString();   //displaying peak-peak value to the text box
            return a;
        }

        private double[] teamB()    //extracts DFT magnitude samples
        {
            double[] a = new double[BUFFER_SIZE];
            double[] b = new double[BUFFER_SIZE / 2];

            for (int i = 0; i < BUFFER_SIZE; i++)
            {
                //store values from DFT amplitude signal buffer
                a[i] = DFT_amplitude_signal_buffer[i];
                if (i > BUFFER_SIZE / 2)
                {
                    b[i - (BUFFER_SIZE / 2)] = DFT_amplitude_signal_buffer[i];
                }
            }
            double maxValue = b.Max();  //finding max value
            int index = Array.IndexOf(b, maxValue); //finding index of max value

            float freq = (float)((max_sampling_frequency/(1.0* BUFFER_SIZE)) * index);  //converting index of max value into frequency of input signal
            freq_box.Text = freq.ToString();    //displaying the frequency to text box

            return a;

        }

        private double[] teamC()    //extracts DFT phase samples
        {
            double[] a = new double[BUFFER_SIZE];
            for (int i = 0; i < BUFFER_SIZE; i++)
            {
                //store values from DFT phase signal buffer
                a[i] = DFT_phase_signal_buffer[i];
            }
            return a;

        }
        private void graph_init()
        {
            
            mypane_1 = zedGraphControl1.GraphPane;  //associates graph pane to first zedgraph
            
            mypane_1.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.MintCream); //sets the background color 
            mypane_1.Fill = new Fill(Color.FromArgb(192, 192, 255));    //sets the outer area colot

            mypane_1.Title.Text = "Time Domain";    //sets the title for the chart
            mypane_1.XAxis.Title.Text = "Time(s)";  //sets the xlabel
            mypane_1.YAxis.Title.Text = "Voltage(V)";   //sets the ylabel

            mypane_2 = zedGraphControl2.GraphPane;  //associates graph pane to second zedgraph
            mypane_2.Title.Text = "DFT";
            mypane_2.XAxis.Title.Text = "Frequency(Hz)";
            mypane_2.YAxis.Title.Text = "Amplitude(V)";
            mypane_2.Y2Axis.Title.Text = "Phase(Degree)";
            mypane_2.Y2Axis.IsVisible = true;   //enables second Yaxis for the graph

            mypane_2.Fill.Color = Color.Wheat;

            mypane_1.XAxis.MajorGrid.IsVisible = true;  //turns on the grid
            mypane_2.XAxis.MajorGrid.IsVisible = true;

            mypane_1.YAxis.MajorGrid.IsVisible = true;
            mypane_1.YAxis.MinorGrid.IsVisible = true;

            mypane_2.YAxis.MajorGrid.IsVisible = true;

            

            double[] a = teamA();
            double[] b = teamB();
            double[] c = teamC();

            for (int i = 0; i < BUFFER_SIZE; i++)   //adds the value into the list
            {
                listA.Add(i, a[i]);
                listB.Add(-50+i, b[i]);
                listC.Add(-50+i, c[i]);
            }

            teamAcurve = mypane_1.AddCurve("Time Domain Signal", listA, Color.Blue, SymbolType.None);   //creates a curve to be plotted into the grpah
            teamBcurve = mypane_2.AddCurve("DFT Amplitude", listB, Color.Tomato, SymbolType.None);
            teamCcurve = mypane_2.AddCurve("DFT Phase", listC, Color.Black, SymbolType.None);


            
            mypane_1.YAxis.Scale.Max = 5;   //changing the max value for Yaxis
            mypane_1.YAxis.Scale.Min = 0;   //changing the min value for Yaxis

            teamBcurve.IsVisible = false;
            teamCcurve.IsVisible = true;
            mypane_2.YAxis.IsVisible = false;
            mypane_2.Y2Axis.IsVisible = true;
         
            zedGraphControl1.AxisChange();
            zedGraphControl1.IsShowPointValues = true;

            zedGraphControl2.AxisChange();
            zedGraphControl2.IsShowPointValues = true;

            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
        }

        private void updatePlot()   //method that updates the plot after receiving new samples
        {

            if (zedGraphControl1.InvokeRequired || zedGraphControl2.InvokeRequired)
            {
                var d = new CalldrawGraph(updatePlot);  //method used to have safe-cross thread call
                Invoke(d);
            }
            else
            {
                teamAcurve.Clear();
                teamBcurve.Clear();
                teamCcurve.Clear();

                double[] a = teamA();
                double[] b = teamB();
                double[] c = teamC();

                float sampling_freq = float.Parse(max_sampling_freq.Text);
                float freq = float.Parse(freq_box.Text);
                int cycles = int.Parse(textBox1.Text);

                int points_to_show = (int)(sampling_freq/freq*cycles);
                
                if (points_to_show <= BUFFER_SIZE)
                {
                    for (int i = 0; i < points_to_show; i++)
                    {
                        listA.Add((double)(i/sampling_freq), a[i]);
                    }
                    mypane_1.XAxis.Scale.Max = (float)(points_to_show/sampling_freq)-(float)(1/sampling_freq);
                }
                else
                {
                    for (int i = 0; i < BUFFER_SIZE; i++)
                    {
                        listA.Add(i, a[i]);
                    }
                    mypane_1.XAxis.Scale.Max = BUFFER_SIZE-1;
                }

               
                if (linear_plot)
                {
                    //adding imaginary part from DFT into respective list
                    mypane_2.YAxis.Title.Text = "Amplitude(V)";
                    for (int i = 0; i < BUFFER_SIZE / 2; i++)
                    {
                        listB.Add((i - BUFFER_SIZE / 2) * (sampling_freq / BUFFER_SIZE), b[i]);
                        listC.Add((i - BUFFER_SIZE / 2) * (sampling_freq / BUFFER_SIZE), c[i]);
                    }

                    //adding DC part from DFT into respective list
                    listB.Add(0, b[BUFFER_SIZE / 2]);
                    listC.Add(0, c[BUFFER_SIZE / 2]);

                    //adding real part from DFT into respective list
                    for (int i = BUFFER_SIZE / 2 + 1; i < BUFFER_SIZE; i++)
                    {
                        listB.Add((i - BUFFER_SIZE / 2) * (sampling_freq / BUFFER_SIZE), b[i]);
                        listC.Add((i - BUFFER_SIZE / 2) * (sampling_freq / BUFFER_SIZE), c[i]);
                    }
                }
                else//  plot in DB form
                {
                    double max_db_value =b.Max();
                    mypane_2.YAxis.Title.Text = "Amplitude(dB)";
                    //adding imaginary part from DFT into respective list
                    for (int i = 0; i < BUFFER_SIZE / 2; i++)
                    {
                       listB.Add((i-BUFFER_SIZE / 2) * (sampling_freq/BUFFER_SIZE), 20*Math.Log10(b[i]/ max_db_value));
                       listC.Add((i - BUFFER_SIZE / 2) * (sampling_freq / BUFFER_SIZE), c[i]);
                    }

                    //adding DC part from DFT into respective list
                    listB.Add(0, 20*Math.Log10(b[BUFFER_SIZE / 2]/ max_db_value));
                    listC.Add(0, c[BUFFER_SIZE / 2]);

                    //adding real part from DFT into respective list
                    for (int i = BUFFER_SIZE / 2 + 1; i < BUFFER_SIZE; i++)
                    {
                       listB.Add((i-BUFFER_SIZE / 2) * (sampling_freq/BUFFER_SIZE), 20 * Math.Log10( b[i]/ max_db_value));
                       listC.Add((i - BUFFER_SIZE / 2) * (sampling_freq / BUFFER_SIZE), c[i]);
                    }
                }

                mypane_2.XAxis.Scale.Max = sampling_freq/2;
                mypane_2.XAxis.Scale.Min = -sampling_freq/2;
                if (DFT_phase)
                {
                    //turning on phase plot and turning off amplitude plot
                    teamBcurve.IsVisible = false;
                    teamCcurve.IsVisible = true;
                    mypane_2.YAxis.IsVisible = false;
                    mypane_2.Y2Axis.IsVisible = true;
                }
                else
                {
                    //turning off phase plot and turning on amplitude plot 
                    teamBcurve.IsVisible = true;
                    teamCcurve.IsVisible = false;
                    mypane_2.YAxis.IsVisible = true;
                    mypane_2.Y2Axis.IsVisible = false;
                }

                mypane_1.AxisChange();
                mypane_2.AxisChange();

                zedGraphControl1.Refresh();
                zedGraphControl2.Refresh();


                if (start_pressed && !single_pressed)
                {
                    //sending PIC signal to send another set of data
                    char[] ch = new char[1];
                    ch[0] = '~';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

                    //sending PIC signal to send another max sampling freq data 
                    ch[0] = '%';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                }
            }

        }

        //claculates magnitude and phase of one signal and stores in the buffer
        private void calculate_dft_magnitude_phase(int index)
        {
            int rem = 0;
            double a;
            double real = 0, 
                img=0;

            for (int i = 0; i < BUFFER_SIZE; i++)
            {
                a = time_domain_signal_buffer[i]*5.0/(256.0*BUFFER_SIZE);
                Math.DivRem(i, 2, out rem);
                if (rem != 0)
                    a *= -1;

                real += (double)(a * Math.Cos(2 * (Math.PI / BUFFER_SIZE) * i * index));
                img += (double)(-1 * a* Math.Sin(2 * (Math.PI / BUFFER_SIZE) * i * index));
            }

            double mag = (double)(Math.Sqrt(Math.Pow(real, 2) + Math.Pow(img, 2))); //calculating DFT magnitude
            DFT_amplitude_signal_buffer[index] = mag;   //storing DFT magnitude

            double phase = (double)(Math.Atan2(img,real) * 180 / Math.PI);  //calculating DFT phase
            DFT_phase_signal_buffer[index] = phase; //storing DFT phase
        }
        #endregion

        private void COMPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _setting.Show();    //displaying secondary form
            _setting._serial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)  //data receive handler to extract received bytes from the buffer
        {
            SerialPort sp = (SerialPort)sender;

            try
            {
                if (sp.BytesToRead > 0)
                {
                    byte[] buffer = new byte[sp.BytesToRead];
                    int count = sp.Read(buffer, 0, sp.BytesToRead);
                    modify_richtextbox1(buffer, count);
                }
            }
            catch
            {
                sp.DiscardInBuffer();
            }
        }

        private void modify_richtextbox1(byte[] buffer, int count)  //method to extract each byte of data 
        {
            byte data;
            for (int i = 0; i < count; i++)
            {
                data = buffer[i];
                this.Invoke(new EventHandler(write_richtextbox1), new object[] { data });   //implementing safe-cross thread call
            }
        }

        private void write_richtextbox1(object sender, EventArgs e) //read each byte of data 
        {
            byte data = (byte)sender;
            char s = Convert.ToChar(data);  //converting byte into character
            if (s == '!')   //start of samples
            {
                temp_data = 0;
                time_domain_signal_index = 0;
            }
            else if (s >= '0' && s <= '9')  //numeric data
            {   
                temp_data = (UInt32)(temp_data * 10 + (s - '0'));
            }
            else if (s == ' ')  //interval between samples
            {

                try
                {
                    time_domain_signal_buffer[time_domain_signal_index++] = (double)(temp_data);    //storing each sample into buffer
                    temp_data = 0;
                }
                catch {

                }
            }
            else if (s == '@')  //end of samples
            {
                if (!clear_pressed)
                {
                    updatePlot();
                }
            }
            else if (s == '#')//start of maximum sampling freq value
            {
                temp_data = 0;
            }
            else if (s == '$')  //end of maximum sampling freq value
            {
                this.Invoke(new EventHandler(updateSampling_freq_textBox), new object[] { temp_data }); //calling this method to display the sampling freqeuncy
            }
            else if (s == '*')  //start signal sent from Keypad
            {
                start_pressed = true;
                clear_pressed = false;
                single_pressed = false;
                button1.BackColor = Color.Lime;     //changing button color to Green
            }
            else if (s == '&')  //stop signal sent from keypad
            {
                start_pressed = false;
                button1.BackColor = Color.Red;      //changing button color to red
            }
            else if (s == '+')  //increase sampling frequency sent from keypad
            {
                //increase sampling freq
                switch ((string)comboBox1.Text) //determines current sampling freqeuncy setting 
                {
                    case "Fs":
                        comboBox1.Text = "Fs";
                        break;
                    case "Fs/4":
                        comboBox1.Text = "Fs";
                        break;
                    case "Fs/16":
                        comboBox1.Text = "Fs/4";
                        break;
                    case "Fs/100":
                        comboBox1.Text = "Fs/16";
                        break;
                }
                if (start_pressed)  //determines if sampling has started or not
                {
                    //sending PIC signal to send another set of data
                    char[] ch = new char[1];
                    ch[0] = '~';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

                    //sending PIC signal to send another max sampling freq data 
                    ch[0] = '%';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    //_setting._serial.Write("%");
                }
            }
            else if (s == '-')  //decrease sampling frequency sent from keypad
            {
                //decrease sampling freq
                switch ((string)comboBox1.Text)
                {
                    case "Fs":
                        comboBox1.Text = "Fs/4";
                        break;
                    case "Fs/4":
                        comboBox1.Text = "Fs/16";
                        break;
                    case "Fs/16":
                        comboBox1.Text = "Fs/100";
                        break;
                    case "Fs/100":
                        comboBox1.Text = "Fs/100";
                        break;
                }
                if (start_pressed)
                {
                    //sending PIC signal to send another set of data
                    char[] ch = new char[1];
                    ch[0] = '~';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

                    //sending PIC signal to send another max sampling freq data 
                    ch[0] = '%';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                }
            }
        }

        private void updateSampling_freq_textBox(object sender, EventArgs e)    //updates the sampling frequency with new value received from PIC
        {
            float freq;
            UInt32 time_value = (UInt32)(sender);
            
            freq = (float)((1.0 / (float)time_value) * BUFFER_SIZE * 16.0 * Math.Pow(10, 6));   //converts the timer value into frequency
            max_sampling_freq.Text = freq.ToString();
            max_sampling_frequency = freq;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!start_pressed || button1.BackColor==Color.Red) //start samplinng
            {
                _setting._serial.Write("*");
                _setting._serial.Write("%");    //sending PIC signal to send another max sampling freq data 
                start_pressed = true;           //start button is pressed
                clear_pressed = false;          //reset clear button pressed flag
                single_pressed = false;         //reset single button pressed flag
                button1.BackColor = Color.Lime;
            }
            else if(start_pressed)  //stop sampling
            {
                char[] ch = new char[1];
                ch[0] = '&';
                _setting._serial.Write(ch,0,1);    //sending stop_sampling_signal 
                start_pressed = false;
                button1.BackColor = Color.Red;
            }
        }


        //clear the current grpah on Zedgraph Control
        private void Button3_Click(object sender, EventArgs e)
        {
            char[] ch = new char[1];
            ch[0] = '&';
            _setting._serial.Write(ch, 0, 1);    //sending stop_sampling_signal 
            start_pressed = false;
            clear_pressed = true;
            teamAcurve.Clear();
            teamBcurve.Clear();
            teamCcurve.Clear();

            mypane_1.AxisChange();
            mypane_2.AxisChange();

            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
            _setting._serial.Write("c");        //sending clear_signal to PIC
        }

        //single display button click event handler 
        private void Button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            single_pressed = true;  //single button is pressed
            clear_pressed = false;
            //sending PIC signal to send another set of data
            char[] ch = new char[1];
            ch[0] = '~';
            _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

            //sending PIC signal to send another max sampling freq data 
            ch[0] = '%';
            _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
        }

        //sampling frequency combobox value changed event 
        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            char[] ch = new char[1];
            
            switch ((string)comboBox1.Text) //determines current setting for sampling frequency
            {
                case "Fs":
                    ch[0] = 'A';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    break;
                case "Fs/4":
                    ch[0] = 'B';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    break;
                case "Fs/16":
                    ch[0] = 'C';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    break;
                case "Fs/100":
                    ch[0] = 'D';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    break;
                default:
                    ch[0] = 'A';
                    _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    break;
            }
        }

       
        //event handler for trigger value changed
        private void TrackBar2_MouseUp(object sender, MouseEventArgs e)
        {
            
            _setting._serial.Write("(" + trackBar2.Value.ToString() + ")"); //sending trigger value to PIC

            char[] ch = new char[1];
            ch[0] = '~';
            _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

            //sending PIC signal to send another max sampling freq data 
            ch[0] = '%';
            _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
        }

        //event handler for displaying new trigger value
        private void TrackBar2_ValueChanged(object sender, EventArgs e)
        {
            trigger_value.Text = ((float)trackBar2.Value * 5.0 / 255).ToString("0.0");
        }

        //event handler for number of cycles to be displayed changed
        private void TrackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar3.Value.ToString();
        }

        //event handler for magnitude span changed
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();

        }

        //magnitude span changed event handler that changes the scale of time domain signal
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

            switch (textBox2.Text)
            {
                case "1":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "1V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 5;
                    mypane_1.YAxis.Scale.Min = 0;
                    break;
                case "2":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.5V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5+(2.5/2);
                    mypane_1.YAxis.Scale.Min = 2.5-(2.5/2);
                    break;
                case "3":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.2V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5 + (2.5 / 4);
                    mypane_1.YAxis.Scale.Min = 2.5 - (2.5 / 4);
                    break;
                case "4":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.1V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5 + (2.5 / 8);
                    mypane_1.YAxis.Scale.Min = 2.5 - (2.5 / 8);
                    break;
                case "5":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.05V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5 + (2.5 / 16);
                    mypane_1.YAxis.Scale.Min = 2.5 - (2.5 / 16);
                    break;
                case "6":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.02V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5 + (2.5 / 32);
                    mypane_1.YAxis.Scale.Min = 2.5 - (2.5 / 32);
                    break;
                case "7":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.01V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5 + (2.5 / 64);
                    mypane_1.YAxis.Scale.Min = 2.5 - (2.5 / 64);
                    break;
                case "8":
                    textBox2.TextChanged -= new EventHandler(TextBox2_TextChanged);
                    textBox2.Text = "0.01V";
                    textBox2.TextChanged += new EventHandler(TextBox2_TextChanged);
                    mypane_1.YAxis.Scale.Max = 2.5 + (2.5 / 100);
                    mypane_1.YAxis.Scale.Min = 2.5 - (2.5 / 100);
                    break;
                default:
                    break;
            }

            mypane_1.AxisChange();
            zedGraphControl1.AxisChange();

            zedGraphControl1.Refresh();
        }

        //switches DFT amplitude/phase plot
        private void Button5_Click(object sender, EventArgs e)
        {
            if (DFT_phase)
            {
                DFT_phase = false;
                button5.Text = "DFT Amplitude";
                //turning on phase plot and turning off amplitude plot
                teamBcurve.IsVisible = false;
                teamCcurve.IsVisible = true;
                mypane_2.YAxis.IsVisible = false;
                mypane_2.Y2Axis.IsVisible = true;
                zedGraphControl2.AxisChange();
                zedGraphControl2.Refresh();
            }
            else
            {
                DFT_phase = true;
                button5.Text = "DFT Phase";
                //turning off phase plot and turning on amplitude plot 
                teamBcurve.IsVisible = true;
                teamCcurve.IsVisible = false;
                mypane_2.YAxis.IsVisible = true;
                mypane_2.Y2Axis.IsVisible = false;
                zedGraphControl2.AxisChange();
                zedGraphControl2.Refresh();
            }
        }

        //sends character typed in rich text box to PIC using keyboard
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            char[] ch = new char[1];
            switch (richTextBox1.Text)
            {
                case "*":
                    _setting._serial.Write("*");
                    _setting._serial.Write("%");     //sending PIC signal to send another max sampling freq data 
                    start_pressed = true;           //start button is pressed
                    clear_pressed = false;          //reset clear button pressed flag
                    single_pressed = false;         //reset single button pressed flag
                    button1.BackColor = Color.Lime;
                    break;
                case "#":
                    
                    ch[0] = '&';
                    _setting._serial.Write(ch, 0, 1);    //sending stop_sampling_signal 
                    start_pressed = false;
                    button1.BackColor = Color.Red;
                    break;
                case "c":
                    
                    ch[0] = '&';
                    _setting._serial.Write(ch, 0, 1);    //sending stop_sampling_signal 
                    start_pressed = false;
                    clear_pressed = true;
                    teamAcurve.Clear();
                    teamBcurve.Clear();
                    teamCcurve.Clear();

                    mypane_1.AxisChange();
                    mypane_2.AxisChange();

                    zedGraphControl1.Refresh();
                    zedGraphControl2.Refresh();
                    _setting._serial.Write("c");        //sending clear_signal to PIC
                    break;
                case "2":
                    switch ((string)comboBox1.Text)
                    {
                        case "Fs":
                            comboBox1.Text = "Fs";
                            break;
                        case "Fs/4":
                            comboBox1.Text = "Fs";
                            break;
                        case "Fs/16":
                            comboBox1.Text = "Fs/4";
                            break;
                        case "Fs/100":
                            comboBox1.Text = "Fs/16";
                            break;
                    }
                    if (start_pressed)
                    {
                        //sending PIC signal to send another set of data
                        ch[0] = '~';
                        _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

                        //sending PIC signal to send another max sampling freq data 
                        ch[0] = '%';
                        _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                                                             //_setting._serial.Write("%");
                    }
                    break;

                case "3":
                    switch ((string)comboBox1.Text)
                    {
                        case "Fs":
                            comboBox1.Text = "Fs/4";
                            break;
                        case "Fs/4":
                            comboBox1.Text = "Fs/16";
                            break;
                        case "Fs/16":
                            comboBox1.Text = "Fs/100";
                            break;
                        case "Fs/100":
                            comboBox1.Text = "Fs/100";
                            break;
                    }
                    if (start_pressed)
                    {
                        //sending PIC signal to send another set of data
                        ch[0] = '~';
                        _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal

                        //sending PIC signal to send another max sampling freq data 
                        ch[0] = '%';
                        _setting._serial.Write(ch, 0, 1);    //sending start_sampling_signal
                    }
                    break;
                default:
                    break;

            }
            richTextBox1.TextChanged -= new EventHandler(RichTextBox1_TextChanged);
            richTextBox1.Text = "";
            richTextBox1.TextChanged += new EventHandler(RichTextBox1_TextChanged);
        }

        //switches between DFT amplitude linear/logarithmic scale
        private void Linear_db_Click(object sender, EventArgs e)
        {
            float sampling_freq = float.Parse(max_sampling_freq.Text);
            if (linear_plot)
            {
                linear_db.BackColor = Color.Gold;
                linear_db.Text = "Logarithmic";
                linear_plot = false;
                mypane_2.YAxis.Title.Text = "Amplitude(V)";
            }
            else
            {
                linear_db.BackColor = Color.DarkTurquoise;
                linear_db.Text = "Linear";
                linear_plot = true;
                mypane_2.YAxis.Title.Text = "Amplitude(dB)";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
