
namespace QUAN_LY_THIET_BI_DO
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabcalibration = new System.Windows.Forms.TabPage();
            this.btncalibration = new System.Windows.Forms.Button();
            this.btnDevice = new System.Windows.Forms.Button();
            this.tagManager = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tabcalibration.SuspendLayout();
            this.tagManager.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem1.Text = "Systems";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // tabcalibration
            // 
            this.tabcalibration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabcalibration.Controls.Add(this.btncalibration);
            this.tabcalibration.Controls.Add(this.btnDevice);
            this.tabcalibration.Location = new System.Drawing.Point(4, 22);
            this.tabcalibration.Name = "tabcalibration";
            this.tabcalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tabcalibration.Size = new System.Drawing.Size(936, 409);
            this.tabcalibration.TabIndex = 1;
            this.tabcalibration.Text = "Calibration management";
            this.tabcalibration.UseVisualStyleBackColor = true;
            // 
            // btncalibration
            // 
            this.btncalibration.BackColor = System.Drawing.Color.White;
            this.btncalibration.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btncalibration.FlatAppearance.BorderSize = 0;
            this.btncalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncalibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncalibration.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._85334_file_open_icon_32px;
            this.btncalibration.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btncalibration.Location = new System.Drawing.Point(120, 6);
            this.btncalibration.Name = "btncalibration";
            this.btncalibration.Size = new System.Drawing.Size(122, 77);
            this.btncalibration.TabIndex = 1;
            this.btncalibration.Text = "Manager calibration ";
            this.btncalibration.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btncalibration.UseVisualStyleBackColor = false;
            this.btncalibration.Click += new System.EventHandler(this.btncalibration_Click);
            // 
            // btnDevice
            // 
            this.btnDevice.BackColor = System.Drawing.Color.White;
            this.btnDevice.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDevice.FlatAppearance.BorderSize = 0;
            this.btnDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevice.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._85334_file_open_icon_32px;
            this.btnDevice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDevice.Location = new System.Drawing.Point(15, 6);
            this.btnDevice.Name = "btnDevice";
            this.btnDevice.Size = new System.Drawing.Size(99, 77);
            this.btnDevice.TabIndex = 0;
            this.btnDevice.Text = "Manager device";
            this.btnDevice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDevice.UseVisualStyleBackColor = false;
            this.btnDevice.Click += new System.EventHandler(this.btnDevice_Click);
            // 
            // tagManager
            // 
            this.tagManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagManager.Controls.Add(this.tabcalibration);
            this.tagManager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tagManager.Location = new System.Drawing.Point(5, 96);
            this.tagManager.Name = "tagManager";
            this.tagManager.SelectedIndex = 0;
            this.tagManager.Size = new System.Drawing.Size(944, 435);
            this.tagManager.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(5, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 57);
            this.panel1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(2, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(475, 24);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "UMC_QUẢN LÝ HIỆU CHUẨN THIẾT BỊ ĐO";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(956, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "PE-IT:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel2.Text = "3143";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel3.Text = "Version:";
            // 
            // toolStripStatusVersion
            // 
            this.toolStripStatusVersion.Name = "toolStripStatusVersion";
            this.toolStripStatusVersion.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 543);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tagManager);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "UMC_QUAN_LY_HIEU_CHUAN_THIET_BI_DO";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabcalibration.ResumeLayout(false);
            this.tagManager.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage tabcalibration;
        private System.Windows.Forms.TabControl tagManager;
        private System.Windows.Forms.Button btnDevice;
        private System.Windows.Forms.Button btncalibration;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusVersion;
    }
}

