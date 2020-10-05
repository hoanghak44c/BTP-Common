using System;

namespace QLBH.Common.Objects
{
    public class BienBanBG
    {
        public BienBanBG()
        {
            
        }
        public BienBanBG(string sohoadon, string sobienban, string tenkh, string diachi, string daidien, string diachigh, 
                        string kho, string nguoibg, DateTime ngaymua, string dienthoai, string email, string mst, string noimua)
        {
            this.SoHoaDon = sohoadon;
            this.SoBienBan = sobienban;
            this.HoTenKH = tenkh;
            this.DiaChiKH = diachi;
            this.NguoiDaiDien = daidien;
            this.DiaChiGiaoHang = diachigh;
            this.KhoBan = kho;
            this.NguoiBanGiao = nguoibg;
            this.NgayMua = ngaymua;
            this.DienThoai = dienthoai;
            this.Email = email;
            this.MaSoThue = mst;
            this.NoiMua = noimua;
        }

        string _soHoaDon;
        public string SoHoaDon
        {
            get { return _soHoaDon; }
            set { _soHoaDon = value; }
        }

        string _soBienBan;
        public string SoBienBan
        {
            get { return _soBienBan; }
            set { _soBienBan = value; }
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

        string _nguoiDaiDien;
        public string NguoiDaiDien
        {
            get { return _nguoiDaiDien; }
            set { _nguoiDaiDien = value; }
        }

        string _diaChiGiaoHang;
        public string DiaChiGiaoHang
        {
            get { return _diaChiGiaoHang; }
            set { _diaChiGiaoHang = value; }
        }

        string _nguoiBanGiao;
        public string NguoiBanGiao
        {
            get { return _nguoiBanGiao; }
            set { _nguoiBanGiao = value; }
        }

        string _khoBan;
        public string KhoBan
        {
            get { return _khoBan; }
            set { _khoBan = value; }
        }

        string _noiMua;
        public string NoiMua
        {
            get { return _noiMua; }
            set { _noiMua = value; }
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

        string _maSoThue;
        public string MaSoThue
        {
            get { return _maSoThue; }
            set { _maSoThue = value; }
        }

        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }



    }
}
