using System;

namespace QLBH.Common.Objects
{
    public class PhieuXuat
    {
        public PhieuXuat()
        {
            
        }
        public PhieuXuat(int idpx, string sopx, DateTime ngayxuat, string trungtam, string kho, string dckho, string dtkho, string nhanvien,
                        string tenkh, string dckh, string dtkh, string mstkh, double tienhang, double tienck,
                        double tienvat, double tientt, double tientra, double tienno, string tiente, string hinhthuctt, string ghichu)
        {
            this._idPhieuXuat = idpx;
            this._soPhieuXuat = sopx;
            this._ngayXuat = ngayxuat;
            this._trungTam = trungtam;
            this._khoXuat = kho;
            this._diaChiKho = dckho;
            this._dienThoaiKho = dtkho;
            this._nhanVien = nhanvien;
            this._tenKhachHang = tenkh;
            this._diaChiKH = dckh;
            this._dienThoaiKH = dtkh;
            this._maSoThueKH = mstkh;
            this._tongTienHang = tienhang;
            this._tongTienCK = tienck;
            this._tongTienVAT = tienvat;
            this._tongTienThanhToan = tientt;
            this._tienThucTra = tientra;
            this._tienConNo = tienno;
            this._tienTe = tiente;
            this._hinhThucTT = hinhthuctt;
            this._ghiChu = ghichu;
        }

        public PhieuXuat(int idpx, string sopx, DateTime ngayxuat, string trungtam, string kho, string dckho, string dtkho, string nhanvien,
                        string tenkh, string dckh, string dtkh, string mstkh, double tienhang, double tienck,
                        double tienvat, double tientt, double tientra, double tienno, string tiente, string hinhthuctt, string ghichu, string thoihantt, string sotk, string nghang)
        {
            this._idPhieuXuat = idpx;
            this._soPhieuXuat = sopx;
            this._ngayXuat = ngayxuat;
            this._trungTam = trungtam;
            this._khoXuat = kho;
            this._diaChiKho = dckho;
            this._dienThoaiKho = dtkho;
            this._nhanVien = nhanvien;
            this._tenKhachHang = tenkh;
            this._diaChiKH = dckh;
            this._dienThoaiKH = dtkh;
            this._maSoThueKH = mstkh;
            this._tongTienHang = tienhang;
            this._tongTienCK = tienck;
            this._tongTienVAT = tienvat;
            this._tongTienThanhToan = tientt;
            this._tienThucTra = tientra;
            this._tienConNo = tienno;
            this._tienTe = tiente;
            this._hinhThucTT = hinhthuctt;
            this._ghiChu = ghichu;
            this._thoiHanTT = thoihantt;
            this._soTaiKhoan = sotk;
            this._nganHang = nghang;
        }
        public PhieuXuat(int idpx, string sopx, string kho, string tenkh)
        {
            this._idPhieuXuat = idpx;
            this._soPhieuXuat = sopx;
            this._khoXuat = kho;
            this._tenKhachHang = tenkh;
        }
        int _idPhieuXuat;
        public int IdPhieuXuat
        {
            get { return _idPhieuXuat; }
            set { _idPhieuXuat = value; }
        }

        string _soPhieuXuat;
        public string SoPhieuXuat
        {
            get { return _soPhieuXuat; }
            set { _soPhieuXuat = value; }
        }

        DateTime _ngayXuat;
        public DateTime NgayXuat
        {
            get { return _ngayXuat; }
            set { _ngayXuat = value; }
        }

        string _trungTam;
        public string TrungTam
        {
            get { return _trungTam; }
            set { _trungTam = value; }
        }

        string _khoXuat;
        public string KhoXuat
        {
            get { return _khoXuat; }
            set { _khoXuat = value; }
        }
        string _diaChiKho;
        public string DiaChiKho
        {
            get { return _diaChiKho; }
            set { _diaChiKho = value; }
        }

        string _dienThoaiKho;
        public string DienThoaiKho
        {
            get { return _dienThoaiKho; }
            set { _dienThoaiKho = value; }
        }

        string _nhanVien;
        public string NhanVien
        {
            get { return _nhanVien; }
            set { _nhanVien = value; }
        }

        string _tenKhachHang;
        public string TenKhachHang
        {
            get { return _tenKhachHang; }
            set { _tenKhachHang = value; }
        }

        string _diaChiKH;
        public string DiaChiKH
        {
            get { return _diaChiKH; }
            set { _diaChiKH = value; }
        }

        string _dienThoaiKH;
        public string DienThoaiKH
        {
            get { return _dienThoaiKH; }
            set { _dienThoaiKH = value; }
        }

        string _maSoThueKH;
        public string MaSoThueKH
        {
            get { return _maSoThueKH; }
            set { _maSoThueKH = value; }
        }

        double _tongTienHang;
        public double TongTienHang
        {
            get { return _tongTienHang; }
            set { _tongTienHang = value; }
        }

        double _tongTienCK;
        public double TongTienCK
        {
            get { return _tongTienCK; }
            set { _tongTienCK = value; }
        }

        double _tongTienVAT;
        public double TongTienVAT
        {
            get { return _tongTienVAT; }
            set { _tongTienVAT = value; }
        }

        double _tongTienThanhToan;
        public double TongTienThanhToan
        {
            get { return _tongTienThanhToan; }
            set { _tongTienThanhToan = value; }
        }

        double _tienThucTra;
        public double TienThucTra
        {
            get { return _tienThucTra; }
            set { _tienThucTra = value; }
        }

        double _tienConNo;
        public double TienConNo
        {
            get { return _tienConNo; }
            set { _tienConNo = value; }
        }

        string _tienTe;
        public string TienTe
        {
            get { return _tienTe; }
            set { _tienTe = value; }
        }

        string _hinhThucTT;
        public string HinhThucTT
        {
            get { return _hinhThucTT; }
            set { _hinhThucTT = value; }
        }

        string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

        string _thoiHanTT;
        public string ThoiHanTT
        {
            get { return _thoiHanTT; }
            set { _thoiHanTT = value; }
        }

        string _soTaiKhoan;
        public string SoTaiKhoan
        {
            get { return _soTaiKhoan; }
            set { _soTaiKhoan = value; }
        }

        string _nganHang;
        public string NganHang
        {
            get { return _nganHang; }
            set { _nganHang = value; }
        }
    }
}
