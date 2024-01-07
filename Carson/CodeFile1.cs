using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Storage.Streams;
using System.Media;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace Carson
{
    public partial class Form1 : Form

    {
        Dictionary<string, DeviceInformation> devices = new Dictionary<string, DeviceInformation>();

        private DeviceWatcher deviceWatcher;
        int ECG_voltage = 0;
        float ECG_float = 0;
        int sample_limit = 200;

        private static string ECG_SERVICE = "00000000000000000000000000001516";
        private static string ECG_SIGNAL_NOTIFICATION = "00000000000000000000000000002a01";


        BluetoothLEDevice ECGBoard = null;

        GattDeviceService ECG_Service = null;

        GattCharacteristic ECG_Notify_Characteristic = null;

        private void StartBLEDeviceWathcer()
        {

            // Query for extra properties you want returned
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected" };

            deviceWatcher = DeviceInformation.CreateWatcher(
                                BluetoothLEDevice.GetDeviceSelectorFromPairingState(false),
                                requestedProperties,
                                DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            // Added, Updated and Removed are required to get all nearby devices
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;

            // EnumerationCompleted and Stopped are optional to implement.
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start the watcher.
            deviceWatcher.Start();
        }

        private async Task<int> ConnectBLE()
        {
            StopBleDeviceWatcher();

            try
            {
                if (BLE_List_View.SelectedItems[0].Text == "ECG")
                {
                    string ECGName = BLE_List_View.SelectedItems[0].Text;

                    ECGBoard = await BluetoothLEDevice.FromIdAsync(devices[ECGName].Id);

                    if (ECGBoard != null)
                    {

                        ECGBoard.ConnectionStatusChanged += CurrentDevice_ConnectionStatusChanged;
                        await GetServices(ECGBoard);
                        return 1;
                       
                    }

                    else
                    {

                        return 0;
                    }



                }
                else
                {
                    return 0;
                }
            }


            catch (Exception ex)
            {
                //Terminal.AppendText(ex.ToString() + "\n");
                return 0;
                //throw ex;

            }

        }

        private async Task GetServices(BluetoothLEDevice Board)
        {
            GattDeviceServicesResult serviceResult;
            serviceResult = await Board.GetGattServicesAsync();

            if (serviceResult.Status == GattCommunicationStatus.Success)
            {
                var services = serviceResult.Services;

                //ECG_SERVICE
                //ECG_SIGNAL_NOTIFICATION 

                foreach (var service in services)
                {
                    string servicename;
                    servicename = service.Uuid.ToString("N");
                    //Terminal.AppendText(servicename + '\n');


                    if (servicename == ECG_SERVICE)
                    {
                        await GetCharacteristics(service, Board);
                        ECG_Service = service;
                    }

                    /*
                    if (servicename == POWER_ADC_SERVICE)
                    {
                        Power_ADC_Service = service;
                    }

                    else if (servicename == STENT_ADC_SERVICE)
                    {
                        Stent_ADC_Service = service;
                    }

                    */
                }
            }

        }

        private async Task GetCharacteristics(GattDeviceService service, BluetoothLEDevice Board)
        {

            GattCharacteristicsResult characteristicResult;
            characteristicResult = await service.GetCharacteristicsAsync();

            if (characteristicResult.Status == GattCommunicationStatus.Success)
            {
              //  Terminal.AppendText("Found characacteristics\n");

                var characteristics = characteristicResult.Characteristics;

                foreach (var characteristic in characteristics)
                {
                    string charname;
                    charname = characteristic.Uuid.ToString("N");
                    //Terminal.AppendText(charname + '\n');

                    GattCharacteristicProperties properties;
                    properties = characteristic.CharacteristicProperties;

                    if (properties.HasFlag(GattCharacteristicProperties.Notify))
                    {
                        if (characteristic.Uuid.ToString("N") == ECG_SIGNAL_NOTIFICATION)
                        {
                            ECG_Notify_Characteristic = characteristic;
                        }

                        await SuscribeToNotification(characteristic, Board);

                    }

                    if (properties.HasFlag(GattCharacteristicProperties.Write))
                    {

                    }


                    if (properties.HasFlag(GattCharacteristicProperties.Read))
                    {


                    }


                }

            }
        }

        private void Disconnect_ECG()
        {
            this?.Invoke(new Action(() =>
            {
                if (ECGBoard != null)
                {
                    ECGBoard.ConnectionStatusChanged -= CurrentDevice_ConnectionStatusChanged;
                    ECG_Notify_Characteristic.ValueChanged -= Characteristic_ValueChanged;
                    //Power_Battery_Notify_Characteristic.ValueChanged -= Characteristic_ValueChanged;

                    ECG_Service.Dispose();
                    ECGBoard.Dispose();
                    devices.Remove("ECG");


                    ECGBoard = null;

                    Connect_LED.Color = Color.White;

                }

                else
                {
                    //Terminal.AppendText("Power Board not Connected.\n");
                }
            }));
        }

        private void CurrentDevice_ConnectionStatusChanged(BluetoothLEDevice Board, object args)
        {
            //  throw new NotImplementedException();

            if (Board.ConnectionStatus == BluetoothConnectionStatus.Disconnected)
            {
                if (Board == ECGBoard)
                {
                    this?.Invoke(new Action(() =>
                    {

                        ECGBoard = null;
                        ECG_Notify_Characteristic = null;
                        ECG_Service = null;



                        Connect_LED.Color = Color.White;
                        devices.Remove("ECG");
                    }));
                }
            }

        }

        private async Task SuscribeToNotification(GattCharacteristic characteristic, BluetoothLEDevice Board)
        {
            GattCommunicationStatus status;
            status = await characteristic.WriteClientCharacteristicConfigurationDescriptorAsync(
                GattClientCharacteristicConfigurationDescriptorValue.Notify);

            if (status == GattCommunicationStatus.Success)
            {
                characteristic.ValueChanged += Characteristic_ValueChanged;
                // Terminal.AppendText(":)))\n");

            }

            // BLE_List_View.Items.Remove(BLE_List_View.SelectedItems[0]);

        }

        private void Characteristic_ValueChanged(GattCharacteristic board_characteristic, GattValueChangedEventArgs notification_data)
        {
            // throw new NotImplementedException();
            if (board_characteristic.Uuid.ToString("N") == ECG_SIGNAL_NOTIFICATION)
            {
                this?.Invoke(new Action(() =>
                {
                    byte[] power_package = notification_data.CharacteristicValue.ToArray();



                    // Extract the first four bytes into one int variable
                    int power_raw = (power_package[0] << 24) | (power_package[1] << 16)
                    | (power_package[2] << 8) | power_package[3];

                    power_raw = Convert_Endianness(power_raw);


                    ECG_voltage = (power_package[4] << 24) | (power_package[5] << 16)
                    | (power_package[6] << 8) | power_package[7];

                    ECG_voltage = Convert_Endianness(ECG_voltage);

                    //ECG_float = (float)ECG_voltage;
                    //ECG_Chart.Series[0].Points.Add(ECG_voltage);
                    //Console.WriteLine(ECG_voltage);

                    ECG_Chart.Series[0].Points.Add(ECG_voltage);
                    if (ECG_Chart.Series[0].Points.Count > sample_limit)
                    {
                        ECG_Chart.Series[0].Points.RemoveAt(0);
                    }



                    ECG_Chart.Update();


                }));
            }

        }

        private int Convert_Endianness(int original_value)
        {
            int flipped_value;
            flipped_value = (int)((original_value & 0xFF000000) >> 24) |
                                 ((original_value & 0x00FF0000) >> 8) |
                                 ((original_value & 0x0000FF00) << 8) |
                                 ((original_value & 0x000000FF) << 24);

            return flipped_value;
        }

        private void DeviceWatcher_Stopped(DeviceWatcher sender, object args)
        {
           // throw new NotImplementedException();
        }

        private void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object args)
        {
           // throw new NotImplementedException();
        }

        private void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate args)
        {
           // throw new NotImplementedException();
        }

        private void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate args)
        {
           // throw new NotImplementedException();
        }

        private void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            //  throw new NotImplementedException();
           // Console.WriteLine(args.Name);
            try
            {
                // Thread safe calls to controls
                this?.Invoke(new Action(() => {
                    if ((sender == deviceWatcher)
                    && (!devices.ContainsKey(deviceInfo.Name))
                    && (deviceInfo.Name.StartsWith("ECG")))
                    {
                        // Add the device to our dictionary of devices.
                        devices.Add(deviceInfo.Name, deviceInfo);
                      //  Terminal.AppendText(deviceInfo.Name + " Board found\n");


                        ListViewItem listviewitem = new ListViewItem(deviceInfo.Name);
                        listviewitem.SubItems.Add(deviceInfo.Id);

                        BLE_List_View.Items.Add(listviewitem);
                    }
                }));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void StopBleDeviceWatcher()
        {
            if (deviceWatcher != null)
            {
                // Unregister the event handlers.
                deviceWatcher.Added -= DeviceWatcher_Added;
                deviceWatcher.Updated -= DeviceWatcher_Updated;
                deviceWatcher.Removed -= DeviceWatcher_Removed;
                deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
                deviceWatcher.Stopped -= DeviceWatcher_Stopped;

                // Stop the watcher.
                deviceWatcher.Stop();
                deviceWatcher = null;


            }
        }

    }
}
