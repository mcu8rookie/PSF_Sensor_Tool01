using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;

using PSF_STM32_Comm;

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

        private Button button_CommRefresh = new Button();

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

        

        // 

        string Json_String;
        JsonData_Config1 JsonData_Import = new JsonData_Config1();
        JsonData_Config1 JsonData_Export = new JsonData_Config1();
        JsonData_Config1 JsonData_Obj = new JsonData_Config1();
        StreamReader Reader_Stream;

        UInt16 Firmware_Data = 0;
        UInt16 Firmware_Product = 0;
        UInt16 Firmware_PartNbr = 0;
        UInt16 Firmware_Revision = 0;
        UInt16 Cal_Offset = 0;
        UInt16 Cal_Gain = 0;
        UInt16[] Table_X = new UInt16[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        UInt16[] Table_Y = new UInt16[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        public int Comm_BoardType_Index = 0;
        public string Comm_BoardType_String = "";

        public int Comm_CommNbr_Index = 0;
        public string Comm_CommNbr_String = "";

        public int Comm_BaudRate_Index = 0;
        public string Comm_BaudRate_String = "";
        public int Comm_BaudRate_Nbr = 0;

        public int Comm_CommSwitch = 0;

        Comm_Stm32 Comm = new Comm_Stm32();

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

            Comm_BoardType_Index = 0;
            Comm_BoardType_String = "";

            Comm_CommNbr_Index = 0;
            Comm_CommNbr_String = "";

            Comm_BaudRate_Index = 0;
            Comm_BaudRate_String = "";
            Comm_BaudRate_Nbr = 0;

            Comm_CommSwitch = 0;

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

                    comboBox_CommBoardSelect.Text = "请选择通信板";
                    comboBox_CommBoardSelect.Items.Add("PSF_STM32 Board");
                    comboBox_CommBoardSelect.Items.Add("Dialan Board");
                    comboBox_CommBoardSelect.Items.Add("UART Board");
                    comboBox_CommBoardSelect.Items.Add("非指定的串口板");
                    comboBox_CommBoardSelect.Items.Add("非指定的USB板");

                    comboBox_CommBoardSelect.Width = combobox_width;
                    comboBox_CommBoardSelect.Height = combobox_height;
                    comboBox_CommBoardSelect.Location = new Point(150, 50);
                    comboBox_CommBoardSelect.SelectedIndexChanged += new EventHandler(comboBox_CommBoardSelectChanged);
                    panel_CommSet.Controls.Add(comboBox_CommBoardSelect);

                    label_UartSelect.Text = "通信口选择:";
                    label_UartSelect.Width = label_width;
                    label_UartSelect.Height = label_height;
                    label_UartSelect.Location = new Point(50, 100);
                    panel_CommSet.Controls.Add(label_UartSelect);

                    button_CommRefresh.Text = "刷新";
                    button_CommRefresh.Size = new Size(50,20);
                    button_CommRefresh.Location = new Point(300, 100);
                    button_CommRefresh.Click += new EventHandler(button_CommRefresh_Click);
                    panel_CommSet.Controls.Add(button_CommRefresh);

                    //comboBox_UartSelect.Items.Add("COM1");
                    //comboBox_UartSelect.Items.Add("COM2");
                    //comboBox_UartSelect.Items.Add("COM3");
                    //comboBox_UartSelect.Items.Add("COM4");
                    //comboBox_UartSelect.Items.Add("COM5");
                    //comboBox_UartSelect.Items.Add("COM6");
                    //comboBox_UartSelect.Items.Add("COM7");
                    //comboBox_UartSelect.Items.Add("COM8");
                    // comboBox_UartSelect.Text = "";
                    comboBox_UartSelect.Width = combobox_width;
                    comboBox_UartSelect.Height = combobox_height;
                    comboBox_UartSelect.Location = new Point(150, 100);
                    panel_CommSet.Controls.Add(comboBox_UartSelect);


                    label_BaudRateSelect.Text = "波特率选择:";
                    label_BaudRateSelect.Width = label_width;
                    label_BaudRateSelect.Height = label_height;
                    label_BaudRateSelect.Location = new Point(50, 150);
                    panel_CommSet.Controls.Add(label_BaudRateSelect);

                    comboBox_BaudRateSelect.Items.Clear();

                    comboBox_BaudRateSelect.Items.Add("1200");
                    comboBox_BaudRateSelect.Items.Add("2400");
                    comboBox_BaudRateSelect.Items.Add("4800");
                    comboBox_BaudRateSelect.Items.Add("9600");
                    comboBox_BaudRateSelect.Items.Add("10800");
                    comboBox_BaudRateSelect.Items.Add("19200");
                    comboBox_BaudRateSelect.Items.Add("28800");
                    comboBox_BaudRateSelect.Items.Add("38400");
                    comboBox_BaudRateSelect.Items.Add("57200");
                    comboBox_BaudRateSelect.Items.Add("115200");
                    comboBox_BaudRateSelect.Items.Add("230400");
                    comboBox_BaudRateSelect.Items.Add("460800");
                    comboBox_BaudRateSelect.Items.Add("921600");

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

                    button_ReadFirmware.Name = "button_ReadFirmware";
                    button_ReadFirmware.Text = "读取版本号";
                    button_ReadFirmware.Width = label_width;
                    button_ReadFirmware.Height = label_height;
                    button_ReadFirmware.Location = new Point(50, 80);
                    button_ReadFirmware.Click += new System.EventHandler(this.button_ReadFirmware_Click);
                    panel_SensorSet.Controls.Add(button_ReadFirmware);

                    textBox_Offset.Text = "";
                    textBox_Offset.Width = label_width;
                    textBox_Offset.Height = label_height;
                    textBox_Offset.Location = new Point(50, 150);
                    panel_SensorSet.Controls.Add(textBox_Offset);

                    button_ReadOffset.Name = "button_ReadOffset";
                    button_ReadOffset.Text = "读取Offset";
                    button_ReadOffset.Width = label_width;
                    button_ReadOffset.Height = label_height;
                    button_ReadOffset.Location = new Point(50, 180);
                    button_ReadOffset.Click += new System.EventHandler(button_ReadOffset_Click);
                    panel_SensorSet.Controls.Add(button_ReadOffset);

                    button_WriteOffset.Name = "button_WriteOffset";
                    button_WriteOffset.Text = "写入Offset";
                    button_WriteOffset.Width = label_width;
                    button_WriteOffset.Height = label_height;
                    button_WriteOffset.Location = new Point(50, 210);
                    button_WriteOffset.Click += new System.EventHandler(button_WriteOffset_Click);
                    panel_SensorSet.Controls.Add(button_WriteOffset);

                    textBox_Gain.Text = "";
                    textBox_Gain.Width = label_width;
                    textBox_Gain.Height = label_height;
                    textBox_Gain.Location = new Point(50, 280);
                    panel_SensorSet.Controls.Add(textBox_Gain);

                    button_ReadGain.Name = "button_ReadGain";
                    button_ReadGain.Text = "读取Gain";
                    button_ReadGain.Width = label_width;
                    button_ReadGain.Height = label_height;
                    button_ReadGain.Location = new Point(50, 310);
                    button_ReadGain.Click += new System.EventHandler(button_ReadGain_Click);
                    panel_SensorSet.Controls.Add(button_ReadGain);

                    button_WriteGain.Name = "button_WriteGain";
                    button_WriteGain.Text = "写入Gain";
                    button_WriteGain.Width = label_width;
                    button_WriteGain.Height = label_height;
                    button_WriteGain.Location = new Point(50, 340);
                    button_WriteGain.Click += new System.EventHandler(button_WriteGain_Click);
                    panel_SensorSet.Controls.Add(button_WriteGain);

                    button_ReadTableX.Name = "button_ReadTableX";
                    button_ReadTableX.Text = "读取Table X";
                    button_ReadTableX.Width = label_width;
                    button_ReadTableX.Height = label_height;
                    button_ReadTableX.Location = new Point(170,50);
                    button_ReadTableX.Click += new System.EventHandler(button_ReadTableX_Click);
                    panel_SensorSet.Controls.Add(button_ReadTableX);

                    button_ReadTableY.Name = "button_ReadTableY";
                    button_ReadTableY.Text = "读取Table Y";
                    button_ReadTableY.Width = label_width;
                    button_ReadTableY.Height = label_height;
                    button_ReadTableY.Location = new Point(170, 80);
                    button_ReadTableY.Click += new System.EventHandler(button_ReadTableY_Click);
                    panel_SensorSet.Controls.Add(button_ReadTableY);

                    button_WriteTableX.Name = "button_WriteTableX";
                    button_WriteTableX.Text = "写入Table X";
                    button_WriteTableX.Width = label_width;
                    button_WriteTableX.Height = label_height;
                    button_WriteTableX.Location = new Point(170, 180);
                    button_WriteTableX.Click += new System.EventHandler(button_WriteTableX_Click);
                    panel_SensorSet.Controls.Add(button_WriteTableX);

                    button_WriteTableY.Name = "button_WriteTableY";
                    button_WriteTableY.Text = "写入Table Y";
                    button_WriteTableY.Width = label_width;
                    button_WriteTableY.Height = label_height;
                    button_WriteTableY.Location = new Point(170, 210);
                    button_WriteTableY.Click += new System.EventHandler(button_WriteTableY_Click);
                    panel_SensorSet.Controls.Add(button_WriteTableY);

                    button_ReadTableXY.Name = "button_ReadTableXY";
                    button_ReadTableXY.Text = "读取Table XY";
                    button_ReadTableXY.Width = label_width;
                    button_ReadTableXY.Height = label_height;
                    button_ReadTableXY.Location = new Point(170, 310);
                    button_ReadTableXY.Click += new System.EventHandler(button_ReadTableXY_Click);
                    panel_SensorSet.Controls.Add(button_ReadTableXY);

                    button_WriteTableXY.Name = "button_WriteTableXY";
                    button_WriteTableXY.Text = "写入Table XY";
                    button_WriteTableXY.Width = label_width;
                    button_WriteTableXY.Height = label_height;
                    button_WriteTableXY.Location = new Point(170, 340);
                    button_WriteTableXY.Click += new System.EventHandler(button_WriteTableXY_Click);
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

                    button_SaveParameter.Name = "button_SaveParameter"; 
                    button_SaveParameter.Text = "保存参数";
                    button_SaveParameter.Size = new Size(100,20);
                    button_SaveParameter.Location = new Point(50,420);
                    button_SaveParameter.Click += new System.EventHandler(button_SaveParameter_Click);
                    panel_SensorSet.Controls.Add(button_SaveParameter);

                    button_ImportParameter.Name = "button_ImportParameter";
                    button_ImportParameter.Text = "导入参数";
                    button_ImportParameter.Size = new Size(100, 20);
                    button_ImportParameter.Location = new Point(50, 450);
                    button_ImportParameter.Click += new System.EventHandler(button_ImportParameter_Click);
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
                    button_ReadCalidata.Click += new System.EventHandler(button_ReadCalidata_Click);
                    panel_DataGather.Controls.Add(button_ReadCalidata);

                    button_ReadRawdata.Name = "button_ReadRawdata";
                    button_ReadRawdata.Text = "读取Rawdata";
                    button_ReadRawdata.Size = new System.Drawing.Size(90, 30);
                    button_ReadRawdata.Location = new Point(105, 5);
                    button_ReadRawdata.Click += new System.EventHandler(button_ReadRawdata_Click);
                    panel_DataGather.Controls.Add(button_ReadRawdata);

                    button_ReadAlldata.Name = "button_ReadAlldata";
                    button_ReadAlldata.Text = "读取Alldata";
                    button_ReadAlldata.Size = new System.Drawing.Size(90, 30);
                    button_ReadAlldata.Location = new Point(205, 5);
                    button_ReadAlldata.Click += new System.EventHandler(button_ReadAlldata_Click);
                    panel_DataGather.Controls.Add(button_ReadAlldata);

                    button_ClearData.Name = "ClearData";
                    button_ClearData.Text = "ClearData";
                    button_ClearData.Size = new System.Drawing.Size(90, 30);
                    button_ClearData.Location = new Point(305, 5);
                    button_ClearData.Click += new System.EventHandler(button_ClearData_Click);
                    panel_DataGather.Controls.Add(button_ClearData);

                    button_SaveData.Name = "button_SaveData";
                    button_SaveData.Text = "SaveData";
                    button_SaveData.Size = new System.Drawing.Size(90, 30);
                    button_SaveData.Location = new Point(405, 5);
                    button_SaveData.Click += new System.EventHandler(button_SaveData_Click);
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

        private void comboBox_CommBoardSelectChanged(object sender, EventArgs e)
        {
            if(comboBox_CommBoardSelect.SelectedIndex == 2 || comboBox_CommBoardSelect.SelectedIndex == 3)
            {
                Comm_UartComm_Refresh();
            }
        }


        private bool Check_Argument(int nbr)
        {
            bool ReturnCode = true;

            switch(nbr)
            {
                case 1:

                    break;
                case 2:
                    try
                    {
                        Comm_BoardType_Index = comboBox_CommBoardSelect.SelectedIndex;

                        Console.WriteLine("comboBox_CommBoardSelect.SelectedIndex = " + comboBox_CommBoardSelect.SelectedIndex.ToString()) ;
                        Console.WriteLine("Comm_BoardType_Index = "+ Comm_BoardType_Index.ToString());

                    }
                    catch
                    {
                        Comm_BoardType_Index = -1;
                        MessageBox.Show("选择通信板型号错误","Exception Report:");
                        ReturnCode = false;
                    }
                    finally
                    {
                        if(Comm_BoardType_Index == -1)
                        {
                            MessageBox.Show("请正确选择通信板型号，\r\n如果不是指定的通信板型号，请选择非指定的特定通信方式的板型。\r\n","Exception Report:");
                            ReturnCode = false;
                        }
                        else
                        {
                            ReturnCode = true;
                        }
                    }

                    if (ReturnCode == false)
                    {
                        return false;
                    }

                    if(Comm_BoardType_Index == 2 || Comm_BoardType_Index == 3)
                    {
                        try
                        {
                            Comm_CommNbr_Index = comboBox_UartSelect.SelectedIndex;
                            Console.WriteLine("comboBox_UartSelect.SelectedIndex = " + comboBox_UartSelect.SelectedIndex.ToString());
                            Console.WriteLine("Comm_ComnNbr = " + Comm_CommNbr_Index.ToString());
                        }
                        catch
                        {
                            Comm_CommNbr_Index = -1;
                            MessageBox.Show("选择通信口错误", "Exception Report:");
                            ReturnCode = false;
                        }
                        finally
                        {
                            if (Comm_CommNbr_Index == -1)
                            {
                                MessageBox.Show("请正确选择通信口，\r\n", "Exception Report:");
                                ReturnCode = false;
                            }
                            else
                            {
                                ReturnCode = true;
                            }
                        }

                        if(ReturnCode == false)
                        {
                            return false;
                        }

                        if(Comm_BoardType_Index == 2 || Comm_BoardType_Index == 3)
                        {
                            try
                            {
                                // Comm_BaudRate_Type = comboBox_BaudRateSelect.SelectedIndex;
                                Comm_BaudRate_Nbr = Convert.ToInt32(comboBox_BaudRateSelect.Text);
                                //Console.WriteLine("comboBox_BaudRateSelect.SelectedIndex = "+ comboBox_BaudRateSelect.SelectedIndex.ToString());
                                //Console.WriteLine("Comm_BaudRate_Type = "+Comm_BaudRate_Type.ToString());
                                Console.WriteLine("Convert.ToInt32(comboBox_BaudRateSelect.Text) = " + Convert.ToInt32(comboBox_BaudRateSelect.Text));
                                Console.WriteLine("Comm_BaudRate_Nbr = " + Comm_BaudRate_Nbr);
                            }
                            catch
                            {
                                Comm_BaudRate_Index = -1;
                                
                                MessageBox.Show("请选择正确的波特率","Exception Report:") ;
                                ReturnCode = false;
                            }
                            finally
                            {
                                if(Comm_BaudRate_Index == -1)
                                {
                                    MessageBox.Show("请正确选择波特率，\r\n", "Exception Report:");
                                    ReturnCode = false;
                                }
                                else
                                {
                                    ReturnCode = true;
                                }
                            }
                        }
                        if(ReturnCode == false)
                        {
                            return false;
                        }

                        return true;
                    }
                    else
                    {
                        return true;
                    }

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:

                    break;

            }

            return true;
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

        private void button_GatherData_Click(object sender, EventArgs e)
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

        // button click function at panel 2
        // private bool Flag_CommSwitch = false;
        private bool Check_CommArgments()
        {
            Int16 ProcessResult = 0;
            try
            {
                Comm_BoardType_Index = comboBox_CommBoardSelect.SelectedIndex;
                Comm_BoardType_String = comboBox_CommBoardSelect.Text;
                if(Comm_BoardType_Index == 0 || Comm_BoardType_Index == 1 || Comm_BoardType_Index == 4)
                {

                }
                else
                {
                    try
                    {
                        Comm_CommNbr_Index = comboBox_UartSelect.SelectedIndex;
                        Comm_CommNbr_String = comboBox_UartSelect.Text;

                        Comm_BaudRate_Index = comboBox_BaudRateSelect.SelectedIndex;
                        Comm_BaudRate_String = comboBox_BaudRateSelect.Text;
                        Comm_BaudRate_Nbr = Convert.ToUInt16(Comm_BaudRate_String);
                    }
                    catch(Exception e)
                    {
                        ProcessResult = -1;
                        // MessageBox.Show(e.Message,"通信口或波特率错误");
                        MessageBox.Show("通信口或波特率错误","异常报告");
                    }
                    finally
                    {
                        Comm_UartComm_Refresh();
                    }
                    
                    if(ProcessResult == -1)
                    {
                        return false;
                    }
                }

            }
            catch(Exception e)
            {
                ProcessResult = -1;
                // MessageBox.Show(e.Message,"通信板选择错误");
                MessageBox.Show("通信板选择错误","异常报告");
            }
            finally
            {

            }
            
            if(ProcessResult == -1)
            {
                return false;

            }

            return true;
        }

        private void CommArgs_Enable(bool nbr)
        {
            comboBox_CommBoardSelect.Enabled = nbr;
            comboBox_UartSelect.Enabled = nbr;
            comboBox_BaudRateSelect.Enabled = nbr;
        }
        private void button_CommSwitch_Click(object sender,EventArgs e)
        {
            // Check Config Parameter;

            if(Check_CommArgments() != true)
            {
                return;
            }


            if(Comm_CommSwitch == 1)
            {
                if (Comm.Close() == true)
                {
                    Comm_CommSwitch = 0;
                    button_CommSwitch.Text = "开/关  (当前：关)";
                    button_CommSwitch.BackColor = Color.Pink;

                    CommArgs_Enable(true);
                    
                }
                else
                {
                    MessageBox.Show("关闭通信口异常；", "Exception Report: Comm.Close();");
                }
            }
            else
            {

                if(Comm.Open() == true)
                {
                    Comm_CommSwitch = 1;
                    button_CommSwitch.Text = "开/关  (当前：开)";
                    button_CommSwitch.BackColor = Color.LightGreen;

                    CommArgs_Enable(false);
                }
                else
                {
                    MessageBox.Show("打开通信口异常；", "Exception Report: Comm.Open();");
                }

                Check_Argument(2);
            }
        }
        private void button_CommRefresh_Click(object sender,EventArgs e)
        {
            //string[] portlist = SerialPort.GetPortNames();
            //comboBox_UartSelect.Items.Clear();

            //for(int i=0;i<portlist.Length;i++)
            //{
            //    comboBox_UartSelect.Items.Add(portlist[i]);
            //}
            //label_UartSelect.Text = "通信口选择:" + portlist.Length.ToString() ;

            Comm_UartComm_Refresh();
        }

        private void Comm_UartComm_Refresh()
        {
            string[] portlist = SerialPort.GetPortNames();
            comboBox_UartSelect.Items.Clear();

            for (int i = 0; i < portlist.Length; i++)
            {
                comboBox_UartSelect.Items.Add(portlist[i]);
            }
            label_UartSelect.Text = "通信口选择:" + portlist.Length.ToString();
        }

        // button click function which at panel 3
        private void button_ReadFirmware_Click(object sender, EventArgs e)
        {

        }

        private void button_ReadOffset_Click(object sender, EventArgs e)
        {

        }

        private void button_WriteOffset_Click(object sender, EventArgs e)
        {

        }
        private void button_ReadGain_Click(object sender,EventArgs e)
        {

        }

        private void button_WriteGain_Click(object sender,EventArgs e)
        {

        }
        private void button_ReadTableX_Click(object sender,EventArgs e)
        {

        }
        private void button_ReadTableY_Click(object sender, EventArgs e)
        {

        }
        private void button_WriteTableX_Click(object sender,EventArgs e)
        {

        }
        private void button_WriteTableY_Click(object sender,EventArgs e)
        {

        }
        private void button_ReadTableXY_Click(object sender,EventArgs e)
        {

        }
        private void button_WriteTableXY_Click(object sender,EventArgs e)
        {

        }
        private void button_SaveParameter_Click(object sender,EventArgs e)
        {
            string jsonstring = "";
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "所有文件(*.*)|*.*|Json文件(*.json)|*.json|文本文件(*.txt)|*.txt|log文件(*.log)|*.log";
            savefiledialog.FileName = "SaveFileName";
            savefiledialog.AddExtension = true;
            if(savefiledialog.ShowDialog() == DialogResult.OK)
            {
                TextBox_To_JsonObj(JsonData_Obj);
                jsonstring = JsonConvert.SerializeObject(JsonData_Obj);
                // MessageBox.Show(savefiledialog.FileName);
                using (StreamWriter smWriter = new StreamWriter(savefiledialog.FileName))
                {
                    smWriter.Write(jsonstring);
                    smWriter.Close();
                }
            
            }
        }

        private void TextBox_To_JsonObj(JsonData_Config1 obj)
        {
            obj.Firmware_Data = Firmware_Data;
            obj.Firmware_Product = Firmware_Product;
            obj.Firmware_PartNbr = Firmware_PartNbr;
            obj.Firmware_Revision = Firmware_Revision;
            obj.Cal_Offset = Cal_Offset;
            obj.Cal_Gain = Cal_Gain;

            for(byte i=0;i<15;i++)
            {
                obj.Table_X[i] = Table_X[i];
                obj.Table_Y[i] = Table_Y[i];
            }
        }
        private void JsonObj_To_TextBox(JsonData_Config1 obj)
        {

            label_Firmware.Text = obj.Firmware_Data.ToString() + "=>" + obj.Firmware_Product.ToString() + "_" + obj.Firmware_PartNbr.ToString() + "_" + obj.Firmware_Revision.ToString();
            textBox_Offset.Text = obj.Cal_Offset.ToString();
            textBox_Gain.Text = obj.Cal_Gain.ToString();

            for (byte i = 0; i < 15; i++)
            {
                dataGridView_C2R15.Rows[i].Cells[0].Value = obj.Table_X[i];
                dataGridView_C2R15.Rows[i].Cells[1].Value = obj.Table_Y[i];
            }

            Firmware_Data = obj.Firmware_Data;
            Firmware_Product = obj.Firmware_Product;
            Firmware_PartNbr = obj.Firmware_PartNbr;
            Firmware_Revision = obj.Firmware_Revision;
            Cal_Offset = obj.Cal_Offset;
            Cal_Gain = obj.Cal_Gain;
            
            for(byte i=0;i<15;i++)
            {
                Table_X[i] = obj.Table_X[i];
                Table_Y[i] = obj.Table_Y[i];
            }

        }
        private void button_ImportParameter_Click(object sender,EventArgs e)
        {
            int ProcessResult = 0;
            OpenFileDialog openfiledialog = new OpenFileDialog();
            // openfiledialog.InitialDirectory = @"D:\";
            openfiledialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            openfiledialog.Title = "Exercise OpenFileDialog function.";
            openfiledialog.Filter = "All Files(*.*)|*.*|json Files(*.json)|*.json|txt Files(*.txt)|*.txt|log Files(*.log)|*.log";
            openfiledialog.FilterIndex = 2;
            openfiledialog.RestoreDirectory = true;
            if(openfiledialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openfiledialog.FileName + "\r\n" );

                try
                {
                    Reader_Stream = new StreamReader(openfiledialog.FileName);
                    Json_String = Reader_Stream.ReadToEnd();
                    Reader_Stream.Close();
                }
                catch
                {
                    MessageBox.Show("读取Json文件错误","异常报告");
                    ProcessResult = -1;
                }
                finally
                {
                    if(ProcessResult != -1)
                    {
                        JsonData_Obj = JsonConvert.DeserializeObject<JsonData_Config1>(Json_String);
                        JsonObj_To_TextBox(JsonData_Obj);
                    }
                    
                }
                

            }
            else
            {

            }
        }

        // button click function which at panel 4
        private void button_ReadCalidata_Click(object sender, EventArgs e)
        {

        }
        private void button_ReadRawdata_Click(object sender,EventArgs e)
        {

        }
        private void button_ReadAlldata_Click(object sender,EventArgs e)
        {

        }
        private void button_ClearData_Click(object sender, EventArgs e)
        {

        }
        private void button_SaveData_Click(object sender,EventArgs e)
        {

        }

        // button click function at panel 5
        //private void button

    }

    class JsonData_Config1
    {
        public UInt16 Firmware_Data;
        public UInt16 Firmware_Product;
        public UInt16 Firmware_PartNbr;
        public UInt16 Firmware_Revision;

        public UInt16 Cal_Offset;
        public UInt16 Cal_Gain;
        public UInt16[] Table_X = new UInt16[15];
        public UInt16[] Table_Y = new UInt16[15];

        public JsonData_Config1()
        {
            Firmware_Data = 0;
            Firmware_Product = 0;
            Firmware_PartNbr = 0;
            Firmware_Revision = 0;

            Cal_Offset = 0;
            Cal_Gain = 0;

            for (byte i = 0; i < 15; i++)
            {
                Table_X[i] = 0;
                Table_Y[i] = 0;
            }
        }
    }
}



