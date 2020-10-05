using System.Collections.Generic;

namespace QLBH.Common.Objects
{
    public class ChiTietPhieuXuat
    {
        public ChiTietPhieuXuat()
        {
            DsHangHoa = new List<ChiTietHangHoa>();
        }

        public ChiTietPhieuXuat(int idsanpham, int idsanphamban, int soluong, double dongia, 
                                double tyleck, double tienck, double tylevat, double tienvat, double tylethuong,double thuongnong, 
                                List<ChiTietHangHoa> hh)
        {
            this._idSanPham = idsanpham;
            this._idSanPhamBan = idsanphamban;
            this._soLuong = soluong;
            this._donGia = dongia;
            this._tyLeChietKhau = tyleck;
            this._tienChietKhau = tienck;
            this._tyLeVAT = tylevat;
            this._tienVAT = tienvat;
            this._tyLeThuong = tylethuong;
            this._thuongNong = thuongnong;
            this._dsHangHoa = hh;
        }

        int _idSanPham;
        public int IdSanPham
        {
            get { return _idSanPham; }
            set { _idSanPham = value; }
        }

        int _idSanPhamBan;
        public int IdSanPhamBan
        {
            get { return _idSanPhamBan; }
            set { _idSanPhamBan = value; }
        }

        int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        double _donGia;
        public double DonGia
        {
            get { return _donGia; }
            set { _donGia = value; }
        }

        double _tyLeChietKhau;
        public double TyLeChietKhau
        {
            get { return _tyLeChietKhau; }
            set { _tyLeChietKhau = value; }
        }

        double _tienChietKhau;
        public double TienChietKhau
        {
            get { return _tienChietKhau; }
            set { _tienChietKhau = value; }
        }

        double _tyLeVAT;
        public double TyLeVAT
        {
            get { return _tyLeVAT; }
            set { _tyLeVAT = value; }
        }

        double _tienVAT;
        public double TienVAT
        {
            get { return _tienVAT; }
            set { _tienVAT = value; }
        }

        double _tyLeThuong;
        public double TyLeThuong
        {
            get { return _tyLeThuong; }
            set { _tyLeThuong = value; }
        }

        double _thuongNong;
        public double ThuongNong
        {
            get { return _thuongNong; }
            set { _thuongNong = value; }
        }

        double _giaTheoBangGia;
        public double GiaTheoBangGia
        {
            get { return _giaTheoBangGia; }
            set { _giaTheoBangGia = value; }
        }

        string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }      
        List<ChiTietHangHoa> _dsHangHoa;
        public List<ChiTietHangHoa> DsHangHoa
        {
            get { return _dsHangHoa; }
            set { _dsHangHoa = value; }
        }
    }
}
