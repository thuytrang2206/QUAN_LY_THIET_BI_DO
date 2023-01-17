
namespace QUAN_LY_THIET_BI_DO
{
    partial class FormCalibration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibration));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grb_datagridview = new System.Windows.Forms.GroupBox();
            this.dtgvcalibration = new System.Windows.Forms.DataGridView();
            this.PART_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALI_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALI_RECOMMEND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.lblnamefile = new System.Windows.Forms.Label();
            this.btnOpenfile = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.handtab = new System.Windows.Forms.TabPage();
            this.cbbpart_no = new System.Windows.Forms.ComboBox();
            this.dtcali_recommend = new System.Windows.Forms.DateTimePicker();
            this.dtcali_date = new System.Windows.Forms.DateTimePicker();
            this.lblcali_recommend = new System.Windows.Forms.Label();
            this.lblcali_date = new System.Windows.Forms.Label();
            this.lblpart_no = new System.Windows.Forms.Label();
            this.lblRecommendcali = new System.Windows.Forms.Label();
            this.lblDatecali = new System.Windows.Forms.Label();
            this.lblPartNo = new System.Windows.Forms.Label();
            this.exceltab = new System.Windows.Forms.TabPage();
            this.dtgvimport_excel = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grb_datagridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcalibration)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.handtab.SuspendLayout();
            this.exceltab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvimport_excel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 57);
            this.panel1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(3, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(541, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "UMCVN_QUẢN LÝ HIỆU CHUẨN THIẾT BỊ ĐO";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem1.Text = "Systems";
            // 
            // grb_datagridview
            // 
            this.grb_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_datagridview.BackColor = System.Drawing.Color.White;
            this.grb_datagridview.Controls.Add(this.dtgvcalibration);
            this.grb_datagridview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grb_datagridview.Location = new System.Drawing.Point(0, 140);
            this.grb_datagridview.Name = "grb_datagridview";
            this.grb_datagridview.Size = new System.Drawing.Size(480, 352);
            this.grb_datagridview.TabIndex = 9;
            this.grb_datagridview.TabStop = false;
            this.grb_datagridview.Text = "Dữ liệu hàng tháng sau hiệu chuẩn";
            // 
            // dtgvcalibration
            // 
            this.dtgvcalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvcalibration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvcalibration.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvcalibration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvcalibration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcalibration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PART_NO,
            this.CALI_DATE,
            this.CALI_RECOMMEND});
            this.dtgvcalibration.Location = new System.Drawing.Point(7, 19);
            this.dtgvcalibration.Name = "dtgvcalibration";
            this.dtgvcalibration.RowHeadersVisible = false;
            this.dtgvcalibration.Size = new System.Drawing.Size(463, 327);
            this.dtgvcalibration.TabIndex = 0;
            // 
            // PART_NO
            // 
            this.PART_NO.DataPropertyName = "PART_NO";
            this.PART_NO.HeaderText = "Mã quản lý";
            this.PART_NO.Name = "PART_NO";
            // 
            // CALI_DATE
            // 
            this.CALI_DATE.DataPropertyName = "CALI_DATE";
            this.CALI_DATE.HeaderText = "Ngày hiệu chuẩn";
            this.CALI_DATE.Name = "CALI_DATE";
            // 
            // CALI_RECOMMEND
            // 
            this.CALI_RECOMMEND.DataPropertyName = "CALI_RECOMMEND";
            this.CALI_RECOMMEND.HeaderText = "Ngày hiệu chuẩn đề nghị";
            this.CALI_RECOMMEND.Name = "CALI_RECOMMEND";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Location = new System.Drawing.Point(0, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 46);
            this.panel3.TabIndex = 8;
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._85542_guardar_save_icon__1_1;
            this.btn_save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_save.Location = new System.Drawing.Point(923, 10);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(62, 27);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "   Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lblnamefile
            // 
            this.lblnamefile.AutoSize = true;
            this.lblnamefile.Location = new System.Drawing.Point(305, 15);
            this.lblnamefile.Name = "lblnamefile";
            this.lblnamefile.Size = new System.Drawing.Size(52, 13);
            this.lblnamefile.TabIndex = 10;
            this.lblnamefile.Text = "name_file";
            this.lblnamefile.Visible = false;
            // 
            // btnOpenfile
            // 
            this.btnOpenfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenfile.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenfile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenfile.FlatAppearance.BorderSize = 0;
            this.btnOpenfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOpenfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOpenfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenfile.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._85334_file_open_icon16px1;
            this.btnOpenfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenfile.Location = new System.Drawing.Point(391, 7);
            this.btnOpenfile.Name = "btnOpenfile";
            this.btnOpenfile.Size = new System.Drawing.Size(96, 27);
            this.btnOpenfile.TabIndex = 9;
            this.btnOpenfile.TabStop = false;
            this.btnOpenfile.Text = "     Open file";
            this.btnOpenfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenfile.UseVisualStyleBackColor = false;
            this.btnOpenfile.Click += new System.EventHandler(this.btnOpenfile_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.handtab);
            this.tabControl.Controls.Add(this.exceltab);
            this.tabControl.Location = new System.Drawing.Point(486, 140);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(501, 352);
            this.tabControl.TabIndex = 10;
            this.tabControl.Tag = "";
            // 
            // handtab
            // 
            this.handtab.Controls.Add(this.cbbpart_no);
            this.handtab.Controls.Add(this.dtcali_recommend);
            this.handtab.Controls.Add(this.dtcali_date);
            this.handtab.Controls.Add(this.lblcali_recommend);
            this.handtab.Controls.Add(this.lblcali_date);
            this.handtab.Controls.Add(this.lblpart_no);
            this.handtab.Controls.Add(this.lblRecommendcali);
            this.handtab.Controls.Add(this.lblDatecali);
            this.handtab.Controls.Add(this.lblPartNo);
            this.handtab.Location = new System.Drawing.Point(4, 22);
            this.handtab.Name = "handtab";
            this.handtab.Padding = new System.Windows.Forms.Padding(3);
            this.handtab.Size = new System.Drawing.Size(493, 326);
            this.handtab.TabIndex = 0;
            this.handtab.Text = "Hand";
            this.handtab.UseVisualStyleBackColor = true;
            // 
            // cbbpart_no
            // 
            this.cbbpart_no.FormattingEnabled = true;
            this.cbbpart_no.Location = new System.Drawing.Point(215, 21);
            this.cbbpart_no.Name = "cbbpart_no";
            this.cbbpart_no.Size = new System.Drawing.Size(121, 21);
            this.cbbpart_no.TabIndex = 33;
            this.cbbpart_no.SelectedIndexChanged += new System.EventHandler(this.cbbpart_no_SelectedIndexChanged);
            // 
            // dtcali_recommend
            // 
            this.dtcali_recommend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtcali_recommend.Location = new System.Drawing.Point(210, 105);
            this.dtcali_recommend.Name = "dtcali_recommend";
            this.dtcali_recommend.Size = new System.Drawing.Size(200, 20);
            this.dtcali_recommend.TabIndex = 32;
            // 
            // dtcali_date
            // 
            this.dtcali_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtcali_date.Location = new System.Drawing.Point(212, 62);
            this.dtcali_date.Name = "dtcali_date";
            this.dtcali_date.Size = new System.Drawing.Size(200, 20);
            this.dtcali_date.TabIndex = 31;
            // 
            // lblcali_recommend
            // 
            this.lblcali_recommend.AutoSize = true;
            this.lblcali_recommend.ForeColor = System.Drawing.Color.Red;
            this.lblcali_recommend.Location = new System.Drawing.Point(212, 127);
            this.lblcali_recommend.Name = "lblcali_recommend";
            this.lblcali_recommend.Size = new System.Drawing.Size(41, 13);
            this.lblcali_recommend.TabIndex = 30;
            this.lblcali_recommend.Text = "label22";
            this.lblcali_recommend.Visible = false;
            // 
            // lblcali_date
            // 
            this.lblcali_date.AutoSize = true;
            this.lblcali_date.ForeColor = System.Drawing.Color.Red;
            this.lblcali_date.Location = new System.Drawing.Point(212, 86);
            this.lblcali_date.Name = "lblcali_date";
            this.lblcali_date.Size = new System.Drawing.Size(41, 13);
            this.lblcali_date.TabIndex = 29;
            this.lblcali_date.Text = "label21";
            this.lblcali_date.Visible = false;
            // 
            // lblpart_no
            // 
            this.lblpart_no.AutoSize = true;
            this.lblpart_no.ForeColor = System.Drawing.Color.Red;
            this.lblpart_no.Location = new System.Drawing.Point(212, 46);
            this.lblpart_no.Name = "lblpart_no";
            this.lblpart_no.Size = new System.Drawing.Size(41, 13);
            this.lblpart_no.TabIndex = 28;
            this.lblpart_no.Text = "label20";
            this.lblpart_no.Visible = false;
            // 
            // lblRecommendcali
            // 
            this.lblRecommendcali.AutoSize = true;
            this.lblRecommendcali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendcali.Location = new System.Drawing.Point(22, 109);
            this.lblRecommendcali.Name = "lblRecommendcali";
            this.lblRecommendcali.Size = new System.Drawing.Size(182, 16);
            this.lblRecommendcali.TabIndex = 27;
            this.lblRecommendcali.Text = "Ngày hiệu chuẩn đề nghị:";
            // 
            // lblDatecali
            // 
            this.lblDatecali.AutoSize = true;
            this.lblDatecali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatecali.Location = new System.Drawing.Point(22, 67);
            this.lblDatecali.Name = "lblDatecali";
            this.lblDatecali.Size = new System.Drawing.Size(123, 16);
            this.lblDatecali.TabIndex = 26;
            this.lblDatecali.Text = "Ngày hiệu chuẩn";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNo.Location = new System.Drawing.Point(22, 26);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(83, 16);
            this.lblPartNo.TabIndex = 25;
            this.lblPartNo.Text = "Mã quản lý";
            // 
            // exceltab
            // 
            this.exceltab.Controls.Add(this.dtgvimport_excel);
            this.exceltab.Controls.Add(this.lblnamefile);
            this.exceltab.Controls.Add(this.btnOpenfile);
            this.exceltab.Location = new System.Drawing.Point(4, 22);
            this.exceltab.Name = "exceltab";
            this.exceltab.Padding = new System.Windows.Forms.Padding(3);
            this.exceltab.Size = new System.Drawing.Size(493, 326);
            this.exceltab.TabIndex = 1;
            this.exceltab.Text = "Import Excel";
            this.exceltab.UseVisualStyleBackColor = true;
            // 
            // dtgvimport_excel
            // 
            this.dtgvimport_excel.AllowUserToAddRows = false;
            this.dtgvimport_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvimport_excel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvimport_excel.BackgroundColor = System.Drawing.Color.White;
            this.dtgvimport_excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvimport_excel.Location = new System.Drawing.Point(3, 40);
            this.dtgvimport_excel.Name = "dtgvimport_excel";
            this.dtgvimport_excel.RowHeadersVisible = false;
            this.dtgvimport_excel.Size = new System.Drawing.Size(486, 283);
            this.dtgvimport_excel.TabIndex = 2;
            this.dtgvimport_excel.Visible = false;
            // 
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 504);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.grb_datagridview);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalibration";
            this.Text = "UMC_QUAN_LY_HIEU_CHUAN_THIET_BI_DO";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grb_datagridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcalibration)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.handtab.ResumeLayout(false);
            this.handtab.PerformLayout();
            this.exceltab.ResumeLayout(false);
            this.exceltab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvimport_excel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.GroupBox grb_datagridview;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lblnamefile;
        private System.Windows.Forms.Button btnOpenfile;
        private System.Windows.Forms.DataGridView dtgvcalibration;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALI_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALI_RECOMMEND;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage handtab;
        private System.Windows.Forms.TabPage exceltab;
        private System.Windows.Forms.ComboBox cbbpart_no;
        private System.Windows.Forms.DateTimePicker dtcali_recommend;
        private System.Windows.Forms.DateTimePicker dtcali_date;
        private System.Windows.Forms.Label lblcali_recommend;
        private System.Windows.Forms.Label lblcali_date;
        private System.Windows.Forms.Label lblpart_no;
        private System.Windows.Forms.Label lblRecommendcali;
        private System.Windows.Forms.Label lblDatecali;
        private System.Windows.Forms.Label lblPartNo;
        private System.Windows.Forms.DataGridView dtgvimport_excel;
    }
}