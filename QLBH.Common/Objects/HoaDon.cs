using System;

namespace QLBH.Common.Objects
{
    public class HoaDon
    {
        public HoaDon()
        {
            
        }
        public HoaDon(int id, int quyenso, string soct, string soseri, DateTime ngaylap, string trungtam, string kho, string dckho, string dtkho, string nhanvien,
                        string tenkh, int gioitinh, int dotuoi, string dckh, string dtkh, string mstkh, int ordertype, int billto, int shipto, double tienhang, double tienck,
                        double tylevat, double tienvat, double tientt, string tiente, string hinhthuctt, int hinhthuctra, string ghichu)
        {
            this._idChungTu = id;
            this._quyenSo = quyenso;
            this._soChungTu = soct;
            this._soSeri = soseri;
            this._ngayLap = ngaylap;
            this._trungTam = trungtam;
            this._khoXuat = kho;
            this._diaChiKho = dckho;
            this._dienThoaiKho = dtkho;
            this._nhanVien = nhanvien;
            this._tenKhachHang = tenkh;
            this._gioiTinh = gioitinh;
            this._doTuoi = dotuoi;
            this._diaChiKH = dckh;
            this._dienThoaiKH = dtkh;
            this._maSoThueKH = mstkh;
            this._orderType = ordertype;
            this._billTo = billto;
            this._shipTo = shipto;
            this._tongTienHang = tienhang;
            this._tongTienCK = tienck;
            this._tyLeVAT = tylevat;
            this._tongTienVAT = tienvat;
            this._tongTienThanhToan = tientt;
            this._tienTe = tiente;
            this._hinhThucTT = hinhthuctt;
            this._hinhThucTra = hinhthuctra;
            this._ghiChu = ghichu;
        }
        int _idChungTu;
        public int IdChungTu
        {
            get { return _idChungTu; }
            set { _idChungTu = value; }
        }

        int _quyenSo;
        public int QuyenSo
        {
            get { return _quyenSo; }
            set { _quyenSo = value; }
        }
        string _soChungTu;
        public string SoChungTu
        {
            get { return _soChungTu; }
            set { _soChungTu = value; }
        }

        string _soSeri;
        public string SoSeri
        {
            get { return _soSeri; }
            set { _soSeri = value; }
        }

        DateTime _ngayLap;
        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
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

        int _gioiTinh;
        public int GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }

        int _doTuoi;
        public int DoTuoi
        {
            get { return _doTuoi; }
            set { _doTuoi = value; }
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

        int _orderType;
        public int OrderType
        {
            get { return _orderType; }
            set { _orderType = value; }
        }

        int _billTo;
        public int BillTo
        {
            get { return _billTo; }
            set { _billTo = value; }
        }

        int _shipTo;
        public int ShipTo
        {
            get { return _shipTo; }
            set { _shipTo = value; }
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

        double _tyLeVAT;
        public double TyLeVAT
        {
            get { return _tyLeVAT; }
            set { _tyLeVAT = value; }
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

        int _hinhThucTra;
        public int HinhThucTra
        {
            get { return _hinhThucTra; }
            set { _hinhThucTra = value; }
        }

        string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
    }
}
