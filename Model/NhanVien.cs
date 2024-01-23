using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.Model
{
    internal class NhanVien
    {
        private string manv;
        private string tennv;
        private string gioitinh;
        private string diachi;
        private string sdt;
        private string ngaylam;

        public NhanVien(string manv, string tennv, string gioitinh, string diachi, string sdt, string ngaylam)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.ngaylam = ngaylam;
        }

        public void setMaNV(String manv)
        {
            this.manv = manv;
        }
        public String getMaNV()
        {
            return manv;
        }
        public void setTenNV(String tennv)
        {
            this.tennv = tennv;
        }
        public String getTenNV()
        {
            return tennv;
        }
        public void setGioiTinh(String gioitinh)
        {
            this.gioitinh = gioitinh;
        }
        public String getGioiTinh()
        {
            return gioitinh;
        }
        public void setDiaChi(String diachi)
        {
            this.diachi = diachi;
        }
        public String getDiaChi()
        {
            return diachi;
        }
        public void setSDT(String sdt)
        {
            this.sdt = sdt;
        }
        public String getSDT()
        {
            return sdt;
        }
        public void setNgaylam(String ngaylam)
        {
            this.ngaylam = ngaylam;
        }
        public String getNgaylam()
        {
            return ngaylam;
        }

    }
}
