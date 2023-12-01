namespace haisan
{
    partial class fTableManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTableManager));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvHoadon = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnInhoadon = new System.Windows.Forms.Button();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnQuanlibanan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnQuanlithongtin = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmMonan = new System.Windows.Forms.NumericUpDown();
            this.btnThemmon = new System.Windows.Forms.Button();
            this.cbMonan = new System.Windows.Forms.ComboBox();
            this.cbDanhmuc = new System.Windows.Forms.ComboBox();
            this.flpBanan = new System.Windows.Forms.FlowLayoutPanel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnDangxuat = new System.Windows.Forms.Button();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMonan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lsvHoadon);
            this.panel2.Location = new System.Drawing.Point(552, 89);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 338);
            this.panel2.TabIndex = 1;
            // 
            // lsvHoadon
            // 
            this.lsvHoadon.HideSelection = false;
            this.lsvHoadon.Location = new System.Drawing.Point(2, 2);
            this.lsvHoadon.Margin = new System.Windows.Forms.Padding(2);
            this.lsvHoadon.Name = "lsvHoadon";
            this.lsvHoadon.Size = new System.Drawing.Size(300, 334);
            this.lsvHoadon.TabIndex = 0;
            this.lsvHoadon.UseCompatibleStateImageBehavior = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnInhoadon);
            this.panel3.Controls.Add(this.btnThanhtoan);
            this.panel3.Location = new System.Drawing.Point(552, 432);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 114);
            this.panel3.TabIndex = 2;
            // 
            // btnInhoadon
            // 
            this.btnInhoadon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInhoadon.Location = new System.Drawing.Point(2, 2);
            this.btnInhoadon.Margin = new System.Windows.Forms.Padding(2);
            this.btnInhoadon.Name = "btnInhoadon";
            this.btnInhoadon.Size = new System.Drawing.Size(106, 53);
            this.btnInhoadon.TabIndex = 1;
            this.btnInhoadon.Text = "In hóa đơn";
            this.btnInhoadon.UseVisualStyleBackColor = true;
            this.btnInhoadon.Click += new System.EventHandler(this.btnInhoadon_Click);
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThanhtoan.Location = new System.Drawing.Point(2, 60);
            this.btnThanhtoan.Margin = new System.Windows.Forms.Padding(2);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(299, 51);
            this.btnThanhtoan.TabIndex = 0;
            this.btnThanhtoan.Text = "Thanh toán";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnQuanlibanan,
            this.mnQuanlithongtin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(865, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnQuanlibanan
            // 
            this.mnQuanlibanan.Name = "mnQuanlibanan";
            this.mnQuanlibanan.Size = new System.Drawing.Size(96, 20);
            this.mnQuanlibanan.Text = "Quản lí bàn ăn";
            this.mnQuanlibanan.Click += new System.EventHandler(this.mnQuanlibanan_Click);
            // 
            // mnQuanlithongtin
            // 
            this.mnQuanlithongtin.Name = "mnQuanlithongtin";
            this.mnQuanlithongtin.Size = new System.Drawing.Size(109, 20);
            this.mnQuanlithongtin.Text = "Quản lí thông tin";
            this.mnQuanlithongtin.Click += new System.EventHandler(this.mnQuanlithongtin_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.nmMonan);
            this.panel4.Controls.Add(this.btnThemmon);
            this.panel4.Controls.Add(this.cbMonan);
            this.panel4.Controls.Add(this.cbDanhmuc);
            this.panel4.Location = new System.Drawing.Point(552, 26);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 58);
            this.panel4.TabIndex = 4;
            // 
            // nmMonan
            // 
            this.nmMonan.Location = new System.Drawing.Point(259, 21);
            this.nmMonan.Margin = new System.Windows.Forms.Padding(2);
            this.nmMonan.Name = "nmMonan";
            this.nmMonan.Size = new System.Drawing.Size(43, 20);
            this.nmMonan.TabIndex = 3;
            this.nmMonan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemmon
            // 
            this.btnThemmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemmon.Location = new System.Drawing.Point(172, 2);
            this.btnThemmon.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemmon.Name = "btnThemmon";
            this.btnThemmon.Size = new System.Drawing.Size(82, 51);
            this.btnThemmon.TabIndex = 2;
            this.btnThemmon.Text = "Thêm món";
            this.btnThemmon.UseVisualStyleBackColor = true;
            this.btnThemmon.Click += new System.EventHandler(this.btnThemmon_Click);
            // 
            // cbMonan
            // 
            this.cbMonan.FormattingEnabled = true;
            this.cbMonan.Location = new System.Drawing.Point(2, 34);
            this.cbMonan.Margin = new System.Windows.Forms.Padding(2);
            this.cbMonan.Name = "cbMonan";
            this.cbMonan.Size = new System.Drawing.Size(165, 21);
            this.cbMonan.TabIndex = 1;
            // 
            // cbDanhmuc
            // 
            this.cbDanhmuc.FormattingEnabled = true;
            this.cbDanhmuc.Location = new System.Drawing.Point(2, 2);
            this.cbDanhmuc.Margin = new System.Windows.Forms.Padding(2);
            this.cbDanhmuc.Name = "cbDanhmuc";
            this.cbDanhmuc.Size = new System.Drawing.Size(165, 21);
            this.cbDanhmuc.TabIndex = 0;
            // 
            // flpBanan
            // 
            this.flpBanan.BackColor = System.Drawing.Color.Transparent;
            this.flpBanan.Location = new System.Drawing.Point(10, 26);
            this.flpBanan.Margin = new System.Windows.Forms.Padding(2);
            this.flpBanan.Name = "flpBanan";
            this.flpBanan.Size = new System.Drawing.Size(538, 520);
            this.flpBanan.TabIndex = 5;
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.Location = new System.Drawing.Point(9, 551);
            this.btnDangxuat.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Size = new System.Drawing.Size(80, 32);
            this.btnDangxuat.TabIndex = 6;
            this.btnDangxuat.Text = "Đăng xuất";
            this.btnDangxuat.UseVisualStyleBackColor = true;
            this.btnDangxuat.Click += new System.EventHandler(this.btnDangxuat_Click);
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.BackColor = System.Drawing.SystemColors.Control;
            this.lblXinChao.ForeColor = System.Drawing.Color.Red;
            this.lblXinChao.Location = new System.Drawing.Point(551, 9);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(35, 13);
            this.lblXinChao.TabIndex = 7;
            this.lblXinChao.Text = "label1";
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(865, 584);
            this.Controls.Add(this.lblXinChao);
            this.Controls.Add(this.btnDangxuat);
            this.Controls.Add(this.flpBanan);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lí nhà hàng hải sản";
            this.Load += new System.EventHandler(this.fTableManager_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmMonan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnQuanlibanan;
        private System.Windows.Forms.ToolStripMenuItem mnQuanlithongtin;
        private System.Windows.Forms.ListView lsvHoadon;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbMonan;
        private System.Windows.Forms.ComboBox cbDanhmuc;
        private System.Windows.Forms.NumericUpDown nmMonan;
        private System.Windows.Forms.Button btnThemmon;
        private System.Windows.Forms.FlowLayoutPanel flpBanan;
        private System.Windows.Forms.Button btnInhoadon;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnDangxuat;
        private System.Windows.Forms.Label lblXinChao;
    }
}