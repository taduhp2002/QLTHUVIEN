using QLThuVien.Model;
using QLThuVien.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien.Controller
{
    internal class MuonTraController
    {
        List<MuonTraSach> mtList;
        public MuonTraController()
        {
            mtList = new List<MuonTraSach>();
        }

        public List<MuonTraSach> Load()
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                mtList.Clear();
                SqlCommand cmd = new SqlCommand("select * from CTPM", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {                   
                    String maphieu = reader["MaPhieu"].ToString();
                    String masach = reader["MaSach"].ToString();
                    int slmuon = int.Parse(reader["SLMuon"].ToString());
                    String ngaymuon = reader["NgayMuon"].ToString();
                    String ngaytra = reader["NgayTra"].ToString();
                    String ghichu = reader["GhiChu"].ToString();

                    MuonTraSach mtsach = new MuonTraSach(maphieu, masach, slmuon, ngaymuon, ngaytra, ghichu);
                    mtList.Add(mtsach);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return mtList;
        }

        public MuonTraSach get(string maphieu)
        {
            foreach (MuonTraSach mts in mtList)
            {
                if (mts.getMaPhieu() == maphieu)
                {
                    return mts;
                }
            }
            return null;
        }

        public bool insert(MuonTraSach mtsach)
        {

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CTPM (MaPhieu, MaSach, SLMuon, NgayMuon, NgayTra, GhiChu) VALUES (@MaPhieu, @MaSach, @SLMuon, @NgayMuon, @NgayTra, @GhiChu)", conn);
                cmd.Parameters.AddWithValue("@MaPhieu", mtsach.getMaPhieu());
                cmd.Parameters.AddWithValue("@MaSach", mtsach.getMaSach());
                cmd.Parameters.AddWithValue("@SLMuon", mtsach.getSLMuon());
                cmd.Parameters.AddWithValue("@NgayMuon", mtsach.getNgayMuon());
                cmd.Parameters.AddWithValue("@NgayTra", mtsach.getNgayTra());
                cmd.Parameters.AddWithValue("@GhiChu", mtsach.getGhiChu());

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

        public bool update(MuonTraSach mtsach)
        {
            return false;
        }
        public bool delete(string id)
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CTPM WHERE MaSach = @MaSach", conn);
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
        public bool delete(NhanVien nhanvien) { return false; }
    }
}
