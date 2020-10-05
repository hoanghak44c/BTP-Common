namespace QLBH.Common.Objects
{
    public class ChiTietHangHoa
    {
        public ChiTietHangHoa()
        {

        }

        public ChiTietHangHoa(int idhanghoa, int soluong, double tienck, double tienvat, double thuongnong, string ghichu)
        {
            this._idHangHoa = idhanghoa;
            this._soLuong = soluong;
            this._tienChietKhau = tienck;
            this._tienVAT = tienvat;
            this._thuongNong = thuongnong;
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

        double _tienChietKhau;
        public double TienChietKhau
        {
            get { return _tienChietKhau; }
            set { _tienChietKhau = value; }
        }

        double _tienVAT;
        public double TienVAT
        {
            get { return _tienVAT; }
            set { _tienVAT = value; }
        }

        double _thuongNong;
        public double ThuongNong
        {
            get { return _thuongNong; }
            set { _thuongNong = value; }
        }

        string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
    }

}
