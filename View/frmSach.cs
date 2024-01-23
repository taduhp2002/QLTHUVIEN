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
    public partial class frmSach : Form
    {
        SachController controller;
        List<Sach> dsSach;
        Sach currentSach;
        public frmSach()
        {
            InitializeComponent();
            controller = new SachController();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBoxes trên form.
            string maSach = textBox1.Text;
            string tenSach = textBox2.Text;
            string theLoai = textBox3.Text;
            string tacGia = textBox4.Text;
            string nxb = textBox5.Text;
            string ngayXB = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int soLuong = int.Parse(textBox6.Text);



            // Tạo đối tượng Kho từ thông tin đã lấy.
            Sach sach = new Sach(maSach, tenSach, theLoai, tacGia, nxb, ngayXB, soLuong);

            // Gọi phương thức Insert của KhoController để thêm kho vào cơ sở dữ liệu.
            SachController controller = new SachController();
            bool result = controller.insert(sach);
            if (result)
            {
                MessageBox.Show("Thêm sách thành công.");
                // Nếu thêm thành công, thêm vào DataGridView để hiển thị dữ liệu mới
                List<Sach> dsSach = controller.Load();
                dataGridView_Sach.Rows.Clear();
                foreach (Sach sach1 in dsSach)
                {
                    string[] row = { sach1.GetMaSach(), sach1.GetTenSach(), sach1.GetTheLoai(), sach1.GetTacGia(), sach1.GetNXB(), sach1.GetNgayXB(), sach1.GetSoLuong().ToString() };
                    dataGridView_Sach.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Thêm sách không thành công.");
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string maSach = textBox1.Text;
            string tenSach = textBox2.Text;
            string theLoai = textBox3.Text;
            string tacGia = textBox4.Text;
            string nxb = textBox5.Text;
            string ngayXB = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int soLuong = int.Parse(textBox6.Text);

            // Tạo đối tượng HangHoa từ thông tin đã lấy.
            Sach sach = new Sach(maSach, tenSach, theLoai, tacGia, nxb, ngayXB, soLuong);

            // Gọi phương thức Update của HangHoaController để cập nhật kho trong cơ sở dữ liệu.
            SachController controller = new SachController();
            bool success = controller.update(sach);

            if (success)
            {
                MessageBox.Show("Cập nhật sách thành công.");
                // Nếu cập nhật thành công, thêm vào DataGridView để hiển thị dữ liệu mới
                List<Sach> dsSach = controller.Load();
                dataGridView_Sach.Rows.Clear();
                foreach (Sach sach2 in dsSach)
                {
                    string[] row = { sach2.GetMaSach(), sach2.GetTenSach(), sach2.GetTheLoai(), sach2.GetTacGia(), sach2.GetNXB(), sach2.GetNgayXB(), sach2.GetSoLuong().ToString() };
                    dataGridView_Sach.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Cập nhật sách không thành công.");
            }
            
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string maSach = textBox1.Text;
            SachController controller = new SachController();
            bool success = controller.delete(maSach);
            MessageBox.Show("Bạn có chắc chắn xóa không!");
            if (success)
            {
                // Nếu xóa thành công, cập nhật DataGridView để hiển thị dữ liệu mới
                List<Sach> dsSach = controller.Load();
                dataGridView_Sach.Rows.Clear();
                foreach (Sach sach3 in dsSach)
                {
                    string[] row = { sach3.GetMaSach(), sach3.GetTenSach(), sach3.GetTheLoai(), sach3   .GetTacGia(), sach3.GetNXB(), sach3.GetNgayXB(), sach3  .GetSoLuong().ToString() };
                    dataGridView_Sach.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Không thể xóa!");
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            dsSach = new List<Sach>();
            dsSach = controller.Load();
            dataGridView_Sach.Rows.Clear();
            foreach (Sach sach in dsSach)
            {
                string[] row = { sach.GetMaSach(), sach.GetTenSach(), sach.GetTheLoai(), sach.GetTacGia(), sach.GetNXB(), sach.GetNgayXB(), sach.GetSoLuong().ToString() };
                dataGridView_Sach.Rows.Add(row);

            }
        }

        private void dataGridView_Sach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView_Sach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_Sach.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView_Sach.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty; // Mã sách
                textBox2.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty; // Tên sách
                textBox3.Text = selectedRow.Cells[2].Value?.ToString() ?? string.Empty; // Thể loại
                textBox4.Text = selectedRow.Cells[3].Value?.ToString() ?? string.Empty; // Tác giả
                textBox5.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty; // NXB

                // Ngày XB - Kiểm tra giá trị không null và có thể chuyển đổi thành DateTime
                if (DateTime.TryParse(selectedRow.Cells[5].Value?.ToString(), out DateTime dateValue))
                {
                    dateTimePicker1.Value = dateValue;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now; // Nếu không thành công, thiết lập mặc định là ngày hiện tại
                }

                textBox6.Text = selectedRow.Cells[6].Value?.ToString() ?? string.Empty; // Số lượng
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmSach_Load(object sender, EventArgs e)
        {

        }
    }
}
