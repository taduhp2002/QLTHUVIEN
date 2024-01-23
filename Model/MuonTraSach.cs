using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.Model
{
    internal class MuonTraSach
    {       
        private string maphieu;
        private string masach;
        private int slmuon;
        private string ngaymuon;
        private string ngaytra;
        private string ghichu;



        public MuonTraSach(string maphieu, string masach, int slmuon, string ngaymuon, string ngaytra, string ghichu)
        {          
            this.maphieu = maphieu;
            this.masach = masach;
            this.slmuon = slmuon;
            this.ngaymuon = ngaymuon;
            this.ngaytra = ngaytra;
            this.ghichu = ghichu;
        }



        public void setMaPhieu(String maphieu)
        {
            this.maphieu = maphieu;
        }
        public String getMaPhieu()
        {
            return maphieu;
        }
        public void setMaSach(String masach)
        {
            this.masach = masach;
        }
        public String getMaSach()
        {
            return masach;
        }
        public void setSLMuon(int slmuon)
        {
            this.slmuon = slmuon;
        }
        public int getSLMuon()
        {
            return slmuon;
        }
        public void setNgayMuon(String ngaymuon)
        {
            this.ngaymuon = ngaymuon;
        }
        public String getNgayMuon()
        {
            return ngaymuon;
        }
        public void setNgayTra(String ngaytra)
        {
            this.ngaytra = ngaytra;
        }
        public String getNgayTra()
        {
            return ngaytra;
        }
        public void setGhiChu(String ghichu)
        {
            this.ghichu = ghichu;
        }
        public String getGhiChu()
        {
            return ghichu;
        }

       
    }
}
