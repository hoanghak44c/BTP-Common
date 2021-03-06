using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace QLBH.Common.Objects
{
    public class ChiTietKhuyenMai
    {
        #region Khai bao thuoc tinh
        int _idSanPham;
        string _maSanPham;
        string _tenSanPham;
        string _donViTinh;
        int _soLuong;
        double _tienKM;
        int _thayDoi = 0;//1: Them, 2: Sua, 3: Xoa
        int _idChiTiet;
        #endregion

        #region Khai bao phương thức
        public int IdSanPham
        {
            get { return _idSanPham; }
            set { _idSanPham = value; }
        }
        public string MaSanPham
        {
            get { return _maSanPham; }
            set { _maSanPham = value; }
        }
        public string TenSanPham
        {
            get { return _tenSanPham; }
            set { _tenSanPham = value; }
        }
        public string DonViTinh
        {
            get { return _donViTinh; }
            set { _donViTinh = value; }
        }
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        public double TienKM
        {
            get { return _tienKM; }
            set { _tienKM = value; }
        }
        public int ThayDoi
        {
            get { return _thayDoi; }
            set { _thayDoi = value; }
        }
        public int IdChiTiet
        {
            get { return _idChiTiet; }
            set { _idChiTiet = value; }
        }
        

        #endregion
    }
    public class KhuyenMai
    {
        #region Khai bao thuoc tinh
        int _idKhuyenMai;
        int _idChiTietBangGia;
        string _soKhuyenMai;
        string _moTa;
        int _idChiTiet;
        List<ChiTietKhuyenMai> _lstSanPham=new List<ChiTietKhuyenMai>();
        #endregion
        #region Khai bao phương thức get, set
        public int IdKhuyenMai
        {
            get { return _idKhuyenMai; }
            set { _idKhuyenMai = value; }
        }
        public int IdChiTietBangGia
        {
            get { return _idChiTietBangGia; }
            set { _idChiTietBangGia = value; }
        }
        public string SoKhuyenMai
        {
            get { return _soKhuyenMai; }
            set { _soKhuyenMai = value; }
        }
        public string MoTa
        {
            get { return _moTa; }
            set { _moTa = value; }
        }
        public int IdChiTiet
        {
            get { return _idChiTiet; }
            set { _idChiTiet = value; }
        }
        public List<ChiTietKhuyenMai> LstSanPham
        {
            get { return _lstSanPham; }
            set { _lstSanPham = value; }
        }
        #endregion
        Utils ut = new Utils();
        public bool getKhuyenMai(int pIDKhuyenMai)
        {
            DataTable dt = ut.getDataTable("SELECT * FROM tbl_KhuyenMai WHERE IdKhuyenMai=" + pIDKhuyenMai.ToString());
            if (dt.Rows.Count <= 0) return false;
            DataRow r = dt.Rows[0];
            _idChiTiet = ut.getInt(r["IdChiTietBangGia"]);
            _idKhuyenMai = ut.getInt(r["IdKhuyenMai"]);
            _soKhuyenMai = ut.getString(r["SoKhuyenMai"]);
            _moTa = ut.getString(r["GhiChu"]);
            DataTable dt1 = ut.getDataTable(@"SELECT     dbo.tbl_KhuyenMai_Chitiet.IdChiTiet, dbo.tbl_SanPham.IdSanPham, dbo.tbl_SanPham.MaSanPham, dbo.tbl_SanPham.TenSanPham, 
                      dbo.tbl_DM_DonViTinh.TenDonViTinh, dbo.tbl_KhuyenMai_Chitiet.SoLuong, dbo.tbl_KhuyenMai_Chitiet.SoTien
FROM         dbo.tbl_DM_DonViTinh INNER JOIN
                      dbo.tbl_SanPham ON dbo.tbl_DM_DonViTinh.IdDonViTinh = dbo.tbl_SanPham.IdDonViTinh RIGHT OUTER JOIN
                      dbo.tbl_KhuyenMai_Chitiet ON dbo.tbl_SanPham.IdSanPham = dbo.tbl_KhuyenMai_Chitiet.IdSanPham
                                                WHERE IdKhuyenMai=" + pIDKhuyenMai.ToString());
            foreach (DataRow r1 in dt1.Rows)
            {
                AddSanPham(ut.getInt(r1["IdSanPham"]), ut.getString(r1["MaSanPham"]), ut.getString(r1["TenSanPham"]), ut.getString(r1["TenDonViTinh"]), ut.getInt(r1["SoLuong"]), ut.getDouble(r1["SoTien"]));
            } 
            
            return true;
        }
        public void AddSanPham(int pIdSanPham, string pMaSanPham, string pTenSanPham, string pDonViTinh, int pSoLuong, double pTienKM)
        {
            ChiTietKhuyenMai ct = new ChiTietKhuyenMai();
            ct.IdSanPham = pIdSanPham;
            ct.MaSanPham = pMaSanPham;
            ct.TenSanPham = pTenSanPham;
            ct.DonViTinh = pDonViTinh;
            ct.SoLuong = pSoLuong;
            ct.TienKM = pTienKM;
            ct.IdChiTiet = 0;
            _lstSanPham.Add(ct);
        }
        public List<KhuyenMai> getListKhuyenMai(int pIdChiTietBangGia)
        {
            DataTable dt1;
            DataTable dt = ut.getDataTable("SELECT * FROM tbl_KhuyenMai WHERE IdChiTietBangGia=" + pIdChiTietBangGia.ToString());
            KhuyenMai KM;
            ChiTietKhuyenMai ct;
            List<KhuyenMai> lst=new List<KhuyenMai>();
            foreach (DataRow r in dt.Rows)
            {
                KM = new KhuyenMai();
                KM.getKhuyenMai(ut.getInt(r["IdKhuyenMai"]));
                
                lst.Add(KM);
            }
            return lst;
        }
        public void AddNew()
        {
            string lstField, lstValue, sql;
            lstField = ""; lstValue = "";
            ut.CreateStrInsert(ref lstField, ref lstValue, "SoKhuyenMai", _soKhuyenMai.ToString(), true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "IdChiTietBangGia", _idChiTietBangGia.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "GhiChu",_moTa, true);
            
            sql = string.Format("INSERT INTO tbl_KhuyenMai({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
            sql += ";select @@Identity";
            int ID = ut.ExecuteSQL(sql);
            if (ID != 0)
            {
                _idKhuyenMai = ID;
                //Chen cac muc trong lst vao tbl_KhuyenMai_ChiTiet

                foreach (ChiTietKhuyenMai r in _lstSanPham)
                {
                    if (r.IdSanPham > 0 || ut.getDouble(r.TienKM)>0)
                    {
                        lstField = ""; lstValue = "";
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdKhuyenMai", _idKhuyenMai.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdSanPham", r.IdSanPham.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "SoLuong", r.SoLuong.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "SoTien", r.TienKM.ToString(new CultureInfo("en-US")), false);
                        sql = string.Format("INSERT INTO tbl_KhuyenMai_ChiTiet({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
                        ut.ExecuteSQL(sql);
                    }
                }
            }
        }
        public void Update()
        {
            string lstField,lstValue,stUpdate,sql;
                        
            stUpdate = "";
            ut.CreateStrUpdate(ref stUpdate, "SoKhuyenMai", _soKhuyenMai, true);
            ut.CreateStrUpdate(ref stUpdate, "IdChiTietBangGia", _idChiTietBangGia.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "GhiChu", _moTa, true);
            sql = "UPDATE tbl_KhuyenMai SET " + stUpdate.Trim(',') + " WHERE IdKhuyenMai=" + _idKhuyenMai.ToString();
            ut.ExecuteSQL(sql);
            ////Chen cac muc trong lst vao tbl_KhuyenMai_ChiTiet
            //foreach (ChiTietKhuyenMai r in _lstSanPham)
            //{
            //    if (r.ThayDoi==2)
            //    {
            //        stUpdate = "";
            //        ut.CreateStrUpdate(ref stUpdate, "IdKhuyenMai", _idKhuyenMai.ToString(), false);
            //        ut.CreateStrUpdate(ref stUpdate, "IdSanPham", r.IdSanPham.ToString(), false);
            //        ut.CreateStrUpdate(ref stUpdate, "SoLuong", r.SoLuong.ToString(), false);
            //        ut.CreateStrUpdate(ref stUpdate, "SoTien", r.TienKM.ToString(), false);
            //        sql = "UPDATE tbl_KhuyenMai_ChiTiet SET " + stUpdate.Trim(',') + " WHERE IdChiTiet=" + r.IdChiTiet.ToString();
            //        ut.ExecuteSQL(sql);
            //    }
            //}
            //Xoa cac muc trong lst vao tbl_KhuyenMai_ChiTiet
            sql = string.Format("DELETE FROM tbl_KhuyenMai_ChiTiet Where IdKhuyenMai=" + _idKhuyenMai.ToString());
            ut.ExecuteSQL(sql);
            //Chen cac muc trong lst vao tbl_KhuyenMai_ChiTiet
            foreach (ChiTietKhuyenMai r in _lstSanPham)
            {
                if (r.IdSanPham > 0 || ut.getDouble(r.TienKM) > 0)
                {
                    lstField = ""; lstValue = "";
                    ut.CreateStrInsert(ref lstField, ref lstValue, "IdKhuyenMai", _idKhuyenMai.ToString(), false);
                    ut.CreateStrInsert(ref lstField, ref lstValue, "IdSanPham", r.IdSanPham.ToString(), false);
                    ut.CreateStrInsert(ref lstField, ref lstValue, "SoLuong", r.SoLuong.ToString(), false);
                    ut.CreateStrInsert(ref lstField, ref lstValue, "SoTien", r.TienKM.ToString(), false);
                    sql = string.Format("INSERT INTO tbl_KhuyenMai_ChiTiet({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
                    ut.ExecuteSQL(sql);
                }
            }
        }
        public void DeleteAllKhuyenMai(int pIdChiTietBangGia)
        {
            DataTable dt=ut.getDataTable("SELECT * FROM tbl_KhuyenMai WHERE IdChiTietBangGia=" + pIdChiTietBangGia.ToString());
            foreach (DataRow r in dt.Rows)
                Delete(ut.getInt(r["IdKhuyenMai"]));
        }
        public void Delete(int pIdKhuyenMai)
        {
            string sql = @"DELETE FROM tbl_KhuyenMai_Chitiet WHERE IdKhuyenMai=" + pIdKhuyenMai.ToString();
            ut.ExecuteSQL(sql);
            sql = @"DELETE FROM tbl_KhuyenMai WHERE IdKhuyenMai=" + pIdKhuyenMai.ToString();
            ut.ExecuteSQL(sql);
        }
    }
}
