using System;
using System.Collections.Generic;
using System.Data;

namespace QLBH.Common.Objects
{
    public class ChiTietChamCong
    {
        #region Khai bao thuoc tinh
        int _idChiTiet;
        int _idNhanVien;
        string _maNhanVien;
        string _tenNhanVien;
        bool _diLam;
        DateTime _thoiGian;
        string _ghiChu;
        int _thayDoi=0;//1:Them, 2: Sua, 3: Xoa.
        #endregion

        #region Khai bao phương thức
        public int IdChiTiet
        {
            get { return _idChiTiet; }
            set { _idChiTiet = value; }
        }
        public int IdNhanVien
        {
            get { return _idNhanVien; }
            set { _idNhanVien = value; }
        }
        public string MaNhanVien
        {
            get { return _maNhanVien; }
            set { _maNhanVien = value; }
        }
        public string TenNhanVien
        {
            get { return _tenNhanVien; }
            set { _tenNhanVien = value; }
        }
        public bool DiLam
        {
            get { return _diLam; }
            set { _diLam = value; }
        }
        public DateTime ThoiGian
        {
            get { return _thoiGian; }
            set { _thoiGian = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        
        public int ThayDoi
        {
            get { return _thayDoi; }
            set { _thayDoi = value; }
        }
        #endregion

    }

    public class ChamCong
    {
        #region Khai bao thuoc tinh
        int _idChamCong;
        int _idKho;
        DateTime _ngayLamViec;
        string _idNguoiCham;

        List<ChiTietChamCong> _lstChamCong = new List<ChiTietChamCong>();
        #endregion

        #region Khai bao phương thức get, set
        public int IdChamCong
        {
            get { return _idChamCong; }
            set { _idChamCong = value; }
        }
        public int IdKho
        {
            get { return _idKho; }
            set { _idKho = value; }
        }
        
        public DateTime NgayLamViec
        {
            get { return _ngayLamViec; }
            set { _ngayLamViec = value; }
        }
        public string IdNguoiCham
        {
            get { return _idNguoiCham; }
            set { _idNguoiCham = value; }
        }
        public List<ChiTietChamCong> LstChamCong
        {
            get { return _lstChamCong; }
            set { _lstChamCong = value; }
        }
        #endregion

        Utils ut = new Utils();
        public bool getChamCong(int pIDChamCong, int pIdKho)
        {
            DataTable dt,dt1;
            string sql;
            ChiTietChamCong ct;
            bool Ok = true;
            _lstChamCong = new List<ChiTietChamCong>();
            if (pIDChamCong > 0)
            {
                #region pID>0
                sql = @"SELECT * FROM tbl_ChamCong WHERE IdChamCong=" + pIDChamCong.ToString();
                dt = ut.getDataTable(sql);
                if (dt.Rows.Count < 1)
                    Ok = false;
                else
                {
                    DataRow dr = dt.Rows[0];
                    _idChamCong = pIDChamCong;
                    _idKho=ut.getInt(dr["IdKho"]);
                    _ngayLamViec =  ut.getDate(dr["NgayLamViec"]);
                    _idNguoiCham = ut.getString(dr["IdNguoiCham"]);
                    
                    //Load lstChamCong------------------------------------------------
                    sql = @"SELECT     dbo.tbl_ChamCong_ChiTiet.IdChiTiet, dbo.tbl_DM_NhanVien.IdNhanVien,dbo.tbl_DM_NhanVien.MaNhanVien, dbo.tbl_DM_NhanVien.HoTen, dbo.tbl_ChamCong_ChiTiet.DiLam, 
                                dbo.tbl_ChamCong_ChiTiet.ThoiGian, dbo.tbl_ChamCong_ChiTiet.GhiChu
                            FROM         dbo.tbl_ChamCong_ChiTiet INNER JOIN
                                dbo.tbl_DM_NhanVien ON dbo.tbl_ChamCong_ChiTiet.IdNhanVien = dbo.tbl_DM_NhanVien.IdNhanVien
                          WHERE dbo.tbl_ChamCong_Chitiet.IdChamCong=" + pIDChamCong.ToString();
                    dt1 = ut.getDataTable(sql);
                    foreach (DataRow r in dt1.Rows)
                    {
                        ct = new ChiTietChamCong();
                        ct.IdChiTiet = int.Parse(r["IdChiTiet"].ToString());
                        ct.IdNhanVien = ut.getInt(r["IdNhanVien"]);
                        ct.MaNhanVien = ut.getString(r["MaNhanVien"]);
                        ct.TenNhanVien = ut.getString(r["HoTen"]);
                        ct.DiLam = ut.getBool(r["DiLam"]);
                        ct.ThoiGian = ut.getDate(r["ThoiGian"]);
                        ct.GhiChu = ut.getString(r["GhiChu"]);
                        _lstChamCong.Add(ct);
                    }
                    dt1.Dispose();
                }
                dt.Dispose();
                #endregion
            }
            else
            {
            #region pIDChamCong=0 - Lay danh sach tu nhan vien
                _idChamCong = 0;
                _idKho = 0;
                _ngayLamViec = DateTime.Today;
                _idNguoiCham = "";
                sql = @"SELECT     dbo.tbl_DM_NhanVien.IdNhanVien,dbo.tbl_DM_NhanVien.MaNhanVien, dbo.tbl_DM_NhanVien.HoTen, dbo.tbl_Kho_NhanVien.IdKho
                                FROM         dbo.tbl_DM_NhanVien INNER JOIN
                                                      dbo.tbl_Kho_NhanVien ON dbo.tbl_DM_NhanVien.IdNhanVien = dbo.tbl_Kho_NhanVien.IdNhanVien
                                WHERE     dbo.tbl_Kho_NhanVien.IdKho = " + pIdKho ;
                dt1 = ut.getDataTable(sql);
                foreach (DataRow r in dt1.Rows)
                {
                    ct = new ChiTietChamCong();
                    ct.IdChiTiet = 0;
                    ct.IdNhanVien = ut.getInt(r["IdNhanVien"]);
                    ct.MaNhanVien = ut.getString(r["MaNhanVien"]);
                    ct.TenNhanVien = ut.getString(r["HoTen"]);
                    ct.ThoiGian = DateTime.Today;
                    ct.GhiChu = "";
                    _lstChamCong.Add(ct);
                }
                dt1.Dispose();

	            #endregion 
            }
            return Ok;
        }
        
        public ChiTietChamCong FindChamCongChiTiet(int pIdChamCongChiTiet)
        {
            return _lstChamCong.Find(
                delegate(ChiTietChamCong ct)
                {
                    return ct.IdChiTiet == pIdChamCongChiTiet;
                });
        }
        public ChiTietChamCong FindChamCongChiTietByNhanVien(int pIdNhanVien)
        {
            return _lstChamCong.Find(
                delegate(ChiTietChamCong ct)
                {
                    return ct.IdNhanVien == pIdNhanVien;
                });
        }
        public void AddNew()
        {
            
            string lstField, lstValue, sql;
            lstField = ""; lstValue = "";
            ut.CreateStrInsert(ref lstField, ref lstValue, "IdKho", _idKho.ToString(),false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "NgayLamViec",ut.DateToString(_ngayLamViec), true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "IdNguoiCham", _idNguoiCham.ToString(), true);
            sql = string.Format("INSERT INTO tbl_ChamCong({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
            sql += ";select @@Identity";
            int ID = ut.ExecuteSQL(sql);
            if (ID != 0)
            {
                _idChamCong = ID;
                //Chen cac muc trong DataGrid vao tbl_ChamCong_ChiTiet
                foreach (ChiTietChamCong r in _lstChamCong)
                {
                    if (r.IdNhanVien > 0)
                    {
                        lstField = ""; lstValue = "";
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdChamCong", _idChamCong.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdNhanVien", r.IdNhanVien.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "DiLam", r.DiLam ? "1" : "0", false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "ThoiGian", ut.DateTimeToString(r.ThoiGian), true);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "GhiChu", r.GhiChu,true);
                        sql = string.Format("INSERT INTO tbl_ChamCong_ChiTiet({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
                        ut.ExecuteSQL(sql);
                    }
                }
            }
        }
        public void Update()
        {
            string stUpdate,sql;
            stUpdate = "";

            ut.CreateStrUpdate(ref stUpdate, "IdKho", _idKho.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "NgayLamViec", ut.DateToString(_ngayLamViec), true);
            ut.CreateStrUpdate(ref stUpdate, "IdNguoiCham", _idNguoiCham.ToString(), true);
            sql = "UPDATE tbl_ChamCong SET " + stUpdate.Trim(',') + " WHERE IdChamCong=" + _idChamCong.ToString();
            ut.ExecuteSQL(sql);
            //cap nhat lai cac muc trong bang tbl_ChamCong_ChiTiet
            foreach (ChiTietChamCong r in _lstChamCong)
            {
                if ((r.IdChiTiet > 0) && (r.ThayDoi==2))
                {
                    stUpdate = "";
                    ut.CreateStrUpdate(ref stUpdate, "IdChamCong", _idChamCong.ToString(), false);
                    ut.CreateStrUpdate(ref stUpdate, "IdNhanVien", r.IdNhanVien.ToString(), false);
                    ut.CreateStrUpdate(ref stUpdate, "DiLam", r.DiLam ? "1" : "0", false);
                    ut.CreateStrUpdate(ref stUpdate, "ThoiGian", ut.DateTimeToString(r.ThoiGian), true);
                    ut.CreateStrUpdate(ref stUpdate, "GhiChu", r.GhiChu, true);
                    sql = "UPDATE tbl_ChamCong_ChiTiet SET " + stUpdate.Trim(',') + " WHERE IdChiTiet=" + r.IdChiTiet.ToString();
                    ut.ExecuteSQL(sql);
                }
            }
        }
        public void Delete(int pIDChamCong)
        {
            string sql = @"DELETE FROM tbl_ChamCong_Chitiet WHERE IdChamCong=" + pIDChamCong.ToString();
            ut.ExecuteSQL(sql);
            sql = @"DELETE FROM tbl_ChamCong WHERE IdChamCong=" + pIDChamCong.ToString();
            ut.ExecuteSQL(sql);
        }
    }
}
