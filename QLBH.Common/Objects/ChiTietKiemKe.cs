using System.Collections.Generic;

namespace QLBH.Common.Objects
{
    public class ChiTietKiemKe
    {
        public ChiTietKiemKe()
        {
            DsHangHoa = new List<ChiTietKKHangHoa>();
        }

        public ChiTietKiemKe(int idsanpham, int idsanphamban, int soluong, int nguoitao, List<ChiTietKKHangHoa> hh)
        {
            this._idSanPham = idsanpham;
            this._soLuong = soluong;
            this._nguoiTao = nguoitao;
            this._dsHangHoa = hh;
        }

        int _idSanPham;
        public int IdSanPham
        {
            get { return _idSanPham; }
            set { _idSanPham = value; }
        }

        int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        int _nguoiTao;
        public int NguoiTao
        {
            get { return _nguoiTao; }
            set { _nguoiTao = value; }
        }

        List<ChiTietKKHangHoa> _dsHangHoa;
        public List<ChiTietKKHangHoa> DsHangHoa
        {
            get { return _dsHangHoa; }
            set { _dsHangHoa = value; }
        }
    }
}
