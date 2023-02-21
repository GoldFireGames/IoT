using DeviceSdkDemo.Device;
using Microsoft.Azure.Devices.Client;

string deviceConnectionString = "HostName=name-test-ul.azure-devices.net;DeviceId=jm-221013-2;SharedAccessKey=+BKFUpG43eKWe0d9oSXrdGGEwJlAuiq7ugfFP+f0dpE=";

using var deviceClient = DeviceClient.CreateFromConnectionString(deviceConnectionString, TransportType.Mqtt);
await deviceClient.OpenAsync();
var device = new VirtualDevice(deviceClient);

await device.InitializeHandlers();
await device.UpdateTwinAsync();

Console.WriteLine($"Connection success!");

await device.SendMessages(3, 1000);

Console.WriteLine("Finished! Press Enter to close...");
Console.ReadLine();
