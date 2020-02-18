using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Bluetooth_16._10._19
{
    class BTDevice
    {
        public BluetoothDeviceInfo DeviceInfo { get; set; }
        public string Address { get; set; }
        public bool Paired { get; set; }
        public bool Connected { get; set; }

        public BTDevice(BluetoothDeviceInfo rawInfo)
        {
            this.DeviceInfo = rawInfo;
            this.Address = rawInfo.DeviceAddress.ToString();
            this.Paired = rawInfo.Authenticated;
            this.Connected = rawInfo.Connected;
        }

        public override string ToString()
        {
            return "Name: " + this.DeviceInfo.DeviceName + " Address: " + this.Address;
        }
    }
}
