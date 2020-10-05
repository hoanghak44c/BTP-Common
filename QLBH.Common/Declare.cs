// <summary>
// Mô tả class: Lớp đối tượng khai báo các biến Message dùng chung trong hệ thống
// </summary>
// <remarks>
// Người tạo: Nguyen Gia Dang
// Ngày tạo: 03/10/2007
// </remarks>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;
using QLBH.Common.Providers;

namespace QLBH.Common
{
    public class Declare
    {
        #region "Khai báo các biến dùng chung"

        public const string CrmSchema = "CRM";
        public static int IdTrungTam = 0;
        public static int IdTrungTamHachToan = 0;
        public static string TenTrungTam = "";
        public static string MaTrungTam = "";
        public static string DienThoaiTrungTam = "";
        public static int IdKho = 0; //loai kho mac dinh
        public static string TenKho = "";
        public static int IdLoaiKhachHang = 0; //loai khach hang mac dinh
        public static int IdKHMacDinh = 0;
        public static string TenKhachHang = "";
        public static int IdThoiHanThanhToan = 0; //loai khach hang mac dinh
        public static int IdTruongCa = 0;
        public static int IdThuNgan = 0;
        public static int IdQuanLyTrucTiep = -1;
        public static string LstOthersTrungTam = "";
        public static int LogIn = 0; //0-bat dau chuong trinh; 1-chua login; 2-da login
        public static int IdTienTe = 0;
        public static string KyHieuTienTe = "VNĐ";
        public static double TyleVATMacDinh = 0;
        public static int SoHoaDon_Quyen = 100;
        public static string TempDirectory = Common.GetValue("TEMP_DIRECTORY", Application.StartupPath + "\\Temp");
        public static string WEBSERVICE_URL = "";
        public static string WEBSERVICE_NAME = "SERVICE";
        public static string CHUAN_MAVACH = "Code 128";
        public static int TyLeChenhGiaNhap_Xuat = 0; //%
        public static int MAXMAVACH_SANPHAM = 4; //9999 ma vach cho 1 loai san pham
        public static int MAXSOPHIEU = 4; //9999 giao dich mot ngay
        public static string MAVUNG = "01";
        public static List<string> ListCN = new List<string>();
        public static int CaBanHang = Common.IntValue(Common.GetValue("GIAO_CA", "15"));
        public static int DoDaiHoaDon = Common.IntValue(Common.GetValue("HOADON_LENGTH", "7"));
        public static string SMTPServer = "smtp.gmail.com";
        public static int SMTPPort = 587;
        public static string SMTPAccount = "gtidtest@gmail.com";
        public static string SMTPPassword = "0102280892";
        public static bool SSL = true;
        public static string Signature = "";
        public static int LENGH_HT = 55;
        public static int LENGH_NOTE = 150;
		public static double CurrentVersion = 20150613155910;
        public const string APP_VERSION = "GOLIVE";
        public static DateTime GoliveDate = new DateTime(2013, 5, 1);
        public static string PathToLoadFile = "http://10.1.12.70/update";
        public static string SAPARATOR = "~";
        public static string LastMDIChildAction = String.Empty;
        public const string DateMinValue = "01/01/1753 12:00:00 AM";
        public const string OrderTypeBan = "HD_HH_O";
        public const string OrderTypeTraLai = "HL_HH_O";
        public const int MaxSoLuongMaVach = 5;
        public const int NHOM_GIAM_DOC_SIEU_THI = 535;
        public const int NHOM_TRUONG_CSKH = 658;
        public const bool GiaoNhanCungKhachHang = true;
        public const int MauHoaDon = 0;
        public const string HangBaoHanhDefault = "SAMSUNG";
        // Khai báo hằng số hệ thống
        public static bool MULTI_USER_SESSION = true;//cho phép 1 user đăng nhập 1 hay nhiều máy
        public static bool IS_SUPPER_USER = true;//cho phép 1 user đăng nhập 1 hay nhiều máy
        public static string LICENSE = "Phiên bản ";
        public static Object USER_INFOR;//lưu thông tin user đăng nhập
        public static int SOLUONG_TIMKIEM = 50;
        public static int SOLUONG_HIENTHI_TON = 20;
        public static int CHIEUDAI_TENHANG = 90;//dung de in phieu thu
        public static string LstNotInHoaDon = ";001.0001.2;";//ma hang ko phai chietkhau nhung ko len khi in hoa don
        public static string LstSuaGiaBan = ";091.0253.3833;091.0253.41133;001.0001.46184;246.0853.22206;091.0253.23945;001.0000.23946;";//ma hang ban co ton duoc sua gia ban = 0
        public static string LstSuaCKhauKoLenODT = ";001.0000.23946;091.0253.23945;246.0853.22206;246.0853.49356;246.0853.49357;246.0853.49358;246.0853.49359;";//ma hang chiet khau duoc sua gia ban khong cho len ODT
        public static string LstSuaCKhauKoLenOD = ";001.0000.23946;";//ma hang ban bat ky duoc sua gia ban cac don hang khac DT, OL ma khong phai OD
        public static string LstKMDuocBanOD = ";001.0001.2;";//ma hang khuyen mai duoc ban tren don hang
        public static string LstTrungTamNotDefault = ";1;";//trung tam khong an theo chinh sach gia: bao hanh
        public static string LstTrungTamADChinhSachThe = ";1;4;6;";//trung tam ap dung chinh sach the
        public static int TimeToSearch = 7;//cho phep nguoi dung binh thuong nhin du lieu trong vong 7 ngay
        public static bool IS_CHINHSACH_KHO = false;//cho phép áp dụng chính sách riêng lẻ theo kho
        public static bool IS_CHINHSACH_KHACHHANG = true;//cho phép áp dụng chính sách riêng lẻ theo khách hàng
        public static bool IS_APDUNG_DIEMTHUONG_MACDINH = true;//cho phép áp dụng diem thuong mac dinh hay khong neu khong co chinh sach diem thuong
        //cbo.Datasource = ((NguoiDungInfor)Declare.USER_INFOR).KhoNguoiDung;
        public static Hashtable FORM_STATUS = new Hashtable();//lưu trạng thái của form bán hàng: có sửa => load lại, ko thì thôi   
        public static double HE_SO_DOI_TIEN_RA_DIEM = 1;//He so doi tien ra diem: 1 dong duoc 1 diem
        public static double HE_SO_DOI_DIEM_RA_TIEN = 1;//He so doi tien ra diem: 1 diem duoc 1 dong
        public static double GIA_TRI_MAX_DOI_TIEN = 40;//toi da 40% gia tri don hang
        public static string MA_DOI_DIEM = "MADOIDIEM";
        public static string TEN_DOI_DIEM = "Mã đổi điểm thẻ thành viên";
        public static double GIA_TRI_TANG = 10000;
        public static string MA_HOAN_TIEN = "MAHOANTIEN";
        public static string TEN_HOAN_TIEN = "Mã hoàn tiền do quy điểm thưởng bị âm";
        public static int DO_DAI_SO_THE = 8;
        public static int DO_DAI_MA_VACH_THE = 20;
        public static int INTERVAL_RANDOM = int.MaxValue;//khoang gia tri de sinh so random 2,147,483,647
        public static DateTime THOI_GIAN_TICH_DIEM = new DateTime(2015,5,11);//ngay chay module the
        public static string REG_ORG = "0W6gK1BhcZOV8comBOOqBnxu3VnF2nf/9iZXO134lh06fjewAK3dCk1gmHOeJUECfRItpN11SXdbmTViX/k5/bHrm/TCVcgx6s7MWq7waBCNfqSBnAwr7/0OnHXnSBcmg+bxtSNJ3oMM6u/37W6jmlajSchYetJ6JT5FVx0Bb4o=";

        public static string REG_ID = "jTGzRsXNOs1CZugDHHWtsyLPm49EC2tNiZwFm61yvmreV8MmyB/1UP13PH70Zbb9NpUU7+7gvmNgWQIUil0mHz4M2M3XsTo0X4dbO2ECARVjX62xegFBLCkegnPLIpcl";
        //public static bool ENABLE_THE_THANH_VIEN = false;//ap dung chinh sach the hay khong
        //public static bool ENABLE_DOI_DIEM_TIEN = false;//cho phep doi diem ra tien khong
        #endregion

        #region "Các hằng số"

        public static int UserId = 4;
        public static bool IsRegister = false;
        public static bool IsEnterprise = true;//Enterprise: day du chuc nang, Standard: bo chuc nang: dieu chuyen, thu chi, cong no
        public static double NumDayExpire = 60;
        public static string FullName = "Nguyễn Gia Đăng";
        public static string UserName = "ngdang";
        public static string Password = "23-62-92-08-F1-6F-6A-6A-C1-A3-31-53-CA-9B-D4-F6-74-A8-FA-8C";
        public static string Salt = "P1iNmBJu0HIf";
        public static string GroupCode = "Admin";
        public static int IdNhanVien = -1;
        public static string MaNhanVien = "";
        public static string TenNhanVien = "";
        public static string ORG_CODE = Common.GetValue("ORG_CODE", "-1");
        public static string MONEY_TYPE = Common.GetValue("MONEY_TYPE", "-1");
        public static DateTime SYSDATE;
        public static bool TUDONG_DUYETGIA = true;
        public static string DescHangBan = "Sản phẩm chính";
        public static string DescHangKem = "Sản phẩm mua kèm";
        public static string DescKhuyenMai = "Khuyến mại";
        public static string DescGiaoNhan = "Giao nhận";
        public static int THOIGIAN_TONKHO = 5;//lay so ton kho lau nhat
        public static int Authenticating;
        public static int LOGIN_TIMEOUT = 15;
        public static int EXIT_TIMEOUT = 30;
        public static DateTime LastAction;
        //tuy chon nguoi dung
        public static bool InBill = true;
        public static bool InHoaDon = true;
        public static bool InPhieuThu = false;
        public static bool HienThiChonKho = false;
        public static string GiaoDienMacDinh = "";
        //quyen nguoi dung truy cap
        public static int QuyenNguoiDung;
        //
        public static string TenMay = WindowsIdentity.GetCurrent().Name.ToString();

        //chu y: khong set gia tri o day
        public static DateTime NgayLamViec;
        public static DateTime NgayKhoaSo;
        public static DateTime NgayDuDau;

        //public static DateTime NgayLamViec = System.DateTime.Now.AddDays(-CommonProvider.Instance.GetSysDate().Day + 1);
        //public static DateTime NgayKhoaSo = CommonProvider.Instance.GetSysDate();
        //public static DateTime NgayDuDau = CommonProvider.Instance.GetSysDate();//DateTime.Parse(SqlDateTime.MinValue.ToString());

        public static string CONFIG_FILE = @"../../app.config";
        public static string ROOT_PATH = @"/configuration/appSettings";
        public static string AppPath = Common.GetAppFolderPath();
        public static string RegistryPath = @"HKEY_LOCAL_MACHINE\Software\QLBH_TA\Infor";
        public static string HelpFilePath = Application.StartupPath + "\\Help\\HDSD_QLBH.chm";

        public static string titleNotice = "Thông báo";
        public static string titleWarning = "Cảnh báo";
        public static string titleError = "Lỗi";

        public static string msgRemoveData = "Có chắc xoá dữ liệu này?";
        public static string msgSelectToRemove = "Hãy chọn dữ liệu để xóa";
        public static string msgSelectToEdit = "Hãy chọn dữ liệu để xóa";
        public static string msgChangeStoreData = "Thay đổi kho xuất sẽ phải nhập lại toàn bộ dữ liệu! Bạn có chắc chắn muốn thay đổi kho?";

        public static string msgExistData = "Dữ liệu này đã tồn tại. Hãy nhập lại";
        public static string msgInputData = "Nhập dữ liệu vào";
        public static string msgSavedData = "Đã ghi dữ liệu!";
        public static string msgSavedKho = "Đã cập nhật kho hiện tại!";

        public static string msgUpdateErr = "Có lỗi khi cập nhật dữ liệu. Hãy kiểm tra lại!";
        public static string msgDeleteErr = "Có lỗi khi xóa dữ liệu. Hãy kiểm tra lại!";
        public static string msgInsertErr = "Có lỗi trong khi thêm mới!";
        public static string msgUpdateSucc = "Cập nhật thành công!";
        public static string msgInsertSucc = "Thêm mới thành công!";
        public static string msgDeleteSucc = "Xóa thành công!";
        public static string msgNoDataToPrint = "Không có dữ liệu. Chọn báo cáo khác để in!";

        //Phạm Ngọc Minh
        public static string msgAskDraft =
            "Khi thực hiện xác nhận phiếu này, bạn không thể chỉnh sửa lại được, bạn có muốn tiếp tục không?";

        public static string msgDraftDeleteFalse =
            "Phiếu này đã được Confim, không thể xóa!";
        public static string msgDraftUpdateFalse =
            "Phiếu này đã được Confim, không thể chỉnh sửa!";

        /// <summary>
        /// Phạm ngọc minh 
        /// Cảnh báo của bảo hành
        /// </summary>
        public const int BHHanCanhBao = 2;

        public static Color BHQuaHanDamPhan = Color.Yellow;
        public static Color BHDenHanDamPhan = Color.Red;

        public static Color BhDaXacNhan = Color.Blue;
        public static Color BhChuaXacNhan = Color.Yellow;
        public static Color BhHuyXacNhan = Color.Red;

        public static string msgLoadDataWrn = "Xem toàn bộ dữ liệu có thể làm chậm hệ thống. Bạn có đồng ý thực hiện không?";
        public static string msgLoadDataErr = "Có lỗi khi lấy dữ liệu!";
        public static string msgChangedPass = "Đã thay đổi mật khẩu!";
        public static string msgInValidDataType = "Sai kiểu dữ liệu. Hãy nhập lại!";
        public static string msgValidateEmail = "Email không đúng định dạng";
        public static string msgValidateWebsite = "Website không đúng định dạng";
        public static string msgLoiNgoaiLe = "Lỗi ngoại lệ:";

        //Dung cho frmDM_Chung
        public static string msgFrmDM_Chung_MaChuaNhap = "Mã chưa nhập";
        public static string msgFrmDM_Chung_MaChungMa = "Mã này đã tồn tại";
        public static string msgFrmDM_chung_TenChuaNhap = "Chưa nhập tên";
        public static string msgFrmDM_chung_ThemMoiThanhCong = "Thêm mới danh mục thành công";
        public static string msgFrmDM_chung_SuaThanhCong = "Cập nhật danh mục thành công";
        public static string msgFrmDM_chung_XoaThanhCong = "Xóa danh mục thành công";
        public static string msgFrmDM_Chung_KhongXoa = "Dòng thông tin danh mục này đã sử dụng. Nên không thể xóa";

        //Dung cho frmDM_NhaCC_NhaSX
        public static string msgfrmDM_NhaCC_NhaSX_MaChuaNhap = "Mã chưa nhập";
        public static string msgfrmDM_NhaCC_NhaSX_MaChungMa = "Mã này đã tồn tại";
        public static string msgfrmDM_NhaCC_NhaSX_TenChuaNhap = "Chưa nhập tên";
        public static string msgfrmDM_NhaCC_NhaSX_DiaChiChuaNhap = "Chưa nhập địa chỉ";
        public static string msgfrmDM_NhaCC_NhaSX_QuocGiaChuaNhap = "Chưa nhập quốc gia";
        public static string msgfrmDM_NhaCC_NhaSX_DienThoaiChuaNhap = "Chưa nhập điện thoại";

        //Dung cho frmDM_KhachHang
        public static string msgfrmDM_KhachHang_MaChuaNhap = "Mã khách hàng chưa nhập";
        public static string msgfrmDM_KhachHang_MaChungMa = "Mã khách hàng này đã có. Hãy nhập lại";
        public static string msgfrmDM_KhachHang_TenChuaNhap = "Chưa nhập tên khách hàng";
        public static string msgfrmDM_KhachHang_KhongXoa = "Thông tin của khách hàng này đã được sử dụng. Nên không thể xóa";

        //Dung cho frm_HopDong
        public static string msgfrmHopDong_MaChuaNhap = "Số hợp đồng chưa nhập";
        public static string msgfrmHopDong_MaChungMa = "Số hợp đồng này đã có. Hãy nhập lại";
        public static string msgfrmHopDong_TenChuaNhap = "Chưa nhập tên hợp đồng";
        public static string msgfrmHopDong_KhongXoa = "Thông tin của hợp đồng này đã được sử dụng. Nên không thể xóa";

        public static string msgLogin_InputUserName = "Bạn chưa điền tên đăng nhập!";
        public static string msgLogin_InputPassword = "Bạn chưa gõ mật khẩu!";
        public static string msgLogin_UserNotExist = "Không có người dùng này";
        public static string msgLogin_WrongPassword = "Mật khẩu không đúng. Hãy nhập lại!";
        public static string msgLogin_Error = "Lỗi kết nối CSDL. Xem lại thông tin kết nối!";
        public static string msgLogin_UserHasLoggedIn = "Tài khoản này đang được sử dụng trong hệ thống!";

        //Dung cho form ChangePass
        public static string msgChangePass_WrongPassword = "Mật khẩu không đúng. Hãy nhập lại!";
        public static string msgChangePass_RetypePass = "Xác nhận lại mật khẩu";
        public static string msgChangePass_PassHasChanged = "Mật khẩu đã được thay đổi!";

        //Dung cho frmDM_Thuoc
        public static string msgfrmDM_Thuoc_MaChuaNhap = "Mã thuốc chưa nhập";
        public static string msgfrmDM_Thuoc_MaChungMa = "Mã thuốc này đã có. Hãy nhập lại mã thuốc";
        public static string msgfrmDM_Thuoc_TenThuocChuaNhap = "Tên thuốc chưa nhập";
        public static string msgfrmDM_Thuoc_ChuaNhapDonViTinh = "Đơn vị tính thuốc chưa nhập";
        public static string msgfrmDM_Thuoc_ChuaNhapLoaiThuoc = "Loại thuốc chưa nhập";
        public static string msgfrmDM_Thuoc_ChuaNhapNhaSanXuat = "Chưa nhập nhà sản xuất";
        public static string msgfrmDM_Thuoc_TyLeThueSaiKieuDuLieu = "Tỷ lệ thuế không phải là dạng số. Hãy xem lại";
        public static string msgfrmDM_Thuoc_GiaBanBuonSaiKieu = "Gia bán buôn phải là dạng số";
        public static string msgfrmDM_Thuoc_GiaBanBuonLeSaiKieu = "Gia bán lẻ phải là dạng số";
        public static string msgfrmDM_Thuoc_ThemMoiThanhCong = "Lưu thuốc mới thành công";
        public static string msgfrmDM_Thuoc_SuaThanhCong = "Cập nhật thuốc thành công";
        public static string msgfrmDM_Thuoc_XoaThanhCong = "Xóa thuốc thành công";

        //Dung cho dlgChiTietPhieuXuat
        public static string msgdlgChiTietPhieuXuat_ChuaNhapThuoc_Ma = "Mã thuốc chưa nhập";
        public static string msgdlgChiTietPhieuXuat_ChuaNhapThuoc_Ten = "Tên thuốc chưa nhập";
        public static string msgdlgChiTietPhieuXuat_DonViTinhChuaNhap = "Đơn vị tính chưa nhập";
        public static string msgdlgChiTietPhieuXuat_HSChuyenDoiSaiKieu = "Hệ số chuyển đổi phải có dạng số";
        public static string msgdlgChiTietPhieuXuat_HSChuyenDoiChuaNhap = "Chưa nhập hệ số chuyển đổi";
        public static string msgdlgChiTietPhieuXuat_HSChuyenDoiKhongAm = "Hệ số chuyển đổi phải là một số dương lớn hơn băng 1";
        public static string msgdlgChiTietPhieuXuat_SoLuongSaiKieu = "Số lượng phải có dạng số";
        public static string msgdlgChiTietPhieuXuat_SoLuongChuaNhap = "Số lượng chưa nhập";
        public static string msgdlgChiTietPhieuXuat_SoLuongKhongAm = "Số lượng phải là một số dương";
        public static string msgdlgChiTietPhieuXuat_DonGiaSaiKieu = "Đơn giá phải có dạng số";
        public static string msgdlgChiTietPhieuXuat_DonGiaChuaNhap = "Chưa nhập đơn giá";

        //Dung cho frmPhieuXuat
        public static string msgfrmPhieuXuat_ChuaNhapSoPhieu = "Chưa nhập số phiếu xuất";
        public static string msgfrmPhieuXuat_ChungSoPhieu = "Số phiếu xuất này đã có. Hãy nhập lại";
        public static string msgfrmPhieuXuat_ChuaNhapNgayXuat = "Chưa nhập ngày xuất";
        public static string msgfrmPhieuXuat_NhapSaiNgayXuat = "Nhập sai ngày";
        public static string msgfrmPhieuXuat_ChuaNhapKhoXuat = "Chưa nhập kho xuất";
        public static string msgfrmPhieuXuat_ChuaNhapKhachHang = "Chưa nhập khách hàng";
        public static string msgfrmPhieuXuat_ChuaNhapNhanVien = "Chưa nhập nhân viên lập phiếu";
        public static string msgfrmPhieuXuat_ChuaNhapDongChiTietPhieu = "Chưa nhập dòng chi tiết phiếu xuất";
        public static string msgfrmPhieuXuat_XoaPhieu = "Bạn có chắc chắn xóa phiếu xuât này không?";
        public static string msgfrmPhieuXuat_KhongCoPhieuXoa = "Không có phiếu cần xóa nên không thể xóa được";
        public static string msgfrmPhieuXuat_TimKiem_KhongCo = "Không có kết quả của phiếu cần tìm";
        public static string msgfrmPhieuXuat_LuuThanhCong = "Lưu phiếu xuất thành công";
        public static string msgfrmPhieuXuat_CapNhatThanhCong = "Cập nhật phiếu xuất thành công";
        public static string msgfrmPhieuXuat_XoaThanhCong = "Xóa phiếu xuất thành công";

        //Dung cho frmTimPhieuXuat
        public static string msgfrmTimPhieuXuat_TuNgaySai = "Nhập sai ngày của phần từ ngày";
        public static string msgfrmTimPhieuXuat_DenNgaySai = "Nhập sai ngay thang của phần đến ngày";
        public static string msgfrmTimPhieuXuat_TimKiem_KhongCo = "Không có kết quả thỏa mãn điều kiện tìm";
        public static string msgfrmTimPhieuXuat_SuaThanhCong = "Sửa phiếu xuất thành công";
        public static string msgfrmTimPhieuXuat_XoaThanhCong = "Xóa phiếu xuất thành công";
        public static string msgfrmTimPhieuXuat_KhongCoDuLieuXoa = "Không có dữ liệu để xóa";
        public static string msgfrmTimPhieuXuat_KhongCoDuLieuSua = "Không có dữ liệu để sửa";

        //Dung cho frmTimHoaDonBan
        public static string msgfrmTimHoaDonBan_TuNgaySai = "Nhập sai ngày của phần từ ngày";
        public static string msgfrmTimHoaDonBan_DenNgaySai = "Nhập sai ngay thang của phần đến ngày";
        public static string msgfrmTimHoaDonBan_TongTienTu = "Giá trị hóa đơn mục 'Từ' phải có dạng số";
        public static string msgfrmTimHoaDonBan_TongTienDen = "Giá trị hóa đơn mục 'Đến' phải có dạng số";
        public static string msgfrmTimHoaDonBan_TimKiem_KhongCo = "Không có kết quả thỏa mãn điều kiện tìm";
        public static string msgfrmTimHoaDonBan_SuaThanhCong = "Sửa hóa đơn bán thành công";
        public static string msgfrmTimHoaDonBan_XoaThanhCong = "Xóa hóa đơn bán thành công";


        //Dung cho frmHoaDonBanBuon
        public static string msgfrmHoaDonBan_ChuaNhapCoSoPhieu = "Chưa nhập số hóa đơn";
        public static string msgfrmHoaDonBan_SoPhieuChung = "Số hóa đơn này đã có";
        public static string msgfrmHoaDonBan_KhongCoSoPhieu = "Không có phiếu xuất cần tìm";
        public static string msgfrmHoaDonBan_SoHoaDonChuaNhap = "Chưa nhập số hóa đơn bán";
        public static string msgfrmHoaDonBan_ChuaNhapNgay = "Chưa nhập ngày lập hóa đơn";
        public static string msgfrmHoaDonBan_NgayHoaDonSai = "Nhập sai ngày lập hóa đơn";
        public static string msgfrmHoaDonBan_ChuaChonNhanVien = "Chưa chọn nhân viên lập hóa đơn";
        public static string msgfrmHoaDonBan_ChuaChonKhachHang = "Chưa chọn khách hàng";
        public static string msgfrmHoaDonBan_SaiKieuVAT = "Thuế VAT phai có dạng số";
        public static string msgfrmHoaDonBan_VATKhongAm = "Thuế VAT phải là số không âm";
        public static string msgfrmHoaDonBan_VATLonHonMotTram = "Thuế VAT không vượt quá 100";
        public static string msgfrmHoaDonBan_SaiKieuChietKhau = "Chiết khấu phải có dạng số";
        public static string msgfrmHoaDonBan_ChietKhauKhongAm = "Chiết khấu phải là số không âm";
        public static string msgfrmHoaDonBan_ChietKhauLonHonMotTram = "Chiết khấu không vượt quá 100";
        public static string msgfrmHoaDonBan_ChuaNhapDongChiTietHD = "Chưa nhập dòng chi tiết hóa đơn";
        public static string msgfrmHoaDonBan_ThemMoiThanhCong = "Thêm mới hóa đơn thành công.";
        public static string msgfrmHoaDonBan_SuaThanhCong = "Cập nhật hóa đơn thành công";
        public static string msgfrmHoaDonBan_XoaThanhCong = "Xóa hóa đơn thành công";
        public static string msgfrmHoaDonBan_KhongCoHoaDonDeXoa = "Không có hóa đơn xóa";
        public static string msgfrmHoaDonBan_HoiXoa = "Bạn có muốn xóa hóa đơn này không";


        // Dùng Cho Ngày Tháng
        public static string msgDateTimeValid = "Lỗi kiểu ngày tháng." + "\n" +
                                                "-Bạn chưa nhập đúng kiểu ngày theo định dạng 'Ngay/Thang/Nam'" + "\n" +
                                                "-Sai ngày trong tháng" + "\n" +
                                                "-Tháng nhỏ hơn 1 hoặc lớn hơn 12" + "\n" +
                                                "-Năm nhỏ hơn 1753 hoăc lớn hơn 9999";
        public static string msgDateTime = "Bạn chưa nhập ngày tháng!";
        public static string msgNotGreater_CurrDate = "Không được lớn hơn ngày hiện tại!";
        public static string msgNotSmall_CurrDate = "Không được nhỏ hơn hoặc bằng ngày hiện tại!";
        public static string msgNotGreater_ToDate = "Từ ngày không được lớn hơn Đến ngày!";

        // Dùng cho các Phiếu nhập
        public static string msgInPutMesCheck = "Số phiếu này đã có! Hãy nhập lại";
        public static string msgInPutMesNull = "Số phiếu không được để trống!";

        // Dùng cho các Phiếu thu, chi
        public static string msgFind_NotFound = "Không tìm thấy phiếu nào!";
        public static string msgPrint_NotFound = "Không có phiếu nào để in!";
        public static string msgIsNumeric_SoTien = "Phải nhập số tiền là số!";
        public static string msgIsNumeric_TyGia = "Phải nhập tỷ giá là số!";
        public static string msgIsNumeric_CTKem = "Phải nhập chứng từ kèm theo là số!";
        public static string msgIsInteger16_CTKem = "Phải nhập số chứng từ kèm theo là số nguyên không được lớn hơn 32767!";
        public static string msgNotHi_CTKem = "Chứng từ kèm theo không được lớn hơn 32767!";
        public static string msgNotLo_CTKem = "Chứng từ kèm theo không được nhỏ hơn -32768!";
        public static string msgNotNull_LoaiTien = "Chưa nhập loại tiền!";
        public static string msgNotNull_TyGia = "Chưa nhập tỷ giá!";
        public static string msgNotExist_SoPhieu = "Số phiếu này chưa có!";
        public static string msgNotGreater_TienDen = "Số tiền từ không được lớn hơn đến!";

        public static string msgNotNull_QC = "Phải nhập số quyển chi!";
        public static string msgNotGreater_NC = "Ngày lập không được lớn hơn ngày hiện tại!";
        public static string msgNotNull_LoaiChi = "Chưa nhập loại thu!";
        public static string msgNotNull_NCC = "Chưa chọn đối tượng!";

        public static string msgNotNull_QT = "Phải nhập số quyển thu!";
        public static string msgNotGreater_NT = "Ngày thu không được lớn hơn ngày hiện tại!";
        public static string msgNotNull_LoaiThu = "Chưa nhập loại thu!";
        public static string msgNotNull_KH = "Chưa nhập khách hàng!";

        // frmTinhTon
        public static string msgNotExist_TT = "Không có dữ liệu thỏa mãn khi tính!";
        public static string msgNotExist_Print = "Dữ liệu tồn này chưa có hãy tính tồn trước khi in!";
        public static string msgExist_TT = "Dữ liệu tồn này đã có hãy tính lại!";
        public static string msgFinish_TT = "Đã tính tồn xong!";
        public static string msgYearNotGreater_TT = "Từ năm không được lớn hơn đến năm!";
        public static string msgKyNotGreater_TT = "Từ kỳ không được lớn hơn đến kỳ!";
        public static string msgNotGreaterCur_TT = "Không được lớn hơn năm hiện tại!";
        public static string msgYearNumber_TT = "Phải nhập năm là số nguyên!";
        public static string msgYearInvalid_TT = "Nhập sai định dạng năm!";
        public static string msgMonthNotNull_TT = "Phải chọn tháng để tính!";
        public static string msgYearNotNull_TT = "Phải nhập năm để tính!";

        // frmChiTiet

        public static string msgMonthNotNull_CT = "Phải nhập tháng để tính!";
        public static string msgYearNotNull_CT = "Phải nhập năm để tính!";
        public static string msgMonthGreater_CT = "Chỉ được nhập hai số!";
        public static string msgMonthNumber_CT = "Phải nhập tháng là số nguyên!";
        public static string msgMonthNotGreater_CT = "Tháng không được lớn hơn 12!";

        // frm_CapnhatTon
        public static string msgCapnhatSoDuDau = "Thông tin tồn đầu kỳ chỉ cập nhật một lần khi sử dụng phần mềm. Bạn đồng ý thực hiện?";
        public static string msgNapSoDuDau = "Bạn đồng ý nạp số dư đầu?";

        # region PhongTQ Sử dụng cho tra cứu

        public const int YCHanTraLoi = 2;
        public static Color QuaHanTraLoiKhach = Color.Red;
        public static Color DenHanTraLoiKhach = Color.Yellow;

        // sử dụng cho tổng hợp yêu cầu 
        public static Color YeuCauGocDaXong = Color.Green;
        public static Color YeuCauGocChuaXong = Color.Red;

        // trạng thái cuộc gọi của kịch bản gọi 
        public static Color ChoThucHienCuocGoi = Color.Yellow;
        public static Color DangThucHienCuocGoi = Color.Blue;
        public static Color KetThucCuocGoi = Color.Green;
        public static Color SaiSoDienThoai = Color.Red;

        // trạng thái cuộc gọi lấy ý kiến đánh giá của khách hàng

        public static Color ChoThucHienCuocGoiToiKhach = Color.Yellow;
        public static Color KhongLienLaDuoc = Color.Red;
        public static Color HoanThanhCuocGoi = Color.Green;
        #endregion

        #endregion

        #region "QLBanHang.Modules.DanhMuc Namespace"
        public static class DanhMucNamespace
        {
            public static string frmDM_Kho = "QLBanHang.Modules.DanhMuc.frmDM_Kho";
            public static string frmDM_TrungTam = "QLBanHang.Modules.DanhMuc.frmDM_TrungTam";
            public static string frmDM_DungChung = "QLBanHang.Modules.DanhMuc.frmDM_Chung";
            public static string frmDM_The = "QLBanHang.Modules.DanhMuc.frmDM_The";
            public static string frmDM_LoaiDichVu = "QLBanHang.Modules.DanhMuc.frmDM_LoaiDichVu";
            public static string frmDM_LoaiItem = "QLBanHang.Modules.DanhMuc.frmDM_LoaiItem";
            public static string frmDM_CauHinh = "QLBanHang.Modules.DanhMuc.frmDM_CauHinh";
            public static string frmDM_MaLoi = "QLBanHang.Modules.DanhMuc.frmDM_MaLoi";
            public static string frmDM_KhachHang = "QLBanHang.Modules.DanhMuc.frmDM_KhachHang";
            public static string frmDM_MatHang = "QLBanHang.Modules.DanhMuc.frmDM_HangHoa";
            public static string frmDM_NhanVien = "QLBanHang.Modules.DanhMuc.frmDM_NhanVien";
            public static string frmDM_OrderType = "QLBanHang.Modules.DanhMuc.frmDM_OrderType";
            public static string frmDM_QuyenHoaDon = "QLBanHang.Modules.DanhMuc.frmDM_QuyenHoaDon";
            public static string frmDM_ListDM = "QLBanHang.Modules.DanhMuc.frmDM_ListDM";
            public static string frmDM_LyDoTraHang = "QLBanHang.Modules.DanhMuc.frmDM_LyDoTraHang";
            public static string frmDM_LyDoGiaoDich = "QLBanHang.Modules.DanhMuc.frmDM_LyDoGiaoDich";
            public static string frmDM_CachGiaoHang = "QLBanHang.Modules.DanhMuc.frmDM_CachGiaoHang";
            public static string frmDM_BangKeThue = "QLBanHang.Modules.DanhMuc.frmDM_BangKeThue";
            public static string frmDM_PhuongThucBanHang = "QLBanHang.Modules.DanhMuc.frmDM_PhuongThucBanHang";
            public static string frmDM_Hang = "QLBanHang.Modules.DanhMuc.frmDm_SegmentHang";
            public static string frmDM_LinhVuc = "QLBanHang.Modules.DanhMuc.frmDm_SegmentLinhVuc";
            public static string frmDM_ChungHang = "QLBanHang.Modules.DanhMuc.frmDM_SegmentChildChung";
            public static string frmDM_LoaiHang = "QLBanHang.Modules.DanhMuc.frmDM_SegmentChildLoai";
            public static string frmDM_LoaiHoaDon = "QLBanHang.Modules.DanhMuc.frmDM_LoaiHoaDon";
            public static string frmDM_NganhHang = "QLBanHang.Modules.DanhMuc.frmDM_SegmentChildNganh";
            public static string frmDM_NganHang = "QLBanHang.Modules.DanhMuc.frmDM_NganHang";
            public static string frmDM_NhomHang = "QLBanHang.Modules.DanhMuc.frmDM_SegmentChildNhom";
            public static string frmDM_Model = "QLBanHang.Modules.DanhMuc.frmDM_SegmentChildModel";
            public static string frmDM_LoaiThuChi = "QLBanHang.Modules.DanhMuc.frmDM_LoaiThuChi";
            public static string frmDM_TienTe = "QLBanHang.Modules.DanhMuc.frmDM_TienTe";
            public static string frmDM_ThanhToan = "QLBanHang.Modules.DanhMuc.frmDM_HinhThucThanhToan";
            public static string frmDM_ChucNang = "QLBanHang.Modules.DanhMuc.frmDM_ChucNang";
            public static string frmDM_ChiPhi = "QLBanHang.Modules.DanhMuc.frmDM_ChiPhi";
            public static string frmDM_DonViTinh = "QLBanHang.Modules.DanhMuc.frmDM_DonViTinh";
            public static string frmDM_PhongBan = "QLBanHang.Modules.DanhMuc.frmDM_PhongBan";
            public static string frmDM_ChucVu = "QLBanHang.Modules.DanhMuc.frmDM_ChucVu";
            public static string frmDM_DuAn = "QLBanHang.Modules.DanhMuc.frmDM_DuAn";
            public static string frmDM_TaxCode = "QLBanHang.Modules.DanhMuc.frmDM_TaxCode";
            public static string frmDM_LoaiSanPham = "QLBanHang.Modules.DanhMuc.frmDM_LoaiSanPham";
            public static string frmDM_LoaiDoiTuong = "QLBanHang.Modules.DanhMuc.frmDM_LoaiDoiTuong";
            public static string frmDMCauHinh_LoaiSanPham = "QLBanHang.Modules.DanhMuc.frmDMCauHinh_LoaiSanPham";
            public static string frmDM_KhachHangLe = "QLBanHang.Modules.DanhMuc.frmDM_KhachHangLe";
            public static string frmDM_CauHinhSanPham = "QLBanHang.Modules.DanhMuc.frm_DM_CauHinhSanPham";
        }

        #endregion

        #region "HeThong Namespace"
        public static class HeThongNamespace
        {
            public static string frmDM_NhomNguoiDung = "QLBanHang.Modules.HeThong.frmDM_NhomNguoiDung";
            public static string frmHT_ListChucNang = "QLBanHang.Modules.HeThong.frmHT_ListChucNang";
            public static string frmHT_ListNguoiDung = "QLBanHang.Modules.HeThong.frmHT_ListNguoiDung";
            public static string frmHT_ListNhomNguoiDung = "QLBanHang.Modules.HeThong.frmHT_ListNhomNguoiDung";
            public static string frmHT_ChangePass = "QLBanHang.Modules.HeThong.frmHT_ChangePass";
            public static string frmThietLapCaLamViec = "QLBanHang.Modules.HeThong.frmThietLapCaLamViec";
            public static string frmHT_ThietLapPheDuyetGiaBan = "QLBanHang.Modules.HeThong.frmHT_ThietLapPheDuyetGiaBan";
            public static string frmHT_ThietLapThuongNhanVien = "QLBanHang.Modules.HeThong.frmHT_ThietLapThuongNhanVien";
            public static string frm_InMaVach = "QLBanHang.Modules.HeThong.frm_InMaVach";
            public static string frm_InMaVach2 = "QLBanHang.Modules.HeThong.frm_InMaVach2";
            public static string frmHT_NhatKyNSD = "QLBanHang.Modules.HeThong.frmHT_NhatKyNSD";
            public static string frmHT_SessionDB = "QLBanHang.Modules.HeThong.frmHT_SessionDB";
            public static string frmBC_PhanQuyenChucNang = "QLBanHang.Modules.HeThong.frmBC_PhanQuyenChucNang";
            public static string frmBC_PhanQuyenChucNangNguoiDung = "QLBanHang.Modules.HeThong.frmBC_PhanQuyenChucNangNguoiDung";
            public static string frmBC_PhanQuyenNganhHang = "QLBanHang.Modules.HeThong.frmBC_PhanQuyenNganhHang";
            public static string frmBC_PhanQuyenNhomNguoiDung = "QLBanHang.Modules.HeThong.frmBC_PhanQuyenNhomNguoiDung";
            public static string frmHT_ManageLockChungTu = "QLBanHang.Modules.HeThong.frmHT_LockChungTuManager";
            public static string frmNangCapPhienBanMoi = "QLBanHang.Modules.HeThong.frmHT_SaleTid_CapNhatPhienBanMoi";
            public static string frmNangCapPhienBanMoiCrm = "QLBanHang.Modules.HeThong.frmHT_CrmTid_CapNhatPhienBanMoi";
            public static string frmHT_ThamSoBanHang = "QLBanHang.Modules.HeThong.ThamSoBanHang";
        }
        #endregion

        #region "BanHang Namespace"
        public static class BanHangNamespace
        {
            public static string frmCS_BangGia = "QLBanHang.Modules.BanHang.frmCS_BangGia";
            public static string frmCS_ListBangGia = "QLBanHang.Modules.BanHang.frmCS_ListBangGia";
            public static string frmCS_BangGiaHienTai = "QLBanHang.Modules.BanHang.frmCS_BangGiaHienTai";
            //public static string frmCS_BangGia_ChinhSach = "QLBanHang.Modules.BanHang.frmCS_BangGia_ChinhSach";
            public static string frmCS_BangGia_ChinhSach = "QLBanHang.Modules.BanHang.frmCS_ListChinhSachKM";
            public static string frmCS_BangGia_ChinhSachKM = "QLBanHang.Modules.BanHang.frmCS_ListChinhSachKMai";
            public static string frmCS_CheckKhuyenMai = "QLBanHang.Modules.BanHang.frmCS_CheckKhuyenMai";
            public static string frmCS_DuyetBangGia = "QLBanHang.Modules.BanHang.frmCS_Duyet_BangGia";
            public static string frmCS_ImportBangGia = "QLBanHang.Modules.BanHang.frmCS_ImportBangGia";
            public static string frmCS_TimKiem_BangGia = "QLBanHang.Modules.BanHang.frmCS_TimKiem_BangGia";
            public static string frmCS_TimKiem_ChinhSachGia = "QLBanHang.Modules.BanHang.frmCS_TimKiem_ChinhSachGia";
            public static string frmCS_ThietLapDiemThuong = "QLBanHang.Modules.BanHang.frmCS_ThietLapDiemThuong";
            public static string frmCS_BangGia_ChuaDuyet = "QLBanHang.Modules.BanHang.frmCS_BangGia_ChuaDuyet";
            public static string frmBH_BangGiaBanHang = "QLBanHang.Modules.BanHang.frmBH_BangGiaBanHang";
            public static string frmBH_BangGiaOnline = "QLBanHang.Modules.BanHang.frmBH_BangGiaBanHang_Online";
            public static string frmBC_HangChuaCoGia = "QLBanHang.Modules.BanHang.frmBC_HangChuaCoGia";
            public static string frmBH_ListDonHangDatTruoc = "QLBanHang.Modules.BanHang.frmBH_ListDonHangDatTruoc";
            public static string frmBH_ListDonHangBan = "QLBanHang.Modules.BanHang.frmBH_ListDonHangBan";
            public static string frmBH_ListDonHangBanTheTVien = "QLBanHang.Modules.BanHang.frmBH_ListDonHangBanTheTVien";
            public static string frmBH_ListDonHangOnline = "QLBanHang.Modules.BanHang.frmBH_ListDonHangOnline";
            public static string frmBH_ListDuyetDonHangOnline = "QLBanHang.Modules.BanHang.frmBH_ListDuyetDonHangOnline";
            public static string frmBH_ListPhanDonGiaoNhan = "QLBanHang.Modules.BanHang.frmBH_ListPhanDonGiaoNhan";
            public static string frmBH_ListXacNhanGiaoNhan = "QLBanHang.Modules.BanHang.frmBH_ListXacNhanGiaoNhan";
            public static string frmBH_ListPhanCongGiaoNhan = "QLBanHang.Modules.BanHang.frmBH_ListDonHangGiaoNhan";
            public static string frmBH_TinhTrangGiaoNhan = "QLBanHang.Modules.BanHang.frmBH_TinhTrangGiaoNhan";
            public static string frmBH_ListPhieuXuatKho = "QLBanHang.Modules.BanHang.frmBH_ListPhieuXuatKho";
            public static string frmBH_ListPhieuThanhToan = "QLBanHang.Modules.BanHang.frmBH_ListPhieuThanhToan";
            public static string frmBH_ListPhieuChi = "QLBanHang.Modules.BanHang.frmBH_ListPhieuChi";
            public static string frmBH_DanhSachDonHang = "QLBanHang.Modules.BanHang.frmBH_DanhSachDonHang";
            public static string frmBH_LapDonHangBan = "QLBanHang.Modules.BanHang.frmBH_LapDonHangBan";
            public static string frmBH_LapDonHangOnline = "QLBanHang.Modules.BanHang.frmBH_LapDonHangOnline";
            public static string frmBH_DuyetDonHangOnline = "QLBanHang.Modules.BanHang.frmBH_DuyetDonHangOnline";
            public static string frmBH_LapDonDatHangTruoc = "QLBanHang.Modules.BanHang.frmBH_LapDonDatHangTruoc";
            public static string frmCS_SuDungHoaDon = "QLBanHang.Modules.BanHang.frmCS_SuDungHoaDon";
            public static string frmBH_TimChungTu = "QLBanHang.Modules.BanHang.frmBH_TimChungTu";
            public static string frmBH_TraLaiHangBan = "QLBanHang.Modules.BaoHanh.frmChiTietYeuCauNhapLaiHangMua";
            public static string frmBH_PhanCongGiaoNhan = "QLBanHang.Modules.BanHang.frmBH_PhanCongGiaoNhan";
            public static string frmBH_ListDonHangTraLai = "QLBanHang.Modules.BanHang.frmBH_ListDonHangTraLai";
            public static string frmBC_SanPhamHienCo = "QLBanHang.Modules.BanHang.frmBC_SanPhamHienCo";
            public static string frmBH_SuaDonHangBan = "QLBanHang.Modules.BanHang.frmBH_SuaDonHangBan";
            public static string frmBC_DonHangChiTietChuaXuatKho = "QLBanHang.Modules.BanHang.frmBC_DonHangChiTietChuaXuatKho";
            public static string frmBC_TongHopBanHang = "QLBanHang.Modules.BanHang.frmBC_TongHopBanHang";
            public static string frmBC_TongHopKhungGioTheoNganh = "QLBanHang.Modules.BanHang.frmBC_TongHopKhungGioNganh";
            public static string frmBC_TongHopKhungGioTheoTuan = "QLBanHang.Modules.BanHang.frmBC_TongHopKhungGioTuan";
            public static string frmThietLapSoLuongMaVachXuat = "QLBanHang.Modules.BanHang.frmThietLapSoLuongMaVachXuat";
            public static string frmBH_KhoaDonHang = "QLBanHang.Modules.BanHang.frmBH_KhoaDonHang";
            public static string frmCS_DayKhuyenMai = "QLBanHang.Modules.BanHang.frmCS_DayKhuyenMai";
            public static string frmBH_SuaDonHangTraLai = "QLBanHang.Modules.BanHang.frmBH_SuaDonHangTraLai";
            public static string frmBH_SuaDonHangNhapLai = "QLBanHang.Modules.BanHang.frmBH_SuaDonHangNhapLai";

            //import du lieu vao pos
            public static string frmImport_ChungTuChiTiet = "QLBanHang.Modules.BanHang.frmImport_ChungTuChiTiet";

            //bao cao ban hang
            public static string frmBC_TongHopDoanhThuBanHang = "QLBanHang.Modules.BanHang.frmBC_TongHopDoanhThu";
            public static string frmBC_DoanhThuBanHang = "QLBanHang.Modules.BanHang.frmBC_PhieuThuLenDoanhSo";
            public static string frmBC_PhieuThuTien = "QLBanHang.Modules.BanHang.frmBC_PhieuThuTien";
            public static string frmBC_PhieuThuCongNo = "QLBanHang.Modules.BanHang.frmBC_PhieuThuCongNo";
            public static string frmBC_CongNoKhachHang = "QLBanHang.Modules.BanHang.frmBC_CongNoKhachHang";
            public static string frmBC_CongNoTrungTam = "QLBanHang.Modules.BanHang.frmBC_CongNoTrungTam";
            public static string frmBC_PhieuThuChiTiet = "QLBanHang.Modules.BanHang.frmBC_PhieuThuChiTiet";
            public static string frmBC_DonHang = "QLBanHang.Modules.BanHang.frmBC_DonHang";
            public static string frmBC_DonHangChiTiet = "QLBanHang.Modules.BanHang.frmBC_DonHangChiTiet";
            public static string frmBC_GiaoNhan = "QLBanHang.Modules.BanHang.frmBC_GiaoNhan";
            public static string frmBC_GiaoNhanChiTiet = "QLBanHang.Modules.BanHang.frmBC_GiaoNhanChiTiet";
            public static string frmBC_GiaoNhanChiTietKThuat = "QLBanHang.Modules.BanHang.frmBC_GiaoNhanChiTietKThuat";
            public static string frmBC_GiaoNhanChiTietKThuatCT = "QLBanHang.Modules.BanHang.frmBC_GiaoNhanChiTietKThuatCT";
            public static string frmBC_GiaoNhanThongKeKThuat = "QLBanHang.Modules.BanHang.frmBC_GiaoNhanThongKeKThuat";
            public static string frmBC_DonHangChiTietXuatKho = "QLBanHang.Modules.BanHang.frmBC_DonHangChiTietXuatKho";
            public static string frmBC_NoKhuyenMai = "QLBanHang.Modules.BanHang.frmBC_NoKhuyenMai";
            public static string frmBH_BangGiaBanHang_LichSu = "QLBanHang.Modules.BanHang.frmBH_BangGiaBanHang_LichSu";

            public static string frmBC_ChinhSachGia = "QLBanHang.Modules.BanHang.frmBC_ChinhSachGia";
            public static string frmBC_SuDungHoaDon = "QLBanHang.Modules.BanHang.frmBC_SuDungHoaDon";
            public static string frmBC_ChinhSachGiaChiTiet = "QLBanHang.Modules.BanHang.frmBC_ChinhSachGiaChiTiet";
            public static string frmBC_LichSuGiaBan = "QLBanHang.Modules.BanHang.frmBC_LichSuGiaBan";
            //kich hoat bao hanh
            public static string frmKT_KichHoatBaoHanh = "QLBanHang.Modules.BanHang.frmKT_KichHoatBaoHanh";
            public static string frmKT_KichHoatBHHangBan = "QLBanHang.Modules.BanHang.frmKT_KichHoatBHHangBan";
            public static string frmKT_KichHoatBHHangTon = "QLBanHang.Modules.BanHang.frmKT_KichHoatBaoHanhTonKho";
            //ton ma vach
            public static string frmBC_LichSuMaVach = "QLBanHang.Modules.BanHang.frmBC_LichSuMaVach";
            public static string frmBC_TonMaVachHienCo = "QLBanHang.Modules.BanHang.frmBC_TonMaVachHienCo";

            public static string frmBH_LapPhieuThu = "QLBanHang.Modules.BanHang.frmBH_LapPhieuThu";
            public static string frmBH_LapPhieuChi = "QLBanHang.Modules.BanHang.frmBH_LapPhieuChi";
            //Phạm Ngọc Minh 28/12/2012
            public static string frmDMDnTraHangMua = "QLBanHang.Modules.BanHang.frmDMDnTraHangMua";
            public static string frmXacNhanNhapHangTraLai = "QLBanHang.Modules.BanHang.frmXacNhanNhapHangTraLai";

            //Phạm Ngọc Minh 2/1/2013
            public static string frmDMDeNghiDoiMa = "QLBanHang.Modules.BanHang.frmDMDeNghiDoiMa";
            public static string frmDMXacNhanDoiMa = "QLBanHang.Modules.BanHang.frmDMXacNhanDoiMa";
            public static string frmCongNoPOSAR0400 = "QLBanHang.Modules.BanHang.frmBC_CongNoPOS_AR0400";
        }
        #endregion

        #region "BaoHanh Namespace"
        public static class BaoHanhNamespace
        {
            public static string frmDMYeuCau = "QLBanHang.Modules.BaoHanh.frmDMYeuCauTaiNha";
            public static string frmBHHoTroKhachHang = "QLBanHang.Modules.BaoHanh.frmBHYeuCauTaiNha";
            public static string frmDMYeuCauPhanCong = "QLBanHang.Modules.BaoHanh.frmDMYeuCauPhanCong";
            public static string frmDMHangXuLy = "QLBanHang.Modules.BaoHanh.frmDMHangXuLy"; // xử lý yêu cầu

            public static string frmDMPhieuNhanHangLoi = "QLBanHang.Modules.BaoHanh.frmDMPhieuNhanHangLoi";

            public static string frmDMPhieuNhapKho = "QLBanHang.Modules.BaoHanh.frmDMPhieuNhapKho";
            public static string frmDMPhanLoaiBaoHanh = "QLBanHang.Modules.BaoHanh.frmDMPhanLoaiBaoHanh";

            public static string frmDMKiemTraTongHop = "QLBanHang.Modules.BaoHanh.frmDMKiemTraTongHop";

            public static string frmDMXuatHangLoiBHNCC = "QLBanHang.Modules.BaoHanh.frmDMXuatHangLoiBHNCC";
            public static string frmDMNhanHangBHNCC = "QLBanHang.Modules.BaoHanh.frmDMNhanHangBaoHanh";
            // chia thành 3 nút chức năng riêng
            public static string frmDMPhieuYeuCauXM = "QLBanHang.Modules.BaoHanh.frmDMPhieuYeuCauXM";
            public static string frmDMPhieuYeuCauXM_KT = "QLBanHang.Modules.BaoHanh.frmDMPhieuYeuCauXM_KT";
            public static string frmDMPhieuYeuCauXM_Kho = "QLBanHang.Modules.BaoHanh.frmDMPhieuYeuCauXM_Kho";

            //bảng kê hàng lỗi
            public static string frmDMBangKeHangLoi = "QLBanHang.Modules.BaoHanh.frmDMBangKeHangLoi";
            //bảng tra cứu bảo hành
            public static string frmDMTraCuuBaoHanh = "QLBanHang.Modules.BaoHanh.frmDMTraCuuBaoHanh";


            public static string frmDMDamPhanNCC = "QLBanHang.Modules.BaoHanh.frmDMDamPhanNCC";

            public static string frmDMBHBaoCaoXM = "QLBanHang.Modules.BaoHanh.frmDMBHBaoCaoXM";

            public static string frmBHBaoCaoNoKhach = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoNoKhach";

            //Nhập trả hàng mượn
            /// <summary>
            /// Kho(Nhập hàng khách mượn)
            /// </summary>
            public static string frmDMKhachMuonTra = "QLBanHang.Modules.BaoHanh.frmDMKhachMuonTra";

            /// <summary>
            /// Kế toán(Xác nhận trả hàng  mượn)
            /// </summary>
            public static string frmDMKhachMuonTraKT = "QLBanHang.Modules.BaoHanh.frmDMKhachMuonTraKT";

            //Thực hiện bảo hành
            /// <summary>
            /// Thông tin(lên kế hoạch trả hàng)
            /// </summary>
            public static string frmDMThucHienBaoHanh = "QLBanHang.Modules.BaoHanh.frmDMThucHienBaoHanh";

            /// <summary>
            /// Kho(Xuất linh kiện BH)
            /// </summary>
            public static string frmDMThucHienBaoHanhKho = "QLBanHang.Modules.BaoHanh.frmDMThucHienBaoHanhKho";

            /// <summary>
            /// kĩ thuật(Phân công bảo hành)
            /// </summary>
            public static string frmDMPhanCongBH = "QLBanHang.Modules.BaoHanh.frmDMPhanCongBH";

            /// <summary>
            /// Kí thuật(Thực hiện bảo hành)
            /// </summary>
            public static string frmDMThucHienBaoHanhKT = "QLBanHang.Modules.BaoHanh.frmDMThucHienBaoHanhKT";

            // xuất trả bảo hành
            /// <summary>
            /// kế toán(Lập phiếu thu)
            /// </summary>
            public static string frmDMXuatTraHangBH = "QLBanHang.Modules.BaoHanh.frmDMXuatTraHangBH";

            /// <summary>
            /// Kho(Xuất trả bảo hành)
            /// </summary>
            public static string frmDMXuatTraHangBHKho = "QLBanHang.Modules.BaoHanh.frmDMXuatTraHangBHKho";

            // xuất trả linh kiện
            /// <summary>
            /// kế toán lập phiếu (Phiếu xuất trả linh kiện)
            /// </summary>
            public static string frmDMXuatTraLinhKien = "QLBanHang.Modules.BaoHanh.frmDMXuatTraLinhKien";

            /// <summary>
            /// Kho xuất sản phẩm(Kho xuất trả linh kiện)
            /// </summary>
            public static string frmDMXuatTraLinhKienKho = "QLBanHang.Modules.BaoHanh.frmDMXuatTraLinhKienKho";

            /// <summary>
            /// Hàng lỗi kinh doanh(khi bên kinh doanh điều chuyển hàng lỗi sang bảo hành
            /// </summary>
            public static string frmDMHangLoiKinhDoanh = "QLBanHang.Modules.BaoHanh.frmDMHangLoiKinhDoanh";

            /// <summary>
            /// báo cáo hàng xuất hãng
            /// </summary>
            public static string frmDMBaoCaoNoNCC = "QLBanHang.Modules.BaoHanh.frmDMBaoCaoNoNCC";

            /// <summary>
            /// ki thuat xu ly  tai nha
            /// </summary>
            public static string frmKiThuatXuLyTaiNha = "QLBanHang.Modules.BaoHanh.frmKiThuatXuLyTaiNha";

            /// <summary>
            /// Báo cáo tồn kho bảo hành
            /// </summary>
            public static string frmBHBaoCaoTonKho = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoTonKho";

            //5/12/2012
            /// <summary>
            /// Báo cáo kĩ thuật xử lý yêu cầu tại nhà
            /// </summary>
            public static string frmBCYeuCauKTXuLy = "QLBanHang.Modules.BaoHanh.frmBCYeuCauKTXuLy";

            /// <summary>
            /// Báo cáo hãng xử lý yêu cầu tại nhà
            /// </summary>
            public static string frmBaoCaoHangXuLyYC = "QLBanHang.Modules.BaoHanh.frmBaoCaoHangXuLyYC";

            /// <summary>
            /// Báo cáo yêu cầu xử lý
            /// </summary>
            public static string frmBCDSYeuCauTaiNha = "QLBanHang.Modules.BaoHanh.frmBCDSYeuCauTaiNha";

            /// <summary>
            /// Kiểm tra nhận ncc
            /// </summary>
            public static string frmChiTietKiemSoatNhanBHNCC = "QLBanHang.Modules.BaoHanh.frmBhKhoKiemTra";

            /// <summary>
            /// Báo cáo kiểm tra nhận ncc
            /// </summary>
            public static string frmBaoCaoKiemTraNhapKho = "QLBanHang.Modules.BaoHanh.frmBaoCaoKiemTraNhapKho";

            /// <summary>
            /// báo cáo tồn mã vạch
            /// </summary>
            public static string frmBHBaoCaoTonMaVach = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoTonMaVach";

            /// <summary>
            /// Xác nhận xuất trả kinh doanh
            /// </summary>
            public static string frmDMChoXuatKinhDoanh = "QLBanHang.Modules.BaoHanh.frmDMChoXuatKinhDoanh";

            /// <summary>
            /// Tra cứu bảo hành
            /// </summary>
            public static string frmDMTraCuuMaVach = "QLBanHang.Modules.BaoHanh.frmDMTraCuMaVach";

            /// <summary>
            /// báo cáo thu chi
            /// </summary>
            public static string frmBaoCaoThuChi = "QLBanHang.Modules.BaoHanh.frmBaoCaoThuChi";

            /// <summary>
            /// báo cáo nợ công ty
            /// </summary>
            public static string frmBaoCaoNoCongTy = "QLBanHang.Modules.BaoHanh.frmBaoCaoNoCongTy";

            /// <summary>
            /// báo cáo nhận bảo hành nhà cung cấp
            /// </summary>
            public static string frmBHBaoCaoNhanHangNCC = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoNhanHangNCC";
            /// <summary>
            /// chính sách bảo hành nhà cung cấp
            /// </summary>
            public static string frmBHDSChinhSachNCC = "QLBanHang.Modules.BaoHanh.frmBHDSChinhSachNCC";

            /// <summary>
            /// Báo cáo tổng hợp hàng lỗi
            /// </summary>
            public static string frmBhBaoCaoTongHopHangLoi = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoTongHopHangLoi";

            /// <summary>
            /// Báo cáo xuất hàng bảo hành
            /// </summary>
            public static string frmBHBaoCaoHangXuatHang = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoHangXuatHang";

            /// <summary>
            /// Cập nhật thông tin khách hàng
            /// </summary>
            public static string frmCapNhapThongTinKhach = "QLBanHang.Modules.BaoHanh.frmCapNhapThongTinKhach";

            /// <summary>
            /// Báo cáo đổi mã
            /// </summary>
            public static string frmBhBaoCaoDoiMa = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoDoiMa";

            /// <summary>
            /// Báo cáo lên kế hoạch trả khách
            /// </summary>
            public static string frmBHBaoCaoLenKeHoach = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoLenKeHoach";

            /// <summary>
            /// Báo cáo lập bảng kê
            /// </summary>
            public static string frmBhBaoCaoBangKe = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoBangKe";

            /// <summary>
            /// Báo cáo tổng hợp xử lý
            /// </summary>
            public static string frmBHBaoCaoTongHopXuLy = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoTongHopXuLy";

            /// <summary>
            /// Hoàn thiện xử lý yêu cầu
            /// </summary>
            public static string frmKetThucXuLyYeuCau = "QLBanHang.Modules.BaoHanh.frmKetThucXuLyYeuCau";

            /// <summary>
            /// Thiết lập trưởng ca
            /// </summary>
            public static string frmBHThietLapTruongCa = "QLBanHang.Modules.BaoHanh.frmBHThietLapTruongCa";

            /// <summary>
            /// Đổi tính chất hàng công ty
            /// </summary>
            public static string frmUpdateTinhChatHang = "QLBanHang.Modules.BaoHanh.frmUpdateTinhChatHang";

            /// <summary>
            /// Định giá sản phẩm
            /// </summary>
            public static string frmBhDinhGiaSanPham = "QLBanHang.Modules.BaoHanh.frmBhDinhGiaSanPham";

            /// <summary>
            /// Mở khóa dữ liệu
            /// </summary>
            public static string frmBHUnlock = "QLBanHang.Modules.BaoHanh.frmBHUnlock";

            /// <summary>
            /// Xác định kho lỗi công ty
            /// ps:anh đưa vào phần thiết lập bảo hành
            /// </summary>
            public static string frmBHSetKhoLoiCongTy = "QLBanHang.Modules.BaoHanh.frmBHSetKhoLoiCongTy";

            /// <summary>
            /// Đổi mã vạch
            /// ps:anh đưa vào phần thiết lập bảo hành
            /// </summary>
            public static string frmSuaMaVach = "QLBanHang.Modules.BaoHanh.frmSuaMaVach";

            /// <summary>
            /// Báo cáo đổi tính chất hàng CTy
            /// ps:anh đưa vào phần báo cáo
            /// </summary>
            public static string frmBhBaoCaoDoiTinhChat = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoDoiTinhChat";

            /// <summary>
            /// Báo cáo xử lý tại trung tâm
            /// ps:anh đưa vào phần báo cáo ,anh đưa vào chức năng: Báo cáo tổng hợp xử lý (đổi tên thành chức năng thành "Báo cáo xử lý tại trung tâm")
            /// </summary>
            public static string frmBHLichSuPhanCong = "QLBanHang.Modules.BaoHanh.frmBHLichSuPhanCong";

            /// <summary>
            /// Báo cáo giao dịch đổi hàng
            /// ps:anh đưa vào phần báo cáo 
            /// </summary>
            public static string frmBHBaoCaoGDDoiHang = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoGDDoiHang";

            /// <summary>
            /// Báo cáo điều chuyển bảo hành
            /// ps:anh đưa vào phần báo cáo 
            /// </summary>
            public static string frmBhBaoCaoGiaoDichSetLoi = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoGiaoDichSetLoi";

            /// <summary>
            /// Báo cáo giao dịch xuất hãng
            /// ps:anh đưa vào phần báo cáo 
            /// </summary>
            public static string frmBHGiaoDichXuatHang = "QLBanHang.Modules.BaoHanh.frmBHGiaoDichXuatHang";

            /// <summary>
            /// ngày 21/5/2013
            /// Báo cáo định giá sản phẩm
            /// ps:anh đưa vào báo cáo thống kê -  báo cáo thực hiện bảo hành
            /// </summary>
            public static string frmBhBaoCaoDinhGia = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoDinhGia";


            //CuongTT 20/4/2013
            public static string frmDMLoiCheck = "QLBanHang.Modules.BaoHanh.frmBhDMLoiCheck";
            public static string frmChiTietKiemSoatNhanBHNCC1 = "QLBanHang.Modules.BaoHanh.frmChiTietKiemSoatNhanBHNCC";
            public static string frmBaoCaoKiemSoatNhanBHNCC = "QLBanHang.Modules.BaoHanh.frmBaoCaoKiemSoatNhanBHNCC";

            /// <summary>
            /// Báo cáo Pending Oracle
            /// ps:anh đưa vào báo cáo thống kê
            /// </summary>
            public static string frmBHBaoCaoPending = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoPending";

            /// <summary>
            /// Đánh giá công việc

            /// </summary>
            public static string frmBhDanhGiaBaoHanh = "QLBanHang.Modules.BaoHanh.frmBhDanhGiaBaoHanh";

            /// <summary>
            /// Báo cáo tổng hợp giao dịch bảo hành
            /// ps:Anh đưa vào báo cáo thông kê
            /// </summary>
            public static string frmBhBaoCaoNhapXuatBH = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoNhapXuatBH";

            /// <summary>
            /// Báo cáo tách cấu hình
            /// ps:Anh đưa vào thực hiện bảo hành
            /// ngày:5/6/2013
            /// </summary>
            public static string frmBhBaoCaoTachCauHinh = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoTachCauHinh";

            /// <summfary>
            /// Báo cáo xuất trả bảo hanh
            /// ps:Anh đưa vào thực hiện bảo hành
            /// ngày:5/6/2013
            /// </summary>
            public static string frmBHBaoCaoXuatTra = "QLBanHang.Modules.BaoHanh.frmBHBaoCaoXuatTra";

            /// <summfary>
            /// Phiếu thu bổ xung
            /// ps:Anh đưa vào trả hàng
            /// ngày:7/6/2013
            /// </summary>
            public static string frmBhPhieuThuChiBoXung = "QLBanHang.Modules.BaoHanh.frmBhPhieuThuChiBoXung";

            /// <summfary>
            /// Khu vực nhà cung cấp
            /// ps:Anh đưa vào trả hàng
            /// ngày:7/6/2013
            /// </summary>
            public static string frmBhKhuVuc = "QLBanHang.Modules.BaoHanh.frmBhKhuVuc";

            /// <summfary>
            /// Báo cáo kiểm soát xử lý tại trung tâm
            /// ps:Anh đưa vào báo cáo thực hiện bảo hành
            /// ngày:7/6/2013
            /// </summary>
            public static string frmBhBaoCaoKSXLTrungTam = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoKSXLTrungTam";
            /// <summfary>
            /// Nhật ký bảo hành
            /// ps:Anh đưa vào báo cáo thực hiện bảo hành
            /// ngày:16/7/2013
            /// </summary>
            public static string frmBHNhatKyBaoHanh = "QLBanHang.Modules.BaoHanh.frmBHNhatKyBaoHanh";

            /// <summfary>
            /// Báo cáo đàm phán khách lẻ
            /// ps:Anh đưa vào báo cáo thực hiện bảo hành
            /// ngày:24/7/2013
            /// </summary>
            public static string frmBhBaoCaoDamPhanKhachLe = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoDamPhanKhachLe";

            /// <summfary>
            /// Báo cáo tiếp nhận hàng lỗi
            /// ps:Anh đưa vào báo cáo thực hiện bảo hành
            /// ngày:24/7/2013
            /// </summary>
            public static string frmBhBaoCaoTiepNhanHL = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoTiepNhanHL";
            /// <summfary>
            /// Cập nhật phiếu nhận hàng lỗi (sửa: Đề nghị hủy phiếu nhận hàng lỗi)
            /// ps:Anh đưa vào Thiết lập bảo hành (sửa Anh đưa vào Tiếp nhận)
            /// ngày:31/7/2013
            /// </summary>
            public static string frmBHCapNhatPhieuNhan = "QLBanHang.Modules.BaoHanh.frmBHCapNhatPhieuNhan";

            /// <summfary>
            /// Duyệt hủy phiếu nhận hàng lỗi
            /// ps:Anh đưa vào Tiếp nhận  (Anh sửa cả form trên cho em luôn nhé)
            /// ngày:3/8/2013
            /// </summary>
            public static string frmBhDuyetHuyPhieuNhan = "QLBanHang.Modules.BaoHanh.frmBhDuyetHuyPhieuNhan";
            /// <summfary>
            /// Báo cáo hủy phiếu nhận hàng lỗi
            /// ps:Anh đưa vào báo cáo thực hiện bảo hành
            /// ngày:3/8/2013
            /// </summary>
            public static string frmBhBaoCaoHuyPhieuNhan = "QLBanHang.Modules.BaoHanh.frmBhBaoCaoHuyPhieuNhan";

            /// <summfary>
            /// Cập nhật phiếu nhận từ nhà cung cấp
            /// ps:Anh đưa vào xuất bảo hành NCC
            /// ngày:3/10/2014
            /// </summary>
            public static string frmBHPhieuNCC = "QLBanHang.Modules.BaoHanh.frmBHPhieuNCC";



            /// <summfary>
            /// Báo cáo đàm phán nhà cung cấp
            /// ps:Anh đưa vào báo cáo
            /// ngày:14/10/2014
            /// </summary>
            public static string frmBHBCDamPhanNCC = "QLBanHang.Modules.BaoHanh.frmBHBCDamPhanNCC";

            public static string frmHangLoiCanChuyen = "QLBanHang.Modules.BaoHanh.frmDMHangLoiCanChuyenVeTT";

            public static string frmYeuCauChuyen = "QLBanHang.Modules.BaoHanh.frmDMYeuCauChuyen";
        }
        #endregion

        #region "DongBoERP Namespace"
        public static class DongBoNamespace
        {
            public static string frm_ChungTuNhap = "QLBanHang.Modules.DongBoERP.frm_ChungTuNhap";
        }
        #endregion

        #region "TheThanhVien Namespace"
        public static class TheThanhVienNamespace
        {
            public static string frmDM_HoSoKhachHang = "QLBanHang.Modules.TheThanhVien.frmDM_HoSoKhachHang";
            public static string frmDM_HoSoKhachHangPOS = "QLBanHang.Modules.TheThanhVien.frmDM_HoSoKhachHangPOS";
            public static string frmDM_HoSoKhachHangOnline = "QLBanHang.Modules.TheThanhVien.frmDM_HoSoKhachHangOnline";

            public static string frmDM_LoaiTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmDM_LoaiTheThanhVien";
            public static string frmDM_TheThanhVien = "QLBanHang.Modules.TheThanhVien.frmDM_TheThanhVien";            

            public static string frmTH_HeSoDoiDiem = "QLBanHang.Modules.TheThanhVien.frmTH_HeSoDoiDiem";
            public static string frmTH_ChinhSachThe = "QLBanHang.Modules.TheThanhVien.frmTH_ChinhSachThe";
            public static string frmTH_DotInThe = "QLBanHang.Modules.TheThanhVien.frmTH_DotInThe";

            public static string frmTH_CapNhatDiemTichLuy = "QLBanHang.Modules.TheThanhVien.frmTH_CapNhatDiemTichLuy";

            public static string frmHT_DNghiNangCapTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmHT_DNghiNangCapTheThanhVien";
            public static string frmHT_XNhanNangCapTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmHT_XNhanNangCapTheThanhVien";
            public static string frmHT_CPhatNangCapTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmHT_CPhatNangCapTheThanhVien";

            public static string frmHT_DNghiCapLaiTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmHT_DNghiCapLaiTheThanhVien";
            public static string frmHT_XNhanCapLaiTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmHT_XNhanCapLaiTheThanhVien";
            public static string frmHT_CPhatCapLaiTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmHT_CPhatCapLaiTheThanhVien";

            public static string frmBC_TheoDoiTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmBC_TheoDoiTheThanhVien";
            public static string frmBC_HoatDongTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmBC_HoatDongTheThanhVien";
            public static string frmBC_TheoDoiTichDiemThe = "QLBanHang.Modules.TheThanhVien.frmBC_TheoDoiTichDiemThe";
            public static string frmBC_LichSuGiaoDich = "QLBanHang.Modules.TheThanhVien.frmBC_LichSuGiaoDich";
            public static string frmBC_ThongKeTheThanhVien = "QLBanHang.Modules.TheThanhVien.frmBC_ThongKeTheThanhVien";
            public static string frmBC_TheoDoiQuyDoiDiem = "QLBanHang.Modules.TheThanhVien.frmBC_TheoDoiQuyDoiDiem";
            public static string frmBC_TongHopTichDiemThe = "QLBanHang.Modules.TheThanhVien.frmBC_TongHopTichDiemThe";
            public static string frmBC_TongHopDiemTichLuy = "QLBanHang.Modules.TheThanhVien.frmBC_TongHopDiemTichLuy";
            public static string frmBC_TheoDoiBoiHoanTien = "QLBanHang.Modules.TheThanhVien.frmBC_TheoDoiBoiHoanTien";
        }
        #endregion

        #region CustomerReception Namespace
        public static class CustomerReceptionNamespace
        {
            public static string frmDsTiepNhanYeuCau = "QLBanHang.Modules.CustomerReception.frmDSTiepNhanYeuCau";
            public static string frmDsLyDoTiepNhan = "QLBanHang.Modules.CustomerReception.FrmDMLyDoTiepNhan";
            public static string frmXuLyYeuCau = "QLBanHang.Modules.CustomerReception.FrmDSYeuCauCanThucHien";
            public static string frmPhanCongXuLyYeuCau = "QLBanHang.Modules.CustomerReception.FrmPhanCongXuLyYeuCau";
        }
        #endregion

        #region CustomerCare Namespace
        public static class CustomerCareNamespace
        {
            public static string frmDMKichBanGoi = "QLBanHang.Modules.CustomerCare.FrmDmKichBanGoi";
            public static string frmDsDotKhaoSat = "QLBanHang.Modules.CustomerCare.FrmDMDotKhaoSatCuocGoi";
            public static string frmDsCuocKhaoSat = "QLBanHang.Modules.CustomerCare.FrmDmDotKSCSKHCanThucHien";
        }

        #endregion

        #region "KhoHang Namespace"
        public static class KhoHangNamespace
        {

            public static string frmThongKeTonMaVach = "QLBanHang.Modules.KhoHang.frmThongKe_TonChiTietMaVach";
            public static string frmThongKeHangTonKho = "QLBanHang.Modules.KhoHang.frmThongKe_TonSanPham_v01";
            public static string DanhSachNhapHangMua = "QLBanHang.Modules.KhoHang.frm_ListChungTuNhap";
            public static string DanhSachTraNhaCungCap = "QLBanHang.Modules.KhoHang.frm_ListChungTuTraNCC";
            public static string frm_DanhSachPhieuNhapNoiBo = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuNhapNoiBo";
            public static string frmDeNghiXuatTieuHao = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuDeNghiXuatTHnew";
            public static string frmXuatTieuHao = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuXuatTieuHaonew";
            public static string frmDeNghiNhapTieuHao = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuDeNghiNhapTH";
            public static string frmNhapTieuHao = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuNhapTieuHao";

            public static string frm_ListChungTuNhap = "QLBanHang.Modules.KhoHang.frm_ListChungTuNhap";

            public static string frm_DanhSachPhieuXuatNoiBo = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuXuatNoiBo";
            public static string frm_DanhSachDeNghiDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachDeNghiDieuChuyen";
            public static string frm_DanhSachDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachDieuChuyen";
            public static string DanhSachXuatLinhKienSX = "QLBanHang.Modules.KhoHang.frmDanhSachXuatLKSX";
            public static string DanhSachNhapThanhPhamSX = "QLBanHang.Modules.KhoHang.frmDanhSachXacNhanNhapThanhPham";
            public static string DanhSachTachThanhPhamSX = "QLBanHang.Modules.KhoHang.frmDanhSachTachThanhPhamSX";

            public static string DanhSachDeNghiNhanDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachDeNghiNhanDieuChuyenNew";
            public static string DanhSachNhanDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuNhanDieuChuyen";
            public static string DanhSachPhieuKiemKe = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuKiemKe";

            public static string frmBH_XuatKhoHangBan = "QLBanHang.Modules.BanHang.frmBH_XuatKhoHangBan";
            public static string frmCapNhatTonDauKy = "QLBanHang.Modules.KhoHang.frmCapNhatTonDauKy";
            public static string frmCSBCBangGiaChiTiet = "QLBanHang.Modules.KhoHang.frmBC_BangGiaChiTiet";
            public static string frmCSBCTinhTrangBangGia = "QLBanHang.Modules.KhoHang.frmBC_TinhTrangBangGia";
            public static string frmCSBCTinhTrangDonHang = "QLBanHang.Modules.KhoHang.frmBC_TinhTrangDonHang";
            public static string frmCSBCLichSuThayDoiGia = "QLBanHang.Modules.KhoHang.frmBC_LichSuThayDoiGia";
            public static string frmBaoCaoChiTietGiaoDichNhapHang = "QLBanHang.Modules.KhoHang.frm_BaoCaoChiTietGiaoDichNhapHang";
            public static string frmBaoCaoTongHopGiaoDichNhapHang = "QLBanHang.Modules.KhoHang.frm_BaoCaoTongHopGiaoDichNhapHang";
            public static string frmBaoCaoChiTietChuyenKho = "QLBanHang.Modules.KhoHang.frm_BaoCaoChiTietHangChuyenKho";
            public static string frmBaoCaoTongHopChuyenKho = "QLBanHang.Modules.KhoHang.frm_BaoCaoTongHopHangChuyenKho";
            public static string frmBaoCaoXuatLinhKienLapRap = "QLBanHang.Modules.KhoHang.frm_BaoCaoChiTietMaVachSanXuat";
            public static string frmBaoCaoLenhSXChuaXuatLK = "QLBanHang.Modules.KhoHang.frm_BaoCaoLenhSXChuaXuatLK";
            public static string frmBaoCaoXuatTieuHao = "QLBanHang.Modules.KhoHang.frm_BaoCaoDeNghiXuatTieuHao";
            public static string frmBaoCaoDongBoPO = "QLBanHang.Modules.KhoHang.frm_BaoCaoDongBoPO";
            public static string frmDanhSachNhapCombo = "QLBanHang.Modules.KhoHang.frmDanhSachNhapComBo";
            public static string frmDanhSachNhapDoiMa = "QLBanHang.Modules.KhoHang.frmDanhSachNhapDoiMa";
            // Báo cáo 
            public static string frmBaoCaoChiTietNhapChuyenKho = "QLBanHang.Modules.KhoHang.frm_BaoCaoChiTietNhanChuyenKho";
            public static string frmBaoCaoTongHopNhapChuyenKho = "QLBanHang.Modules.KhoHang.frm_BaoCaoTongHopNhanChuyenKho";
            public static string frmBaoCaoDanhMuc = "QLBanHang.Modules.KhoHang.frm_BaoCaoDanhMuc";
            public static string frmBaoCaoTonLichSu = "QLBanHang.Modules.KhoHang.frm_BaoCaoXuatNhapTonLichSu";
            public static string frmBaoCaoChiTietSanXuat = "QLBanHang.Modules.KhoHang.frmBaoCaoChiTietSanXuat";
            public static string frmBaoCaoTongHopSanXuat = "QLBanHang.Modules.KhoHang.frmBaoCaoTongHopSanXuat";
            public static string frmBaoCaoKiemKeMaVachBanNhieuLan = "QLBanHang.Modules.KhoHang.frm_BaoCaoKiemKeMaVachBanNhieuLan";
            public static string frmBaoCaoTongHopXuatTieuHao = "QLBanHang.Modules.KhoHang.frm_BaoCaoTongHopXuatTieuHao";
            public static string frmBaoCaoDanhSachNhapHangMua = "QLBanHang.Modules.KhoHang.frmBaoCaoDanhSachNhapHangMua";
            public static string frmBaoCaoChiTietNhapHangMua = "QLBanHang.Modules.KhoHang.frmBaoCaoChiTietNhapHangMua";
            public static string frmBaoCaoDanhSachNhapNoiBo = "QLBanHang.Modules.KhoHang.frmBaoCaoDanhSachNhapNoiBo";
            public static string frmBaoCaoChiTietNhapNoiBo = "QLBanHang.Modules.KhoHang.frmBaoCaoChiTietNhapNoiBo";
            public static string frmBaoCaoDanhSachXuatNoiBo = "QLBanHang.Modules.KhoHang.frmBaoCaoDanhSachXuatNoiBo";
            public static string frmBaoCaoChiTietXuatNoiBo = "QLBanHang.Modules.KhoHang.frmBaoCaoChiTietXuatNoiBo";
            public static string frmBaoCaoChiTietNhapTieuHao = "QLBanHang.Modules.KhoHang.frm_BaoCaoChiTietNhapTieuHao";
            public static string frmBaoCaoTongHopNhapTieuHao = "QLBanHang.Modules.KhoHang.frm_BaoCaoTongHopNhapTieuHao";
            public static string frmBaoCaoChiTietNhapXuatLK = "QLBanHang.Modules.KhoHang.frmBaoCaoChiTietGiaoDichNhapXuatLK";
            public static string frmBaoCaoTongHopNhapXuatLK = "QLBanHang.Modules.KhoHang.frmBaoCaoTongHopGiaoDichNhapXuatLK";
            public static string frmBaoCaoChiTietNhapXuatTP = "QLBanHang.Modules.KhoHang.frm_BaoCaoChiTietNhapXuatThanhPham";
            public static string frmBaoCaoTongHopNhapXuatTP = "QLBanHang.Modules.KhoHang.frm_BaoCaoTongHopNhapXuatThanhPham";
            public static string frmBaoCaoNhapXuatPOChuaXuat = "QLBanHang.Modules.KhoHang.frmBaoCaoCNhapXuatPOChuaXuat";
            public static string frmInNoteSP = "QLBanHang.Modules.KhoHang.frm_InNoteSanPham";
            public static string frmBaoCaoDieuChuyenChoNhan = "QLBanHang.Modules.KhoHang.frm_BaoCaoPhieuDieuChuyenChoNhan";
            public static string frmBaoCaoNhapTPChuaNhap = "QLBanHang.Modules.KhoHang.frmBaoCaoThanhPhamSanXuatChuaXacNhan";
            // Điều chuyển có kho trung gian
            public static string frmDanhSachDeNghiXuatDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuDeNghiXuatDieuChuyen";
            public static string frmDanhSachXuatDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuXuatDieuChuyen";
            public static string frmDanhSachDeNghiNhapDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuDeNghiNhapDieuChuyen";
            public static string frmDanhSachNhapDieuChuyen = "QLBanHang.Modules.KhoHang.frm_DanhSachPhieuNhapDieuChuyen";
            //kiem ke
            public static string frmDanhSachTongHopKiemKe = "QLBanHang.Modules.KhoHang.frm_DanhSachDotKiemKe";
            public static string frmBaoCaoKiemKeTonKho = "QLBanHang.Modules.KhoHang.frm_BaoCaoKiemKeTonKho";
            public static string frmBaoCaoKiemKeTonMaVach = "QLBanHang.Modules.KhoHang.frm_BaoCaoKiemKeTonMaVach";
            public static string frmBaoCaoDanhSachPhieuKiemKe = "QLBanHang.Modules.KhoHang.frm_BaoCaoDanhSachPhieuKiemKe";
            public static string frmDoiMaLinhKien = "QLBanHang.Modules.KhoHang.frmDoiMaLinhKien";
            public static string frmBCTonTrungChuyen = "QLBanHang.Modules.KhoHang.frm_BaoCaoTonTrungChuyen";

            public static string frmBaoCaoGiaoDichKhongDongBo =
                "QLBanHang.Modules.KhoHang.frm_BaoCaoGiaoDichKhongDongBo";

            public static string frmBCDieuChuyenKhoTongGiao =
                "QLBanHang.Modules.KhoHang.frm_BaoCaoDieuChuyenKhoTongGiao";
        }
        #endregion

        #region "TableNamespace"
        public static class TableNamespace
        {
            public const string DotKiemKe = "tbl_dotkiemke";
            public const string TmpDieuChuyenKho = "tbl_tmp_dieuchuyenkho";
            public const string TmpNhapXuatKho = "tbl_tmp_nhapxuatkho";
            public const string DmBangKeThue = "tbl_DM_BangKeThue";
            public const string DmDoiTuong = "tbl_DM_DoiTuong";
            public const string DmKhaiBao = "tbl_DM_KhaiBao";
            public const string DmLoaiThuChi = "tbl_DM_LoaiThuChi";
            public const string DmLoaiHoaDon = "tbl_DM_LoaiHD_BanHang";
            public const string DmOrderType = "tbl_DM_OrderType";
            public const string DmTienTe = "tbl_DM_TienTe";
            public const string DmQuyenHoaDon = "tbl_DM_HoaDon";
            public const string DmNhanVien = "tbl_DM_NhanVien";
            public const string DmChucVu = "tbl_DM_ChucVu";
            public const string DmChiPhi = "tbl_DM_ChiPhi";
            public const string DmPhongBan = "tbl_DM_PhongBan";
            public const string DmKhoNhanVien = "tbl_Kho_NhanVien";
            public const string DmKho = "tbl_DM_Kho";
            public const string DmTrungTam = "tbl_DM_TrungTam";
            public const string DmCachGiaoHang = "tbl_DM_CachGiaoHang";
            public const string DmLyDoTraHang = "tbl_DM_LyDoTraHang";
            public const string DmLyDoGiaoDich = "tbl_DM_LyDoGiaoDich";
            public const string DmMaLoi = "tbl_DM_MaLoi";
            public const string DmMaVung = "tbl_DM_MaVung";
            public const string DmThanhToan = "tbl_DM_HinhThucThanhToan";
            public const string DmLoaiDichVu = "tbl_DM_LoaiDichVu";
            public const string DoiTuongDiaChi = "tbl_DM_DoiTuong_DiaChi";
            public const string DmLoaiItem = "tbl_DM_LoaiItem";
            public const string DmSanPham = "tbl_SanPham";
            public const string DmChucNang = "tbl_DM_ChucNang";
            public const string DmChung = "tbl_DM_DL_Chung";
            public const string DmHang = "tbl_DM_DL_Hang";
            public const string DmLinhVuc = "tbl_DM_DL_LinhVuc";
            public const string DmLoai = "tbl_DM_DL_Loai";
            public const string DmModel = "tbl_DM_DL_Model";
            public const string DmNganh = "tbl_DM_DL_Nganh";
            public const string DmNhom = "tbl_DM_DL_Nhom";
            public const string DmDonViTinh = "tbl_DM_DonViTinh";
            public const string DmDuAn = "tbl_DM_DuAn";
            public const string DmNganHang = "tbl_DM_NganHang";
            public const string DmLoaiTheKhachHang = "tbl_DM_LoaiThe_KhachHang";
            public const string DmLoaiTheQuyenLoi = "tbl_DM_LoaiThe_QuyenLoi";
            public const string DmLoaiTheUuDai = "tbl_DM_LoaiThe_UuDai";
            public const string DmTaxCode = "tbl_DM_TaxCode";
            public const string DmNhomNguoiDung = "tbl_DM_NhomNguoiDung";
            public const string DmLoaiSanPham = "tbl_DM_LoaiSanPham";
            public const string DmCauHinhLoaiSP = "tbl_CauHinh_LoaiSanPham";
            public const string DmNguoiDung = "tbl_DM_NguoiDung";
            public const string tmp_NhapHang_User = "tmp_NhapHang_User";
            public const string tbl_ChungTu = "tbl_ChungTu";
            public const string tbl_ChungTu_ChiTiet = "tbl_ChungTu_ChiTiet";
            public const string tbl_ChungTu_ChiTiet_HangHoa = "tbl_ChungTu_ChiTiet_HangHoa";
            public const string tbl_ChiTiet_HangHoa = "tbl_HangHoa_ChiTiet";
            public const string tmp_NhapHang_Log = "tmp_NhapHang_Log";
            public const string tbl_HangTonKho = "tbl_HangTonKho";
            public const string tbl_The_Kho = "tbl_The_Kho";
            public const string DmLoaiDoiTuong = "tbl_DM_LoaiDoiTuong";
            public const string DmPhuongThucBanHang = "tbl_DM_PhuongThucBanHang";
            public const string tbl_ChungTu_ThanhToan = "tbl_ChungTu_ThanhToan";
            //public const string DmLoai = "tbl_DM_DL_Loai";
            //public const string DmChung = "tbl_DM_DL_Chung";
            //public const string DmHang = "tbl_DM_DL_Hang";
            //public const string DmModel = "tbl_DM_DL_Model";

            #region BaoHanh

            public const string bhYCHangXuLy = "TBL_BH_HANGXULY";
            public const string BhYeuCau = "tbl_BH_YeuCau";
            public const string BhPhieuNhanHangLoi = "tbl_bh_phieunhan";
            public const string BhItem = "tbl_bh_item";
            public const string BhCauHinhNhan = "tbl_bh_cauhinhnhan";
            public const string BhBaoHanh = "tbl_Bh_BaoHanh";
            public const string BhPhieuXuatMuon = "tbl_bh_phieuxuatmuon";
            public const string BhPhieuXuatMuonCT = "tbl_bh_phieuxuatmuonct";
            public const string BhPhieuXuatMuon_CT_HangHoa = "tbl_bh_phieuxuatmuon_ct_hanghoa";
            public const string BhThucHienBH = "tbl_bh_thuchienbh";
            public const string tbl_bh_phancongbh = "tbl_bh_phancongbh";
            public const string tbl_bh_TraBaoHanh = "tbl_bh_TraBaoHanh";
            public const string tbl_bh_damphanhang = "tbl_bh_damphanhang";

            public const string tbl_BH_HangNhanBH = "tbl_BH_HangNhanBH";
            // Tran Tuan Cuong 07/10/2012

            public const string BhBangKe = "tbl_Bh_BangKe";
            public const string BhHuyPhieuNhan = "TBL_BH_HUYPHIEUNHAN";
            public const string BhChitietBangKe = "tbl_Bh_ChiTietBangKe";
            public const string TBL_BH_DAMPHAN_KHACHLE = "TBL_BH_DAMPHAN_KHACHLE";

            public const string tbl_bh_lichsupc = "TBL_BH_LICHSUPC";
            public const string tbl_bh_loaihinhdichvu = "tbl_bh_loaihinhdichvu";
            public const string tbl_bh_chungtunhap = "tbl_bh_Chungtunhap";
            public const string tbl_bh_chinhsach_ncc = "tbl_bh_chinhsach_ncc";
            public const string tbl_bh_csncc_loaisp = "TBL_BH_CSNCC_LOAISP";
            public const string tbl_bh_csncc_ChiTiet = "TBL_BH_CSNCC_CHITIET";
            public const string tbl_bh_csncc_nhaplai = "tbl_bh_csncc_nhaplai";
            #endregion

            #region BanHang

            public const string BangGia = "tbl_BangGia";
            public const string BangGiaChiTiet = "tbl_BangGia_ChiTiet";
            public const string BangGiaChiTietLichSu = "tbl_BangGia_ChiTiet_LichSu";
            public const string BangGiaChiTietSPKem = "tbl_BangGia_ChiTiet_SPKem";
            public const string BangGiaDoiTuong = "tbl_BangGia_DoiTuong";
            public const string BangGiaThamSo = "tbl_BangGia_ThamSo";
            public const string NhomNDBanHang = "tbl_NhomND_BanHang";
            public const string SuDungHoaDon = "tbl_SuDung_HoaDon";

            #endregion
        }
        #endregion

        #region "StoreProcedureNamespace"
        public static class StoreProcedureNamespace
        {
            #region tbl_DM_BangKeThue
            public const string spBangKeThueSelectAll = "sp_BangKeThue_SelectAll";
            public const string spBangKeThueUpdate = "sp_DM_BangKeThue_Update";
            public const string spBangKeThueInsert = "sp_DM_BangKeThue_Insert";
            public const string spBangKeThueDelete = "sp_DM_BangKeThue_Delete";
            public const string spBangKeThueExist = "sp_DM_BangKeThue_Exist";
            public const string spBangKeThueSearch = "sp_DM_BangKeThue_Search";
            public const string spBangKeThueGetbyId = "sp_DM_BangKeThue_GetbyId";

            public const string spBangKeThueSyncGetLastUpdateDate = "sp_BangKeThue_Sync_LUD";
            public const string spBangKeThueSyncUpdate = "sp_PhuongThucBH_Sync_Update";
            public const string spBangKeThueSyncInsert = "sp_PhuongThucBH_Sync_Insert";
            public const string spBangKeThueSyncTransfer = "sp_BangKeThue_Sync_Transfer";
            #endregion

            #region tbl_Tmp_DM_BangKeThue
            public const string spTmpBangKeThueDelete = "sp_Tmp_BangKeThue_Delete";
            public const string spTmpBangKeThueSelectAll = "sp_Tmp_BangKeThue_SelectAll";
            public const string spTmpBangKeThueValid = "sp_Tmp_BangKeThue_Valid";
            #endregion

            #region tbl_DM_CachGiaoHang
            public const string spCachGiaoHangSelectAll = "sp_CachGiaoHang_SelectAll";
            public const string spCachGiaoHangUpdate = "sp_DM_CachGiaoHang_Update";
            public const string spCachGiaoHangInsert = "sp_DM_CachGiaoHang_Insert";
            public const string spCachGiaoHangDelete = "sp_DM_CachGiaoHang_Delete";
            public const string spCachGiaoHangExist = "sp_DM_CachGiaoHang_Exist";
            public const string spCachGiaoHangSearch = "sp_DM_CachGiaoHang_Search";
            public const string spCachGiaoHangGetbyId = "sp_DM_CachGiaoHang_GetbyId";

            public const string spCachGiaoHangSyncGetLastUpdateDate = "sp_CachGiaoHang_Sync_LUD";
            public const string spCachGiaoHangSyncUpdate = "sp_CachGiaoHang_Sync_Update";
            public const string spCachGiaoHangSyncInsert = "sp_CachGiaoHang_Sync_Insert";
            public const string spCachGiaoHangSyncTransfer = "sp_CachGiaoHang_Sync_Transfer";
            #endregion

            #region tbl_Tmp_DM_CachGiaoHang
            public const string spTmpCachGiaoHangDelete = "sp_Tmp_CachGiaoHang_Delete";
            public const string spTmpCachGiaoHangSelectAll = "sp_Tmp_CachGiaoHang_SelectAll";
            public const string spTmpCachGiaoHangValid = "sp_Tmp_CachGiaoHang_Valid";
            #endregion

            #region tbl_DM_LoaiHD_BanHang
            public const string spLoaiHoaDonSelectAll = "sp_LoaiHoaDon_SelectAll";

            public const string spLoaiHoaDonSyncGetLastUpdateDate = "sp_LoaiHoaDon_Sync_LUD";
            public const string spLoaiHoaDonSyncUpdate = "sp_LoaiHoaDon_Sync_Update";
            public const string spLoaiHoaDonSyncInsert = "sp_LoaiHoaDon_Sync_Insert";
            public const string spLoaiHoaDonSyncTransfer = "sp_LoaiHoaDon_Sync_Transfer";
            public const string spLoaiHoaDonUpdate = "sp_DM_LoaiHoaDon_Update";
            public const string spLoaiHoaDonInsert = "sp_DM_LoaiHoaDon_Insert";
            public const string spLoaiHoaDonDelete = "sp_DM_LoaiHoaDon_Delete";
            public const string spLoaiHoaDonSearch = "sp_DM_LoaiHoaDon_Search";
            public const string spLoaiHoaDonExist = "sp_DM_LoaiHoaDon_Exist";
            public const string spLoaiHoaDonGetbyId = "sp_DM_LoaiHoaDon_GetbyId";

            #endregion

            #region tbl_Tmp_DM_LoaiHoaDon
            public const string spTmpLoaiHoaDonDelete = "sp_Tmp_LoaiHoaDon_Delete";
            public const string spTmpLoaiHoaDonSelectAll = "sp_Tmp_LoaiHoaDon_SelectAll";
            public const string spTmpLoaiHoaDonValid = "sp_Tmp_LoaiHoaDon_Valid";
            #endregion

            #region tbl_DM_LyDoGiaoDich
            public const string spLyDoGiaoDichSelectAll = "sp_LyDoGiaoDich_SelectAll";
            public const string spLyDoGiaoDichUpdate = "sp_DM_LyDoGiaoDich_Update";
            public const string spLyDoGiaoDichInsert = "sp_DM_LyDoGiaoDich_Insert";
            public const string spLyDoGiaoDichDelete = "sp_DM_LyDoGiaoDich_Delete";
            public const string spLyDoGiaoDichExist = "sp_DM_LyDoGiaoDich_Exist";
            public const string spLyDoGiaoDichSearch = "sp_DM_LyDoGiaoDich_Search";
            public const string spLyDoGiaoDichGetbyId = "sp_DM_LyDoGiaoDich_GetbyId";

            public const string spLyDoGiaoDichSyncGetLastUpdateDate = "sp_LyDoGiaoDich_Sync_LUD";
            public const string spLyDoGiaoDichSyncUpdate = "sp_LyDoGiaoDich_Sync_Update";
            public const string spLyDoGiaoDichSyncInsert = "sp_LyDoGiaoDich_Sync_Insert";
            public const string spLyDoGiaoDichSyncTransfer = "sp_LyDoGiaoDich_Sync_Transfer";
            #endregion

            #region tbl_Tmp_DM_LyDoGiaoDich
            public const string spTmpLyDoGiaoDichDelete = "sp_Tmp_LyDoGiaoDich_Delete";
            public const string spTmpLyDoGiaoDichSelectAll = "sp_Tmp_LyDoGiaoDich_SelectAll";
            public const string spTmpLyDoGiaoDichValid = "sp_Tmp_LyDoGiaoDich_Valid";
            #endregion

            #region tbl_DM_LyDoTraHang
            public const string spLyDoTraHangSelectAll = "sp_LyDoTraHang_SelectAll";

            public const string spLyDoTraHangSyncGetLastUpdateDate = "sp_LyDoTraHang_Sync_LUD";
            public const string spLyDoTraHangSyncUpdate = "sp_LyDoTraHang_Sync_Update";
            public const string spLyDoTraHangSyncInsert = "sp_LyDoTraHang_Sync_Insert";
            public const string spLyDoTraHangSyncTransfer = "sp_LyDoTraHang_Sync_Transfer";

            public const string spLyDoTraHangUpdate = "sp_DM_LyDoTraHang_Update";
            public const string spLyDoTraHangInsert = "sp_DM_LyDoTraHang_Insert";
            public const string spLyDoTraHangDelete = "sp_DM_LyDoTraHang_Delete";
            public const string spLyDoTraHangExist = "sp_DM_LyDoTraHang_Exist";
            public const string spLyDoTraHangSearch = "sp_DM_LyDoTraHang_Search";
            public const string spLyDoTraHangGetbyId = "sp_DM_LyDoTraHang_GetbyId";

            #endregion

            #region tbl_Tmp_DM_LyDoTraHang
            public const string spTmpLyDoTraHangDelete = "sp_Tmp_LyDoTraHang_Delete";
            public const string spTmpLyDoTraHangSelectAll = "sp_Tmp_LyDoTraHang_SelectAll";
            public const string spTmpLyDoTraHangValid = "sp_Tmp_LyDoTraHang_Valid";
            #endregion

            #region tbl_DM_TrungTam

            public const string SP_DM_TRUNGTAM_GETALLTRUNGTAM = "SP_DM_TRUNGTAM_GETALLTRUNGTAM";
            public const string spTrungTamSelectAll = "sp_TrungTam_SelectAll";
            public const string spTrungTamSelectAllBaoHanh = "sp_TrungTam_GetAllBHanh";
            public const string spTrungTamSelectPair = "sp_TrungTam_SelectPair";
            /// <summary>
            /// Trả về danh sách trung tâm theo ID nhân viên
            /// </summary>
            public const string spTrungTamGetAllByIdNhanVien = "sp_TrungTam_GetByIdNVienBHanh";
            public const string spTrungTamSelectByIdNhanVien = "sp_TrungTam_SelectByIdNhanVien";
            public const string spTrungTamUpdate = "sp_TrungTam_Update";
            public const string spTrungTamDelete = "sp_TrungTam_Delete";
            public const string spTrungTamInsert = "sp_TrungTam_Insert";
            public const string spTrungTamSyncUpdate = "sp_TrungTam_Sync_Update";
            public const string spTrungTamSyncInsert = "sp_TrungTam_Sync_Insert";
            public const string spTrungTamSyncTransfer = "sp_TrungTam_Sync_Transfer";
            public const string spTrungTamSyncGetLastUpdateDate = "sp_TrungTam_Sync_LUD";
            public const string spTrungTamExist = "sp_TrungTam_Exist";
            public const string spTrungTamSearch = "sp_TrungTam_Search";
            public const string spTrungTamGetById = "sp_TrungTam_GetById";
            public const string spTrungTamGetByIdKho = "sp_TrungTam_GetByIdKho";
            public const string spTrungTamGetByText = "sp_TrungTam_GetByText";
            public const string spTrungTamGetByMa = "sp_TrungTam_GetByMa";
            public const string spTrungTamLoadNoWeb = "sp_TrungTam_LoadNoWeb";
            #endregion

            #region tbl_Tmp_TrungTam
            public const string spTmpTrungTamDelete = "sp_Tmp_TrungTam_Delete";
            public const string spTmpTrungTamSelectAll = "sp_Tmp_TrungTam_SelectAll";
            public const string spTmpTrungTamValid = "sp_Tmp_TrungTam_Valid";
            #endregion

            #region tbl_DM_TienTe
            public const string spTienTeSelectAll = "sp_TienTe_SelectAll";
            public const string spTienTeUpdate = "sp_DM_TienTe_Update";
            public const string spTienTeDelete = "sp_DM_TienTe_Delete";
            public const string spTienTeInsert = "sp_DM_TienTe_Insert";
            public const string spTienTeExist = "sp_TienTe_Exist";
            public const string spTienTeSearch = "sp_TienTe_Search";
            public const string spTienTeGetbyId = "sp_TienTe_GetbyId";
            #endregion

            #region tbl_DM_HoaDon
            public const string spHoaDonSelectAll = "sp_HoaDon_SelectAll";
            public const string spHoaDonGetAllEmpty = "sp_HoaDon_GetAllEmpty";
            public const string spHoaDonUpdate = "sp_DM_HoaDon_Update";
            public const string spHoaDonDelete = "sp_DM_HoaDon_Delete";
            public const string spHoaDonInsert = "sp_DM_HoaDon_Insert";
            public const string spHoaDonExist = "sp_HoaDon_Exist";
            public const string spHoaDonSearch = "sp_HoaDon_search";
            public const string spHoaDonGetById = "sp_QuyenHoaDon_GetById";
            #endregion

            #region tbl_DM_TaxCode
            public const string spTaxCodeSyncGetLastUpdateDate = "sp_TaxCode_Sync_LUD";
            public const string spTaxCodeSyncTransfer = "sp_TaxCode_Sync_Transfer";
            public const string spTaxCodeSyncSelectAll = "sp_TaxCode_Sync_SelectAll";
            public const string spTaxCodeSyncInsert = "sp_DM_TaxCode_Sync_Insert";
            public const string spTaxCodeSyncUpdate = "sp_DM_TaxCode_Sync_Update";
            public const string spTaxCodeSelectAll = "sp_TaxCode_SelectAll";
            public const string spTaxCodeUpdate = "sp_DM_TaxCode_Update";
            public const string spTaxCodeDelete = "sp_DM_TaxCode_Delete";
            public const string spTaxCodeInsert = "sp_DM_TaxCode_Insert";
            public const string spTaxCodeExist = "sp_TaxCode_Exist";
            public const string spTaxCodeSearch = "sp_TaxCode_Search";
            public const string spTaxCodeGetById = "sp_TaxCode_GetById";
            #endregion

            #region tbl_Tmp_TaxCode
            public const string spTmpTaxCodeSelectAll = "sp_Tmp_TaxCode_SelectAll";
            public const string spTmpTaxCodeDelete = "sp_Tmp_TaxCode_Delete";
            public const string spTmpTaxCodeValid = "sp_Tmp_TaxCode_Valid";
            #endregion

            #region tbl_DM_PhongBan
            public const string spPhongBanSelectAll = "sp_PhongBan_SelectAll";
            public const string spPhongBanSelectActived = "sp_PhongBan_SelectActived";
            public const string spPhongBanUpdate = "sp_DM_PhongBan_Update";
            public const string spPhongBanDelete = "sp_DM_PhongBan_Delete";
            public const string spPhongBanInsert = "sp_DM_PhongBan_Insert";
            public const string spPhongBanSyncInsert = "sp_DM_PhongBan_Sync_Insert";
            public const string spPhongBanSyncUpdate = "sp_DM_PhongBan_Sync_Update";
            public const string spPhongBanSyncTransfer = "sp_DM_PhongBan_Sync_Transfer";
            public const string spPhongBanSyncGetLastUpdateDate = "sp_DM_PhongBan_Sync_LUD";
            public const string spPhongBanExist = "sp_PhongBan_Exist";
            public const string spPhongBanSelectPair = "sp_PhongBan_SelectPair";
            public const string spPhongBanSearch = "sp_PhongBan_Search";
            public const string spPhongBanGetById = "sp_PhongBan_GetById";

            #endregion

            #region tbl_Tmp_PhongBan
            public const string spTmpPhongBanDelete = "sp_Tmp_PhongBan_Delete";
            public const string spTmpPhongBanSelectAll = "sp_Tmp_PhongBan_SelectAll";
            public const string spTmpPhongBanValid = "sp_Tmp_PhongBan_Valid";
            #endregion

            #region tbl_DM_NhanVien
            public const string spNhanVienSyncGetLastUpdateDate = "sp_NhanVien_Sync_LUD";
            public const string spNhanVienSyncTransfer = "sp_NhanVien_Sync_Transfer";
            public const string spNhanVienSyncInsert = "sp_NhanVien_Sync_Insert";
            public const string spNhanVienSyncUpdate = "sp_NhanVien_Sync_Update";
            public const string spNhanVienSyncSelectAll = "sp_NhanVien_Sync_SelectAll";

            public const string spNhanVienSelectAll = "sp_NhanVien_SelectAll";
            public const string spNhanVienUsingSelectAll = "sp_NhanVien_Using_SelectAll";
            public const string spNhanVienSelectPair = "sp_NhanVien_SelectPair";
            public const string sp_NhanVien_Update = "sp_NhanVien_Update";
            public const string spNhanVienInsert = "sp_NhanVien_Insert";
            public const string spNhanVienDelete = "sp_NhanVien_Delete";
            public const string spNhanVienExist = "sp_NhanVien_Exist";
            public const string spNhanVienSearch = "sp_NhanVien_Search";
            public const string spNhanVienGetById = "sp_NhanVien_GetById";
            public const string sp_DM_NhanVien_Insert = "sp_DM_NhanVien_Insert";
            /// <summary>
            /// Trả về danh sách các nhân viên được phép lookup theo user hiện tại
            /// </summary>
            public const string spNhanVienGetAllByUserId = "sp_NhanVien_GetAllByUserId";
            public const string spNhanVienGetByUserId = "sp_NhanVien_GetByUserId";
            public const string spNhanVienGetAllByTrungTamId = "sp_NhanVien_GetAllByTrungTamId";
            public const string spNhanVienGetByTrungTamId = "sp_NhanVien_GetByTrungTamId";
            public const string spNhanVienGetTruongCaByUser = "sp_NhanVien_GetTruongCaByUser";
            public const string spNhanVienGetTruongCaByIdKho = "sp_NhanVien_GetTruongCaByIdKho";
            public const string spNhanVienGetByCodeAndUserId = "sp_NhanVien_GetByCode_UserId";
            public const string spNhanVienGetByText = "sp_NhanVien_GetByText";
            public const string spNhanVienGetByMaVach = "sp_NhanVien_GetByMaVach";
            /// <summary>
            /// Trả về danh sách nhân viên thuộc kho id /n
            /// - check điều kiện xóa kho
            /// </summary>
            public const string spNhanVienGetByKhoId = "sp_NhanVien_GetByKho";
            public const string spNhanVienGetByIdKho = "sp_NhanVien_GetByIdKho";
            #endregion

            #region tbl_tmp_DM_NhanVien
            public const string spTmpNhanVienDelete = "sp_Tmp_NhanVien_Delete";
            public const string spTmpNhanVienSelectAll = "sp_Tmp_NhanVien_SelectAll";
            public const string spTmpNhanVienValid = "sp_Tmp_NhanVien_Valid";

            #endregion

            #region tbl_Kho_NhanVien
            public const string spKhoNhanVienSelectAll = "sp_Kho_NhanVien_SelectAll";
            public const string spKhoNhanVienInsert = "sp_Kho_NhanVien_Insert";
            public const string spKhoNhanVienDelete = "sp_Kho_NhanVien_Delete";
            public const string spKhoNhanVienSelectByidNhanvien = "sp_Kho_NV_SelectidNhanVien";
            #endregion

            #region tbl_DoiTuong_DiaChi
            public const string spDoiTuongDiaChiInsert = "sp_DoiTuong_DiaChi_Insert";
            public const string spDoiTuongDiaChiDelete = "sp_DoiTuong_DiaChi_Delete";
            public const string spDoiTuongDiaChiSelectByidDoiTuong = "sp_DoiTuong_DiaChi_GetById";
            #endregion

            #region TransType
            public const string spTransTypeSelectAll = "sp_TransType_GetAll";
            #endregion

            #region tbl_DM_OrderType
            public const string spOrderTypeSelectAll = "sp_OrderType_SelectAll";
            public const string spOrderTypeUpdate = "sp_DM_OrderType_Update";
            public const string spOrderTypeDelete = "sp_DM_OrderType_Delete";
            public const string spOrderTypeInsert = "sp_DM_OrderType_Insert";
            public const string spOrderTypeSyncSelectAll = "sp_OrderType_Sync_SelectAll";
            public const string spOrderTypeSyncUpdate = "sp_DM_OrderType_Sync_Update";
            public const string spOrderTypeSyncInsert = "sp_DM_OrderType_Sync_Insert";
            public const string spOrderTypeSyncTransfer = "sp_OrderType_Sync_Transfer";
            public const string spOrderTypeSyncGetLastUpdateDate = "sp_OrderType_Sync_LUD";
            public const string spOrderTypeExist = "sp_OrderType_Exist";
            public const string spOrderTypeSelectPair = "sp_OrderType_SelectPair";
            public const string spOrderTypeGetbyId = "sp_OrderType_GetbyId";
            public const string spOrderTypeSearch = "sp_OrderType_Search";

            #endregion

            #region tbl_Tmp_OrderType
            public const string spTmpOrderTypeSelectAll = "sp_Tmp_OrderType_SelectAll";
            public const string spTmpOrderTypeDelete = "sp_Tmp_OrderType_Delete";
            public const string spTmpOrderTypeValid = "sp_Tmp_OrderType_Valid";
            #endregion

            #region tbl_DM_MaLoi
            public const string spMaLoiSelectAll = "sp_MaLoi_SelectAll";
            public const string spMaLoiUpdate = "sp_MaLoi_Update";
            public const string spMaLoiDelete = "sp_MaLoi_Delete";
            public const string spMaLoiInsert = "sp_MaLoi_Insert";
            public const string spMaLoiExist = "sp_MaLoi_Exist";
            public const string spMaLoiSearch = "sp_MaLoi_Search";
            public const string spMaLoitById = "sp_MaLoi_GetById";

            #endregion

            #region tbl_DM_MaVung
            public const string spMaVungSelectAll = "sp_MaVung_SelectAll";
            #endregion

            #region tbl_DM_Kho
            public const string spKhoSelectAll = "sp_Kho_SelectAll";
            public const string spKhoSelectAllEx3 = "sp_Kho_SelectAll_Ex3";
            public const string spKhoSelectPair = "sp_Kho_SelectPair";
            public const string spKhoSelectOtherByNhanVien = "sp_Kho_SelectOtherByNhanVien";
            public const string spKhoSelectByNhanVien = "sp_Kho_SelectByNhanVien";
            public const string spKhoSelectInforByIdNhanVien = "sp_Kho_SelectByIdNhanVien";
            public const string spKhoSelectInforByIdNhanVien2 = "sp_Kho_SelectByIdNhanVien2";
            public const string spKhoDieuChuyenSelectByIdNhanVien = "sp_Kho_DCSelectByIdNhanVien";
            public const string spKhoSelectByUser = "sp_Kho_SelectByUser";
            public const string spKhoSelectPairByTrungTam = "sp_Kho_SelectPairByTrungTam";
            public const string spKhoInsert = "sp_Kho_Insert";
            public const string spKhoUpdate = "sp_Kho_Update";
            public const string spKhoDelete = "sp_Kho_Delete";
            public const string spKhoSyncInsert = "sp_Kho_Sync_Insert";
            public const string spKhoSyncUpdate = "sp_Kho_Sync_Update";
            public const string spKhoSyncTransfer = "sp_Kho_Sync_Transfer";
            public const string spKhoSyncSelectAll = "sp_Kho_Sync_SelectAll";
            public const string spKhoSyncGetLastUpdateDate = "sp_Kho_Sync_LUD";
            public const string spKhoExist = "sp_Kho_Exist";
            public const string spKhoSearch = "sp_Kho_Search";
            public const string spKhoGetById = "sp_Kho_GetById";
            public const string spKhoGetByCode = "sp_Kho_GetByCode";
            public const string spKhoGetByTrungTamNhanVien = "sp_Kho_GetByTrungTamNhanVien";
            public const string spKhoNhapLaiGetByTrungTamNhanVien = "sp_KhoNL_GetByTrungTamNhanVien";
            public const string spKhoUpdateLanDongBo = "sp_Kho_LanDongBo_Update";
            public const string spGetIdTrungTamByIdKho = "sp_GetIdTrungTamByIdKho";
            public const string spKhoGetByText = "sp_Kho_GetByText";
            public const string SP_DM_KHO_GETINFORKHO = "SP_DM_KHO_GETINFORKHO";
            public const string sp_Dm_Kho_GetKhoByIdTrungTam = "sp_Dm_Kho_GetKhoByIdTrungTam";
            public const string sp_dm_kho_getkhoandtentrungtam = "sp_dm_kho_getkhoandtentrungtam";
            #endregion

            #region tbl_Tmp_Kho
            public const string spTmpKhoSelectAll = "sp_Tmp_Kho_SelectAll";
            public const string spTmpKhoDelete = "sp_Tmp_Kho_Delete";
            public const string spTmpKhoValid = "sp_Tmp_Kho_Valid";
            public const string spKhoChungTuGetByLoaiChungTu = "sp_Kho_CTU_SelectByLoaiChungTu";
            public const string spKhoChungTuGetListXuatTieuHao = "sp_Kho_CTU_GetListXuatTieuHao";
            public const string spKhoChungTuGetPhieuXuatTieuHao = "sp_Kho_Ctu_GetPhieuXuatTieuHao";
            public const string spKhoChungTuGetListNhapTieuHao = "sp_Kho_CTU_GetListNhapTieuHao";
            public const string spKhoChungTuGetListXuatDieuChuyen = "sp_Kho_CTU_GetListXuatDC";
            public const string spKhoChungTuGetFillterXuatDieuChuyen = "sp_Kho_CTU_GetFillterXuatDC";
            public const string spKhoChungTuGetListNhanDieuChuyen = "sp_Kho_CTU_GetListNhanDC";
            public const string spKhoChungTuGetListNhanDieuChuyenTG = "sp_Kho_CTU_GetListNhanDCTG";
            public const string spKhoChungTuGetFillterNhanDieuChuyen = "sp_Kho_CTU_GetFillterNhanDC";
            public const string spKhoChungTuGetListXuatNoiBo = "sp_Kho_CTU_GetListXuatNoiBo";
            public const string spKhoChungTuGetListNhapNoiBo = "sp_Kho_CTU_GetListNhapNoiBo";
            public const string spKhoChungTuGetListXLK = "sp_Kho_CTU_GetListXuatLinhKien";
            public const string spKhoChungTuGetListNTP = "sp_Kho_CTU_GetListNhapTP";
            public const string spKhoChungTuGetTrungMaVach = "sp_TrungMaVach_SelectAll";
            public const string spHangTonKhoGetbyIdSP = "sp_HangTonKho_GetbyIdSP";

            #endregion
            /// <summary>
            /// dùng cho nhập xuất nội bộ
            /// </summary>
            public const string spGetIdDoiTuongByPO = "sp_SelectIdDoiTuongbyPO";

            #region tbl_DM_LoaiThuChi
            public const string spLoaiThuChiSelectAll = "sp_LoaiThuChi_SelectAll";
            public const string spLoaiThuChiUpdate = "sp_DM_LoaiThuChi_Update";
            public const string spLoaiThuChiInsert = "sp_DM_LoaiThuChi_Insert";
            public const string spLoaiThuChiDelete = "sp_DM_LoaiThuChi_Delete";
            public const string spLoaiThuChiExist = "sp_LoaiThuChi_Exist";
            public const string spLoaiThuChiSearch = "sp_LoaiThuChi_Search";
            public const string spLoaiThuChiGetbyId = "sp_LoaiThuChi_GetbyId";
            public const string spLoaiThuChiSyncGetLastUpdateDate = "sp_LoaiThuChi_Sync_LUD";
            public const string spLoaiThuChiSyncTransfer = "sp_LoaiThuChi_Sync_Transfer";
            public const string spLoaiThuChiSyncInsert = "sp_LoaiThuChi_Sync_Insert";
            public const string spLoaiThuChiSyncUpdate = "sp_LoaiThuChi_Sync_Update";
            public const string spLoaiThuChiGetbyText = "sp_LoaiThuChi_GetbyText";

            #endregion

            #region tbl_tmp_dm_payment
            public const string spTmpPaymentDelete = "sp_Tmp_Payment_Delete";
            public const string spTmpPaymentSelectAll = "sp_Tmp_Payment_SelectAll";
            public const string spTmpPaymentValid = "sp_Tmp_Payment_Valid";

            #endregion

            #region tbl_DM_DoiTuong
            public const string spDoiTuongSelectAll = "sp_DoiTuong_SelectAll";
            public const string spDoiTuongSelectPair = "sp_DoiTuong_SelectPair";
            public const string spDoiTuongUpdate = "sp_DoiTuong_Update";
            public const string spDoiTuongInsert = "sp_DoiTuong_Insert";
            public const string spDoiTuongDelete = "sp_DoiTuong_Delete";
            public const string spDoiTuongSyncInsert = "sp_DoiTuong_Sync_Insert";
            public const string spDoiTuongSyncUpdate = "sp_DoiTuong_Sync_Update";
            public const string spDoiTuongSyncTransfer = "sp_DoiTuong_Sync_Transfer";
            public const string spDoiTuongSyncGetLastUpdateDate = "sp_DoiTuong_Sync_LUD";
            public const string spDoiTuongExist = "sp_DoiTuong_Exist";
            public const string spDoiTuongLeExist = "sp_DoiTuongLe_Exist";
            public const string spDoiTuongSearch = "sp_DoiTuong_Search";
            public const string spDoiTuongSearchRieng = "sp_DoiTuong_SearchRieng";
            public const string spDoiTuongGetById = "sp_DoiTuong_GetById";
            public const string spDoiTuongSelectEx = "sp_DoiTuong_SelectEx";
            public const string spDoiTuongGetByLoaiDT = "sp_DoiTuong_GetByLoaiDT";
            public const string spDoiTuongSelectKL = "sp_doituong_selectKL";
            public const string spDoiTuongSelectKLByCode = "sp_doituong_selectKLByCode";
            public const string spDoiTuongSelectAllByLoaiDT = "sp_DoiTuong_SelectByLoaiDT";
            public const string spDoiTuongSelectByType = "sp_DoiTuong_SelectByType";
            public const string spDoiTuongGetByLoaiDTCode = "sp_DoiTuong_GetByLoaiDTCode";
            public const string spDoiTuongGetByCode = "sp_doituong_getByCode";
            public const string spDoiTuongGetBySoPO = "sp_doituong_getBySoPO";
            public const string spDoiTuongGetByText = "sp_DoiTuong_GetByText";
            public const string spDoiTuongGetKLByText = "sp_DoiTuong_GetKLByText";
            public const string spDoiTuongGetDTacGVan = "sp_doituong_getdtacgvan";
            #endregion

            #region tbl_CauHinh_SanPham

            public const string spNhaCCGetByIdSanPham = "sp_NhaCC_GetById";
            public const string spCauHinhSanPhamSelectAll = "sp_CauHinhSanPham_SelectAll";
            public const string spCauHinhSanPhamUpdate = "sp_CauHinhSanPham_Update";
            public const string spCauHinhSanPhamInsert = "sp_CauHinhSanPham_Insert";
            public const string spCauHinhSanPhamDelete = "sp_CauHinhSanPham_Delete";
            public const string spCauHinhSanPhamSearch = "sp_CauHinhSanPham_Search";
            public const string spCauHinhSanPhamSearchKhong = "sp_CauHinhSanPham_SearchKhong";
            public const string spCauHinhSanPhamGetbyId = "sp_CauHinhSanPham_GetbyId";
            public const string spCauHinhSanPhamUpdateLogo = "sp_CauHinhSanPham_Update_Logo";
            public const string spCauHinhSanPhamExists = "sp_CauHinhSanPham_Exists";
            #endregion

            #region tbl_Tmp_DoiTuong
            public const string spTmpDoiTuongDelete = "sp_Tmp_DoiTuong_Delete";
            public const string spTmpDoiTuongSelectAll = "sp_Tmp_DoiTuong_SelectAll";
            public const string spTmpDoiTuongValid = "sp_Tmp_DoiTuong_Valid";
            #endregion

            #region tbl_DM_LoaiSanPham
            public const string spLoaiSanPhamSelectAll = "sp_LoaiSanPham_SelectAll";
            public const string spLoaiSanPhamSelectPair = "sp_LoaiSanPham_SelectPair";
            public const string spLoaiSanPhamUpdate = "sp_LoaiSanPham_Update";
            public const string spLoaiSanPhamInsert = "sp_LoaiSanPham_Insert";
            public const string spLoaiSanPhamDelete = "sp_LoaiSanPham_Delete";
            public const string spLoaiSanPhamExist = "sp_LoaiSanPham_Exist";
            public const string spLoaiSanPhamSearch = "sp_LoaiSanPham_Search";
            public const string spLoaiSanPhamGetById = "sp_LoaiSanPham_GetById";
            public const string spLoaiSanPhamGetByCode = "sp_LoaiSanPham_GetByCode";
            public const string spLoaiSanPhamGetByText = "sp_LoaiSanPham_GetByText";

            public const string spLoaiSanPhamSyncGetLastUpdateDate = "sp_LoaiSanPham_Sync_LUD";
            public const string spLoaiSanPhamSyncTransfer = "sp_LoaiSanPham_Sync_Transfer";
            public const string spLoaiSanPhamSyncInsert = "sp_LoaiSanPham_Sync_Insert";
            public const string spLoaiSanPhamSyncUpdate = "sp_LoaiSanPham_Sync_Update";
            #endregion

            #region tbl_Tmp_DM_LoaiSanPham
            public const string spTmpLoaiSanPhamDelete = "sp_Tmp_LoaiSanPham_Delete";
            public const string spTmpLoaiSanPhamSelectAll = "sp_Tmp_LoaiSanPham_SelectAll";
            public const string spTmpLoaiSanPhamValid = "sp_Tmp_LoaiSanPham_Valid";
            #endregion

            #region tbl_CauHinh_LoaiSanPham
            public const string spCauHinhLoaiSanPhamSelectAll = "sp_CauHinh_LoaiSP_SelectAll";
            //public const string spCauHinhLoaiSanPhamSelectPair = "sp_LoaiSanPham_SelectPair";
            public const string spCauHinhLoaiSanPhamUpdate = "sp_CauHinh_LoaiSanPham_Update";
            public const string spCauHinhLoaiSanPhamInsert = "sp_CauHinh_LoaiSanPham_Insert";
            public const string spCauHinhLoaiSanPhamDelete = "sp_CauHinh_LoaiSanPham_Delete";
            public const string spCauHinhLoaiSanPhamExist = "sp_CauHinh_LoaiSanPham_Exist";
            public const string spCauHinhLoaiSanPhamSearch = "sp_CauHinh_LoaiSanPham_Search";
            public const string spCauHinhLoaiSanPhamGetById = "sp_CauHinh_LoaiSanPham_GetById";
            #endregion

            #region tbl_DM_LoaiItem
            public const string spLoaiItemSelectAll = "sp_LoaiItem_SelectAll";
            public const string spLoaiItemUpdate = "sp_LoaiItem_Update";
            public const string spLoaiItemInsert = "sp_LoaiItem_Insert";
            public const string spLoaiItemDelete = "sp_LoaiItem_Delete";
            public const string spLoaiItemExist = "sp_LoaiItem_Exist";
            public const string spLoaiItemSearch = "sp_LoaiItem_Search";
            public const string spLoaiItemGetById = "sp_LoaiItem_GetById";
            #endregion

            #region tbl_DM_LoaiDichVu
            public const string spLoaiDichVuSelectAll = "sp_LoaiDichVu_SelectAll";
            public const string spLoaiDichVuUpdate = "sp_LoaiDichVu_Update";
            public const string spLoaiDichVuInsert = "sp_LoaiDichVu_Insert";
            public const string spLoaiDichVuDelete = "sp_LoaiDichVu_Delete";
            public const string spLoaiDichVuExist = "sp_LoaiDichVu_Exist";
            public const string spLoaiDichVuSearch = "sp_LoaiDichVu_Search";
            public const string spLoaiDichVuGetById = "sp_DichVu_GetById";
            #endregion

            #region tbl_DM_DuAn
            public const string spDuAnSelectAll = "sp_DuAn_SelectAll";
            public const string spDuAnUpdate = "sp_DM_DuAn_Update";
            public const string spDuAnInsert = "sp_DM_DuAn_Insert";
            public const string spDuAnDelete = "sp_DM_DuAn_Delete";
            public const string spDuAnExist = "sp_DuAn_Exist";
            public const string spDuAnSearch = "sp_DuAn_Search";
            public const string spDuAnGetbyId = "sp_DuAn_GetbyId";
            public const string spDuAnSyncGetLastUpdateDate = "sp_DuAn_Sync_LUD";
            public const string spDuAnSyncTransfer = "sp_DuAn_Sync_Transfer";
            public const string spDuAnSyncInsert = "sp_DuAn_Sync_Insert";
            public const string spDuAnSyncUpdate = "sp_DuAn_Sync_Update";
            #endregion

            #region tbl_Tmp_DM_DuAn
            public const string spTmpDuAnDelete = "sp_Tmp_DuAn_Delete";
            public const string spTmpDuAnSelectAll = "sp_Tmp_DuAn_SelectAll";
            public const string spTmpDuAnValid = "sp_Tmp_DuAn_Valid";
            #endregion

            #region tbl_DM_DonViTinh
            public const string spDonViTinhSelectAll = "sp_DonViTinh_SelectAll";
            public const string spDonViTinhUpdate = "sp_DM_DonViTinh_Update";
            public const string spDonViTinhInsert = "sp_DM_DonViTinh_Insert";
            public const string spDonViTinhDelete = "sp_DM_DonViTinh_Delete";
            public const string spDonViTinhExist = "sp_DonViTinh_Exist";
            public const string spDonViTinhLoad = "sp_DonViTinh_SelectPair";
            public const string spDonViTinhSearch = "sp_DonViTinh_Search";
            public const string spDonViTinhGetbyId = "sp_DonViTinh_GetbyId";
            public const string spDonViTinhIsUsed = "sp_DonViTinh_IsUsed";
            public const string spDonViTinhSyncInsert = "sp_DM_DonViTinh_Sync_Insert";
            public const string spDonViTinhSyncUpdate = "sp_DM_DonViTinh_Sync_Update";
            public const string spDonViTinhSyncTransfer = "sp_DM_DonViTinh_Sync_Transfer";
            public const string spDonViTinhSyncGetLastUpdateDate = "sp_DonViTinh_Sync_LUD";
            #endregion

            #region tbl_Tmp_DonViTinh
            public const string spTmpDonViTinhSelectAll = "sp_Tmp_DonViTinh_SelectAll";
            public const string spTmpDonViTinhDelete = "sp_Tmp_DonViTinh_Delete";
            public const string spTmpDonViTinhValid = "sp_Tmp_DonViTinh_Valid";
            #endregion

            #region tbl_DM_ChucVu
            public const string spChucVuSelectAll = "sp_ChucVu_SelectAll";
            public const string spChucVuUpdate = "sp_DM_ChucVu_Update";
            public const string spChucVuInsert = "sp_DM_ChucVu_Insert";
            public const string spChucVuDelete = "sp_DM_ChucVu_Delete";
            public const string spChucVuExist = "sp_ChucVu_Exist";
            public const string spChucVuSelectPair = "sp_ChucVu_SelectPair";
            public const string spChucVuSearch = "sp_ChucVu_Search";
            public const string spChucVuGetbyId = "sp_ChucVu_GetbyId";

            #endregion

            #region tbl_DM_ChucNang
            public const string spChucNangSelectAll = "sp_ChucNang_SelectAll";
            public const string spChucNangUpdate = "sp_DM_ChucNang_Update";
            public const string spChucNangInsert = "sp_DM_ChucNang_Insert";
            public const string spChucNangDelete = "sp_DM_ChucNang_Delete";
            public const string spChucNangExist = "sp_ChucNang_Exist";
            public const string spChucNangSearch = "sp_ChucNang_Search";
            public const string spChucNangGetbyId = "sp_ChucNang_GetbyId";

            public const string spChucNangListAll = "sp_DM_ChucNang_ListAll";
            public const string spChucNangInsertIfNotExist = "sp_DM_ChucNang_AddIfNotExist";
            public const string spChucNangSearchCN = "sp_DM_ChucNang_Search";
            public const string spChucNangDeleteCN = "sp_DM_ChucNang_Delete";

            public const string spPhanQuyenChucNang = "sp_DM_ChucNang_PhanQuyenCN";
            public const string spPhanQuyenNganhHang = "sp_DM_ChucNang_PhanQuyenNH";
            public const string spPhanQuyenNguoiDung = "sp_DM_ChucNang_NguoiDung";
            public const string spPhanQuyenNguoiDungCNang = "sp_DM_ChucNang_NguoiDungCN";

            #endregion

            #region tbl_DM_ChiPhi
            public const string spChiPhiSyncGetLastUpdateDate = "sp_ChiPhi_Sync_LUD";
            public const string spChiPhiSyncTransfer = "sp_ChiPhi_Sync_Transfer";
            public const string spChiPhiSyncInsert = "sp_ChiPhi_Sync_Insert";
            public const string spChiPhiSyncUpdate = "sp_ChiPhi_Sync_Update";
            public const string spChiPhiSelectAll = "sp_ChiPhi_SelectAll";
            public const string spChiPhiSelectActived = "sp_ChiPhi_SelectActived";
            public const string spChiPhiUpdate = "sp_DM_ChiPhi_Update";
            public const string spChiPhiInsert = "sp_DM_ChiPhi_Insert";
            public const string spChiPhiDelete = "sp_DM_ChiPhi_Delete";
            public const string spChiPhiExist = "sp_DM_ChiPhi_Exist";
            public const string spChiPhiSearch = "sp_DM_ChiPhi_Search";
            public const string spChiPhiGetbyId = "sp_DM_ChiPhi_GetbyId";
            #endregion
            #region tbl_DM_DL_LinhVuc

            public const string spLinhVucSelectAll = "sp_DM_LinhVuc_SelectAll";
            #endregion

            #region tbl_DM_DL_Nganh

            public const string spNganhSelectAll = "sp_DM_Nganh_SelectAll";
            public const string spNganhPQSelectAll = "sp_DM_NganhPQ_SelectAll";
            public const string spNganhPQGetPheDuyet = "sp_DM_NganhPQ_GetPheDuyet";
            public const string spPheDuyetGiaNganhPQGetAll = "sp_PheDuyetGia_NganhPQ_GetAll";
            public const string spPheDuyetGiaNhomNDGetAll = "sp_PheDuyetGia_NhomND_GetAll";
            public const string spPheDuyetGiaNganhPQUpdate = "sp_PheDuyetGia_NganhPQ_Update";
            public const string spPheDuyetGiaNganhPQDelete = "sp_PheDuyetGia_NganhPQ_Delete";
            #endregion

            #region tbl_DM_DL_Loai
            public const string spLoaiSelectAll = "sp_DM_Loai_SelectAll";
            #endregion

            #region tbl_DM_DL_Chung

            public const string spChungSelectAll = "sp_DM_Chung_SelectAll";
            #endregion

            #region tbl_DM_DL_Nhom

            public const string spNhomSelectAll = "sp_DM_Nhom_SelectAll";
            #endregion

            #region tbl_DM_DL_Hang

            public const string spHangSelectAll = "sp_DM_Hang_SelectAll";
            public const string spHangPQSelectAll = "sp_DM_HangPQ_SelectAll";
            #endregion

            #region tbl_DM_DL_Model

            public const string spModelSelectAll = "sp_DM_Model_SelectAll";
            #endregion

            #region tbl_DM_PhuongThucBanHang
            public const string spPhuongThucBHSelectAll = "sp_DM_PhuongThucBH_SelectAll";
            public const string spPhuongThucBHUpdate = "sp_DM_PhuongThucBH_Update";
            public const string spPhuongThucBHInsert = "sp_DM_PhuongThucBH_Insert";
            public const string spPhuongThucBHDelete = "sp_DM_PhuongThucBH_Delete";
            public const string spPhuongThucBHExist = "sp_DM_PhuongThucBH_Exist";
            public const string spPhuongThucBHSearch = "sp_DM_PhuongThucBH_Search";
            public const string spPhuongThucBHGetbyId = "sp_DM_PhuongThucBH_GetbyId";

            public const string spPhuongThucBanHangSyncGetLastUpdateDate = "sp_PhuongThucBanHang_Sync_LUD";
            public const string spPhuongThucBanHangSyncUpdate = "sp_PhuongThucBH_Sync_Update";
            public const string spPhuongThucBanHangSyncInsert = "sp_PhuongThucBH_Sync_Insert";
            public const string spPhuongThucBanHangSyncTransfer = "sp_PhuongThucBH_Sync_Transfer";
            #endregion

            #region tbl_Tmp_DM_PhuongThucBanHang
            public const string spTmpPhuongThucBanHangDelete = "sp_Tmp_PhuongThucBH_Delete";
            public const string spTmpPhuongThucBanHangSelectAll = "sp_Tmp_PhuongThucBH_SelectAll";
            public const string spTmpPhuongThucBanHangValid = "sp_Tmp_PhuongThucBH_Valid";
            #endregion

            #region tbl_tmp_DM_ChiPhi
            public const string spTmpChiPhiDelete = "sp_Tmp_ChiPhi_Delete";
            public const string spTmpChiPhiSelectAll = "sp_Tmp_ChiPhi_SelectAll";
            public const string spTmpChiPhiValid = "sp_Tmp_ChiPhi_Valid";
            #endregion

            #region tbl_SanPham
            public const string spSanPhamSyncInsert = "sp_SanPham_Sync_Insert";
            public const string spSanPhamSyncUpdate = "sp_SanPham_Sync_Update";
            public const string spSanPhamSyncTransfer = "sp_SanPham_Sync_Transfer";
            public const string spSanPhamSyncGetLastUpdateDate = "sp_SanPham_Sync_LUD";
            public const string spSanPhamSelectAll = "sp_SanPham_SelectAll";
            public const string spSanPhamUsingSelectAll = "sp_SanPhamUsing_SelectAll";
            public const string spSanPhamSyncSelectAll = "sp_SanPhamSync_SelectAll";
            public const string spSanPhamCauHinhSelectAll = "sp_SanPham_CauHinh_SelectAll";
            public const string spSanPhamSelectByKTTT = "sp_SanPham_SelectByKTTT";
            public const string spSanPhamSelectPair = "sp_SanPham_SelectPair";
            public const string spSanPhamUpdate = "sp_SanPham_Update";
            public const string spSanPhamInsert = "sp_SanPham_Insert";
            public const string spSanPhamDelete = "sp_SanPham_Delete";
            public const string spSanPhamExist = "sp_SanPham_Exist";
            public const string spSanPhamSearch = "sp_SanPham_Search";
            public const string spSanPhamGetByMaSP = "sp_SanPham_GetByMaSP";
            public const string spSanPhamGetById = "sp_SanPham_GetById";
            public const string spSanPhamGetByLoaiSP = "sp_SanPham_SelectByLoaiSP";
            public const string spSanPhamSelectTrungMaVach = "sp_SanPham_SelectTrungMaVach";
            public const string spSanPhamSelectBrief = "sp_SanPham_SelectBrief";
            public const string spSanPhamSelectBriefByNSD = "sp_SanPham_SelectBriefByNSD";
            public const string spSanPhamSelectPagingDmSanPhamInfo = "sp_SanPham_SelectAllPaging";
            public const string spSanPhamSelectBriefByMa = "sp_SanPham_GetBriefByMa";
            public const string spSanPhamSelectBriefByNSDMa = "sp_SanPham_GetBriefByNSDMa";
            public const string spMatHangGetAllByMaNSD = "sp_MatHang_GetAllByMaNSD";
            public const string spMatHangGetAllMatHangByType = "sp_MatHang_GetAllSPByType";
            public const string spMatHangGetAllByMaParent = "sp_MatHang_GetAllByMaParent";
            public const string spSanPhamSelectBriefByNSDTK = "sp_SanPham_SelectBriefByNSDTK";
            public const string spMatHangGetAllByMaNSDText = "sp_MatHang_GetAllByMaNSDText";
            public const string spMatHangGetGetHangSanXuat = "sp_MatHang_GetHangSanXuat";
            public const string spMatHangGetGetHangInfo = "sp_MatHang_GetHangInfo";
            public const string spMatHangGetItemByTypeAndCode = "sp_MatHang_GetItemByTypeCode";
            public const string spMatHangGetItemCKhauByCode = "sp_MatHang_GetItemCKhauByCode";
            public const string spSanPhamGetByText = "sp_SanPham_GetByText";
            public const string spSanPhamSelectNoCKhau = "sp_SanPham_SelectCKhau";

            public const string spSanPhamSelectCheckKM = "sp_SanPham_LoadNoKMaiCheck";
            public const string spSanPhamSelectChuaDayKMOrc = "sp_SanPham_LoadNoKMaiSynOrc";
            public const string spSanPhamSelectChuaDayKMWeb = "sp_SanPham_LoadNoKMaiSynWeb";
            public const string spSanPhamUpdateTrangThaiDayKMWeb = "sp_SanPham_UdpTrangThaiSynWeb";

            //CuongTT 02/12/2012
            public const string spSanPhamGetGiaByMaSP = "sp_SanPham_GetGiaByMaSP";
            public const string spSanPhamGetCauHinhByMaSP = "sp_SanPham_GetCauHinhByMaSP";
            //CuongTT 08/01/2013
            public const string spSanPhamGetByMaVach = "sp_SanPham_GetByMaVach";
            //HanhBD 04/16/2013
            public const string spSanPhamGetTenByIdSP = "sp_SanPham_GetTenByIdSP";
            public const string spSanPhamGetCauHinhByIdSP = "sp_SanPham_GetCauHinhByIdSP";
            public const string spSanPhamGetHeaderByIdSP = "sp_SanPham_GetHeaderByIdSP";
            public const string spSanPhamGetCauHinhByIdSPs = "sp_SanPham_GetCauHinhByIdSPs";
            public const string spSanPhamGetCauHinhA7ByIdSP = "sp_SanPham_GetCauHinhA7ByIdSP";
            public const string spSanPhamGetByIdSP = "sp_SanPham_GetByIdSP";
            public const string spUpdateCauHinhSanPham = "sp_CauHinh_SanPham_Update";
            public const string spDeleteCauHinhSanPham = "sp_CauHinh_SanPham_Delete";
            public const string spUpdateTenVietTatSanPham = "sp_TenVietTat_SanPham_Update";
            //Phạm ngọc minh 30/1/2013
            public const string spBhSanPhamGetLookUp = "sp_bh_SanPham_getlookup";
            public const string spBhSanPhamGetLookUpTA = "sp_bh_SanPham_getlookupTA";
            public const string spBhSanPhamGetLookUpXM = "sp_bh_SanPham_getlookupxm";
            public const string spBhSanPhamGetLookUpAll = "sp_bh_SanPham_getlookupall";

            //CuongTT 19/02/2013 phần báo cáo
            public const string spChiTietGiaoDichNhapHangReport = "sp_rpt_BaoCaoNhapHang";
            public const string spTongHopGiaoDichNhapHangReport = "sp_rpt_BaoCaoTongHopNhapHang";
            public const string spChiTietGiaoDichXuatHangReport = "sp_rpt_BaoCaoXuatHang";
            public const string spChiTietGiaoDichXuatHangReportPNG = "sp_rpt_BaoCaoXuatHangPNG";
            public const string spTongHopGiaoDichXuatHangReport = "sp_rpt_BaoCaoTongHopXuatHang";
            public const string spTongHopDuLieuNhapXuatReportPNG = "sp_rpt_TongHopGiaoDichNhapXuat";
            public const string spGetDuLieuTongHopNhapXuatReportPNG = "sp_rpt_GetTongHopNhapXuatPNG"; //"sp_rpt_BCTHXuatHangPNG";
            public const string spXoaDuLieuTongHopNhapXuatReportPNG = "sp_rpt_XoaTongHopNhapXuatPNG";
            public const string spTongHopNhapXuatThanhPhamReport = "sp_rpt_BCTHNhapXuatThanhPham";
            public const string spChiTietNhapXuatThanhPhamReport = "sp_rpt_BCCTNhapXuatThanhPham";
            public const string spMaVachSXReport = "sp_rpt_BaoCaoMaVachSanXuat";
            public const string spLenhSXChuaNhapLK = "sp_rpt_BaoCaoLenhSXChuaNhapLK";
            public const string spXuatDoiLKLoi = "sp_rpt_BaoCaoXuatDoiLKLoi";
            public const string spChiTietThanhPhamReport = "sp_rpt_BaoCaoChiTietThanhPham";
            public const string spChiTietTachThanhPhamReport = "sp_rpt_ChiTietTachThanhPham";
            public const string spChiTietLinhKienReport = "sp_rpt_BaoCaoChiTietLinhKien";
            public const string spTongHopThanhPhamReport = "sp_rpt_BaoCaoTongHopThanhPham";
            public const string spTongHopTachThanhPhamReport = "sp_rpt_TongHopTachThanhPham";
            public const string spTongHopLinhKienReport = "sp_rpt_BaoCaoTongHopLinhKien";
            public const string spDanhSachNhapPOReport = "sp_rpt_BaoCaoDanhSachNhapPO";
            public const string spDanhSachNhapNoiBoReport = "sp_rpt_BaoCaoDanhSachNhapNoiBo";
            public const string spDanhSachXuatNoiBoReport = "sp_rpt_BaoCaoDanhSachXuatNoiBo";
            public const string spChiTietNhapPOReport = "sp_rpt_BaoCaoChiTietNhapPO";
            public const string spChiTietNhapNoiBoReport = "sp_rpt_BaoCaoChiTietNhapNoiBo";
            public const string spChiTietXuatNoiBoReport = "sp_rpt_BaoCaoChiTietXuatNoiBo";
            public const string spPXTHGetAll = "sp_ct_XTHselect";
            public const string spPXDCGetAll = "sp_ct_XDCselect";
            public const string spDKKGetAll = "sp_DKKselect";
            public const string spListSPTrungMV = "sp_ListSanPhamTrungMV";
            public const string spDKKGetEnd = "sp_DKKEndselect";
            public const string spDKKGetById = "sp_DKKGetById";
            public const string spPXTHctGetAll = "sp_ctct_XTHselect";
            public const string spPXDCctGetAll = "sp_ctct_XDCselect";
            public const string spctXTHGetAll = "sp_select_ctct_XTH";
            public const string spTongHopNhapXuatLK = "sp_rpt_TongHopNhapXuatLK";
            public const string spTongHopNhapXuatDM = "sp_rpt_TongHopNhapXuatDM";
            public const string spTongHopNhapXuatCB = "sp_rpt_TongHopNhapXuatCB";
            public const string spChiTietNhapXuatLK = "sp_rpt_ChiTietNhapXuatLK";
            public const string spChiTietNhapXuatDM = "sp_rpt_ChiTietNhapXuatDM";
            public const string spChiTietNhapXuatCB = "sp_rpt_ChiTietNhapXuatCB";


            //get kho loi
            public const string spBHKhoGetKhoLoi = "sp_bh_kho_getkhoLoi";
            public const string spBHKhoGetKhoSuDung = "sp_bh_kho_getkhoSuDung";
            #endregion

            #region tbl_Tmp_SanPham
            public const string spTmpSanPhamSelectAll = "sp_Tmp_SanPham_SelectAll";
            public const string spTmpSanPhamDelete = "sp_Tmp_SanPham_Delete";
            public const string spTmpSanPhamValid = "sp_Tmp_SanPham_Valid";

            #endregion

            #region tbl_DM_DL_Chung
            public const string spChungSyncInsert = "sp_Chung_Sync_Insert";
            public const string spChungSyncUpdate = "sp_Chung_Sync_Update";
            public const string spChungSyncGetLastUpdateDate = "sp_Chung_Sync_LUD";
            public const string spChungSyncTransfer = "sp_Chung_Sync_Transfer";
            public const string spChungSyncSelectAll = "sp_Chung_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_Chung
            public const string spTmpChungDelete = "sp_Tmp_Chung_Delete";
            public const string spTmpChungSelectAll = "sp_Tmp_Chung_SelectAll";
            public const string spTmpChungValid = "sp_Tmp_Chung_Valid";
            #endregion

            #region tbl_DM_DL_Hang
            public const string spHangSyncInsert = "sp_Hang_Sync_Insert";
            public const string spHangSyncUpdate = "sp_Hang_Sync_Update";
            public const string spHangSyncGetLastUpdateDate = "sp_Hang_Sync_LUD";
            public const string spHangSyncTransfer = "sp_Hang_Sync_Transfer";
            public const string spHangSyncSelectAll = "sp_Hang_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_Hang
            public const string spTmpHangDelete = "sp_Tmp_Hang_Delete";
            public const string spTmpHangSelectAll = "sp_Tmp_Hang_SelectAll";
            public const string spTmpHangValid = "sp_Tmp_Hang_Valid";
            #endregion

            #region tbl_DM_DL_LinhVuc
            public const string spLinhVucSyncInsert = "sp_LinhVuc_Sync_Insert";
            public const string spLinhVucSyncUpdate = "sp_LinhVuc_Sync_Update";
            public const string spLinhVucSyncGetLastUpdateDate = "sp_LinhVuc_Sync_LUD";
            public const string spLinhVucSyncTransfer = "sp_LinhVuc_Sync_Transfer";
            public const string spLinhVucSyncSelectAll = "sp_LinhVuc_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_LinhVuc
            public const string spTmpLinhVucDelete = "sp_Tmp_LinhVuc_Delete";
            public const string spTmpLinhVucSelectAll = "sp_Tmp_LinhVuc_SelectAll";
            public const string spTmpLinhVucValid = "sp_Tmp_LinhVuc_Valid";
            #endregion

            #region tbl_DM_DL_Loai
            public const string spLoaiSyncInsert = "sp_Loai_Sync_Insert";
            public const string spLoaiSyncUpdate = "sp_Loai_Sync_Update";
            public const string spLoaiSyncGetLastUpdateDate = "sp_Loai_Sync_LUD";
            public const string spLoaiSyncTransfer = "sp_Loai_Sync_Transfer";
            public const string spLoaiSyncSelectAll = "sp_Loai_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_Loai
            public const string spTmpLoaiDelete = "sp_Tmp_Loai_Delete";
            public const string spTmpLoaiSelectAll = "sp_Tmp_Loai_SelectAll";
            public const string spTmpLoaiValid = "sp_Tmp_Loai_Valid";
            #endregion

            #region tbl_DM_DL_Model
            public const string spModelSyncInsert = "sp_Model_Sync_Insert";
            public const string spModelSyncUpdate = "sp_Model_Sync_Update";
            public const string spModelSyncGetLastUpdateDate = "sp_Model_Sync_LUD";
            public const string spModelSyncTransfer = "sp_Model_Sync_Transfer";
            public const string spModelSyncSelectAll = "sp_Model_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_Model
            public const string spTmpModelDelete = "sp_Tmp_Model_Delete";
            public const string spTmpModelSelectAll = "sp_Tmp_Model_SelectAll";
            public const string spTmpModelValid = "sp_Tmp_Model_Valid";
            #endregion

            #region tbl_DM_DL_Nganh
            public const string spNganhSyncInsert = "sp_Nganh_Sync_Insert";
            public const string spNganhSyncUpdate = "sp_Nganh_Sync_Update";
            public const string spNganhSyncGetLastUpdateDate = "sp_Nganh_Sync_LUD";
            public const string spNganhSyncTransfer = "sp_Nganh_Sync_Transfer";
            public const string spNganhSyncSelectAll = "sp_Nganh_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_Nganh
            public const string spTmpNganhDelete = "sp_Tmp_Nganh_Delete";
            public const string spTmpNganhSelectAll = "sp_Tmp_Nganh_SelectAll";
            public const string spTmpNganhValid = "sp_Tmp_Nganh_Valid";
            #endregion

            #region tbl_DM_DL_Nhom
            public const string spNhomSyncInsert = "sp_Nhom_Sync_Insert";
            public const string spNhomSyncUpdate = "sp_Nhom_Sync_Update";
            public const string spNhomSyncGetLastUpdateDate = "sp_Nhom_Sync_LUD";
            public const string spNhomSyncTransfer = "sp_Nhom_Sync_Transfer";
            public const string spNhomSyncSelectAll = "sp_Nhom_Sync_SelectAll";
            #endregion

            #region tbl_Tmp_DM_DL_Nhom
            public const string spTmpNhomDelete = "sp_Tmp_Nhom_Delete";
            public const string spTmpNhomSelectAll = "sp_Tmp_Nhom_SelectAll";
            public const string spTmpNhomValid = "sp_Tmp_Nhom_Valid";
            #endregion

            #region tbl_DM_LoaiThe_KhachHang
            public const string spLoaiThe_KhachHangselectAll = "sp_LoaiThe_KhachHang_SelectAll";
            //public const string spSanPhamSelectPair = "sp_SanPham_SelectPair";
            public const string spLoaiThe_KhachHangUpdate = "sp_LoaiThe_KhachHang_Update";
            public const string spLoaiThe_KhachHangInsert = "sp_LoaiThe_KhachHang_Insert";
            public const string spLoaiThe_KhachHangDelete = "sp_LoaiThe_KhachHang_Delete";
            public const string spLoaiThe_KhachHangExist = "sp_LoaiThe_KhachHang_Exist";
            public const string spLoaiThe_KhachHangSearch = "sp_LoaiThe_KhachHang_Search";
            public const string spLoaiThe_KhachHangGetById = "sp_LoaiThe_KhachHang_GetById";
            #endregion

            #region tbl_LoaiThe_QuyenLoi
            //public const string spDoiTuongDiaChiSelectAll = "sp_Kho_NhanVien_SelectAll";
            public const string spLoaitheQuyenLoiInsert = "sp_LoaiThe_QuyenLoi_Insert";
            public const string spLoaitheQuyenLoiDelete = "sp_LoaiThe_QuyenLoi_Delete";
            public const string spLoaitheQuyenLoiSelectByidLoaiThe = "sp_LoaiThe_QuyenLoi_GetById";
            #endregion

            #region tbl_LoaiThe_UuDai
            //public const string spDoiTuongDiaChiSelectAll = "sp_Kho_NhanVien_SelectAll";
            public const string spLoaitheUuDaiInsert = "sp_LoaiThe_UuDai_Insert";
            public const string spLoaitheUuDaiDelete = "sp_LoaiThe_UuDai_Delete";
            public const string spLoaitheUuDaiSelectByidLoaiThe = "sp_LoaiThe_UuDai_GetById";
            #endregion

            #region tbl_DM_KhaiBao
            public const string spKhaiBaoSelectAll = "sp_ListDM_SelectAll";
            //public const string spKhaiBaoSelectPair = "sp_ListDM_SelectPair";
            public const string spKhaiBaoUpdate = "sp_ListDM_Update";
            public const string spKhaiBaoInsert = "sp_ListDM_Insert";
            public const string spKhaiBaoDelete = "sp_ListDM_Delete";
            public const string spKhaiBaoExist = "sp_ListDM_Exist";
            public const string spKhaiBaoSearch = "sp_ListDM_Search";
            public const string spKhaiBaoGetById = "sp_ListDM_GetById";
            #endregion

            #region tbl_DM_NguoiDung
            public const string spNguoiDungGetByUserName = "sp_DM_NguoiDung_GetByUserName";
            public const string spNguoiDungUpdateStatus = "sp_DM_NguoiDung_UpdateStatus";
            public const string spNguoiDungGetChucNang = "sp_DM_NguoiDung_GetChucNang";
            public const string spNguoiDungGetKho = "sp_DM_NguoiDung_GetKho";
            public const string spNguoiDungGetNganhHang = "sp_DM_NguoiDung_GetNganhHang";
            public const string spNguoiDungGetHangSX = "sp_DM_NguoiDung_GetHangSX";
            public const string spNguoiDungListAll = "sp_DM_NguoiDung_ListAll";
            public const string spNguoiDungGetInfor = "sp_DM_NguoiDung_GetInfor";
            public const string spNguoiDungUpdate = "sp_DM_NguoiDung_Update1";
            public const string spNguoiDungInsert = "sp_DM_NguoiDung_Insert1";
            public const string spNguoiDungDelete = "sp_DM_NguoiDung_Delete";
            public const string spNguoiDungSearch = "sp_DM_NguoiDung_Search";
            public const string spNguoiDungChangePass = "sp_DM_NguoiDung_ChangPass";
            public const string spNguoiDungExistND = "sp_DM_NguoiDung_ExistND";
            public const string spNguoiDungUpdateKhoDefault = "sp_DM_NguoiDung_UpdateKho";
            #endregion

            #region tbl_DM_NhomNguoiDung
            public const string spNhomNguoiDungListAll = "sp_DM_NhomNguoiDung_ListAll";
            public const string spNhomNguoiDungGetInfor = "sp_DM_NhomNguoiDung_GetInfor";
            public const string spNhomNguoiDungUpdate = "sp_DM_NhomNguoiDung_Update";
            public const string spNhomNguoiDungInsert = "sp_DM_NhomNguoiDung_Insert";
            public const string spNhomNguoiDungDelete = "sp_DM_NhomNguoiDung_Delete";
            public const string spNhomNguoiDungSearch = "sp_DM_NhomNguoiDung_Search";
            public const string spNhomNguoiDungGetCNang = "sp_DM_NhomNguoiDung_GetCNang";
            public const string spNhomNguoiDungGetNganh = "sp_DM_NhomNguoiDung_GetNganh";
            public const string spNhomNguoiDungGetHang = "sp_DM_NhomNguoiDung_GetHang";
            public const string spNhomNguoiDungInsertCN = "sp_DM_NhomNguoiDung_InsertCN";
            public const string spNhomNguoiDungInsertNH = "sp_DM_NhomNguoiDung_InsertNH";
            public const string spNhomNguoiDungInsertHSX = "sp_DM_NhomNguoiDung_InsertHSX";
            public const string spNhomNguoiDungDeleteCN = "sp_DM_NhomNguoiDung_DeleteCN";
            public const string spNhomNguoiDungExistNND = "sp_DM_NhomNguoiDung_ExistNND";
            public const string spNhomNguoiDungLoadByMaNV = "sp_DM_NhomNguoiDung_LoadByNV";
            #endregion

            #region tbl_DM_HinhThucThanhToan
            public const string spHinhThucThanhToanInsert = "sp_HinhThucThanhToan_Insert";
            public const string spHinhThucThanhToanUpdate = "sp_HinhThucThanhToan_Update";
            public const string spHinhThucThanhToanDelete = "sp_HinhThucThanhToan_Delete";
            public const string spHinhThucThanhToanSelectAll = "sp_HinhThucThanhToan_SelectAll";
            public const string spHinhThucThanhToanExist = "sp_HinhThucThanhToan_Exist";
            public const string spHinhThucThanhToanSearch = "sp_DM_ThanhToan_Search";
            public const string spHinhThucThanhToanGetbyId = "sp_DM_ThanhToan_GetById";

            public const string spHinhThucThanhToanSyncGetLastUpdateDate = "sp_HTTT_Sync_LUD";
            public const string spHinhThucThanhToanSyncUpdate = "sp_HTTT_Sync_Update";
            public const string spHinhThucThanhToanSyncInsert = "sp_HTTT_Sync_Insert";
            public const string spHinhThucThanhToanSyncTransfer = "sp_HTTT_Sync_Transfer";
            #endregion

            #region tbl_Tmp_DM_HinhThucThanhToan
            public const string spTmpHinhThucThanhToanDelete = "sp_Tmp_HTTT_Delete";
            public const string spTmpHinhThucThanhToanSelectAll = "sp_Tmp_HTTT_SelectAll";
            public const string spTmpHinhThucThanhToanValid = "sp_Tmp_HTTT_Valid";
            #endregion

            #region tmp_NhapHang_User
            public const string spTraHangUserSelectAll = "sp_tmp_NhapHang_User_TraHang";
            public const string spNhapHangUserSelectAll = "sp_tmp_NhapHang_User_SelectAll";
            public const string spNhapHangSearch = "sp_tmp_NhapHang_Search";
            public const string spNhapHangUserGetById = "sp_NhapHangUser_SelectByPO";
            //Cuongtt 06/06/2013
            public const string spBaoCaoNhapXuatPOChuaXuat = "sp_BaoCaoNhapXuatPOChuaXuat";
            public const string spBaoCaoNhapTPChuaNhap = "sp_BaoCaoNhapTPChuaNhap";
            #endregion

            #region tbl_ChungTu
            public const string spChungTuGetListLockInfor = "sp_GetListChungTuLockInfor";
            public const string spChungTuInsert = "sp_ChungTu_Insert";
            public const string spChungTuGetById = "sp_ChungTu_GetbyId";
            public const string spChungTuGetBySoChungTu = "sp_ChungTu_GetBySoChungTu";
            public const string spChungTuUpdate = "sp_ChungTu_Update";
            public const string spChungTuSearch = "sp_ChungTu_Search";
            public const string spChungTuDeleteBySoPhieu = "sp_ChungTu_DeleteBySoPhieu";
            public const string spChungTuDeleteById = "sp_ChungTu_DeleteById";
            public const string spChungTuSelectByPO = "sp_ChungTu_SelectByPO1";
            public const string spLichSuChungTuSelectByPO = "sp_LichSu_ChungTu_SelectByPO";
            public const string spChungTuGetByMaVach = "sp_ChungTu_GetByMaVach";
            public const string spMaVachGetByChungTuGoc = "sp_GetMaVachByChungTuGoc";
            public const string spChungTuGetByLoaiChungTu = "sp_ChungTu_GetByLoaiChungTu";
            public const string spChungTuGetByLoaiChungTuBK = "sp_ChungTu_GetByLoaiChungTuBK";
            public const string spChungTuDelete = "sp_ChungTu_Delete";
            public const string spChungTuSelectBySoCTG = "sp_ChungTu_SelectBySoCTG";
            public const string spChungTuUpdateTrangThai = "sp_ChungTu_UpdateTrangThai";
            public const string spChungTuGetBySoPhieuXuat = "sp_ChungTu_GetBySoPhieuXuat";
            public const string spChungTuCheckSoPhieuByDH = "sp_ChungTu_CheckSoPhieuByDH";
            public const string spChungTuGetIdChungTuBySoPhieu = "sp_CT_GetIdChungTuBySoPhieu";
            public const string spChungTuSelectBySoChungTu = "sp_ChungTu_SelectBySoCT";
            public const string spChungTuSelectSoChungTuBan = "sp_DC_HB_SelectSoCT";
            public const string spChungTuXacNhanNhapThanhPhamGetBySoChungTuGoc = "sp_ChungTu_001";
            // Thêm, sửa trong bảng chứng từ của các phiếu xuất tiêu hao, xuất nội bộ,  nhập nội bộ, điều chuyển
            // bao gồm cả kế toán và kho
            public const string spChungTuDNXTHInsert = "sp_ChungTu_DNXTH_Insert";
            public const string spChungTuDNXTHUpdate = "sp_ChungTu_DNXTH_Update";
            public const string spChungTuXTHUpdate = "sp_ChungTu_XTH_Update";

            public const string spChungTuDNNTHInsert = "sp_ChungTu_DNNTH_Insert";
            public const string spChungTuDNNTHUpdate = "sp_ChungTu_DNNTH_Update";

            public const string spChungTuXNBInsert = "sp_ChungTu_XNB_Insert";
            public const string spChungTuXNBUpdate = "sp_ChungTu_XNB_Update";

            public const string spChungTuNNBInsert = "sp_ChungTu_NNB_Insert";
            public const string spChungTuNNBUpdate = "sp_ChungTu_NNB_Update";

            public const string spChungTuDNDCInsert = "sp_ChungTu_DNDC_Insert2";
            public const string spChungTuDNDCUpdate = "sp_ChungTu_DNDC_Update1";
            public const string spChungTuDNDCUpdateTrangThaiHuy = "sp_ChungTu_DNDC_Huy_Update";


            public const string spChungTuDNDCTGInsert = "sp_ChungTu_DNDCTG_Insert1";

            public const string spChungTuXDCInsert = "sp_ChungTu_XDC_Insert";
            public const string spChungTuXDCUpdate = "sp_ChungTu_XDC_Update";

            public const string spChungTuDNNDCInsert = "sp_ChungTu_DNNDC_Insert1";
            public const string spChungTuDNNDCUpdate = "sp_ChungTu_DNNDC_Update2";
            public const string spChungTuDNNDCTGInsert = "sp_ChungTu_DNNDCTG_Insert";
            public const string spChungTuNDCInsert = "sp_ChungTu_NDC_Insert";
            public const string spChungTuNDCUpdate = "sp_ChungTu_NDC_Update";
            public const string spChungTuNDCTGUpdate = "sp_ChungTu_NDCTG_Update";
            public const string spChungTuDaXuatHang = "sp_ChungTu_DaXuatHang1";
            public const string spChungTuDaXacNhanNhapKho = "sp_ChungTu_DaXacNhanNhapKho1";
            public const string spChungTuNhapXuatGetBySoChungTu = "sp_chungtuNX_selectbysochungtu";
            //CuongTT 7/11/2012
            public const string spChungTuExist = "sp_ChungTu_Exist";
            public const string spChungTuUpdateSX = "sp_ChungTu_UpdateSanXuat";
            /// <summary>
            /// Chứng từ phiếu xuất mượn
            /// sau khi kế toán xác nhận đã thu tiền thì chứng từ sẽ được tạo ra
            /// </summary>
            public const string spChungTuXMInsert = "sp_ChungTu_XM_Insert";
            public const string spChungTuXMUpdate = "sp_ChungTu_XM_Update";
            public const string spChungTuXMGetBySoPhieu = "sp_ChungTu_XM_BySoPhieu";
            public const string spChungTuXMDelete = "sp_ChungTu_XM_Delete";
            //HanhBD 08/10/2013
            public const string spChungTuDieuChuyenCanXoa = "sp_ChungTu_DieuChuyen_Delete";
            public const string spChungTuDieuChuyenXoa = "sp_ChungTu_DC_Delete";
            #endregion

            #region tbl_DieuChuyen_HangBan
            /// <summary>
            /// insert chứng từ điều chuyển vào bảng tbl_dieuchuyen_hangban
            /// </summary>
            public const string spDieuChuyenHangBanInsert = "sp_DC_HB_Insert";

            public const string spDieuChuyenHangBanDelete = "sp_DC_HB_Delete";
            #endregion

            #region Phạm Ngọc Minh sử dụng trong bảo hành
            //Tim chung tu qua phieu nhan va loai phieu
            //Pham ngoc minh 14/9/2012
            public const string spChungTuSearchByPN = "sp_ChungTu_SearchPhieuNhan";
            public const string SpBhChungTuInsertNCC = "sp_BH_ChungTu_XNCC_Insert";
            public const string spBHChungTuUpdateNCC = "sp_BH_ChungTu_XNCC_Update";
            /// <summary>
            /// Thao tác với bảng chứng từ
            /// </summary>
            public const string spBHChungTuInsert = "sp_BH_ChungTu_Insert";
            public const string spBHChungTuKDInsert = "sp_BH_ChungTuKd_Insert";
            public const string spBHChungTuUpdate = "sp_BH_ChungTu_Update1";
            public const string spBHChungTuDelete = "sp_BH_ChungTu_Delete";
            public const string spBHChungTuUpdateDraft = "sp_BH_ChungTu_UpdateDraft";
            public const string spChungTuUpdateThuNgan = "sp_BH_ChungTu_UpdateThuNgan";
            public const string spBHChungTuGetByIdKho = "sp_BH_ChungTu_GetByKho";
            public const string spBHChungTuGetByIdChungTu = "sp_BH_ChungTu_GetById";

            //xuat tra bảo hành
            public const string spBHChungTuTraUpdateDraft = "sp_BH_ChungTuTra_UpdateDraft";
            public const string spBhChuntTuTraUpdateTrangThai = "sp_BH_ChungTuTra_UpdateTT";
            //Thao tác với phiếu nhập kho 
            public const string spBHChungTuPNKInsert = "sp_BH_ChungTuPNK_Insert";

            //tìm kiếm idchungtu
            public const string spChungTuGetIdChungTu = "sp_ChungTu_GetId";
            //Chứng từ khi xuất trả hàng cho khách hàng
            public const string spBHPhieuXuatTraGetListAll = "sp_BH_PXT_GetListAll";
            public const string spBHPhieuXuatTraGetReport = "sp_BH_PXT_GetReport";
            public const string spBHPhieuXuatTraGetListAllKho = "sp_BH_PXT_GetListAllKho";
            public const string spBHPhieuXuatTraUpdate = "sp_BH_PXT_Update";
            public const string spBhPhieuXuatTraReport = "sp_BH_PXT_Report";
            public const string spBHChungTuInsertXT = "sp_BH_ChungTu_InsertXT";
            public const string spBhXuatTraBHLinhKien = "sp_BH_PXT_GetLinhKien";
            public const string spBhXuatTraBHLinhKienKho = "sp_BH_PXT_GetLinhKienKho";

            public const string spBhXuatTraBHLinhKienForXuatTraBH = "sp_BH_PXT_GetLKForTraBH";
            public const string spBhXuatTraBHUpdateTrangThai = "sp_BH_PXT_UpdateTT";
            public const string spBhXuatTraBHGetLinhKien = "sp_BH_PXT_GetListLinhKien";
            public const string spBhXuatTraBHGetLinhKienKho = "sp_BH_PXT_GetListLinhKienKho";
            public const string spBhTraBHUpdateTT = "sp_BH_TraBH_UpdateTT";
            public const string spBhChungTuUpdateTT = "sp_BH_ChungTu_UpdateTT";
            public const string spBhChungTuUpdatePhanHoi = "sp_BH_ChungTu_UpdatePhanHoi";
            public const string spBhChungTuTraUpdatePhanHoi = "sp_BH_ChungTuTra_UpdatePhanHoi";
            public const string spBhChungTuGiaoDichGetDM = "sp_BH_ChungTu_GiaoDich_getDM";
            public const string spBhChungTuGiaoDichGetDC = "sp_BH_ChungTu_GiaoDich_getDC";
            public const string spBhChungTuGiaoDichGetXH = "sp_BH_ChungTu_GiaoDich_getXH";
            public const string spBhChungTuGiaoDichGetNH = "sp_BH_ChungTu_GiaoDich_getNH";
            public const string spBhChungTuGiaoDichGetAll = "sp_BH_ChungTu_GiaoDich_getAll";
            public const string spBhChungTuGiaoDichGetAllMV = "sp_BH_ChungTu_GD_getAllMV";
            public const string spBhChungTuGiaoDichGetAllPg = "sp_BH_ChungTu_GiaoDich_getPg";
            public const string spBhChungTuGiaoDichGetAllMVPg = "sp_BH_ChungTu_GD_getMVPg";

            //tbl_bh_chungtu_checkloi CuongTT
            public const string spBhChungTuCheckLoiInsert = "sp_BH_ChungTu_CheckLoi_Insert";
            public const string spBhChungTuCheckLoiUpdate = "sp_BH_ChungTu_CheckLoi_Update";
            public const string spBhChungTuCheckLoiCheck = "sp_BH_ChungTuCheckLoi_Check";
            //tbl_bh_chungtuchitiet_checkloi
            public const string spBhChungTuCTietCheckLoiInsert = "sp_BH_ChiTiet_CheckLoi_Insert";
            public const string spBhChungTuCtTietCheckLoiUpdate = "sp_BH_ChiTiet_CheckLoi_Update";
            public const string spBhChungTuCTietCheckLoiSelectAll = "sp_bh_CheckLoi_SelectAll";
            public const string spBhChungTuCTietCheckLoiGetByChungTu = "sp_bh_CheckLoi_GetByChungTu";
            public const string spBhChungTuCTietCheckLoiReport = "sp_bh_CheckLoi_Report";
            public const string spBhChungTuCTietCheckLoiReportKT = "sp_bh_CheckLoi_ReportKT";

            //vào bằng tbl_bh_chungtuTra
            public const string spBHChungTuTraInsert = "sp_BH_ChungTuTra_Insert";
            public const string spBHChungTuTraUpdate = "sp_BH_ChungTuTra_Update";
            public const string spBHChungTuTraExist = "sp_BH_ChungTuTra_Exist";
            public const string spBHChungTuTraUpdateHDTC = "sp_BH_ChungTuTra_UpdateHDTC";
            public const string spBHChungTuTraChiTietInsert = "sp_BH_ChungTuTraChiTiet_Insert";
            //Chứng từ nhập hàng khách mượn

            public const string spChungTuNhapMuonGetListAll = "sp_ChungTuNhapMuon_GetListAll";


            //chứng từ nhập bảo hành nhà cung cấp
            public const string spBHNhapBhNhaCCGetListAll = "sp_ChungTuNhapBHNCC_All";
            public const string spBhGetListChungTuByMaVach = "sp_CTXuatBHNCC_GetByMaVach";
            public const string spBhGetListChungTuByDoiTuong = "sp_CTXuatBHNCC_GetByDT";
            public const string spBhGetListChungTuChiTietTra = "sp_CTXuatBHNCC_ChungTuCTTra";
            public const string spBbXuatNhaCCLookup = "sp_Bh_XuatNhaCC_Lookup";
            public const string spBbXuatNhaCCLookupTT = "sp_Bh_XuatNhaCC_LookupTT";
            public const string spBHNhapBHNhaCCInsert = "sp_ChungTuNhapBHNCC_Insert";
            public const string spBHChiTietNhapBHNCCGetList = "sp_BH_CTNhapBHNCC_GetAll";

            public const string spBHChiTietNhapBHNCCGetListXN = "sp_BH_CTNhapBHNCC_GetAllXN";
            public const string spBHChiTietNhapBHNCCGetDelete = "sp_BH_CTNhapBHNCC_GetDelete";
            public const string spBHChungTuNhapBHNCCExist = "sp_ChungTuNhapBHNCC_Exist";
            //phiếu nhập kho
            public const string spChungTuChiTietGetReport = "sp_ChungTuCT_Report";
            //CuongTT 17/4/2013
            public const string spPhieuNhapLookupTT = "sp_Bh_PhieuNhap_LookupTT";


            //CheckHangLoi
            public const string spbhloichechhanginsert = "sp_bh_loicheckhang_insert";
            public const string spbhloichechhangUpdate = "sp_bh_loicheckhang_update";
            public const string spbhloichechhangdelete = "sp_bh_loicheckhang_delete";
            public const string spbhloichechhanggetall = "sp_bh_loicheckhang_getall";
            public const string spbhloichechhanggetcbo = "sp_bh_loicheckhang_getcbo";
            public const string spbhloichechhangexist = "sp_bh_loicheckhang_exist";

            //Nhập hàng bảo hành nhà cung cấp
            public const string spBhTraBaoHanhNCCInsert = "sp_Bh_TraBaoHanhNCC_Insert";
            public const string spBhTraBaoHanhNCCUpdate = "sp_Bh_TraBaoHanhNCC_Update";
            public const string spBhTraBaoHanhNCCDelete = "sp_Bh_TraBaoHanhNCC_Delete";
            public const string spBHTraBaoHanhNCCCheck = "sp_Bh_TraBaoHanhNCC_Check";
            public const string spBHKiemSoatBHNCC = "sp_BhGetListKiemSoatBHNCC";
            public const string spBHBaoCaoKiemTraNhapKho = "sp_Bh_GetListBaoCaoKiemTraNhap";
            public const string spBHBaoCaoNhanHangBH = "sp_Bh_NhanHangBHNCC_Report";
            public const string spBHTraBaoHanhNCCGetList = "sp_Bh_TraBaoHanhNCC_GetList";
            public const string sp_NhapXuatBaoHanhSync_PushORC = "sp_NhapXuatBaoHanhSync_PushORC";
            public const string spBHKhoTestHang = "sp_Bh_NhanHangBHNCC_Test";
            public const string spBHUpdateKhoTestHang = "sp_Bh_NhanHangBHNCC_UpdateTest";
            #endregion

            #region Bán hàng
            /// <summary>
            /// Chứng từ bán hàng
            /// </summary>
            public const string spChungTuBanHangGetAll = "sp_BHang_ChungTu_GetAll";
            public const string spChungTuBanHangGetAllPX = "sp_BHang_ChungTu_GetAllPX";
            public const string spChungTuBanHangGetByLoaiCT = "sp_BHang_ChungTu_GetByLoaiCTu";
            public const string spChungTuBanHangGetDHOL = "sp_BHang_ChungTu_GetDHOL";
            public const string spChungTuBanHangGetXNDHOL = "sp_BHang_ChungTu_GetXNDHOL";
            public const string spChungTuBanHangGetDTHM = "sp_BHang_ChungTu_GetDTHM";
            public const string spChungTuBanHangGetDHTS = "sp_BHang_ChungTu_GetDHTS";
            public const string spChungTuBanHangGetTToan = "sp_BHang_ChungTu_GetTToan";
            public const string spChungTuBanHangGetPCGN = "sp_BHang_ChungTu_GetPCGN";
            public const string spChungTuBanHangGetTTPCGN = "sp_BHang_ChungTu_GetTTPCGN";
            public const string spChungTuBanHangGetXuatKhoBan = "sp_BHang_ChungTu_GetXuatKho";

            public const string spChungTuBanHangGetDHOLPg = "sp_BHang_ChungTu_GetDHOLPg";
            public const string spChungTuBanHangGetXNDHOLPg = "sp_BHang_ChungTu_GetXNDHOLPg";
            public const string spChungTuBanHangGetDTHMPg = "sp_BHang_ChungTu_GetDTHMPg";
            public const string spChungTuBanHangGetDHTSPg = "sp_BHang_ChungTu_GetDHTSPg";
            public const string spChungTuBanHangGetXBKMPg = "sp_BHang_ChungTu_GetXBKMPg";
            public const string spChungTuBanHangGetTToanPg = "sp_BHang_ChungTu_GetTToanPg";
            public const string spChungTuBanHangGetPCGNPg = "sp_BHang_ChungTu_GetPCGNPg";
            public const string spChungTuBanHangGetPDGNPg = "sp_BHang_ChungTu_GetPDGNPg";
            public const string spChungTuBanHangGetXNGNPg = "sp_BHang_ChungTu_GetXNGNPg";
            public const string spChungTuBanHangGetTTPCGNPg = "sp_BHang_ChungTu_GetTTPCGNPg";
            public const string spChungTuBanHangGetTTPCGNPgS = "sp_BHang_ChungTu_GetTTPCGNPgS";
            public const string spChungTuBanHangGetXuatKhoBanPg = "sp_BHang_ChungTu_GetXuatKhoPg";
            public const string spChungTuBanHangGetHDTLPg = "sp_BHang_ChungTu_GetHDTLPg";

            public const string spChungTuBanHangUpdateTichDiem = "sp_BHang_ChungTu_UdpTDiem";
            public const string spChungTuBanHangUpdateCongNo = "sp_BHang_ChungTu_UdpCNoKH";
            public const string spChungTuBanHangUpdateTThai = "sp_BHang_ChungTu_UdpTThai";
            public const string spChungTuBanHangKhoaDonHang = "sp_BHang_ChungTu_KhoaDHang";
            public const string spChungTuBanHangUpdateTThaiSCT = "sp_BHang_ChungTu_UdpTThaiSCT";
            public const string spChungTuBanHangLockEdit = "sp_BHang_ChungTu_LockEditCT";
            public const string spChungTuBanHangGetById = "sp_BHang_ChungTu_GetById";
            public const string spChungTuBanHangGetListPXById = "sp_BHang_ChungTu_GetPXById";
            public const string spChungTuBanHangGetBySoCT = "sp_BHang_ChungTu_GetBySoCT";
            public const string spChungTuBanHangGetBySoCTHD = "sp_BHang_ChungTu_GetBySoCTHD";
            public const string spChungTuBanHangGetBySoCTu = "sp_BHang_ChungTu_GetBySoCTu";
            public const string spChungTuBanHangInsert = "sp_BHang_ChungTu_InsertHD";
            public const string spChungTuBanHangUpdate = "sp_BHang_ChungTu_UpdateHD";
            public const string spChungTuBanHangInsertThe = "sp_BHang_ChungTu_Insert";
            public const string spChungTuBanHangUpdateThe = "sp_BHang_ChungTu_Update";
            public const string spChungTuBanHangDelete = "sp_BHang_ChungTu_Delete";
            public const string spChungTuBanHangDeleteAll = "sp_BHang_ChungTu_DeleteAll";
            public const string spChungTuBanHangSearch = "sp_BHang_ChungTu_Search";
            public const string spChungTuBanHangExists = "sp_BHang_ChungTu_Exists1";
            public const string spChungTuBanHangSearchByDate = "sp_BHang_ChungTu_SearchByDate";
            public const string spChungTuBanHangExistsByDate = "sp_BHang_ChungTu_ExistByDate1";
            public const string spChungTuBanHangSearchDaMua = "sp_BHang_ChungTu_SearchDaMua";
            public const string spChungTuBanHangExistDaMua = "sp_BHang_ChungTu_ExistDaMua1";
            public const string spChungTuBanHangValidChietKhau = "sp_BHang_ChungTu_ValidMaCKhGia";
            public const string spChungTuBanHangTimKiemCT = "sp_BHang_ChungTu_TimKiem";
            public const string spChungTuBanHangTKiemDoanhSoTongHopPg = "sp_BHang_ChungTu_TKiemDThuTHop";
            public const string spChungTuBanHangKhungGioTheoNganhPg = "sp_BHang_ChungTu_KhungGioNganh";
            public const string spChungTuBanHangKhungGioTheoTuanPg = "sp_BHang_ChungTu_KhungGioTuan";
            public const string spChungTuBanHangTKiemDoanhSoPg = "sp_BHang_ChungTu_TKiemDThuPg1";
            public const string spChungTuBanHangTimKiemCTCTiet = "sp_BHang_ChungTu_TimKiemCTiet";
            public const string spChungTuBanHangTimKiemCTCSach = "sp_BHang_ChungTu_TimKiemCSach";
            public const string spChungTuBanHangTimKiemCTCSachThe = "sp_BHang_ChungTu_TimKiemCSThe";
            public const string spChungTuBanHangTimKiemCTPg = "sp_BHang_ChungTu_TimKiemPg";
            public const string spChungTuBanHangTimKiemKHPg = "sp_BHang_ChungTu_TimKiemKHPg";
            public const string spChungTuBanHangTimKiemDHPg = "sp_BHang_ChungTu_TimKiemDHPg";
            public const string spChungTuBanHangTimKiemKhoaDHPg = "sp_BHang_ChungTu_TimKhoaDHPg";
            public const string spChungTuBanHangTimKiemTheTVien = "sp_BHang_ChungTu_TimTheTVien";
            public const string spChungTuBanHangTimKiemKhachHang = "sp_BHang_ChungTu_TimTheTVien";
            public const string spChungTuBanHangTimKiemPThuPg = "sp_BHang_ChungTu_TKiemPTPg";
            public const string spChungTuBanHangTimKiemCNoPg = "sp_BHang_ChungTu_TKiemCNo";
            public const string spChungTuBanHangTimKiemNoKMai = "sp_BHang_ChungTu_SearchNoKMai";
            public const string spChungTuBanHangTonKhoBySanPham = "sp_BHang_NapTonKho_BySanPham1";
            public const string spChungTuBanHangSearchByPDC = "sp_BHang_ChungTu_SearchByPDC";
            public const string spChungTuBanHangTimKiemPT = "sp_BHang_ChungTu_TimKiemPT";
            //public const string spChungTuBanHangTimKiemPTPg = "sp_BHang_ChungTu_TimKiemPTPg";
            public const string spChungTuBanHangTimKiemPTCTietPg = "sp_BHang_ChungTu_TimKiemPTPg";
            public const string spChungTuBanHangTimKiemCTiet = "sp_BHang_ChungTu_TimKiemCT";
            public const string spChungTuBanHangTimKiemCTietPg = "sp_BHang_ChungTu_TimKiemCTPg2";
            public const string spChungTuBanHangTimKiemCTietAll = "sp_BHang_ChungTu_TimKiemCTAl";
            public const string spChungTuBanHangTimKiemCTietNoKMPg = "sp_BHang_ChungTu_TKiemNoKMCTPg";
            public const string spChungTuBanHangTimKiemCTGN = "sp_BHang_ChungTu_TimKiemGN";
            public const string spChungTuBanHangTimKiemCTGNPg = "sp_BHang_ChungTu_TimKiemGNPg1";
            public const string spChungTuBanHangTimKiemCTGNCTiet = "sp_BHang_ChungTu_TimKiemGNCT1";
            public const string spChungTuBanHangTimKiemCTGNCTietPg = "sp_BHang_ChungTu_TimKiemGNCTPg";
            public const string spChungTuBanHangTimKiemCTGNCTietKThuatPg = "sp_BHang_ChungTu_TKiemGNCTKT1";
            public const string spChungTuBanHangTimKiemCTGNCTietKThuatCTPg = "sp_BHang_ChungTu_TKiemGNKTCT1";
            public const string spChungTuBanHangTimKiemCTGNThongKeKThuatCTPg = "sp_BHang_ChungTu_TKiemGNTKKTPg";
            public const string spChungTuBanHangSearchCTietMVach = "sp_BHang_ChungTu_SearchCTMV";
            public const string spChungTuBanHangSearchCTietMVachPg = "sp_BHang_ChungTu_SearchCTMVPg1";
            public const string spChungTuBanHangSearchCTietChuaXuatDuPg = "sp_BHang_ChungTu_SrcNoXuatDu";
            public const string spChungTuBanHangSearchCTietMVachBHanh = "sp_BHang_ChungTu_SearchCTMVBH";
            public const string spChungTuBanHangSearchCTietMVachBHanhPg = "sp_BHang_ChungTu_SearchMVBHPg2";
            public const string spChungTuBanHangSearchCTietMVachTon = "sp_BHang_ChungTu_SearchCTMVBH";
            public const string spChungTuBanHangSearchCTietMVachTonPg = "sp_BHang_ChungTu_SearchTMVBHPg";
            public const string spChungTuBanHangSearchLichSuMaVach = "sp_BHang_ChungTu_SrcLSuMVach";
            public const string spChungTuBanHangSearchTonMaVach = "sp_BHang_ChungTu_SrcTonMVach";
            public const string spChungTuBanHangSearchTonMaVachPg = "sp_BHang_ChungTu_SrcTonMVach2";
            public const string spChungTuBanHangSearchTonSanPhamPg = "sp_BHang_ChungTu_SrcTonSPhamPg";
            #endregion

            #region tbl_Tmp_ChungTu_Imp
            public const string spImportLoadCTuBySoCTuGoc = "sp_Import_ChungTu_GetByCTuGoc";
            public const string spImportLoadCTuImportBySoCTuGoc = "sp_BHang_ChungTu_GetImpByCTG";
            public const string spImportLoadCTuCTietBySoCTuGoc = "sp_Import_CTuCTiet_GetByCTuGoc";
            public const string spImportLoadCTuCTietHHoaBySoCTuGoc = "sp_Import_CTuCTHH_GetByCTuGoc";
            public const string spImportLoadCTuTToanBySoCTuGoc = "sp_Import_CTuTToan_GetByCTuGoc";
            public const string spImportLoadCTuTToanAddLstBySoCTuGoc = "sp_Import_CTuTToan_AddLstByCTG";
            public const string spImportLoadCTuTToanAddBySoCTuGoc = "sp_Import_CTuTToan_AddByCTuGoc";
            public const string spXoaChungTuBanHangByIdCT = "sp_BHang_ChungTu_XoaDLByCT";
            public const string spXoaChungTuBanHangByDate = "sp_BHang_ChungTu_XoaDLByDate";
            #endregion

            #region tbl_dotkiemke

            public const string spDotKiemKeGetAll = "sp_DotKiemKe_GetAll1";
            public const string spDotKiemKeGetByDate = "sp_DotKiemKe_GetByDate";
            public const string spDotKiemKeUpdate = "sp_DotKiemKe_Update";
            public const string spDotKiemKeUpdate2 = "sp_DotKiemKe_Update3";
            public const string spDotKiemKeInsert = "sp_DotKiemKe_Insert";
            public const string spDotKiemKeChotSoTon = "sp_DotKiemKe_ChotTon2";
            public const string spDotKiemKeDaChotSoTon = "sp_DotKiemKe_DaChotTon";
            public const string spDotKiemKeCanBeFinished = "sp_DotKiemKe_CanBeFinished";
            public const string spDotKiemKeMaUnique = "sp_DotKiemKe_MaUnique";
            #endregion

            #region tbl_Tmp_ChungTu_DC_Imp
            public const string spImportLoadCTuDCBySoPDC = "sp_Import_ChungTuDC_GetBySoPDC";
            public const string spImportLoadCTuDCCTietBySoCTuGoc = "sp_Import_CTuCTiet_GetByCTuGoc";
            public const string spImportLoadCTuDCCTietHHoaBySoCTuGoc = "sp_Import_CTuCTHH_GetByCTuGoc";

            public const string spXoaChungTuDieuChuyenByIdCT = "sp_BHang_ChungTuDC_XoaDLByCT";
            public const string spXoaChungTuDieuChuyenByDate = "sp_BHang_ChungTuDC_XoaDLByDate";

            public const string spImportChungTuDCDelete = "sp_Import_ChungTuDC_Delete";
            public const string spImportChungTuDCInsert = "sp_Import_ChungTuDC_Insert";
            public const string spImportChungTuDCUpdate = "sp_Import_ChungTuDC_Update";
            public const string spImportChungTuCTietDCGetByCT = "sp_Import_CTuCTietDC_GetByCT";
            public const string spImportChungTuCTietDCDelete = "sp_Import_CTuCTietDC_Delete";
            public const string spImportChungTuCTietDCInsert = "sp_Import_CTuCTietDC_Insert";
            public const string spImportChungTuCTietDCUpdate = "sp_Import_CTuCTietDC_Update";
            public const string spImportChungTuCTietHHoaDCGetByCT = "sp_Import_CTuCTHHoaDC_GetByCT";
            public const string spImportChungTuCTietHHoaDCDelete = "sp_Import_CTuCTHHoaDC_Delete";
            public const string spImportChungTuCTietHHoaDCInsert = "sp_Import_CTuCTHHoaDC_Insert";
            public const string spImportChungTuCTietHHoaDCUpdate = "sp_Import_CTuCTHHoaDC_Update";

            #endregion

            #region tbl_tmp_BangGia_BanHang_Imp
            public const string spImportBangGiaBanHangChiTiet = "sp_Import_BangGia_BHang_CTiet";
            #endregion

            #region tbl_ChungTu_KichHoat_BaoHanh
            public const string spChungTuKichHoatBaoHanh = "sp_BHang_ChungTu_InsertKHBH";
            #endregion

            #region tbl_bh_Chung
            public const string spBhKhoaGetAll = "sp_bh_Khoa_getAll";
            public const string spBhItemUpdateKhoa = "sp_bh_item_updatekhoa";
            public const string spBhPhieuNhanUpdateKhoa = "sp_bh_PhieuNhan_updatekhoa";
            public const string spBhBangKeUpdateKhoa = "sp_bh_bangke_updatekhoa";
            public const string spBhItemCheckKhoa = "sp_bh_item_Checkkhoa";
            public const string spBhPhieuNhanCheckKhoa = "sp_bh_PhieuNhan_Checkkhoa";
            public const string spBhBangKeCheckKhoa = "sp_bh_bangke_Checkkhoa";
            public const string spBhMaVachCheckExist = "sp_bh_MaVach_CheckExist";
            public const string spBhMaVachCheckExistKho = "sp_bh_MaVach_CheckExistKho";
            public const string spBhUpdateTruongCa = "sp_bh_UpdateTruongCa";
            public const string spBhGetNhanVienCungNhom = "sp_bh_GetNhanVienCungNhom";
            public const string spBhKhoUpdateType = "sp_bh_Kho_updatetype";
            public const string spBhSanPhamInfor = "sp_bh_SanPham_Search";
            public const string spBhKhoInfor = "sp_bh_Kho_Search";
            public const string spBhReportPendingOrc = " sp_bh_report_pendingOrc";
            public const string spBhGetHangHoaChiTiet = " sp_bh_GetHangHoaChiTiet";
            public const string spBhInsertHangHoaChiTiet = " sp_bh_InsertHangHoaChiTiet";
            #endregion

            #region tbl_Bh_BangKe
            public const string spBhBangKeInsert = "sp_BH_BangKe_Insert";
            public const string spBhBangKeUpdate = "sp_BH_BangKe_Update";
            public const string spBhBangKeDelete = "sp_BH_BangKe_Delete";
            public const string spBhBangKeSelectAll = "sp_BH_BangKe_SelectAll";
            public const string spBhBangKeSelectByTrungTam = "sp_BH_BangKe_selectByTrungTam";
            public const string spBhBangKeExist = "sp_BH_BangKe_Exist";
            public const string spBhBangKeSearchByItem = "sp_BH_BangKe_searchbyitem";
            public const string spBhBangKeUpdateNhanVienGiao = "sp_BH_BangKe_UpdateNhanVien";
            #endregion

            #region tbl_bh_tinhchatcongty

            public const string spBHTinhChatCongTyInsert = "sp_bh_tinhchatcongty_insert";
            public const string spBhChitietTinhchatInsert = "sp_bh_chitiettinhchat_insert";
            public const string spbhChiTiettinhchatUpdatepn = "sp_bh_chitiettinhchat_updatepn";
            public const string spBHTinhChatCongTyGetList = "sp_bh_tinhchatcongty_GetList";
            public const string spBHTinhChatCongTyReport = "sp_bh_tinhchatcongty_Report";
            #endregion

            #region TBL_BH_NHATKYBAOHANH

            public const string spBhNhatKyBaoHanhInsert = "ap_BH_NHATKYBAOHANH_insert";
            public const string spBhNhatKyBaoHanhGetList = "sp_BH_NHATKYBAOHANH_getlist";
            #endregion

            #region tbl_bh_lichsu

            public const string spBHLichSuInsert = "sp_BH_LichSu_Insert";
            public const string spBHLichSuDelete = "sp_BH_LichSu_Delete";
            public const string spBHLichSuGetByPN = "sp_BH_LichSu_GetByPN";
            public const string spBHLichSuGetByMaVach = "sp_BH_LichSu_GetByMaVach";
            public const string spBHLichSuGetAllByIdPhieuNhan = "sp_BH_LichSu_GetByAllByPN";
            public const string spBHLichSuNhanInsert = "sp_BH_LICHSUNHAN_insert";
            public const string spBHLichSuNhanGet = "sp_BH_LICHSUNHAN_Get";
            public const string spBHLichSuNhanTra = "sp_BH_LICHSUTra_insert";
            public const string spBHLichSuNhanUpdateKho = "sp_bh_lichsunhan_updatekho";
            public const string spBHLichSuNhanUpdateMV = "sp_bh_lichsunhan_updatemv1";
            public const string spBHLichSuNhanCauHinhInsert = "sp_bh_lsn_cauhinh_insert";
            public const string spBHLichSuNhanCauHinhGet = "sp_bh_lsn_cauhinh_Get";
            public const string spBHLichSuBanGetList = "sp_bh_lichsuban_get";
            public const string spBHLichSuNhanupdatedoituong = "sp_bh_lichsunhan_updatedt";
            public const string spBHLichSuNhanGetListForDT = "sp_bh_lichsunhan_Getfordt";
            public const string spBHLichSuReportAll = "sp_BH_LichSu_reportall";
            public const string spBHLichSuReportGiong = "sp_BH_LichSu_reportGiong";
            public const string spBHLichSuReportKhac = "sp_BH_LichSu_reportKhac";
            public const string spBHLichSuTachCauHinhInsert = "sp_bh_ls_tachcauhinh_insert";
            public const string spBHLichSuTachCauHinhReport = "sp_bh_ls_tachcauhinh_Report";
            public const string spBHLichSuGetBySoHoaDon = "sp_BH_LichSu_GetBySoHD";
            public const string spBHLichSuBanGetListSHD = "sp_bh_lichsuban_getSHD";
            public const string spBHLichSuNhanInsertth = "sp_bh_lichsunhan_insertth";

            #endregion

            #region tbl_Bh_ChiTietBangKe
            public const string spBhChiTietBangKeInsert = "sp_BH_ChiTietBangKe_Insert";
            public const string spBhChiTietBangKeDelete = "sp_BH_ChiTietBangKe_Delete";
            public const string spBhChiTietBangKeExistMV = "sp_BH_ChiTietBangKe_ExistMV";
            public const string spBhChiTietBangKeSelectById = "sp_bh_ChiTietBangKe_GetById";
            public const string spBhChiTietBangKeGetReport = "sp_bh_ChiTietBangKe_GetReport";
            public const string spBhChiTietBangKeGetReportAll = "sp_bh_ChiTietBangKe_BCAll";
            public const string spBhChiTietBangKeUpdateNgayTra = "sp_bh_ChiTietBangKe_UpdateNT";
            public const string spBhChiTietBangKeUpdatePhieuBaoHanh = "sp_bh_ChiTietBangKe_UpdatePBH";
            public const string spBhChiTietBangKeUpdateKhuVuc = "sp_bh_ChiTietBangKe_UpdateKV";
            public const string spBhChiTietBangKeUpdatePhieuNhan = "sp_bh_ChiTietBangKe_UpdatePN1";
            #endregion

            #region tbl_ChungTu_ChiTiet
            /// <summary>
            /// Xóa chứng từ chi tiết theo IdChiTietChungTu (hàm này có thể dùng chung nên không cần đặt theo tên nghiệp vụ)
            /// </summary>
            public const string spCtCtDelByIdCtCt = "sp_CtCt_DeleteByIdCtCt";

            public const string spChungTuChiTietInsert = "sp_ChungTu_ChiTiet_Insert";
            public const string spChungTuChiTietGetByIdSanPham = "sp_ChungTuCT_SelectByIdSanPham";
            public const string spChungTuChiTietGetById = "sp_ChungTu_ChiTiet_SelectById";
            public const string spChungTuChiTietGetByIdChungTu = "sp_ChungTuCT_SelectByIdChungTu";
            public const string spChungTuChiTietGetBySoPO = "sp_ChungTuCT_SelectBySoPO";
            public const string spChungTuChiTietDeleteByIdChungTu = "sp_ChungTuCT_DeleteByIdChungTu";
            public const string spChungTuChiTietSelectByIdChungTu = "sp_ChungTuCT_SelectByIdCT";
            public const string spChungTuChiTietDNXTHGetByIdChungTu = "sp_CTCT_DNXTH_GetById";

            public const string spChungTuChiTietNhanTHGetByIdChungTu = "sp_ChungTuCT_NhanTHGetByIdCT";
            public const string spChungTuChiTietDNXTHInsert = "sp_ChungTu_CT_DNXTH_Insert";
            public const string spChungTuChiTietDNXTHNewInsert = "sp_CTCT_DNXTH_New_Insert";
            public const string spChungTuChiTietDNXTHDeleteByIdCT = "sp_ChungTuCT_DNXTH_Delete";
            public const string spChungTuChiTietXTHDelete = "sp_ChungTuCT_XTH_Delete";
            public const string spChungTuChiTietXTHUpdate = "sp_ChungTuCT_XTH_Update";
            public const string spChungTuChiTietXTHNewUpdate = "sp_ChungTuCT_XTHNew_Update";
            public const string spChungTuChiTietKhoUpdate = "sp_ChungTu_ChiTiet_Kho_Update";
            public const string spChungTuChiTietSelectBySoCT = "sp_ChungTuCT_SelectBySoCT";
            public const string spChungTuChiTietGetBySoPhieuThu = "sp_ChungTuCT_SelectByPhieuThu";

            //Tran Tuan Cuong
            public const string spChungTuChiTietPNKGetByIdChungTu = "sp_ChungTuCTPNK_GetByIdChungtu";
            public const string spChungTuChiTietXHLGetByIdChungTu = "sp_ChungTuCTXHL_GetByIdChungtu";
            public const string spChungTuChiTietXHLGetBySoChungTuGoc = "sp_ChungTuCTXHL_GetBySoCTGoc";
            public const string spChungTuChiTietXHLGetByMaVach = "sp_ChungTuCTXHL_GetByMaVach";
            public const string spBhPNKCheckTrangthaiPhieu = "sp_BH_PNKCheckTrangThaiPhieu";
            public const string spChungTuChiTietNTPInsert = "sp_ChungTu_ChiTietNTP_Insert";
            public const string spChungTuChiTietNTPUpdate = "sp_ChungTuCT_NTP_Update";
            //Phạm ngọc Minh
            public const string spChungtuchitiethanghoaXNCCSearch = "sp_BH_ChungTuHHXNCC_Search";
            public const string spChungTuChiTietHangHoaXNCCupdatePN = "sp_BH_ChungTuHHXNCC_UpdatePN";
            public const string spChungTuChiTietHangHoaXNCCReport = "sp_BH_ChungTuHHXNCC_Report";
            public const string spChungTuChiTietHangHoaXNCCReport1 = "sp_BH_ChungTuHHXNCC_Report1";
            public const string spChungTuChiTietHangHoaXNCCReportX = "sp_BH_ChungTuHHXNCC_ReportX";
            public const string spCTCTHHXNCCGetUpdateP = "sp_BH_ChungTuHHXNCC_GetUpdateP";
            public const string spChungTuXuatNCCExist = "sp_BH_ChungTuXNCC_Exist";
            public const string spChungTuChiTietHangHoaXNCCReportTD = "sp_BH_ChungTuHHXNCC_ReportTD";

            /// <summary>
            /// Chi tiết chứng từ xuất mượn 
            /// sau khi kế toán xác nhận đã thi tiền thì chứng từ chi tiết được tạo ra và có tiền đặt cọc
            /// </summary>
            public const string spChungTuChiTietXMInsert = "sp_ChungTu_CT_XM_Insert";
            public const string spChungTuChiTietXMUpdate = "sp_ChungTu_CT_XM_Update";
            public const string spChungTuChiTietXMDelete = "sp_ChungTu_CT_XM_Delete";
            public const string spChungTuChiTietXMGetListAll = "sp_ChungTu_CT_XM_GetListAll";
            //CuongTT 08/01/2013
            public const string spChungTuCTGetByMaVach = "sp_ChungTu_CTiet_GetByMaVach";
            public const string spChungTuGetSoChungTuGoc = "sp_ChungTu_GetSoChungTuGoc";
            //Bùi Đức Hạnh sử dụng cho điều chuyển kho
            public const string spChungTuNhanDieuChuyenById = "sp_ChungTu_GetNDCById";
            public const string spChungTuNDCGetBySoChungTuGoc = "sp_ChungTu_GetNDCByCTGoc1";
            public const string spChungTuNDCTGGetBySoChungTuGoc = "sp_ChungTu_GetNDCTGByCTGoc1";
            public const string spChungTuXDCTGGetBySoChungTuGoc = "sp_ChungTu_GetXDCTGByCTGoc";
            public const string spLinhKienSXGetByIdChungTu = "sp_GetLinhKienSX_ByIdChungTu";
            #endregion
            #region Phạm Ngọc Minh Sử dụng trong bảo hành

            public const string spBHChungTuChiTietInsert = "sp_BH_ChungTu_CT_Insert";
            public const string spBHChungTuChiTietUpdate = "sp_BH_ChungTu_CT_Update";
            public const string spBHChungTuChiTietDelete = "sp_BH_ChungTu_CT_Delete";
            public const string spBHChungTuChiTietGetList = "sp_BH_ChungTu_CT_GetList";
            public const string spBHNhapKhoHlInsert = "sp_BH_NhapKhoHl_Insert";

            //chứng từ nhập hàng khách mượn
            public const string spChungTuChiTietNhapMuonGetListAll = "sp_ChungTu_CT_NM_GetListAll";
            #endregion
            #region Tra cứu mã vạch

            public const string spBHTraCuuMVGetSanPhamInfor = "sp_bh_TraCuuMV_GetSanPhamInfor";
            public const string spBHTraCuuMVGetListPhieuNhan = "sp_bh_TraCuuMV_GetListPN";
            public const string spBHTraCuuMVGetListBHang = "sp_bh_TraCuuMV_GetListBhang";
            public const string spBHTraCuuMVGetLichSu = "sp_bh_TraCuuMV_GetLichSu";
            public const string spBHTraCuuMVGetChungTu = "sp_bh_TraCuuMV_GetChungTu";
            #endregion


            #region Bán hàng
            public const string spChungTuBanHangGetByListId = "sp_BHang_ChungTu_GetByListId";
            public const string spChungTuBanHangCTietGetByCT = "sp_BHang_ChungTu_CTiet_GetByCT";
            public const string spChungTuBanHangCTietGetByKM = "sp_BHang_ChungTu_CTiet_GetByKM";
            public const string spChungTuBanHangCTietGetDaXuatByCT = "sp_BHang_ChungTu_CTiet_GetDaXK";
            public const string spChungTuBanHangCTietGetNoKM = "sp_BHang_ChungTu_CTiet_GetNoKM";
            public const string spChungTuBanHangCTietGetById = "sp_BHang_ChungTu_CTiet_GetById";
            public const string spChungTuBanHangCTietInsert = "sp_BHang_ChungTu_CTiet_Ins";
            public const string spChungTuBanHangCTietUpdate = "sp_BHang_ChungTu_CTiet_Upd";
            public const string spChungTuBanHangCTietUpdCTKM = "sp_BHang_ChungTu_CTiet_UpdCTKM";
            public const string spChungTuBanHangCTietDelete = "sp_BHang_ChungTu_CTiet_Delete";
            public const string spChungTuBanHangCTietKMSearch = "sp_BHang_ChungTu_CTiet_CheckKM";
            public const string spChungTuBanHangCTietKMExist = "sp_BHang_ChungTu_CTiet_ExistKM";
            public const string spChungTuNhapHangTraLaiCTietGetByCT = "sp_NTra_ChungTu_CTiet_GetByCT";
            public const string spChungTuBanHangCTietXoaNoKM = "sp_BHang_ChungTu_CTiet_UdpNoKM";
            public const string spChungTuBanHangUpdateNgayHoaDon = "sp_BHang_ChungTu_UpdNgayHDon";
            #endregion

            #region tbl_ChungTu_ChiTiet_HangHoa
            /// <summary>
            /// Ap dung cho cac nghiep vu nhap xuat noi chung
            /// </summary>
            public const string spChungTuChiTietHangHoaUpdate = "sp_ChungTuCTHH_Update";
            public const string spChungTuChiTietHangHoaDelete = "sp_ChungTu_CT_Hanghoa_Delete";

            public const string spChungTuChiTietHangHoaInsert = "sp_ChungTu_HangHoa_Insert";
            public const string spChungTuChiTietHangHoaNhapNCCInsert = "sp_ChungTu_Hanghoa_NCC_Insert";
            public const string spChungTuChiTietHangHoaGetByIdChungTu = "sp_ChungTuCTHH_GetByIdChungTu";
            public const string spChungTuChiTietHHXTHGetbyIdCT = "sp_ChungTuCTHH_XTH_GetByIdCT";
            public const string spChungTuChiTietHHNDCGetbySoPhieu = "sp_ChungTuCTHH_GetBySoPhieu";
            public const string spChungTuChiTietHHXTHInsert = "sp_ChungTuCTHH_XTH_Insert";
            //public const string spChungTuChiTietHHNDCInsert = "sp_ChungTuCTHH_NDC_Insert";
            public const string spChungTuChiTietHHXNBUpdate = "sp_ChiTietHH_XNB_Update";
            public const string spHangHoaChiTietMaVachExist = "sp_HangHoa_CTiet_MaVachExist";
            public const string spHangHoaChiTietCheckSoLuong = "sp_HangHoa_CTiet_CheckSoLuong";
            public const string spGetBaoHanhByIdKhoIdSanPhamMaVach = "sp_GetBaoHanhByIdKhoMaVach";
            // phiếu nhập kho
            public const string spChungTuChiTietHangHoaPNKInsert = "sp_ChungTuCTHH_PNK_insert";
            public const string spChungTuChiTietHangHoaPNKUpdate = "sp_ChungTuCTHHPNK_Update";
            /// <summary>
            /// Chi tiết chứng từ hàng hóa xuất mượn 
            /// sau khi kế toán xác nhận đã thi tiền thì chứng từ chi tiết được tạo ra và có tiền đặt cọc
            /// </summary>
            public const string spChungTuChiTietHHXMInsert = "sp_ChungTuCTHH_XM_Insert";
            public const string spChungTuChiTietHHXMGetListAll = "sp_ChungTuCTHH_XM_GetListAll";
            public const string spChungTuChiTietHHXMDelete = "sp_ChungTuCTHH_XM_Delete";

            //CuongTT 07/11/2012
            public const string spHangHoaChiTietCheck = "sp_HangHoa_CTiet_check";
            public const string spHangHoaChiTietCheckMaVachXacNhanNhapTP = "sp_HHCT_ChkMvXnNhapTP";
            public const string spHangHoaChiTietCheckByKho = "sp_HangHoa_CTiet_checkByKho";
            public const string spHangHoaChiTietNTPCheck = "sp_HangHoa_CTiet_NTP_check";
            public const string spChungTuChiTietCheck = "sp_ChungTu_CTiet_check";

            public const string spBHGetSanPhamInfor = "sp_bh_SanPham_getinfor";
            #endregion

            #region Phạm Ngọc Minh sử dụng cho bảo hành

            public const string spBHChungTuChiTietHHInsert = "sp_BH_ChungTuCTHH_Insert";
            public const string spBHChungTuChiTietHHGetList = "sp_BH_ChungTuCTHH_GetList";
            public const string spBHChungTuChiTietHHDelete = "sp_BH_ChungTuCTHH_Delete";
            public const string spBHChungTuChiTietHHUpdate = "sp_BH_ChungTuCTHH_Update";
            public const string spBHChungTuChiTietHHCheckMaVach = "sp_BH_ChungTuCTHH_CheckMaVach";

            public const string spBHUpdateHangHoaChiTiet = "sp_BH_HangHoa_ChiTiet_Update";
            #endregion

            #region Bán hàng
            public const string spChungTuBanHangCTietHHoaGetByCTu = "sp_BHang_ChungTu_CTHH_GetByCTu";
            public const string spChungTuBanHangCTietHHoaGetAll = "sp_BHang_ChungTu_CTHH_GetAll";
            public const string spChungTuBanHangCTietHHoaGetByMax = "sp_BHang_ChungTu_LoadSerialBan";
            public const string spChungTuBanHangCTietHHoaGetByMV = "sp_BHang_ChungTu_CTHH_GetByMV";
            public const string spChungTuBanHangCTietHHoaGetByDC = "sp_BHang_ChungTu_CTHH_GetByDC";
            public const string spChungTuBanHangCTietHHoaInsert = "sp_BHang_ChungTu_CTHH_Insert";
            public const string spChungTuBanHangCTietHHoaInsertDM = "sp_BHang_ChungTu_CTHH_InsertDM";
            public const string spChungTuBanHangCTietHHoaUpdate = "sp_BHang_ChungTu_CTHH_Update";
            public const string spChungTuBanHangCTietHHoaDelete = "sp_BHang_ChungTu_CTHH_Delete";
            public const string spChungTuBanHangCTietHHoaDelByCT = "sp_BHang_ChungTu_CTHH_DelByCT";
            public const string spChungTuBanHangLichSuDoiMaInsert = "sp_BHang_ChungTu_LSDM_Insert";
            #endregion

            #region tbl_KiemKe
            public const string spInsertSoPhieuKiemKe = "sp_InsertSoPhieuKiemKe";
            public const string spInsertKiemKe = "sp_InsertKiemKe";
            public const string spUpdateKiemKe = "sp_UpdateKiemKe";
            public const string spGetListKiemKe = "sp_GetListKiemKe";
            public const string spGetListKiemKe2 = "sp_GetListKiemKe2";
            public const string spDeleteKiemKe = "sp_DeleteKiemKe";
            public const string spDeleteKiemKe2 = "sp_DeleteKiemKe2";
            public const string spDeleteRowKiemKeCoMaVach = "sp_DeleteRowKiemKeCoMaVach";
            public const string spDeleteRowKiemKeKhongMaVach = "sp_DeleteRowKiemKeKhongMaVach";
            public const string spKiemKeSearch = "sp_KiemKe_Search";
            public const string spUpdateTrangThaiKiemKe = "sp_UpdateTrangThaiKiemKe";
            public const string spUpdateGhiChuKiemKe = "sp_UpdateGhiChuKiemKe";
            public const string spUpdateKiemKeKhoKhach = "sp_UpdateKiemKeKhoKhach";
            public const string spKiemKeChiTietCheckMaVach = "sp_Kiemke_CTiet_CheckMaVach";
            public const string spTrangThaiBysoPhieu = "sp_GetTrangThaiBySoPhieu";
            public const string spChungTuKiemKeLienQuanTon = "sp_KiemKe_ctlq_Ton";
            public const string spChungTuKiemKeLienQuanMaVach = "sp_KiemKe_ctlq_MaVach";
            #endregion

            #region tbl_KiemKe_ChiTiet
            public const string spInsertKiemKe_ChiTiet = "sp_InsertKiemKe_ChiTiet";
            public const string spUpdateKiemKe_ChiTiet = "sp_UpdateKiemKe_ChiTiet";
            public const string spGetListChiTietKiemKeCo = "sp_GetListChiTietKiemKeCo";
            public const string spGetListChiTietKiemKeKhong = "sp_GetListChiTietKiemKeKhong";
            public const string spInsertChiTietKiemKeBoSung = "sp_InsertChiTietKiemKeBoSung";
            public const string spInsertChiTietHangHoaKiemKeBoSung = "sp_Insert_CT_HH_KiemKeBoSung";
            #endregion

            #region tbl_HangHoa_DuDauKy
            public const string spGetTonDauKy = "spGetTonDauKy";
            public const string spNapSoTon = "sp_Ton_NapSoTon";
            public const string spTonDauKyUpdate = "sp_CapNhatTonDauKy_Update";
            public const string spTonDauKyInsert = "sp_CapNhatTonDauKy_Insert";
            public const string spTonDauKyChiTietUpdate = "sp_CapNhatTonDauKy_CT_Update";
            public const string spTonDauKyChiTietInsert = "sp_CapNhatTonDauKy_CT_Insert";
            #endregion

            #region tbl_HangHoa_ChiTiet
            public const string spGetHangHoaChiTiet = "sp_Ton_GetHangHoaChiTiet";
            public const string spGetHangHoaChiTietByMaVach = "sp_HangHoaChiTiet_GetByMaVach";
            public const string spGetHangHoaChiTietByMaVachCTGoc = "sp_HangHoaChiTiet_GetByMVCTGoc";
            public const string spHangHoaChiTietCheckMaVach = "sp_HangHoaChiTiet_Check";
            public const string spUpdateHangHoaChiTietByInfo = "sp_HangHoaChiTiet_UpdateByInfo";
            public const string spUpdateHangHoaChiTietByIdChiTiet = "sp_HangHoaChiTiet_UpdateById";
            public const string spInsertHangHoaChiTietByIdChiTiet = "sp_HangHoaChiTiet_InsertById";
            //CuongTT 20.3.2013
            public const string spHangHoaChiTietInsert = "sp_HangHoaChiTiet_Insert";
            #endregion

            #region tbl_KiemKe_ChiTiet_HangHoa
            public const string spInsertKiemKe_ChiTietHangHoa = "sp_InsertKiemKe_CT_HangHoa";
            public const string spUpdateKiemKe_ChiTietHangHoa = "sp_UpdateKiemKe_CT_HangHoa";
            public const string spGetIdSanPhamByMaVach = "sp_GetIdSanPhamByMaVach";
            public const string spSanPhamById_MaVach = "sp_GetSanPhamInfoById_MaVach";
            #endregion

            #region tbl_KiemKe_ChiTiet_KhongMaVach
            public const string spInsertKiemKe_ChiTietKhongMaVach = "sp_InsertKiemKe_CT_KhongMaVach";
            public const string spUpdateKiemKe_ChiTietKhongMaVach = "sp_UpdateKiemKe_CT_KhongMaVach";
            #endregion

            #region tbl_Dm_BaoCao
            public const string spDmBaoCao_SelectAll = "sp_BHang_ChungTu_BaoCao_GetAll";
            #endregion

            #region tbl_ChungTu_ThanhToan
            public const string spChungTuThanhToanInsert = "sp_BHang_ChungTu_TToan_Insert";
            public const string spChungTuThanhToanUpdate = "sp_BHang_ChungTu_TToan_Update";
            public const string spChungTuThanhToanDelete = "sp_BHang_ChungTu_TToan_Delete";
            public const string spChungTuThanhToanDeleteAll = "sp_BHang_ChungTu_TToan_DelAll";
            public const string spChungTuThanhToanGetAll = "sp_BHang_ChungTu_TToan_GetAll";
            public const string spChungTuThanhToanGetByCT = "sp_BHang_ChungTu_TToan_GetByCT";
            public const string spChungTuThanhToanGetByTT = "sp_BHang_ChungTu_TToan_GetByTT";
            public const string spCongNoKhachHang = "sp_BHang_CongNo_KhachHang";
            public const string spCongNoSieuThi = "sp_BHang_CongNo_SieuThi";

            //Pham Ngọc Minh
            public const string spBHChungTuThanhToanInsert = "sp_BH_ChungTu_TToan_Insert";
            public const string spBHChungTuThanhToanUpdate = "sp_BH_ChungTu_TToan_Update";
            public const string spBHChungTuThanhToanExist = "sp_BH_ChungTu_TToan_Exist";
            public const string spBHChungTuThanhToanCheckXM = "sp_BH_ChungTu_TToan_CheckXM";
            public const string spBHChungTuThanhToanThuBoXung = "sp_BH_ChungTu_TToan_ThuBX";
            public const string spBHChungTuThanhToanExistByIdChungTu = "sp_BH_ChungTu_TToan_ExistByCT";
            public const string spBHChungTuThanhToanGetListAll = "sp_BH_ChungTu_TToan_GetListAll";
            public const string spBHChungTuThanhToanGetBySP = "sp_BH_ChungTu_TToan_GetBySP";
            #endregion

            #region tbl_ChungTu_GiaoNhan
            public const string spChungTuGiaoNhanInsert = "sp_BHang_ChungTu_GNhan_Ins";
            public const string spChungTuGiaoNhanUpdate = "sp_BHang_ChungTu_GNhan_Upd";
            public const string spChungTuGiaoNhanDeleteAll = "sp_BHang_ChungTu_GNhan_DelAll";
            public const string spChungTuGiaoNhanDeleteByCT = "sp_BHang_ChungTu_GNhan_DelCT";
            public const string spChungTuGiaoNhanGetByCT = "sp_BHang_ChungTu_GNhan_GetByCT";
            public const string spChungTuGiaoNhanGetAll = "sp_BHang_ChungTu_GNhan_GetAll";
            public const string spChungTuGiaoNhanGetAllChungTu = "sp_BHang_ChungTu_GetByPCGN";
            public const string spChungTuGiaoNhanGetDonHangByPCGN = "sp_BHang_ChungTu_GetDHGN";
            public const string spChungTuGiaoNhanUpdateTTGN = "sp_BHang_ChungTu_GNhan_UpdTTGN";
            #endregion

            #region tbl_ChungTu_GiaoNhan_ChiTiet
            public const string spChungTuGiaoNhanChiTietInsert = "sp_BHang_CTu_GNCTiet_InsDT1";
            public const string spChungTuGiaoNhanChiTietDelete = "sp_BHang_ChungTu_GNCTiet_Del";
            public const string spChungTuGiaoNhanChiTietGetById = "sp_BHang_ChungTu_GNCTiet_Get";
            public const string spChungTuGiaoNhanChiTietGetByCT = "sp_BHang_ChungTu_GNCTiet_GetCT";
            public const string spChungTuGiaoNhanGetListNhanVien = "sp_NhanVien_GetListByGiaoNhan";
            public const string spChungTuGiaoNhanGetListDoiTac = "sp_DoiTac_GetListByGiaoNhan";
            #endregion

            #region tbl_NhapHang_Log
            public const string spNhapHangLogInsert = "sp_tmp_NhapHang_Log_Insert";
            public const string spNhapHangLogUpdate = "sp_tmp_NhapHangLog_Update";
            public const string spNhapHangLogDelete = "sp_tmp_NhapHangLog_Delete";
            public const string spNhapHangLogGetBySoPO = "sp_tmp_NhapHangLog_GetBySoPO";
            public const string spNhapHangLogGetByUser = "sp_tmp_NhapHangLog_GetByUser";
            public const string spNhapHangLogGetDateMin = "sp_tmp_NhapHangLog_GetDMin";
            #endregion

            #region "tbl_DM_LoaiDoiTuong"
            public const string spLoaiDoiTuongSelectAll = "sp_LoaiDoiTuong_SelectAll";
            public const string spLoaiDoiTuongUpdate = "sp_LoaiDoiTuong_Update";
            public const string spLoaiDoiTuongInsert = "sp_LoaiDoiTuong_Insert";
            public const string spLoaiDoiTuongDelete = "sp_LoaiDoiTuong_Delete";
            public const string spLoaiDoiTuongExist = "sp_LoaiDoiTuong_Exist";
            public const string spLoaiDoiTuongSearch = "sp_LoaiDoiTuong_Search";
            public const string spLoaiDoiTuongGetbyId = "sp_LoaiDoiTuong_GetbyId";

            public const string spLoaiDoiTuongSyncGetLastUpdateDate = "sp_LoaiDoiTuong_Sync_LUD";
            public const string spLoaiDoiTuongSyncTransfer = "sp_LoaiDoiTuong_Sync_Transfer";
            public const string spLoaiDoiTuongSyncInsert = "sp_LoaiDoiTuong_Sync_Insert";
            public const string spLoaiDoiTuongSyncUpdate = "sp_LoaiDoiTuong_Sync_Update";
            #endregion

            #region "tbl_Tmp_DM_LoaiDoiTuong"
            public const string spTmpLoaiDoiTuongDelete = "sp_Tmp_LoaiDoiTuong_Delete";
            public const string spTmpLoaiDoiTuongSelectAll = "sp_Tmp_LoaiDoiTuong_SelectAll";
            public const string spTmpLoaiDoiTuongValid = "sp_Tmp_LoaiDoiTuong_Valid";
            #endregion

            #region tbl_SanXuat_Lenh
            public const string spSanXuatLenhSelectAll = "sp_SanXuat_Lenh_SelectAll";
            public const string spSanXuatLenhRecent = "sp_SanXuat_Lenh_Recent";
            public const string spSanXuatLenhInsert = "sp_SanXuat_Lenh_Insert";
            public const string spSanXuatLenhUpdate = "sp_SanXuat_Lenh_Update";
            public const string spSanXuatLenhUpdate1 = "sp_SanXuat_Lenh_Update1";
            public const string spSanXuatLenhUpdateTrangThai = "sp_SanXuat_Lenh_UpdateTT";
            public const string spSanXuatLenhGetMaLenh = "sp_SanXuat_Lenh_GetbyMaLenh";
            public const string spSanXuatLenhExist = "sp_SanXuat_Lenh_Exist";
            public const string sptmpSanXuatLenhDelete = "sp_tmp_SanXuat_Lenh_Delete";
            public const string sptmpSanXuatLenhSelectall = "sp_tmpSanXuatLenh_SelectAll";
            public const string sptmpSanXuatCTLenhDelete = "sp_tmp_SanXuat_CTLenh_Delete";
            public const string sptmpSanXuatCTLenhSelectAll = "sp_TmpSanXuatCTLenh_SelectAll";
            public const string spSanXuatLenhGetMaxDate = "sp_SanXuat_Lenh_GetMaxDate";
            public const string spSanXuatLenhGetSoLuong = "sp_SanXuat_Lenh_GetSoLuong";
            public const string spSanXuatLenhGetSoLuongDN = "sp_SanXuat_Lenh_GetSoLuongDN1";
            //CuongTT 19/01/2013
            public const string spChungTuGetSoLuong = "sp_chungtu_GetSoLuong";
            public const string spXacNhanXuatGetSoLuong = "sp_XacNhanNhap_GetSoLuong";
            #endregion

            #region tbl_SanXuat_CTietLenh
            public const string spSanXuatCTietLenhInsert = "sp_SXCTietLenh_Insert";
            public const string spSanXuatCTietLenhUpdate = "sp_SXCTietLenh_Update";
            public const string spSanXuatCTietLenhDelete = "sp_SXCTietLenh_Delete";
            public const string spSanXuatCTietLenhUpdateSL = "sp_SXCTietLenh_UpdateSL";
            public const string spSanXuatCTietLenhGetMaLenh = "sp_SXCTietLenh_GetbyMaLenh";
            public const string spSanXuatCtietLenhExist = "sp_SanXuat_CTietLenh_Exist";
            #endregion

            #region tbl_SanXuat_NhapTach
            public const string spSanXuatNhapTachGetMaxDate = "sp_SanXuat_NhapTach_GetMaxDate";
            public const string spSanXuatNhapTachInsert = "sp_SX_NhapTach_Insert";
            public const string spSanXuatNhapTachExist = "sp_SanXuat_NhapTach_Exist";
            public const string spSanXuatNhapTachUpdate = "sp_SX_NhapTach_Update";
            public const string spSanXuatNhapTachDelete = "sp_SX_NhapTach_Delete";
            public const string spSanXuatNhapTachSelectall = "sp_SX_NhapTach_SelectAll";
            public const string spSanXuatNhapTachGetByMaVach = "sp_SX_NhapTach_GetByMaVach";
            public const string sptmpSanXuatNhapTachSelectall = "sp_tmp_SX_NhapTach_SelectAll";
            public const string spSanXuatNhapTachGetSoLuongYC = "sp_SX_NhapTach_GetSoLuongYC";
            public const string spSanXuatNhapTachCTGetBySoChungTu = "sp_SX_NhapTachCT_GetBySCT";
            public const string spSanXuatNhapTachCheckMaVach = "sp_SX_NhapTach_CheckMaVach";
            //CuongTT 09/01/2013
            public const string spSanXuatNhapTachGetByMaLenh = "sp_SX_NhapTach_GetByMaLenh";
            #endregion

            #region Thong Ke
            public const string spThongKeXuatNhapTon = "sp_thongke_xuatnhapton";
            public const string spThongKeXuatNhapTon2 = "sp_thongke_xuatnhapton2";
            public const string spThongKeXuatNhapTon3 = "sp_thongke_xuatnhapton3";
            public const string spThongKeXuatNhapTon4 = "sp_thongke_xuatnhapton4";
            public const string spThongKeXuatNhapTon5 = "sp_thongke_xuatnhapton5";
            public const string spThongKeXuatNhapTonLichSu5 = "sp_thongke_xuatnhaptonLS5";
            public const string spThongKeXuatNhapTonLichSu = "sp_thongke_xuatnhaptonLS";
            public const string spThongKeXuatNhapTonLichSu2 = "sp_thongke_xuatnhaptonLS2";
            public const string spGetListTonKho = "SP_GETLISTTONKHO";
            public const string spThongKeTonMaVach = "sp_thongke_tonmavach";
            public const string spThongKeChungTuLienQuan = "sp_thongke_ctlq";
            public const string spThongKeChiTietHangTrungChuyen = "sp_thongke_cthtc";
            public const string spDeleteCompleteData = "sp_delete_business_data";
            public const string spTongHopTonDauKy = "sp_TongHopTonDauKy";
            public const string spTongHopTonTheoNam = "sp_TongHopTonTheoNam";
            public const string spTongHopTon = "sp_TongHopTon";
            public const string spTongHopTonTheoThang = "sp_TongHopTonTheoThang";
            public const string spTongHopTonTheoNgay = "sp_TongHopTonTheoNgay";
            #endregion

            #region Tra cứu bảo hành

            public const string spBHThongKeTongHop = "sp_BH_ThongKeTongHop";
            public const string spBHTraCuuBaoHanh = "sp_BH_TraCuuBaoHanh";
            public const string spBHGetListItem = "sp_BH_TraCuuBH_GetListItem";
            #endregion

            #region Xuất trả kinh doanh

            public const string spBHXuatTraKinhDoanhGetListAll = "sp_BH_XuatTraKD_GetAll";
            public const string spBHXuatTraKinhDoanhGetListCTietAll = "sp_BH_XuatTraKD_CTiet_GetAll";
            public const string spBHXuatTraKinhDoanhInsert = "sp_BH_XuatTraKD_Insert";
            #endregion

            #region BaoHanh
            #region PhanLoaiBaoHanh

            public static int BHTrungTam = 1;
            public static int BHHang = 2;
            #endregion

            #region tbl_BH_HangXuLy

            public const string spBHYCHangXuLy = "sp_bh_HangXuLy_Insert";
            public const string spBHYCHangXuLyDelete = "sp_bh_HangXuLy_Delete";
            public const string spBHYCHangXuLyGetList = "sp_bh_HangXuLy_GetList";
            #endregion

            #region tbl_BH_YeuCau

            public const string spBHYeuCauInsert = "SP_BH_YEUCAU_Insert";
            public const string spBHYeuCauUpdate = "SP_BH_YeuCau_UpDate";
            public const string spBHYeuCauUpdate1 = "SP_BH_YeuCau_UpDate1";
            public const string spBHYeuCauUpdateHangXuLy = "SP_BH_YeuCau_UpDateHangXL";
            public const string spBHYeuCauUpdateKetThuc = "SP_BH_YeuCau_UpDateKetThuc";
            public const string spBHYeuCauUpdateXuLyKT = "SP_BH_YeuCau_UpDateXuLyKT";
            public const string spBHYeuCauUpdateXuLy = "SP_BH_YeuCau_UpDateXuLy";
            public const string spBHYeuCauHuyPhanCong = "SP_BH_YeuCau_HuyPhanCong";
            public const string spBHYeuCauLoadAll = "SP_BH_YeuCau_LoadAll1";
            public const string spBHYeuCauDelete = "SP_BH_YeuCau_Delete";
            public const string spBHYeuCauLoadAllPC = "SP_BH_YeuCau_LoadAllPC1";
            public const string spBHYeuCauLoadAllKP = "SP_BH_YeuCau_LoadAllKP";
            public const string spBHYeuCauLoadAllKT = "SP_BH_YeuCau_LoadAllKT";
            public const string spBHYeuCauLoadAllKhac = "SP_BH_YeuCau_LoadAllKhac";
            public const string spBHYeuCauUpdatePC = "SP_BH_YeuCau_UpDatePC";
            public const string spBHYeuCauUpdateKP = "SP_BH_YeuCau_UpDateKP";
            public const string spBHYeuCauLoadKH = "SP_BH_YeuCau_LoadKH";
            public const string spBHYeuCauSPDaMuaKH = "sp_bh_yeucau_LoadSPDaMuaKH";
            public const string spBHYeuCauSPDaMuaSP = "sp_bh_yeucau_LoadSPDaMuaSP";

            public const string spBHYeuCauSPDaMuaLS = "sp_bh_yeucau_LoadSPDaMuaLs";
            public const string spBHYeuCauSPDaMuaDM = "sp_bh_yeucau_LoadSPDaMuaDB";

            public const string spBHYeuCauSPDaMua = "sp_bh_yeucau_LoadSPDaMua";
            public const string spBHYeuCauLookUp = "SP_BH_YeuCau_LookUp";
            public const string spBHYeuCauSearchKH = "sp_bh_yeucau_SearchKH";
            public const string spBHYeuCauExistYCau = "SP_BH_YeuCau_ExistYCau";
            public const string spBHYeuCauExistPc = "SP_BH_YeuCau_ExistPc";
            public const string spBHYeuCauLoadGetObject = "SP_BH_YeuCau_LoadOb";
            public const string spBHYeuCauUpdateNhapKho = "SP_BH_YeuCau_UpDateNK";
            public const string spBHYeuCauUpdateGioXL = "SP_BH_YeuCau_UpdateGioXL";
            public const string spBhYeuCauGetBaoCao = "sp_bh_yeucau_getbaocao";
            public const string spBhYeuCauGetBaoCaoPg = "sp_BH_YeuCau_GetBaoCaoPg";
            public const string spBhYeuCauUpdateDiem = "sp_bh_yeucau_UpdateDiem";
            public const string spBhYeuCauInsertLichSuPC = "sp_bh_yeucau_InsertLichSuPC";
            public const string spBhYeuCauGetBaoCaoHang = "SP_BH_YeuCau_GetBCHang1";
            public const string spBHYeuCauUpdateTra = "SP_BH_YeuCau_UpDateTra";
            public const string spBHBCYCSDTaiNha = "sp_Bh_BCYeuCauTaiNha1";
            public const string spBHBYeuCauSearchLanTruoc = "sp_Bh_YeuCau_SearchLanTruoc";
            public const string spBHYeuCauInsertDiKem = "sp_bh_yeucau_nv_insert";
            public const string spBHYeuCauNhanVienList = "sp_bh_yeucau_nv_List";
            public const string spBHYeuCauUpdatePhanHoi = "sp_bh_yeucau_UpdatePhanHoi";
            public const string spBHYeuCauUpdateHoanThien = "sp_bh_yeucau_UpdateHoanthien";
            public const string spBHBCKSYCSDTaiNha = "sp_Bh_KSBCYeuCauTaiNha";
            public const string spBHYeuCauUpdateChuyenTT = "SP_BH_YeuCau_ChuyenTT";
            #endregion

            #region tbl_bh_huyphieunhan
            public static string spBhHuyPhieuNhanInsert = "sp_Bh_huyPhieuNhan_Insert";
            public static string spBhHuyPhieuNhanUpdate = "sp_Bh_huyPhieuNhan_Update";
            public static string spBhHuyPhieuNhanLoad = "sp_Bh_huyPhieuNhan_Load";
            public static string spBhHuyPhieuNhanReport = "sp_Bh_huyPhieuNhan_Report";

            #endregion

            #region tbl_BH_PhieuNhan

            public static string spBHPhieuNhanHangLoiInsert = "sp_BH_PhieuNhanHangLoi_Insert1";
            public static string spBhPhieuNhanHangLoiUpdate = "sp_BH_PhieuNhanHangLoi_Update";
            public static string spBHPhieuNhanHangLoiLoadAll = "sp_BH_PhieuNhanHangLoi_LoadAll";
            public static string spBHPhieuNhanHangLoiLoadData = "sp_BH_PhieuNhanHangLoi_Load";

            public static string spBHPhieuNhanHangLoiDelete = "sp_BH_PhieuNhanHangLoi_Delete";
            public static string spBHPhieuNhanHangLoiExist = "sp_BH_PhieuNhanHangLoi_Exist";
            public static string spBHPhieuNhanHangLoiBySoPhieu = "sp_BH_PhieuBienNhan_BySoPhieu";
            public static string spBHPhieuNhanHangLoiLookUp = "sp_BH_PhieuNhanHangLoi_LookUp";
            public static string spBHPhieuNhanHangLoiLookUpTra = "sp_BH_PhieuNhanHangLoi_Tra";
            public static string spBHPhieuNhanHangLoiGetTraInfor = "sp_BH_PNHL_GetTraInfor";
            public static string spBHPhieuNhanHangLoiByID = "sp_BH_PhieuNhanHangLoi_ByID";
            public static string spBHPhieuNhanHangLoiUpdateTT = "sp_BH_PNHL_UpdateTT";
            public static string spBHPhieuNhanHangLoiUpdateTrungTamTra = "sp_BH_PNHL_UpdateTrungTamT";
            public static string spBHPhieuNhanHangLoiCheckItem = "sp_BH_PNHL_CheckItem";
            public static string spBHPhieuNhanHangLoiGetBySerial = "sp_BH_PNHL_GetBySerial";
            public static string spBHPhieuNhanHangLoiPL = "sp_BH_PhieuNhanHangLoi_PL";
            public static string spBHPhieuNhanHangLoiMuonTra = "sp_BH_PNHL_MuonTra";

            public static string spBHPhieuNhanHangLoiBaoCao = "sp_BH_PhieuNhanHangLoi_BaoCao";

            public static string spBHPhieuNhanHangLoiBaoCaoTN = "sp_BH_PNHL_BaoCaoTN";
            public static string spBHPhieuNhanHangLoiBaoCaoTNPg = "sp_BH_PNHL_BaoCaoTNPg";

            public static string spBHPhieuNhanHangLoiBaoCaoCTy = "sp_BH_PhieuNhanHangLoi_BCCTy";
            public static string spBHPhieuNhanHangLoiBaoCaoCTyTD = "sp_BH_PhieuNhanHangLoi_BCCTyTD";
            public static string spBHPhieuNhanHangLoiGetSPGoc = "sp_BH_PhieuNhanHL_GetSPGoc";
            public static string spBHPhieuNhanHangLoiBaoCaoTHPg = "sp_BH_PhieuNhanHangLoi_BCTHPg";
            public static string spBHPhieuNhanHangLoiBaoCaoTH = "sp_BH_PhieuNhanHangLoi_BCTH";
            public static string spBHPhieuNhanHangLoiBaoCaoTHLoiLai = "sp_BH_PhieuNhanHangLoi_BCLL";
            public static string spBHPhieuNhanHangLoiBaoCaoCTyK = "sp_BH_PhieuNhanHangLoi_BCCTyK";
            public static string spBHPhieuNhanHangLoiBaoCaoCTyXM = "sp_BH_PhieuNhanHangLoi_BCCTyXM";
            public static string spBHPhieuNhanHangLoiBaoCaoCTyKTD = "sp_BH_PhieuNhanHangLoi_BCCTyKTD";
            public static string spBHPhieuNhanHangLoiBaoCaoCTyXMTD = "sp_BH_PhieuNhanHangLoi_CTyXMTD";
            public static string spBHPhieuNhanUpdateNgayHen = "sp_bh_PhieuNhan_updateNgayHen";
            //CuongTT
            public static string spBHPhieuNhanHangLoiLoadByTrangthai = "sp_BH_PNHangLoi_GetByTrangthai";
            public static string spBHPhieuXuatHangLoiLoadByTrangthai = "sp_BH_PXHangLoi_GetByTrangthai";
            public static string spBHBangKeHangLoiLoadByTrangthai = "sp_BH_BKHangLoi_GetByTrangthai";
            public static string spBhPhieuNhanHangLoiUpdateNK = "sp_BH_PNHangLoi_UpdateNK";
            public static string spBhPhieuNhanHangLoiUpdateTrungTam = "sp_BH_PNHangLoi_UpdateTrungTam";

            //TuanNA
            public static string spBHPhieuNhanHangLoiXMLookUp = "sp_BH_PNHangLoiXM_LookUp";
            public static string spBHPhieuNhanHangLoiXMLookUpAll = "sp_BH_PNHangLoiXM_LookUpAll";
            #endregion

            #region tbl_BH_CauHinhNhan
            public static string spBHCauHinhNhanGetCauHinh = "sp_BH_CauHinhNhan_CauHinh";

            public static string spBHCauHinhNhanGetCauHinhLSP = "sp_BH_CauHinhNhan_CauHinhLSP";
            public static string spBHCauHinhNhanInsert = "sp_BH_CauHinhNhan_Insert";
            public static string spBHCauHinhNhanUpdate = "sp_BH_CauHinhNhan_Update";
            public static string spBHCauHinhNhanDelete = "sp_BH_CauHinhNhan_Delete";
            public static string spBHCauHinhNhanUpDateTach = "sp_BH_CauHinhNhan_UpdateTach";
            public static string spBHCauHinhNhanTra = "sp_BH_CauHinhNhan_Tra";
            public static string spBHCauHinhNhanUpdateSerial = "sp_BH_CauHinhNhan_UpdateSerial";

            public static string spBHCauHinhNhanUpdateIdItem = "sp_BH_CauHinhNhan_UpdateIdItem";
            public static string spBHCauHinhNhanGetTrangThaiTach = "sp_BH_CauHinhNhan_TTTach";
            public static string spBHCauHinhNhanSearch = "sp_BH_CauHinhNhan_Search";
            public static string spBHCauHinhNhanGetCauHinhBH = "sp_BH_CauHinhNhan_CauHinhBH";
            public static string spBHCauHinhNhanUpdateNhapLai = "sp_BH_CauHinhNhan_UpdateNL";
            public static string spBHCauHinhNhanCheckItem = "sp_BH_CauHinhNhan_CheckItem";
            #endregion

            #region tbl_BH_BangKePhieuxuat
            public static string spBHBangKePhieuXuatInsert = "sp_BH_BangKePhieuXuat_Insert";
            public static string spBHBangKePhieuXuatExist = "sp_BH_BangKePhieuXuat_Exist";
            public static string spBHBangKePhieuXuatDeleteByIdChungTu = "sp_BH_BangKePhieuXuat_Delete1";
            public static string spBHBangKePhieuXuatSearchByChungTu = "sp_BH_BangKePhieuXuat_SearchC1";

            #endregion

            #region tbl_BH_Item
            public static string spBHItemInsert = "sp_BH_Item_Insert";
            public static string spBHItemUpdate = "sp_BH_Item_Update";
            public static string spBHItemDelete = "sp_BH_Item_Delete";
            public static string spBHItemGetData = "sp_BH_Item_GetData";
            public static string spBHItemUpdateTrangThai = "sp_BH_Item_UpdateTrangThai";
            public static string spBhItemGetView = "sp_BH_Item_GetView";
            public static string spBhItemGetViewGoc = "sp_BH_Item_GetViewGoc";

            public static string spBhItemGetViewPL = "sp_BH_Item_GetViewPL";
            public static string spBHItemUpdatePhanLoai = "sp_BH_Item_UpdatePhanLoai";
            public static string spBHItemUpdateLoi = "sp_BH_Item_UpdateLoi";
            public static string spBHItemUpdateKiemTra = "sp_BH_Item_UpdateKiemTra";
            public static string spBHItemUpdatePhieuNhan = "sp_BH_Item_UpdatePN";
            public static string spBHItemUpdatePhieuNhanNoGoc = "sp_BH_Item_UpdatePNNoGoc";
            public static string spBHItemSearchItem = "sp_BH_Item_Search";
            public static string spBHItemSearchItemKhach = "sp_BH_Item_SearchKhach";
            public static string spBhItemGetListItem = "sp_BH_Item_GetListItem";

            public static string spBhItemGetListItemTraKD = "sp_BH_Item_GetListItemTraKD";

            public static string spBHItemUpdateDaXetLoi = "sp_BH_Item_UpdateDaXetLoi";
            public static string spBhItemGetListItemByDC = "sp_BH_Item_GetListItemByDC";
            public static string spBhItemGetByMaVach = "sp_BH_Item_GetByMaVach";
            public static string spBhItemGetChiPhiHang = "sp_BH_Item_GetChiPhiHang";
            public static string spBhItemGetListItemByItemGoc = "sp_BH_Item_GetListByItemGoc";
            public static string spBHItemDeleteByItem = "sp_BH_Item_DeleteByItem";
            public static string spBhItemGetListItemTra = "sp_BH_Item_GetListItemTra";
            public static string spBHItemUpdateNhanNCC = "sp_BH_Item_UpdateNhanNCC";
            public static string spBHItemUpdateXuatTra = "sp_BH_Item_UpdateXuatTra";
            public static string spBHItemUpdateTTLK = "sp_BH_Item_UpdateTTLK";
            public static string spBHItemUpdateBangKe = "sp_BH_Item_UpdateBangKe";
            public static string spBHItemUpdateHanNCCThuc = "sp_BH_Item_UpdateHanNCCThuc";

            public static string spBHItemUpdateKhoNhap = "sp_BH_Item_UpdateKhoNhap";
            public static string spBhItemGetListItemKTTH = "sp_BH_Item_GetListItemKTTH";
            public static string spBHItemUpdateNgayTra = "sp_BH_Item_UpdateNgayTra";
            public static string spBHItemGetListDinhGia = "sp_BH_Item_GetListDinhGia";
            public static string spBHItemUpdateDinhGia = "sp_BH_Item_GetUpdateDinhGia";
            public static string spBHItemUpdateLoaiHang = "sp_BH_Item_GetUpdateLoaiHang";
            public static string spBHItemUpdateMoTaLoi = "sp_BH_Item_GetUpdateMoTaLoi";
            public static string spBHItemKiemTraMaVach = "sp_BH_Item_KiemTraMV";
            public static string spBHItemUpdateTypeTien = "sp_BH_Item_GetUpdateTypeTien";
            public static string spBHItemInsertLSDinhGia = "sp_BH_Item_InsertLSDinhGia";
            public static string spBHItemReportLSDinhGia = "sp_BH_Item_ReportLSDinhGia";
            //kiểm tra mã vạch sản phẩm
            public static string spBhItemGetListCheckItem = "sp_BH_Item_GetListCheckItem";

            public static string spBhItemGetNhapPOItem = "sp_BH_Item_GetNhapPOItem";

            //Tran Tuan Cuong 10/10/2012
            public static string spBHItemNoBaoHanhUpdate = "sp_BH_ItemNoBaoHanh_Update";
            //import
            public static string spBHItemGetListAll = "sp_BH_Item_GetListAll";
            #endregion

            #region tbl_Bh_BaoHanh
            //Select bao hanh theo doi tuong va ma vach
            public const string spBhBaoHanhGetListDtMV = "sp_BH_BaoHanh_GetListDtMV";
            public const string spBhBaoHanhGetByChungTu = "sp_BH_BaoHanh_GetByChungTu";
            public const string spBhBaoHanhUpdateMaVach = "sp_BH_BaoHanh_UpdateMaVach";
            public const string spBhBaoHanhSearchMaVach = "sp_BH_BaoHanh_SearchMaVachBH";
            public const string spBhBaoHanhGetListSHD = "sp_BH_BaoHanh_GetListSHD";
            #endregion

            #region tbl_Bh_PhieuXuatMuon
            public static string spBHPhieuXuatMuonInsert = "sp_BH_PhieuXuatMuon_Insert";
            public static string spBHPhieuXuatMuonUpdate = "sp_BH_PhieuXuatMuon_Update";
            public static string spBHPhieuXuatMuonDelete = "sp_BH_PhieuXuatMuon_Delete";
            public static string spBHPhieuXuatMuonByID = "sp_BH_PhieuXuatMuon_ByID";
            public static string spBHPhieuXuatMuonAll = "sp_BH_PhieuXuatMuon_All";

            //TUAN
            public static string spBHPhieuYeuCauXMInsert = "sp_BH_PhieuYeuCauXM_Insert";
            public static string spBHPhieuYeuCauXM_CTu_Insert = "sp_BH_PhieuYeuCauXM_CTu_Insert";
            public static string spBHPhieuYeuCauXMUpdate = "sp_BH_PhieuYeuCauXM_Update";
            public static string spBHPhieuYeuCauXMDelete = "sp_BH_PhieuYeuCauXM_Delete";
            public static string spBHPhieuYeuCauXMAll = "sp_BH_PhieuYeuCauXM_All";
            public static string spBHPhieuYeuCauXMByID = "sp_BH_PhieuYeuCauXMByID";
            // Minh
            public static string spBHPhieuXuatMuonLoadByPN = "sp_BH_PhieuXuatMuon_LoadByPN";
            public static string spBHPhieuXuatMuonLoadByPNT = "sp_BH_PhieuXuatMuon_LoadByPNT";
            public static string spBHPhieuYeuCauXMBySoChungTu = "sp_BH_PhieuYeuCauXMBySoChungTu";
            public static string spBHPhieuXuatMuonObject = "sp_BH_PhieuYeuCauXM_Object";
            public static string spBHPhieuXuatMuonBaoCao = "sp_BH_PhieuYeuCauXM_BaoCao";
            public static string spBHPhieuXuatMuonBaoCaoPg = "sp_BH_PhieuYeuCauXM_BaoCaoPg";
            public static string spBHPhieuXuatMuonPhieuChi = "sp_BH_PhieuYeuCauXM_PhieuChi";
            public static string spBHPhieuXuatMuonHuyKT = "sp_BH_PhieuYeuCauXM_HuyKT";
            #endregion

            #region tbl_Bh_PhieuXuatMuonCT
            public static string spBHPhieuXuatMuonCtInsert = "sp_BH_CT_PhieuXuatMuon_Insert";
            public static string spBHPhieuXuatMuonCtUpdate = "sp_BH_CT_PhieuXuatMuon_Update";
            public static string spBHPhieuXuatMuonCtDelete = "sp_BH_CT_PhieuXuatMuon_Delete";
            public static string spBHPhieuXuatMuonCtDeleteAll = "sp_BH_CT_PhieuXM_DeleteAll";
            public static string spBHPhieuXuatMuonCtLoadAll = "sp_BH_CT_PhieuXM_LoadAll";
            public static string spBHPhieuXuatMuonCtLoadSP = "sp_BH_CT_PhieuXM_LoadSP";

            public static string spBHPhieuXuatMuonCt_KTLoadAll = "sp_BH_CT_PhieuXM_KT_LoadAll";

            //Phạm Ngọc Minh 12/10/2012
            public static string spBHPhieuXuatMuonGetListReport = "sp_BH_PhieuXM_GetListReport";
            public static string spBHNCCNoBaoHanhGetListAll = "sp_Bh_NCCNo_GetListAll";
            public static string spBHNCCNoBaoHanhUpdateItem = "sp_Bh_NCCNo_UpdateItem";
            //TUAN
            public static string spBHPhieuYeuCauXMCtLoadByIdChungTu = "sp_BH_PhieuYCXMCt_GetByIdCT";
            public static string spBHPhieuYeuCauXMCtInsert = "sp_BH_CT_PhieuYeuCauXM_Insert";
            public static string spBHPhieuYeuCauXMCtUpdate = "sp_BH_CT_PhieuYeuCauXM_Update";
            public static string spBHPhieuYeuCauXMCtKTUpdate = "sp_BH_CT_PhieuYCXMKT_Update";
            public static string spBHPhieuYeuCauXMCtDelete = "sp_BH_CT_PhieuYeuCauXM_Delete";
            public static string spBHPhieuYeuCauXMCtDeleteAll = "sp_BH_CT_PhieuYeuCauXM_DeleteAll";
            public static string spBHPhieuYeuCauXMCtLoadAll = "sp_BH_CT_PhieuYeuCauXM_LoadAll";
            public static string spBHPhieuYeuCauXMCtLoadSP = "sp_BH_CT_PhieuYeuCauXM_LoadSP";

            public static string spBHPhieuYeuCauXM_KhoCtLoadSP = "sp_BH_CT_PhieuYCXM_Kho_LoadSP";

            public static string spBHPhieuYeuCauXM_KhoCtNgayMuon = "sp_BH_CT_XM_Kho_NgayMuon";
            #endregion

            #region tbl_Bh_PhieuXM_CT_HangHoa
            public static string spBHPhieuYeuCauXMCtHHInsert = "sp_BH_PhieuXM_CT_HH_Insert";
            public static string spBHPhieuYeuCauXMCtHHUpdate = "sp_BH_PhieuXM_CT_HH_Update";
            public static string spBHPhieuYeuCauXMCtHHDelete = "sp_BH_PhieuXM_CT_HH_Delete";
            public static string spBHPhieuXuatMuonCtHHLoadAll = "sp_BH_PhieuXM_CT_HH_LoadAll";
            public static string spBHPhieuYeuCauXMCtHHLoadBySerial = "sp_BH_PhieuXM_CT_HH_LoadBySeri";
            public static string spBHPhieuYeuCauXMCtHHCheckTon = "sp_BH_PhieuXM_CT_HH_CheckTon";

            #endregion

            #region tbl_bh_phancongbh
            public static string spBHPhanCongInsert = "sp_BH_PhanCong_Insert";
            public static string spBHPhanCongUpdate = "sp_BH_PhanCong_Update";
            public static string spBHPhanCongDelete = "sp_BH_PhanCong_Delete";
            public static string spBHPhanCongGetListPhanLoai = "sp_BH_PhanCong_GetPhanLoai";
            public static string spBHPhanCongGetObjectInfor = "sp_BH_PhanCong_GetObject";
            public static string spBHPhanCongExsitPhanCong = "sp_BH_PhanCong_Exsit";
            public static string spBHPhanCongGetThucHien = "sp_BH_PhanCong_GetThucHien";
            public static string spBHPhanCongGetKiemTraTongHop = "sp_BH_PhanCong_GetKiemTra";
            public static string spBHPhanCongGetDaBaoHanh = "sp_BH_PhanCong_DaBaoHanh";
            public static string spBHPhanCongGetThucHienKT = "sp_BH_PhanCong_GetThucHienKT";
            public static string spBHPhanCongGetThucHienPC = "sp_BH_PhanCong_GetThucHienPC";
            public static string spBHPhanCongGetThucHienPCAll = "sp_BH_PhanCong_GetTHPCAll";
            public static string spBHPhanCongUpdateKetThuc = "sp_BH_PhanCong_UpdateKetThuc";
            public static string spBHPhanCongUpdateNVTH = "sp_BH_PhanCong_UpdateNVTH";
            #endregion

            #region tbl_BH_lichsupc

            public static string spBHLichSuPhanCongInsert = "sp_BH_LichSuPC_Insert";
            public static string spBHLichSuPhanCongGetListALLByIdItem = "sp_BH_LichSuPC_GetListByIdItem";
            public static string spBHLichSuPhanCongGetListALLByIdItemPg = "sp_BH_LichSuPC_GetLstByIdPg";
            public static string spBHLichSuPhanCongGetListDanhGia = "sp_BH_LichSuPC_GetListDanhGia";
            public static string spBHLichSuPhanCongExist = "sp_BH_LichSuPC_Exist";
            public static string spBHLichSuPhanCongUpdate = "sp_BH_LichSuPC_Update";
            public static string spBHLichSuPhanCongUpdateDG = "sp_BH_LichSuPC_UpdateDG";
            #endregion

            #region HangLoiKinhDoanh

            public static string spBH_DieuChuyen_LoadCT = "sp_BH_DieuChuyen_LoadCT";
            public static string spBH_ChungTuCT_SelectByIdCT = "sp_BH_ChungTuCT_SelectByIdCT";
            public static string spBH_HangLoiKinhDoanh_UpdateItem = "sp_BH_HLKD_UpdateItem";
            public static string spBH_HangLoiKinhDoanh_InsertItem = "sp_BH_HLKD_InsertItem";
            public static string spBH_HangLoiKinhDoanh_Insert = "sp_BH_HLKD_Insert";
            public static string spBH_KinhDoanh_Insert = "sp_BH_KinhDoanh_Insert";
            public static string spBH_KinhDoanh_Update = "sp_BH_KinhDoanh_Update";
            public static string spBH_ChungTuCT_SelectAll = "sp_BH_ChungTuCT_SelectAll";

            #endregion

            #region tbl_bh_ThucHienBh

            public static string spBHThucHienBHInsert = "sp_BH_ThucHienBH_Insert";
            public static string spBHThucHienBHDelete = "sp_BH_ThucHienBH_Delete";
            public static string spBHThucHienBHLoadAll = "sp_BH_ThucHienBH_LoadAll";
            public static string spBHThucHienBHLoadAllByIdCauHinhNhan = "sp_BH_ThucHienBH_ByCHN";
            public static string spBHThucHienBHLoadByItem = "sp_BH_ThucHienBH_ByItem";
            public static string spBHThucHienBHCheckSP = "sp_BH_ThucHienBH_CheckSP";
            public static string spBHThucHienBHCheckSPKhach = "sp_BH_ThucHienBH_CheckSPKhach";
            public static string spBHThucHienBHUpdateIdItem = "sp_BH_ThucHienBH_UpdateItem";
            public static string spBHThucHienBHLoadKho = "sp_BH_ThucHienBH_LoadKho";
            public static string spBHThucHienBHUpdateSerial = "sp_BH_ThucHienBH_UpdateSerial";
            public static string spBHThucHienBHUpdateSerialH = "sp_BH_ThucHienBH_UpdateSerialH";
            public static string spBHThucHienBHUpdateSerialHK = "sp_BH_ThucHienBH_UpdateHuyKT";
            public static string spBHThucHienBHUpdateChiPhiTT = "sp_BH_ThucHienBH_UpdateCPTT";
            public static string spBHThucHienBHUpdateHuyKT = "sp_BH_ThucHienBH_UpdateKTHuy";
            public static string spBHThucHienBHGetMaThayThe = "sp_bh_MaThayThe_GetList";
            public static string spBHThucHienBHUpdateNV = "sp_BH_ThucHienBH_UpdateNV";
            public static string spBHCheckMaVach = "sp_BH_CheckMaVach";
            public static string spBHCheckMaVachKhach = "sp_BH_CheckMaVachKhach";
            public static string spBHThongKe_MaVachAll = "sp_BH_ThongKe_MaVachAll";
            public static string spBHThucHienBHGetReport = "sp_BH_ThucHienBH_GetReport";
            public static string spBHThucHienBHGetReportPg = "sp_BH_ThucHienBH_GetReportPg";
            public static string spBHThucHienBHUpdateDanhGia = "sp_BH_ThucHienBH_UpdateDG";
            public static string spBHThucHienBHUpdateSerialN = "sp_BH_ThucHienBH_UpdateMaVachN";

            public static string spBHThucHienBHCheckExist = "sp_BH_ThucHienBH_CheckExist";
            public static string spBHThucHienBHCheckExistTH = "sp_BH_ThucHienBH_CheckExistTH";
            public static string spBHThucHienBHCheckExistMV = "sp_BH_ThucHienBH_CheckExistMV";
            //update cho item
            public static string spBHThucHienBHUpdateChungTu = "sp_BH_ThucHienBH_UpdateCTu";
            public static string spBHThucHienBHUpdateGhiChuKho = "sp_BH_ThucHienBH_UpdateKho";
            public static string spBhThucHienBHUpateDaThucHien = "sp_BH_ThucHienBH_UpdateDaTH";
            public static string UpdateTrangThaiTra = "sp_BH_PXM_UpdateTT";
            public static string UpdateTrangThaiNhapKHo = "sp_BH_PXM_UpdateNhapKho";

            #endregion


            #region tbl_BH_DamPhanHang

            public static string spBHDamPhanHangInsert = "sp_BH_DamPhanHang_Insert";
            public static string spBHDamPhanHangDelete = "sp_BH_DamPhanHang_Delete";
            public static string spBHDamPhanHangGetList = "sp_BH_DamPhanHang_GetList";
            public static string spBHDamPhanHangReport = "sp_BH_DamPhanHang_Report";
            #endregion

            #region tbl_BH_HangNhanBH

            public static string spBHHangNhanBHInsert = "sp_BH_HangNhanBH_Insert";
            public static string spBHHangNhanBHGet = "sp_BH_HangNhanBH_Get";
            public static string spBHHangNhanBHChiTietGet = "sp_BH_HangNhanBH_CT_Get";
            public static string spBHHangNhanBHChiTietInsert = "sp_BH_HangNhanBH_CT_Insert";

            public static string spBHHangNhanBHChiTietAllMV = "sp_BH_HangNhanBH_CT_AllMV";

            #endregion

            #region InPhieuBaoHanh
            public static string spInPhieuBaoHanhGet = "sp_InPhieuBH_Get";
            public static string spInPhieuBaoHanhChiTiet = "sp_InPhieuBH_ChiTiet";
            public static string spInPhieuBaoHanhGetLinhKien = "sp_InPhieuBH_GetLinhKien";

            public static string spBhKhuVucNCCGetList = "sp_bh_khuvuc_ncc_getlist";
            public static string spBhKhuVucNCCUpdate = "sp_bh_khuvuc_ncc_update";
            #endregion

            #region BaoCaoTonKho

            public static string spBHBaoCaoTonKhoGetList = "sp_BH_thongke_xuatnhapton";
            public static string spBHBaoCaoTonKhoGetListPg = "sp_BH_thongke_TonKhoBaoHanhPg";
            public static string spBHBaoCaoTonKhoGetListAll = "sp_BH_thongke_xuatnhaptonAll";
            public static string spBHBaoCaoTonMaVachGetList = "sp_BH_thongke_tonmavach";
            public static string spBHBaoCaoTonMaVachGetListPg = "sp_BH_Thongke_TonMVachBHanhPg";
            public static string spBHBaoCaoTonMaVachGetListCT = "sp_BH_Thongke_TonMVachBHanhCT";
            public static string spBHBaoCaoTonMaVachGetListByIdKho = "sp_BH_thongke_tonmavach_ByKho";
            #endregion

            #region DamPhanKhachLe
            public static string spBHDamPhanKhachLeInsert = "sp_BH_DPKhachLe_Insert";
            public static string spBHDamPhanKhachLeLoadAll = "sp_BH_DPKhachLe_LoadAll";
            public static string spBHDamPhanKhachLeLoadBC = "sp_BH_DPKhachLe_LoadBC";

            #region tbl_bh_suamavach

            public static string spBhSuaMaVachInsert = "sp_bh_suamavach_insert";
            #endregion
            #endregion

            #region tbl_bh_loaihinhdichvu

            public static string spBHLoaiHinhDichVuGetCbo = "sp_BH_LoaiHinhDV_GetCbo";
            #endregion

            #region tbl_bh_chungtunhan

            public static string spBHChungTuNhanInsert = "sp_bh_chungtunhap_insert";

            #region tbl_bh_chinhsach_ncc

            public static string spBHChinhSachNCCInsert = "sp_BH_CHINHSACH_NCC_insert";
            public static string spBHChinhSachNCCUpdate = "sp_BH_CHINHSACH_NCC_Update";
            public static string spBHChinhSachNCCDelete = "sp_BH_CHINHSACH_NCC_Delete";
            public static string spBHChinhSachNCCGetAll = "sp_bh_chinhsach_ncc_getall";
            public static string spBHChinhSachNCCExist = "sp_bh_chinhsach_ncc_Exist";
            public static string spBHChinhSachNCCExistApDung = "sp_bh_chinhsach_ncc_ExistAD";
            public static string spBHChinhSachNCCLoad = "sp_bh_chinhsach_ncc_Load";

            public static string spbhdmcamketnccgetall = "sp_bh_dm_camketncc_getall";
            #endregion

            #region tbl_bh_csncc_loaisp
            public static string spBHChinhSachNCCLoaiSPInsert = "sp_BH_CSNCC_LOAISP_insert";
            public static string spBHChinhSachNCCLoaiSPUpdate = "sp_BH_CSNCC_LOAISP_update";
            public static string spBHChinhSachNCCLoaiSPDelete = "sp_BH_CSNCC_LOAISP_delete";
            public static string spBHChinhSachNCCLoaiSPGetAll = "sp_BH_CSNCC_LOAISP_GetAll";
            public static string spBHChinhSachNCCLoaiSPDeleteAll = "sp_BH_CSNCC_LOAISP_deleteAll";

            public static string spBHChinhSachNCCLinhVuc = "sp_BH_CSNCC_LOAISP_linhvuc";
            public static string spBHChinhSachNCCNganh = "sp_BH_CSNCC_LOAISP_nganh";
            public static string spBHChinhSachNCCLoai = "sp_BH_CSNCC_LOAISP_loai";
            public static string spBHChinhSachNCCChung = "sp_BH_CSNCC_LOAISP_chung";
            public static string spBHChinhSachNCCNhom = "sp_BH_CSNCC_LOAISP_nhom";
            public static string spBHChinhSachNCCHang = "sp_BH_CSNCC_LOAISP_hang";
            public static string spBHChinhSachNCCModel = "sp_BH_CSNCC_LOAISP_model";
            #endregion

            #region tbl_bh_csncc_chitiet
            public static string spBHChiTietChinhSachNCCLoaiSPInsert = "sp_BH_CSNCC_CHITIET_insert";
            public static string spBHChiTietChinhSachNCCLoaiSPDelete = "sp_BH_CSNCC_CHITIET_delete";
            public static string spBHChiTietChinhSachNCCLoaiSPGetAll = "sp_BH_CSNCC_CHITIET_getAll";
            #endregion

            #region TBL_BH_CSNCC_NHAPLAI

            public static string spbhcsnccnhaplaiget = "sp_bh_csncc_nhaplai_get";
            #endregion
            #endregion

            #endregion
            #region Chinh sach gia
            #region tbl_BangGia
            public const string spBangGiaSelectAll = "sp_CS_BangGia_SelectAll";
            public const string spBangGiaSelectByNSD = "sp_CS_BangGia_SelectByNSD";
            public const string spBangGiaSearchByNSD = "sp_CS_BangGia_SearchByNSD";
            public const string spBangGiaSearchByNSDPg = "sp_CS_BangGia_SearchByNSDPg";
            public const string spBangGiaSelectAllChuaDuyet = "sp_CS_BangGia_SelectChuaDuyet";
            public const string spBangGiaGetNoDuyetByNND = "sp_CS_BangGia_GetNoDuyetByNND";
            public const string spBangGiaGetNoDuyetByNNDPg = "sp_CS_BangGia_GetNoDuyetByNDPg";
            public const string spBangGiaSelectById = "sp_CS_BangGia_SelectById";
            public const string spBangGiaGetBySoBangGia = "sp_CS_BangGia_GetBySoBangGia";
            public const string spBangGiaGetNoDuyetBySBG = "sp_CS_BangGia_GetNoDuyetBySBG";
            //public const string spBangGiaSelectByIdChiTiet = "sp_CS_BangGia_SelectByIdCTiet";
            public const string spBangGiaUpdateDuyet = "sp_CS_BangGia_UpdDuyet";
            public const string spBangGiaUpdate = "sp_CS_BangGia_UpdateLst";
            public const string spBangGiaInsert = "sp_CS_BangGia_InsertLst";
            public const string spBangGiaTTamInsert = "sp_CS_BangGia_InsertTT";
            public const string spBangGiaDelete = "sp_CS_BangGia_Delete";
            public const string spBangGiaTTamDelete = "sp_CS_BangGia_DeleteTT";
            public const string spBangGiaSearch = "sp_CS_BangGia_Search";
            public const string spBangGiaTimKiem = "sp_CS_BangGia_TimKiem";
            public const string spBangGiaTimKiemPg = "sp_CS_BangGia_TimKiemPg";
            public const string spBangGiaSearchChuaDuyet = "sp_CS_BangGia_SearchChuaDuyet";
            public const string spBangGiaSearchChuaDuyetPg = "sp_CS_BangGia_SearchNoDuyetPg";
            public const string spBangGiaDuyet = "sp_CS_BangGia_Duyet";
            public const string spBangGiaExist = "sp_CS_BangGia_Exist";
            public const string spBangGiaLoadGiaBan = "sp_CS_BangGia_LoadGiaBan";
            public const string spBangGiaLoadGiaBanByNSD = "sp_CS_BangGia_LoadGiaBanByNSD";
            public const string spBangGiaLoadGiaBanByOrg = "sp_CS_BangGia_LoadGiaBanByORG";
            public const string spBangGiaLoadBangGiaBan = "sp_CS_BangGia_LoadBangGiaBan";
            public const string spBangGiaLoadGiaTheoShop = "sp_CS_BangGia_LoadByShop";
            public const string spBangGiaLoadGiaSanPham = "sp_CS_BangGia_LoadGiaSanPham";
            public const string spBangGiaGetGiaBan = "sp_CS_BangGia_GetGiaBan";
            public const string spBangGiaGetGiaBanThoiGian = "sp_CS_BangGia_GetGiaBanQK";
            public const string spBangGiaGetBangGiaBan = "sp_CS_BangGia_GetBangGiaBan";
            public const string spBangGiaGetBangGiaBanTon = "sp_CS_BangGia_GetBangGiaBanTon";
            public const string spBangGiaGetBangGiaBanTonPg = "sp_CS_BangGia_GetBangGiaBanPg";
            public const string spBangGiaGetBangGiaBanTonOnline = "sp_CS_BangGia_GetBangGiaBanOnl";
            public const string spBangGiaGetSanPhamChuaCoGia = "sp_CS_BangGia_GetSPChuaCoGia";
            public const string spBangGiaGetCSachCKhauAD = "sp_CS_BangGia_GetChietKhauAD";
            public const string spBangGiaGetChinhSachAD = "sp_CS_BangGia_GetChinhSachAD";
            public const string spBangGiaGetChinhSachAll = "sp_CS_BangGia_GetChinhSachAll";
            public const string spBangGiaGetChinhSachDaAD = "sp_CS_BangGia_GetChinhSachDaAD";
            public const string spBangGiaGetChinhSachGiaBan = "sp_BCCS_CHINHSACHGIA_CTIET";
            public const string spBangGiaGetChinhSachGiaBanPg = "sp_BCCS_CHINHSACHGIA_CTIETPg2";
            public const string spBangGiaGetMatHangKhongApDung = "sp_BCCS_GetMHangKhongAD";
            #endregion

            #region tbl_BangGia_ChinhSach
            public const string spBangGiaChinhSachSelectAll = "sp_CS_BangGia_CSach_SelectAll";
            public const string spBangGiaChinhSachGetByNSD = "sp_CS_BangGia_CSach_GetByNSD";
            public const string spBangGiaChinhSachGetByIdDKMua = "sp_CS_BangGia_CSach_GetByDKM";
            public const string spBangGiaChinhSachGetByNSDTT = "sp_CS_BangGia_CSach_GetByNSDTT";
            public const string spBangGiaChinhSachGetById = "sp_CS_BangGia_CSach_GetById";
            public const string spBangGiaChinhSachUpdate = "sp_CS_BangGia_CSach_UpdT";
            public const string spBangGiaChinhSachInsert = "sp_CS_BangGia_CSach_InsT";
            public const string spBangGiaChinhSachNoDuyetUpdate = "sp_CS_BangGia_CSach_UpdNoAgree";
            public const string spBangGiaChinhSachNoDuyetInsert = "sp_CS_BangGia_CSach_InsNoAgree";

            public const string spBangGiaChinhSachDelete = "sp_CS_BangGia_CSach_Delete";
            public const string spBangGiaChinhSachExist = "sp_CS_BangGia_CSach_Exist";
            public const string spBangGiaChinhSachDuyet = "sp_CS_BangGia_CSach_Duyet";
            public const string spBangGiaChinhSachMacDinh = "sp_CS_BangGia_CSach_Default";
            public const string spBangGiaChinhSachTimKiem = "sp_CS_BangGia_CSach_TimKiem";
            public const string spBangGiaChinhSachNoDuyetPg = "sp_CS_BangGia_CSach_NoDuyetPg";
            public const string spBangGiaChinhSachTimKiemPg = "sp_CS_BangGia_CSach_TimKiemPg1";
            public const string spBangGiaChinhSachSearchPg = "sp_CS_BangGia_CSach_SearchPg";
            public const string spBangGiaChinhSachTongHop = "sp_BCCS_CHINHSACHGIA_TONGHOP";
            public const string spBangGiaChinhSachTongHopPg = "sp_BCCS_CHINHSACHGIA_TONGHOPPg";
            #endregion

            #region tbl_BangGia_ChinhSach_ChiTiet
            public const string spBangGiaCSachCTietLoad = "sp_CS_BangGia_CSachCTiet_Load";
            public const string spBangGiaCSachCTietInsert = "sp_CS_BangGia_CSachCTiet_Ins";
            public const string spBangGiaCSachCTietDelete = "sp_CS_BangGia_CSachCTiet_Del";
            #endregion

            #region tbl_BangGia_ChiTiet
            public const string spBangGiaChiTietSelect = "sp_CS_BangGia_ChiTiet_Select";
            public const string spBangGiaChiTietGetTon = "sp_CS_BangGia_ChiTiet_GetTon";
            public const string spBangGiaChiTietUpdate = "sp_CS_BangGia_ChiTiet_UpdateKM";
            public const string spBangGiaChiTietInsert = "sp_CS_BangGia_ChiTiet_InsertKM";
            public const string spBangGiaChiTietDelete = "sp_CS_BangGia_ChiTiet_Delete";
            public const string spBangGiaChiTietDuyet = "sp_CS_BangGia_ChiTiet_Duyet";
            public const string spBangGiaChiTietGetNoDuyet = "sp_CS_BangGia_ChiTiet_NoDuyet";
            public const string spBangGiaChiTietGetAllNoDuyet = "sp_CS_BangGia_GetAll_ChuaDuyet";
            public const string spBangGiaChiTietGetNhomDuyet = "sp_CS_BangGia_ChiTiet_GetDuyet";
            public const string spBangGiaChiTietUpdateNhomDuyet = "sp_CS_BangGia_ChiTiet_UDPDuyet";
            public const string spBangGiaInMaVach = "sp_CS_BangGia_ChiTiet_InMaVach";
            public const string spBangGiaInMaVachPg = "sp_CS_BangGia_ChiTiet_InMVPg";
            #endregion

            #region tbl_banggia_banhang_lichsu
            public const string spBangGiaBanHangLichSuSearch = "sp_CS_BangGia_BHang_LSu_Search";
            public const string spBangGiaBanHangLichSuSearchPg = "sp_CS_BangGia_BHang_LSu_SrcPg";
            public const string spBangGiaBanHangLichSuDelete = "sp_CS_BangGia_BHang_LSu_Delete";
            public const string spBangGiaBanHangLichSuDelAll = "sp_CS_BangGia_BHang_LSu_DelAll";
            public const string spBangGiaDongBoKhuyenMai = "sp_CS_BangGia_SyncKMai";
            public const string spBangGiaDongBoKhuyenMaiTTam = "sp_CS_BangGia_SyncKMaiTTam";
            #endregion

            #region tbl_tmp_gianhap
            public const string spBangGiaGiaNhapSelect = "sp_CS_BangGia_GiaNhap_Select";
            public const string spBangGiaGiaMinMaxSelect = "sp_CS_BangGia_GiaMinMax_Select";
            #endregion

            #region tbl_BangGia_ChinhSach_DKMua
            public const string spBangGiaChinhSachDKMuaSelect = "sp_CS_BangGia_CSach_DKMua_Get";
            public const string spBangGiaChinhSachDKMuaGetById = "sp_CS_BangGia_CSach_DKMua_ByID";
            public const string spBangGiaChinhSachDKMuaInsert = "sp_CS_BangGia_CSach_DKMua_Ins";
            public const string spBangGiaChinhSachDKMuaUpdate = "sp_CS_BangGia_CSach_DKMua_Upd";
            public const string spBangGiaChinhSachDKMuaDelete = "sp_CS_BangGia_CSach_DKMua_Del";
            #endregion

            #region tbl_KhuyenMai
            public const string spBangGiaKhuyenMaiSelect = "sp_CS_BangGia_KhuyenMai_Select";
            public const string spBangGiaKhuyenMaiUpdate = "sp_CS_BangGia_KhuyenMai_Update";
            public const string spBangGiaKhuyenMaiInsert = "sp_CS_BangGia_KhuyenMai_Insert";
            public const string spBangGiaKhuyenMaiDelete = "sp_CS_BangGia_KhuyenMai_Delete";
            public const string spBangGiaKhuyenMaiDelByDKM = "sp_CS_BangGia_KhuyenMai_DelDKM";
            public const string spBangGiaKhuyenMaiDelByCSG = "sp_CS_BangGia_KhuyenMai_DelCSG";
            public const string spBangGiaKhuyenMaiExist = "sp_CS_BangGia_KhuyenMai_Exist";
            public const string spBangGiaKhuyenMaiLoadSP = "sp_CS_BangGia_LoadKhuyenMai";
            public const string spBangGiaKhuyenMaiGetAD = "sp_CS_BangGia_GetKhuyenMaiAD";
            #endregion

            #region tbl_KhuyenMai_ChiTiet
            public const string spBangGiaKMChiTietSelect = "sp_CS_BangGia_KMChiTiet_Select";
            public const string spBangGiaKMChiTietUpdate = "sp_CS_BangGia_KMChiTiet_Update";
            public const string spBangGiaKMChiTietInsert = "sp_CS_BangGia_KMChiTiet_Insert";
            public const string spBangGiaKMChiTietDelete = "sp_CS_BangGia_KMChiTiet_Delete";
            //public const string spBangGiaKMChiTietDuyet = "sp_CS_BangGia_KMChiTiet_Duyet";
            public const string spBangGiaKMChiTietLoadSP = "sp_CS_BangGia_LoadKMaiChiTiet";
            public const string spBangGiaKMChiTietGetAD = "sp_CS_BangGia_GetKMChiTietAD";
            public const string spBangGiaKMChiTietGetADGia = "sp_CS_BangGia_GetKMCTietADGia";
            public const string spBangGiaKMChiTietGetADTTGia = "sp_CS_BangGia_GetKMCTietTTGia";
            public const string spBangGiaKMWebCTietGetADGia = "sp_CS_BangGia_GetKMCTietWeb";
            #endregion

            #region tbl_BangGia_ChiTiet_SPKem
            public const string spBangGiaChiTietSPKemApDung = "sp_CS_BangGia_GetSPKemAD";
            public const string spBangGiaChiTietSPKemSelect = "sp_CS_BangGia_CTiet_SPKem_Get";
            public const string spBangGiaChiTietSPKemInsert = "sp_CS_BangGia_CTiet_SPKem_InsG";
            public const string spBangGiaChiTietSPKemDelete = "sp_CS_BangGia_CTiet_SPKem_Del";
            #endregion

            #region tbl_BangGia_ChiTiet_SPDaMua
            public const string spBangGiaChiTietSPDaMuaSelect = "sp_CS_BangGia_CTiet_SPMua_Get";
            public const string spBangGiaChiTietSPDaMuaInsert = "sp_CS_BangGia_CTiet_SPMua_Ins";
            public const string spBangGiaChiTietSPDaMuaDelete = "sp_CS_BangGia_CTiet_SPMua_Del";
            #endregion

            #region tbl_BangGia_ChiTiet_SPNoAD
            public const string spBangGiaChiTietSPNoADSelect = "sp_CS_BangGia_CTiet_SPisAD_Get";
            public const string spBangGiaChiTietSPNoADInsert = "sp_CS_BangGia_CTiet_SPisAD_Ins";
            public const string spBangGiaChiTietSPNoADDelete = "sp_CS_BangGia_CTiet_SPNoAD_Del";
            #endregion

            #region tbl_BangGia_DoiTuong
            public const string spBangGiaDoiTuongLoad = "sp_CS_BangGia_DoiTuong_Load";
            public const string spBangGiaDoiTuongInsert = "sp_CS_BangGia_DoiTuong_Insert";
            public const string spBangGiaDoiTuongDelete = "sp_CS_BangGia_DoiTuong_Delete";
            #endregion

            #region tbl_BangGia_TrungTam
            public const string spBangGiaTrungTamLoad = "sp_CS_BangGia_TrungTam_Load";
            public const string spBangGiaTrungTamInsert = "sp_CS_BangGia_TrungTam_Insert";
            public const string spBangGiaTrungTamDelete = "sp_CS_BangGia_TrungTam_Delete";
            #endregion

            #region tbl_BangGia_ThoiGian
            public const string spBangGiaThoiGianLoad = "sp_CS_BangGia_ThoiGian_Load";
            public const string spBangGiaThoiGianInsert = "sp_CS_BangGia_ThoiGian_Insert";
            public const string spBangGiaThoiGianDelete = "sp_CS_BangGia_ThoiGian_Delete";
            #endregion

            #region tbl_BangGia_ThanhToan
            public const string spBangGiaThanhToanLoad = "sp_CS_BangGia_ThanhToan_Load";
            public const string spBangGiaThanhToanInsert = "sp_CS_BangGia_ThanhToan_Insert";
            public const string spBangGiaThanhToanDelete = "sp_CS_BangGia_ThanhToan_Delete";
            #endregion

            #region tbl_BangGia_ThamSo
            public const string spBangGiaThamSoUpdate = "sp_BangGia_ThamSo_Update";
            #endregion

            #region tbl_BangGia_ChiTiet_LichSu
            public const string spBangGiaChiTietLSSelect = "sp_CS_BangGia_ChiTietLS_Select";
            public const string spBangGiaChiTietLSDelete = "sp_CS_BangGia_ChiTietLS_Delete";
            public const string spBangGiaChiTietLSDelByCT = "sp_CS_BangGia_ChiTietLS_DelCT";
            #endregion

            #region tbl_banggia_khoang_diemthuong
            public const string spBangGiaDiemThuongGetDmuc = "sp_CS_BangGia_Khoang_DTh_Dmuc";
            public const string spBangGiaDiemThuongGetAll = "sp_CS_BangGia_Khoang_DTh_All";
            public const string spBangGiaDiemThuongUpdate = "sp_CS_BangGia_Khoang_DTh_Udp";
            public const string spBangGiaDiemThuongDelete = "sp_CS_BangGia_Khoang_DTh_Del";
            public const string spBangGiaDiemThuongCheck = "sp_CS_BangGia_Khoang_DTh_Chk";
            #endregion

            #endregion
            #region tbl_SuDung_HoaDon
            public const string spSuDungHoaDonGetByUser = "sp_CS_SuDung_HoaDon_GetByUser";
            public const string spSuDungHoaDonSrcByUser = "sp_CS_SuDung_HoaDon_SrcByUser";
            public const string spSuDungHoaDonSearchHD = "sp_CS_SuDung_HoaDon_SearchHD";
            public const string spSuDungHoaDonGetByKyHieu = "sp_CS_SuDung_HoaDon_GetByKHieu";
            public const string spSuDungHoaDonGetBySoHD = "sp_CS_SuDung_HoaDon_GetBySoHD";
            public const string spSuDungHoaDonGetBySoHoaDon = "sp_CS_SuDung_HoaDon_GetSoHDon";
            public const string spSuDungHoaDonGetBySDHoaDon = "sp_CS_SuDung_HoaDon_GetSDHDon";
            public const string spSuDungHoaDonGetEmpty = "sp_CS_SuDung_HoaDon_GetEmpty";
            public const string spSuDungHoaDonDelByUser = "sp_CS_SuDung_HoaDon_DelByUser";
            public const string spSuDungHoaDonInSert = "sp_CS_SuDung_HoaDon_InSert";
            public const string spSuDungHoaDonUpdate = "sp_CS_SuDung_HoaDon_Update1";
            public const string spSuDungHoaDonUpdNextSHD = "sp_CS_SuDung_HoaDon_UpdNextHD";
            public const string spSuDungHoaDonDelte = "sp_CS_SuDung_HoaDon_Delete";
            public const string spSuDungHoaDonValidHD = "sp_CS_SuDung_HoaDon_ValidHD1";
            public const string spSuDungHoaDonLoadInUsed = "sp_CS_SuDung_HoaDon_LoadInUsed";
            #endregion

            #region tbl_DM_NganHang
            public const string spNganHangDeleteTemp = "sp_DM_NganHang_001";
            public const string spNganHangGetLastUpdateDate = "sp_DM_NganHang_002";
            public const string spNganHangTransferData = "sp_DM_NganHang_003";
            public const string spNganHangGetTmpData = "sp_DM_NganHang_004";
            public const string spNganHangSelectAll = "sp_DM_NganHang_SelectAll";
            public const string spNganHangUpdate = "sp_DM_NganHang_Update";
            public const string spNganHangInsert = "sp_DM_NganHang_Insert";
            public const string spNganHangDelete = "sp_DM_NganHang_Delete";
            public const string spNganHangExist = "sp_DM_NganHang_Exist";
            public const string spNganHangSearch = "sp_DM_NganHang_Search";
            public const string spNganHangGetbyId = "sp_DM_NganHang_GetbyId";
            public const string spNganHangGetText = "sp_DM_NganHang_GetbyText";
            #endregion

            #region tbl_DM_TaiKhoanQuy
            public const string spTaiKhoanQuySelectAll = "sp_DM_TaiKhoanQuy_SelectAll";
            public const string spTaiKhoanQuySelectByTrungTam = "sp_DM_TaiKhoanQuy_GetByTTam";
            public const string spTaiKhoanQuyGetByText = "sp_DM_TaiKhoanQuy_GetByText";
            public const string spTaiKhoanQuyTMGetByTrungTam = "sp_TaiKhoanQuyTM_GetByTT";
            #endregion

            #region tbl_DM_VungMienKhach
            public const string spVungMienKhachSelectAll = "sp_DM_VungMienKhach_SelectAll";
            #endregion

            #region tbl_DM_PhuongTien_GiaoNhan
            public const string spPhuongTienGiaoNhanSelectAll = "sp_DM_PTien_GNhan_SelectAll";
            #endregion

            #region tbl_DM_Tinh
            public const string spTinhSelectAll = "sp_DM_Tinh_SelectAll";
            public const string spTinhSelectByText = "sp_DM_Tinh_SelectByText";
            public const string spTinhSelectById = "sp_DM_Tinh_SelectById";
            #endregion

            #region tbl_DM_Huyen
            public const string spHuyenSelectByTinh = "sp_DM_Huyen_SelectByTinh";
            public const string spHuyenSelectByText = "sp_DM_Huyen_SelectByTextTinh";
            public const string spHuyenSelectById = "sp_DM_Huyen_SelectById";
            #endregion


            #region tbl_DM_NgheNghiep
            public const string spNgheNghiepSelectAll = "sp_DM_NgheNghiep_SelectAll";
            #endregion

            #region tbl_DM_CaBanHang
            public const string spCaBanHangSelectAll = "sp_DM_CaBanHang_SelectAll";
            public const string spCaBanHangGetCurrent = "sp_DM_CaBanHang_GetCurrent";
            #endregion

            #region tbl_thuong_nhanvien_thangdiem
            public const string spThangDiemThuongNhanVienLoad = "sp_ThuongNVien_TDiem_LoadAll";
            public const string spThangDiemThuongNhanVienInsert = "sp_ThuongNVien_TDiem_Insert";
            public const string spThangDiemThuongNhanVienDelete = "sp_ThuongNVien_TDiem_DeleteAll";
            #endregion

            #region tbl_thuong_nhanvien_cachtinh
            public const string spCachTinhThuongNhanVienLoad = "sp_ThuongNVien_CTinh_LoadAll";
            public const string spCachTinhThuongNhanVienInsert = "sp_ThuongNVien_CTinh_Insert";
            public const string spCachTinhThuongNhanVienDelete = "sp_ThuongNVien_CTinh_DeleteAll";
            public const string spGetThuongNhanVienBySanPham = "sp_CS_BangGia_ThuongNV_BySPham";

            #endregion

            #region Bao Cao Chinh Sach Gia
            public const string spCSBCTinhTrangDonHang = "sp_CSBC_TinhTrangDonHang";
            public const string spCSBCTinhTrangBangGia = "sp_CSBC_TinhTrangBangGia";
            public const string spCSBCBangGiaChiTiet = "sp_CSBC_BangGiaChiTiet";
            public const string spCSBCChinhSachApDung = "sp_CSBC_ChinhSachApDung";
            public const string spCSBCLichSuThayDoiGia = "sp_CSBC_LichSuThayDoiGia";
            public const string spCSBCLichSuThayDoiGiaDetail = "sp_CSBC_LichSuThayDoiGiaDetail";
            #endregion


            #region Báo cáo chi tiết chuyển kho

            public const string sp_BC_LichSuNhapHang = "sp_BC_LichSuNhapHang";
            public const string sp_BC_ChiTietDieuChuyen = "sp_BC_ChiTietDieuChuyen";
            public const string sp_BC_ChiTietNhapDieuChuyen = "sp_BC_ChiTietNhapDieuChuyen1";
            public const string sp_BC_TongHopDieuChuyen = "sp_BC_TongHopDieuChuyen1";
            public const string sp_BC_TongHopNhapDieuChuyen = "sp_BC_TongHopNhapDieuChuyen1";

            public const string sp_BC_PhieuDieuChuyenChoNhan = "sp_BC_DieuChuyenChoNhan";

            public const string sp_GetChungTuXuatDieuChuyenBySoChungTu = "sp_GetInfoDNDCBySoChungTu";
            public const string sp_GetChungTuXuatDieuChuyenById = "sp_GetInfoDNDCByIdChungTu1";
            public const string sp_GetInfoDNNDCByIdChungtu = "sp_GetInfoDNNDCByIdChungTu";
            #endregion
            #region Báo cáo chi tiết kiểm kê
            public const string sp_BC_TongHopKiemKe = "sp_BC_TongHopKiemKe";
            public const string sp_BC_KiemKeTonKho = "sp_BC_KiemKeTonKho";
            public const string sp_BC_KiemKeTonMaVach = "sp_BC_KiemKeTonMaVach";
            public const string sp_BC_KiemKeMaVachBanNhieuLan = "sp_BC_KiemKeMaVachBanNhieuLan";
            public const string sp_BC_DanhSachPhieuKiemKe = "sp_BC_DanhSachPhieuKiemKe";
            #endregion
            #region Báo cáo tiêu hao

            public const string sp_BC_ChiTietXuatTieuHao = "sp_BC_ChiTietXuatTieuHao";
            public const string sp_BC_ChiTietNhapTieuHao = "sp_BC_ChiTietNhapTieuHao";
            public const string sp_BC_TongHopXuatTieuHao = "sp_BC_TongHopXuatTieuHao";
            public const string sp_BC_TongHopNhapTieuHao = "sp_BC_TongHopNhapTieuHao";
            #endregion

            #region Biểu mẫu - Báo cáo
            public const string spPhieuXuatTieuHao = "GetPhieuXuatTieuHaoDetail";
            public const string spPhieuNhapNCC = "GetPhieuNhapNCCDetail1";
            public const string spPhieuTraNCC = "GetPhieuTraNCCDetail";
            public const string spPhieuTraNCC_TH = "GetPhieuTraNCC_TH_Detail";
            public const string spInPhieuDNXuatTieuHao = "GetInPhieuDNXuatTieuHao";
            public const string spPhieuDeNghiDeTail = "GetBCPhieuDeNghiDetail";
            public const string spPhieuTieuHaoDeTail = "sp_GetDeNghiTieuHaoDetail";
            public const string spPhieuBaoCaoDieuChuyen = "sp_GetPhieuBaoCaoDieuChuyen";
            public const string spPhieuXuatNhanDetail = "GetBCPhieuXuatNhanDetail";
            public const string spPhieuXuatDieuChuyen = "GetBCPhieuXuatDieuChuyenDetail";
            public const string spDieuChuyenCheckChanged = "sp_DieuChuyen_CheckChanged1";
            public const string spPhieuNhapPOTongHop = "GetPhieuNhapPOTongHop1";
            public const string spInPhieuKiemKe = "sp_GetBaoCaoInPhieuKiemKe";
            #endregion

            #region Nhập trả hàng khách mua

            public static string spChungTuNhapTraHangMuaGetByPX = "sp_CTNhapTraHangMua_GetByPX";
            public static string spChungTuNhapTraHangLaiMuaGetByPX = "sp_CTNhapTraLaiHangMua_GetByPX";
            public static string spChungTuNhapTraHangMuaGetByPN = "sp_CTNhapTraHangMua_GetByPN";
            public static string spChungTuNhapTraHangMuaGetByMaVach = "sp_CTNhapTraHM_GetByMaVach";
            public static string spChungTuNhapTraHangMuaGetByMaVachKM = "sp_CTNhapTraHM_GetByKM";
            public static string spChungTuNhapTraHangGetChiTiet = "sp_CTNhapTraHM_GetChiTiet";
            public static string spChungTuNhapTraHangGetChiTietDN = "sp_CTNhapTraHM_GetChiTietDN";
            public static string spChungTuNhapTraHangInsertChiTiet = "sp_CTNhapTraHM_InsertChiTiet";
            public static string spChungTuNhapTraHangMuaGetByPXGoc = "sp_CTNhapTraHangMua_GetByPXGoc";
            public static string spChungTuNhapTraHangMuaGetAll = "sp_CTNhapTraHangMua_GetAll";
            public static string spChungTuNhapTraHangMuaGetDoiMaPg = "sp_CTNhapTraHangMua_GetDMaPg";
            public static string spChungTuNhapTraHangMuaGetXNDoiMaPg = "sp_CTNhapTraHangMua_GetXNDMaPg";
            public static string spChungTuNhapTraHangMuaGetAllPg = "sp_CTNhapTraHangMua_GetAllPg1";
            public static string spChungTuNhapTraHangMuaGetAllKT = "sp_CTNhapTraHangMua_GetAllKT";
            public static string spChungTuNhapTraHangMuaGetAllKTPg = "sp_CTNhapTraHangMua_GetAlKTPg1";
            public static string spChungTuNhapTraHangMuaGetAllChiTien = "sp_CTNhapTraHangMua_GetChiTien";
            public static string spChungTuNhapTraHangMuaGetAllChiTienPg = "sp_CTNhapTraHangMua_GetPChiPg";

            #endregion

            #region Đổi mã
            public static string spChungTuDoiHangMuaGetByPX = "sp_CTNhapTraHangMua_GetByPX";
            public static string spChungTuDoiHangMuaGetByPN = "sp_CTNhapTraHangMua_GetByPN";
            public static string spChungTuDoiHangMuaGetByPXGoc = "sp_CTNhapTraHangMua_GetByPXGoc";
            public static string spChungTuDoiHangGetChiTietDN = "sp_CTDoiHM_GetChiTietDN";
            public const string spChungTuDoiMaHHDelete = "sp_BH_ChungTuDoiMaHH_Delete";
            public const string spChungTuDoiMaHHGetInfor = "sp_BH_ChungTuDoiMaHH_GetInfor";
            public const string spChungTuDoiMaHHUpdate = "sp_BH_ChungTuDoiMaHHKho_Update";
            public const string spChungTuDoiMaGocUpdate = "sp_BH_ChungTuDoiMaDHGoc_Update";
            public const string spChungTuDoiMaVachDHGocUpdate = "sp_BH_ChungTuDMaMVDHGoc_Update";
            public static string spChungTuDoiHangGetChiTietXN = "sp_CTDoiHM_GetChiTietXN";
            public static string spChungTuGetIdKhoDoiHang = "sp_CTDoiHM_GetIdKhoDoiMa";
            #endregion

            #region Nhật ký người dùng
            public static string spNhatKyNguoiDungDelete = "sp_NhatKy_NguoiDung_Delete";
            public static string spNhatKyNguoiDungSearch = "sp_NhatKy_NguoiDung_Search";

            #endregion

            #region Đổi linh kiện lỗi
            public const string spDoiLinhKienLoi_GetListThanhPham = "sp_DLKL_GetListThanhPham";
            public const string spDoiLinhKienLoi_GetDonHangBan = "sp_DLKL_GetDonHangBan";
            public const string spDoiLinhKienLoi_GetLinhKienLoi = "sp_DLKL_GetLinhKienLoi";
            public const string spDoiLinhKienLoi_GetLinhKienMoi = "sp_DLKL_GetLinhKienMoi";
            public static string spDoiLinhKienLoi_UpdatePhieuXLK = "sp_DLKL_UpdatePhieuXLK";
            public static string spDoiLinhKienLoi_GetSoPhieuXLK = "sp_DLKL_GetSoPhieuXLK";
            public static string spDoiLinhKienLoi_UpdateChungTu = "sp_DLKL_UpdateChungTu";
            public static string spDoiLinhKienLoi_InsertChungTu = "sp_DLKL_InsertChungTu1";
            public static string spDoiLinhKienLoi_DeleteChungTu = "sp_DLKL_DeleteChungTu";
            public static string spDoiLinhKienLoi_GetListChiTietChungTu = "sp_DLKL_GetListCTietCTu";
            public static string spDoiLinhKienLoi_InsertChiTietChungTu = "sp_DLKL_InsertCTietCTu";
            public static string spDoiLinhKienLoi_DeleteChiTietChungTu = "sp_DLKL_DeleteCTietCTu";
            public static string spDoiLinhKienLoi_UpdateChiTietChungTu = "sp_DLKL_UpdateCTietCTu";
            public static string spDoiLinhKienLoi_GetListChiTietHangHoa = "sp_DLKL_GetListCTietHHoa";
            public static string spDoiLinhKienLoi_DeleteChiTietHangHoa = "sp_DLKL_DeleteCTietHHoa";
            public static string spDoiLinhKienLoi_InsertChiTietHangHoa = "sp_DLKL_InsertCTietHHoa";
            public static string spDoiLinhKienLoi_UpdateChiTietHangHoa = "sp_DLKL_UpdateCTietHHoa";
            public static string spTonTrungChuyenGetList = "sp_TonTrungChuyen_GetList";
            public static string spKhoIdPhieuNhapMuaCuoi = "sp_GetIdPhieuNhapMuaCuoi";
            public static string spPhieuNhanDieuChuyenExisted = "sp_PhieuNhanDieuChuyenExisted1";
            public static string spGetListGiaoDichKhongDongBo = "sp_GetListGDKhongDB";
            public static string spBHGetIdPhieuNhapLanCuoi = "sp_BH_GetIdPhieuNhapCuoi";
            public static string spDangCoPhieuDieuChuyenChoNhanSerial = "sp_Kho_CoPhieuDCChoNhanSerial";
            public static string spGetLichSuGia = "sp_GetLichSuGia";
            public static string spGetLichSuThayDoiGia = "sp_GetLichSuThayDoiGia";

            #endregion

            #region Quản lý thẻ
            // Loại  Thẻ
            public const string sp_QLT_LoaiThe_Insert = "sp_QLT_LoaiThe_Insert";
            public const string sp_QLT_LoaiThe_Update = "sp_QLT_LoaiThe_Update";
            public const string sp_QLT_LoaiThe_GetAll = "sp_QLT_LoaiThe_GetAll";
            public const string sp_QLT_LoaiThe_GetAllloaithe = "sp_QLT_LoaiThe_GetAllloaithe";
            public const string sp_QLT_LoaiThe_Delete = "sp_QLT_LoaiThe_Delete";


            //Thẻ khách hàng
            public const string sp_QLT_TheKhachHang_GetAll = "sp_QLT_TheKhachHang_GetAll";
            public const string SP_QLT_THEKHACHHANG_INSERT = "SP_QLT_THEKHACHHANG_INSERT";
            public const string SP_QLT_THEKHACHHANG_UPDATE = "SP_QLT_THEKHACHHANG_UPDATE";
            public const string SP_QLT_THEKHACHHANG_DELETE = "SP_QLT_THEKHACHHANG_DELETE";
            public const string SP_QLT_KHACHHANG_GETALL = "SP_QLT_KHACHHANG_GETALL";
            public const string SP_QLT_KHACHHANG_INSERT = "SP_QLT_KHACHHANG_INSERT";



            #endregion

            #region Báo cáo công nợ bán hàng
            public static string spCongNoPosAr0400 = "sp_CongNoPosAr0400";
            #endregion



            #region PhongTQ sử dụng cho CRM
            // Suport Project CRM.SuportKnowLedge 
            // Người tạo : PhongTQ
            // Ngày Tạo : 17-1-2015

            public const string spSuportGetAllBaiViet = "crm.sp_tt_BaiViet_GetAllBaiViet";
            public const string spSuportSearch = "crm.sp_tt_BaiViet_Search";
            public const string spSuportInsert = "crm.sp_tt_baiviet_insert";
            public const string spSuportDelete = "crm.sp_tt_BaiViet_Delete";
            public const string spSuportUpDate = "crm.sp_tt_BaiViet_UpDate";
            public const string spBaiVietWriteTag = "crm.sp_BaiViet_WriteTag";
            public const string spTagUpDate = "crm.sp_Tag_UpDate";
            public const string spSuportGetTagByBaiVietId = "crm.sp_tt_BaiViet_LoadAllTag";
            public const string spTagDeleteTagFromTagBaiViet = "crm.sp_Tag_DeleteTagFromTagBaiViet";


            // Sử dụng cho form tra cứu 
            // Người Tạo : PhongTQ,
            // Ngày Tạo : 10/2/2015
            public const string SpCRTNYCSelectAll = "crm.Sp_CR_TNYC_SelectAll";
            //public const string SpCRTNYCGetYeuCauByIdYeuCau="Sp_CR_TNYC_GetYeuCauByIDYeuCau";
            //public const string spcrTNYCGetKHByDT = "crm.sp_cr_TNYC_GetKHByDT";
            public const string spCRTNYCSearch = "crm.sp_CR_TNYC_Search";
           // public const string Sp_TN_SelectAllYc = "crm.Sp_TN_SelectAllYc";
            // public const string spCRTNYCInsertDoiTuong = "crm.sp_CR_TNYC_InsertDoiTuong";
            public const string spCRTNYCDelete = "crm.sp_CR_TNYC_Delete";
            public const string sp_cr_TNYC_DeleteYCGoc = "crm.sp_cr_TNYC_DeleteYCGoc";
            //  public const string spCRTNYCInsertYeuCau = "crm.sp_CR_TNYC_InsertYeuCau";
            // public const string spCRTNYCInsert = "crm.sp_CR_TNYC_Insert";
            // public const string spDMDOITUONGEXITS = "crm.SP_DM_DOITUONG_EXITS";
            public const string SpCRTNYCInSertYCWithIdDT1 = "crm.Sp_CR_TNYC_InsertYCWithIdDT1";
            public const string SpCRTNYCInSertYCWithIdDT2 = "crm.Sp_CR_TNYC_InsertYCWithIdDT2";
            //  public const string SPDMDoiTuongSearchByPhone = "crm.SP_DM_DoiTuong_SearchByPhone";
            //public const string SpDMDoiTuongUpDate = "crm.Sp_DM_DoiTuong_Update";
            // public const string SpDMDoiTuongMaDoiTuong =  "crm.SP_DM_DoiTuong_MaDoiTuong";
            // public const string SpDmDoiTuongCheckMaRieng = "crm.SP_DM_DoiTuong_CheckMaRieng";
            public const string spCRTNYCSearchByPhone = "crm.sp_CR_TNYC_SearchByPhone";
            public const string SPChungTuGetInfor = "crm.SP_ChungTu_GetInfor";
            public const string SPChungTuDoiTuongExits = "SP_ChungTu_DoiTuong_Exits";
            public const string SpBHGetInfor = "crm.Sp_BH_GetInfor";

            public const string SpCRXuLyInsertTuChoiXuLy = "crm.Sp_CR_XuLY_InsertTuChoiXuLy";

            // sử dụng cho form danh mục lý do
            public const string SpDmLyDoTiepNhanSelectAll = "crm.Sp_DmLyDoTiepNhan_SelectAll";
            public const string SpDmLyDoTiepNhanSearch = "crm.Sp_DmLyDoTiepNhan_Search";
            public const string SpDmLyDoTiepNhanDelete = "crm.Sp_DmLyDoTiepNhan_Delete";
            public const string SpDmLyDoTiepNhanSelectLDById="crm.Sp_DmLyDoTiepNhan_SelectLDById";
            public const string SpDmLyDoTiepNhanInsert = "crm.Sp_DmLyDoTiepNhan_Insert";
            public const string SpDmLyDoTiepNhanUpDate = "crm.Sp_DmLyDoTiepNhan_UpDate";

            // sử dụng cho lock yêu cầu
            public const string SPCRTNYCUPDATELOCK = "crm.SP_CR_TNYC_UpdateLock";
            public const string SPCRTNYCCheckKhoaYeuCau = "crm.SP_CR_TNYC_CheckKhoaYeuCau";

            // log cuộc gọi
            public const string sp_log_cuocgoi = "crm.sp_log_cuocgoi";
          

            // PhongTQ sử dụng cho form Yêu Cầu Chờ Xử Lý
            public const string SPCRXuLyLoadYeuCauChoXuLy = "crm.SP_CR_XuLy_LoadYeuCauChoXuLy";
            public const string SPCRXuLyUpDateTrangThaiYC  ="crm.Sp_CR_XuLy_UpDateTrangThaiYC";
            public const string SpYeuCauPhanCongExits     = "crm.SP_YeuCau_PhanCong_Exits";
            public const string Sp_CR_XuLy_UpDateXacNhan = "crm.Sp_CR_XuLy_UpDateXacNhan";
           
            public const string SpCRXyLyInsertXacNhan    = "crm.Sp_CR_XuLy_InsertXacNhan";
            // Sử dụng cho form chi tiết xử lý
            public const string SpCRXuLyLoadXuLyByIdYC   = "crm.Sp_CR_XuLy_LoadXuLyByIdYC";
            public const string SpCRXuLyInsert           = "crm.Sp_CR_XuLy_Insert";
            public const string Sp_CR_XuLy_InsertCallOut = "crm.Sp_CR_XuLy_InsertCallOut";
            public const string Sp_CR_XuLy_UpDateNhanVienCS = "crm.Sp_CR_XuLy_UpDateNhanVienCS";
            public const string Sp_CR_XuLy_UpDateHoanThanh = "crm.Sp_CR_XuLy_UpDateHoanThanh";   

            // sử dụng cho form chi tiết chuyển 
            public const string Sp_CR_XuLy_InsertNhanLuc = "crm.Sp_CR_XuLy_InsertNhanLuc";


            // sử dụng cho tổng hợp yêu cầu 
            public const string Sp_TheoDoi_TongHopYC = "crm.Sp_TheoDoi_TongHopYC";
            public const string Sp_TheoDoi_CheckTongHop_Exits = "crm.Sp_TheoDoi_CheckTongHop_Exits";
            public const string sp_TheoDoi_LoadDS_ByTThaiYc = "crm.sp_TheoDoi_LoadDS_ByTThaiYc";
            public const string Sp_TheoDoi_LoadDSByIdYCGoc = "crm.Sp_TheoDoi_LoadDSByIdYCGoc";
            
            // sử dụng cho Modules Custormer Care
            public const string Sp_CC_LoadDSNoKMChuaPC = "crm.Sp_CC_LoadDSNoKMChuaPC";
            public const string Sp_CC_LoadDanhSachNoKM = "crm.Sp_CC_LoadDanhSachNoKM";
            public const string Sp_CC_InsertPhanCong = "crm.Sp_CC_InsertPhanCong";
            public const string Sp_CC_CheckPhanCong = "crm.Sp_CC_CheckPhanCong";
            public const string sp_CC_PhanCongLai = "crm.sp_CC_PhanCongLai";
            public const string sp_CC_TenNVwithIDNhanVien = "crm.sp_CC_TenNVwithIDNhanVien";
            public const string Sp_CC_LoadDSPCNoKM = "crm.Sp_CC_LoadDSPCNoKM";
            public const string Sp_CC_UpdateLoaiNoKM = "crm.Sp_CC_UpdateLoaiNoKM";
            public const string Sp_CC_DeNghiDieuChuyenInsertCT = "crm.Sp_CC_DeNghiDieuChuyenInsertCT";
            public const string Sp_CC_DeNghiDieuChuyenInsert = "crm.Sp_CC_DeNghiDieuChuyenInsert";
            public const string Sp_CC_DeNghieDieuChuyenUpDate = "crm.Sp_CC_DeNghieDieuChuyenUpDate";
            public const string Sp_CC_LoadPhieuDNDC = "crm.Sp_CC_LoadPhieuDNDC";


            // đợtkhảo sát 
            public const string Sp_CC_KichBanGoi_SearchDotKS = "crm.Sp_CC_KichBanGoi_SearchDotKS";
            public const string Sp_CC_KichBanGoi_DotKSDelete = "crm.Sp_CC_KichBanGoi_DotKSDelete";
            public const string SP_CC_KichBanGoi_DotKSInsert = "crm.SP_CC_KichBanGoi_DotKSInsert";
            public const string Sp_CC_KichBanGoi_CTDotKSInsert = "crm. Sp_CC_KichBanGoi_CTDotKSInsert";
            public const string SP_CC_KichBanGoi_PCDotKS = "crm.SP_CC_KichBanGoi_PCDotKS";
            public const string Sp_CC_KichBanGoi_UpdatePCKS = "crm.Sp_CC_KichBanGoi_UpdatePCKS";
            public const string Sp_Cc_KichBanGoi_LoadPhanCong = "crm.Sp_Cc_KichBanGoi_LoadPhanCong";
            public const string Sp_CC_KichBanGoi_LoadDotKSById = "crm.Sp_CC_KichBanGoi_LoadDotKSById";
            public const string Sp_CC_KichBanGoi_DotKSInfor = "crm.Sp_CC_KichBanGoi_DotKSInfor";
            public const string Sp_CC_KichBanGoi_ExitsIdDotKS = "crm.Sp_CC_KichBanGoi_ExitsIdDotKS";
            public const string Sp_CC_KichBanGoi_UpdateDotKS = "crm.Sp_CC_KichBanGoi_UpdateDotKS";

            public const string Sp_CC_KichBanGoi_DSDotKSTH = "crm.Sp_CC_KichBanGoi_DSDotKSTH";
            public const string Sp_Cc_KichBanGoi_CTIdDotKS = "crm.Sp_Cc_KichBanGoi_CTIdDotKS";

            // update thời gian bắt đầu khảo sát
            public const string Sp_CC_KichBanGoi_TimeStart = "crm.Sp_CC_KichBanGoi_TimeStart";
            // update trạng thái đợt khảo sát
            public const string Sp_CC_KichBanGoi_TTDotKS = "crm.Sp_CC_KichBanGoi_TTDotKS";
            // xóa điện thoại khong liên lạc được khỏi đợt khảo sát
            public const string Sp_CC_KichBanGoi_DeltePhone = "crm.Sp_CC_KichBanGoi_DeltePhone";
            // load danh sách số điện thoại cần khảo sát trong kịch bản
            public const string Sp_CC_KichBanGoi_ListPhoneKS = "crm.Sp_CC_KichBanGoi_ListPhoneKS";
            // load danh sách số điện thoại trong kết quả
            public const string Sp_CC_KichBanGoi_ListPhoneKQ = "crm.Sp_CC_KichBanGoi_ListPhoneKQ";

            // kịch bản gọi 
               // load số lượng câu hỏi của kịch bản trong đợt khảo sát có trong bảng kết quả
            public const string SP_CC_KICHBANGOI_CAUHOICOUNT = "crm.SP_CC_KICHBANGOI_CAUHOICOUNT";
               //
               // update lại trạng thái cuộc gọi 
            public const string Sp_CC_KichBanGoi_CallUpdate = "crm.Sp_CC_KichBanGoi_CallUpdate";
              //

            public const string Sp_CS_KichBanLoadDataSource = "crm.Sp_CS_KichBanLoadDataSource";
            public const string Sp_CS_KichBanSearchByTen = "crm.Sp_CS_KichBanSearchByTen";
            public const string Sp_Cs_KichBanGoi_Delete = "crm.Sp_Cs_KichBanGoi_Delete";
            public const string Sp_CS_KichBanGoiUpdate = "crm.Sp_CS_KichBanGoiUpdate";
            public const string Sp_CS_GetCaHoiByIdKichBan = "crm.Sp_CS_GetCaHoiByIdKichBan";
            public const string Sp_CS_UpdateCHByIdCH = "crm.Sp_CS_UpdateCHByIdCH";
            public const string Sp_Cs_LoadPhuongAnByCH = "crm.Sp_Cs_LoadPhuongAnByCH";
            public const string Sp_Cs_UpdatePA = "crm.Sp_Cs_UpdatePA";
            public const string Sp_CC_KichBanGoi_InsertKichBan = "crm.Sp_CC_KichBanGoi_InsertKichBan";
            public const string Sp_KichBan_InsertCauHoi = "crm.Sp_KichBan_InsertCauHoi";
            public const string Sp_CC_KichBan_choseIDCauHoiMin = "crm.Sp_CC_KichBan_choseIDCauHoiMin";
            public const string Sp_CC_KichBanGoi_InsertPA = "crm.Sp_CC_KichBanGoi_InsertPA";
            public const string Sp_CC_KichBanGoi_UpdateIdKB = "crm.Sp_CC_KichBanGoi_UpdateIdKB";
            public const string Sp_Cc_KichBanGoi_UpDateIdCH = "crm.Sp_Cc_KichBanGoi_UpDateIdCH";

            //xóa
            public const string Sp_KichBanGoi_DeleteCH = "crm.Sp_KichBanGoi_DeleteCH";

            public const string sp_Cc_KichBan_selectAllCauHoi = "crm.sp_Cc_KichBan_selectAllCauHoi";
            public const string Sp_CC_KichBanGoi_SelectAll = "crm.Sp_CC_KichBanGoi_SelectAll";
            public const string Sp_CC_KichBanGoi_GetKBById = "crm.Sp_CC_KichBanGoi_GetKBById";
            public const string Sp_Cc_KichBanGoi_Search = "crm.Sp_Cc_KichBanGoi_Search";
            public const string Sp_CC_KichBanGoi_InsertKQCH = "crm.Sp_CC_KichBanGoi_InsertKQCH";
            public const string Sp_CC_KichBanGoi_DeletePA = "crm.Sp_CC_KichBanGoi_DeletePA";
            public const string Sp_Cc_KichBanGoi_UpdatePA = "crm.Sp_Cc_KichBanGoi_UpdatePA";
            public const string Sp_CC_KichBanGoi_InsertPAKhac = "crm.Sp_CC_KichBanGoi_InsertPAKhac";
            public const string Sp_CC_KichBanGoi_InsertKQKhac = "crm.Sp_CC_KichBanGoi_InsertKQKhac";
            public const string sp_CC_KichBanGoi_InsertChPhu = "crm.sp_CC_KichBanGoi_InsertChPhu";
            public const string Sp_CC_KichBanGoi_UpDateLoaiCH = "crm.Sp_CC_KichBanGoi_UpDateLoaiCH";
            public const string Sp_CC_KichBanGoi_BaoCao = "crm.Sp_CC_KichBanGoi_BaoCao";
            public const string Sp_Cc_KichBanGoi_LoadLoaiCH = "crm.Sp_Cc_KichBanGoi_LoadLoaiCH";
            

            // Load ra những câu hỏi chưa hỏi với trường hợp đang xử lý
            public const string Sp_CC_KichBanGoi_Search2 = "crm.Sp_CC_KichBanGoi_Search2";

            // danh sách điện thoại cần khảo sát
            public const string Sp_KichBanGoi_ListPhoneChungTu = "crm.Sp_KichBanGoi_ListPhoneChungTu";
            public const string Sp_KichBanGoi_DSDTBaoHanh = "crm.Sp_KichBanGoi_DSDTBaoHanh";

            // lấy số điện thoại ra từ bảng gần nhất 
            public const string Sp_CC_KichBanGoi_XacDinhSoDT = "crm.Sp_CC_KichBanGoi_XacDinhSoDT";

            // trường hợp câu hỏi chỉ được chọn 1 phương án check idcauhoi trong bảng kết quả
            public const string Sp_CC_KichBanGoi_CheckCH = "crm.Sp_CC_KichBanGoi_CheckCH";
            // trường hợp số điện thoại ko liên lạc được
            public const string Sp_CC_KichBanGoi_CallFail = "crm.Sp_CC_KichBanGoi_CallFail";

            // phân công chăm sóc cuộc gọi

            public const string Sp_CC_KichBanGoi_CTPhanCong = "crm.Sp_CC_KichBanGoi_CTPhanCong";
            public const string Sp_CC_KichBanGoi_DSPhanCong = "crm.Sp_CC_KichBanGoi_DSPhanCong";

            public const string Sp_CC_KichBanGoi_BaoCaoTH = "crm.Sp_CC_KichBanGoi_BaoCaoTH";



            // đánh giá điện thoại
            public const string sp_CS_DANHGIA_LISTPHONEKHMUA = "crm.sp_CS_DANHGIA_LISTPHONEKHMUA";
            public const string Sp_CS_DanhGia_InserInfor = "crm.Sp_CS_DanhGia_InserInfor";
            public const string Sp_CS_DanhGia_PhanCong = "crm.Sp_CS_DanhGia_PhanCong";
            public const string Sp_CS_DanhGia_LoadDotDanhGia = "crm.Sp_CS_DanhGia_LoadDotDanhGia";
            public const string Sp_CS_DanhGia_Delete = "crm.Sp_CS_DanhGia_Delete";
            public const string Sp_Cc_DanhGia_LoadById = "crm.Sp_Cc_DanhGia_LoadById";
            public const string Sp_CC_DanhGia_KhaoSat = "crm.Sp_CC_DanhGia_KhaoSat";
            public const string Sp_CC_DanhGia_Callfaild = "crm.Sp_CC_DanhGia_Callfaild";
            public const string Sp_CC_DANHGIA_TTDotDanhGia = "crm.Sp_CC_DANHGIA_TTDotDanhGia";
            public const string Sp_CC_DANHGIA_LOADDSCUOCGOI = "crm.Sp_CC_DANHGIA_LOADDSCUOCGOI";
            public const string Sp_CC_DanhGia_CheckMaDanhGia = "crm.Sp_CC_DanhGia_CheckMaDanhGia";

            #endregion




            #region Huy sử dụng cho Support

            public const string LoadAllDMLoaiBaiViet = "crm.sp_Load_DMLoaiBaiViet";
            public const string LoadDMLoaiBaiVietChiTiet = "crm.sp_Load_DMLoaiBaiVietChiTiet";
            public const string InsertDMLoaiBaiViet = "crm.sp_Insert_DMLBaiViet";
            public const string UpdateDMLoaiBaiViet = "crm.sp_Update_DMLBaiViet";
            public const string DeleteDMLoaiBaiViet = "crm.sp_Delete_DMLoaiBaiViet";

            public const string SP_DM_TRUNGTAM_GETALL = "crm.Sp_DM_TrungTam_GetAll";
            public const string SP_DM_NHOMNGUOIDUNG_GETALL = "crm.Sp_DM_NhomNGuoiDung_GETALL";
            public const string SP_DMLYDOTIEPNHAN_GETALL = "crm.Sp_DM_LyDoTiepNhan_GETALL";
            public const string SP_DM_NHANVIEN_GETBYID = "crm.Sp_DM_NhanVien_GetById";
            public const string SP_TN_YEUCAU_UPDATE = "crm.Sp_TN_YeuCau_Update";
            public const string Sp_TN_YeuCau_GetAll = "crm.Sp_TN_YeuCau_GetAll";
            public const string SP_TN_YEUCAU_GETBYID = "crm.Sp_TN_YeuCau_GetById";
            public const string SP_TN_YEUCAU_INSERT = "crm.Sp_TN_YeuCau_Insert";
            public const string Sp_TN_YeuCau_Exits = "crm.Sp_TN_YeuCau_Exits";
            public const string Sp_TN_YeuCau_Insert_TachYeuCau = "crm.Sp_TN_YeuCau_Insert_TachYeuCau";
            public const string Sp_TN_YeuCau_GetByIdGoc = "crm.Sp_TN_YeuCau_GetByIdGoc";
            public const string Sp_TN_LichSu_ChamSoc_Insert = "crm.Sp_TN_LichSu_ChamSoc_Insert";
            public const string Sp_TN_XuLy_GetAll = "crm.Sp_TN_XuLy_GetAll";
            public const string Sp_TN_LichSu_NhanLuc_Insert = "crm.Sp_TN_LichSu_NhanLuc_Insert";
            public const string Sp_TN_LichSu_NhanLuc_Update = "crm.Sp_TN_LichSu_NhanLuc_Update";
            public const string Sp_DM_NhanVien_GetById = "crm.Sp_DM_NhanVien_GetById";
            public const string Sp_TN_YeuCau_Search = "crm.Sp_TN_YeuCau_Search";
            public const string SP_LichSu_PhanCong = "crm.SP_LichSu_PhanCong";
            public const string Sp_TN_YeuCau_Update_NhanLuc = "crm.Sp_TN_YeuCau_Update_NhanLuc";
            #endregion


            #region Quan ly the

            #region Ho so khach hang
            public const string spHoSoKhachHangGetAll = "sp_QLThe_HSKH_GetAll";
            public const string spHoSoKhachHangUpdate = "sp_QLThe_HSKH_Update";
            public const string spHoSoKhachHangUpdateHDong = "sp_QLThe_HSKH_UpdateHDong";
            public const string spHoSoKhachHangInsert = "sp_QLThe_HSKH_Insert";
            public const string spHoSoKhachHangDelete = "sp_QLThe_HSKH_Delete";
            public const string spHoSoKhachHangExist = "sp_QLThe_HSKH_Exist";
            public const string spHoSoKhachHangCheckCode = "sp_QLThe_HSKH_CheckCode";
            public const string spHoSoKhachHangSearch = "sp_QLThe_HSKH_Search";
            public const string spHoSoKhachHangGetbyId = "sp_QLThe_HSKH_GetbyId";
            public const string spHoSoKhachHangGetPOS = "sp_QLThe_HSKH_GetPos";
            public const string spHoSoKhachHangGetOnline = "crm.sp_QLThe_HSKH_GetOnl";
            public const string spHoSoKhachHangLichSuGDich = "sp_QLThe_HSKH_LichSuGDich";
            public const string spHoSoKhachHangGDichDoiDiem = "sp_QLThe_HSKH_GiaoDichDoiDiem";
            public const string spHoSoKhachHangGDichBuTien = "sp_QLThe_HSKH_GiaoDichBuTien";
            #endregion

            #region DM loai the thanh vien
            public const string spDMLoaiTheThanhVienGetAll = "crm.sp_QLThe_DMLThe_GetAll";
            public const string spDMLoaiTheThanhVienGetSuDung = "crm.sp_QLThe_DMLThe_GetSuDung";
            public const string spDMLoaiTheThanhVienUpdate = "crm.sp_QLThe_DMLThe_Update";
            public const string spDMLoaiTheThanhVienUpdateHDong = "crm.sp_QLThe_DMLThe_UpdateHDong";
            public const string spDMLoaiTheThanhVienInsert = "crm.sp_QLThe_DMLThe_Insert";
            public const string spDMLoaiTheThanhVienDelete = "crm.sp_QLThe_DMLThe_Delete";
            public const string spDMLoaiTheThanhVienExist = "crm.sp_QLThe_DMLThe_Exist";
            public const string spDMLoaiTheThanhVienValid = "crm.sp_QLThe_DMLThe_Valid";
            public const string spDMLoaiTheThanhVienSearch = "crm.sp_QLThe_DMLThe_Search";
            public const string spDMLoaiTheThanhVienGetbyId = "crm.sp_QLThe_DMLThe_GetbyId";
            public const string spDMLoaiTheThanhVienGetbyText = "crm.sp_QLThe_DMLThe_GetbyTxt";
            public const string spDMLoaiTheThanhVienGetDefault = "crm.sp_QLThe_DMLThe_GetDefault";
            
            #endregion

            #region DM loai the thanh vien - san pham kem
            public const string spDMLoaiTheSPhamKemGetAll = "crm.sp_QLThe_LTSPKem_GetAll";
            public const string spDMLoaiTheSPhamKemUpdate = "crm.sp_QLThe_LTSPKem_Update";
            public const string spDMLoaiTheSPhamKemInsert = "crm.sp_QLThe_LTSPKem_Insert";
            public const string spDMLoaiTheSPhamKemDelete = "crm.sp_QLThe_LTSPKem_Delete";
            public const string spDMLoaiTheSPhamKemGetbyId = "crm.sp_QLThe_LTSPKem_GetbyId";
            public const string spDMLoaiTheSPhamKemGetbyLoaiThe = "crm.sp_QLThe_LTSPKem_GetbyLTh";
            public const string spDMLoaiTheSPhamKemDelbyLoaiThe = "crm.sp_QLThe_LTSPKem_DelbyLTh";
            #endregion

            #region DM loai the thanh vien - uu dai
            public const string spDMLoaiTheUuDaiGetAll = "crm.sp_QLThe_LTUuDai_GetAll";
            public const string spDMLoaiTheUuDaiUpdate = "crm.sp_QLThe_LTUuDai_Update";
            public const string spDMLoaiTheUuDaiInsert = "crm.sp_QLThe_LTUuDai_Insert";
            public const string spDMLoaiTheUuDaiDelete = "crm.sp_QLThe_LTUuDai_Delete";
            public const string spDMLoaiTheUuDaiGetbyId = "crm.sp_QLThe_LTUuDai_GetbyId";
            public const string spDMLoaiTheUuDaiGetbyLoaiThe = "crm.sp_QLThe_LTUuDai_GetbyLTh";
            public const string spDMLoaiTheUuDaiDelbyLoaiThe = "crm.sp_QLThe_LTUuDai_DelbyLTh";
            #endregion

            #region The thanh vien
            public const string spTheThanhVienGetAll = "crm.sp_QLThe_ThTV_GetAll";
            public const string spTheThanhVienUpdate = "crm.sp_QLThe_ThTV_Update";
            public const string spTheThanhVienUpdateHDong = "crm.sp_QLThe_ThTV_UpdateHDong";
            public const string spTheThanhVienInsert = "crm.sp_QLThe_ThTV_Insert";
            public const string spTheThanhVienDelete = "crm.sp_QLThe_ThTV_Delete";
            public const string spTheThanhVienExist = "crm.sp_QLThe_ThTV_Exist";
            public const string spTheThanhVienSearch = "crm.sp_QLThe_ThTV_Search";
            public const string spTheThanhVienSearchPg = "crm.sp_QLThe_ThTV_SearchPg";
            public const string spTheThanhVienBaoCaoPg = "crm.sp_QLThe_ThTV_BaoCaoPg";
            public const string spTheThanhVienThongKeThe = "crm.sp_QLThe_ThTV_BCThongKe";
            public const string spTheThanhVienTongHopDiemTichLuy = "crm.sp_QLThe_ThTV_BCTHopDTLuy";
            public const string spTheThanhVienTongHopTichDiemThe = "crm.sp_QLThe_ThTV_BCTHopTDThe";
            public const string spTheThanhVienSearchTheNangHang = "crm.sp_QLThe_ThTV_SrcTheNHang";
            public const string spTheThanhVienGetbyId = "crm.sp_QLThe_ThTV_GetbyId";
            public const string spTheThanhVienGetbyText = "crm.sp_QLThe_ThTV_GetbyText";
            public const string spTheThanhVienGetbyHoSo = "crm.sp_QLThe_ThTV_GetbyHSo";
            public const string spTheThanhVienDelbyHoSo = "crm.sp_QLThe_ThTV_DelbyHSo";
            public const string spTheThanhVienTichDiem = "crm.sp_QLThe_ThTV_TichDiemThe";
            public const string spTheThanhVienShowWeb = "crm.sp_QLThe_ThTV_ShowWeb";
            public const string spTheThanhVienTichDiemMua = "crm.sp_QLThe_ThTV_TichDiemMua";
            public const string spTheThanhVienTichDiemTra = "crm.sp_QLThe_ThTV_TichDiemTra";
            public const string spTheThanhVienTichDiemDung = "crm.sp_QLThe_ThTV_UdpDiemDung";
            public const string spTheThanhVienKiemTraTraLai = "crm.sp_QLThe_ThTV_KTraDHTraLai";
            public const string spTheThanhVienKiemTraTrcTraLai = "crm.sp_QLThe_ThTV_KTraTrcDHTraLai";
            #endregion

            #region He so doi diem
            public const string spHeSoDoiDiemGetAll = "crm.sp_QLThe_HSDD_GetAll";
            public const string spHeSoDoiDiemUpdate = "crm.sp_QLThe_HSDD_Update";
            public const string spHeSoDoiDiemDelete = "crm.sp_QLThe_HSDD_Delete";
            public const string spHeSoDoiDiemLoad = "crm.sp_QLThe_HSDD_Load";
            #endregion

            #region Cap nhat diem tich luy
            public const string spCapNhatDiemTichLuyGetAll = "crm.sp_QLThe_CNDTL_GetAll";
            public const string spCapNhatDiemTichLuyInsert = "crm.sp_QLThe_CNDTL_Insert";
            public const string spCapNhatDiemTichLuyUpdate = "crm.sp_QLThe_CNDTL_Update";
            public const string spCapNhatDiemTichLuyDelete = "crm.sp_QLThe_CNDTL_Delete";
            public const string spCapNhatDiemTichLuyDuyet = "crm.sp_QLThe_CNDTL_Duyet";
            public const string spCapNhatDiemTichLuyLoad = "crm.sp_QLThe_CNDTL_Load";
            public const string spCapNhatDiemTichLuySearch = "crm.sp_QLThe_CNDTL_Search";
            public const string spCapNhatDiemTichLuyExist = "crm.sp_QLThe_CNDTL_Exist";
            public const string spCapNhatDiemTichLuyDoiDiem = "crm.sp_QLThe_CNDTL_DoiDiem";
            #endregion

            #region Nang cap the thanh vien
            public const string spNangCapTheThanhVienGetAll = "crm.sp_QLThe_NCTTV_GetAll";
            public const string spNangCapTheThanhVienInsert = "crm.sp_QLThe_NCTTV_Insert";
            public const string spNangCapTheThanhVienUpdate = "crm.sp_QLThe_NCTTV_Update";
            public const string spNangCapTheThanhVienDelete = "crm.sp_QLThe_NCTTV_Delete";
            public const string spNangCapTheThanhVienLoad = "crm.sp_QLThe_NCTTV_Load";
            public const string spNangCapTheThanhVienSearch = "crm.sp_QLThe_NCTTV_Search";
            public const string spNangCapTheThanhVienGoiY = "crm.sp_QLThe_NCTTV_GoiY";
            public const string spNangCapTheThanhVienExist = "crm.sp_QLThe_NCTTV_Exist";
            #endregion

            #region Chinh sach the thanh vien
            public const string spChinhSachTheGetAll = "crm.sp_QLThe_CST_GetAll";
            public const string spChinhSachTheInsert = "crm.sp_QLThe_CST_Insert";
            public const string spChinhSachTheUpdate = "crm.sp_QLThe_CST_Update";
            public const string spChinhSachTheDelete = "crm.sp_QLThe_CST_Delete";
            public const string spChinhSachTheLoad = "crm.sp_QLThe_CST_Load";
            public const string spChinhSachTheSearch = "crm.sp_QLThe_CST_Search";
            public const string spChinhSachTheGetAD = "crm.sp_QLThe_CST_GetAD";
            #endregion

            #region In ma vach the thanh vien
            public const string spDotInTheGetAll = "crm.sp_QLThe_InThe_GetAll";
            public const string spDotInTheGetNext = "crm.sp_QLThe_InThe_GetNext";
            public const string spDotInTheInsert = "crm.sp_QLThe_InThe_Insert";
            public const string spDotInTheDelete = "crm.sp_QLThe_InThe_Delete";
            public const string spDotInTheGetNextSoThe = "crm.sp_QLThe_InThe_GetNextSoThe";
            public const string spDotInTheGetDateTichDiem = "crm.sp_QLThe_InThe_GetDateTichDiem";
            public const string spDotInTheUdpSoTheHTai = "crm.sp_QLThe_InThe_UpdSoTheHTai";
            #endregion

            #region In ma vach the thanh vien chi tiet
            public const string spDotInTheInsertChiTiet = "crm.sp_QLThe_InThe_InsertCTiet";
            public const string spDotInTheGetChiTiet = "crm.sp_QLThe_InThe_GetDetail";
            public const string spDotInTheGetAllSuDung = "crm.sp_QLThe_InThe_GetAllSuDung";
            #endregion
            #endregion


        #endregion

          
        }
        //#endregion


        public class NotifierPlugins
        {
            public static List<String> Notifies =
                new List<string>
                    {
                        "QLBanHang.Modules.KhoHang.DieuChuyenNotify"
                    };
        }

        public class Prefix
        {
            public const string PhieuXuatMuon = "PXM";
            public const string PhieuXuatTieuHao = "PXTH";
            public const string PhieuXuatNoiBo = "PXNB";
            public const string PhieuNhapNoiBo = "PNNB";
            public const string PhieuXuatDieuChuyen = "PXDC";
            public const string PhieuNhanDieuChuyen = "PNDC";
            public const string PhieuXuatDieuChuyenTrungGian = "PXDCTG";
            public const string PhieuNhanDieuChuyenTrungGian = "PNDCTG";
            public const string PhieuNhapHangLoi = "PNHL";
            public const string PhieuXuatTraHang = "PXTH";
            public const string PhieuNhapBH = "PNBH";
            public const string PhieuXuatBH = "PXBH";
            public const string PhieuYeuCau = "PYC";
            public const string PhieuNhapHangMuon = "PNHMBH";
            public const string PhieuNhapTP = "PNTP";
            public const string PhieuNhapKhoBH = "PNKBH";
            public const string PhieuXuatHangLoiBHNCC = "PXBHNCC";
            public const string PhieuNhapHangLoiBHNCC = "PNBHNCC";
            public const string PhieuXuatLinhKien = "PXLK";
            public const string PhieuPhanCong = "PPC";
            public const string PhieuKiemKe = "PKK";
            public const string PhieuXuatThanhPham = "PXTP";
            public const string PhieuNhapLinhKien = "PNLK";
            public const string BangKeHangLoi = "BKHL";
            public const string PhieuXuatTraLK = "PXTLK";
            public const string ChinhSachBanHang = "CSG";
            public const string BangGiaBan = "BG";
            public const string PhieuKhuyenMai = "KM";
            public const string TaoDonHangBan = "OD";
            public const string PhieuThanhToan = "PT";
            public const string PhieuChiTien = "PC";
            public const string PhieuTraHangMua = "PTM";
            public const string PhieuTraHangBan = "PNL";
            public const string DonHangTraLai = "DNL";
            public const string PhieuNhapHangMua = "PNHM";
            //public const string PhieuChi = "PC";
            //public const string PhieuThu = "PT";
            public const string PhieuXuatKhoHangBan = "XK";
            public const string TaoDonHangOnline = "OL";
            public const string XacNhanDonHangOnline = "XNOL";
            public const string PhieuPhanCongGiaoNhan = "GN";
            public const string TaoDonHangDatTruoc = "DT";
            public const string DonHangBanDatTruoc = "ODT";
            /// <summary>
            /// Doi ma hang ban
            /// </summary>
            public const string PhieuDeNghiDoiMa = "PDNDM";
            /// <summary>
            /// Doi ma hang ban
            /// </summary>
            public const string PhieuXacNhanDoiMa = "PXNDM";
            public const string DonHangGiaoNhan = "ODG";
            public const string HuyXuatKhoBH = "HXK";
            public const string XuatTraLKKD = "XLKKD";
            public const string XuatKinhDoanh = "XKD";
            public const string NhapKinhDoanh = "NKD";
            public const string PhieuHangLoiKD = "HLKD";
            public const string DonHangImport = "ODI";
            public const string PhieuThuImport = "PTTI";
            public const string PhieuNhapLaiKhac = "NLK";
            /// <summary>
            /// Doi ma san xuat
            /// </summary>
            public const string PhieuNhapDoiMa = "PNDM";
            /// <summary>
            /// Doi ma san xuat
            /// </summary>
            public const string PhieuXuatDoiMa = "PXDM";

            public const string PhieuNhapComBo = "PNCB";
            public const string PhieuXuatComBo = "PXCB";
            public const string XuatTinhChatBH = "XTC";
            public const string NhapTinhChatBH = "NTC";
            public const string NhapDoiSeRial = "NDSR";
            public const string XuatDoiSeRial = "XDSR";
            // tự tăng số yêu cầu khách hàng trong CRM
            public const string SoYeuCau = "YC";

            public const string DCNoKhuyenMai = "DCNKM";

            public const string CapNhatTichDiem = "CNDTL";
            public const string NangCapTheThanhVien = "NCTTV";

        }

        /// <summary>
        /// Phạm Ngọc Minh
        ///Tham số thời gian tự động refresh
        /// </summary>
        public static int TimerInterval = 60000;
    }
}

