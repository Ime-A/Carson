using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carson
{
    public partial class Form1 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Scan_Button_Click(object sender, EventArgs e)
        {
            StartBLEDeviceWathcer();
        }

        private async void Connect_Button_Click(object sender, EventArgs e)
        {
            if (BLE_List_View.SelectedItems.Count == 0)
            {
               // Terminal.AppendText("Select a board from the list.\n");
            }
            else
            {
                try
                {
                    BLE_List_View.Enabled = false;
                    Connect_Button.Enabled = false;
                    int BLE_Success = await ConnectBLE();
                    if (BLE_Success == 1)
                    {
                        BLE_List_View.Items.Remove(BLE_List_View.SelectedItems[0]);
                        Connect_LED.Color = Color.Blue;
                        //Connect_LED.Color.Blue();
                    }
                    else
                    {
                      //  Terminal.AppendText($"{BLE_List_View.SelectedItems[0].Text} Board was not able to connect \n");
                    }
                    // Configure_Max_Power_Threshold(Power_Max_ComboBox.Text);
                    // Configure_Min_Stent_Threshold(Stent_Min_ComboBox.Text);

                    Connect_Button.Enabled = true;
                    BLE_List_View.Enabled = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void Disconnect_Button_Click(object sender, EventArgs e)
        {
            Disconnect_Button.Enabled = false;
            Disconnect_ECG();
            Disconnect_Button.Enabled = true;
        }
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BLE_List_View_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
