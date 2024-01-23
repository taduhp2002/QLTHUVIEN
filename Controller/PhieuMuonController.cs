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
    internal class PhieuMuonController
    {
        List<PhieuMuon> pmList;
        public PhieuMuonController()
        {
            pmList = new List<PhieuMuon>();
        }
        public List<PhieuMuon> Load()
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                pmList.Clear();
                SqlCommand cmd = new SqlCommand("select * from PhieuMuon", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String maphieu = reader["MaPhieu"].ToString();
                    String madg = reader["MaDG"].ToString();                  
                    String manv = reader["MaNV"].ToString();

                    PhieuMuon phieumuon = new PhieuMuon(maphieu, madg, manv);
                    pmList.Add(phieumuon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return pmList;
        }

        public PhieuMuon get(string maphieu)
        {
            foreach (PhieuMuon phieumuon in pmList)
            {
                if (phieumuon.getMaPhieu() == maphieu)
                {
                    return phieumuon;
                }
            }
            return null;
        }

        public bool insert(PhieuMuon phieumuon)
        {

            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO PhieuMuon (MaPhieu, MaDG, MaNV) VALUES (@MaPhieu, @MaDG, @MaNV)", conn);
                cmd.Parameters.AddWithValue("@MaPhieu", phieumuon.getMaPhieu());
                cmd.Parameters.AddWithValue("@MaDG", phieumuon.getMaDG());
                cmd.Parameters.AddWithValue("@MaNV", phieumuon.getMaNV());
                
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

        public bool update(PhieuMuon phieumuon)
        {
            return false;
        }
        public bool delete(String id)
        {
            SqlConnection conn = DataHelper.getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM PhieuMuon WHERE MaPhieu = @MaPhieu", conn);
                cmd.Parameters.AddWithValue("@MaPhieu", id);

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
        public bool delete(PhieuMuon phieumuon) { return false; }

    }
}
