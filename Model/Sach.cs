using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien.Model
{
    internal class Sach
    {
        private string masach;
        private string tensach;
        private string theloai;
        private string tacgia;
        private string nxb;
        private string ngayxb;
        private int soluong;

        public Sach()
        {
        }

        public Sach(string masach, string tensach, string theloai, string tacgia, string nxb, string ngayxb, int soluong)
        {
            this.masach = masach;
            this.tensach = tensach;
            this.theloai = theloai;
            this.tacgia = tacgia;
            this.nxb = nxb;
            this.ngayxb = ngayxb;
            this.soluong = soluong;


        }

        public string GetMaSach()
        {
            return masach;
        }

        public void SetMaSach(string masach)
        {
            this.masach = masach;
        }

        public string GetTenSach()
        {
            return tensach;
        }

        public void SetTenSach(string tensach)
        {
            this.tensach = tensach;
        }

        public string GetTheLoai()
        {
            return theloai;
        }

        public void SetTheLoai(string theloai)
        {
            this.theloai = theloai;
        } 
        public string GetTacGia()
        {
            return tacgia;
        }

        public void SetTacGia(string tacgia)
        {
            this.tacgia = tacgia;
        }
        public string GetNXB()
        {
            return nxb;
        }

        public void SetNXB(string nxb)
        {
            this.nxb = nxb;
        } 
        public string GetNgayXB()
        {
            return ngayxb;
        }

        public void SetNgayXB(string ngayxb)
        {
            this.ngayxb = ngayxb;
        }
        public int GetSoLuong()
        {
            return soluong;
        }

        public void SetSoLuong(int soluong)
        {
            this.soluong = soluong;
        }


    }
}
