
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibration));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.handtab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgv_his = new System.Windows.Forms.DataGridView();
            this.Date_check = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Partname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.chkbox_donecheck = new System.Windows.Forms.CheckBox();
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
            this.btn_saveimport = new System.Windows.Forms.Button();
            this.grb_datagridview = new System.Windows.Forms.GroupBox();
            this.dtgvcalibration = new System.Windows.Forms.DataGridView();
            this.PART_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALI_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALI_RECOMMEND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Open = new System.Windows.Forms.Button();
            this.lblnamefile = new System.Windows.Forms.Label();
            this.dtgvimport_excel = new System.Windows.Forms.DataGridView();
            this.cbbsheet = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.handtab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_his)).BeginInit();
            this.exceltab.SuspendLayout();
            this.grb_datagridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcalibration)).BeginInit();
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
            this.textBox1.Size = new System.Drawing.Size(488, 24);
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
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tabControl);
            this.panel3.Controls.Add(this.grb_datagridview);
            this.panel3.Location = new System.Drawing.Point(0, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 449);
            this.panel3.TabIndex = 8;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.handtab);
            this.tabControl.Controls.Add(this.exceltab);
            this.tabControl.Location = new System.Drawing.Point(545, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(443, 439);
            this.tabControl.TabIndex = 12;
            this.tabControl.Tag = "";
            this.tabControl.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // handtab
            // 
            this.handtab.Controls.Add(this.label7);
            this.handtab.Controls.Add(this.dtgv_his);
            this.handtab.Controls.Add(this.btn_Luu);
            this.handtab.Controls.Add(this.chkbox_donecheck);
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
            this.handtab.Size = new System.Drawing.Size(435, 413);
            this.handtab.TabIndex = 0;
            this.handtab.Text = "Setting";
            this.handtab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Lịch sử hiệu chuẩn:";
            // 
            // dtgv_his
            // 
            this.dtgv_his.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_his.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_his.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date_check,
            this.Partno,
            this.Partname,
            this.Serial});
            this.dtgv_his.Location = new System.Drawing.Point(6, 225);
            this.dtgv_his.Name = "dtgv_his";
            this.dtgv_his.RowHeadersVisible = false;
            this.dtgv_his.Size = new System.Drawing.Size(404, 182);
            this.dtgv_his.TabIndex = 40;
            // 
            // Date_check
            // 
            this.Date_check.DataPropertyName = "DATE_CHECK";
            this.Date_check.HeaderText = "Ngày kiểm tra";
            this.Date_check.Name = "Date_check";
            // 
            // Partno
            // 
            this.Partno.DataPropertyName = "PART_NO";
            this.Partno.HeaderText = "Mã quản lý";
            this.Partno.Name = "Partno";
            // 
            // Partname
            // 
            this.Partname.DataPropertyName = "PART_NAME";
            this.Partname.HeaderText = "Tên thiết bị";
            this.Partname.Name = "Partname";
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "SERIAL";
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            // 
            // btn_Luu
            // 
            this.btn_Luu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Luu.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._85542_guardar_save_icon__1_1;
            this.btn_Luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Luu.Location = new System.Drawing.Point(348, 145);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(62, 27);
            this.btn_Luu.TabIndex = 39;
            this.btn_Luu.Text = "   Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // chkbox_donecheck
            // 
            this.chkbox_donecheck.AutoSize = true;
            this.chkbox_donecheck.Location = new System.Drawing.Point(210, 155);
            this.chkbox_donecheck.Name = "chkbox_donecheck";
            this.chkbox_donecheck.Size = new System.Drawing.Size(96, 17);
            this.chkbox_donecheck.TabIndex = 34;
            this.chkbox_donecheck.Text = "Đã hiệu chuẩn";
            this.chkbox_donecheck.UseVisualStyleBackColor = true;
            // 
            // cbbpart_no
            // 
            this.cbbpart_no.FormattingEnabled = true;
            this.cbbpart_no.Location = new System.Drawing.Point(210, 21);
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
            this.dtcali_date.Location = new System.Drawing.Point(210, 62);
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
            this.lblDatecali.Size = new System.Drawing.Size(127, 16);
            this.lblDatecali.TabIndex = 26;
            this.lblDatecali.Text = "Ngày hiệu chuẩn:";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNo.Location = new System.Drawing.Point(22, 26);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(87, 16);
            this.lblPartNo.TabIndex = 25;
            this.lblPartNo.Text = "Mã quản lý:";
            // 
            // exceltab
            // 
            this.exceltab.Controls.Add(this.cbbsheet);
            this.exceltab.Controls.Add(this.dtgvimport_excel);
            this.exceltab.Controls.Add(this.lblnamefile);
            this.exceltab.Controls.Add(this.btn_Open);
            this.exceltab.Controls.Add(this.btn_saveimport);
            this.exceltab.Location = new System.Drawing.Point(4, 22);
            this.exceltab.Name = "exceltab";
            this.exceltab.Padding = new System.Windows.Forms.Padding(3);
            this.exceltab.Size = new System.Drawing.Size(435, 413);
            this.exceltab.TabIndex = 1;
            this.exceltab.Text = "Import";
            this.exceltab.UseVisualStyleBackColor = true;
            // 
            // btn_saveimport
            // 
            this.btn_saveimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveimport.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._3855617_edit_pencil_write_mode_icon16px1;
            this.btn_saveimport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveimport.Location = new System.Drawing.Point(367, 380);
            this.btn_saveimport.Name = "btn_saveimport";
            this.btn_saveimport.Size = new System.Drawing.Size(62, 27);
            this.btn_saveimport.TabIndex = 39;
            this.btn_saveimport.Text = "   Save";
            this.btn_saveimport.UseVisualStyleBackColor = true;
            this.btn_saveimport.Click += new System.EventHandler(this.btn_saveimport_Click);
            // 
            // grb_datagridview
            // 
            this.grb_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_datagridview.BackColor = System.Drawing.Color.White;
            this.grb_datagridview.Controls.Add(this.dtgvcalibration);
            this.grb_datagridview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grb_datagridview.Location = new System.Drawing.Point(1, 3);
            this.grb_datagridview.Name = "grb_datagridview";
            this.grb_datagridview.Size = new System.Drawing.Size(538, 439);
            this.grb_datagridview.TabIndex = 11;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvcalibration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvcalibration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcalibration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PART_NO,
            this.CALI_DATE,
            this.CALI_RECOMMEND});
            this.dtgvcalibration.Location = new System.Drawing.Point(7, 19);
            this.dtgvcalibration.Name = "dtgvcalibration";
            this.dtgvcalibration.RowHeadersVisible = false;
            this.dtgvcalibration.Size = new System.Drawing.Size(521, 414);
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
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(354, 6);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(75, 23);
            this.btn_Open.TabIndex = 41;
            this.btn_Open.Text = "Open file";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btnOpenfile_Click);
            // 
            // lblnamefile
            // 
            this.lblnamefile.AutoSize = true;
            this.lblnamefile.Location = new System.Drawing.Point(6, 16);
            this.lblnamefile.Name = "lblnamefile";
            this.lblnamefile.Size = new System.Drawing.Size(33, 13);
            this.lblnamefile.TabIndex = 42;
            this.lblnamefile.Text = "name";
            // 
            // dtgvimport_excel
            // 
            this.dtgvimport_excel.AllowUserToAddRows = false;
            this.dtgvimport_excel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvimport_excel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvimport_excel.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvimport_excel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvimport_excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvimport_excel.Location = new System.Drawing.Point(5, 47);
            this.dtgvimport_excel.Name = "dtgvimport_excel";
            this.dtgvimport_excel.RowHeadersVisible = false;
            this.dtgvimport_excel.Size = new System.Drawing.Size(424, 327);
            this.dtgvimport_excel.TabIndex = 43;
            // 
            // cbbsheet
            // 
            this.cbbsheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbsheet.FormattingEnabled = true;
            this.cbbsheet.Location = new System.Drawing.Point(215, 8);
            this.cbbsheet.Name = "cbbsheet";
            this.cbbsheet.Size = new System.Drawing.Size(121, 21);
            this.cbbsheet.TabIndex = 44;
            this.cbbsheet.SelectedIndexChanged += new System.EventHandler(this.cbbsheet_SelectedIndexChanged);
            // 
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 541);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalibration";
            this.Text = "UMC_QUAN_LY_HIEU_CHUAN_THIET_BI_DO";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.handtab.ResumeLayout(false);
            this.handtab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_his)).EndInit();
            this.exceltab.ResumeLayout(false);
            this.exceltab.PerformLayout();
            this.grb_datagridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcalibration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvimport_excel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage handtab;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.CheckBox chkbox_donecheck;
        private System.Windows.Forms.ComboBox cbbpart_no;
        private System.Windows.Forms.DateTimePicker dtcali_recommend;
        private System.Windows.Forms.DateTimePicker dtcali_date;
        private System.Windows.Forms.Label lblcali_recommend;
        private System.Windows.Forms.Label lblcali_date;
        private System.Windows.Forms.Label lblpart_no;
        private System.Windows.Forms.Label lblRecommendcali;
        private System.Windows.Forms.Label lblDatecali;
        private System.Windows.Forms.Label lblPartNo;
        private System.Windows.Forms.TabPage exceltab;
        private System.Windows.Forms.GroupBox grb_datagridview;
        private System.Windows.Forms.DataGridView dtgvcalibration;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALI_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALI_RECOMMEND;
        private System.Windows.Forms.Button btn_saveimport;
        private System.Windows.Forms.DataGridView dtgv_his;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Partname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Label lblnamefile;
        private System.Windows.Forms.DataGridView dtgvimport_excel;
        private System.Windows.Forms.ComboBox cbbsheet;
    }
}