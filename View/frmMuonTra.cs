using QLThuVien.Controller;
using QLThuVien.Model;
using QLThuVien.Utils;
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
    public partial class frmMuonTra : Form
    {
        MuonTraController controller;
        List<MuonTraSach> dsMuonTra;
        public frmMuonTra()
        {
            InitializeComponent();
            controller = new MuonTraController();
            LoadMaPhieuDataIntoComboBox();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            dsMuonTra = new List<MuonTraSach>();
            dsMuonTra = controller.Load();
            dataGridView_MT.Rows.Clear();

            foreach (MuonTraSach mts in dsMuonTra)
            {

                string[] row1 = { mts.getMaPhieu(), mts.getMaSach(), mts.getSLMuon().ToString(), mts.getNgayMuon(), mts.getNgayTra(), mts.getGhiChu() };
                dataGridView_MT.Rows.Add(row1);
            }
        }

        private void btn_Muon_Click(object sender, EventArgs e)
        {
            if (dataGridView_MT.CurrentRow != null) // Kiểm tra xem có hàng nào được chọn không
            {
                
                // Lấy giá trị từ cột ComboBox trong hàng mới của DataGridView
                DataGridViewComboBoxCell comboBoxCell = (DataGridViewComboBoxCell)dataGridView_MT.CurrentRow.Cells["Column1"];
                string maPhieu = comboBoxCell.Value?.ToString(); // Sử dụng ?. để tránh lỗi nếu giá trị là null

                string maSach = cbb_MaSach.SelectedItem.ToString();
                int slMuon = int.Parse(txt_SLMuon.Text);
                string ngayMuon = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string ngayTra = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                string ghiChu = txt_Ghichu.Text;

                // Tạo đối tượng MuonTra từ thông tin đã lấy
                MuonTraSach mtsach = new MuonTraSach(maPhieu, maSach, slMuon, ngayMuon, ngayTra, ghiChu);

                // Gọi phương thức Insert để thêm phieumuon vào cơ sở dữ liệu
                bool result1 = controller.insert(mtsach);
                if (result1)
                {
                    MessageBox.Show("Mượn sách thành công.");

                    List<MuonTraSach> dsMuonTra = controller.Load();
                    dataGridView_MT.Rows.Clear();
                    foreach (MuonTraSach mts1 in dsMuonTra)
                    {

                        string[] row = { mts1.getMaPhieu(), mts1.getMaSach(), mts1.getSLMuon().ToString(), mts1.getNgayMuon(), mts1.getNgayTra(), mts1.getGhiChu() };
                        dataGridView_MT.Rows.Add(row);
                    }

                }
                else
                {
                    MessageBox.Show("Mượn sách không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để mượn sách.");
            }
        }

        private void cbb_maphieu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void cbb_MaSach_Click(object sender, EventArgs e)
        {
            cbb_MaSach.Items.Clear(); // Xóa các mục hiện tại trong ComboBox

            // Truy vấn SQL để lấy danh sách mã độc giả
            string query = "SELECT MaSach FROM Sach";
            using (SqlConnection conn = DataHelper.getConnection()) // Tạo và sử dụng một kết nối mới
            {
                conn.Open(); // Mở kết nối

                using (SqlCommand cmd = new SqlCommand(query, conn)) // Sử dụng kết nối
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maSach = reader["MaSach"].ToString();
                            cbb_MaSach.Items.Add(maSach); // Thêm mã độc giả vào ComboBox
                        }
                    }
                }
            }
        }
        private void LoadMaPhieuDataIntoComboBox()
        {
            // Lấy DataGridViewComboBoxColumn tương ứng trong DataGridView của bạn
            DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)dataGridView_MT.Columns["Column1"];

            // Lấy danh sách mã phiếu từ CSDL và gán vào ComboBoxColumn
            List<string> maPhieuList = new List<string>();
            string query = "SELECT MaPhieu FROM PhieuMuon";
            using (SqlConnection conn = DataHelper.getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maPhieu = reader["MaPhieu"].ToString();
                            maPhieuList.Add(maPhieu);
                        }
                    }
                }
            }

            // Gán danh sách mã phiếu vào ComboBoxColumn
            comboBoxColumn.DataSource = maPhieuList;
        }


    
    private void dataGridView_MT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbb_maphieu_Click(object sender, EventArgs e)
        {

        }

        private void btn_Tra_Click(object sender, EventArgs e)
        {
            // Check if any item is selected in the ComboBox
            if (cbb_MaSach.SelectedItem != null)
            {
                string maSach = cbb_MaSach.SelectedItem.ToString();
                MuonTraController controller = new MuonTraController();
                bool success = controller.delete(maSach);

                MessageBox.Show("Xác nhận trả sách!");

                if (success)
                {
                    MessageBox.Show("Trả sách thành công!");
                    // If deletion is successful, update the DataGridView to display the new data
                    List<MuonTraSach> dsMuonTra = controller.Load();
                    dataGridView_MT.Rows.Clear();

                    foreach (MuonTraSach mt1 in dsMuonTra)
                    {
                        string[] row = { mt1.getMaPhieu(), mt1.getMaSach(), mt1.getSLMuon().ToString(), mt1.getNgayMuon(), mt1.getNgayTra(), mt1.getGhiChu() };
                        dataGridView_MT.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("Trả sách thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mã sách trước khi trả!");
            }
        }


        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_MT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_MT.Rows.Count) // Kiểm tra hàng được chọn có hợp lệ hay không
            {
                DataGridViewRow selectedRow = dataGridView_MT.Rows[e.RowIndex];

                // Kiểm tra giá trị của ô có tồn tại hay không trước khi truy cập
                if (selectedRow.Cells[1].Value != null)
                {
                    cbb_MaSach.SelectedItem = selectedRow.Cells[1].Value.ToString();
                }

                if (selectedRow.Cells[2].Value != null)
                {
                    txt_SLMuon.Text = selectedRow.Cells[2].Value.ToString();
                }

                if (selectedRow.Cells[3].Value != null && DateTime.TryParse(selectedRow.Cells[3].Value.ToString(), out DateTime dateValue1))
                {
                    dateTimePicker1.Value = dateValue1;
                }

                if (selectedRow.Cells[4].Value != null && DateTime.TryParse(selectedRow.Cells[4].Value.ToString(), out DateTime dateValue2))
                {
                    dateTimePicker2.Value = dateValue2;
                }

                if (selectedRow.Cells[5].Value != null)
                {
                    txt_Ghichu.Text = selectedRow.Cells[5].Value.ToString();
                }
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
