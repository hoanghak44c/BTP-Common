namespace QLBH.Common.Objects
{
    public class ChiTietKKHangHoa
    {
        public ChiTietKKHangHoa()
        {

        }

        public ChiTietKKHangHoa(int idhanghoa, int soluong, int soLuongTT, string ghichu)
        {
            this._idHangHoa = idhanghoa;
            this._soLuong = soluong;
            this._soLuongSoSach = soLuongTT;
            this._ghiChu = ghichu;
        }

        int _idHangHoa;
        public int IdHangHoa
        {
            get { return _idHangHoa; }
            set { _idHangHoa = value; }
        }

        int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        int _soLuongSoSach;
        public int SoLuongSoSach
        {
            get { return _soLuongSoSach; }
            set { _soLuongSoSach = value; }
        }

        string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
    }

}
