using QLThuVien.Controller;
using QLThuVien.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLThuVien.View
{
    public partial class frmTKSach : Form
    {
        private SachController sachController; // Thêm một thể hiện của SachController

        public frmTKSach()
        {
            InitializeComponent();
            sachController = new SachController(); // Khởi tạo thể hiện của SachController
        }

        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSearch.SelectedItem.ToString() == "Mã sách")
            {
                // Thiết lập TextBox để cho phép tìm kiếm theo Mã sách
                txtSearch.Text = "";
            }
            else if (cbbSearch.SelectedItem.ToString() == "Tên sách")
            {
                // Thiết lập TextBox để cho phép tìm kiếm theo Tên sách
                txtSearch.Text = "";
            }
        }

        private void cbbSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (cbbSearch.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã sách hoặc tên sách để tìm kiếm.");
                return; // Dừng hàm ở đây nếu không có tiêu chí được chọn
            }
            string searchValue = txtSearch.Text;
            string searchCriteria = cbbSearch.SelectedItem.ToString();

            // Gọi phương thức Search từ thể hiện của SachController
            List<Sach> searchResults = sachController.Search(searchValue, searchCriteria);

            // Populate your DataGridView with the search results
            dataGridView_Search.Rows.Clear();
            foreach (Sach sach in searchResults)
            {
                dataGridView_Search.Rows.Add(sach.GetMaSach(), sach.GetTenSach(), sach.GetTheLoai(), sach.GetTacGia(), sach.GetNXB(), sach.GetNgayXB(), sach.GetSoLuong());
            }
            if (searchResults.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả nào.");
            }
            else
            {
                MessageBox.Show("Tìm thấy " + searchResults.Count + " kết quả.");
            }
        }

        private void dataGridView_Search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTKSach_Load(object sender, EventArgs e)
        {

        }
    }
}
