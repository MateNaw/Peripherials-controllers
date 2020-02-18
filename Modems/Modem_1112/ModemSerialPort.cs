using System;
using System.IO.Ports;
using System.Threading;

namespace Modem_1112
{
    class ModemSerialPort
    {
        private SerialPort _serialPort;
        private Thread read;
        public ModemSerialPort(string portName)
        {
            _serialPort = new SerialPort(portName);
            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.Handshake = Handshake.RequestToSendXOnXOff;
            _serialPort.DtrEnable = true;

            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            if (_serialPort.IsOpen)
                _serialPort.Close();
            _serialPort.Open();

            read = new Thread(Read);
            read.Start();

            SendMessage("ATZ");
            Thread.Sleep(1000);
            SendMessage("ATE0");
        }

        private void Read()
        {
            while(_serialPort.IsOpen)
            {
                try
                {
                    string receivedMessage = _serialPort.ReadExisting();
                    if(receivedMessage.Length > 0)
                        Console.Write(receivedMessage);
                }
                catch (Exception)
                {
                }
            }
        }

        public void Send(char key)
        {
            _serialPort.Write(key.ToString());
        }

        public void SendMessage(string message)
        {
            _serialPort.Write(message + Environment.NewLine);
        }

        static public void ShowAvailablePorts()
        {
            Console.WriteLine("Dostepne porty: ");
            foreach (string port in SerialPort.GetPortNames())
                Console.WriteLine(" {0}", port);
        }

        public void Join()
        {
            _serialPort.Close();
            read.Join();
        }
    }
}
