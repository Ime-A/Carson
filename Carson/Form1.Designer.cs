
namespace Carson
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ECG_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Scan_Button = new System.Windows.Forms.Button();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.Disconnect_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ECG_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BLE_List_View = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Connect_LED = new Carson.LedBulb();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ECG_Chart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ECG_Chart
            // 
            this.ECG_Chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisY.Maximum = 500D;
            chartArea2.AxisY.Minimum = 200D;
            chartArea2.Name = "ChartArea1";
            this.ECG_Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ECG_Chart.Legends.Add(legend2);
            this.ECG_Chart.Location = new System.Drawing.Point(28, 74);
            this.ECG_Chart.Name = "ECG_Chart";
            series2.BorderWidth = 5;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ECG_Chart.Series.Add(series2);
            this.ECG_Chart.Size = new System.Drawing.Size(442, 334);
            this.ECG_Chart.TabIndex = 0;
            this.ECG_Chart.Text = "chart1";
            this.ECG_Chart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // Scan_Button
            // 
            this.Scan_Button.Location = new System.Drawing.Point(0, 0);
            this.Scan_Button.Name = "Scan_Button";
            this.Scan_Button.Size = new System.Drawing.Size(114, 50);
            this.Scan_Button.TabIndex = 1;
            this.Scan_Button.Text = "SCAN";
            this.Scan_Button.UseVisualStyleBackColor = true;
            this.Scan_Button.Click += new System.EventHandler(this.Scan_Button_Click);
            // 
            // Connect_Button
            // 
            this.Connect_Button.Location = new System.Drawing.Point(185, 0);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(114, 50);
            this.Connect_Button.TabIndex = 2;
            this.Connect_Button.Text = "CONNECT";
            this.Connect_Button.UseVisualStyleBackColor = true;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // Disconnect_Button
            // 
            this.Disconnect_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Disconnect_Button.Location = new System.Drawing.Point(3, 418);
            this.Disconnect_Button.Name = "Disconnect_Button";
            this.Disconnect_Button.Size = new System.Drawing.Size(296, 73);
            this.Disconnect_Button.TabIndex = 3;
            this.Disconnect_Button.Text = "DISCONNECT";
            this.Disconnect_Button.UseVisualStyleBackColor = true;
            this.Disconnect_Button.Click += new System.EventHandler(this.Disconnect_Button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.BLE_List_View);
            this.panel1.Controls.Add(this.Scan_Button);
            this.panel1.Controls.Add(this.Disconnect_Button);
            this.panel1.Controls.Add(this.Connect_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 491);
            this.panel1.TabIndex = 4;
            // 
            // ECG_Label
            // 
            this.ECG_Label.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ECG_Label.AutoSize = true;
            this.ECG_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ECG_Label.Location = new System.Drawing.Point(142, 19);
            this.ECG_Label.Name = "ECG_Label";
            this.ECG_Label.Size = new System.Drawing.Size(233, 32);
            this.ECG_Label.TabIndex = 5;
            this.ECG_Label.Text = "IoT ECG Logger";
            this.ECG_Label.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.ECG_Label);
            this.panel2.Controls.Add(this.ECG_Chart);
            this.panel2.Location = new System.Drawing.Point(380, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(504, 429);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // BLE_List_View
            // 
            this.BLE_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.BLE_List_View.FullRowSelect = true;
            this.BLE_List_View.GridLines = true;
            this.BLE_List_View.HideSelection = false;
            this.BLE_List_View.Location = new System.Drawing.Point(0, 105);
            this.BLE_List_View.Name = "BLE_List_View";
            this.BLE_List_View.Size = new System.Drawing.Size(299, 97);
            this.BLE_List_View.TabIndex = 5;
            this.BLE_List_View.UseCompatibleStateImageBehavior = false;
            this.BLE_List_View.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BLE Device";
            this.columnHeader1.Width = 294;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Connect_LED
            // 
            this.Connect_LED.Color = System.Drawing.Color.White;
            this.Connect_LED.Location = new System.Drawing.Point(238, 3);
            this.Connect_LED.Name = "Connect_LED";
            this.Connect_LED.On = true;
            this.Connect_LED.Size = new System.Drawing.Size(45, 47);
            this.Connect_LED.TabIndex = 6;
            this.Connect_LED.Text = "ledBulb1";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Connection Status";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.Connect_LED);
            this.panel3.Location = new System.Drawing.Point(0, 244);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(299, 54);
            this.panel3.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 491);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ECG_Chart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ECG_Chart;
        private System.Windows.Forms.Button Scan_Button;
        private System.Windows.Forms.Button Connect_Button;
        private System.Windows.Forms.Button Disconnect_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ECG_Label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView BLE_List_View;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private LedBulb Connect_LED;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}

