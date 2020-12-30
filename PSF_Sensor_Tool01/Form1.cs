using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSF_Sensor_Tool01
{

    

    public partial class Form1 : Form
    {

        public int Panel_Active_Nbr = 0;

        private Point panel_location = new Point(10, 10);

        private int panel_width = 600;
        private int panel_height = 800;

        private int edge_width = 20;
        private int edge_height = 20;

        private int label_width = 100;
        private int label_height = 20;

        private int combobox_width = 150;
        private int combobox_height = 50;

        private int interval_width = 20;
        private int interval_height = 20;
        

        // for panel2 panel_CommSet;
        private System.Windows.Forms.Label label_CommBoardSelect = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox comboBox_CommBoardSelect = new System.Windows.Forms.ComboBox();

        private System.Windows.Forms.Label label_UartSelect = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox comboBox_UartSelect = new System.Windows.Forms.ComboBox();

        private System.Windows.Forms.Label label_BaudRateSelect = new System.Windows.Forms.Label();
        private System.Windows.Forms.ComboBox comboBox_BaudRateSelect = new System.Windows.Forms.ComboBox();

        private System.Windows.Forms.Label label_CommSwith = new System.Windows.Forms.Label();
        private System.Windows.Forms.Button button_CommSwitch = new System.Windows.Forms.Button();


        // for panel3 panel_SensorSet
        private System.Windows.Forms.Button button_ReadFirmware = new System.Windows.Forms.Button();
        private System.Windows.Forms.Label label_Firmware = new System.Windows.Forms.Label();

        private System.Windows.Forms.Button button_ReadOffset = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_WriteOffset = new System.Windows.Forms.Button();
        private System.Windows.Forms.TextBox textBox_Offset = new System.Windows.Forms.TextBox();

        private System.Windows.Forms.Button button_ReadGain = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_WriteGain = new System.Windows.Forms.Button();
        private System.Windows.Forms.TextBox textBox_Gain = new System.Windows.Forms.TextBox();


        private System.Windows.Forms.Button button_ReadTableX = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_ReadTableY = new System.Windows.Forms.Button();

        private System.Windows.Forms.Button button_WriteTableX = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_WriteTableY = new System.Windows.Forms.Button();

        private System.Windows.Forms.Button button_ReadTableXY = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_WriteTableXY = new System.Windows.Forms.Button();

        private System.Windows.Forms.DataGridView dataGridView_C2R15 = new System.Windows.Forms.DataGridView();

        private System.Windows.Forms.Button button_SaveParameter = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_ImportParameter = new System.Windows.Forms.Button();


        // for panel 4 GatherData;
        private System.Windows.Forms.TextBox textBox_DataText = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Button button_ReadCalidata = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_ReadRawdata = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_ReadAlldata = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_ClearData = new System.Windows.Forms.Button();
        private System.Windows.Forms.Button button_SaveData = new System.Windows.Forms.Button();

        private System.Windows.Forms.Label label_GatherInterval = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox textBox_GatherInterval = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.ComboBox comboBox_WhetherAutoSave = new System.Windows.Forms.ComboBox();
        private System.Windows.Forms.Label label_AutoSaveInterval = new System.Windows.Forms.Label();
        private System.Windows.Forms.TextBox textBox_AutoSaveInterval = new System.Windows.Forms.TextBox();

        

        //public int Comm_Board_Type = 0;
        //public int Comm_BaudRate_Type = 0;
        //public int 


        public Form1()
        {
            InitializeComponent();

            //this.Width = 800;
            //this.Height = 500;

            this.Text = "PSF_Sensor_Tool01";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            UI_Init();

        }

        private void UI_Init()
        {
            Panel_Active_Nbr = 1;

            panel_SoftNote.Visible = true;
            panel_CommSet.Visible = false;
            panel_SensorSet.Visible = false;
            panel_DataGather.Visible = false;
            panel_SaveAllData.Visible = false;


            //panel_SoftNote.Width = panel_width;
            //panel_SoftNote.Height = panel_height;
            panel_SoftNote.Size = new System.Drawing.Size(600, 600);
            // panel_SoftNote.Location = panel_location;

            //panel_CommSet.Width = panel_width;
            //panel_CommSet.Height = panel_height;
            panel_CommSet.Size = new System.Drawing.Size(600, 600);
            panel_CommSet.Location = panel_SoftNote.Location;

            //panel_SensorSet.Width = panel_width;
            //panel_SensorSet.Height = panel_height;
            panel_SensorSet.Size = new System.Drawing.Size(600, 600);
            panel_SensorSet.Location = panel_SoftNote.Location;

            //panel_DataGather.Width = panel_width;
            //panel_DataGather.Height = panel_height;
            panel_DataGather.Size = new System.Drawing.Size(600, 600);
            panel_DataGather.Location = panel_SoftNote.Location;

            //panel_SaveAllData.Width = panel_width;
            //panel_SaveAllData.Height = panel_height;
            panel_SaveAllData.Size = new System.Drawing.Size(600, 600);
            panel_SaveAllData.Location = panel_SoftNote.Location;

            Panel_Init(1);
            Panel_Init(2);
            Panel_Init(3);
            Panel_Init(4);
            Panel_Init(5);
        }
        private void Panel_Init(byte nbr)
        {
            
            switch(nbr)
            {
                case 1:
                    //label_SoftNote.Text = "\r\n;asdkfj;askdjf;askjdf;kasjdf\r\n;aksdf;jaskdf";

                    break;

                case 2:

                    label_CommBoardSelect.Text = "通信板选择:";
                    label_CommBoardSelect.Width = label_width;
                    label_CommBoardSelect.Height = label_height;
                    label_CommBoardSelect.Location = new Point(50, 50);
                    panel_CommSet.Controls.Add(label_CommBoardSelect);

                    comboBox_CommBoardSelect.Items.Add("PSF_STM32 Board");
                    comboBox_CommBoardSelect.Items.Add("Dialan Board");
                    comboBox_CommBoardSelect.Items.Add("UART Board");
                    comboBox_CommBoardSelect.Width = combobox_width;
                    comboBox_CommBoardSelect.Height = combobox_height;
                    comboBox_CommBoardSelect.Location = new Point(150, 50);
                    panel_CommSet.Controls.Add(comboBox_CommBoardSelect);

                    label_UartSelect.Text = "串口号选择:";
                    label_UartSelect.Width = label_width;
                    label_UartSelect.Height = label_height;
                    label_UartSelect.Location = new Point(50, 100);
                    panel_CommSet.Controls.Add(label_UartSelect);

                    comboBox_UartSelect.Items.Add("COM1");
                    comboBox_UartSelect.Items.Add("COM2");
                    comboBox_UartSelect.Items.Add("COM3");
                    comboBox_UartSelect.Items.Add("COM4");
                    comboBox_UartSelect.Items.Add("COM5");
                    comboBox_UartSelect.Items.Add("COM6");
                    comboBox_UartSelect.Items.Add("COM7");
                    comboBox_UartSelect.Items.Add("COM8");
                    comboBox_UartSelect.Width = combobox_width;
                    comboBox_UartSelect.Height = combobox_height;
                    comboBox_UartSelect.Location = new Point(150, 100);
                    panel_CommSet.Controls.Add(comboBox_UartSelect);


                    label_BaudRateSelect.Text = "波特率选择:";
                    label_BaudRateSelect.Width = label_width;
                    label_BaudRateSelect.Height = label_height;
                    label_BaudRateSelect.Location = new Point(50, 150);
                    panel_CommSet.Controls.Add(label_BaudRateSelect);

                    comboBox_BaudRateSelect.Items.Add("2400");
                    comboBox_BaudRateSelect.Items.Add("4800");
                    comboBox_BaudRateSelect.Items.Add("9600");
                    comboBox_BaudRateSelect.Items.Add("19200");
                    comboBox_BaudRateSelect.Items.Add("38400");
                    comboBox_BaudRateSelect.Items.Add("115200");
                    comboBox_BaudRateSelect.Width = combobox_width;
                    comboBox_BaudRateSelect.Height = combobox_height;
                    comboBox_BaudRateSelect.Location = new Point(150, 150);
                    panel_CommSet.Controls.Add(comboBox_BaudRateSelect);

                    label_CommSwith.Text = "开关通信口:";
                    label_CommSwith.Width = label_width;
                    label_CommSwith.Height = label_height;
                    label_CommSwith.Location = new Point(50, 200);
                    panel_CommSet.Controls.Add(label_CommSwith);


                    button_CommSwitch.Name = "button_CommSwitch";
                    button_CommSwitch.Text = "开/关  (当前：关)";
                    button_CommSwitch.BackColor = Color.Pink;
                    //button_CommSwitch.Width = combobox_width;
                    //button_CommSwitch.Height = combobox_height;
                    button_CommSwitch.Size = new System.Drawing.Size(combobox_width, combobox_height);
                    button_CommSwitch.Location = new Point(150, 200);
                    // button_CommSwitch.UseVisualStyleBackColor = true;
                    button_CommSwitch.Click += new System.EventHandler(this.button_CommSwitch_Click);

                    panel_CommSet.Controls.Add(button_CommSwitch);


                    


                    break;

                case 3:

                    label_Firmware.Text = "未读取";
                    label_Firmware.Width = label_width;
                    label_Firmware.Height = label_height;
                    label_Firmware.Location = new Point(50,50);
                    panel_SensorSet.Controls.Add(label_Firmware);

                    button_ReadFirmware.Text = "读取版本号";
                    button_ReadFirmware.Width = label_width;
                    button_ReadFirmware.Height = label_height;
                    button_ReadFirmware.Location = new Point(50, 80);
                    panel_SensorSet.Controls.Add(button_ReadFirmware);

                    textBox_Offset.Text = "";
                    textBox_Offset.Width = label_width;
                    textBox_Offset.Height = label_height;
                    textBox_Offset.Location = new Point(50, 150);
                    panel_SensorSet.Controls.Add(textBox_Offset);

                    button_ReadOffset.Text = "读取Offset";
                    button_ReadOffset.Width = label_width;
                    button_ReadOffset.Height = label_height;
                    button_ReadOffset.Location = new Point(50, 180);
                    panel_SensorSet.Controls.Add(button_ReadOffset);

                    button_WriteOffset.Text = "写入Offset";
                    button_WriteOffset.Width = label_width;
                    button_WriteOffset.Height = label_height;
                    button_WriteOffset.Location = new Point(50, 210);
                    panel_SensorSet.Controls.Add(button_WriteOffset);

                    textBox_Gain.Text = "";
                    textBox_Gain.Width = label_width;
                    textBox_Gain.Height = label_height;
                    textBox_Gain.Location = new Point(50, 280);
                    panel_SensorSet.Controls.Add(textBox_Gain);

                    button_ReadGain.Text = "读取Gain";
                    button_ReadGain.Width = label_width;
                    button_ReadGain.Height = label_height;
                    button_ReadGain.Location = new Point(50, 310);
                    panel_SensorSet.Controls.Add(button_ReadGain);

                    button_WriteGain.Text = "写入Gain";
                    button_WriteGain.Width = label_width;
                    button_WriteGain.Height = label_height;
                    button_WriteGain.Location = new Point(50, 340);
                    panel_SensorSet.Controls.Add(button_WriteGain);

                    button_ReadTableX.Text = "读取Table X";
                    button_ReadTableX.Width = label_width;
                    button_ReadTableX.Height = label_height;
                    button_ReadTableX.Location = new Point(170,50);
                    panel_SensorSet.Controls.Add(button_ReadTableX);

                    button_ReadTableY.Text = "读取Table Y";
                    button_ReadTableY.Width = label_width;
                    button_ReadTableY.Height = label_height;
                    button_ReadTableY.Location = new Point(170, 80);
                    panel_SensorSet.Controls.Add(button_ReadTableY);

                    button_WriteTableX.Text = "写入Table X";
                    button_WriteTableX.Width = label_width;
                    button_WriteTableX.Height = label_height;
                    button_WriteTableX.Location = new Point(170, 180);
                    panel_SensorSet.Controls.Add(button_WriteTableX);

                    button_WriteTableY.Text = "写入Table Y";
                    button_WriteTableY.Width = label_width;
                    button_WriteTableY.Height = label_height;
                    button_WriteTableY.Location = new Point(170, 210);
                    panel_SensorSet.Controls.Add(button_WriteTableY);

                    button_ReadTableXY.Text = "读取Table XY";
                    button_ReadTableXY.Width = label_width;
                    button_ReadTableXY.Height = label_height;
                    button_ReadTableXY.Location = new Point(170, 310);
                    panel_SensorSet.Controls.Add(button_ReadTableXY);

                    button_WriteTableXY.Text = "写入Table XY";
                    button_WriteTableXY.Width = label_width;
                    button_WriteTableXY.Height = label_height;
                    button_WriteTableXY.Location = new Point(170, 340);
                    panel_SensorSet.Controls.Add(button_WriteTableXY);

                    dataGridView_C2R15.ColumnCount = 2;
                    dataGridView_C2R15.RowCount = 15;

                    dataGridView_C2R15.Columns[0].HeaderText = "TableX;";
                    dataGridView_C2R15.Columns[1].HeaderText = "TableY:";

                    dataGridView_C2R15.RowHeadersWidth = 80;
                    
                    for(byte i =0;i<15;i++)
                    {
                        dataGridView_C2R15.Rows[i].HeaderCell.Value = "[" + i.ToString() + "]";

                    }

                    dataGridView_C2R15.Width = 290;
                    dataGridView_C2R15.Height = 380;

                    dataGridView_C2R15.Location = new Point(290,50);
                    panel_SensorSet.Controls.Add(dataGridView_C2R15);

                    button_SaveParameter.Text = "保存参数";
                    button_SaveParameter.Size = new Size(100,20);
                    button_SaveParameter.Location = new Point(50,420);
                    panel_SensorSet.Controls.Add(button_SaveParameter);

                    button_ImportParameter.Text = "导入参数";
                    button_ImportParameter.Size = new Size(100, 20);
                    button_ImportParameter.Location = new Point(50, 450);
                    panel_SensorSet.Controls.Add(button_ImportParameter);


                    break;

                case 4:
                    textBox_DataText.Multiline = true;
                    textBox_DataText.Size = new System.Drawing.Size(560, 500);
                    textBox_DataText.Location = new Point(10, 80);
                    panel_DataGather.Controls.Add(textBox_DataText);

                    button_ReadCalidata.Name = "ReadCalidata";
                    button_ReadCalidata.Text = "读取Calidata";

                    button_ReadCalidata.Size = new System.Drawing.Size(90, 30);
                    button_ReadCalidata.Location = new Point(5, 5);
                    panel_DataGather.Controls.Add(button_ReadCalidata);

                    button_ReadRawdata.Name = "button_ReadRawdata";
                    button_ReadRawdata.Text = "读取Rawdata";

                    button_ReadRawdata.Size = new System.Drawing.Size(90, 30);
                    button_ReadRawdata.Location = new Point(105, 5);
                    panel_DataGather.Controls.Add(button_ReadRawdata);

                    button_ReadAlldata.Name = "button_ReadAlldata";
                    button_ReadAlldata.Text = "读取Alldata";

                    button_ReadAlldata.Size = new System.Drawing.Size(90, 30);
                    button_ReadAlldata.Location = new Point(205, 5);
                    panel_DataGather.Controls.Add(button_ReadAlldata);

                    button_ClearData.Name = "ClearData";
                    button_ClearData.Text = "ClearData";
                    button_ClearData.Size = new System.Drawing.Size(90, 30);
                    button_ClearData.Location = new Point(305, 5);
                    panel_DataGather.Controls.Add(button_ClearData);

                    button_SaveData.Name = "button_SaveData";
                    button_SaveData.Text = "SaveData";

                    button_SaveData.Size = new System.Drawing.Size(90, 30);
                    button_SaveData.Location = new Point(405, 5);
                    panel_DataGather.Controls.Add(button_SaveData);

                    // comboBox_WhetherAutoSave.Text = "自动保存吗？";
                    comboBox_WhetherAutoSave.Items.Add("不自动保存");
                    comboBox_WhetherAutoSave.Items.Add("自动保存");
                    comboBox_WhetherAutoSave.SelectedIndex = 0;
                    comboBox_WhetherAutoSave.Size = new Size(90, 30);
                    comboBox_WhetherAutoSave.Location = new Point(5,45);
                    panel_DataGather.Controls.Add(comboBox_WhetherAutoSave);

                    label_AutoSaveInterval.Text = "保存间隔(s):";
                    label_AutoSaveInterval.Size = new Size(50,30);
                    label_AutoSaveInterval.Location = new Point(105, 45);
                    panel_DataGather.Controls.Add(label_AutoSaveInterval);

                    textBox_AutoSaveInterval.Text = "60";
                    textBox_AutoSaveInterval.Size = new Size(90, 30);
                    textBox_AutoSaveInterval.Location = new Point(160, 45);
                    panel_DataGather.Controls.Add(textBox_AutoSaveInterval);


                    label_GatherInterval.Text = "数据间隔(ms):";
                    label_GatherInterval.Size = new Size(50, 30);
                    label_GatherInterval.Location = new Point(345, 45);
                    panel_DataGather.Controls.Add(label_GatherInterval);

                    textBox_GatherInterval.Text = "100";
                    textBox_GatherInterval.Size = new Size(label_width-10, label_height);
                    textBox_GatherInterval.Location = new Point(405, 45);
                    panel_DataGather.Controls.Add(textBox_GatherInterval);


                    break;

                case 5:

                    break;

                default:

                    break;
            }
           
        }


        private void button_SoftNote_Click(object sender, EventArgs e)
        {
            Panel_Active_Nbr = 1;

            panel_SoftNote.Visible = true;
            panel_CommSet.Visible = false;
            panel_SensorSet.Visible = false;
            panel_DataGather.Visible = false;
            panel_SaveAllData.Visible = false;
        }

        private void button_CommSet_Click(object sender, EventArgs e)
        {
            Panel_Active_Nbr = 2;

            panel_SoftNote.Visible = false;
            panel_CommSet.Visible = true;
            panel_SensorSet.Visible = false;
            panel_DataGather.Visible = false;
            panel_SaveAllData.Visible = false;

        }

        private void button_SensorSet_Click(object sender, EventArgs e)
        {
            Panel_Active_Nbr = 3;

            panel_SoftNote.Visible = false;
            panel_CommSet.Visible = false;
            panel_SensorSet.Visible = true;
            panel_DataGather.Visible = false;
            panel_SaveAllData.Visible = false;
        }

        private void button_Gather_Click(object sender, EventArgs e)
        {
            Panel_Active_Nbr = 4;

            panel_SoftNote.Visible = false;
            panel_CommSet.Visible = false;
            panel_SensorSet.Visible = false;
            panel_DataGather.Visible = true;
            panel_SaveAllData.Visible = false;
        }

        private void button_HandCmd_Click(object sender, EventArgs e)
        {
            Panel_Active_Nbr = 5;

            panel_SoftNote.Visible = false;
            panel_CommSet.Visible = false;
            panel_SensorSet.Visible = false;
            panel_DataGather.Visible = false;
            panel_SaveAllData.Visible = true;
        }

        private bool Flag_CommSwitch = false;
        private void button_CommSwitch_Click(object sender,EventArgs e)
        {
            if(Flag_CommSwitch)
            {
                Flag_CommSwitch = false;
                button_CommSwitch.Text = "开/关  (当前：关)";
                button_CommSwitch.BackColor = Color.Pink;
            }
            else
            {
                Flag_CommSwitch = true;
                button_CommSwitch.Text = "开/关  (当前：开)";
                button_CommSwitch.BackColor = Color.LightGreen;
            }
            
        }
    }
}
