namespace PSF_Sensor_Tool01
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_SoftNote = new System.Windows.Forms.Button();
            this.button_CommSet = new System.Windows.Forms.Button();
            this.button_SensorSet = new System.Windows.Forms.Button();
            this.button_DataGather = new System.Windows.Forms.Button();
            this.button_HandCmd = new System.Windows.Forms.Button();
            this.panel_SoftNote = new System.Windows.Forms.Panel();
            this.label_SoftNote = new System.Windows.Forms.Label();
            this.panel_CommSet = new System.Windows.Forms.Panel();
            this.panel_SensorSet = new System.Windows.Forms.Panel();
            this.panel_DataGather = new System.Windows.Forms.Panel();
            this.panel_SaveAllData = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.panel_SoftNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_SoftNote
            // 
            this.button_SoftNote.Location = new System.Drawing.Point(833, 10);
            this.button_SoftNote.Name = "button_SoftNote";
            this.button_SoftNote.Size = new System.Drawing.Size(150, 50);
            this.button_SoftNote.TabIndex = 0;
            this.button_SoftNote.Text = "软件说明";
            this.button_SoftNote.UseVisualStyleBackColor = true;
            this.button_SoftNote.Click += new System.EventHandler(this.button_SoftNote_Click);
            // 
            // button_CommSet
            // 
            this.button_CommSet.Location = new System.Drawing.Point(833, 65);
            this.button_CommSet.Name = "button_CommSet";
            this.button_CommSet.Size = new System.Drawing.Size(150, 50);
            this.button_CommSet.TabIndex = 1;
            this.button_CommSet.Text = "通信设置";
            this.button_CommSet.UseVisualStyleBackColor = true;
            this.button_CommSet.Click += new System.EventHandler(this.button_CommSet_Click);
            // 
            // button_SensorSet
            // 
            this.button_SensorSet.Location = new System.Drawing.Point(833, 119);
            this.button_SensorSet.Name = "button_SensorSet";
            this.button_SensorSet.Size = new System.Drawing.Size(150, 50);
            this.button_SensorSet.TabIndex = 2;
            this.button_SensorSet.Text = "模组设置";
            this.button_SensorSet.UseVisualStyleBackColor = true;
            this.button_SensorSet.Click += new System.EventHandler(this.button_SensorSet_Click);
            // 
            // button_DataGather
            // 
            this.button_DataGather.Location = new System.Drawing.Point(833, 176);
            this.button_DataGather.Name = "button_DataGather";
            this.button_DataGather.Size = new System.Drawing.Size(150, 50);
            this.button_DataGather.TabIndex = 3;
            this.button_DataGather.Text = "数据抓取";
            this.button_DataGather.UseVisualStyleBackColor = true;
            this.button_DataGather.Click += new System.EventHandler(this.button_GatherData_Click);
            // 
            // button_HandCmd
            // 
            this.button_HandCmd.Location = new System.Drawing.Point(833, 233);
            this.button_HandCmd.Name = "button_HandCmd";
            this.button_HandCmd.Size = new System.Drawing.Size(150, 50);
            this.button_HandCmd.TabIndex = 4;
            this.button_HandCmd.Text = "手动指令";
            this.button_HandCmd.UseVisualStyleBackColor = true;
            this.button_HandCmd.Click += new System.EventHandler(this.button_HandCmd_Click);
            // 
            // panel_SoftNote
            // 
            this.panel_SoftNote.Controls.Add(this.label_SoftNote);
            this.panel_SoftNote.Location = new System.Drawing.Point(10, 10);
            this.panel_SoftNote.Name = "panel_SoftNote";
            this.panel_SoftNote.Size = new System.Drawing.Size(800, 400);
            this.panel_SoftNote.TabIndex = 5;
            // 
            // label_SoftNote
            // 
            this.label_SoftNote.AutoSize = true;
            this.label_SoftNote.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SoftNote.Location = new System.Drawing.Point(57, 57);
            this.label_SoftNote.Name = "label_SoftNote";
            this.label_SoftNote.Size = new System.Drawing.Size(429, 260);
            this.label_SoftNote.TabIndex = 0;
            this.label_SoftNote.Text = "0:本软件是和博思发的传感器交互的软件工具；\r\n\r\n请用右边的按键选择使用的功能；\r\n\r\n1：软件说明：软件简介及使用说明；\r\n\r\n2：通信设置：主要用于设置通信" +
    "的相关参数；\r\n\r\n3：模组设置：主要用于写传感器的各种参数；\r\n\r\n4：数据抓取：主要用于抓取传感器各种数据；\r\n\r\n5：手动指令：主要用于手工进行通信；\r\n" +
    "";
            // 
            // panel_CommSet
            // 
            this.panel_CommSet.Location = new System.Drawing.Point(10, 10);
            this.panel_CommSet.Name = "panel_CommSet";
            this.panel_CommSet.Size = new System.Drawing.Size(800, 400);
            this.panel_CommSet.TabIndex = 6;
            // 
            // panel_SensorSet
            // 
            this.panel_SensorSet.Location = new System.Drawing.Point(10, 10);
            this.panel_SensorSet.Name = "panel_SensorSet";
            this.panel_SensorSet.Size = new System.Drawing.Size(800, 400);
            this.panel_SensorSet.TabIndex = 7;
            // 
            // panel_DataGather
            // 
            this.panel_DataGather.Location = new System.Drawing.Point(10, 10);
            this.panel_DataGather.Name = "panel_DataGather";
            this.panel_DataGather.Size = new System.Drawing.Size(800, 400);
            this.panel_DataGather.TabIndex = 8;
            // 
            // panel_SaveAllData
            // 
            this.panel_SaveAllData.Location = new System.Drawing.Point(10, 10);
            this.panel_SaveAllData.Name = "panel_SaveAllData";
            this.panel_SaveAllData.Size = new System.Drawing.Size(800, 400);
            this.panel_SaveAllData.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 753);
            this.Controls.Add(this.panel_SoftNote);
            this.Controls.Add(this.panel_CommSet);
            this.Controls.Add(this.panel_SensorSet);
            this.Controls.Add(this.panel_DataGather);
            this.Controls.Add(this.panel_SaveAllData);
            this.Controls.Add(this.button_HandCmd);
            this.Controls.Add(this.button_DataGather);
            this.Controls.Add(this.button_SensorSet);
            this.Controls.Add(this.button_CommSet);
            this.Controls.Add(this.button_SoftNote);
            this.Name = "Form1";
            this.Text = "PSF_Sensor_Tool01";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_SoftNote.ResumeLayout(false);
            this.panel_SoftNote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_SoftNote;
        private System.Windows.Forms.Button button_CommSet;
        private System.Windows.Forms.Button button_SensorSet;
        private System.Windows.Forms.Button button_DataGather;
        private System.Windows.Forms.Button button_HandCmd;
        private System.Windows.Forms.Panel panel_SoftNote;
        private System.Windows.Forms.Panel panel_CommSet;
        private System.Windows.Forms.Panel panel_SensorSet;
        private System.Windows.Forms.Panel panel_DataGather;
        private System.Windows.Forms.Panel panel_SaveAllData;
        private System.Windows.Forms.Label label_SoftNote;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

