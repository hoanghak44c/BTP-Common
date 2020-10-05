namespace QLBH.Common.Objects
{
    public class TrungTamItem
    {
        bool _suDung;
        public bool SuDung
        {
            get { return _suDung; }
            set { _suDung = value; }
        }

        string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

        string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        
        string _dienThoai;
        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }

        string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        string _tenTrungTam;
        public string TenTrungTam
        {
            get { return _tenTrungTam; }
            set { _tenTrungTam = value; }
        }

        string _maTrungTam;
        public string MaTrungTam
        {
            get { return _maTrungTam; }
            set { _maTrungTam = value; }
        }

        int _idTrungTam;
        public int IdTrungTam
        {
            get { return _idTrungTam; }
            set { _idTrungTam = value; }
        }
    }
}
