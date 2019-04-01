﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ArduinoC
{
    public partial class Form1 : Form
    {
        System.IO.Ports.SerialPort ArduinoPort;
        private delegate void LineReceivedEvent(string POT);
        public Form1()
        {
            InitializeComponent();
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM3";  //sustituir por vuestro 
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            //vincular eventos
            this.FormClosing += FrmMain_FormClosing;
            ArduinoPort.DataReceived += serialPort1_DataReceived;

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string POT = ArduinoPort.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), POT);
        }

        

        private void LineReceived(string POT)
        {
            //What to do with the received line here
            this.label1.Text = POT;
            if (int.TryParse(label1.Text, out int t))
            {
                grafica(int.Parse(POT));
            }
            

        }
        
        public void grafica(int x)
        {
            if(x<=200)
            {
                chart1.Series[0].Points.AddXY(y, x);
                y++;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cerrar puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }

        int y = 0;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.AddXY(0, 200);
            timer1.Start();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
