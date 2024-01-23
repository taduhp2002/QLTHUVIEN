using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.Model
{
    internal class DocGia
    {
        private string madg;
        private string tendg;
        private string gioitinh;
        private string diachi;
        private string lop;
        private string ngaytaothe;

       
        public DocGia(string madg, string tendg, string gioitinh, string diachi, string lop, string ngaytaothe)
        {
            this.madg = madg;
            this.tendg = tendg;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.lop = lop;
            this.ngaytaothe = ngaytaothe;
        }

        public void setMaDG(String madg)
        {
            this.madg = madg;
        }
        public String getMaDG()
        {
            return madg;
        }
        public void setTenDG(String tendg)
        {
            this.tendg = tendg;
        }
        public String getTenDG()
        {
            return tendg;
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
        public void setLop(String lop)
        {
            this.lop = lop;
        }
        public String getLop()
        {
            return lop;
        }
        public void setNgayTaoThe(String ngaytaothe)
        {
            this.ngaytaothe = ngaytaothe;
        }
        public String getNgayTaoThe()
        {
            return ngaytaothe;
        }
    }
}
