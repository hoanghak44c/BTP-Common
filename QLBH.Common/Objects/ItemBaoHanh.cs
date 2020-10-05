using System;

namespace QLBH.Common.Objects
{
    public class ItemBaoHanh
    {


        public ItemBaoHanh()
        {
            
        }
        public ItemBaoHanh(int IdItem, string SoPhieu, string Serial_No, int IdKho, int IdDoiTuong, string MaSanPham, string TenSanPham, int IdLoaiItem, int IdLoaiDichVu, int HinhThucSua,
                        DateTime NgayNhan, DateTime NgayHenTra, string ChuanDoanBanDau, string MatKhauMay, string MatKhauWindow, string KetLuanLoi, DateTime NgayKetThuc, DateTime NgayTra, double ChiPhiKiemTra, double ChiPhiSuaChua, int IdTrangThai,
                        int IdNhanVienNhan, int IdNhanvienSua, string GhiChuNhanMay, string GhiChuSuaMay, string KhachHangDanhGia, int DiemDanhGia)
        {
            this._idItem = IdItem;
            this._soPhieu = SoPhieu;
            this._serial_No = Serial_No;
            this._idKho = IdKho;
            this._idDoiTuong = IdDoiTuong;
            this._maSanPham = MaSanPham;
            this._tenSanPham = TenSanPham;
            this._idLoaiItem = IdLoaiItem;
            this._idLoaiDichVu = IdLoaiDichVu;
            this._hinhThucSua = HinhThucSua;
            this._ngayNhan = NgayNhan;
            this._ngayHenTra = NgayHenTra;
            this._chuanDoanBanDau = ChuanDoanBanDau;
            this._matKhauMay = MatKhauMay;
            this._matKhauWindow = MatKhauWindow;
            this._ketLuanLoi = KetLuanLoi;
            this._ngayKetThuc = NgayKetThuc;
            this._ngayTra = NgayTra;
            this._chiPhiKiemTra = ChiPhiKiemTra;
            this._chiPhiSuaChua = ChiPhiSuaChua;
            this._idTrangThai = IdTrangThai;
            this._idNhanVienNhan = IdNhanVienNhan;
            this._idNhanvienSua = IdNhanvienSua;
            this._ghiChuNhanMay = GhiChuNhanMay;
            this._ghiChuSuaMay = GhiChuSuaMay;
            this._khachHangDanhGia = KhachHangDanhGia;
            this._diemDanhGia = DiemDanhGia;            
        }
        int _idItem;
        public int IdItem
        {
            get { return _idItem; }
            set { _idItem = value; }
        }

        string _soPhieu;
        public string SoPhieu
        {
            get { return _soPhieu; }
            set { _soPhieu = value; }
        }
        
        string _serial_No;
        public string Serial_No
        {
            get { return _serial_No; }
            set { _serial_No = value; }
        }

        int _idKho = -1;
        public int IdKho
        {
            get { return _idKho; }
            set { _idKho = value; }
        }

        int _idDoiTuong;
        public int IdDoiTuong
        {
            get { return _idDoiTuong; }
            set { _idDoiTuong = value; }
        }

        string _maSanPham;
        public string MaSanPham
        {
            get { return _maSanPham; }
            set { _maSanPham = value; }
        }

        string _tenSanPham;
        public string TenSanPham
        {
            get { return _tenSanPham; }
            set { _tenSanPham = value; }
        }

        int _idLoaiItem;
        public int IdLoaiItem
        {
            get { return _idLoaiItem; }
            set { _idLoaiItem = value; }
        }

        int _idLoaiDichVu;
        public int IdLoaiDichVu
        {
            get { return _idLoaiDichVu; }
            set { _idLoaiDichVu = value; }
        }

        int _hinhThucSua;
        public int HinhThucSua
        {
            get { return _hinhThucSua; }
            set { _hinhThucSua = value; }
        }

        DateTime _ngayNhan;
        public DateTime NgayNhan
        {
            get { return _ngayNhan; }
            set { _ngayNhan = value; }
        }

        DateTime _ngayHenTra;
        public DateTime NgayHenTra
        {
            get { return _ngayHenTra; }
            set { _ngayHenTra = value; }
        }

        string _chuanDoanBanDau;
        public string ChuanDoanBanDau
        {
            get { return _chuanDoanBanDau; }
            set { _chuanDoanBanDau = value; }
        }

        string _matKhauMay;
        public string MatKhauMay
        {
            get { return _matKhauMay; }
            set { _matKhauMay = value; }
        }

        string _matKhauWindow;
        public string MatKhauWindow
        {
            get { return _matKhauWindow; }
            set { _matKhauWindow = value; }
        }

        string _ketLuanLoi;
        public string KetLuanLoi
        {
            get { return _ketLuanLoi; }
            set { _ketLuanLoi = value; }
        }

        DateTime _ngayKetThuc;
        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set { _ngayKetThuc = value; }
        }

        DateTime _ngayTra;
        public DateTime NgayTra
        {
            get { return _ngayTra; }
            set { _ngayTra = value; }
        }

        double _chiPhiKiemTra;
        public double ChiPhiKiemTra
        {
            get { return _chiPhiKiemTra; }
            set { _chiPhiKiemTra = value; }
        }

        double _chiPhiSuaChua;
        public double ChiPhiSuaChua
        {
            get { return _chiPhiSuaChua; }
            set { _chiPhiSuaChua = value; }
        }

        int _idTrangThai;
        public int IdTrangThai
        {
            get { return _idTrangThai; }
            set { _idTrangThai = value; }
        }

        int _idNhanVienNhan;
        public int IdNhanVienNhan
        {
            get { return _idNhanVienNhan; }
            set { _idNhanVienNhan = value; }
        }

        int _idNhanvienSua;
        public int IdNhanvienSua
        {
            get { return _idNhanvienSua; }
            set { _idNhanvienSua = value; }
        }

        string _ghiChuNhanMay;
        public string GhiChuNhanMay
        {
            get { return _ghiChuNhanMay; }
            set { _ghiChuNhanMay = value; }
        }

        string _ghiChuSuaMay;
        public string GhiChuSuaMay
        {
            get { return _ghiChuSuaMay; }
            set { _ghiChuSuaMay = value; }
        }

        string _khachHangDanhGia;
        public string KhachHangDanhGia
        {
            get { return _khachHangDanhGia; }
            set { _khachHangDanhGia = value; }
        }

        int _diemDanhGia;
        public int DiemDanhGia
        {
            get { return _diemDanhGia; }
            set { _diemDanhGia = value; }
        }       
    }
}
