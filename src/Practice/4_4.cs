using System.Device.Gpio;
using System.Device.I2c;
using Iot.Device.Adc;
using Iot.Device.OneWire;
using Iot.Device.RotaryEncoder;
using Raven.Iot.Device;
using Raven.Iot.Device.GpioExpander;
using Raven.Iot.Device.Ina219;
using UnitsNet;


var duration = TimeSpan.FromMinutes(1);
var interval = TimeSpan.FromSeconds(10);

if (DeviceHelper.GetGpioExpanderDevices() is [I2cConnectionSettings settings])
{
    using Ina219 device = new Ina219(settings);

    TimeProvider.CreateTimer()
    List<(double Voltage, double Power, double Current)> data = new List<(double Voltage, double Power, double Current)>();
   
    while(/*timer*/)
    {
        Console.WriteLine($"Bus Voltage {device.ReadBusVoltage()} Power {device.ReadPower() * 1000}mW Current {device.ReadCurrent()}mA") ;
    }
    
}
else
{
    Console.WriteLine("Device is not connected");
    Console.ReadKey();
}
