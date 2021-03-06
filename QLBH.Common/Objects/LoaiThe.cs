using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;

namespace QLBH.Common.Objects
{
    public class LoaiThe_UuDai
    {
        #region Khai bao thuoc tinh
        int tT;
        int id;
        int idLoaiThe;
        string dichVu;
        string uuDai;
        int thayDoi=0;//1:Them, 2: Sua, 3: Xoa.
        #endregion
        Utils ut = new Utils();
        static Utils ut1 = new Utils();
        #region Khai bao phương thức
        public int TT
        {
            get { return tT; }
            set { tT = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdLoaiThe
        {
            get { return idLoaiThe; }
            set { idLoaiThe = value; }
        }
        
        public string DichVu
        {
            get { return dichVu; }
            set { dichVu = value; }
        }
        public string UuDai
        {
            get { return uuDai; }
            set { uuDai = value; }
        }
        public int ThayDoi
        {
            get { return thayDoi; }
            set { thayDoi = value; }
        }
        #endregion
        public void AddNew()
        {
            string sql,lstField,lstValue;
            lstField = ""; lstValue = "";
            ut.CreateStrInsert(ref lstField, ref lstValue, "idLoaiThe",idLoaiThe.ToString() , false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "dichVu", dichVu, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "uuDai", uuDai, true);
            
            sql = string.Format("INSERT INTO tbl_DM_LoaiThe_UuDai({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
            sql += ";select @@Identity";
            ut.ExecuteSQL(sql);
        }
        public void Update()
        {
            string stUpdate, sql;
            stUpdate = "";
            ut.CreateStrUpdate(ref stUpdate, "idLoaiThe", idLoaiThe.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "dichVu", dichVu, true);
            ut.CreateStrUpdate(ref stUpdate, "uuDai", uuDai, true);
            sql = "UPDATE tbl_DM_LoaiThe_UuDai SET " + stUpdate.Trim(',') + " WHERE IdUuDai=" + id.ToString();
            ut.ExecuteSQL(sql);
        }
        public void Delete()
        {
            string sql="DELETE FROM tbl_DM_LoaiThe_UuDai WHERE IdUuDai=" + id.ToString();
            ut.ExecuteSQL(sql);
        }
        public static List<LoaiThe_UuDai> getLstUuDai(int IdLoaiThe)
        {
            List<LoaiThe_UuDai> lst=new List<LoaiThe_UuDai>();
            LoaiThe_UuDai uudai;
            string sql = string.Format("SELECT * FROM tbl_DM_LoaiThe_UuDai WHERE IdLoaiThe={0}", IdLoaiThe);
            DataTable dt=ut1.getDataTable(sql);
            int dem = 0;
            foreach(DataRow r in dt.Rows)
            {
                dem++;
                uudai = new LoaiThe_UuDai();
                uudai.tT = dem;
                uudai.Id=ut1.getInt(r["IdUuDai"]);
                uudai.IdLoaiThe=ut1.getInt(r["IdLoaiThe"]);
                uudai.DichVu=r["DichVu"].ToString();
                uudai.UuDai=r["UuDai"].ToString();
                lst.Add(uudai);
            }
            return lst;
        }
    }
    public class LoaiThe_QuyenLoi
    {
        #region Khai bao thuoc tinh
        int tT;
        int id;
        int idLoaiThe;
        int idSanPham;
        double tyleGiam;
        string ghiChu;
        int thayDoi = 0;//1:Them, 2: Sua, 3: Xoa.
        #endregion
        Utils ut = new Utils();
        static Utils ut1 = new Utils();
        #region Khai bao phương thức
        public int TT
        {
            get { return tT; }
            set { tT = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdLoaiThe
        {
            get { return idLoaiThe; }
            set { idLoaiThe = value; }
        }
        public int IdSanPham
        {
            get { return idSanPham; }
            set { idSanPham = value; }
        }
        public double TyleGiam
        {
            get { return tyleGiam; }
            set { tyleGiam = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public int ThayDoi
        {
            get { return thayDoi; }
            set { thayDoi = value; }
        }
        #endregion
        public void AddNew()
        {
            string sql,lstField,lstValue;
            lstField = ""; lstValue = "";
            ut.CreateStrInsert(ref lstField, ref lstValue, "idLoaiThe",idLoaiThe.ToString() , false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "idSanPham", idSanPham.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "tyleGiam", tyleGiam.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "GhiChu", ut.getString(ghiChu), true);
            
            sql = string.Format("INSERT INTO tbl_DM_LoaiThe_QuyenLoi({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
            sql += ";select @@Identity";
            ut.ExecuteSQL(sql);
        }
        public void Update()
        {
            string stUpdate, sql;
            stUpdate = "";
            ut.CreateStrUpdate(ref stUpdate, "idLoaiThe", idLoaiThe.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "idSanPham", idSanPham.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "tyleGiam", tyleGiam.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "GhiChu", ghiChu, true);
            sql = "UPDATE tbl_DM_LoaiThe_QuyenLoi SET " + stUpdate.Trim(',') + " WHERE IdQuyenLoi=" + id.ToString();
            ut.ExecuteSQL(sql);
        }
        public void Delete()
        {
            string sql="DELETE FROM tbl_DM_LoaiThe_QuyenLoi WHERE IdQuyenLoi=" + id.ToString();
            ut.ExecuteSQL(sql);
        }
        public static List<LoaiThe_QuyenLoi> getLstQuyenLoi(int IdLoaiThe)
        {
            List<LoaiThe_QuyenLoi> lst=new List<LoaiThe_QuyenLoi>();
            LoaiThe_QuyenLoi quyenloi;
            string sql = string.Format("SELECT * FROM tbl_DM_LoaiThe_QuyenLoi WHERE IdLoaiThe={0}", IdLoaiThe);
            DataTable dt=ut1.getDataTable(sql);
            int dem = 0;
            foreach(DataRow r in dt.Rows)
            {
                dem++;
                quyenloi = new LoaiThe_QuyenLoi();
                quyenloi.tT = dem;
                quyenloi.Id=ut1.getInt(r["IdQuyenLoi"]);
                quyenloi.IdLoaiThe = ut1.getInt(r["IdLoaiThe"]);
                quyenloi.IdSanPham=ut1.getInt(r["IdSanPham"]);
                quyenloi.TyleGiam=ut1.getDouble(r["TyLeGiam"]);
                quyenloi.GhiChu=r["GhiChu"].ToString();
                lst.Add(quyenloi);
            }
            return lst;
        }
    }
    public class LoaiThe_KhachHang
    {
        #region Khai bao thuoc tinh
        int tT;
        int id;
        string maThe;
        string tenThe;
        string ghiChu;
        double dk_GiaTri_LanDau;
        double dk_GiaTri_TichLuy_Tu;
        double dk_GiaTri_TichLuy_Den;
        string dk_SanPham_KemTheo;
        int thoiGianHieuLuc;
        int doUuTien;
        double baoLuuDiem;
        bool duocTangQuaSinhNhat;
        bool duocBaoHanhVang;
        bool duocCapNhatSanPhamMoi;
        bool duocThamGiaDaoTao;
        bool duocTuVanHoTro;
        List<LoaiThe_QuyenLoi> lstQuyenLoi=new List<LoaiThe_QuyenLoi>();
        List<LoaiThe_UuDai> lstUuDai=new List<LoaiThe_UuDai>();
        //int _thayDoi = 0;//1:Them, 2: Sua, 3: Xoa.
        bool suDung;
        #endregion

        #region Khai bao phương thức get, set
        public int TT
        {
            get { return tT; }
            set { tT = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string MaThe
        {
            get { return maThe; }
            set { maThe = value; }
        }
        public string TenThe
        {
            get { return tenThe; }
            set { tenThe = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        public double Dk_GiaTri_LanDau
        {
            get { return dk_GiaTri_LanDau; }
            set { dk_GiaTri_LanDau = value; }
        }
        public double Dk_GiaTri_TichLuy_Tu
        {
            get { return dk_GiaTri_TichLuy_Tu; }
            set { dk_GiaTri_TichLuy_Tu = value; }
        }
        public double Dk_GiaTri_TichLuy_Den
        {
            get { return dk_GiaTri_TichLuy_Den; }
            set { dk_GiaTri_TichLuy_Den = value; }
        }
        public string Dk_SanPham_KemTheo
        {
            get { return dk_SanPham_KemTheo; }
            set { dk_SanPham_KemTheo = value; }
        }
        public int ThoiGianHieuLuc
        {
            get { return thoiGianHieuLuc; }
            set { thoiGianHieuLuc = value; }
        }
        public int DoUuTien
        {
            get { return doUuTien; }
            set { doUuTien = value; }
        }
        public double BaoLuuDiem
        {
            get { return baoLuuDiem; }
            set { baoLuuDiem = value; }
        }
        public bool DuocTangQuaSinhNhat
        {
            get { return duocTangQuaSinhNhat; }
            set { duocTangQuaSinhNhat = value; }
        }
        public bool DuocBaoHanhVang
        {
            get { return duocBaoHanhVang; }
            set { duocBaoHanhVang = value; }
        }
        public bool DuocCapNhatSanPhamMoi
        {
            get { return duocCapNhatSanPhamMoi; }
            set { duocCapNhatSanPhamMoi = value; }
        }
        public bool DuocThamGiaDaoTao
        {
            get { return duocThamGiaDaoTao; }
            set { duocThamGiaDaoTao = value; }
        }
        public bool DuocTuVanHoTro
        {
            get { return duocTuVanHoTro; }
            set { duocTuVanHoTro = value; }
        }
        public List<LoaiThe_QuyenLoi> LstQuyenLoi
        {
            get { return lstQuyenLoi; }
            set { lstQuyenLoi = value; }
        }
        public List<LoaiThe_UuDai> LstUuDai
        {
            get { return lstUuDai; }
            set { lstUuDai = value; }
        }
        public bool SuDung
        {
            get { return suDung; }
            set { suDung = value; }
        }    
    #endregion
        Utils ut = new Utils();
        
        public bool getLoaiThe(int pID)
        {
            string sql;
            DataTable dt;
            //Lay thong tin loai the
            sql = string.Format("SELECT * FROM tbl_DM_LoaiThe_KhachHang WHERE IdLoaiThe={0}", pID);
            dt = ut.getDataTable(sql);
            if (dt.Rows.Count < 1) return false;
            id = ut.getInt(dt.Rows[0]["IdLoaiThe"]);
            maThe = dt.Rows[0]["MaThe"].ToString();
            tenThe = dt.Rows[0]["TenThe"].ToString();
            ghiChu = dt.Rows[0]["GhiChu"].ToString();
            dk_GiaTri_LanDau = ut.getDouble(dt.Rows[0]["dk_GiaTri_LanDau"]);
            dk_GiaTri_TichLuy_Tu = ut.getDouble(dt.Rows[0]["dk_GiaTri_TichLuy_Tu"]);
            dk_GiaTri_TichLuy_Den = ut.getDouble(dt.Rows[0]["dk_GiaTri_TichLuy_Den"]);
            dk_SanPham_KemTheo = dt.Rows[0]["dk_SanPham_KemTheo"].ToString();
            thoiGianHieuLuc = ut.getInt(dt.Rows[0]["thoiGianHieuLuc"]);
            doUuTien = ut.getInt(dt.Rows[0]["doUuTien"]);
            baoLuuDiem = ut.getDouble(dt.Rows[0]["baoLuuDiem"]);// *100;
            duocTangQuaSinhNhat = ut.getBool(dt.Rows[0]["duocTangQuaSinhNhat"]);
            duocBaoHanhVang = ut.getBool(dt.Rows[0]["duocBaoHanhVang"]);
            duocCapNhatSanPhamMoi = ut.getBool(dt.Rows[0]["duocCapNhatSanPhamMoi"]);
            duocThamGiaDaoTao = ut.getBool(dt.Rows[0]["duocThamGiaDaoTao"]);
            duocTuVanHoTro = ut.getBool(dt.Rows[0]["duocTuVanHoTro"]);
            suDung = ut.getBool(dt.Rows[0]["SuDung"]);
            
            //Lay Quyen loi
            lstQuyenLoi=LoaiThe_QuyenLoi.getLstQuyenLoi(pID);

            //Lay Uu dai
            lstUuDai=LoaiThe_UuDai.getLstUuDai(pID);
            return true;
        }
        public bool AddNew()
        {
            string lstField, lstValue, sql;
            lstField = ""; lstValue = "";
            ut.CreateStrInsert(ref lstField, ref lstValue, "maThe", maThe, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "tenThe", tenThe, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "ghiChu", ghiChu, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "dk_GiaTri_LanDau", dk_GiaTri_LanDau.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "dk_GiaTri_TichLuy_Tu", dk_GiaTri_TichLuy_Tu.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "dk_GiaTri_TichLuy_Den", dk_GiaTri_TichLuy_Den.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "dk_SanPham_KemTheo", dk_SanPham_KemTheo, true);
            ut.CreateStrInsert(ref lstField, ref lstValue, "thoiGianHieuLuc", thoiGianHieuLuc.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "doUuTien", doUuTien.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "baoLuuDiem", baoLuuDiem.ToString(), false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "duocTangQuaSinhNhat", (duocTangQuaSinhNhat) ? "1" : "0", false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "duocBaoHanhVang", (duocBaoHanhVang) ? "1" : "0", false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "duocCapNhatSanPhamMoi", (duocCapNhatSanPhamMoi) ? "1" : "0", false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "duocThamGiaDaoTao", (duocThamGiaDaoTao) ? "1" : "0", false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "duocTuVanHoTro", (duocTuVanHoTro) ? "1" : "0", false);
            ut.CreateStrInsert(ref lstField, ref lstValue, "SuDung", (suDung) ? "1" : "0", false);
            sql = string.Format("INSERT INTO tbl_DM_LoaiThe_KhachHang({0}) VALUES({1})", lstField.Trim(','), lstValue.Trim(','));
            sql += ";select @@Identity";
            int iID = ut.ExecuteSQL(sql);
            if (iID<1) return false;
            id = iID;

            //Update Quyen Loi
            foreach (LoaiThe_QuyenLoi tmp in lstQuyenLoi)
            {
                if (tmp.ThayDoi == 1)
                {
                    tmp.IdLoaiThe = id;
                    tmp.AddNew();
                }
                else if (tmp.ThayDoi == 2)//Sua
                    tmp.Update();
                else if (tmp.ThayDoi == 3)
                    tmp.Delete();
            }
            //Update UuDai
            foreach (LoaiThe_UuDai tmp in lstUuDai)
            {
                if (tmp.ThayDoi == 1)//Them
                {
                    tmp.IdLoaiThe = id;
                    tmp.AddNew();
                }
                else if (tmp.ThayDoi == 2)//Sua
                    tmp.Update();
                else if (tmp.ThayDoi == 3)//Xoa
                    tmp.Delete();
            }
            return true;
        }
        public void Update()
        {
            string stUpdate, sql;
            stUpdate = "";
            ut.CreateStrUpdate(ref stUpdate, "maThe", maThe, true);
            ut.CreateStrUpdate(ref stUpdate, "tenThe", tenThe, true);
            ut.CreateStrUpdate(ref stUpdate, "ghiChu", ghiChu, true);
            ut.CreateStrUpdate(ref stUpdate, "dk_GiaTri_LanDau", dk_GiaTri_LanDau.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "dk_GiaTri_TichLuy_Tu", dk_GiaTri_TichLuy_Tu.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "dk_GiaTri_TichLuy_Den", dk_GiaTri_TichLuy_Den.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "dk_SanPham_KemTheo", dk_SanPham_KemTheo, true);
            ut.CreateStrUpdate(ref stUpdate, "thoiGianHieuLuc", thoiGianHieuLuc.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "doUuTien", doUuTien.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "baoLuuDiem", baoLuuDiem.ToString(), false);
            ut.CreateStrUpdate(ref stUpdate, "duocTangQuaSinhNhat", (duocTangQuaSinhNhat) ? "1" : "0", false);
            ut.CreateStrUpdate(ref stUpdate, "duocBaoHanhVang", (duocBaoHanhVang) ? "1" : "0", false);
            ut.CreateStrUpdate(ref stUpdate, "duocCapNhatSanPhamMoi", (duocCapNhatSanPhamMoi) ? "1" : "0", false);
            ut.CreateStrUpdate(ref stUpdate, "duocThamGiaDaoTao", (duocThamGiaDaoTao) ? "1" : "0", false);
            ut.CreateStrUpdate(ref stUpdate, "duocTuVanHoTro", (duocTuVanHoTro) ? "1" : "0", false);
            ut.CreateStrUpdate(ref stUpdate, "SuDung", (suDung) ? "1" : "0", false);
            sql = "UPDATE tbl_DM_LoaiThe_KhachHang SET " + stUpdate.Trim(',') + " WHERE IdLoaiThe=" + id.ToString();
            ut.ExecuteSQL(sql);
            //Update Quyen Loi
            foreach (LoaiThe_QuyenLoi tmp in lstQuyenLoi)
            {
                if (tmp.ThayDoi == 1)
                {
                    tmp.IdLoaiThe = id;
                    tmp.AddNew();
                }
                else if (tmp.ThayDoi == 2)//Sua
                    tmp.Update();
                else if (tmp.ThayDoi == 3)
                    tmp.Delete();
            }
            //Update UuDai
            foreach (LoaiThe_UuDai tmp in lstUuDai)
            {
                if (tmp.ThayDoi == 1)
                {
                    tmp.IdLoaiThe = id;
                    tmp.AddNew();
                }
                else if (tmp.ThayDoi == 2)//Sua
                    tmp.Update();
                else if (tmp.ThayDoi == 3)
                    tmp.Delete();
            }
        }
        public void Delete(int IDLoaiThe)
        {
            string sql;
            //Xoa quyen loi
            sql = "DELETE FROM tbl_DM_LoaiThe_QuyenLoi WHERE IdLoaiThe=" + IDLoaiThe.ToString();
            ut.ExecuteSQL(sql);
            //Xoa uudai
            sql = "DELETE FROM tbl_DM_LoaiThe_UuDai WHERE IdLoaiThe=" + IDLoaiThe.ToString();
            ut.ExecuteSQL(sql);
            //Xoa LoaiThe
            sql = "DELETE FROM tbl_DM_LoaiThe_KhachHang WHERE IdLoaiThe=" + IDLoaiThe.ToString();
            ut.ExecuteSQL(sql);
            
            id = 0;
        }
 
    }
}
