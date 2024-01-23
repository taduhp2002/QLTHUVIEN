using QLThuVien.Controller;
using QLThuVien.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien.View
{
    public partial class frmNhanVien : Form
    {
        NhanVienController controller;
        List<NhanVien> dsNhanVien;
        NhanVien currentNhanVien;
        public frmNhanVien()
        {
            InitializeComponent();
            controller = new NhanVienController();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string maNV = textBox1.Text;
            string tenNV = textBox2.Text;
            string gioiTinh = "";

            if (radioButton1.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (radioButton2.Checked)
            {
                gioiTinh = "Nữ";
            }
            string diaChi = textBox3.Text;
            string sdt = textBox4.Text;
            string ngayLam = dateTimePicker1.Value.ToString("yyyy-MM-dd");


            // Tạo đối tượng Kho từ thông tin đã lấy.
            NhanVien nhanvien = new NhanVien(maNV, tenNV, gioiTinh, diaChi, sdt, ngayLam);

            // Gọi phương thức Insert của KhoController để thêm kho vào cơ sở dữ liệu.
            NhanVienController controller = new NhanVienController();
            bool result = controller.insert(nhanvien);
            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                // Nếu thêm thành công, thêm vào DataGridView để hiển thị dữ liệu mới
                List<NhanVien> dsNhanVien = controller.Load();
                dataGridView_NV.Rows.Clear();
                foreach (NhanVien nv in dsNhanVien)
                {
                    string[] row = { nv.getMaNV(), nv.getTenNV(), nv.getGioiTinh(), nv.getDiaChi(), nv.getSDT(), nv.getNgaylam() };
                    dataGridView_NV.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công.");
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string maNV = textBox1.Text;
            string tenNV = textBox2.Text;
            string gioiTinh = "";

            if (radioButton1.Checked)
            {
                gioiTinh = "Nam";
            }
            else if (radioButton2.Checked)
            {
                gioiTinh = "Nữ";
            }
            string diaChi = textBox3.Text;
            string sdt = textBox4.Text;
            string ngayLam = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Tạo đối tượng DocGia từ thông tin đã lấy.
            NhanVien nhanvien = new NhanVien(maNV, tenNV, gioiTinh, diaChi, sdt, ngayLam);

            // Gọi phương thức Update của NhanVienController để cập nhật kho trong cơ sở dữ liệu.
            NhanVienController controller = new NhanVienController();
            bool success = controller.update(nhanvien);

            if (success)
            {
                MessageBox.Show("Cập nhật nhân viên thành công.");
                // Nếu cập nhật thành công, thêm vào DataGridView để hiển thị dữ liệu mới
                List<NhanVien> dsNhanVien = controller.Load();
                dataGridView_NV.Rows.Clear();
                foreach (NhanVien nv1 in dsNhanVien)
                {
                    string[] row = { nv1.getMaNV(), nv1.getTenNV(), nv1.getGioiTinh(), nv1.getDiaChi(), nv1.getSDT(), nv1.getNgaylam() };
                    dataGridView_NV.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Cập nhật độc gỉa không thành công.");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string maNV = textBox1.Text;
            NhanVienController controller = new NhanVienController();
            bool success = controller.delete(maNV);
            MessageBox.Show("Bạn có chắc chắn xóa không!");
            if (success)
            {
                // Nếu xóa thành công, cập nhật DataGridView để hiển thị dữ liệu mới
                List<NhanVien> dsNhanVien = controller.Load();
                dataGridView_NV.Rows.Clear();
                foreach (NhanVien nv2 in dsNhanVien)
                {
                    string[] row = { nv2.getMaNV(), nv2.getTenNV(), nv2.getGioiTinh(), nv2.getDiaChi(), nv2.getSDT(), nv2.getNgaylam() };
                    dataGridView_NV.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Không thể xóa!");
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            dsNhanVien = new List<NhanVien>();
            dsNhanVien = controller.Load();
            dataGridView_NV.Rows.Clear();
            foreach (NhanVien nhanvien in dsNhanVien)
            {
                string[] row = { nhanvien.getMaNV(), nhanvien.getTenNV(), nhanvien.getGioiTinh(), nhanvien.getDiaChi(), nhanvien.getSDT(), nhanvien.getNgaylam() };
                dataGridView_NV.Rows.Add(row);

            }
        }

        private void dataGridView_NV_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_NV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_NV.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView_NV.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells[0].Value?.ToString();
                textBox2.Text = selectedRow.Cells[1].Value?.ToString();
                string gioiTinh = selectedRow.Cells[2].Value?.ToString(); // Lấy giá trị giới tính từ DataGridView

                // Kiểm tra và hiển thị giới tính lên RadioButton
                if (gioiTinh != null)
                {
                    if (gioiTinh.Equals("Nam", StringComparison.OrdinalIgnoreCase)) // Kiểm tra giới tính, không phân biệt hoa thường
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else if (gioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase)) // Kiểm tra giới tính, không phân biệt hoa thường
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    else // Nếu giá trị không phải là "Nam" hoặc "Nữ"
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }
                }
                else // Nếu giá trị null
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }

                textBox3.Text = selectedRow.Cells[3].Value?.ToString();
                textBox4.Text = selectedRow.Cells[4].Value?.ToString();

                if (DateTime.TryParse(selectedRow.Cells[5].Value?.ToString(), out DateTime dateValue))
                {
                    dateTimePicker1.Value = dateValue;
                }
            }
        }



        private void dataGridView_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
