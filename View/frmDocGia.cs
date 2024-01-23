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
using QLThuVien.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLThuVien.View
{
    public partial class frmDocGia : Form
    {
        DocGiaController controller;
        List<DocGia> dsDocGia;
        DocGia currentDocGia;
        public frmDocGia()
        {
            InitializeComponent();
            controller = new DocGiaController();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmDocGia_Load(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBoxes trên form.
            string maDG = textBox1.Text;
            string tenDG = textBox2.Text;
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
            string lop = textBox4.Text;
            string ngayTaothe = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            

            // Tạo đối tượng Kho từ thông tin đã lấy.
            DocGia docgia = new DocGia(maDG, tenDG, gioiTinh, diaChi, lop, ngayTaothe);

            // Gọi phương thức Insert của KhoController để thêm kho vào cơ sở dữ liệu.
            DocGiaController controller = new DocGiaController();
            bool result = controller.insert(docgia);
            if (result)
            {
                MessageBox.Show("Thêm độc giả thành công.");
                // Nếu thêm thành công, thêm vào DataGridView để hiển thị dữ liệu mới
                List<DocGia> dsDocGia = controller.Load();
                dataGridView_DG.Rows.Clear();
                foreach (DocGia dg in dsDocGia)
                {
                    string[] row = { dg.getMaDG(), dg.getTenDG(), dg.getGioiTinh(), dg.getDiaChi(), dg.getLop(), dg.getNgayTaoThe()};
                    dataGridView_DG.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Thêm độc giả không thành công.");
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            dsDocGia = new List<DocGia>();
            dsDocGia = controller.Load();
            dataGridView_DG.Rows.Clear();
            foreach (DocGia docgia in dsDocGia)
            {
                string[] row = { docgia.getMaDG(), docgia.getTenDG(), docgia.getGioiTinh(), docgia.getDiaChi(), docgia.getLop(), docgia.getNgayTaoThe() };
                dataGridView_DG.Rows.Add(row);

            }
        }

        private void dataGridView_DG_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_DG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_DG.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView_DG.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells[0].Value?.ToString() ?? string.Empty;
                textBox2.Text = selectedRow.Cells[1].Value?.ToString() ?? string.Empty;

                string gioiTinh = selectedRow.Cells[2].Value?.ToString(); // Lấy giá trị giới tính từ DataGridView

                // Kiểm tra giới tính và thiết lập RadioButton
                if (!string.IsNullOrEmpty(gioiTinh))
                {
                    if (gioiTinh.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else if (gioiTinh.Equals("Nữ", StringComparison.OrdinalIgnoreCase))
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                }

                textBox3.Text = selectedRow.Cells[3].Value?.ToString() ?? string.Empty;
                textBox4.Text = selectedRow.Cells[4].Value?.ToString() ?? string.Empty;

                if (DateTime.TryParse(selectedRow.Cells[5].Value?.ToString(), out DateTime dateValue))
                {
                    dateTimePicker1.Value = dateValue;
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now; // Nếu không thành công, thiết lập mặc định là ngày hiện tại
                }
            }
        }


        private void btn_Edit_Click(object sender, EventArgs e)
        {
            string maDG = textBox1.Text;
            string tenDG = textBox2.Text;
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
            string lop = textBox4.Text;
            string ngayTaothe = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Tạo đối tượng DocGia từ thông tin đã lấy.
            DocGia docgia = new DocGia(maDG, tenDG, gioiTinh, diaChi, lop, ngayTaothe);

            // Gọi phương thức Update của DocGiaController để cập nhật kho trong cơ sở dữ liệu.
            DocGiaController controller = new DocGiaController();
            bool success = controller.update(docgia);

            if (success)
            {
                MessageBox.Show("Cập nhật độc giả thành công.");
                // Nếu cập nhật thành công, thêm vào DataGridView để hiển thị dữ liệu mới
                List<DocGia> dsDocGia = controller.Load();
                dataGridView_DG.Rows.Clear();
                foreach (DocGia dg1 in dsDocGia)
                {
                    string[] row = { dg1.getMaDG(), dg1.getTenDG(), dg1.getGioiTinh(), dg1.getDiaChi(), dg1.getLop(), dg1.getNgayTaoThe() };
                    dataGridView_DG.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Cập nhật độc gỉa không thành công.");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string maDG = textBox1.Text;
            DocGiaController controller = new DocGiaController();
            bool success = controller.delete(maDG);
            MessageBox.Show("Bạn có chắc chắn xóa không!");
            if (success)
            {
                // Nếu xóa thành công, cập nhật DataGridView để hiển thị dữ liệu mới
                List<DocGia> dsDocGia = controller.Load();
                dataGridView_DG.Rows.Clear();
                foreach (DocGia dg2 in dsDocGia)
                {
                    string[] row = { dg2.getMaDG(), dg2.getTenDG(), dg2.getGioiTinh(), dg2.getDiaChi(), dg2.getLop(), dg2.getNgayTaoThe() };
                    dataGridView_DG.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Không thể xóa!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
