using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.Model
{
    internal class PhieuMuon
    {
        private string maphieu;
        private string madg;
        private string manv;

        public PhieuMuon(string maphieu, string madg, string manv)
        {
            this.maphieu = maphieu;
            this.madg = madg;
            this.manv = manv;
        }

        public void setMaPhieu(String maphieu)
        {
            this.maphieu = maphieu;
        }
        public String getMaPhieu()
        {
            return maphieu;
        }
        public void setMaDG(String madg)
        {
            this.madg = madg;
        }
        public String getMaDG()
        {
            return madg;
        }
        public void setMaNV(String manv)
        {
            this.manv = manv;
        }
        public String getMaNV()
        {
            return manv;
        }
    }
}
