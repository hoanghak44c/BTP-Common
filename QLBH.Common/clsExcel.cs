using System;
using System.Collections.Generic;
using QLBH.Common.Objects;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;


namespace QLBH.Common
{
    public class clsExcel
    {
        static Utils ut=new Utils();
        public static string ExportToExcel(BangGia BG, string FileName, string TemplateExcel, string maSP, string tenSP, int loaiSP)
        {
            System.Globalization.CultureInfo old = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            try
            {

                Application oXL;
                Workbook oWB;
                Worksheet oWS;
                Range rng;
                oXL = new Application();
                oWB = oXL.Workbooks.Open(TemplateExcel,
                         Missing.Value, false, Missing.Value, Missing.Value, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, true, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                oWS = (Worksheet)oWB.Worksheets[1];
                //Day noi dung ra bao cao
                int TT = 0; int DongIn = 8; int CotIn;
                List<ChiTietBangGia> lstCTBG;
                if (maSP.Trim()!="" || tenSP.Trim() != "" || loaiSP > 0)
                    lstCTBG=BG.LocSP(maSP,tenSP,loaiSP);
                else
                   lstCTBG= BG.LstSanPham;
                foreach (ChiTietBangGia ct in lstCTBG)
                {
                    TT++;
                    rng = oWS.get_Range("A" + Convert.ToString(DongIn+1), "Z" + Convert.ToString(DongIn+1));
                    rng.Insert(XlInsertShiftDirection.xlShiftDown, XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                    CotIn = 1; oWS.Cells[DongIn, CotIn] = TT;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.MaSanPham;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.TenSanPham;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.GiaNhap;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.GiaBan;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.CK;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.TienCK;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.VAT;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.TienVAT;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.TyLeThuong;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.ThuongNong;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.ThanhTien;
                    CotIn++; oWS.Cells[DongIn, CotIn] = ct.KhuyenMaiMa;
                    //CotIn++; oWS.Cells[DongIn, CotIn] = ct.KhuyenMai;
                    DongIn++;
                 }
                //Dien noi dung tieu de
                rng = (Range)oWS.get_Range("A1", "Z6");
                rng.Replace("##SoBangGia", BG.SoBangGia, Missing.Value, Missing.Value, false, false, Missing.Value, Missing.Value);
                rng.Replace("##NgayKy", BG.NgayKy, Missing.Value, Missing.Value, false, false, Missing.Value, Missing.Value);
                rng.Replace("##NguoiKy", BG.NguoiKy, Missing.Value, Missing.Value, false, false, Missing.Value, Missing.Value);
                rng.Replace("##NgayHieuLuc", BG.NgayLap, Missing.Value, Missing.Value, false, false, Missing.Value, Missing.Value);
                rng.Replace("##GhiChu", BG.GhiChu, Missing.Value, Missing.Value, false, false, Missing.Value, Missing.Value);

                //Save file
                oWB.SaveAs(FileName, XlFileFormat.xlWorkbookNormal, null, null, false, false,
                            XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                oXL.Quit();
                System.Threading.Thread.CurrentThread.CurrentCulture = old;
                return FileName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                System.Threading.Thread.CurrentThread.CurrentCulture = old;
                return "";
            }
            
            System.Threading.Thread.CurrentThread.CurrentCulture = old;
        }
        public static string ImportFromExcels(BangGia BG, string FileName,KetQuaImportBangGia ResultImport)
        {
            System.Globalization.CultureInfo old = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            try
            {

                Application oXL;
                Workbook oWB;
                Worksheet oWS;
                Range rng;
                oXL = new Application();
                oWB = oXL.Workbooks.Open(FileName,
                         Missing.Value, false, Missing.Value, Missing.Value, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, true, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                oWS = (Worksheet)oWB.Worksheets[1];
                //Doc du lieu tu dong 8
                int DongIn = 8, CotIn, ID, tt = BG.LstSanPham.Count;
                Utils.SoKhuyenMaiTT = 0;

                ChiTietBangGia tmpct,ct;
                KetQuaImportBangGiaChiTiet kqCT;
                List<KhuyenMai> lstKMtmp;
                bool FoundCT;
                string MaSP = ut.getString(((Range)oWS.Cells[DongIn, 2]).Text);
                while (MaSP.Trim() != "")
                {
                    //Kiem tra maSP co ton tai
                    ID = ut.fGetID_sql(string.Format("SELECT IdSanPham FROM tbl_SanPham WHERE MaSanPham=N'{0}' and SuDung=1 ", MaSP));
                    if (ID == 0)
                    {
                        ResultImport.SLLoi++;
                        kqCT = new KetQuaImportBangGiaChiTiet();
                        kqCT.MaSanPham = MaSP;
                        kqCT.TenSanPham = ut.getString(((Range)oWS.Cells[DongIn, 3]).Text);
                        kqCT.LyDo = "Không có hàng trong danh mục hóa hoặc hàng đang bị inactive";
                        ResultImport.LstLoi.Add(kqCT);
                    }
                    if (ID > 0)
                    {
                        ResultImport.SLThanhCong++;
                        //Kiem tra xem sp da co trong bang gia chua
                        tmpct=BG.FindSanPham(ID);
                        FoundCT=(tmpct!=null);
                        if (!FoundCT)
                        {
                            ct = new ChiTietBangGia();
                            tt++; ct.TT = tt;
                            ct.IdSanPham = ID;
                            ct.IdChiTiet = 0;
                        }
                        else
                        {
                            ct=tmpct;
                            ct.ThayDoi = 2;
                        }
                        CotIn = 2; ct.MaSanPham = MaSP;
                        CotIn++; ct.TenSanPham = ut.getString(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.GiaNhap = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.GiaBan = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.CK = ut.getDouble1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.TienCK = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.VAT = ((Range)oWS.Cells[DongIn, CotIn]).Text.Equals("") ? -1 : ut.getDouble1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.TienVAT = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.TyLeThuong = ut.getDouble1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.ThuongNong = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.ThanhTien = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        //Lay khuyen mai tu xau \1900113/10000\1900112(2);/20000
                        CotIn++;  lstKMtmp=GetLstKhuyenMai(ut.getString(((Range)oWS.Cells[DongIn, CotIn]).Text));
                        //if ((lstKMtmp.Count > 0 && FoundCT) || (!FoundCT))
                        //{
                        //    ct.LstKhuyenMai = lstKMtmp;
                        //    ct.KhuyenMai = ct.GetKhuyenMaiTheoChiTiet();
                        //}
                        ct.LstKhuyenMai = lstKMtmp;
                        string KMMa = "";
                        if (lstKMtmp.Count > 0)
                            ct.KhuyenMai = ct.GetKhuyenMaiTheoChiTiet(ref KMMa);
                        else
                            ct.KhuyenMai = "";
                        ct.KhuyenMaiMa = KMMa;

                        ID = ut.fGetID_sql(string.Format("SELECT IdCha FROM tbl_SanPham WHERE MaSanPham=N'{0}'", MaSP));
                        ct.LoaiSanPham = ID;

                        //Them vao bang gia
                        if (!FoundCT)
                        {
                            BG.LstSanPham.Add(ct);
                        }
                    }
                    DongIn++;
                    MaSP = ut.getString(((Range)oWS.Cells[DongIn, 2]).Text);
                }
                oWB.Close(null, null, null);
                oXL.Quit();
                System.Threading.Thread.CurrentThread.CurrentCulture = old;
                return FileName;
            }
            catch (Exception e)
            {
#if DEBUG
                MessageBox.Show("Lỗi ngoại lệ: " + e.ToString(), Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
                MessageBox.Show("Lỗi ngoại lệ: " + e.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                System.Threading.Thread.CurrentThread.CurrentCulture = old;
                return "";
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = old;
        }
        public static string ImportFromExcel(BangGia BG, string FileName)
        {
            System.Globalization.CultureInfo old = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            try
            {

                Application oXL;
                Workbook oWB;
                Worksheet oWS;
                Range rng;
                oXL = new Application();
                oWB = oXL.Workbooks.Open(FileName,
                         Missing.Value, false, Missing.Value, Missing.Value, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, true, Missing.Value,
                         Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                oWS = (Worksheet)oWB.Worksheets[1];
                //Doc du lieu tu dong 8
                int DongIn = 8,CotIn,ID,tt=0;
                List<ChiTietBangGia> lstCTBG=new List<ChiTietBangGia>();
                ChiTietBangGia ct;
                Utils.SoKhuyenMaiTT=0;
                string MaSP = ut.getString(((Range)oWS.Cells[DongIn, 2]).Text);
                while (MaSP.Trim() != "")
                {
                    //Kiem tra maSP co ton tai
                    ID=ut.fGetID_sql(string.Format("SELECT IdSanPham FROM tbl_SanPham WHERE MaSanPham=N'{0}' and SuDung=1 ",MaSP));
                    if (ID > 0)
                    {
                        ct = new ChiTietBangGia();
                        tt++; ct.TT = tt;
                        ct.IdSanPham = ID;
                        CotIn = 2; ct.MaSanPham = MaSP;
                        CotIn++; ct.TenSanPham = ut.getString(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.GiaNhap = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.GiaBan = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.CK = ut.getDouble1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.TienCK = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        //CotIn++; ct.VAT = ut.getDouble1(((ComExcel.Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.VAT = ((Range)oWS.Cells[DongIn, CotIn]).Text.Equals("") ? -1 : ut.getDouble1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.TienVAT = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.TyLeThuong = ut.getDouble1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.ThuongNong = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        CotIn++; ct.ThanhTien = ut.getDoubleInt1(((Range)oWS.Cells[DongIn, CotIn]).Text);
                        //Lay khuyen mai tu xau \1900113/10000\1900112(2);/20000
                        CotIn++; ct.LstKhuyenMai=GetLstKhuyenMai(ut.getString(((Range)oWS.Cells[DongIn, CotIn]).Text));
                        string KMMa = "";
                        ct.KhuyenMai = ct.GetKhuyenMaiTheoChiTiet(ref KMMa);
                        ct.KhuyenMaiMa = KMMa;
                        ct.IdChiTiet = 0;
                        ID = ut.fGetID_sql(string.Format("SELECT IdCha FROM tbl_SanPham WHERE MaSanPham=N'{0}'", MaSP));
                        ct.LoaiSanPham = ID;
                        lstCTBG.Add(ct);
                    }
                    DongIn++;
                    MaSP = ut.getString(((Range)oWS.Cells[DongIn,2]).Text);
                }
                //BG = new BangGia();
                BG.LstSanPham = lstCTBG;
                oWB.Close(null, null, null);
                oXL.Quit();
                return FileName;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return "";
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = old;
        }
        static List<KhuyenMai> GetLstKhuyenMai(string stKhuyenMai)//\1900113/10000\1900112(2)
        {
            List<KhuyenMai> lstKM=new List<KhuyenMai>();
            KhuyenMai KM;
            ChiTietKhuyenMai ct;
            string[] arrKhuyenMai = stKhuyenMai.Split(';');
            bool loi;int vtDauMoNgoac;
            //bool laTien, loi; int dau, cuoi, vtDauMoNgoac;
            string GiaTri,MaSP,sql;
            int SoLuong;
            DataTable dt;

            foreach(string st in arrKhuyenMai)
            {
                KM=new KhuyenMai();
                KM.SoKhuyenMai=LaySoPhieu();
                KM.MoTa="";
                //dau=0;
                string[] arrKM = st.Split('\\');//chia cac san pham khuyen mai
                for (int i = 0; i < arrKM.Length; i++)
                {
                    if (arrKM[i] == "") continue;
                    string[] arrCTKM = arrKM[i].Split('/');
                    double tienKM = 0;
                    GiaTri = arrCTKM[0];
                    if (arrCTKM.Length>1)
                        tienKM = ut.getDoubleInt(arrCTKM[1]);

                    ct = new ChiTietKhuyenMai(); loi = false;
                    vtDauMoNgoac = GiaTri.IndexOf('(');
                    if (vtDauMoNgoac > 0)
                    {
                        MaSP = GiaTri.Substring(0, vtDauMoNgoac);
                        SoLuong = ut.getInt(GiaTri.Substring(vtDauMoNgoac + 1, GiaTri.Length - vtDauMoNgoac - 2));
                    }
                    else
                    {
                        MaSP = GiaTri;
                        SoLuong = 1;
                    }
                    if (MaSP != "")
                    {
                        sql = string.Format(@"SELECT     dbo.tbl_SanPham.IdSanPham, dbo.tbl_SanPham.MaSanPham, dbo.tbl_SanPham.TenSanPham, dbo.tbl_DM_DonViTinh.TenDonViTinh
                            FROM         dbo.tbl_SanPham INNER JOIN  dbo.tbl_DM_DonViTinh ON dbo.tbl_SanPham.IdDonViTinh = dbo.tbl_DM_DonViTinh.IdDonViTinh
                            WHERE     (dbo.tbl_SanPham.MaSanPham = N'{0}')", MaSP);
                        dt = ut.getDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            ct.IdSanPham = ut.getInt(dt.Rows[0]["IdSanPham"]);
                            ct.MaSanPham = ut.getString(dt.Rows[0]["MaSanPham"]);
                            ct.TenSanPham = ut.getString(dt.Rows[0]["TenSanPham"]); ;
                            ct.DonViTinh = ut.getString(dt.Rows[0]["TenDonViTinh"]); ;
                            ct.SoLuong = SoLuong;
                            ct.TienKM = tienKM;
                        }
                        else
                            loi = true;
                    }
                    else
                    {
                        if (tienKM == 0)
                            loi = true;
                        else
                        {
                            ct.IdSanPham = 0;
                            ct.MaSanPham = "";
                            ct.TenSanPham = "";
                            ct.DonViTinh = "";
                            ct.SoLuong = 1;
                            ct.TienKM = tienKM;
                        }
                    }
                    if (!loi)
                        KM.LstSanPham.Add(ct);
                }


//                while (dau < st.Length)
//                {
//                    laTien = (st[dau] == '/');
//                    cuoi = dau + 1;
//                    while (cuoi < st.Length)
//                        if (st[cuoi] != '\\' && st[cuoi] != '/')
//                            cuoi++;
//                        else
//                            break;
//                    GiaTri = st.Substring(dau + 1, cuoi - dau - 1);
//                    ct = new ChiTietKhuyenMai(); loi = false;
//                    #region Lay gia tri vao ct
//                    if (laTien)
//                    {
//                        if (ut.getDouble(GiaTri) <= 0)
//                            loi = true;
//                        else
//                        {
//                            ct.IdSanPham = 0;
//                            ct.MaSanPham = "";
//                            ct.TenSanPham = "";
//                            ct.DonViTinh = "";
//                            ct.SoLuong = 0;
//                            ct.TienKM = ut.getDouble(GiaTri);
//                        }
//                    }
//                    else
//                    {
//                        vtDauMoNgoac = GiaTri.IndexOf('(');
//                        if (vtDauMoNgoac > 0)
//                        {
//                            MaSP = GiaTri.Substring(0, vtDauMoNgoac);
//                            SoLuong = ut.getInt(GiaTri.Substring(vtDauMoNgoac + 1, GiaTri.Length - vtDauMoNgoac - 2));
//                        }
//                        else
//                        {
//                            MaSP = GiaTri;
//                            SoLuong = 1;
//                        }
//                        sql = string.Format(@"SELECT     dbo.tbl_SanPham.IdSanPham, dbo.tbl_SanPham.MaSanPham, dbo.tbl_SanPham.TenSanPham, dbo.tbl_DM_DonViTinh.TenDonViTinh
//                            FROM         dbo.tbl_SanPham INNER JOIN  dbo.tbl_DM_DonViTinh ON dbo.tbl_SanPham.IdDonViTinh = dbo.tbl_DM_DonViTinh.IdDonViTinh
//                            WHERE     (dbo.tbl_SanPham.MaSanPham = N'{0}')", MaSP);
//                        dt = ut.getDataTable(sql);
//                        if (dt.Rows.Count > 0)
//                        {
//                            ct.IdSanPham = ut.getInt(dt.Rows[0]["IdSanPham"]);
//                            ct.MaSanPham = ut.getString(dt.Rows[0]["MaSanPham"]);
//                            ct.TenSanPham = ut.getString(dt.Rows[0]["TenSanPham"]); ;
//                            ct.DonViTinh = ut.getString(dt.Rows[0]["TenDonViTinh"]); ;
//                            ct.SoLuong = SoLuong;
//                            ct.TienKM = 0;
//                        }
//                        else
//                            loi = true;
//                    }
//                    #endregion
//                    if (!loi)
//                        KM.LstSanPham.Add(ct);
//                    dau = cuoi;
//                }
                if (KM.LstSanPham.Count > 0)
                {
                    lstKM.Add(KM);
                    string Mau = string.Format("{0}-{1:00}/{2}-", ut.LayKyHieuThamSo("KM"), DateTime.Today.Month, DateTime.Today.Year);
                    Utils.SoKhuyenMaiTT = ut.getInt(KM.SoKhuyenMai.Substring(Mau.Length + 1));
                }
            }
            return lstKM;
        }
        private static string LaySoPhieu()
        {
            string Mau = string.Format("{0}-{1:00}/{2}-", ut.LayKyHieuThamSo("KM"), DateTime.Today.Month, DateTime.Today.Year);
            int STT = Utils.SoKhuyenMaiTT;
            if (STT == 0)
            {
                DataTable dt = ut.getDataTable(string.Format("SELECT top 1 SoKhuyenMai FROM tbl_KhuyenMai Where SoKhuyenMai Like N'{0}%' ORDER BY SoKhuyenMai DESC", Mau));
                if (dt.Rows.Count > 0)
                {
                    STT = ut.getInt(dt.Rows[0][0].ToString().Substring(Mau.Length + 1));
                }
            }
            return string.Format("{0}{1:0000}", Mau, STT + 1);
        }
    }
}
