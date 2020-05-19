using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

//   w       i      W - ANDA PARA FRENTE         I - INVERTE AS DIREÇÕES DO ROBÔ
// a   d   j   l    A - VIRA PRA ESQUERDA        J - LIGA A ARMA NO SENTIDO ANTI HORÁRIO
//   s       k      S - ANDA PARA TRÁS           K - ------------------------------
//                  D - VIRA PARA A DIREITA      L - LIGA A ARMA NO SENTIDO HORÁRIO

namespace ComputerToArduino
{
    public partial class Form1 : Form

    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        public Form1()
        {
            InitializeComponent();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }
         private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
                {
                    case (char)Keys.W:
                        port.Write("{W}");
                        break;
                    case (char)Keys.A:
                        port.Write("{A}");
                        break;
                    case (char)Keys.S:
                        port.Write("{S}");
                        break;
                    case (char)Keys.D:
                        port.Write("{D}");
                        break;
                    case (char)Keys.I:
                        port.Write("{I}");
                        break;
                    case (char)Keys.L:
                        port.Write("{L}");
                        break;
                    case (char)Keys.K:
                        port.Write("{K}");
                        break;
                    case (char)Keys.J:
                        port.Write("{J}");
                        break;
                    default:
                        break;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            } else
            {
                disconnectFromArduino();
            }
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
        }
    }
}
