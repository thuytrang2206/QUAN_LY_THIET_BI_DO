
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grb_datagridview = new System.Windows.Forms.GroupBox();
            this.dtgvcalibration = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkboximportexcel = new System.Windows.Forms.CheckBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lblnamefile = new System.Windows.Forms.Label();
            this.btnOpenfile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grb_importhand = new System.Windows.Forms.GroupBox();
            this.cbbpart_no = new System.Windows.Forms.ComboBox();
            this.dtcali_recommend = new System.Windows.Forms.DateTimePicker();
            this.dtcali_date = new System.Windows.Forms.DateTimePicker();
            this.lblcali_recommend = new System.Windows.Forms.Label();
            this.lblcali_date = new System.Windows.Forms.Label();
            this.lblpart_no = new System.Windows.Forms.Label();
            this.lblRecommendcali = new System.Windows.Forms.Label();
            this.lblDatecali = new System.Windows.Forms.Label();
            this.lblPartNo = new System.Windows.Forms.Label();
            this.grbimport_excel = new System.Windows.Forms.GroupBox();
            this.dtgvimport_excel = new System.Windows.Forms.DataGridView();
            this.PART_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALI_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CALI_RECOMMEND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grb_datagridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcalibration)).BeginInit();
            this.panel3.SuspendLayout();
            this.grb_importhand.SuspendLayout();
            this.grbimport_excel.SuspendLayout();
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
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
            this.grb_datagridview.Location = new System.Drawing.Point(0, 152);
            this.grb_datagridview.Name = "grb_datagridview";
            this.grb_datagridview.Size = new System.Drawing.Size(480, 340);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvcalibration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgvcalibration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcalibration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PART_NO,
            this.CALI_DATE,
            this.CALI_RECOMMEND});
            this.dtgvcalibration.Location = new System.Drawing.Point(7, 16);
            this.dtgvcalibration.Name = "dtgvcalibration";
            this.dtgvcalibration.RowHeadersVisible = false;
            this.dtgvcalibration.Size = new System.Drawing.Size(463, 318);
            this.dtgvcalibration.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.checkboximportexcel);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Controls.Add(this.lblnamefile);
            this.panel3.Controls.Add(this.btnOpenfile);
            this.panel3.Location = new System.Drawing.Point(0, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 58);
            this.panel3.TabIndex = 8;
            // 
            // checkboximportexcel
            // 
            this.checkboximportexcel.AutoSize = true;
            this.checkboximportexcel.Location = new System.Drawing.Point(10, 20);
            this.checkboximportexcel.Name = "checkboximportexcel";
            this.checkboximportexcel.Size = new System.Drawing.Size(123, 17);
            this.checkboximportexcel.TabIndex = 14;
            this.checkboximportexcel.Text = "Nhập bằng file excel";
            this.checkboximportexcel.UseVisualStyleBackColor = true;
            this.checkboximportexcel.CheckedChanged += new System.EventHandler(this.checkboximportexcel_CheckedChanged);
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
            this.lblnamefile.Location = new System.Drawing.Point(595, 20);
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
            this.btnOpenfile.Enabled = false;
            this.btnOpenfile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnOpenfile.FlatAppearance.BorderSize = 0;
            this.btnOpenfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnOpenfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnOpenfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenfile.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._85334_file_open_icon16px;
            this.btnOpenfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenfile.Location = new System.Drawing.Point(821, 10);
            this.btnOpenfile.Name = "btnOpenfile";
            this.btnOpenfile.Size = new System.Drawing.Size(96, 27);
            this.btnOpenfile.TabIndex = 9;
            this.btnOpenfile.TabStop = false;
            this.btnOpenfile.Text = "     Open file";
            this.btnOpenfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenfile.UseVisualStyleBackColor = false;
            this.btnOpenfile.Click += new System.EventHandler(this.btnOpenfile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // grb_importhand
            // 
            this.grb_importhand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb_importhand.BackColor = System.Drawing.Color.White;
            this.grb_importhand.Controls.Add(this.cbbpart_no);
            this.grb_importhand.Controls.Add(this.dtcali_recommend);
            this.grb_importhand.Controls.Add(this.dtcali_date);
            this.grb_importhand.Controls.Add(this.lblcali_recommend);
            this.grb_importhand.Controls.Add(this.lblcali_date);
            this.grb_importhand.Controls.Add(this.lblpart_no);
            this.grb_importhand.Controls.Add(this.lblRecommendcali);
            this.grb_importhand.Controls.Add(this.lblDatecali);
            this.grb_importhand.Controls.Add(this.label1);
            this.grb_importhand.Controls.Add(this.lblPartNo);
            this.grb_importhand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grb_importhand.Location = new System.Drawing.Point(486, 152);
            this.grb_importhand.Name = "grb_importhand";
            this.grb_importhand.Size = new System.Drawing.Size(501, 175);
            this.grb_importhand.TabIndex = 11;
            this.grb_importhand.TabStop = false;
            this.grb_importhand.Text = "Nhập bằng tay";
            // 
            // cbbpart_no
            // 
            this.cbbpart_no.FormattingEnabled = true;
            this.cbbpart_no.Location = new System.Drawing.Point(217, 26);
            this.cbbpart_no.Name = "cbbpart_no";
            this.cbbpart_no.Size = new System.Drawing.Size(121, 21);
            this.cbbpart_no.TabIndex = 24;
            this.cbbpart_no.SelectedIndexChanged += new System.EventHandler(this.cbbpart_no_SelectedIndexChanged);
            // 
            // dtcali_recommend
            // 
            this.dtcali_recommend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtcali_recommend.Location = new System.Drawing.Point(214, 110);
            this.dtcali_recommend.Name = "dtcali_recommend";
            this.dtcali_recommend.Size = new System.Drawing.Size(200, 20);
            this.dtcali_recommend.TabIndex = 23;
            // 
            // dtcali_date
            // 
            this.dtcali_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtcali_date.Location = new System.Drawing.Point(214, 67);
            this.dtcali_date.Name = "dtcali_date";
            this.dtcali_date.Size = new System.Drawing.Size(200, 20);
            this.dtcali_date.TabIndex = 22;
            // 
            // lblcali_recommend
            // 
            this.lblcali_recommend.AutoSize = true;
            this.lblcali_recommend.ForeColor = System.Drawing.Color.Red;
            this.lblcali_recommend.Location = new System.Drawing.Point(214, 132);
            this.lblcali_recommend.Name = "lblcali_recommend";
            this.lblcali_recommend.Size = new System.Drawing.Size(41, 13);
            this.lblcali_recommend.TabIndex = 21;
            this.lblcali_recommend.Text = "label22";
            this.lblcali_recommend.Visible = false;
            // 
            // lblcali_date
            // 
            this.lblcali_date.AutoSize = true;
            this.lblcali_date.ForeColor = System.Drawing.Color.Red;
            this.lblcali_date.Location = new System.Drawing.Point(214, 91);
            this.lblcali_date.Name = "lblcali_date";
            this.lblcali_date.Size = new System.Drawing.Size(41, 13);
            this.lblcali_date.TabIndex = 20;
            this.lblcali_date.Text = "label21";
            this.lblcali_date.Visible = false;
            // 
            // lblpart_no
            // 
            this.lblpart_no.AutoSize = true;
            this.lblpart_no.ForeColor = System.Drawing.Color.Red;
            this.lblpart_no.Location = new System.Drawing.Point(214, 51);
            this.lblpart_no.Name = "lblpart_no";
            this.lblpart_no.Size = new System.Drawing.Size(41, 13);
            this.lblpart_no.TabIndex = 19;
            this.lblpart_no.Text = "label20";
            this.lblpart_no.Visible = false;
            // 
            // lblRecommendcali
            // 
            this.lblRecommendcali.AutoSize = true;
            this.lblRecommendcali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecommendcali.Location = new System.Drawing.Point(24, 114);
            this.lblRecommendcali.Name = "lblRecommendcali";
            this.lblRecommendcali.Size = new System.Drawing.Size(182, 16);
            this.lblRecommendcali.TabIndex = 18;
            this.lblRecommendcali.Text = "Ngày hiệu chuẩn đề nghị:";
            // 
            // lblDatecali
            // 
            this.lblDatecali.AutoSize = true;
            this.lblDatecali.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatecali.Location = new System.Drawing.Point(24, 72);
            this.lblDatecali.Name = "lblDatecali";
            this.lblDatecali.Size = new System.Drawing.Size(123, 16);
            this.lblDatecali.TabIndex = 17;
            this.lblDatecali.Text = "Ngày hiệu chuẩn";
            // 
            // lblPartNo
            // 
            this.lblPartNo.AutoSize = true;
            this.lblPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartNo.Location = new System.Drawing.Point(24, 31);
            this.lblPartNo.Name = "lblPartNo";
            this.lblPartNo.Size = new System.Drawing.Size(83, 16);
            this.lblPartNo.TabIndex = 16;
            this.lblPartNo.Text = "Mã quản lý";
            // 
            // grbimport_excel
            // 
            this.grbimport_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbimport_excel.BackColor = System.Drawing.Color.White;
            this.grbimport_excel.Controls.Add(this.dtgvimport_excel);
            this.grbimport_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbimport_excel.Location = new System.Drawing.Point(486, 333);
            this.grbimport_excel.Name = "grbimport_excel";
            this.grbimport_excel.Size = new System.Drawing.Size(501, 159);
            this.grbimport_excel.TabIndex = 12;
            this.grbimport_excel.TabStop = false;
            this.grbimport_excel.Text = "Nhập bằng file excel";
            this.grbimport_excel.Visible = false;
            // 
            // dtgvimport_excel
            // 
            this.dtgvimport_excel.AllowUserToAddRows = false;
            this.dtgvimport_excel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvimport_excel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvimport_excel.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvimport_excel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtgvimport_excel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvimport_excel.Location = new System.Drawing.Point(9, 13);
            this.dtgvimport_excel.Name = "dtgvimport_excel";
            this.dtgvimport_excel.RowHeadersVisible = false;
            this.dtgvimport_excel.Size = new System.Drawing.Size(486, 140);
            this.dtgvimport_excel.TabIndex = 1;
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
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 504);
            this.Controls.Add(this.grbimport_excel);
            this.Controls.Add(this.grb_importhand);
            this.Controls.Add(this.grb_datagridview);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormCalibration";
            this.Text = "FormCalibration";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grb_datagridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcalibration)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grb_importhand.ResumeLayout(false);
            this.grb_importhand.PerformLayout();
            this.grbimport_excel.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grb_importhand;
        private System.Windows.Forms.GroupBox grbimport_excel;
        private System.Windows.Forms.DataGridView dtgvimport_excel;
        private System.Windows.Forms.DataGridView dtgvcalibration;
        private System.Windows.Forms.ComboBox cbbpart_no;
        private System.Windows.Forms.DateTimePicker dtcali_recommend;
        private System.Windows.Forms.DateTimePicker dtcali_date;
        private System.Windows.Forms.Label lblcali_recommend;
        private System.Windows.Forms.Label lblcali_date;
        private System.Windows.Forms.Label lblpart_no;
        private System.Windows.Forms.Label lblRecommendcali;
        private System.Windows.Forms.Label lblDatecali;
        private System.Windows.Forms.Label lblPartNo;
        private System.Windows.Forms.CheckBox checkboximportexcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PART_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALI_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CALI_RECOMMEND;
    }
}