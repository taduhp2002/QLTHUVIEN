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
    public partial class frmTKDocGia : Form
    {
        private DocGiaController docgiaController; // Thêm một thể hiện của SachController

        public frmTKDocGia()
        {
            InitializeComponent();
            docgiaController = new DocGiaController(); // Khởi tạo thể hiện của SachController
        }

        private void cbb_searchdg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_searchdg.SelectedItem.ToString() == "Mã độc giả")
            {
                // Thiết lập TextBox để cho phép tìm kiếm theo Mã sách
                txt_Searchdg.Text = "";
            }
            else if (cbb_searchdg.SelectedItem.ToString() == "Tên độc giả")
            {
                // Thiết lập TextBox để cho phép tìm kiếm theo Tên sách
                txt_Searchdg.Text = "";
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (cbb_searchdg.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã độc giả hoặc tên độc giả để tìm kiếm.");
                return; // Dừng hàm ở đây nếu không có tiêu chí được chọn
            }

            string searchValue = txt_Searchdg.Text;
            string searchCriteria = cbb_searchdg.SelectedItem.ToString();

            // Gọi phương thức Search từ thể hiện của SachController
            List<DocGia> searchResults = docgiaController.Search(searchValue, searchCriteria);
            
            // Populate your DataGridView with the search results
            dataGridView_searchdg.Rows.Clear();
            foreach (DocGia dg in searchResults)
            {
                dataGridView_searchdg.Rows.Add(dg.getMaDG(), dg.getTenDG(), dg.getGioiTinh(), dg.getDiaChi(), dg.getLop(), dg.getNgayTaoThe());
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
