namespace QLThuVien
{
    partial class MDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_DocGia = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_NhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Sach = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_MuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_PM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_CTPM = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_TKDG = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_TKSach = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.MenuItem_MuonTra,
            this.tìmKiếmToolStripMenuItem,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fToolStripMenuItem
            // 
            this.fToolStripMenuItem.Name = "fToolStripMenuItem";
            this.fToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fToolStripMenuItem.Text = "File";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_DocGia,
            this.MenuItem_NhanVien,
            this.MenuItem_Sach});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // MenuItem_DocGia
            // 
            this.MenuItem_DocGia.Name = "MenuItem_DocGia";
            this.MenuItem_DocGia.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_DocGia.Text = "Độc giả";
            this.MenuItem_DocGia.Click += new System.EventHandler(this.MenuItem_DocGia_Click);
            // 
            // MenuItem_NhanVien
            // 
            this.MenuItem_NhanVien.Name = "MenuItem_NhanVien";
            this.MenuItem_NhanVien.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_NhanVien.Text = "Nhân viên";
            this.MenuItem_NhanVien.Click += new System.EventHandler(this.MenuItem_NhanVien_Click);
            // 
            // MenuItem_Sach
            // 
            this.MenuItem_Sach.Name = "MenuItem_Sach";
            this.MenuItem_Sach.Size = new System.Drawing.Size(142, 22);
            this.MenuItem_Sach.Text = "Quản lý sách";
            this.MenuItem_Sach.Click += new System.EventHandler(this.MenuItem_Sach_Click);
            // 
            // MenuItem_MuonTra
            // 
            this.MenuItem_MuonTra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_PM,
            this.MenuItem_CTPM});
            this.MenuItem_MuonTra.Name = "MenuItem_MuonTra";
            this.MenuItem_MuonTra.Size = new System.Drawing.Size(95, 20);
            this.MenuItem_MuonTra.Text = "Mượn trả sách";
            this.MenuItem_MuonTra.Click += new System.EventHandler(this.MenuItem_MuonTra_Click);
            // 
            // MenuItem_PM
            // 
            this.MenuItem_PM.Name = "MenuItem_PM";
            this.MenuItem_PM.Size = new System.Drawing.Size(164, 22);
            this.MenuItem_PM.Text = "Tạo phiếu mượn";
            this.MenuItem_PM.Click += new System.EventHandler(this.MenuItem_PM_Click);
            // 
            // MenuItem_CTPM
            // 
            this.MenuItem_CTPM.Name = "MenuItem_CTPM";
            this.MenuItem_CTPM.Size = new System.Drawing.Size(164, 22);
            this.MenuItem_CTPM.Text = "Chi tiết mượn trả";
            this.MenuItem_CTPM.Click += new System.EventHandler(this.MenuItem_CTPM_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_TKDG,
            this.MenuItem_TKSach});
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // MenuItem_TKDG
            // 
            this.MenuItem_TKDG.Name = "MenuItem_TKDG";
            this.MenuItem_TKDG.Size = new System.Drawing.Size(114, 22);
            this.MenuItem_TKDG.Text = "Độc giả";
            this.MenuItem_TKDG.Click += new System.EventHandler(this.MenuItem_TKDG_Click);
            // 
            // MenuItem_TKSach
            // 
            this.MenuItem_TKSach.Name = "MenuItem_TKSach";
            this.MenuItem_TKSach.Size = new System.Drawing.Size(114, 22);
            this.MenuItem_TKSach.Text = "Sách";
            this.MenuItem_TKSach.Click += new System.EventHandler(this.MenuItem_TKSach_Click);
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDI";
            this.Text = "Quản lý thư viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_DocGia;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_NhanVien;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_MuonTra;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_TKDG;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_TKSach;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Sach;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_PM;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_CTPM;
    }
}

