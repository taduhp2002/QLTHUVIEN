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

namespace QLThuVien.View
{
    public partial class frmPhieuMuon : Form
    {
        PhieuMuonController controller;
        List<PhieuMuon> dsPhieuMuon;
        public frmPhieuMuon()
        {
            InitializeComponent();
            controller = new PhieuMuonController();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private bool IsMaPhieuExisted(string maPhieu)
        {
            string query = "SELECT COUNT(*) FROM PhieuMuon WHERE MaPhieu = @MaPhieu";
            using (SqlConnection conn = DataHelper.getConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Trả về true nếu MaPhieu đã tồn tại
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Nhận mã phiếu từ TextBox
            string maPhieu = textBox1.Text;
            if (IsMaPhieuExisted(maPhieu))
            {
                MessageBox.Show("Mã phiếu đã tồn tại. Vui lòng nhập mã phiếu khác.");
                return;
            }
            // Kiểm tra xem ComboBox đã được chọn hay chưa
            if (cbb_MaDG.SelectedIndex < 0 || cbb_MaNV.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mã độc giả và mã nhân viên.");
                return;
            }

            // Nhận mã độc giả và mã nhân viên từ ComboBox
            string maDG = cbb_MaDG.SelectedItem.ToString();
            string maNV = cbb_MaNV.SelectedItem.ToString();

            // Tạo đối tượng PhieuMuon từ thông tin đã lấy
            PhieuMuon phieumuon = new PhieuMuon(maPhieu, maDG, maNV);

            // Gọi phương thức Insert để thêm phieumuon vào cơ sở dữ liệu
            bool result = controller.insert(phieumuon);
            if (result)
            {
                MessageBox.Show("Tạo phiếu mượn thành công. Bây giờ có thể mượn sách!");

                // Thêm dòng mới vào DataGridView
                List<PhieuMuon> dsPhieuMuon = controller.Load();
                dataGridView_PM.Rows.Clear();
                foreach (PhieuMuon pm in dsPhieuMuon)
                {
                    string[] row = { pm.getMaPhieu(), pm.getMaDG(), pm.getMaNV() };
                    dataGridView_PM.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Tạo phiếu mượn không thành công.");
            }
        }

        private void cbb_MaDG_Click(object sender, EventArgs e)
        {
            cbb_MaDG.Items.Clear(); // Xóa các mục hiện tại trong ComboBox

            // Truy vấn SQL để lấy danh sách mã độc giả
            string query = "SELECT MaDG FROM DocGia";
            using (SqlConnection conn = DataHelper.getConnection()) // Tạo và sử dụng một kết nối mới
            {
                conn.Open(); // Mở kết nối

                using (SqlCommand cmd = new SqlCommand(query, conn)) // Sử dụng kết nối
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maDG = reader["MaDG"].ToString();
                            cbb_MaDG.Items.Add(maDG); // Thêm mã độc giả vào ComboBox
                        }
                    }
                }
            }
        }

        private void cbb_MaNV_Click(object sender, EventArgs e)
        {
            cbb_MaNV.Items.Clear(); // Xóa các mục hiện tại trong ComboBox

            // Truy vấn SQL để lấy danh sách mã độc giả
            string query = "SELECT MaNV FROM NhanVien";
            using (SqlConnection conn = DataHelper.getConnection()) // Tạo và sử dụng một kết nối mới
            {
                conn.Open(); // Mở kết nối

                using (SqlCommand cmd = new SqlCommand(query, conn)) // Sử dụng kết nối
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maNV = reader["MaNV"].ToString();
                            cbb_MaNV.Items.Add(maNV); // Thêm mã độc giả vào ComboBox
                        }
                    }
                }
            }
        }

        private void dataGridView_PM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_PM.Rows.Count) // Kiểm tra hàng được chọn có hợp lệ hay không
            {
                DataGridViewRow selectedRow = dataGridView_PM.Rows[e.RowIndex];

                // Kiểm tra giá trị của ô có tồn tại hay không trước khi truy cập
                if (selectedRow.Cells[0].Value != null)
                {
                    textBox1.Text = selectedRow.Cells[0].Value.ToString();
                }

                // Kiểm tra giá trị của các ô và gán giá trị cho ComboBox
                string maDG = selectedRow.Cells[1].Value?.ToString(); // Sử dụng ?. để kiểm tra giá trị null
                string maNV = selectedRow.Cells[2].Value?.ToString(); // Sử dụng ?. để kiểm tra giá trị null

                // Chọn giá trị tương ứng trong ComboBox nếu giá trị không null
                if (!string.IsNullOrEmpty(maDG))
                {
                    cbb_MaDG.SelectedItem = maDG;
                }

                if (!string.IsNullOrEmpty(maNV))
                {
                    cbb_MaNV.SelectedItem = maNV;
                }
            }
        }


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string maPhieu = textBox1.Text;
            PhieuMuonController controller = new PhieuMuonController();
            bool success = controller.delete(maPhieu);
            MessageBox.Show("Bạn có chắc chắn xóa không!");
            if (success)
            {
                // Nếu xóa thành công, cập nhật DataGridView để hiển thị dữ liệu mới
                List<PhieuMuon> dsPhieuMuon = controller.Load();
                dataGridView_PM.Rows.Clear();
                foreach (PhieuMuon pm1 in dsPhieuMuon)
                {
                    string[] row = { pm1.getMaPhieu(), pm1.getMaDG(), pm1.getMaNV() };
                    dataGridView_PM.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Không thể xóa!");
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            dsPhieuMuon = new List<PhieuMuon>();
            dsPhieuMuon = controller.Load();
            dataGridView_PM.Rows.Clear();
            foreach (PhieuMuon pm2 in dsPhieuMuon)
            {
                string[] row = { pm2.getMaPhieu(), pm2.getMaDG(), pm2.getMaNV() };
                dataGridView_PM.Rows.Add(row);

            }
        }
    }
}
