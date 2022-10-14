
namespace QUAN_LY_THIET_BI_DO
{
    partial class Form_device
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tagManager = new System.Windows.Forms.TabControl();
            this.tabcalibration = new System.Windows.Forms.TabPage();
            this.dtgv_device = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tagManager.SuspendLayout();
            this.tabcalibration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_device)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(5, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 57);
            this.panel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 24);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "QUAN LY HIEU CHUAN THIET BI DO";
            // 
            // tagManager
            // 
            this.tagManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagManager.Controls.Add(this.tabcalibration);
            this.tagManager.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tagManager.Location = new System.Drawing.Point(5, 162);
            this.tagManager.Name = "tagManager";
            this.tagManager.SelectedIndex = 0;
            this.tagManager.Size = new System.Drawing.Size(976, 449);
            this.tagManager.TabIndex = 6;
            // 
            // tabcalibration
            // 
            this.tabcalibration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabcalibration.Controls.Add(this.dtgv_device);
            this.tabcalibration.Location = new System.Drawing.Point(4, 22);
            this.tabcalibration.Name = "tabcalibration";
            this.tabcalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tabcalibration.Size = new System.Drawing.Size(968, 423);
            this.tabcalibration.TabIndex = 1;
            this.tabcalibration.Text = "Calibration management";
            this.tabcalibration.UseVisualStyleBackColor = true;
            // 
            // dtgv_device
            // 
            this.dtgv_device.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_device.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_device.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_device.Location = new System.Drawing.Point(6, 6);
            this.dtgv_device.Name = "dtgv_device";
            this.dtgv_device.Size = new System.Drawing.Size(952, 406);
            this.dtgv_device.TabIndex = 0;
            this.dtgv_device.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_device_CellDoubleClick);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.txtsearch);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnDel);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Location = new System.Drawing.Point(5, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 56);
            this.panel2.TabIndex = 8;
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Location = new System.Drawing.Point(438, 21);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(221, 20);
            this.txtsearch.TabIndex = 4;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnExport
            // 
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._4373169_excel_logo_logos_icon;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(19, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "  Export Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._3213447_magnifier_magnifying_glass_search_icon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(665, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "     Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.White;
            this.btnDel.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._2462966_delete_eliminate_garbage_litter_recycle_icon;
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(886, 15);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(76, 34);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "    Xóa";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._3855617_edit_pencil_write_mode_icon;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(822, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(58, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "       Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Image = global::QUAN_LY_THIET_BI_DO.Properties.Resources._32378_add_plus_icon;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(741, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "      Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form_device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 612);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tagManager);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form_device";
            this.Text = "UMC_QUAN_LY_HIEU_CHUAN_THIET_BI_DO";
            this.Load += new System.EventHandler(this.Form_device_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tagManager.ResumeLayout(false);
            this.tabcalibration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_device)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tagManager;
        private System.Windows.Forms.TabPage tabcalibration;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.DataGridView dtgv_device;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;
    }
}