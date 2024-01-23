using QLThuVien.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {

        }

        private void MenuItem_Sach_Click(object sender, EventArgs e)
        {
            frmSach frm_sach = new frmSach();
            frm_sach.ShowDialog();
        }

        private void MenuItem_DocGia_Click(object sender, EventArgs e)
        {
            frmDocGia frm_dg = new frmDocGia();
            frm_dg.ShowDialog();
        }

        private void MenuItem_NhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm_nv = new frmNhanVien();
            frm_nv.ShowDialog();
        }

        private void MenuItem_MuonTra_Click(object sender, EventArgs e)
        {
   
        }

        private void MenuItem_TKDG_Click(object sender, EventArgs e)
        {
            frmTKDocGia frm_tkdg = new frmTKDocGia();
            frm_tkdg.ShowDialog();
        }

        private void MenuItem_TKSach_Click(object sender, EventArgs e)
        {
            frmTKSach frm_tksach = new frmTKSach();
            frm_tksach.ShowDialog();

        }

        private void MenuItem_PM_Click(object sender, EventArgs e)
        {
            frmPhieuMuon frm_pm = new frmPhieuMuon();
            frm_pm.ShowDialog();
        }

        private void MenuItem_CTPM_Click(object sender, EventArgs e)
        {
            frmMuonTra frm_mt = new frmMuonTra();
            frm_mt.ShowDialog();
        }
    }
}
