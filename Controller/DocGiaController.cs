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
    internal class DocGiaController
    {
        List<DocGia> docgiaList;
        public DocGiaController()
        {
            docgiaList = new List<DocGia>();
        }
        public List<DocGia> Load()
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                docgiaList.Clear();
                SqlCommand cmd = new SqlCommand("select * from DocGia", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String madg = reader["MaDG"].ToString();
                    String tendg = reader["TenDG"].ToString();
                    String gioitinh = reader["GioiTinh"].ToString();
                    String diachi = reader["DiaChi"].ToString();
                    String lop = reader["Lop"].ToString();
                    String ngaytaothe = reader["NgayTaoThe"].ToString();
                    


                    DocGia docgia = new DocGia(madg, tendg, gioitinh, diachi, lop, ngaytaothe);
                    docgiaList.Add(docgia);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return docgiaList;
        }

        public DocGia get(string madg)
        {
            foreach (DocGia docgia in docgiaList)
            {
                if (docgia.getMaDG() == madg)
                {
                    return docgia;
                }
            }
            return null;
        }

        public bool insert(DocGia docgia)
        {

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO DocGia (MaDG, TenDG, GioiTinh, DiaChi, Lop, NgayTaoThe) VALUES (@MaDG, @TenDG, @GioiTinh, @DiaChi, @Lop, @NgayTaoThe)", conn);
                cmd.Parameters.AddWithValue("@MaDG", docgia.getMaDG());
                cmd.Parameters.AddWithValue("@TenDG", docgia.getTenDG());
                cmd.Parameters.AddWithValue("@GioiTinh", docgia.getGioiTinh());
                cmd.Parameters.AddWithValue("@DiaChi", docgia.getDiaChi());
                cmd.Parameters.AddWithValue("@Lop", docgia.getLop());
                cmd.Parameters.AddWithValue("@NgayTaoThe", docgia.getNgayTaoThe());              

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

        public bool update(DocGia docgia)
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE DocGia SET TenDG = @TenDG, GioiTinh = @GioiTinh, DiaChi = @DiaChi, Lop = @Lop, NgayTaoThe = @NgayTaoThe WHERE MaDG = @MaDG", conn);
                cmd.Parameters.AddWithValue("@MaDG", docgia.getMaDG());
                cmd.Parameters.AddWithValue("@TenDG", docgia.getTenDG());
                cmd.Parameters.AddWithValue("@GioiTinh", docgia.getGioiTinh());
                cmd.Parameters.AddWithValue("@DiaChi", docgia.getDiaChi());
                cmd.Parameters.AddWithValue("@Lop", docgia.getLop());
                cmd.Parameters.AddWithValue("@NgayTaoThe", docgia.getNgayTaoThe());

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
                SqlCommand cmd = new SqlCommand("DELETE FROM DocGia WHERE MaDG = @MaDG", conn);
                cmd.Parameters.AddWithValue("@MaDG", id);

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

        public List<DocGia> Search(string searchValue, string searchCriteria)
        {
            List<DocGia> searchResults = new List<DocGia>();

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();

                string query = "";
                SqlCommand cmd = null;

                if (searchCriteria == "Mã độc giả")
                {
                    query = "SELECT * FROM DocGia WHERE MaDG LIKE @searchValue";
                }
                else if (searchCriteria == "Tên độc giả")
                {
                    query = "SELECT * FROM DocGia WHERE TenDG LIKE @searchValue";
                }

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string madg = reader["MaDG"].ToString();
                    string tendg = reader["TenDG"].ToString();
                    string gioitinh = reader["GioiTinh"].ToString();
                    string diachi = reader["DiaChi"].ToString();
                    string lop = reader["Lop"].ToString();
                    string ngaytaothe = reader["NgayTaoThe"].ToString();
                   

                    DocGia docgia = new DocGia(madg, tendg, gioitinh, diachi, lop, ngaytaothe);
                    searchResults.Add(docgia);
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


    }
}
