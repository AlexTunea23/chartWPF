﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interfataMSP
{
    public class SerialProvider
    {

        SerialPort mySerialPort;
        List<string> receivedData = new List<string>();

        public SerialProvider()
        {
            SerialInit();
            SerialOpen();
        }

        public void SerialInit()
        {
            mySerialPort = new SerialPort("COM3");
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
            mySerialPort.DataReceived += DataReceivedHandler;
        }

        public void SerialOpen()
        {
            mySerialPort.Open();
        }

        public void SerialClose()
        {
            mySerialPort.Close();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort mySerialPort = (SerialPort)sender;
            receivedData.Add(mySerialPort.ReadLine());
        }

        public string GetFirstDataBuff()
        {

            if (receivedData.Any())
            {
                string data = receivedData.First();
                receivedData.Remove(data);
                data = data.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");

                return data;
            }
            return null;
        }

        public void Dispose()
        {
            mySerialPort.Dispose();
        }

        ~SerialProvider()
        {
            mySerialPort.Close();
        }

    }
}
