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

namespace final_GUI
{
    public partial class Setting : Form
    {
        public SerialPort _serial = new SerialPort();
        public Setting()
        {
            InitializeComponent();
            foreach (string s in SerialPort.GetPortNames()) //displays all the avaialable com ports in this device
            {
                comboBox1.Items.Add(s);
            }
        }

        //established connection between serial port and bluetooth
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    _serial.PortName = comboBox1.SelectedItem.ToString();   //selects port for serial communication
                    _serial.BaudRate = Convert.ToInt32(comboBox2.SelectedItem); //selects baudrate for serial communication
                    _serial.Open(); //tries to open the serial port
                    this.Close();   //closes this form
                    Form1 _main = new Form1();
                    foreach (Form1 tmpform in Application.OpenForms)
                    {
                        if (tmpform.Name == "Form1")
                        {
                            _main = tmpform;
                            break;
                        }
                    }

                    _main.toolStripStatusLabel1.Text = " Connected: " + _serial.PortName.ToString();
                    _main.toolStripStatusLabel1.ForeColor = Color.Green;
                    _main.toolStripProgressBar1.Value = 100;
                }
                catch
                {
                    MessageBox.Show("Please select proper COM Port/Baud Rate");
                }
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
    }
}
