using System;

namespace QLBH.Common.Objects
{
    public class PhieuBaoHanh
    {
        public PhieuBaoHanh()
        {
            
        }
        public PhieuBaoHanh(string sophieu, string makh, string tenkh, DateTime ngaymua, string diachi, string dienthoai, string email, string noimua)
        {
            this.SoPhieu = sophieu;
            this.MaKhachHang = makh;
            this.HoTenKH = tenkh;
            this.NgayMua = ngaymua;
            this.DiaChiKH = diachi;
            this.DienThoai = dienthoai;
            this.Email = email;
            this.NoiMua = noimua;
        }

        public PhieuBaoHanh(int idphieu, string sophieu, string makh, string tenkh, DateTime ngaymua, string diachi, string dienthoai, string email, string noimua)
        {
            this.IdPhieuXuat = idphieu;
            this.SoPhieu = sophieu;
            this.MaKhachHang = makh;
            this.HoTenKH = tenkh;
            this.NgayMua = ngaymua;
            this.DiaChiKH = diachi;
            this.DienThoai = dienthoai;
            this.Email = email;
            this.NoiMua = noimua;
        }

        int _idPhieuXuat;
        public int IdPhieuXuat
        {
            get { return _idPhieuXuat; }
            set { _idPhieuXuat = value; }
        }

        string _soPhieu;
        public string SoPhieu
        {
            get { return _soPhieu; }
            set { _soPhieu = value; }
        }

        string _maKhachHang;
        public string MaKhachHang
        {
            get { return _maKhachHang; }
            set { _maKhachHang = value; }
        }
        string _hoTenKH;
        public string HoTenKH
        {
            get { return _hoTenKH; }
            set { _hoTenKH = value; }
        }

        string _diaChiKH;
        public string DiaChiKH
        {
            get { return _diaChiKH; }
            set { _diaChiKH = value; }
        }

        DateTime _ngayMua;
        public DateTime NgayMua
        {
            get { return _ngayMua; }
            set { _ngayMua = value; }
        }

        string _dienThoai;
        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }

        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        string _noiMua;
        public string NoiMua
        {
            get { return _noiMua; }
            set { _noiMua = value; }
        }
    }
}
