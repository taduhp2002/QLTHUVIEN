using QLThuVien.Model;
using QLThuVien.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien.Controller
{
    internal class SachController
    {
        List<Sach> sachList;
        public SachController()
        {
            sachList = new List<Sach>();
        }
        public List<Sach> Load()
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                sachList.Clear();
                SqlCommand cmd = new SqlCommand("select * from Sach", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String masach = reader["MaSach"].ToString();
                    String tensach = reader["TenSach"].ToString();
                    String theloai = reader["TheLoai"].ToString();
                    String tacgia = reader["TacGia"].ToString();
                    String nxb = reader["NXB"].ToString();
                    String ngayxb = reader["NgayXB"].ToString();
                    int soluong = int.Parse(reader["SoLuong"].ToString());


                    Sach sach = new Sach(masach, tensach, theloai, tacgia, nxb, ngayxb, soluong);
                    sachList.Add(sach);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sachList;
        }

        public Sach get(string masach)
        {
            foreach (Sach sach in sachList)
            {
                if (sach.GetMaSach() == masach)
                {
                    return sach;
                }
            }
            return null;
        }

        public bool insert(Sach sach)
        {

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Sach (MaSach, TenSach, TheLoai, TacGia, NXB, NgayXB, SoLuong) VALUES (@MaSach, @TenSach, @TheLoai, @TacGia, @NXB, @NgayXB, @SoLuong)", conn);
                cmd.Parameters.AddWithValue("@MaSach", sach.GetMaSach());
                cmd.Parameters.AddWithValue("@TenSach", sach.GetTenSach());
                cmd.Parameters.AddWithValue("@TheLoai", sach.GetTheLoai());
                cmd.Parameters.AddWithValue("@TacGia", sach.GetTacGia());
                cmd.Parameters.AddWithValue("@NXB", sach.GetNXB());
                cmd.Parameters.AddWithValue("@NgayXB", sach.GetNgayXB());
                cmd.Parameters.AddWithValue("@SoLuong", sach.GetSoLuong());


                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }

        }

        public bool update(Sach sach)
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Sach SET TenSach = @TenSach, TheLoai = @TheLoai, TacGia = @TacGia, NXB = @NXB, NgayXB = @NgayXB, SoLuong = @SoLuong WHERE MaSach = @MaSach", conn);
                cmd.Parameters.AddWithValue("@MaSach", sach.GetMaSach());
                cmd.Parameters.AddWithValue("@TenSach", sach.GetTenSach());
                cmd.Parameters.AddWithValue("@TheLoai", sach.GetTheLoai());
                cmd.Parameters.AddWithValue("@TacGia", sach.GetTacGia());
                cmd.Parameters.AddWithValue("@NXB", sach.GetNXB());
                cmd.Parameters.AddWithValue("@NgayXB", sach.GetNgayXB());
                cmd.Parameters.AddWithValue("@SoLuong", sach.GetSoLuong());

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool delete(String id)
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Sach WHERE MaSach = @MaSach", conn);
                cmd.Parameters.AddWithValue("@MaSach", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool delete(Sach sach) { return false; }

        public List<Sach> Search(string searchValue, string searchCriteria)
        {
            List<Sach> searchResults = new List<Sach>();

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();

                string query = "";
                SqlCommand cmd = null;

                if (searchCriteria == "Mã sách")
                {
                    query = "SELECT * FROM Sach WHERE MaSach LIKE @searchValue";
                }
                else if (searchCriteria == "Tên sách")
                {
                    query = "SELECT * FROM Sach WHERE TenSach LIKE @searchValue";
                }

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string masach = reader["MaSach"].ToString();
                    string tensach = reader["TenSach"].ToString();
                    string theloai = reader["TheLoai"].ToString();
                    string tacgia = reader["TacGia"].ToString();
                    string nxb = reader["NXB"].ToString();
                    string ngayxb = reader["NgayXB"].ToString();
                    int soluong = int.Parse(reader["SoLuong"].ToString());

                    Sach sach = new Sach(masach, tensach, theloai, tacgia, nxb, ngayxb, soluong);
                    searchResults.Add(sach);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return searchResults;
        }


        internal List<Sach> load()
        {
            throw new NotImplementedException();
        }

        internal List<Sach> loadSach()
        {
            throw new NotImplementedException();
        }
    }
}
