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
    internal class NhanVienController
    {
        List<NhanVien> nvList;
        public NhanVienController()
        {
            nvList = new List<NhanVien>();
        }
        public List<NhanVien> Load()
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                nvList.Clear();
                SqlCommand cmd = new SqlCommand("select * from NhanVien", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String manv = reader["MaNV"].ToString();
                    String tennv = reader["TenNV"].ToString();
                    String gioitinh = reader["GioiTinh"].ToString();
                    String diachi = reader["DiaChi"].ToString();
                    String sdt = reader["SDT"].ToString();
                    String ngaylam = reader["NgayLam"].ToString();



                    NhanVien nhanvien = new NhanVien(manv, tennv, gioitinh, diachi, sdt, ngaylam);
                    nvList.Add(nhanvien);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return nvList;
        }

        public NhanVien get(string manv)
        {
            foreach (NhanVien nhanvien in nvList)
            {
                if (nhanvien.getMaNV() == manv)
                {
                    return nhanvien;
                }
            }
            return null;
        }

        public bool insert(NhanVien nhanvien)
        {

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, DiaChi, SDT, NgayLam) VALUES (@MaNV, @TenNv, @GioiTinh, @DiaChi, @SDT, @NgayLam)", conn);
                cmd.Parameters.AddWithValue("@MaNV", nhanvien.getMaNV());
                cmd.Parameters.AddWithValue("@tenNV", nhanvien.getTenNV());
                cmd.Parameters.AddWithValue("@GioiTinh", nhanvien.getGioiTinh());
                cmd.Parameters.AddWithValue("@DiaChi", nhanvien.getDiaChi());
                cmd.Parameters.AddWithValue("@SDT", nhanvien.getSDT());
                cmd.Parameters.AddWithValue("@NgayLam", nhanvien.getNgaylam());

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

        public bool update(NhanVien nhanvien)
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT = @SDT, NgayLam = @NgayLam WHERE MaNV = @MaNV", conn);               
                cmd.Parameters.AddWithValue("@MaNV", nhanvien.getMaNV());
                cmd.Parameters.AddWithValue("@tenNV", nhanvien.getTenNV());
                cmd.Parameters.AddWithValue("@GioiTinh", nhanvien.getGioiTinh());
                cmd.Parameters.AddWithValue("@DiaChi", nhanvien.getDiaChi());
                cmd.Parameters.AddWithValue("@SDT", nhanvien.getSDT());
                cmd.Parameters.AddWithValue("@NgayLam", nhanvien.getNgaylam());

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
                SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", id);

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
        public bool delete(NhanVien nhanvien) { return false; }

        
    }
}
