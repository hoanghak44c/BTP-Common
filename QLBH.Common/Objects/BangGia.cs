using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace QLBH.Common.Objects
{
    public class ChiTietBangGia
    {
        #region Khai bao thuoc tinh
        int _tT;
        int _idSanPham;
        string _maSanPham;
        string _tenSanPham;
        string _donViTinh;
        double _giaNhap;
        double _giaBan;
        double _cK;
        double _tienCK;
        double _vAT;
        double _tienVAT;
        double _thanhTien;
        double _tyleThuong;//thuong nv
        double _thuongNong;
        int _loaiSanPham;
        int _idChiTiet;
        string _khuyenMai;
        string _khuyenMaiMa;
        List<KhuyenMai> _lstKhuyenMai = null;
        int _thayDoi=0;//1:Them, 2: Sua, 3: Xoa.
        #endregion

        #region Khai bao phương thức
        public int TT
        {
            get { return _tT; }
            set { _tT = value; }
        }
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
        public double GiaNhap
        {
            get { return _giaNhap; }
            set { _giaNhap = value; }
        }
        public double GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }
        }
        public double CK
        {
            get { return _cK; }
            set { _cK = value; }
        }
        public double TienCK
        {
            get { return _tienCK; }
            set { _tienCK = value; }
        }
        public double VAT
        {
            get { return _vAT; }
            set { _vAT = value; }
        }
        public double TienVAT
        {
            get { return _tienVAT; }
            set { _tienVAT = value; }
        }
        public double ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }
        
        public int LoaiSanPham
        {
            get { return _loaiSanPham; }
            set { _loaiSanPham = value; }
        }
        public int IdChiTiet
        {
            get { return _idChiTiet; }
            set { _idChiTiet = value; }
        }
        public int ThayDoi
        {
            get { return _thayDoi; }
            set { _thayDoi = value; }
        }
        public double TyLeThuong
        {
            get { return _tyleThuong; }
            set { _tyleThuong = value; }
        }
        public double ThuongNong
        {
            get { return _thuongNong; }
            set { _thuongNong = value; }
        }
        public string  KhuyenMai
        {
            get { return _khuyenMai; }
            set { _khuyenMai = value; }
        }
        public string KhuyenMaiMa
        {
            get { return _khuyenMaiMa; }
            set { _khuyenMaiMa = value; }
        }
        public List<KhuyenMai> LstKhuyenMai
        {
            get { return _lstKhuyenMai; }
            set { _lstKhuyenMai = value; }
        }
        #endregion

        //public string GetKhuyenMaiTheoChiTiet()
        //{
        //    Utils ut = new Utils();
        //    int IdKhuyenMai_old = 0;
        //    string kq = "";
        //    foreach (KhuyenMai r in _lstKhuyenMai)
        //    {
        //        if (IdKhuyenMai_old != 0)
        //            kq = kq + "|";
        //        else
        //            IdKhuyenMai_old = 1;
        //        int i = 0;
        //        foreach (ChiTietKhuyenMai ctkm in r.LstSanPham)
        //        {
        //            if (i == 0) i++;
        //            else kq += ";";
        //            if (ut.getInt(ctkm.IdSanPham) > 0)
        //            {
        //                if (ctkm.SoLuong > 1)
        //                    kq += string.Format(@"{0}({1})", ctkm.TenSanPham, ctkm.SoLuong);
        //                else
        //                    kq += string.Format(@"{0}", ctkm.TenSanPham);
        //                if (ctkm.TienKM>0)
        //                    kq += string.Format(@"[{0:#,##0.##}]", ut.getDouble(ctkm.TienKM));
        //            }
        //            else
        //                kq += string.Format(@"{0:#,##0.##}", ut.getDouble(ctkm.TienKM));
        //        }

        //    }
        //    return kq;
        //}
        public string GetKhuyenMaiTheoChiTiet(ref string KhuyenMaiMa)
        {
            Utils ut = new Utils();
            int IdKhuyenMai_old = 0;
            string kq = "";
            foreach (KhuyenMai r in _lstKhuyenMai)
            {
                if (IdKhuyenMai_old != 0)
                {
                    kq = kq + "|";
                    KhuyenMaiMa = KhuyenMaiMa + ";";
                }
                else
                    IdKhuyenMai_old = 1;
                int i = 0;
                foreach (ChiTietKhuyenMai ctkm in r.LstSanPham)
                {
                    if (i == 0) i++;
                    else
                    {
                        kq += ";";
                    }
                    if (ut.getInt(ctkm.IdSanPham) > 0)
                    {
                        if (ctkm.SoLuong > 1)
                        {
                            kq += string.Format(@"{0}({1})", ctkm.TenSanPham, ctkm.SoLuong);
                            KhuyenMaiMa += string.Format(@"\{0}({1})", ctkm.MaSanPham, ctkm.SoLuong);
                        }
                        else
                        {
                            kq += string.Format(@"{0}", ctkm.TenSanPham);
                            KhuyenMaiMa += string.Format(@"\{0}", ctkm.MaSanPham);
                        }
                        if (ctkm.TienKM > 0)
                        {
                            kq += string.Format(@"[{0:#,##0.##}]", ut.getDouble(ctkm.TienKM));
                            KhuyenMaiMa += string.Format(@"/{0}", ctkm.TienKM);
                        }
                    }
                    else
                    {
                        kq += string.Format(@"{0:#,##0.##}", ut.getDouble(ctkm.TienKM));
                        KhuyenMaiMa += string.Format(@"/{0}", ctkm.TienKM);
                    }
                }

            }
            return kq;
        }
    }

    public class BangGia
    {
        #region Khai bao thuoc tinh
        int _idBangGia;
        string _soBangGia;
        DateTime _ngayKy;
        DateTime _ngayLap;
        string _nguoiKy;
        bool _tinhTrang;
        string _ghiChu;
        List<ChiTietBangGia> _lstSanPham=new List<ChiTietBangGia>();
        #endregion
        #region Khai bao phương thức get, set
        public int IdBangGia
        {
            get { return _idBangGia; }
            set { _idBangGia = value; }
        }
        public string SoBangGia
        {
            get { return _soBangGia; }
            set { _soBangGia = value; }
        }
        public DateTime NgayKy
        {
            get { return _ngayKy; }
            set { _ngayKy = value; }
        }
        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }
        public string NguoiKy
        {
            get { return _nguoiKy; }
            set { _nguoiKy = value; }
        }
        public bool TinhTrang
        {
            get { return _tinhTrang; }
            set { _tinhTrang = value; }
        }
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }
        public List<ChiTietBangGia> LstSanPham
        {
            get { return _lstSanPham; }
            set { _lstSanPham = value; }
        }
        #endregion
        Utils ut = new Utils();
        public bool getBangGia(int pIDBangGia)
        {
            DataTable dt,dt1;
            string sql;
            ChiTietBangGia ct;
            KhuyenMai km;
            int tt;
            bool Ok = true;
            _lstSanPham = new List<ChiTietBangGia>();
            if (pIDBangGia > 0)
            {
                #region pIDBangGia>0
                sql = @"SELECT * FROM tbl_BangGia WHERE IdBangGia=" + pIDBangGia.ToString();
                dt = ut.getDataTable(sql);
                if (dt.Rows.Count < 1)
                    Ok = false;
                else
                {
                    DataRow dr = dt.Rows[0];
                    _idBangGia = pIDBangGia;
                    _soBangGia=ut.getString(dr["SoBangGia"]);
                    _ngayKy =  ut.getDate(dr["NgayKy"]);
                    _ngayLap = (dr["NgayHieuLuc"] != DBNull.Value ? ut.getDate(dr["NgayHieuLuc"]) : DateTime.MinValue);
                    _nguoiKy = ut.getString(dr["NguoiKy"]);
                    //_tinhTrang = ((bool)dr["TinhTrang"]);
                    _ghiChu = ut.getString(dr["GhiChu"]);
                    //Load lstSanPham
                    sql = @"SELECT    dbo.tbl_BangGia_Chitiet.IdChiTiet, dbo.tbl_BangGia_Chitiet.IdBangGia, dbo.tbl_BangGia_Chitiet.IdSanPham, dbo.tbl_SanPham.IdCha, 
                                      dbo.tbl_SanPham.MaSanPham, dbo.tbl_SanPham.TenSanPham, dbo.tbl_SanPham.GiaNhap, dbo.tbl_BangGia_Chitiet.DonGiaChuaVAT, 
                                      dbo.tbl_BangGia_Chitiet.TyleChietKhau, dbo.tbl_BangGia_Chitiet.TyLeThuong, dbo.tbl_BangGia_Chitiet.TienChietKhau, 
                                      dbo.tbl_BangGia_Chitiet.TyleVAT, dbo.tbl_BangGia_Chitiet.TienVAT, dbo.tbl_BangGia_Chitiet.DonGiaCoVAT, 
                                      dbo.tbl_BangGia_Chitiet.ThuongNong,dbo.tbl_BangGia_Chitiet.KhuyenMai,dbo.tbl_BangGia_Chitiet.KhuyenMaiMa 
                FROM         dbo.tbl_BangGia_Chitiet INNER JOIN
                                      dbo.tbl_SanPham ON dbo.tbl_BangGia_Chitiet.IdSanPham = dbo.tbl_SanPham.IdSanPham and dbo.tbl_SanPham.SuDung=1
                          WHERE dbo.tbl_BangGia_Chitiet.IdBangGia=" + pIDBangGia.ToString();
                    dt1 = ut.getDataTable(sql);
                    tt = 0;
                    foreach (DataRow r in dt1.Rows)
                    {
                        ct = new ChiTietBangGia();
                        tt++; ct.TT = tt;
                        ct.IdSanPham = int.Parse(r["IdSanPham"].ToString());
                        ct.MaSanPham = ut.getString(r["MaSanPham"]);
                        ct.TenSanPham = ut.getString(r["TenSanPham"]);
                        ct.GiaNhap = ut.getDouble(r["GiaNhap"]);
                        ct.GiaBan = ut.getDouble(r["DonGiaChuaVAT"]);
                        //ct.DonViTinh = ut.getString(r["TenDonViTinh"]);
                        ct.CK = ut.getDouble(r["TyleChietKhau"])*100;
                        ct.TienCK = ut.getDouble(r["TienChietKhau"]);
                        ct.VAT = ut.getDouble(r["TyleVAT"]) < 0 ? ut.getDouble(r["TyleVAT"]) : ut.getDouble(r["TyleVAT"]) * 100;
                        ct.TienVAT = ut.getDouble(r["TienVAT"]);
                        ct.ThanhTien = ut.getDouble(r["DonGiaCoVAT"]);
                        ct.LoaiSanPham = ut.getInt(r["IdCha"]);
                        ct.IdChiTiet = ut.getInt(r["IdChiTiet"]);
                        ct.TyLeThuong = ut.getDouble(r["TyleThuong"]) * 100;
                        ct.ThuongNong = ut.getDouble(r["ThuongNong"]);
                        ct.KhuyenMai = ut.getString(r["KhuyenMai"]);//getKhuyenMai(ct.IdChiTiet);
                        ct.KhuyenMaiMa = ut.getString(r["KhuyenMaiMa"]);//getKhuyenMai(ct.IdChiTiet);
                        //Lay ds khuyen mai
                        km = new KhuyenMai();
                        //if (ct.KhuyenMai.Length==0)
                            ct.LstKhuyenMai = null;
                        //else
                        //    ct.LstKhuyenMai = km.getListKhuyenMai(ct.IdChiTiet);// Bo de tang toc do
                        _lstSanPham.Add(ct);
                    }
                    dt1.Dispose();
                }
                dt.Dispose();
                #endregion
            }
            else
            {
            #region pIDBangGia=0 - Lay danh sach tu san pham
                _idBangGia = 0;
                _soBangGia = "";
                _ngayKy = DateTime.Today;
                _ngayLap = DateTime.Today;
                _nguoiKy = "";
                //_tinhTrang = false;
                _ghiChu = "";
		                sql = @"SELECT     IdSanPham, IdCha, MaSanPham, TenSanPham, GiaNhap, SuDung
                        FROM         dbo.tbl_SanPham   
                            WHERE     (dbo.tbl_SanPham.SuDung = 1)";
                dt1 = ut.getDataTable(sql);
                tt = 0;
                foreach (DataRow r in dt1.Rows)
                {
                    ct = new ChiTietBangGia();
                    tt++; ct.TT = tt;
                    ct.IdSanPham = int.Parse(r["IdSanPham"].ToString());
                    ct.MaSanPham = ut.getString(r["MaSanPham"]);
                    ct.TenSanPham = ut.getString(r["TenSanPham"]);
                    ct.GiaNhap = ut.getDouble(r["GiaNhap"]);
                    //ct.GiaBan = ut.getDouble(r["GiaBanChuaVAT"]);
                    //ct.DonViTinh = ut.getString(r["TenDonViTinh"]);
                    //ct.CK = ut.getDouble(r["TyleChietKhau"]);
                    //ct.TienCK = ut.getDouble(r["TienChietKhau"]);
                    //ct.VAT = ut.getDouble(r["TyleVAT"]);
                    //ct.TienVAT = ut.getDouble(r["TienVAT"]);
                    //ct.ThanhTien = ut.getDouble(r["GiaBanCoVAT"]);
                    //ct.TyLeThuong = ut.getDouble(r["TyleThuong"]);
                    ct.GiaBan = 0;
                    ct.CK = 0;
                    ct.TienCK = 0;
                    ct.VAT = 0;
                    ct.TienVAT = 0;
                    ct.ThanhTien = 0;
                    ct.TyLeThuong = 0;
                    ct.ThuongNong = 0;
                    ct.LoaiSanPham = ut.getInt(r["IdCha"]);
                    ct.KhuyenMai = "";
                    ct.KhuyenMaiMa = "";
                    ct.IdChiTiet = 0;
                    ct.LstKhuyenMai = null;
                    _lstSanPham.Add(ct);
                }
                dt1.Dispose();

	            #endregion 
            }
            return Ok;
        }
//        public string getKhuyenMai(int pIdBangGiaChiTiet)
//        {
//            string sql=string.Format(@"SELECT     dbo.tbl_SanPham.IdSanPham,dbo.tbl_SanPham.TenSanPham, dbo.tbl_KhuyenMai_Chitiet.SoTien, dbo.tbl_SanPham.MaSanPham, dbo.tbl_KhuyenMai_Chitiet.SoLuong,
//                                    dbo.tbl_KhuyenMai.IdKhuyenMai
//                    FROM         dbo.tbl_KhuyenMai INNER JOIN
//                                          dbo.tbl_KhuyenMai_Chitiet ON dbo.tbl_KhuyenMai.IdKhuyenMai = dbo.tbl_KhuyenMai_Chitiet.IdKhuyenMai LEFT OUTER JOIN
//                                          dbo.tbl_SanPham ON dbo.tbl_KhuyenMai_Chitiet.IdSanPham = dbo.tbl_SanPham.IdSanPham
//                    WHERE     (dbo.tbl_KhuyenMai.IdChiTietBangGia = {0}) ORDER BY dbo.tbl_KhuyenMai.IdKhuyenMai", pIdBangGiaChiTiet);
//            DataTable dt = ut.getDataTable(sql);
//            string kq="";
//            int IdKhuyenMai_old = 0;
//            foreach (DataRow r in dt.Rows)
//            {
//                if (IdKhuyenMai_old != ut.getInt(r["IdKhuyenMai"]))
//                {
//                    if (IdKhuyenMai_old != 0)
//                        kq = kq.Trim(',') + "|";
//                    IdKhuyenMai_old = ut.getInt(r["IdKhuyenMai"]);
//                }
//                if (ut.getInt(r["IdSanPham"]) > 0)
//                    kq += string.Format("{0}({1}),", r["MaSanPham"], r["SoLuong"]);
//                else
//                    kq += string.Format("{0},", r["SoTien"]);
                
//            }
//            return kq.Trim(',');
//        }
        public string getKhuyenMai(int pIdBangGiaChiTiet)
        {
            ChiTietBangGia ct = FindChiTiet(pIdBangGiaChiTiet);
            int IdKhuyenMai_old = 0;
            string kq = "";
            foreach (KhuyenMai r in ct.LstKhuyenMai)
            {
                if (IdKhuyenMai_old != 0)
                        kq = kq.Trim(',') + "|";
                else
                    IdKhuyenMai_old = 1;
                foreach (ChiTietKhuyenMai ctkm in r.LstSanPham)
                {
                    if (ut.getInt(ctkm.IdSanPham) > 0)
                        kq += string.Format("{0}({1}),", ctkm.MaSanPham, ctkm.SoLuong);
                    else
                        kq += string.Format("{0},", ctkm.TienKM);
                }

            }
            return kq.Trim(',');
        }
        public string getKhuyenMaiMa(int pIdBangGiaChiTiet)
        {
            ChiTietBangGia ct = FindChiTiet(pIdBangGiaChiTiet);
            int IdKhuyenMai_old = 0;
            string kq = "";
            foreach (KhuyenMai r in ct.LstKhuyenMai)
            {
                if (IdKhuyenMai_old != 0)
                    kq = kq.Trim(',') + "|";
                else
                    IdKhuyenMai_old = 1;
                foreach (ChiTietKhuyenMai ctkm in r.LstSanPham)
                {
                    if (ut.getInt(ctkm.IdSanPham) > 0)
                        kq += string.Format("{0}({1}),", ctkm.MaSanPham, ctkm.SoLuong);
                    else
                        kq += string.Format("{0},", ctkm.TienKM);
                }

            }
            return kq.Trim(',');
        }
        //public string getKhuyenMaiTheoTT(int pTT)
        //{
        //    ChiTietBangGia ct = FindThuTu(pTT);
        //    return ct.GetKhuyenMaiTheoChiTiet();
        //}
        public string getKhuyenMaiTheoTT(int pTT, ref string KhuyenMaiMa)
        {
            ChiTietBangGia ct = FindThuTu(pTT);
            return ct.GetKhuyenMaiTheoChiTiet(ref KhuyenMaiMa);
        }        
        public List<ChiTietBangGia> LocSP(string maSP, string tenSP, int loaiSP)
        {
            return _lstSanPham.FindAll(delegate(ChiTietBangGia chitiet)
                    {
                        bool dk = true;
                        if (maSP.Trim() != "") dk = dk && ut.isInStr(chitiet.MaSanPham.ToLower(),maSP.ToLower());
                        if (tenSP.Trim() != "") dk = dk && ut.isInStr(chitiet.TenSanPham.ToLower(),tenSP.ToLower());
                        if (loaiSP > 0) dk = dk && (chitiet.LoaiSanPham == loaiSP);
                        return dk;
                    });
        }
        public ChiTietBangGia FindSanPham(int pIdSanPham)
        {
            return _lstSanPham.Find(
                delegate(ChiTietBangGia ct)
                {
                    return ct.IdSanPham == pIdSanPham;
                });
        }
        public ChiTietBangGia FindThuTu(int pTT)
        {
            return _lstSanPham.Find(
                delegate(ChiTietBangGia ct)
                {
                    return ct.TT == pTT;
                });
        }
        public ChiTietBangGia FindChiTiet(int pIdChiTiet)
        {
            return _lstSanPham.Find(
                delegate(ChiTietBangGia ct)
                {
                    return ct.IdChiTiet == pIdChiTiet;
                });
        }
        public void AddNew()
        {
            string lstField, lstValue, sql;
            lstField = ""; lstValue = "";
            ut.CreateStrInsert(ref lstField, ref lstValue, "SoBangGia", _soBangGia, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "NguoiKy",_nguoiKy, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "NgayKy",ut.DateToStringLong(_ngayKy), true);
            //ut.CreateStrInsert(ref lstField, ref lstValue, "NgayHieuLuc", ut.DateToStringLong(_ngayLap), true);
            if (!_ngayLap.Equals(DateTime.MinValue))
                ut.CreateStrInsert(ref lstField, ref lstValue, "NgayHieuLuc", ut.DateToStringLong(_ngayLap), true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "GhiChu", _ghiChu, true);
            //ut.CreateStrInsert(ref lstField, ref lstValue, "TinhTrang", (_tinhTrang) ? "1" : "0", false);

            sql = string.Format("INSERT INTO tbl_BangGia({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
            sql += ";select @@Identity";
            int ID = ut.ExecuteSQL(sql);
            double tmp;
            if (ID != 0)
            {
                _idBangGia = ID;
                //Chen cac muc trong DataGrid vao tbl_BangGia_ChiTiet
                foreach (ChiTietBangGia r in _lstSanPham)
                {
                    if (r.IdSanPham > 0)
                    {
                        lstField = ""; lstValue = "";
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdBangGia", _idBangGia.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdSanPham", r.IdSanPham.ToString(), false);
                        //ut.CreateStrInsert(ref lstField, ref lstValue, "ThuongNong", r.ThuongNong.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "DonGiaChuaVAT", r.GiaBan.ToString(new CultureInfo("en-US")), false);
                        tmp = (r.CK / 100);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TyleChietKhau", tmp.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TienChietKhau", r.TienCK.ToString(new CultureInfo("en-US")), false);
                        //tmp = r.VAT / 100;
                        tmp = r.VAT < 0 ? r.VAT : (r.VAT / 100);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TyLeVAT", tmp.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TienVAT", r.TienVAT.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "DonGiaCoVAT", r.ThanhTien.ToString(new CultureInfo("en-US")), false);
                        tmp = r.TyLeThuong / 100;
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TyLeThuong", tmp.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "ThuongNong", r.ThuongNong.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "KhuyenMai", r.KhuyenMai, true);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "KhuyenMaiMa", r.KhuyenMaiMa, true);
                        sql = string.Format("INSERT INTO tbl_BangGia_ChiTiet({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
                        sql += ";select @@Identity";
                        r.IdChiTiet= ut.ExecuteSQL(sql);
                        //Chen khuyen mai
                        if (r.LstKhuyenMai != null)
                        {
                            foreach (KhuyenMai km in r.LstKhuyenMai)
                            {
                                km.IdChiTietBangGia = r.IdChiTiet;
                                km.AddNew();
                            }
                        }
                    }
                }
            }
        }
        public void Update()
        {
            string stUpdate, sql,lstField, lstValue;
            stUpdate = "";
            ut.CreateStrUpdate(ref stUpdate, "SoBangGia", _soBangGia, true);
            ut.CreateStrUpdate(ref stUpdate, "NguoiKy", _nguoiKy, true);
            ut.CreateStrUpdate(ref stUpdate, "NgayKy", ut.DateToStringLong(_ngayKy), true);
            if (!_ngayLap.Equals(DateTime.MinValue))
                ut.CreateStrUpdate(ref stUpdate, "NgayHieuLuc", ut.DateToStringLong(_ngayLap), true);
            else
                ut.CreateStrUpdate(ref stUpdate, "NgayHieuLuc", "NULL", false);
            ut.CreateStrUpdate(ref stUpdate, "GhiChu", _ghiChu, true);
            //ut.CreateStrUpdate(ref stUpdate, "TinhTrang", (_tinhTrang) ? "1" : "0", false);
            sql = "UPDATE tbl_BangGia SET " + stUpdate.Trim(',') + " WHERE IdBangGia=" + _idBangGia.ToString();
            ut.ExecuteSQL(sql);
            //cap nhat lai cac muc trong bang tbl_BangGia_ChiTiet
            KhuyenMai tmpKM = new KhuyenMai();
            double tmp;
            foreach (ChiTietBangGia r in _lstSanPham)
            {
                
                if ((r.IdChiTiet > 0) && (r.ThayDoi == 2))
                {
                 #region TH Sua   
                    stUpdate = "";
                    ut.CreateStrUpdate(ref stUpdate, "IdBangGia", _idBangGia.ToString(), false);
                    ut.CreateStrUpdate(ref stUpdate, "IdSanPham", r.IdSanPham.ToString(), false);
                    ut.CreateStrUpdate(ref stUpdate, "DonGiaChuaVAT", r.GiaBan.ToString(new CultureInfo("en-US")), false);
                    tmp = (r.CK / 100);
                    ut.CreateStrUpdate(ref stUpdate, "TyleChietKhau", tmp.ToString(new CultureInfo("en-US")), false);
                    ut.CreateStrUpdate(ref stUpdate, "TienChietKhau", r.TienCK.ToString(new CultureInfo("en-US")), false);
                    tmp = r.VAT < 0 ? r.VAT : (r.VAT / 100);
                    ut.CreateStrUpdate(ref stUpdate, "TyLeVAT", tmp.ToString(new CultureInfo("en-US")), false);
                    ut.CreateStrUpdate(ref stUpdate, "TienVAT", r.TienVAT.ToString(new CultureInfo("en-US")), false);
                    ut.CreateStrUpdate(ref stUpdate, "DonGiaCoVAT", r.ThanhTien.ToString(new CultureInfo("en-US")), false);
                    tmp = (r.TyLeThuong / 100);
                    ut.CreateStrUpdate(ref stUpdate, "TyLeThuong", tmp.ToString(new CultureInfo("en-US")), false);
                    ut.CreateStrUpdate(ref stUpdate, "ThuongNong", r.ThuongNong.ToString(new CultureInfo("en-US")), false);
                    ut.CreateStrUpdate(ref stUpdate, "KhuyenMai", r.KhuyenMai, true);
                    ut.CreateStrUpdate(ref stUpdate, "KhuyenMaiMa", r.KhuyenMaiMa, true);
                    sql = "UPDATE tbl_BangGia_ChiTiet SET " + stUpdate.Trim(',') + " WHERE IdChiTiet=" + r.IdChiTiet.ToString();
                    ut.ExecuteSQL(sql);

                    if (r.LstKhuyenMai != null)
                    {
                        //Xoa cac khuyen mai cu
                        tmpKM.DeleteAllKhuyenMai(r.IdChiTiet);
                        foreach (KhuyenMai km in r.LstKhuyenMai)
                        {
                            km.IdChiTietBangGia = r.IdChiTiet;
                            km.AddNew();
                        }
                    }
                #endregion
                } 
                else
                    if ((r.IdSanPham > 0) && (r.IdChiTiet==0))
                    {
                        #region TH Them tay 1 so san pham
                        lstField = ""; lstValue = "";
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdBangGia", _idBangGia.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "IdSanPham", r.IdSanPham.ToString(), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "ThuongNong", r.ThuongNong.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "DonGiaChuaVAT", r.GiaBan.ToString(new CultureInfo("en-US")), false);
                        tmp = (r.CK / 100);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TyleChietKhau", tmp.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TienChietKhau", r.TienCK.ToString(new CultureInfo("en-US")), false);
                        tmp = r.VAT < 0 ? r.VAT : (r.VAT / 100);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TyLeVAT", tmp.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TienVAT", r.TienVAT.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "DonGiaCoVAT", r.ThanhTien.ToString(new CultureInfo("en-US")), false);
                        tmp = r.TyLeThuong / 100;
                        ut.CreateStrInsert(ref lstField, ref lstValue, "TyLeThuong", tmp.ToString(new CultureInfo("en-US")), false);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "KhuyenMai", r.KhuyenMai, true);
                        ut.CreateStrInsert(ref lstField, ref lstValue, "KhuyenMaiMa", r.KhuyenMaiMa, true);
                        sql = string.Format("INSERT INTO tbl_BangGia_ChiTiet({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
                        sql += ";select @@Identity";
                        r.IdChiTiet = ut.ExecuteSQL(sql);
                        //Chen khuyen mai
                        if (r.LstKhuyenMai != null)
                        {
                            foreach (KhuyenMai km in r.LstKhuyenMai)
                            {
                                km.IdChiTietBangGia = r.IdChiTiet;
                                km.AddNew();
                            }
                        } 
                        #endregion
                    }
            }
        }
        public void Delete(int pIDBangGia)
        {

            KhuyenMai km = new KhuyenMai();
            string sql = @"SELECT * FROM tbl_KhuyenMai WHERE IdChiTietBangGia IN (SELECT IdChiTiet FROM tbl_BangGia_Chitiet WHERE IdBangGia=" + pIDBangGia.ToString() + ")";
            DataTable dt = ut.getDataTable(sql);
            foreach (DataRow r in dt.Rows)
                km.Delete(ut.getInt(r["IdKhuyenMai"]));
            sql = @"DELETE FROM tbl_BangGia_Chitiet WHERE IdBangGia=" + pIDBangGia.ToString();
            ut.ExecuteSQL(sql);
            sql = @"DELETE FROM tbl_BangGia WHERE IdBangGia=" + pIDBangGia.ToString();
            ut.ExecuteSQL(sql);
        }
        public void ApDung(int pIDBangGia,int pIdTrungTam)
        {
            string sql;
            int Id = ut.fGetID_sql("SELECT IdTrungTam FROM tbl_DM_TrungTam WHERE IdTrungTam=" + pIdTrungTam.ToString());
            if (Id > 0)
            {
                sql = string.Format("UPDATE tbl_DM_TrungTam SET IdBangGia={0} WHERE IdTrungTam={1}", pIDBangGia, pIdTrungTam);
                ut.ExecuteSQL(sql);
            }
        }
        public void ApDungTrungTam(int pIDBangGia, int pIdTrungTam)
        {
            string sql;
            if (pIdTrungTam > 0)
            {
                sql = string.Format("DELETE tbl_BangGia_Kho WHERE IdBangGia={0}", pIDBangGia);
                ut.ExecuteSQL(sql);
                sql = string.Format("UPDATE tbl_DM_TrungTam SET IdBangGia={0} WHERE IdTrungTam={1}", pIDBangGia, pIdTrungTam);
                ut.ExecuteSQL(sql);
            }
        }
        public void ApDungShop(int pIDBangGia, int pIdKho)
        {
            string sql;
            if (pIdKho > 0)
            {

                sql = string.Format("DELETE tbl_BangGia_Kho WHERE IdBangGia={0} And IdKho = {1}", pIDBangGia, pIdKho);
                ut.ExecuteSQL(sql);
                sql = string.Format("INSERT INTO  tbl_BangGia_Kho(IdBangGia, IdKho) VALUES({0}, {1})", pIDBangGia, pIdKho);
                ut.ExecuteSQL(sql);
            }
        }
        //public void ApDung()
        //{
        //    string sql;
        //    foreach (ChiTietBangGia r in _lstSanPham)
        //    {
        //        sql = string.Format("UPDATE tbl_SanPham SET GiaBanChuaVAT={0},TyLeChietKhau={1},TienChietKhau={2},TyLeVAT={3},TienVAT={4},GiaBanCoVAT = {5},TyLeThuong={6} Where IdSanPham={7}",
        //                            r.GiaBan, r.CK, r.TienCK, r.VAT, r.TienVAT, r.ThanhTien, r.TyLeThuong, r.IdSanPham);
        //        ut.ExecuteSQL(sql);
        //    }
        //    ut.ExecuteSQL("UPDATE tbl_BangGia SET TinhTrang=0");
        //    ut.ExecuteSQL("UPDATE tbl_BangGia SET TinhTrang=1 Where IdBangGia=" + _idBangGia.ToString());
        //    _tinhTrang = true;
        //}
    }
    public class KetQuaImportBangGiaChiTiet
    {
        string maSanPham, tenSanPham, lyDo;
        public string MaSanPham
        {
            set { maSanPham = value; }
            get { return maSanPham; }
        }
        public string TenSanPham
        {
            set { tenSanPham = value; }
            get { return tenSanPham; }
        }
        public string LyDo
        {
            set { lyDo = value; }
            get { return lyDo; }
        }
    }
    public class KetQuaImportBangGia
    {
        int slThanhCong, slLoi;
        List<KetQuaImportBangGiaChiTiet> lstLoi;
        public int SLThanhCong
        {
            set { slThanhCong = value; }
            get { return slThanhCong; }
        }
        public int SLLoi
        {
            set { slLoi = value; }
            get { return slLoi; }
        }
        public List<KetQuaImportBangGiaChiTiet> LstLoi
        {
            set { lstLoi = value; }
            get { return lstLoi; }
        }
        //ket qua import
        public KetQuaImportBangGia()
        {
            SLThanhCong = 0; 
            slLoi = 0; 
            lstLoi = new List<KetQuaImportBangGiaChiTiet>();
        }
        
    }
}
