using System.Device.Gpio;
using System.Device.I2c;
using Iot.Device.Adc;
using Iot.Device.OneWire;
using Iot.Device.RotaryEncoder;
using Raven.Iot.Device;
using Raven.Iot.Device.GpioExpander;
using UnitsNet;

var duration = TimeSpan.FromMinutes(1);
var interval = TimeSpan.FromSeconds(10);
if (DeviceHelper.GetGpioExpanderDevices() is [I2cConnectionSettings settings])
{
    using Ina219 device = new Ina219(settings);

    device.BusVoltageRange = Ina219BusVoltageRange.Range16v;
    device.PgaSensitivity = Ina219PgaSensitivity.PlusOrMinus40mv;
    device.SetCalibration(33574, (float)12.2e-6);
   
    while(true)
    {
        Console.WriteLine($"Bus Voltage {device.ReadBusVoltage()} Power {device.ReadPower() * 1000}mW Current {device.ReadCurrent()}mA") ;
    }
    
}
else
{
    Console.WriteLine("Device is not connected");
    Console.ReadKey();
}
