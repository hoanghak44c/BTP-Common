// <summary>
// Mô tả class: Lớp đối tượng khai báo các hàm dùng chung, chuyển đổi kiểu dữ liệu
// </summary>
// <remarks>
// Người tạo: Nguyen Gia Dang
// Ngày tạo: 03/10/2007
// </remarks>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Net;
using System.Threading;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using QLBH.Common.Objects;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using ComboBox = System.Windows.Forms.ComboBox;
using ComExcel = Microsoft.Office.Interop.Excel;
using QLBH.Core;
using QLBanHang.Modules;
using QLBH.Common.Providers;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using TextBox = System.Windows.Forms.TextBox;

namespace QLBH.Common
{
    [Serializable]
    public class LookUp
    {
        public int OID { get; set; }
        public string Name { get; set; }
    }
    public enum NhomQuyenHan
    {
        [StringValue("Nhân viên, kỹ thuật")]
        NhanVien = 1,
        [StringValue("Trưởng nhóm")]
        TruongNhom = 2,
        [StringValue("Phụ trách")]
        PhuTrach = 3,
        [StringValue("Giám đốc siêu thị")]
        GiamDocSieuThi = 4,
        [StringValue("Trưởng ngành")]
        TruongNganh = 5,
        [StringValue("Giám đốc vùng")]
        GiamDocVung = 6,
        [StringValue("Ban giám đốc")]
        BanGiamDoc = 7
    }
    public enum CRM_TrangThaiXuLyYeuCau
    {
        [StringValue("yêu cầu đang chờ được xử lý")]
        ChoXuLy = 1,
        [StringValue("yêu cầu đang xử lý")]
        DangXuLy = 2,
        [StringValue("Yêu cầu đã được xử lý")]
        DaXuLy = 3
    }
    public enum TrangThaiXuLyYeuCauThe
    {
        [StringValue("Chờ phê duyệt")]
        CHO_DUYET = 0,
        [StringValue("Đã duyệt đề nghị")]
        DA_DUYET =1,
        [StringValue("Từ chối đề nghị")]
        TU_CHOI = 2,
        [StringValue("Đã xử lý")]
        DA_XU_LY = 3
    }
    public enum LoaiGiaoDichThe
    {
        [StringValue("Cấp mới thẻ thành viên")]
        CAP_MOI_THE = 0,
        [StringValue("Cấp lại thẻ thành viên")]
        CAP_LAI_THE = 1,
        [StringValue("Nâng hạng thẻ thành viên")]
        NANG_HANG_THE = 2,
        [StringValue("Gộp thẻ thành viên")]
        GOP_THE = 3
    }
    public enum TrangThaiTichDiem
    {
        [StringValue("Chưa tích điểm")]
        CHUA_TICH_DIEM = 0,
        [StringValue("Đã tích điểm")]
        DA_TICH_DIEM = 1,
        [StringValue("Chờ duyệt tích điểm")]
        CHO_DUYET_TICH_DIEM = 2,
        [StringValue("Không được tích điểm – đã xin chiết khấu ngành hàng")]
        DA_XIN_CHIET_KHAU = 3
    }
    /// <summary>
    /// Loại đối tượng khách hàng áp dụng chính sách giá
    /// </summary>
    public enum LoaiKhachHang
    {
        [StringValue("Khách mua hàng trực tiếp")]
        KHACH_TRUC_TIEP = 0,
        [StringValue("Khách mua hàng Online")]
        KHACH_ONLINE = 1
    }
    /// <summary>
    /// Trạng thái duyệt giá bán
    /// </summary>
    public enum TinhTrangDuyetGia
    {
        [StringValue("Chưa duyệt")]
        CHUA_DUYET = 0,
        [StringValue("Đồng ý duyệt")]
        DA_DUYET = 1,
        [StringValue("Từ chối duyệt")]
        TU_CHOI = 2
    }
    /// <summary>
    /// Nguồn tạo thẻ thành viên
    /// </summary>
    public enum NoiTaoTheThanhVien
    {
        [StringValue("CRM")]
        CRM = 1,
        [StringValue("POS")]
        POS = 2,
        [StringValue("Online")]
        ONLINE = 3
    }
    /// <summary>
    /// Loại đối tượng
    /// </summary>
    public enum LoaiDoiTuong
    {
        [StringValue("Khách hàng")]
        KHACH_HANG = 1,
        [StringValue("Nhà cung cấp")]
        NHA_CUNG_CAP = 2,
        [StringValue("Đại lý")]
        DAI_LY = 3
    }
    /// <summary>
    /// Loại chính sách giá
    /// </summary>
    public enum LoaiChinhSachGia
    {
        [StringValue("Chính sách thường")]
        THONG_THUONG = 0,
        [StringValue("Chính sách mặc định")]
        MAC_DINH = 1,
        [StringValue("Chính sách chiết khấu")]
        CHIET_KHAU = 2
    }
    /// <summary>
    /// Loại giao dịch bán hàng (được gọi từ menu)
    /// </summary>
    public enum LoaiGiaoDichBanHang
    {
        [StringValue("Lập đơn hàng bán")]
        LAP_DONHANG_BAN = 1,
        [StringValue("Lập đơn hàng Online")]
        LAP_DONHANG_ONLINE = 2,
        [StringValue("Duyệt đơn hàng Online")]
        DUYET_DONHANG_ONLINE = 3,
        [StringValue("Lập đơn hàng đặt trước")]
        LAP_DONHANG_DATTRUOC = 4,
        [StringValue("Phân công giao nhận")]
        PHANCONG_GIAONHAN = 5,
        [StringValue("Xuất kho hàng bán")]
        XUATKHO_HANGBAN = 6,
        [StringValue("Lập phiếu thu")]
        LAP_PHIEUTHU = 7,
        [StringValue("Đề nghị nhập lại hàng")]
        DENGHI_NHAPLAI_HANGBAN = 8,
        [StringValue("Xác nhận nhập lại hàng")]
        XACNHAN_NHAPLAI_HANGBAN = 9,
        [StringValue("Xuất bù khuyến mại")]
        XUAT_BU_KHUYEN_MAI = 10,
        [StringValue("Trả lại đơn hàng bán")]
        TRA_LAI_DON_HANG_BAN = 11
    }
    /// <summary>
    /// Trạng thái đơn hàng:
    /// 1. Đơn hàng Online:
    /// - Tạo đơn hàng
    /// - Xác nhận đơn hàng => thành đơn hàng bán
    /// 2. Đặt hàng trước
    /// - Tạo đơn hàng
    /// </summary>
    public enum OrderStatus//Trang thai don hang ban
    {
        [StringValue("Khóa đơn hàng đặt trước (Đơn hàng bị hủy, không sinh lại phiếu chi)")]
        KHOA_DON_HANG_DAT_TRUOC = -20,
        [StringValue("Tạo đơn hàng Online (chờ kế toán Online duyệt)")]
        TAO_DON_HANG_ONLINE = 1,
        [StringValue("Xác nhận đơn hàng Online (chờ kế toán shop chuyển đơn hàng bán)")]
        XAC_NHAN_DON_HANG_ONLINE = 2,
        [StringValue("Từ chối đơn hàng Online (kế toán Online từ chối đơn hàng, kinh doanh làm lại)")]
        REJECT_DON_HANG_ONLINE = 3,
        [StringValue("Lập đơn hàng bán Online (kế toán shop tạo đơn hàng bán cho yêu cầu Online, chờ phân công hoặc xuất kho)")]
        DON_HANG_BAN_ONLINE = 4,
        [StringValue("Tạo đơn đặt hàng trước (Kế toán tạo đơn hàng thu tiền đặt trước)")]
        TAO_DON_HANG_DAT_TRUOC = 5,
        [StringValue("Lập đơn hàng bán đặt trước (Kế toán shop tạo đơn hàng bán cho yêu cầu đặt trước , chờ phân công hoặc xuất kho)")]
        DON_HANG_BAN_DAT_TRUOC = 6,
        [StringValue("Lập đơn hàng bán tại Shop (Kế toán shop tạo đơn hàng bán, chờ phân công hoặc xuất kho)")]
        DON_HANG_BAN_TAI_SHOP = 7,
        [StringValue("Phân công giao nhận (chờ kế toán xác nhận lại)")]
        PHAN_CONG_GIAO_NHAN = 8,
        [StringValue("Xác nhận đơn hàng giao nhận (Kế toán shop đã xác nhận, chờ xuất kho)")]
        XAC_NHAN_DON_HANG_GIAO_NHAN = 9,
        [StringValue("Từ chối đơn hàng giao nhận (Kế toán shop từ chối phân công giao nhận, chờ phân công lại)")]
        REJECT_DON_HANG_GIAO_NHAN = 10,
        [StringValue("Xuất kho (Thủ kho đã xuất kho toàn bộ đơn hàng bán)")]
        XUAT_KHO = 11,
        [StringValue("Hủy đơn hàng chưa xuất kho(Kế toán hủy hoặc trả lại đơn hàng khi thủ kho chưa xuất hàng bán)")]
        HUY_DON_HANG = 12,//dung cho don hang goc tai sieu thi bi huy chua xuat kho
        [StringValue("Đề nghị nhập lại hàng bán (CSKH kiểm tra mã vạch, lập đề nghị nhập hàng, chờ kế toán xác nhận)")]
        DE_NGHI_TRA_LAI_HANG_BAN = 13,
        [StringValue("Xác nhận nhập lại hàng bán (kế toán xác nhận nhập lại hàng vào kho)")]
        XAC_NHAN_TRA_LAI_HANG_BAN = 14,//dung cho don hang tra lai da xuat kho
        [StringValue("Hủy đề nghị nhập lại hàng bán (CSKH hủy đề nghị nhập lại đơn hàng bán)")]
        HUY_DE_NGHI_TRA_LAI = 15,
        [StringValue("Đề nghị đổi mã vạch hàng bán (Thủ kho đề nghị đổi mã vạch cho hàng bán, chờ kế toán xác nhận)")]
        DE_NGHI_DOI_MA_VACH = 16,
        [StringValue("Xác nhận đổi mã vạch hàng bán (Kế toán xác nhận đổi mã vạch cho hàng bán)")]
        XAC_NHAN_DOI_MA_VACH = 17,
        [StringValue("Hủy đề nghị đổi mã vạch hàng bán (Thủ kho hủy đề nghị đổi mã vạch hàng bán)")]
        HUY_DE_NGHI_DOI_MA_VACH = 18,
        [StringValue("Hủy đơn hàng online (Kinh doanh Online hủy đơn hàng Online trước khi kế toán online duyệt đơn hàng)")]
        HUY_DON_HANG_ONLINE = 19,//dung cho don hang goc online bi huy chua xuat khoa
        [StringValue("Hủy đơn hàng đặt trước (Kinh doanh hủy đơn hàng đặt trước trước khi kế toán siêu thị chuyển sang đơn hàng bán)")]
        HUY_DON_HANG_DAT_TRUOC = 20,//dung cho don hang goc dat truoc bi huy chua xuat khoa
        //[StringValue("Xác nhận nhập lại khác (Kế toán xác nhận nhập lại đơn hàng chưa xuất kho)")]
        [StringValue("Xác nhận nhập lại khác (Kế toán xác nhận nhập lại đơn hàng không gốc)")] //hah: thay đổi cho phù hợp với việc nhập lại đơn hàng không gốc.
        XAC_NHAN_TRA_LAI_KHAC = 21,
        [StringValue("Đang xuất kho (Thủ kho đang xuất từng phần đơn hàng, chưa xuất hết)")]
        DANG_XUAT_KHO = 22,
        [StringValue("Trả lại đơn hàng bán (Trả lại đơn hàng khi chưa xuất kho)")]
        TRA_LAI_DON_HANG_BAN = 23,//dung cho don hang tra lai chua xuat kho
        [StringValue("Trả lại đơn hàng online (Trả lại đơn hàng Online khi kế toán online chưa xác nhận)")]
        TRA_LAI_DON_HANG_ONLINE = 24,//dung cho don hang tra lai chua xuat kho
        [StringValue("Trả lại đơn hàng đặt trước (Trả lại đơn hàng đặt trước khi kế toán chưa chuyển đơn hàng bán)")]
        TRA_LAI_DON_HANG_DAT_TRUOC = 25,//dung cho don hang tra lai chua xuat kho
        [StringValue("Hủy đơn hàng đã xuất kho (Đơn hàng bị hủy, trả lại khi thủ kho đã hoặc đang xuất kho)")]
        TRA_LAI_DON_HANG_XUAT_KHO = 26//dung cho don hang goc bi huy da xuat kho
    }
    public enum LoaiPhieuThanhToan
    {
        [StringValue("Thu")]
        PHIEU_THU = 0,
        [StringValue("Chi")]
        PHIEU_CHI = 1
    }
    public enum LoaiGiaoDichThanhToan
    {
        GIAODICH_BANHANG = 0,
        GIAODICH_BAOHANH = 1
    }
    /// <summary>
    /// Loại trường chứng từ tìm kiếm (sp_BHang_ChungTu_Search)
    /// </summary>
    public enum SearchOrderType
    {
        SOCHUNGTU = 1,
        SOSERI = 2,
        SOPHIEUXUAT = 3,
        SOCHUNGTUGOC = 4,
        SOCMND = 5,
        SODIENTHOAI = 6,
        DIACHI = 7,
        SOHDDAMUA = 8,
        SOPHIEUDC = 9
    }
    public enum CustomerType//Loai doi tuong
    {
        KHACH_HANG = 0,
        NHA_CUNG_CAP,
        DAI_LY
    }

    public enum LoaiGiaoDichSanXuat
    {
        NHAP_THANH_PHAM_SAN_XUAT = 1,
        TACH_THANH_PHAM_SAN_XUAT = 2,
    }

    public enum LoaiGiaoDichPO
    {
        NHAP_HANG_NHA_CUNG_CAP = 0,
        TRA_HANG_NHA_CUNG_CAP = 1,
    }

    public enum TrangThaiSanXuat
    {
        [StringValue("Chờ xuất linh kiện")]
        ChoXuat = 1,
        [StringValue("Đang sản xuất")]
        DangSX = 2,
        [StringValue("Đã sản xuất xong")]
        DaSanXuatXong = 3,
        [StringValue("Ngừng sản xuất")]
        NgungSanXuat = 4,
        [StringValue("Phiếu đã hủy")]
        HuyLenh = 5
    }

    public enum LoaiGiaoNhan
    {
        [StringValue("Không giao")]
        KHONG_GIAO = 0,
        [StringValue("Siêu thị giao")]
        SIEU_THI_GIAO = 1,
        [StringValue("Kho tổng giao")]
        KHO_TONG_GIAO = 2,        
    }

    public enum TrangThaiGiaoNhan
    {
        [StringValue("Phân công (Chưa đi giao,chờ xuất hàng)")]
        PHAN_CONG = 0,
        [StringValue("Đang giao hàng (Đã xuất kho, đang đi giao)")]
        DANG_GIAO_HANG = 1,
        [StringValue("Đã giao hàng (Giao nhận thành công)")]
        DA_GIAO_HANG = 2,
        [StringValue("Hủy giao hàng (Khách từ chối nhận hàng hoặc có vấn đề phát sinh)")]
        HUY_GIAO_HANG = 3,
        [StringValue("Nhập lại hàng (hàng giao bị nhập lại)")]
        NHAP_LAI_HANG = 4,
        [StringValue("Chờ phân công (đơn hàng chưa phân công giao nhận")]
        CHO_PHAN_CONG = -1
    }

    public enum TrangThaiPhanDonGiaoNhan
    {
        [StringValue("Chưa phân đơn")]
        CHUA_PHAN_DON = 0,
        [StringValue("Đã phân đơn")]
        DA_PHAN_DON = 1,
        [StringValue("Từ chối phân đơn")]
        TU_CHOI_PHAN_DON = 2,
        [StringValue("Xác nhận phân đơn")]
        XAC_NHAN_PHAN_DON = 3
    }
    public enum TransactionType//Loai giao dich
    {
        [StringValue("Nhập hàng mua nhà cung cấp")]
        NHAP_PO = 1,
        [StringValue("Nhập thành phẩm sản xuất")]
        NHAP_THANH_PHAM_SX = 2,
        NHAP_TRA_LAI = 3,
        [StringValue("Nhập hàng nội bộ")]
        NHAP_NOIBO = 4,
        TRA_LAI_PO = 5,
        TACH_THANH_PHAM_SX = 6,
        XUAT_LINK_KIEN_SX = 7,
        [StringValue("Đơn hàng đặt trước")]
        DON_HANG_DAT_TRUOC = 8,
        [StringValue("Đơn hàng Online")]
        DON_HANG_ONLINE = 9,
        [StringValue("Đơn hàng tại siêu thị")]
        DON_HANG_TAI_SHOP = 10,
        XUAT_NOI_BO = 11,
        DE_NGHI_XUAT_DIEU_CHUYEN = 12,
        [StringValue("Xuất điều chuyển")]
        XUAT_DIEU_CHUYEN = 13,
        DE_NGHI_NHAN_DIEU_CHUYEN = 14,
        DE_NGHI_TIEU_HAO = 15,
        XUAT_HUY_TIEU_HAO = 16,
        XUAT_KHAC = 17,
        XUAT_KHUYEN_MAI = 18,
        TRA_LAI_KHUYEN_MAI = 19,
        //Dùng trong quá trình xuất mượn hàng cho khách hàng
        [StringValue("Xuất mượn")]
        XUAT_MUON = 20,
        [StringValue("Nhận điều chuyển")]
        NHAN_DIEU_CHUYEN = 21,
        //khi thay thế một sản phẩm trong quá trình thực hiện bảo hành
        [StringValue("Xuất đổi bảo hành")]
        XUAT_BAOHANH = 22,
        //khi trả hàng bảo hành cho khách hàng 
        [StringValue("Xuất trả bảo hành")]
        XUATTRA_BAOHANH = 23,
        //Dùng khi khách hàng mượn hàng của Trần Anh và đem trả lại
        [StringValue("Nhập hàng khách mượn ")]
        NHAPTRA_MUON = 24,
        //khi thay thế một sản phẩm trong quá trình thực hiện bảo hành
        [StringValue("Nhập đổi bảo hành")]
        NHAP_BAOHANH = 25,
        //Nhập hàng bảo hành của khách hàng khi được đưa đến trần anh bảo hành
        [StringValue("Nhập kho hàng lỗi")]
        NHAPKHO_HANGLOIBH = 26,
        //Xuất hàng lỗi sang nhà cung cấp
        [StringValue("Xuất bảo hành hãng")]
        XUATHANGLOIBHNCC = 27,
        //Nhà cung cấp trả hàng cho trần anh
        [StringValue("Nhập bảo hành hãng")]
        NHAPHANGLOIBHNCC = 28,
        XUAT_BAN = 29,
        //Xuất thành phẩm sản xuất
        XUAT_THANH_PHAM = 30,
        //Nhập linh kiện sản xuất
        NHAP_LINH_KIEN = 31,
        //Xuất trả linh kiện bảo hành
        XUATTRALK_BH = 32,

        //Nhập trả hàng mua (Phân hệ bán hàng)
        //Phạm Ngọc Minh
        //06/12/2012
        [StringValue("Nhập lại có đơn hàng bán")]
        NHAPTRAHANGMUA = 33,

        //Đổi mã hàng bán (phân hệ bảo hành)
        //Phạm Ngọc Minh
        //28/12/2012
        [StringValue("Xuất đổi serial cùng mã hàng")]
        DOIMAHANGMUA = 34,
        [StringValue("Đơn hàng giao nhận")]
        DON_HANG_GIAO_NHAN = 35,
        [StringValue("Đơn hàng xuất bù khuyến mại")]
        DON_HANG_BU_KHUYEN_MAI = 36,
        PHAN_CONG_GIAO_NHAN = 41,

        HUYXUAT_TRABH = 39,
        XUATTRALK_KD = 40,
        [StringValue("Xuất kho")]
        XUATKINHDOANH = 37,
        [StringValue("Nhập kho")]
        NHAPKINHDOANH = 38,
        [StringValue("Nhập lại khác - không có đơn hàng bán")]
        DON_HANG_NHAP_LAI = 42,
        NHAP_COMBO = 43,
        XUAT_COMBO = 44,
        [StringValue("Nhập đổi mã linh kiện")]
        NHAP_DOIMA = 45,
        XUAT_DOIMA = 46,
        [StringValue("Xuất đổi tính chất")]
        XUAT_DOI_TINH_CHAT = 47,
        [StringValue("Nhập đổi tính chất")]
        NHAP_DOI_TINH_CHAT = 48,
        [StringValue("Phiếu xuất kho hàng bán")]
        XUAT_KHO_HANG_BAN = 49,
        [StringValue("Trả lại đơn hàng bán chưa xuất kho")]
        TRA_LAI_DON_HANG_BAN = 50,
        [StringValue("Đề nghị nhập lại tiêu hao")]
        DE_NGHI_NHAP_TIEU_HAO = 51,
        [StringValue("Xác nhận nhập lại tiêu hao")]
        NHAP_TIEU_HAO = 52,
        [StringValue("Đề nghị nhận điều chuyển trung gian")]
        DE_NGHI_NHAN_DIEU_CHUYEN_TRUNG_GIAN = 53,
        [StringValue("Nhận điều chuyển trung gian")]
        NHAN_DIEU_CHUYEN_TRUNG_GIAN = 54,
        [StringValue("Đề nghị xuất điều chuyển trung gian")]
        DE_NGHI_XUAT_DIEU_CHUYEN_TRUNG_GIAN = 55,
        [StringValue("Xuất điều chuyển trung gian")]
        XUAT_DIEU_CHUYEN_TRUNG_GIAN = 56,
        [StringValue("Nhập đổi linh kiện lỗi")]
        NHAP_DOI_LINHKIEN_LOI = 57,
        [StringValue("Xuất đổi linh kiện lỗi")]
        XUAT_DOI_LINHKIEN_LOI = 58,
        [StringValue("Nhập đổi đổi serial cùng mã hàng")]
        NHAPDOIMAHANGMUA = 59,
        [StringValue("Điều chỉnh tăng tồn ảo")]
        DIEU_CHINH_TANG_TONAO = 60,
        [StringValue("Điều chỉnh giảm tồn ảo")]
        DIEU_CHINH_GIAM_TONAO = 61,
        [StringValue("Phân đơn giao  nhận")]
        PHAN_DON_GIAO_NHAN = 62
    }

    public enum TrangThaiDuyet// dung cho xuat tieu hao, nhap xuat noi bo
    {
        CHUA_XUAT = 0,
        DA_XUAT = 1,
        CHUA_NHAP = 2,
        DA_NHAP = 3,
        HUY_TIEU_HAO = 4,
    }
    public enum TrangThaiKiemKe
    {
        CHUA_XAC_NHAN = 0,
        XAC_NHAN = 1
    }
    /// <summary>
    /// nằm trong khoảng 100..150
    /// </summary>
    public enum TrangThaiDieuChuyen
    {
        /// <summary>
        /// Chờ xác nhận(chờ kế toán kho nhận xác nhận)
        /// </summary>
        CHO_KETOAN_NHAN = 0,
        DA_XUAT = 1,
        /// <summary>
        /// Chờ nhận hàng (chờ thủ kho nhận nhập hàng vào kho)
        /// </summary>
        CHO_THUKHO_NHAN = 2,
        /// <summary>
        /// Đã nhận (kết thúc.)
        /// </summary>
        DA_NHAN = 3,
        /// <summary>
        /// Chờ xuất serial (chờ thủ kho xuất bắn serial xuất)
        /// </summary>
        CHO_THUKHO_XUAT = 4,
        HUY_DIEU_CHUYEN = 5,
        /// <summary>
        /// Chờ hủy điều chuyển.
        /// </summary>
        CHO_HUY_DIEU_CHUYEN = 6
    }
    #region TrangThaiBaoHanh (Chỉ dùng cho module bảo hành)

    public class StringValue : System.Attribute
    {
        private string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

    public class StringEnum
    {
        public static List<TrangThaiBH> GetStringValue(params object[] paramevalue)
        {
            List<TrangThaiBH> lst = new List<TrangThaiBH>();
            for (int i = 0; i < paramevalue.Length; i++)
            {
                Type type = paramevalue[i].GetType();

                //Check first in our cached results...
                //if (_stringValues.ContainsKey(value))
                //    output = (_stringValues[value] as StringValue).Value;
                //else
                //{
                //Look for our 'StringValueAttribute' 
                //in the field's custom attributes
                FieldInfo fi = type.GetField(paramevalue[i].ToString());
                StringValue[] attrs =
                    fi.GetCustomAttributes(typeof(StringValue),
                                           false) as StringValue[];
                if (attrs.Length > 0)
                {
                    lst.Add(new TrangThaiBH { Id = Convert.ToInt32(paramevalue[i]), Name = attrs[0].Value });
                    //_stringValues.Add(value, attrs[0]);
                }
            }
            //}

            return lst;
        }

        public static List<T> GetStringValue<T>(params object[] paramevalue) where T : class
        {
            var lst = new List<T>();
            for (int i = 0; i < paramevalue.Length; i++)
            {
                var type = paramevalue[i].GetType();

                var fi = type.GetField(paramevalue[i].ToString());
                var attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
                if (attrs != null && attrs.Length > 0)
                {
                    lst.Add(Activator.CreateInstance(typeof (T), Convert.ToInt32(paramevalue[i]), attrs[0].Value) as T);
                }
            }
            return lst;
        }
    }
    [Serializable]
    public class TrangThaiBH
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum Bh_BoPhan
    {
        [StringValue("Tiếp nhận")]
        TiepNhan = 1,
        [StringValue("Kho")]
        Kho = 2,
        [StringValue("Kế toán")]
        KeToan = 3,
        [StringValue("Kĩ thuật")]
        KiThuat = 4,
        [StringValue("Thông tin")]
        ThongTin = 5
    }

    public enum Bh_ThaoTac
    {
        [StringValue("Tiếp nhận hàng lỗi")]
        TiepNhan = 1,
        [StringValue("Nhập kho")]
        NhapKho = 2,
        [StringValue("Phân loại")]
        PhanLoai = 3,
        [StringValue("Lập bảng kê")]
        LapBangKe = 4,
        [StringValue("Sửa bảng kê")]
        SuaBangKe = 5,
        [StringValue("Lập phiếu xuất nhà cung cấp")]
        LapPhieuXuat = 6,
        [StringValue("Sửa phiếu xuất nhà cung cấp")]
        SuaPhieuXuat = 7,
        [StringValue("Đàm phán nhà cung cấp")]
        DamPhanNCC = 8,
        [StringValue("Đàm phán khách lẻ")]
        DamPhanKhach = 9,
        [StringValue("Lập phiếu nhận nhà cung cấp")]
        LapPhieuNhanNCC = 10,
        [StringValue("Sửa phiếu nhận nhà cung cấp")]
        SuaPhieuNhanNCC = 11,
        [StringValue("Lên kế hoạch")]
        LenKeHoach = 12,
        [StringValue("Sửa kế hoạch")]
        SuaKeHoach = 13,
        [StringValue("Xuất linh kiện bảo hành")]
        XuatLKBaoHanh = 14,
        [StringValue("Hủy xuất linh kiện bảo hành")]
        HuyXuatLKBaoHanh = 15,
        [StringValue("Phân công bảo hành")]
        PhanCongBH = 16,
        [StringValue("Kĩ thuật đã kiểm tra")]
        KiThuatKT = 17,
        [StringValue("Kĩ thuật hủy linh kiện")]
        KiThuatHuyLK = 18,
        [StringValue("Kiểm trả tổng hợp")]
        KiemTraTongHop = 19,
        [StringValue("Lập đề nghị trả khách")]
        LapDeNghiTra = 20,
        [StringValue("Tách cấu hình")]
        TachCauHinh = 21,
        [StringValue("Xác nhận trả khách")]
        XacNhanTraKhach = 22,
        [StringValue("Xóa kế hoạch")]
        XoaKeHoach = 23,
        [StringValue("Đổi nhân viên xử lý")]
        DoiKiThuat = 24,
        [StringValue("Kĩ thuật kết thúc")]
        KiThuatKetThuc = 25,
        [StringValue("Đảo công nợ")]
        DaoCongNo = 26,
        [StringValue("Nhập phiếu nhận NCC")]
        NhapPhieuNhanNCC = 27,
        [StringValue("Xuất trả khách")]
        XuatTraKhach = 28,
        [StringValue("Kế toán hủy trả khách")]
        KeToanHuyTra = 29,
        [StringValue("Kho từ chối trả hàng")]
        KhoHuyTra = 30,
        [StringValue("Nhập hàng khách mượn")]
        KhoNhapMuon = 31,
        [StringValue("Xác nhận nhập hàng khách mượn")]
        KeToanNhapMuon = 32,
        [StringValue("Đề nghị xuất mượn")]
        DeNghiXuatMuon = 33,
        [StringValue("Kế toán duyệt xuất mượn")]
        DuyetXuatMuon = 34,
        [StringValue("Kho xuất hàng mượn")]
        KhoXuatMuon = 35,
        [StringValue("Kiếm tra hàng nhận nhà cung cấp")]
        KhoTestHang = 36,
        [StringValue("Kiểm phiếu bảo hành")]
        KiemTraPBH = 37,
        [StringValue("Xác định lỗi hàng công ty")]
        SetLoi = 38,
        [StringValue("Clear lỗi hàng công ty")]
        ClearLoi = 39,
        [StringValue("Tiếp nhận yêu cầu")]
        TiepNhanYeuCau = 40,
        [StringValue("Xử lý yêu cầu")]
        XuLyYeuCau = 41,
        [StringValue("Phân công xử lý yêu cầu")]
        PhanCongYC = 42,

        [StringValue("Kĩ thuật xử lý yêu cầu")]
        KiThuatXLYC = 43,
        [StringValue("Kĩ thuật hủy xử lý yêu cầu")]
        KiThuatHuyYC = 44,
        [StringValue("Hoàn thiện xử lý yêu cầu")]
        KetThucYC = 45,
        [StringValue("Phân công trả hàng yêu cầu ")]
        PhanCongTraYC = 46,
    }

    public enum Bh_TinhTrangChinhSachNCC
    {
        [StringValue("Đổi ngang")]
        DoiNgang = 1,
        [StringValue("Đổi mới")]
        DoiMoi = 2
    }

    public enum BH_loaiHinhDichVu
    {
        [StringValue("Xuất mượn")]
        XuatMuon = 1,
        [StringValue("Nhập mượn")]
        NhapMuon = 2,
        [StringValue("Đổi các")]
        DoiCac = 3,
        [StringValue("Dịch vụ")]
        DichVu = 4,
        [StringValue("Nhập hãng")]
        NhapHang = 5,
        [StringValue("Nhập lại")]
        NhapLai = 6
    }

    public enum Bh_XuLyYeuCau
    {
        [StringValue("Tiếp nhận")]
        ChuaXuLy = 0,
        [StringValue("Đã xử lý")]
        DaXuLy = 1,
        [StringValue("Chờ phân công")]
        ChoPhanCong = 2,
        [StringValue("Nhập kho BH")]
        NhapKho = 3,
        [StringValue("Chờ phiếu BN")]
        ChoLapPhieu = 4,
        [StringValue("Hủy phân công")]
        HuyPhanCong = 5,
        [StringValue("Kĩ thuật đã xử lý")]
        KiThuatXuLy = 6,
        [StringValue("Hãng đang xử lý")]
        HangXuLy = 7,
        [StringValue("Đã phân công")]
        DaPhanCong = 8,
        [StringValue("Hãng đã xử lý")]
        HangDaXuLy = 9,
        [StringValue("Xử lý lại")]
        XuLyLai = 10,
        [StringValue("Kỹ thuật hủy")]
        KiThuatHuy = 11,
        [StringValue("Đã lập phiếu BN")]
        DaLapPhieu = 12
    }
    public enum Bh_TrangThaiKiemSoat
    {
        [StringValue("Chưa kiểm tra")]
        ChuaKiemTra = 0,
        [StringValue("Đang kiểm tra")]
        DangKiemTra = 1,
        [StringValue("Đã kiểm tra")]
        DaKiemTra = 2,
    }
    public enum Bh_HinhThucXuLyYC
    {
        [StringValue("Tư vấn khách hàng")]
        DienThoai = 1,
        [StringValue("Xử lý tại chỗ")]
        XuLyTaiTrungTam = 2,
        [StringValue("Xử lý tại nhà")]
        XuLyTaiNha = 3,
        [StringValue("Báo hãng")]
        BaoHang = 4

    }

    public enum BH_LoaiLoiYC
    {
        [StringValue("Lỗi lắp đặt")]
        LoiLapDat = 1,
        [StringValue("Lỗi sản phẩm")]
        LoiSanPham = 2,
        [StringValue("Sản phẩm bình thường")]
        BinhThuong = 3
    }

    public enum Bh_PhieuBaoHanh
    {
        [StringValue("Có phiếu bảo hành")]
        CoPhieu = 1,
        [StringValue("Không có phiếu bảo hành")]
        KhongCo = 2,
        [StringValue("Đã chuyển lên trước")]
        DaChuyen = 3
    }

    public enum Bh_TrangThaiLichSu
    {
        [StringValue("Nợ gốc")]
        NoGoc = 0,
        [StringValue("Đổi ngang")]
        DoiNgangBH = 1,
        [StringValue("Nhập lại")]
        NhapLaiBH = 2,
        [StringValue("Đổi các")]
        DoiCacBH = 3,
        [StringValue("Xuất bán")]
        XuatBanBH = 4,
        [StringValue("Xuất bán hãng")]
        XuatBanHang = 8,
        [StringValue("Xuất bảo hành hãng")]
        XuatBHHang = 6,
        [StringValue("Xuất trả")]
        XuatTra = 7,
        [StringValue("Nhập bảo hành hãng")]
        NhapBHHang = 5,
        [StringValue("Thanh lý hãng")]
        ThanhLyHang = 9
    }

    public enum Bh_TrangThaiLinhKien
    {
        [StringValue("Chờ phân công")]
        ChoPhanCong = 6,
        [StringValue("Chờ tách cấu hình")]
        ChoTachLinhKien = 1,
        [StringValue("Chờ linh kiện")]
        ChoLinhKien = 2,
        [StringValue("Có linh kiện")]
        CoLinhKien = 3,
        [StringValue("Đã tách cấu hình")]
        DaTach = 4,
        [StringValue("Kĩ thuật thực hiện")]
        DaDoiMa = 5,
        [StringValue("Hủy xuất LK")]
        HuyXuatLK = 7,
        [StringValue("Kĩ thuật hủy")]
        KiThuatHuy = 8,
    }
    public enum Bh_TrangThaiDraft
    {
        [StringValue("Đã xác nhận")]
        DaXacNhan = 0,
        [StringValue("Chưa xác nhận")]
        ChuaXacNhan = 1,
        [StringValue("Kho từ chối")]
        KhoHuy = 2,
        [StringValue("Kế toán nhận")]
        KeToanChi = 3,
        [StringValue("Xác nhận hủy")]
        DaHuy = 4,
    }

    //Dành đánh giá sản phẩm được trả về từ nhà cung cấp


    public enum BH_TrangThaiNhanHangBHNCC
    {
        [StringValue("Hỏng hóc")]
        Hong = 1,
        [StringValue("Tốt")]
        Tot = 2,
        [StringValue("Bình thường")]
        BinhThuong = 3
    }

    public enum BH_TrangThaiNhan
    {
        [StringValue("Hỗ trợ")]
        HoTro = 1,
        [StringValue("Tạm nhận")]
        TamNhan = 2,
        [StringValue("Bảo hành")]
        BaoHanh = 3
        //1. Hỗ trợ
        //2. Tạm nhận
        //3. Bảo hành
    }

    public enum BH_TrangThaiItem
    {
        [StringValue("Tiếp nhận")]
        TiepNhan = 1,
        [StringValue("Chờ phân công")]
        ChoPhanCong = 2,
        [StringValue("Đã phân công")]
        DaPhanCong = 3,
        [StringValue("Đang xử lý bảo hành")]
        DangXuLyBH = 4,
        [StringValue("Đã bảo hành")]
        DaBaoHanh = 5,
        [StringValue("Chờ xuất bảo hành hãng")]
        ChoXuatBH = 6,
        [StringValue("Xuất bảo hành nhà cung cấp")]
        XuatBHNhaCC = 7,
        [StringValue("Gửi NCC (Gửi bên NCC)(bàn thêm về trạng thái này)")]
        GuiNCC = 8,
        [StringValue("Xuất bán nhà cung cấp")]
        XuatBanNCC = 9,
        [StringValue("Đã trả")]
        DaTra = 10,
        [StringValue("Đã kiểm tra")]
        DaKiemTra = 11,
        [StringValue("Xuất trả kinh doanh")]
        XuatTraKD = 12,
        [StringValue("Chờ trả khách")]
        ChoTraKhach = 13,
        [StringValue("Kĩ thuật đã kiểm tra")]
        KiThuatDaKiemTra = 14,
        [StringValue("Trả nguyên trạng")]
        TraNguyenTrang = 15,
        [StringValue("Chờ xử lý")]
        ChoXuLy = 16,
        [StringValue("Kho Test hàng")]
        KhoTest = 17,
        [StringValue("Tồn trung tâm")]
        TonTrungTam = 18,
        [StringValue("Xuất mượn")]
        XuatMuon = 19,
        [StringValue("Đã xóa lỗi")]
        XoaLoi = 20,
        [StringValue("Tồn")]
        Ton = 21,
        [StringValue("Đã trả mượn")]
        TraMuon = 22,
        [StringValue("Tồn trả nguyên trạng")]
        TonTraNguyenTrang = 23,
        [StringValue("Tách cấu hình")]
        TachCauHinh = 24,

        //1. Tiếp nhận(Đã tiếp nhận, chờ nhập kho)
        //2. Chờ phân công (Đã nhập kho, chờ phân công)
        //3. Đã phân công (Đã phân công, chờ xác nhận)
        //4. Đang xử lý BH (Đã nhận phân công và đang xử lý bảo hành)
        //5. Đã bảo hành (Đã bảo hành xong)
        //6. Chờ xuất BH (Đối với Item dc phân loại xuất BH NCC)
        //7. Xuất BH nhà CC(Đã xuất sang NCC để BH)
        //8. Gửi NCC (Gửi bên NCC)(bàn thêm về trạng thái này)
        //9. Xuất bán NCC (Xuất bán cho nhà CC)
        // Chú ý: Trạng thái Redirect sẽ được thiết kế thành một chức năng riêng   
    }

    public enum BH_NghiepVu
    {
        [StringValue("Thông tin")]
        ThongTin = 1,
        [StringValue("Kho")]
        Kho = 2,
        [StringValue("Kĩ thuật")]
        KiThuat = 3,
        [StringValue("Trả hàng")]
        TraHang = 4
    }

    public enum BH_TrangThaiKeHoach
    {
        [StringValue("Thông tin lập")]
        LapKeHoach = 1,
        [StringValue("Kho xuất")]
        KhoXuat = 2,
        [StringValue("Kĩ thuật thực hiện")]
        KiThuat = 3,
        [StringValue("Kĩ thuật hủy")]
        KiThuatHuy = 4,
        [StringValue("Kho hủy")]
        KhoHuy = 5,
        [StringValue("Thông tin hủy")]
        ThongTinHuy = 6,
    }

    public enum BH_TinhChat
    {
        [StringValue("Bảo hành trả ngay")]
        HangMoi = 1,
        [StringValue("Bảo hành thường")]
        BaoHanhThuong = 2,
    }

    public enum BH_TrangThaiXuatMuon
    {
        [StringValue("Tất cả")]
        TatCa = 0,
        [StringValue("Yêu cầu")]
        YeuCau = 1,
        [StringValue("Đã thu tiền")]
        DaThuTien = 2,
        [StringValue("Xuất kho")]
        DaXuatKho = 3,

    }
    public enum BH_TrangThaiTraSPMuon
    {
        [StringValue("Chưa trả")]
        ChuaTra = 0,
        [StringValue("Đã trả")]
        DaTra = 1
    }
    public enum BH_TrangThaiPhieu
    {
        [StringValue("Tiếp nhận")]
        TiepNhan = 1,
        [StringValue("Đang xử lý")]
        DangXuLy = 2,
        [StringValue("Đã xử lý")]
        DaXuLy = 3,
        [StringValue("Đã trả")]
        DaTra = 4,
        [StringValue("Xuất trả kinh doanh")]
        XuatTraKD = 5,
        [StringValue("Chờ trả")]
        ChoTraKhach = 6,
        [StringValue("Chờ hủy phiếu")]
        ChoHuy = 7,
        [StringValue("Đã hủy")]
        DaHuy = 8
        //1. Tiếp nhận(đã lập phiếu tiếp nhận, chưa phân công)
        //2. Đang xử lý(Đã phân công)
        //3. Đã xử lý(Đã hoàn thành bảo hành)
        //4. Đã trả(Đã trả hàng cho khách)

    }

    public enum BH_LoaiHang
    {
        [StringValue("Hàng tốt")]
        Tot = 2,
        [StringValue("Hàng lỗi")]
        Loi = 1,
    }

    public enum BH_HuyPhieuNhan
    {
        [StringValue("Đề nghị hủy")]
        DeNghi = 0,
        [StringValue("Duyệt hủy")]
        Duyet = 1,
        [StringValue("Từ chối hủy")]
        TuChoi = 2
    }

    public enum BH_LoaiPhieuNhan
    {
        [StringValue("Nợ khách")]
        NoKhach = 0,
        [StringValue("Đổi khách")]
        DoiKhach = 1,
        [StringValue("Nợ kinh doanh")]
        NoCTy = 2,
    }
    public enum BH_HinhThucXuLy
    {
        [StringValue("Đổi ngang")]
        DoiNgang = 1,
        [StringValue("Nhập lại")]
        NhapLai = 2,
        [StringValue("Đổi các")]
        DoiCac = 3,
        [StringValue("Xuất bán")]
        XuatBan = 4,
        [StringValue("Trả đúng hàng")]
        NguyenTrang = 5
    }
    #endregion

    public enum ItemStatus//Trang thai san pham
    {
        TON = 1,
        NHAP_MOI,
        NHAP_TRA_LAI,
        XUAT_BAN,
        DIEU_CHUYEN,
        HUY
    }
    public enum ReceiptStatus//Trang thai chung tu
    {
        UNLOCK = 1,
        LOCK
    }

    public enum MenuChucNang//Trang thai chung tu
    {
        LAP_ORDER = 1,
        LAP_HOADON
    }
    // trạn thái xử lý khi tiếp nhận yêu cầu khách hàng CRM
    public enum CRM_TiepNhanYeuCau_TrangThai
    {
        [StringValue("Chờ xử lý ")]
        CHO_XU_LY =1,
        [StringValue("Đang Xử Lý")]
        DANG_XU_LY =2,
        [StringValue("Kết Thúc")]
        KET_THUC = 3,
        [StringValue("Đã Xử Lý")]
        HOAN_THANH=4,
        [StringValue("Từ Chối")]
        TU_CHOI=5

    }
    // Loại Hành Động 
    public enum CRM_TiepNhanYeuCau_HanhDong
    {
        [StringValue("Ghi Nhận")]
        GHI_NHAN=1,
        [StringValue("Xác Nhận Xử Lý")]
        XAC_NHAN=2,
        [StringValue("Hoàn Thành")]
        HOAN_THANH=3,
        [StringValue("Từ Chối")]
        TU_CHOI=4,
        [StringValue("Trả Lời Khách")]
        TRA_LOI_KHACH =5,
        [StringValue("Kết Thúc")]
        KET_THUC =6
    }
    public enum CRM_XuLy_TrangThai
    {
        [StringValue("Đang Xử Lý")]
        DANG_Xu_Ly=0,
        [StringValue("Đã Xử Lý")]
        HOAN_THANH=1,
        [StringValue("Bị Từ Chối")]
        TU_CHOI=2,
        [StringValue("Đã Hủy")]
        DA_HUY=3,
        [StringValue("Đã Liên Hệ ") ]
        DA_LIEN_HE = 4
    }
    // sử dụng cho CSKH nợ KM
    public enum CRM_CC_CSKH_NguyenNhanNoKM
    {
        [StringValue("Nợ Chưa Điều Chuyển")]
        NO_CHUA_DIEU_CHUYEN=0,
        [StringValue("Nợ Hãng Chưa Có ")]
        NO_HANG_CHUA_CO=1,
        [StringValue("Nợ Hết Hàng")]
        NO_HET_HANG=2,
        [StringValue("Nợ Khách Chưa Lấy")]
        NO_KHACH_CHUA_Lay =3
        
    }
    public enum CRM_CC_CSKH_TrangThaiXuLyNoKM
    {
        [StringValue("Đã Phân Công ")]
        DA_PHAN_CONG=0,
        [StringValue("Đang Xử Lý")]
        DANG_XU_LY=1,
        [StringValue("Đã Xử Lý")]
        DA_XU_LY=2
    }

    public enum CRM_CC_KICHBANGOI_LOAICAUHOI
    {
        [StringValue("Chọn Một")]
        CHON_MOT =1,
        [StringValue("Chọn Một Hoặc Khác")]
        CHON_MOT_HOAC_KHAC =2,
        [StringValue("Chọn Nhiều ")]
        CHON_NHIEU=3,
        [StringValue("Chọn Nhiều Hoặc Khác")]
        CHON_NHIEU_HOAC_KHAC=4,
        [StringValue("Chọn Khác")]
        CHON_KHAC=5
    }
    // sử dụng cho đợt khảo sát
    public enum CRM_CC_KICHBANGOI_TRANGTHAIDOTKS
    {
        [StringValue("Chờ Phân Công")]
        CHO_PHAN_CONG =1,
        [StringValue("Đã Phân Công")]
        DA_PHAN_CONG = 4,
        [StringValue("Đang Thực Hiện")]
        DANG_THUC_HIEN=2,
        [StringValue("Kết thúc đợt khảo sát")]
        KET_THUC=3
    }
    public enum CRM_CC_KICHBANGOI_TRANGTHAICUOCGOI
    {
        [StringValue("Chờ Thực Hiện Cuộc Gọi")]
        CHO_THUC_HIEN=1,
        [StringValue("Đang Thực Hiện Cuộc Gọi")]
        DANG_THUC_HIEN=2,
        [StringValue("Kết Thúc Cuộc Gọi")]
        KET_THUC=3,
       [StringValue("Sai Số Điện Thoại")]
        SAI_SO_DIEN_THOAI=5,
        [StringValue("Không Liên Lạc Được")]
        KHONG_LIEN_LAC_DUOC = 4
    }
    public enum CRM_CC_DOTDANHGIA_TRANGTHAI
    {
        [StringValue("Chờ Phân Công")]
        CHO_PHAN_CONG=0,
        [StringValue("Đã Phân Công")]
        DA_PHAN_CONG=1,
        [StringValue("Đang Thực Hiện")]
        DANG_THUC_HIEN = 3,
        [StringValue("Hoàn Thành")]
        HOAN_THANH=2
    }
    public enum CRM_CC_TRANGTHAIDOTDANHGIA
    {
        [StringValue("Chờ phân công")]
        CHO_PHAN_CONG=0,
        [StringValue("Đã Phân Công")]
        DA_PHAN_CONG=1,
        [StringValue("Hoàn Thành")]
        HOAN_THANH=2
    }
    public enum CRM_LOG_CUOCGOI
    {
        [StringValue("Gọi Vào")]
        GOI_DEN=0,
        [StringValue("Gọi Ra")]
        GOI_RA=1
    }

    //So sanh 2 transaction tang dan theo do dai
    public class BillCompare : IComparer<ChiTietPhieuXuat>
    {
        public int Compare(ChiTietPhieuXuat x, ChiTietPhieuXuat y)
        {
            return x.TyLeVAT >= y.TyLeVAT ? 1 : 0;
        }
    }

    public struct STKhuyenMai
    {
        public string MaVach;
        public int IdSanPham;
        public string MaSanPham;
        public string TenSanPham;
        public string DonViTinh;
        public int SoLuong;
        public double SoTien;


        public STKhuyenMai(string mv, int idsp, string msp, string tensp, string dvt, int sl, double st)
        {
            this.MaVach = mv;
            this.IdSanPham = idsp;
            this.MaSanPham = msp;
            this.TenSanPham = tensp;
            this.DonViTinh = dvt;
            this.SoLuong = sl;
            this.SoTien = st;
        }
    }

    public class Common
    {

        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);

            return activeProcId == procId;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        // <summary>
        // Chức năng: Kiểm tra chuỗi có null hoặc rỗng hay không
        // </summary>
        // <param name="sValue">Kiểu string, giá trị cần kiểm tra</param>
        // <returns>true nếu rỗng hoặc null, ngược lại trả lại false</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool IsNullOrEmpty(string sValue)
        {
            return (sValue == null) || (sValue.Equals(string.Empty)) || (sValue.Equals(""));
        }

        public static bool Empty(object StringValue)
        {
            string String = (string)StringValue;
            if (String == null || String.Trim().Length == 0)
                return true;

            return false;
        }

        // <summary>
        // Chức năng: Kiểm tra chuỗi nhập vào có phải là số hay không
        // </summary>
        // <param name="stringValue">Kiểu string, giá trị cần kiểm tra</param>
        // <returns>true nếu kiểu số , ngược lại trả lại false</returns>
        // <remarks>

        // Người tạo: Trần Việt Cường
        // Ngày tạo: 2h35 ngày 02/11/2007
        // Người sửa cuối: 
        // </remarks>

        public bool IsNumeric(string s)
        {
            try
            {
                Int32.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool IsNumeric2(string numberString)
        {
            char[] ca = numberString.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (ca[i] > 57 || ca[i] < 48)
                    return false;
            }
            return true;
        }

        internal static bool IsNumeric3(string numberString)
        {
            char[] ca = numberString.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (!char.IsNumber(ca[i]))
                    return false;
            }
            return true;
        }
        public static bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9,.]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
        public static bool IsNumeric4(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        // <summary>
        // Chức năng: Xóa dấu phẩy và dấm chấm trong một chuỗi
        // </summary>
        // <param name="stringValue">Kiểu string, giá trị cần kiểm tra</param>
        // <returns>Giá String không có dấu phẩy và dấu chấm</returns>
        // <remarks>

        // Người tạo: Trần Việt Cường
        // Ngày tạo: 11h ngày 10/11/2007
        // Người sửa cuối: 
        // </remarks>

        public static string ReplaceComDot(string str)
        {
            string str1 = "";
            string str2 = "";
            str1 = Regex.Replace(str.ToString(), ",", "");
            str2 = str1.Replace(".", "");
            return str2;
        }

        // <summary>
        // Chức năng: Kiểm tra chuỗi nhập vào có phải là số nguyên, số thập phân hay không
        // </summary>
        // <param name="stringValue">Kiểu string, giá trị cần kiểm tra</param>
        // <returns>True nếu đúng </returns>
        // <remarks>

        // Người tạo: Trần Việt Cường
        // Ngày tạo: 16h ngày 20/11/2007
        // Người sửa cuối: 
        // </remarks>
        public static bool IsDecimal(string theValue)
        {
            try
            {
                Convert.ToDouble(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsDecimal
        public static bool IsInteger(object theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger

        public static bool IsInteger32(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger32

        public static bool IsInteger16(string theValue)
        {
            try
            {
                Convert.ToInt16(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger16


        public static bool IsInteger64(string theValue)
        {
            try
            {
                Convert.ToInt64(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger64


        // <summary>
        // Chức năng: Chuyển một chuỗi sang giá trị bool
        // </summary>
        // <param name="str">Kiểu string, giá trị cần chuyển</param>
        // <returns>true nếu chuyển được, ngược lại false</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool BoolValue(string str)
        {
            if (((str != null)) & (str != ""))
            {
                try
                {
                    return System.Boolean.Parse(str);
                }
                catch
                {
                    if (str.Equals("1")) return true;
                    return false;
                }
                finally
                {
                }
            }
            return false;
        }

        public static bool BoolValue(object obj)
        {
            if (((obj != null)) & (obj.ToString() != ""))
            {
                try
                {
                    return System.Boolean.Parse(obj.ToString());
                }
                catch
                {
                    if (obj.ToString().Equals("1")) return true;
                    return false;
                }
                finally
                {
                }
            }
            return false;
        }
        // <summary>
        // Chức năng: Chuyển một chuỗi sang giá trị int
        // </summary>
        // <param name="str">Kiểu string, giá trị cần chuyển</param>
        // <returns>0 nếu bị lỗi, ngược lại trả lại giá trị được chuyển</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static int IntValue(string str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                try
                {
                    return System.Int32.Parse(str);
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
         }
        public static double Round(double value)
        {
            return Math.Round(Math.Round(value, 1, MidpointRounding.AwayFromZero), MidpointRounding.AwayFromZero);
        }
        public static int IntValue(object obj)
        {
            try
            {
                return Convert.ToInt32(obj);
            }
            catch
            {
                try
                {
                    return Convert.ToInt32(obj.ToString());
                }
                catch
                {
                    try
                    {
                        return System.Int32.Parse(obj.ToString());
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }
        // <summary>
        // Chức năng: Chuyển một số kiểu double sang string theo định dạng "#,###.##"
        // </summary>
        // <param name="dblValue">Kiểu double, giá trị cần chuyển</param>
        // <returns>chuỗi được chuyển</returns>
        // <remarks>

        public static string Double2Str(double dblValue)
        {
            string rs = dblValue.ToString("N2", Thread.CurrentThread.CurrentCulture );
            if (rs.EndsWith(",00") || rs.EndsWith(".00"))
                rs = rs.Substring(0, rs.Length - 3);
            return rs;
            //string rs = String.Format("{0:#,#.##}", dblValue);
            //return (rs != null && !rs.Equals("")) ? rs : "0";
        }

        public static string Dbl2Str(double dblValue)
        {
            return dblValue.ToString("N2", Thread.CurrentThread.CurrentCulture);
        }

        public static string Integer2Str(int dblValue)
        {
            return dblValue.ToString("N2", Thread.CurrentThread.CurrentCulture);
        }
        // <summary>
        // Chức năng: Chuyển một chuỗi sang giá trị double
        // </summary>
        // <param name="str">Kiểu string, giá trị cần chuyển có định đạng theo chuân en-US(English - United State)</param>
        // <returns>0 nếu bị lỗi, ngược lại trả lại giá trị được chuyển</returns>
        // <remarks>

        // Người tạo: Le Thanh Luong
        // Ngày tạo: 09/10/2007
        // Người sửa cuối: Nguyễn Văn Thuấn
        // Ngày sửa: 20/12/2007
        // </remarks>

        public static double DoubleValue(string str)
        {
            try
            {
                if ((str != null) && (str != ""))
                {
                    return System.Double.Parse(str, Thread.CurrentThread.CurrentCulture);
                    //return System.Double.Parse(str, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static double DoubleValue(object obj)
        {
            try
            {
                if ((obj != null) && (obj.ToString() != ""))
                {
                    return System.Double.Parse(obj.ToString(), Thread.CurrentThread.CurrentCulture);
                    //return System.Double.Parse(str, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static double DoubleValueInt(string str)
        {
            try
            {
                if ((str != null) && (str != ""))
                {
                    return Math.Round(System.Double.Parse(str, Thread.CurrentThread.CurrentCulture), 0);
                    //return System.Double.Parse(str, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public static double DoubleValueInt(object obj)
        {
            try
            {
                if ((obj != null) && (obj.ToString() != ""))
                {
                    return Math.Round(System.Double.Parse(obj.ToString(), Thread.CurrentThread.CurrentCulture), 0);
                    //return System.Double.Parse(str, new System.Globalization.CultureInfo("en-US"));
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        // <summary>
        // Chức năng: Kiểm tra xem chuỗi đó có phải là số double không. Theo chuẩn của en-US(English - United States)

        // </summary>
        // <param name="strDouble">Kiểu string</param>
        // <returns>true nếu chuỗi đó không phải là đạng double, ngược lại trả lại giá trị false</returns>
        // <remarks>

        // Người tạo: Nguyễn Văn Thuấn
        // Ngày tạo: 09/10/2007
        // Người sửa cuối: Nguyễn Văn Thuấn
        // </remarks>
        public static bool ValidateDouble(string strDouble)
        {
            try
            {
                double.Parse(strDouble, Thread.CurrentThread.CurrentCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static string Str2Dbl(string strValue)
        //{
        //    //return System.Double.Parse(strValue);
        //}

        //Lay thu muc hien thoi cua he thong
        public static string GetAppFolderPath()
        {
            //string strStartPath = Environment.CurrentDirectory; 
            string strStartPath = Application.StartupPath;
            if ((strStartPath.EndsWith("\\")))
                strStartPath = strStartPath.Substring(0, strStartPath.Length - 1);
            else if ((strStartPath.EndsWith("Debug")))
                strStartPath = strStartPath.Substring(0, strStartPath.Length - 9);
            else
                strStartPath = strStartPath + "\\";

            return strStartPath;
        }


        public static bool ValidEmail(string strEmail)
        {
            if (strEmail != "")
            {
                //System.Text.RegularExpressions.Regex Expression = new System.Text.RegularExpressions.Regex("\\S+@\\S+\\.\\S+");
                System.Text.RegularExpressions.Regex Expression = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]+([-+_.'][a-zA-Z0-9]+)*@[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*\\.[a-zA-Z0-9]+([-.][a-zA-Z0-9]+)*");

                if (Expression.IsMatch(strEmail) && !strEmail.Contains(","))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        //TuanLM add 29/03/08
        public static bool ValidWebsite(string strWebsite)
        {
            if (strWebsite != "")
            {
                System.Text.RegularExpressions.Regex Expression = new System.Text.RegularExpressions.Regex("http://+\\S+\\.\\S+");
                if (Expression.IsMatch(strWebsite))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        //~TuanLM add 29/03/08

        //Các hàm về ngày tháng năm
        public static string TaoSoPhieuTuDong(string code, string fieldTable, string fieldName)
        {
            DateTime d = DateTime.Now;
            string sDay = (d.Day < 10) ? ("0" + d.Day) : (d.Day + "");
            string sMonth = (d.Month < 10) ? ("0" + d.Month) : (d.Month + "");
            string sYear = d.Year.ToString().Substring(2);

            string sql = String.Format("select top (1) {0} from {1} where {0} like '{2}{3}_{4}{5}{6}_%' order by {0} desc",
                                fieldName, fieldTable, code, Declare.IdTrungTam, sDay, sMonth, sYear);
            string value = DBTools.getValue(sql);
            string serie = "";
            if (value != "")
            {
                int stt = Common.IntValue(value.Substring(value.LastIndexOf("_") + 1)) + 1;
                serie = stt + "";
                string tmp = serie;
                for (int i = 0; i < (Declare.MAXSOPHIEU - tmp.Length); i++)
                    serie = "0" + serie;
            }
            else
            {
                for (int i = 0; i < Declare.MAXSOPHIEU - 1; i++)
                    serie = "0" + serie;
                serie = serie + "1";
            }

            return String.Format("{0}{1}_{2}{3}{4}_{5}", code, Declare.IdKho, sDay, sMonth, sYear, serie);

        }

        public static string Date2LongString(DateTime d)
        {
            if (IsValidDateTime(d))
            {
                return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", d.Year.ToString(), d.Month.ToString(), d.Day.ToString(),
                            d.Hour.ToString(), d.Minute.ToString(), d.Second.ToString(), d.Millisecond.ToString());
            }

            return "";
        }

        public static string DateTime2String(DateTime d)
        {
            if (IsValidDateTime(d))
            {
                return string.Format("{0}/{1}/{2} {3}:{4}:{5}", d.Day.ToString(), d.Month.ToString(), d.Year.ToString(),
                            d.Hour.ToString(), d.Minute.ToString(), d.Second.ToString());
            }

            return "";
        }
        public static string DateTime2LongString(DateTime d)
        {
            if (IsValidDateTime(d))
            {
                return string.Format("{0}:{1} - {2}/{3}/{4}", d.Hour.ToString(), d.Minute.ToString(), d.Day.ToString(),
                                     d.Month.ToString(), d.Year.ToString());
            }

            return "";
        }
        // <summary>
        // Chức năng: Chuyển một giá trị kiểu DateTime sang chuỗi
        // </summary>
        // <param name="dValue">Kiểu DateTime, giá trị cần chuyển</param>
        // <returns>"" nếu bị lỗi, ngược lại trả lại chuỗi được chuyển</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static string Date2String(DateTime dValue)
        {
            if (IsValidDateTime(dValue))
            {
                return dValue.ToString("dd/MM/yyyy");
            }

            return "";
        }

        public static string Date2FullString(DateTime dValue)
        {
            if (IsValidDateTime(dValue))
            {
                return dValue.ToString("dd/MM/yyyy HH:mm:ss");
            }

            return "";
        }

        public static string DateTimeToString(DateTime d)
        {
            if (IsValidDateTime(d))
            {
                return string.Format("{0}/{1}/{2}", d.Day.ToString(), d.Month.ToString(), d.Year.ToString());
            }

            return "";
        }

        public static string DateTimeToLongString(DateTime d)
        {
            if (IsValidDateTime(d))
            {
                return string.Format("{0}/{1}/{2} {3}:{4}:{5}", d.Day.ToString(), d.Month.ToString(), d.Year.ToString(),
                            d.Hour.ToString(), d.Minute.ToString(), d.Second.ToString());
            }

            return "";
        }

        // <summary>
        // Chức năng: Kiểm tra giá trị ngày tháng có hợp lệ hay không
        // </summary>
        // <param name="dValue">Kiểu DateTime, giá trị cần chuyển</param>
        // <returns>true nếu hợp lệ, ngược lại trả lại false</returns>
        // <remarks>

        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 2h ngày 03/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool IsValidDateTime(System.DateTime dValue)
        {
            if ((dValue.CompareTo(System.DateTime.MinValue) > 0))
            {
                if ((dValue.CompareTo(System.DateTime.MaxValue) < 0))
                {
                    return true;
                }
            }

            return false;
        }


        public static string GetCurrentDate()
        {
            string sCurrentDay = System.DateTime.Now.Day.ToString();
            string sCurrentMonth = System.DateTime.Now.Month.ToString();
            string sCurrentYear = System.DateTime.Now.Year.ToString();

            if (sCurrentDay.Length < 2)
                sCurrentDay = "0" + sCurrentDay;
            if (sCurrentMonth.Length < 2)
                sCurrentMonth = "0" + sCurrentMonth;
            while (sCurrentYear.Length < 4)
                sCurrentYear = "0" + sCurrentYear;
            return sCurrentDay + "/" + sCurrentMonth + "/" + sCurrentYear;
        }

        public static string ConvertDate(string sDate)
        {
            string[] arrTemp = sDate.Split(char.Parse("/"));
            if (arrTemp[0].Length < 2)
                arrTemp[0] = "0" + arrTemp[0];
            if (arrTemp[1].Length < 2)
                arrTemp[1] = "0" + arrTemp[1];
            while (arrTemp[2].Length < 4)
                arrTemp[2] = "0" + arrTemp[2];
            return arrTemp[2] + "/" + arrTemp[1] + "/" + arrTemp[0];
        }

        public static System.DateTime ParseDate(string strValue, System.DateTime defaultValue)
        {
            try
            {
                System.Globalization.CultureInfo format = new System.Globalization.CultureInfo("vi-VN", true);
                return System.DateTime.Parse(strValue, format, System.Globalization.DateTimeStyles.NoCurrentDateDefault);
            }
            catch
            {

            }
            return defaultValue;
        }

        public static System.DateTime ParseDate(string strValue)
        {
            return ParseDate(strValue, System.DateTime.MinValue);
        }

        public static System.DateTime DateValueBegin(Object obj)
        {
            DateTime d;
            try
            {
                d = Convert.ToDateTime(obj);
            }
            catch
            {
                d = DateTime.MinValue;
            }

            string strValue = string.Format("{0}/{1}/{2} 0:0:0", d.Day.ToString(), d.Month.ToString(), d.Year.ToString());
            return ParseDate(strValue, System.DateTime.MinValue);
        }
        public static System.DateTime DateValueEnd(Object obj)
        {
            DateTime d;
            try
            {
                d = Convert.ToDateTime(obj);
            }
            catch
            {
                d = DateTime.MinValue;
            }

            string strValue = string.Format("{0}/{1}/{2} 23:59:59", d.Day.ToString(), d.Month.ToString(), d.Year.ToString());
            return ParseDate(strValue, System.DateTime.MinValue);
        }
        public static System.DateTime DateValue(string strValue)
        {
            if (strValue == null || strValue == "")
                return DateTime.MinValue;
            return ParseDate(strValue, System.DateTime.MinValue);
        }

        public static System.DateTime DateValue(object strValue)
        {
            if (strValue == null || strValue.ToString() == "")
                return DateTime.MinValue;
            return ParseDate(strValue.ToString(), System.DateTime.MinValue);
        }
        public static System.DateTime DateValue(DateTime dt)
        {
            if (dt.ToString().Contains("1/1/0001") ||
                dt == DateTime.MinValue)
                return DateTime.Now;

            return dt;
        }
        public static System.DateTime ToDateValue(object strValue)
        {
            DateTime d;
            try
            {
                //System.Globalization.CultureInfo format = new System.Globalization.CultureInfo("vi-VN", true);
                //d = System.DateTime.Parse(strValue.ToString(), format, System.Globalization.DateTimeStyles..NoCurrentDateDefault);
                //DateTimeFormatInfo vnDtfi = new CultureInfo("vi-VN", false).DateTimeFormat;
                //d = Convert.ToDateTime(strValue, vnDtfi);
                d = Convert.ToDateTime(strValue);
            }
            catch
            {
                d = DateTime.MinValue;
                //try
                //{
                //    d = Convert.ToDateTime(strValue);
                //}
                //catch 
                //{
                //    d = DateTime.MinValue;
                //}                
            }
            return d;
        }

        #region Các hàm về ngày tháng năm
        //Lấy ngày từ ngày tháng năm
        public static string GetDayFromDate(string sDate)
        {
            string str = sDate.Substring(0, sDate.IndexOf("/"));
            if (str.Length < 2)
                str = "0" + str;
            return str;
        }

        //Lấy tháng từ ngày tháng năm
        public static string GetMonthFromDate(string sDate)
        {
            string str = sDate.Substring(sDate.IndexOf("/") + 1, sDate.LastIndexOf("/") - sDate.IndexOf("/") - 1);
            if (str.Length < 2)
                str = "0" + str;
            return str;
        }

        //Lấy năm từ ngày tháng năm
        public static string GetYearFromDate(string sDate)
        {
            string str = sDate.Substring(sDate.LastIndexOf("/") + 1, sDate.Length - sDate.LastIndexOf("/") - 1);
            while (str.Length < 4)
                str = "0" + str;
            return str;
        }

        // <summary>
        //  Chức năng: Kiểm tra năm có nhuận
        // </summary>
        // <param name="yyyy">Kiểu int, năm cần kiểm tra</param>
        // <returns>true nếu năm nhuận, ngược lại false</returns>

        // <remarks>
        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 16h ngày 18/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool IsLeapYear(int yyyy)
        {

            if ((yyyy % 4 == 0 && yyyy % 100 != 0) || (yyyy % 400 == 0))
                return true;
            else
                return false;
        }

        // <summary>
        //  Chức năng: Lấy ngày cuối cùng của tháng trong năm
        // </summary>
        // <param name="iMonth">Kiểu int, tháng cần lấy</param>
        // <param name="iYear">Kiểu int, năm cần lấy</param>
        // <returns>Ngày cuối cùng của tháng trong năm</returns>

        // <remarks>
        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 16h ngày 18/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static int LastDayInMonth(int iMonth, int iYear)
        {
            if (iMonth == 1 || iMonth == 3 || iMonth == 5 || iMonth == 7 || iMonth == 8 || iMonth == 10 || iMonth == 12)
                return 31;
            else if (iMonth == 4 || iMonth == 6 || iMonth == 9 || iMonth == 11)
                return 30;
            else
                return IsLeapYear(iYear) ? 29 : 28;
        }

        // <summary>
        //  Chức năng: Kiểm tra ngày tháng năm có hợp lệ hay không
        // </summary>
        // <param name="sDateToCheck">Kiểu string, ngày tháng cần kiểm tra</param>
        // <returns>true nếu hợp lệ, ngược lại false</returns>

        // <remarks>
        // Người tạo: Nguyễn Gia Đăng
        // Ngày tạo: 16h ngày 18/10/2007
        // Người sửa cuối: Nguyễn Gia Đăng
        // </remarks>

        public static bool IsValidDate(string sDateToCheck)
        {
            return true;
            try
            {
                int dayTemp = IntValue(GetDayFromDate(sDateToCheck).ToString());
                int monthTemp = IntValue(GetMonthFromDate(sDateToCheck).ToString());
                int yearTemp = IntValue(GetYearFromDate(sDateToCheck).ToString());

                if (yearTemp > 9999 || yearTemp < 1753 || monthTemp > 12 || monthTemp < 1 || dayTemp > LastDayInMonth(monthTemp, yearTemp) || dayTemp < 1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        // <summary>
        //  Chức năng: So sanh voi ngay hien tai
        // </summary>
        // <param name="sDateToCheck">Kiểu string, ngày tháng cần kiểm tra</param>
        // <returns>1: lon hon, -1: nho hon, 0: bang voi ngay hien tai</returns>

        // <remarks>
        // Người tạo: Le Manh Tuan
        // Ngày tạo: 18h ngày 30/03/2008
        // Người sửa cuối: 
        // </remarks>
        public static int CompareToCurrentDate(string sDateToCheck)
        {
            int intCurrentDay = int.Parse(System.DateTime.Now.Day.ToString());
            int iCurrentMonth = int.Parse(System.DateTime.Now.Month.ToString());
            int iCurrentYear = int.Parse(System.DateTime.Now.Year.ToString());
            int dayTemp = IntValue(GetDayFromDate(sDateToCheck).ToString());
            int monthTemp = IntValue(GetMonthFromDate(sDateToCheck).ToString());
            int yearTemp = IntValue(GetYearFromDate(sDateToCheck).ToString());

            if (yearTemp > iCurrentYear)
                return 1;
            else if (yearTemp < iCurrentYear)
                return -1;
            else if (monthTemp > iCurrentMonth)
                return 1;
            else if (monthTemp < iCurrentMonth)
                return -1;
            else if (dayTemp > intCurrentDay)
                return 1;
            else if (dayTemp < intCurrentDay)
                return -1;
            else
                return 0;
        }
        #endregion

        #region Các hàm đọc số
        public static string ReadOneNumber(string sNumber)
        {
            switch (sNumber)
            {
                case "0": return "không";
                case "1": return "một";
                case "2": return "hai";
                case "3": return "ba";
                case "4": return "bốn";
                case "5": return "năm";
                case "6": return "sáu";
                case "7": return "bảy";
                case "8": return "tám";
                case "9": return "chín";
            }
            return "không";
        }

        public static string ReadTwoNumber(string sNumber)
        {
            string biendoc = " mười ";
            if ((sNumber.Substring(1, 1) == "0") && (sNumber.Substring(0, 1) != "1")) biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " mươi ";
            if (sNumber.Substring(1, 1) != "0")
                switch (sNumber.Substring(1, 1))
                {
                    case "5":
                        if (sNumber.Substring(0, 1) == "1") biendoc = " mười lăm";
                        else biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " mươi lăm";
                        break;
                    case "1":
                        if (sNumber.Substring(0, 1) == "1") biendoc = " mười một";
                        else biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " mươi mốt";
                        break;
                    default:
                        if (sNumber.Substring(0, 1) == "1") biendoc = " mười " + ReadOneNumber(sNumber.Substring(1, 1));
                        else biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " mươi " + ReadOneNumber(sNumber.Substring(1, 1));
                        break;
                }

            return biendoc;
        }

        public static string ReadThreeNumber(string sNumber)
        {
            string biendoc = "trăm";
            if (sNumber.Substring(1, 1) == "0")
            {
                if (sNumber.Substring(2, 1) == "0") biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " trăm ";
                else biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " trăm linh " + ReadOneNumber(sNumber.Substring(2, 1));
                //else biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " trăm lẻ " + ReadOneNumber(sNumber.Substring(2, 1));
            }
            else
            {
                biendoc = ReadOneNumber(sNumber.Substring(0, 1)) + " trăm " + ReadTwoNumber(sNumber.Substring(1, 2));
            }
            return biendoc;
        }


        // hàm xử lý vấn đề số 0
        //private static string xoasokhong(string tam)
        //{
        //    while (tam[0] == '0')
        //    {
        //        if (tam.Length > 1) tam = tam.Substring(1, tam.Length - 1);
        //        else break;
        //    }
        //    return tam;
        //}

        // hàm xử lý chèn các giá trị 

        private static string InsertType(int tam)
        {
            switch (tam)
            {
                //case 0: return "";
                case 0: return " đồng ";
                case 1: return " nghìn ";
                case 2: return " triệu ";
                case 3: return " tỷ ";
            }
            return "đồng ";
        }

        // hàm đọc nhiều số
        public static string ReadMultiNumber(string sNumber)
        {
            int iLeng = sNumber.Length;
            string strDoc = "";
            string strTemp = "";
            int i = 0;
            while ((iLeng) > 3)
            {

                strTemp = ReadThreeNumber(sNumber.Substring(sNumber.Length - 3, 3));
                sNumber = sNumber.Substring(0, sNumber.Length - 3);
                strDoc = strTemp + InsertType(i) + strDoc;
                i++;
                if (i > 3) i = 1;
                if (iLeng > 3) iLeng = iLeng - 3;
            }
            if (iLeng == 1) strDoc = ReadOneNumber(sNumber) + InsertType(i) + strDoc;
            if (iLeng == 2) strDoc = ReadTwoNumber(sNumber) + InsertType(i) + strDoc;
            if (iLeng == 3) strDoc = ReadThreeNumber(sNumber) + InsertType(i) + strDoc;
            return strDoc;
        }

        public static string ConvertNumber2Str(string sNumber)
        {
            sNumber = sNumber.Replace(".", "");
            sNumber = sNumber.Replace(",", "");
            if (sNumber.Length == 1)
                return ReadOneNumber(sNumber) + InsertType(0);
            else if (sNumber.Length == 2)
                return ReadTwoNumber(sNumber) + InsertType(0);
            else if (sNumber.Length == 3)
                return ReadThreeNumber(sNumber) + InsertType(0);
            else
                return ReadMultiNumber(sNumber);
        }

        public static string ReadNumner_(double number)
        {
            NumberReader doc = new NumberReader(number);
            doc.BlockProcessing();
            return doc.ReadThis() + " đồng";
            //return ReadNumber.ByWords(Convert.ToDecimal(number)).Trim() + " đồng";
        }
        public static string ReadNumner_(long number)
        {
            NumberReader doc = new NumberReader(number);
            doc.BlockProcessing();
            return doc.ReadThis() + " đồng";
            //return ReadNumber.ByWords(Convert.ToDecimal(number)).Trim() + " đồng";
        }
        public static string ReadNumner_(string sNumber)
        {
            double dNumber = DoubleValue(sNumber);
            double dNumber1;
            double dNumber2 = dNumber;
            while (dNumber2 >= 10)
            {
                dNumber2 = dNumber2 % 10;
            }
            while (dNumber2 >= 1)
            {
                dNumber2 = dNumber2 - 1;
            }
            dNumber1 = dNumber - dNumber2;
            if (dNumber2 > 0)
                dNumber2 = DoubleValue(Double2Str(dNumber2).Substring(2));
            if (dNumber2 > 0)
            {
                string str = QLBHUtils.DocSo((ulong)dNumber1);
                return str.Substring(0, str.Length) + "chấm " + QLBHUtils.DocSo((ulong)dNumber2).ToLower() + "đồng";
            }
            else
                return QLBHUtils.DocSo((ulong)dNumber1) + "đồng";
        }
        #endregion


        #region "KeyPress_TextBox"
        private const string strChacracterVN = "ÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẨẬÒÓỎÕỌƠỜỚỞỠỢÔỐỒỔỖỘÚÙỦŨỤƯỨỪỬỮỰÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÝỲỶỸỴĐ";
        private const string strChactacterA_Z = "asdfghjklqwertyuiopzxcvbnm";
        private const string strChactacterA_Z1 = "asdfghjklqwertyuiopzxcvbnm.";
        private const string strChacracterNumber = "0123456789";
        public enum strValidate : byte
        {
            STR_TOLOWER = 0,
            STR_TOUPPER,
            STR_ISNUMBER,
            STR_ISDOUBLE,
            STR_CHAR_A_Z_a_z,
            STR_CHAR_A_Z_a_z_SPACE,
            STR_CHAR_A_Z_a_z_0_9,
            STR_CHAR_A_Z_a_z_0_9_AND1,
            STR_CHAR_A_Z_a_z_0_9_AND_,
            STR_CHAR_A_Z_a_z_VN_SPACE,
            STR_CHAR_A_Z_a_z_VN_0_9_SPACE,
            STR_NOT_TWO_SPACE,
            STR_NOT_SPACE,
            STR_PHONE
        }
        private static bool Like(string str1, string str2, string str3)
        {
            bool isCheck = false;
            if (string.Compare(str1, str2) < 0 || string.Compare(str1, str3) > 0)
                isCheck = false;
            else
                isCheck = true;

            return isCheck;
        }
        public static void ValdateCharInTextBox_Keypress(ref object sender, ref System.Windows.Forms.KeyPressEventArgs e, strValidate OptionValidate)
        {
            if (string.Compare(sender.GetType().ToString(), "System.Windows.Forms.TextBox") != 0) return;

            System.Windows.Forms.TextBox txt;
            txt = (System.Windows.Forms.TextBox)sender;

            switch (OptionValidate)
            {
                case strValidate.STR_TOLOWER:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            e.KeyChar = char.Parse(e.KeyChar.ToString().ToLower());
                            return;
                        }
                        break;
                    }
                case strValidate.STR_TOUPPER:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
                            return;
                        }
                        break;
                    }
                case strValidate.STR_CHAR_A_Z_a_z_0_9_AND_:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0 &&
                                strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0 &&
                                Like(e.KeyChar.ToString(), "-", "-") == false)
                            {
                                e.Handled = true;
                                return;
                            }
                        }

                        break;
                    }
                case strValidate.STR_CHAR_A_Z_a_z_0_9_AND1:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0 &&
                                strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0 &&
                                Like(e.KeyChar.ToString(), ".", ".") == false)
                            {
                                e.Handled = true;
                                return;
                            }
                        }

                        break;
                    }
                case strValidate.STR_CHAR_A_Z_a_z_0_9:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0 &&
                                strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    }
                case strValidate.STR_ISNUMBER:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    }
                case strValidate.STR_ISDOUBLE:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0 && e.KeyChar.ToString() != "." && e.KeyChar.ToString() != ",")
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    }
                case strValidate.STR_CHAR_A_Z_a_z:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    }
                case strValidate.STR_CHAR_A_Z_a_z_SPACE:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0 &&
                                Like(e.KeyChar.ToString(), " ", " ") == false)
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    }
                case strValidate.STR_CHAR_A_Z_a_z_VN_SPACE:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0 &&
                                Like(e.KeyChar.ToString(), " ", " ") == false &&
                                (strChacracterVN.IndexOf(e.ToString()) < 0))
                            {
                                e.Handled = true;
                                return;
                            }
                        }
                        break;
                    }

                case strValidate.STR_CHAR_A_Z_a_z_VN_0_9_SPACE:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (strChactacterA_Z.IndexOf(e.KeyChar.ToString().ToLower()) < 0 &&
                                strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0 &&
                                Like(e.KeyChar.ToString(), " ", " ") == false &&
                                (strChacracterVN.IndexOf(e.ToString()) < 0))
                            {
                                e.Handled = true;
                                return;
                            }
                        }

                        break;
                    }
                case strValidate.STR_PHONE:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (Like(e.KeyChar.ToString(), "(", "(") == false &&
                                Like(e.KeyChar.ToString(), ")", ")") == false &&
                                strChacracterNumber.IndexOf(e.KeyChar.ToString()) < 0 &&
                                Like(e.KeyChar.ToString(), "+", "+") == false &&
                                Like(e.KeyChar.ToString(), "-", "-") == false &&
                                Like(e.KeyChar.ToString(), ".", ".") == false)
                            {
                                e.Handled = true;
                                return;
                            }
                        }

                        break;
                    }
                case strValidate.STR_NOT_SPACE:
                    {
                        if (!char.IsControl(e.KeyChar))
                        {
                            if (e.KeyChar.ToString() == " ")
                            {
                                e.Handled = true;
                                return;
                            }
                        }

                        break;
                    }
                case strValidate.STR_NOT_TWO_SPACE:
                    {
                        Int16 iPos;
                        string str = txt.Text;

                        iPos = (Int16)txt.SelectionStart;
                        if (e.KeyChar == char.Parse(" "))
                        {
                            if (str.Trim().Length == 0)
                            {
                                e.Handled = true;
                                return;
                            }
                            else if (str.Trim().Length > 0)
                            {
                                if (iPos == 0)
                                {
                                    e.Handled = true;
                                    return;
                                }
                                else if (iPos > 0)
                                {
                                    if (iPos < str.Length)
                                    {

                                        if (str.Substring(iPos - 1, 1) == " " | str.Substring(iPos, 1) == " ")
                                        {
                                            e.Handled = true;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (str.Substring(iPos - 1, 1) == " ")
                                        {
                                            e.Handled = true;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
            }
        }

        public static void FirstCharacterToUpper(System.Windows.Forms.TextBox objTexbox)
        {
            int iseleStat;
            string str;
            str = objTexbox.Text;
            iseleStat = objTexbox.SelectionStart;
            while (str.IndexOf("  ") >= 0)
            {
                str = str.Replace("  ", " ");
                iseleStat -= 1;
            }

            string[] arr;
            arr = str.Split(char.Parse(" "));
            for (short i = 0; i <= arr.Length - 1; i++)
            {
                if (arr[i].Length == 1)
                {
                    arr[i] = arr[i].ToUpper();
                }
                else if (arr[i].Length > 1)
                {
                    arr[i] = arr[i].Substring(0, 1).ToUpper() + arr[i].Substring(1).ToLower();
                }
            }
            objTexbox.Text = string.Join(" ", arr);
            objTexbox.SelectionStart = iseleStat;
        }
        #endregion

        #region "KeyPress_TextBox"
        [STAThread]
        public static string GetSerialNumber()
        {
            ArrayList hdCollection = new ArrayList();

            ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDrive hd = new HardDrive();
                //hd.Model	= wmi_HD["Model"].ToString();
                //hd.Type		= wmi_HD["InterfaceType"].ToString();

                hdCollection.Add(hd);
            }

            searcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            int i = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hard drive from collection
                // using index
                HardDrive hd = (HardDrive)hdCollection[i];

                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();

                ++i;
            }

            // Display available hard drives
            foreach (HardDrive hd in hdCollection)
            {
                //Console.WriteLine("Model\t\t: " + hd.Model);
                //Console.WriteLine("Type\t\t: " + hd.Type);
                //Console.WriteLine("Serial No.\t: " + hd.SerialNo);
                //Console.WriteLine();
                return hd.SerialNo;
            }

            // Pause application
            //Console.WriteLine("Press [Enter] to exit...");
            //Console.ReadLine();
            return "";
        }
        //TuanLM add 30/03/08
        public static void txtMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Common.ValdateCharInTextBox_Keypress(ref sender, ref e, Common.strValidate.STR_ISNUMBER);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Common.ValdateCharInTextBox_Keypress(ref sender, ref e, Common.strValidate.STR_PHONE);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ngoại lệ: " + ex.Message, Declare.titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //~TuanLM add 30/03/08
        #endregion



        #region "Quan ly Log"
        // <summary>
        // Chức năng: Ghi log người dùng
        // </summary>
        // <param name="sAction">Kiểu string, hành động thực hiện</param>
        // <param name="sContent">Kiểu string, nội dung thực hiện</param>
        // <param name="IdKho">Kiểu int, kho thực hiện</param>
        // <returns>void</returns>
        // <remarks>

        // Người tạo: Lê Mạnh Tuấn
        // Ngày tạo: 11h ngày 05/04/2010
        // Người sửa cuối: Lê Mạnh Tuấn
        // </remarks>

        public static void LogAction(string sAction, string sContent, int IdKho)
        {
            string sql;
            string sTenMay = Declare.TenMay;

            sql = "Insert Into tbl_Nhatky_NguoiDung(IdKho, IdNguoiDung, TenMay, ThoiGian, HanhDong, GhiChu) Values(";
            sql += IdKho + "," + Declare.UserId + ",'" + sTenMay + "',to_timestamp('" + Common.Date2LongString(DateTime.Now) + "','yyyy-MM-dd HH24:MI:SS.FF'),N'" + sAction + "',N'" + sContent + "')";
            DBTools.ExecuteQuery(sql, CommandType.Text);
        }


        // <summary>
        // Chức năng: Ghi log đồng bộ ERP
        // </summary>
        // <param name="sAction">Kiểu string, hành động thực hiện</param>
        // <param name="sContent">Kiểu string, nội dung thực hiện</param>
        // <param name="IdKho">Kiểu int, kho thực hiện</param>
        // <param name="sURL">Kiểu string, địa chỉ ERP đồng bộ</param>
        // <param name="sTrangthai">Kiểu string, trạng thái thực hiện đồng bộ</param>
        // <returns>void</returns>
        // <remarks>
        // Người tạo: Lê Mạnh Tuấn
        // Ngày tạo: 11h ngày 05/04/2010
        // Người sửa cuối: Lê Mạnh Tuấn
        // </remarks>

        public static void LogERPSync(string sAction, string sContent, int IdKho, string sURL, string sTrangthai, DateTime sThoigian)
        {
            string sql;
            string sTenMay = Declare.TenMay;
            sql = "Insert Into tbl_Nhatky_Dongbo_ERP(IdKho, IdNguoiDung, TenMay, DiachiERP, HanhDong, ThoiGian, TrangThai, GhiChu) Values(";
            sql += IdKho + "," + Declare.UserId + ",'" + sTenMay + "','" + sURL + "',N'" + sAction + "',Convert(datetime,'" + Common.Date2LongString(sThoigian) + "',121), N'" + sTrangthai + "',N'" + sContent + "')";
            DBTools.ExecuteQuery(sql, CommandType.Text);
        }
        #endregion

        #region "Quan ly thuoc tinh trong file app.config"

        /// <summary>
        /// Tải toàn bộ các giá trị cấu hình vào bộ nhớ
        /// </summary>
        private static XmlDocument LoadConfig(string ConfigFile)
        {

            XmlDocument xDoc = null;
            XmlNode xRoot = null;
            try
            {
                if (File.Exists(ConfigFile))
                {
                    xDoc = new XmlDocument();
                    xDoc.Load(ConfigFile);
                    //xRoot = xDoc.SelectSingleNode(m_sRootPath);
                }
                else
                {
                    xDoc = new XmlDocument();
                    xDoc.CreateXmlDeclaration("1.0", "UTF-8", "");
                    //Ghi cac thong so ngam dinh o day
                    string[] arr = Declare.ROOT_PATH.Split('/');
                    XmlNode root = null;
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if (arr[i].Length > 0)
                        {
                            if (xRoot == null)
                            {
                                xRoot = xDoc.CreateElement(arr[i]);
                                root = xRoot;
                            }
                            else
                            {
                                XmlNode node = xDoc.CreateElement(arr[i]);
                                xRoot.AppendChild(node);
                                xRoot = node;
                            }
                        }
                    }
                    if (root != null) xDoc.AppendChild(root);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.ToString());
            }
            return xDoc;
        }

        /// <summary>
        /// Lấy tham số
        /// </summary>
        /// <param name="Key">Tên tham số</param>
        /// <returns>Giá trị trả về</returns>
        public static string GetValue(string Key, string Value)
        {
            try
            {
                if (ConfigurationSettings.AppSettings[Key] == null)
                    return Value;
                else
                    return ConfigurationSettings.AppSettings[Key];
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.ToString());
                return Value;
            }
        }
        /// <summary>
        /// Ghi giá trị tham số
        /// </summary>
        /// <param name="Key">Tên tham số</param>
        /// <param name="Value">Giá trị cần ghi</param>
        public static void SetValue(string Key, string Value)
        {
            if (GetValue(Key, "").Equals(Value))
                return;

            // Load into memory the specified config file
            XmlDocument doc = LoadConfig(Declare.CONFIG_FILE);
            // Find the appsettings add nodes
            XmlNodeList nodes = doc.SelectNodes("/configuration/appSettings/add");
            // Set the Value for each node found in app.config
            bool isFound = false;
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["key"].Value == Key)
                {
                    node.Attributes["value"].Value = Value;
                    isFound = true;
                    break;
                }
            }
            //If node no found in app.config, create a new node and set it's value by the Value
            if (!isFound)
            {
                XmlNode node = doc.SelectSingleNode("/configuration/appSettings");
                XmlElement elm = doc.CreateElement("add");
                XmlAttribute att = doc.CreateAttribute("key");
                att.Value = Key;
                elm.Attributes.Append(att);
                att = doc.CreateAttribute("value");
                att.Value = Value;
                elm.Attributes.Append(att);
                node.AppendChild(elm);
            }
            // Save changes back to the file
            doc.Save(Declare.CONFIG_FILE);

        }

        /// <summary>
        /// Lấy về tên máy đang chạy
        /// </summary>
        public static string GetComputerName()
        {
            string hostName = Dns.GetHostName();
            string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            return hostName + "(" + ipAddress + ")";
        }
        /// <summary>
        /// Trả về quyền cho phép thực thi nút lệnh với chứng từ và user hiện tại
        /// </summary>
        /// <param name="IdChungTu">Id chứng từ hiện tại</param>
        public static bool IsEnableCommand(int IdChungTu)
        {
            return true;
        }
        /// <summary>
        /// Trả về quyền cho phép thực thi nút lệnh với phiếu xuất và user hiện tại
        /// </summary>
        /// <param name="IdPhieuXuat">Id phiếu xuất hiện tại</param>
        public static bool IsEnableCommandPX(int IdPhieuXuat)
        {
            string sql = String.Format("Select * from tbl_PhieuXuat where IdPhieuXuat = {0} and ThoigianTao <=  convert(datetime,'{1}',121) and NhapHoaDon = 1 ",
                                        IdPhieuXuat, Common.Date2LongString(Declare.NgayKhoaSo));
            DataTable dtCN = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dtCN != null && dtCN.Rows.Count > 0)
                return false;
            return true;
        }

        /// <summary>
        /// Trả về quyền cho phép thực thi nút lệnh với phiếu xuất và user hiện tại
        /// </summary>
        /// <param name="IdPhieuXuat">Id phiếu xuất hiện tại</param>
        public static bool DaNhapTraLai(int IdPhieuXuat)
        {
            string sql = String.Format("select * from tbl_phieuxuat where sophieuxuatgoc = (select sophieuxuat from tbl_phieuxuat where idphieuxuat={0}) ",
                                        IdPhieuXuat);
            DataTable dtCN = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dtCN != null && dtCN.Rows.Count > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Khóa chức năng nhập số dư đầu
        /// </summary>
        /// <param name="IdPhieuXuat">Id phiếu xuất hiện tại</param>
        public static bool IsEnableNhapDauKy(int IdKho)
        {
            string sql = String.Format("Select * from tbl_DM_Kho where IdKho = {0} and KhoaNhapDauKy =  1", IdKho);
            DataTable dtCN = DBTools.getData("tmp", sql).Tables["tmp"];
            if (dtCN != null && dtCN.Rows.Count > 0)
                return false;
            return true;
        }
        public static void LoadDMChucNang(string GroupCode)
        {
            Declare.ListCN = new List<string>();
            if (Declare.UserName.ToLower().Equals("admin"))
            {
                string[] arrCN = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" };
                foreach (string str in arrCN)
                    Declare.ListCN.Add(str);
            }
            else
            {
                string str = "select cn.MaChucNang " +
                              " from tbl_DM_ChucNang cn " +
                              " inner join tbl_NhomND_ChucNang ndcn on cn.IdChucNang = ndcn.IdChucNang " +
                              " inner join tbl_DM_NhomNguoiDung nd on ndcn.IdNhomNguoiDung = nd.IdNhomNguoiDung " +
                              " where nd.MaNhom = N'" + GroupCode + "'";
                DataTable dtCN = DBTools.getData("tmp", str).Tables["tmp"];
                if (dtCN != null)
                {
                    for (int i = 0; i < dtCN.Rows.Count; i++)
                        Declare.ListCN.Add(dtCN.Rows[i]["MaChucNang"].ToString());

                }
            }
        }

        /// <summary>
        /// Trả về quyền cho phép thực thi nút lệnh user hiện tại
        /// </summary>
        /// <param name="code">mã chức năng</param>
        public static bool IsEnableCommand(string code)
        {
            if (Declare.ListCN.Contains(code))
                return true;
            else
                return false;

        }

        /// <summary>
        /// Trả về ngày dư đầu của từng kho
        /// </summary>
        /// <param name="IdPhieuXuat">Id phiếu xuất hiện tại</param>
        public static DateTime LayNgayDuDau(int IdKho)
        {

            DateTime time = DateTime.Now;
            try
            {
                time = Common.ParseDate(DBTools.getValue("Select NgayDuDau From tbl_DM_Kho Where IdKho = " + IdKho).ToString());
            }
            catch (Exception ex) { }
            return time;
        }
        public static void SetGridViewStyle(DataGridView gr)
        {
            gr.AutoGenerateColumns = false;
            System.Drawing.Color cellBgColor = System.Drawing.Color.FromArgb(224, 224, 224);
            System.Drawing.Color cellEditColor = System.Drawing.Color.FromArgb(255, 255, 255);
            foreach (DataGridViewRow row in gr.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ReadOnly)
                        cell.Style.BackColor = cellBgColor;
                    else
                    {
                        cell.Style.BackColor = cellEditColor;
                    }
                }
            }
        }

        public static void SetGridViewRowStyle(DataGridViewRow row)
        {
            System.Drawing.Color cellBgColor = System.Drawing.Color.FromArgb(224, 224, 224);
            System.Drawing.Color cellEditColor = System.Drawing.Color.FromArgb(255, 255, 255);
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ReadOnly)
                {
                    cell.Style.BackColor = cellBgColor;
                }
                else
                {
                    cell.Style.BackColor = cellEditColor;
                }
            }
        }
        public static void SetGridViewRowErrorStyle(DataGridViewRow row)
        {
            System.Drawing.Color cellBgColor = System.Drawing.Color.Red;
            System.Drawing.Color cellForeColor = System.Drawing.Color.Black;

            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = cellBgColor;
                cell.Style.ForeColor = cellForeColor;
            }
        }

        static void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            Declare.LastAction = DateTime.Now;
        }

        static void Control_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Declare.LastAction = DateTime.Now;
        }

        private static void SetCatchLastAction(Control ctl)
        {
            if (ctl.Name == "frmLogin") return;
            ctl.MouseMove += Control_MouseMove;
            ctl.KeyPress += Control_KeyPress;
            if (ctl.HasChildren)
            {
                foreach (Control control in ctl.Controls)
                {
                    SetCatchLastAction(control);
                }
            }
        }
        /// <summary>
        /// Thay đổi giao diện cho form
        /// </summary>
        /// <param name="frm">Form cần thay đổi</param>
        public static void LoadStyle(System.Windows.Forms.Form frm)
        {
            //System.Drawing.Color bgColor = System.Drawing.Color.FromName("ControlLight");
            //System.Drawing.Color bgColor = System.Drawing.Color.FromArgb(169, 223, 156);
            //System.Drawing.Color bgColor = System.Drawing.Color.FromArgb(218, 221, 247);
            System.Drawing.Color bgColor = System.Drawing.Color.FromArgb(227, 239, 255);
            System.Drawing.Color editColor = System.Drawing.Color.FromArgb(255, 255, 255);
            //System.Drawing.Font font = new System.Drawing.Font("Arial", 9);
            frm.BackColor = bgColor;
            //frm.Font = font;
            RepositoryItemDateEdit repDateTime_bk = new RepositoryItemDateEdit();
            repDateTime_bk.NullDate = DateTime.MinValue;
            repDateTime_bk.NullText = String.Empty;

            if (frm.Name != "frmLogin") SetCatchLastAction(frm);
            
            foreach (Control gr in frm.Controls)
            {
                if (gr is GridControl)
                {
                    foreach (GridView gv in ((GridControl)gr).ViewCollection)
                    {
                        foreach (GridColumn cl in gv.Columns)
                        {
                            if (cl.DisplayFormat.FormatType == FormatType.Numeric)
                            {
                                cl.DisplayFormat.FormatString = "#,#0.##"; // "#,#.##";
                            }
                            else if (cl.DisplayFormat.FormatType == FormatType.DateTime)
                            {
                                cl.ColumnEdit = repDateTime_bk;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control gr1 in gr.Controls)
                    {
                        if (gr1 is GridControl)
                        {
                            foreach (GridView gv1 in ((GridControl)gr1).ViewCollection)
                            {
                                foreach (GridColumn cl1 in gv1.Columns)
                                {
                                    if (cl1.DisplayFormat.FormatType == FormatType.Numeric)
                                    {
                                        cl1.DisplayFormat.FormatString = "#,#0.##";
                                    }
                                    else if (cl1.DisplayFormat.FormatType == FormatType.DateTime)
                                    {
                                        cl1.ColumnEdit = repDateTime_bk;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //luu lai log mo chuc nang
            //LogOpenForm(frm);
        }

        public static void FormatText(System.Windows.Forms.Form frm)
        {

            foreach (Control hien in frm.Controls)
            {
                if (hien is TextBox)
                    hien.Text = hien.Text.Replace("'", "");
                foreach (Control voxinh in hien.Controls)
                {
                    if (voxinh is TextBox)
                        voxinh.Text = voxinh.Text.Replace("'", "");
                    foreach (Control conxinh in voxinh.Controls)
                    {
                        if (conxinh is TextBox)
                            conxinh.Text = conxinh.Text.Replace("'", "");
                    }

                }
            }
        }
        public static void cboItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Các hàm tiện ích
        /// <summary>
        /// Trả về ký hiệu và số serie tiep theo trong quyển
        /// </summary>
        /// <param name="quyen">Quyển hiện tại</param>
        public static bool LoadHoaDon(ref string kyhieu, ref string serie, int quyen, bool show)
        {
            bool rs = false;

            string str = "select distinct KyHieu,KyHieuDau,SoHienTai SoHienTai from tbl_SuDung_HoaDon " +
                  " where SoHienTai<=SoKetThuc and QuyenSo = " + quyen + " and IdNhanVien=" + Declare.IdNhanVien;

            DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                int ind = 0;
                if (dt.Rows.Count > 1 && show)
                {
                    throw new NotImplementedException("Chua thuc hien");
                    //QLBanHang.Forms.frmPhieuXuatHoaDon_ChonKyHieu frm = new QLBanHang.Forms.frmPhieuXuatHoaDon_ChonKyHieu(dt);
                    //if (frm.ShowDialog() == DialogResult.OK)
                    //    ind = frm.iChonKH;
                }
                kyhieu = dt.Rows[ind]["KyHieu"].ToString();
                serie = dt.Rows[ind]["KyHieuDau"].ToString();
                string tmp = dt.Rows[ind]["SoHienTai"].ToString();
                for (int i = 0; i < (Declare.DoDaiHoaDon - tmp.Length); i++)
                    serie += "0";
                serie += tmp;
                rs = true;
            }

            return rs;
        }
        /// <summary>
        /// Kiểm tra xem số serie có hợp lệ hay không
        /// </summary>
        /// <param name="soSerie">Số serie cần kiểm tra</param>
        public static bool CheckHoaDon(string soSerie, int quyen)
        {
            bool rs = false;
            try
            {
                if (soSerie.Length == (3 + Declare.DoDaiHoaDon))
                {
                    string kytudau = soSerie.Substring(0, 3);
                    int sohientai = Common.IntValue(soSerie.Substring(3));
                    string sql = "select KyHieu from tbl_SuDung_HoaDon where QuyenSo=" + quyen +
                                    " and Sobatdau<=" + sohientai + " and SoKetThuc>=" + sohientai +
                                    " and KyHieuDau='" + kytudau + "'";
                    if (DBTools.getValue(sql).Length > 0)
                        rs = true;
                }
            }
            catch (Exception ex) { }
            return rs;
        }

        /// <summary>
        /// Kiểm tra xem số serie có hợp lệ hay không
        /// </summary>
        /// <param name="soSerie">Số serie cần kiểm tra</param>
        public static string LoadNextHoaDon(int stt, int quyen, string kyhieu)
        {
            string serie = "";

            string str = "select KyHieuDau,SoHienTai+" + stt + " SoHienTai from tbl_SuDung_HoaDon " +
                  " where (SoHienTai+" + stt + ")<=SoKetThuc and QuyenSo = " + quyen + " and KyHieu='" + kyhieu + "'";

            DataTable dt = DBTools.getData("tmp", str).Tables["tmp"];

            if (dt != null && dt.Rows.Count > 0)
            {
                serie = dt.Rows[0]["KyHieuDau"].ToString();
                string tmp = dt.Rows[0]["SoHienTai"].ToString();
                for (int i = 0; i < (Declare.DoDaiHoaDon - tmp.Length); i++)
                    serie += "0";
                serie += tmp;
            }

            return serie;
        }

        public static string LoadNextHoaDon(string soseri)
        {
            int next = Common.IntValue(soseri.Substring(3)) + 1;
            string serie = soseri.Substring(0, 3);

            string tmp = next.ToString();
            for (int i = 0; i < (Declare.DoDaiHoaDon - tmp.Length); i++)
                serie += "0";
            serie += tmp;

            return serie;
        }
        /// <summary>
        /// Trả về ngày dư đầu của từng kho
        /// </summary>
        /// <param name="soSerie">Số serie cập nhật</param>
        public static void updateSoHoaDon(string soSerie, int quyen, string kyhieu)
        {
            try
            {
                if (soSerie.Length == (3 + Declare.DoDaiHoaDon))
                {
                    Utils ut = new Utils();
                    int sohientai = Common.IntValue(soSerie.Substring(3)) + 1;
                    string sql = "update tbl_SuDung_HoaDon set SoHienTai = " + sohientai +
                                    " where QuyenSo=" + quyen + " and SoHienTai <= " + sohientai + " and KyHieu='" + kyhieu + "'";
                    DBTools.ExecuteQuery(sql, CommandType.Text);
                }
            }
            catch (Exception ex) { }
        }

        public static void updateSoHoaDon(string soSerie, string kyhieu)
        {
            try
            {
                if (soSerie.Length == (3 + Declare.DoDaiHoaDon))
                {
                    Utils ut = new Utils();
                    int sohientai = Common.IntValue(soSerie.Substring(3)) + 1;
                    int quyen = sohientai / Declare.SoHoaDon_Quyen + 1;
                    string sql = "update tbl_SuDung_HoaDon set SoHienTai = " + sohientai +
                                    " where QuyenSo=" + quyen + " and SoHienTai <= " + sohientai + " and KyHieu='" + kyhieu + "'";
                    DBTools.ExecuteQuery(sql, CommandType.Text);
                }
            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// Gọi webservice động
        /// </summary>
        /// <param name="methodName">Tên phương thức</param>
        /// <param name="args">tập các tham số</param>
        public static object CallWebservice(string methodName, params object[] args)
        {
            try
            {
                if (Declare.WEBSERVICE_URL.Equals("")) return null;
                System.Net.WebClient client = new System.Net.WebClient();
                System.IO.Stream stream = client.OpenRead(Declare.WEBSERVICE_URL + "?wsdl");
                ServiceDescription description = ServiceDescription.Read(stream);

                ///// LOAD THE DOM /////////
                // Initialize a service description importer.
                ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
                importer.ProtocolName = "Soap12"; // Use SOAP 1.2.
                importer.AddServiceDescription(description, null, null);

                // Generate a proxy client.
                importer.Style = ServiceDescriptionImportStyle.Client;
                // Generate properties to represent primitive values.
                importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;

                // Initialize a Code-DOM tree into which we will import the service.
                CodeNamespace nmspace = new CodeNamespace("TransferData");
                CodeCompileUnit unit1 = new CodeCompileUnit();
                unit1.Namespaces.Add(nmspace);
                // Import the service into the Code-DOM tree. This creates proxy code that uses the service.
                ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1);

                //if (warning == 0) // If zero then we are good to go
                //{
                // Generate the proxy code
                CodeDomProvider provider1 = CodeDomProvider.CreateProvider("CSharp");
                // Compile the assembly proxy with the appropriate references
                string[] assemblyReferences = new string[5] { "System.dll", "System.Web.Services.dll", "System.Web.dll", "System.Xml.dll", "System.Data.dll" };
                CompilerParameters parms = new CompilerParameters(assemblyReferences);
                CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1);

                // Finally, Invoke the web service method
                //object wsvcClass = results.CompiledAssembly.CreateInstance(Declare.WEBSERVICE_NAME);
                object wsvcClass = results.CompiledAssembly.CreateInstance("Main");
                MethodInfo mi = wsvcClass.GetType().GetMethod(methodName);
                return mi.Invoke(wsvcClass, args);
                //}
                //else
                //{
                //    return null;
                //}
            }
            catch (Exception ex) { }
            return null;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
        //Get ca ban hang
        public static int GetCaBanHang()
        {
            int hour = DateTime.Now.Hour;
            if (hour > Declare.CaBanHang)
                return 2;
            return 1;
        }
        #endregion

        public static void WriteLog(string pv_sLog)
        {
            EventLogProvider.Instance.WriteOfflineLog(pv_sLog, "Không xác định");
            //File.AppendAllText(Application.StartupPath + "\\QLBH_Log.txt", pv_sLog);
        }

        /// <summary>
        /// Log khi user mở chức năng
        /// </summary>
        /// <param name="frm"></param>
        public static void LogOpenForm(System.Windows.Forms.Form frm)
        {
            try
            {
                if (frm == null) return;
                int idNhatKy = CommonProvider.Instance.LogOpenForm(Declare.IdNhanVien, Declare.UserId, Declare.TenMay, Dns.GetHostName().ToUpper(), frm.Text,
                                                      Declare.UserName, Process.GetCurrentProcess().Id);
                TextBox txtTmpIdNhatKy = new TextBox();
                txtTmpIdNhatKy.Text = idNhatKy.ToString();
                txtTmpIdNhatKy.Name = "txtTmpIdNhatKy";
                txtTmpIdNhatKy.Visible = false;

                frm.Controls.Add(txtTmpIdNhatKy);
                frm.Activated += new EventHandler(LogActivatedForm);
                frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(LogCloseForm);

            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                //File.AppendAllText(Application.StartupPath + "\\QLBH_Log.txt", "Description: " + ex.ToString());
            }

        }

        static void LogActivatedForm(object sender, EventArgs e)
        {
            try
            {
                if(sender is Form)
                {
                    if (Declare.LastMDIChildAction != (sender as Form).Text)
                    {
                        Declare.LastMDIChildAction = (sender as Form).Text;

                        int idNhatKy = CommonProvider.Instance.LogOpenForm(Declare.IdNhanVien, Declare.UserId,
                                                                           Declare.TenMay, Dns.GetHostName().ToUpper(),
                                                                           (sender as Form).Text,
                                                                           Declare.UserName,
                                                                           Process.GetCurrentProcess().Id);

                        var txtTmpIdNhatKy = (TextBox)((Form)sender).Controls["txtTmpIdNhatKy"];

                        if (txtTmpIdNhatKy != null)
                        {
                            txtTmpIdNhatKy.Text = idNhatKy.ToString();
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Application.StartupPath + "\\QLBH_Log.txt", "Description: " + ex.ToString());
            }
        }

        /// <summary>
        /// Log khi user thoat chức năng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void LogCloseForm(object sender, FormClosedEventArgs e)
        {
            try
            {
                TextBox txtTmpIdNhatKy = (TextBox)((Form)sender).Controls["txtTmpIdNhatKy"];
                if (txtTmpIdNhatKy != null)
                {
                    int idNhatKy = Common.IntValue(txtTmpIdNhatKy.Text);
                    CommonProvider.Instance.LogCloseForm(idNhatKy);
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                //File.AppendAllText(Application.StartupPath + "\\QLBH_Log.txt", "Description: " + ex.ToString());
            }
        }
        public static void SelectAllText(object sender)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = ((TextBox)sender).Text.Length;
        }
        public static bool TestBirthDate(DateTime birthdate)
        {
            bool result = true;
            if (birthdate.Year >= DateTime.Now.Year)
                result = false;
            return result;
        }

        public static bool Int2Bool(int value)
        {
            return (value == 0) ? false : true;
        }

        public static int Bool2Int(bool value)
        {
            return value ? 1 : 0;
        }

        public static string StringValue(object obj)
        {
            if (obj == null)
                return "";
            return obj.ToString();
        }

        public static string GetOrderStatus(int orderStatus, int Draft)
        {
            string str = "";
            try
            {
                str = "Trạng thái phiếu: " +
                      StringEnum.GetStringValue((OrderStatus)orderStatus)[0].Name +
                      (Int2Bool(Draft) ? " - Bản nháp {chưa xác nhận}" : "");
            }
            catch
            {
            }

            return str;

            //string[] arg = {
            //                   "[Tạo đơn hàng Online]",
            //                   "[Xác nhận đơn hàng Online]",
            //                   "[Từ chối đơn hàng Online]",
            //                   "[Lập đơn hàng bán Online]",
            //                   "[Tạo đơn đặt hàng trước]",
            //                   "[Lập đơn hàng bán đặt trước]",                               
            //                   "[Lập đơn hàng bán tại Shop]",
            //                   "[Phân công giao nhận]",
            //                   "[Xác nhận đơn hàng giao nhận]",
            //                   "[Từ chối đơn hàng giao nhận]",
            //                   "[Xuất kho]"                               
            //               };
            //return arg[orderStatus - 1];
        }

        public static bool CompareDayOfWeek(int thu, string day)
        {
            string[] arg = {
                               "sunday","monday","tuesday","wednesday","thursday","friday","saturday"
                           };
            return day.ToLower().Equals(arg[thu]);
        }

        public static bool CompareInDate(string from, string to, int hour, int minute)
        {
            try
            {
                string[] arrTimeFrom = from.Split(":".ToCharArray());
                string[] arrTimeTo = to.Split(":".ToCharArray());
                if (hour < Common.IntValue(arrTimeFrom[0]) || hour > Common.IntValue(arrTimeTo[0]))
                    return false;
                if (hour == Common.IntValue(arrTimeFrom[0]) && minute < Common.IntValue(arrTimeFrom[1]))
                    return false;
                if (hour == Common.IntValue(arrTimeTo[0]) && minute > Common.IntValue(arrTimeTo[1]))
                    return false;
            }
            catch
            {
            }
            return true;
        }
        public static bool CompareHours(string from, string to)
        {
            string[] arrTimeFrom = from.Split(":".ToCharArray());
            string[] arrTimeTo = to.Split(":".ToCharArray());
            bool rs = false;

            if (IntValue(arrTimeFrom[0]) != IntValue(arrTimeTo[0]))
                rs = IntValue(arrTimeFrom[0]) > IntValue(arrTimeTo[0]) ? false : true;
            else if (IntValue(arrTimeFrom[1]) != IntValue(arrTimeTo[1]))
                rs = IntValue(arrTimeFrom[1]) > IntValue(arrTimeTo[1]) ? false : true;

            return rs;
        }
        public static string GetTransTypeStatus(int transtype)
        {
            if (transtype == (int)TransactionType.DON_HANG_TAI_SHOP)
                return "Đơn hàng tại siêu thị";
            else if (transtype == (int)TransactionType.DON_HANG_ONLINE)
                return "Đơn hàng Online";
            else if (transtype == (int)TransactionType.DON_HANG_DAT_TRUOC)
                return "Đơn hàng đặt trước";
            else if (transtype == (int)TransactionType.DON_HANG_GIAO_NHAN)
                return "Đơn hàng giao nhận";
            else if (transtype == (int)TransactionType.DON_HANG_BU_KHUYEN_MAI)
                return "Đơn hàng bù khuyến mại";
            return "";
        }

        public static List<TrangThaiBH> GetListLoaiKhachHang()
        {
            return StringEnum.GetStringValue(LoaiKhachHang.KHACH_TRUC_TIEP,
                                             LoaiKhachHang.KHACH_ONLINE);
        }

        public static List<TrangThaiBH> GetListTinhTrangDonHang()
        {
            List<TrangThaiBH> lstDraft = new List<TrangThaiBH>();
            lstDraft.Add(new TrangThaiBH { Id = 0, Name = "Đã xác nhận" });
            lstDraft.Add(new TrangThaiBH { Id = 1, Name = "Nháp(chưa xác nhận)" });
            return lstDraft;
        }
        public static List<TrangThaiBH> GetListLoaiGiaoVan()
        {
            List<TrangThaiBH> lstDuyet = new List<TrangThaiBH>();
            lstDuyet.Add(new TrangThaiBH { Id = 0, Name = "Không giao" });
            lstDuyet.Add(new TrangThaiBH { Id = 1, Name = "Siêu thị giao" });
            lstDuyet.Add(new TrangThaiBH { Id = 2, Name = "Kho tổng giao" });
            return lstDuyet;
        }
        public static List<TrangThaiBH> GetListTrangThaiPhanDon()
        {
            return StringEnum.GetStringValue(TrangThaiPhanDonGiaoNhan.CHUA_PHAN_DON,
                                             TrangThaiPhanDonGiaoNhan.DA_PHAN_DON,
                                             TrangThaiPhanDonGiaoNhan.TU_CHOI_PHAN_DON,
                                             TrangThaiPhanDonGiaoNhan.XAC_NHAN_PHAN_DON);
        }

        public static List<TrangThaiBH> GetListBHTrangThaiPhieu()
        {
            return StringEnum.GetStringValue(BH_TrangThaiPhieu.TiepNhan,
                                             BH_TrangThaiPhieu.DangXuLy, BH_TrangThaiPhieu.DaXuLy,
                                             BH_TrangThaiPhieu.DaTra, BH_TrangThaiPhieu.XuatTraKD,
                                             BH_TrangThaiPhieu.ChoTraKhach, BH_TrangThaiPhieu.ChoHuy,
                                             BH_TrangThaiPhieu.DaHuy);
        }
        public static List<TrangThaiBH> GetListBHTrangThaiItem()
        {
            return StringEnum.GetStringValue(BH_TrangThaiItem.TiepNhan, BH_TrangThaiItem.ChoPhanCong,
                                             BH_TrangThaiItem.DaPhanCong,
                                             BH_TrangThaiItem.DangXuLyBH,
                                             BH_TrangThaiItem.DaBaoHanh,
                                             BH_TrangThaiItem.ChoXuatBH,
                                             BH_TrangThaiItem.XuatBHNhaCC,
                                             BH_TrangThaiItem.GuiNCC, BH_TrangThaiItem.XuatBanNCC,
                                             BH_TrangThaiItem.DaTra, BH_TrangThaiItem.DaKiemTra,
                                             BH_TrangThaiItem.XuatTraKD, BH_TrangThaiItem.ChoTraKhach,
                                             BH_TrangThaiItem.KiThuatDaKiemTra, BH_TrangThaiItem.TraNguyenTrang,
                                             BH_TrangThaiItem.ChoXuLy,
                                             BH_TrangThaiItem.KhoTest,
                                             BH_TrangThaiItem.XuatMuon,
                                             BH_TrangThaiItem.XoaLoi,
                                             BH_TrangThaiItem.Ton,
                                             BH_TrangThaiItem.TraMuon,
                                             BH_TrangThaiItem.TonTraNguyenTrang,
                                             BH_TrangThaiItem.TachCauHinh);
        }
        public static List<TrangThaiBH> GetListBHLoaiPhieu()
        {
            return StringEnum.GetStringValue(BH_LoaiPhieuNhan.DoiKhach,
                                             BH_LoaiPhieuNhan.NoCTy,
                                             BH_LoaiPhieuNhan.NoKhach);
        }
        public static List<TrangThaiBH> GetListBHTrangThaiNhan()
        {
            return StringEnum.GetStringValue(BH_TrangThaiNhan.TamNhan, BH_TrangThaiNhan.HoTro,
                                             BH_TrangThaiNhan.BaoHanh);
        }
        public static List<TrangThaiBH> GetListTinhTrangDuyet()
        {
            return StringEnum.GetStringValue(TinhTrangDuyetGia.CHUA_DUYET,
                                             TinhTrangDuyetGia.DA_DUYET,
                                             TinhTrangDuyetGia.TU_CHOI);
        }
        public static List<TrangThaiBH> GetLoaiChinhSachGia()
        {
            return StringEnum.GetStringValue(LoaiChinhSachGia.THONG_THUONG,
                                             LoaiChinhSachGia.MAC_DINH,
                                             LoaiChinhSachGia.CHIET_KHAU);
        }
        public static List<TrangThaiBH> GetNguonDL()
        {
            List<TrangThaiBH> lstDL = new List<TrangThaiBH>();
            lstDL.Add(new TrangThaiBH { Id = 0, Name = "Chưa đăng ký" });
            lstDL.Add(new TrangThaiBH { Id = 1, Name = "CRM" });
            lstDL.Add(new TrangThaiBH { Id = 2, Name = "POS" });
            lstDL.Add(new TrangThaiBH { Id = 3, Name = "Online" });
            return lstDL;
        }
        public static List<TrangThaiBH> GetGioiTinh()
        {
            List<TrangThaiBH> lstDL = new List<TrangThaiBH>();
            lstDL.Add(new TrangThaiBH { Id = 0, Name = "Không xác định" });
            lstDL.Add(new TrangThaiBH { Id = 1, Name = "Nam" });
            lstDL.Add(new TrangThaiBH { Id = 2, Name = "Nữ" });
            return lstDL;
        }
        public static List<TrangThaiBH> GetListTrangThaiYeuCauThe()
        {
            return StringEnum.GetStringValue(TrangThaiXuLyYeuCauThe.CHO_DUYET,
                                             TrangThaiXuLyYeuCauThe.DA_DUYET,
                                             TrangThaiXuLyYeuCauThe.TU_CHOI,
                                             TrangThaiXuLyYeuCauThe.DA_XU_LY);
        }
        public static List<TrangThaiBH> GetListNhomQuyenHan()
        {
            return StringEnum.GetStringValue(NhomQuyenHan.NhanVien,
                                             NhomQuyenHan.TruongNhom,
                                             NhomQuyenHan.PhuTrach,
                                             NhomQuyenHan.GiamDocSieuThi,
                                             NhomQuyenHan.TruongNganh,
                                             NhomQuyenHan.GiamDocVung,
                                             NhomQuyenHan.BanGiamDoc);
        }
        public static List<TrangThaiBH> GetListLoaiGiaoDichThe()
        {
            return StringEnum.GetStringValue(LoaiGiaoDichThe.CAP_LAI_THE,
                                             LoaiGiaoDichThe.NANG_HANG_THE);
        }
        public static List<TrangThaiBH> GetListTrangThaiCapNhatDiemTichLuy()
        {
            return StringEnum.GetStringValue(TrangThaiXuLyYeuCauThe.CHO_DUYET,
                                             TrangThaiXuLyYeuCauThe.DA_DUYET,
                                             TrangThaiXuLyYeuCauThe.TU_CHOI);
        }
        public static List<TrangThaiBH> GetListLoaiDonHang()
        {
            return StringEnum.GetStringValue(TransactionType.DON_HANG_DAT_TRUOC,
                                             TransactionType.DON_HANG_ONLINE,
                                             TransactionType.DON_HANG_TAI_SHOP,
                                             TransactionType.DON_HANG_GIAO_NHAN,
                                             TransactionType.DON_HANG_BU_KHUYEN_MAI,
                                             TransactionType.TRA_LAI_DON_HANG_BAN);
        }
        public static List<TrangThaiBH> GetListLoaiDonHangNhap()
        {
            return StringEnum.GetStringValue(TransactionType.NHAP_PO,
                                             TransactionType.NHAP_THANH_PHAM_SX,
                                             TransactionType.NHAP_NOIBO);
        }
        public static List<TrangThaiBH> GetListKhungGio()
        {
            List<TrangThaiBH> liKhungGio = new List<TrangThaiBH>();
            liKhungGio.Add(new TrangThaiBH { Id = 7, Name = "7h đến 8h" });
            liKhungGio.Add(new TrangThaiBH { Id = 8, Name = "8h01 đến 9h" });
            liKhungGio.Add(new TrangThaiBH { Id = 9, Name = "9h01 đến 10h" });
            liKhungGio.Add(new TrangThaiBH { Id = 10, Name = "10h01 đến 11h" });
            liKhungGio.Add(new TrangThaiBH { Id = 11, Name = "11h01 đến 12h" });
            liKhungGio.Add(new TrangThaiBH { Id = 12, Name = "12h01 đến 13h" });
            liKhungGio.Add(new TrangThaiBH { Id = 13, Name = "13h01 đến 14h" });
            liKhungGio.Add(new TrangThaiBH { Id = 14, Name = "14h01 đến 15h" });
            liKhungGio.Add(new TrangThaiBH { Id = 15, Name = "15h01 đến 16h" });
            liKhungGio.Add(new TrangThaiBH { Id = 16, Name = "16h01 đến 17h" });
            liKhungGio.Add(new TrangThaiBH { Id = 17, Name = "17h01 đến18h" });
            liKhungGio.Add(new TrangThaiBH { Id = 18, Name = "18h01 đến 19h" });
            liKhungGio.Add(new TrangThaiBH { Id = 19, Name = "19h01 đến 20h" });
            liKhungGio.Add(new TrangThaiBH { Id = 20, Name = "20h01 đến 21h" });
            liKhungGio.Add(new TrangThaiBH { Id = 21, Name = "21h01 đến 22h" });
            liKhungGio.Add(new TrangThaiBH { Id = 22, Name = "22h" });
            liKhungGio.Add(new TrangThaiBH { Id = 0, Name = "Ngoài giờ" });
            return liKhungGio;
        }

        public static List<TrangThaiBH> GetListThuTuan()
        {
            List<TrangThaiBH> liThu = new List<TrangThaiBH>();
            liThu.Add(new TrangThaiBH { Id = 1, Name = "Chủ Nhật" });
            liThu.Add(new TrangThaiBH { Id = 2, Name = "Thứ Hai" });
            liThu.Add(new TrangThaiBH { Id = 3, Name = "Thứ Ba" });
            liThu.Add(new TrangThaiBH { Id = 4, Name = "Thứ Tư" });
            liThu.Add(new TrangThaiBH { Id = 5, Name = "Thứ Năm" });
            liThu.Add(new TrangThaiBH { Id = 6, Name = "Thứ Sáu" });
            liThu.Add(new TrangThaiBH { Id = 7, Name = "Thứ Bảy" });
            return liThu;
        }

        public static List<TrangThaiBH> GetListBCLoaiDonHang()
        {
            return StringEnum.GetStringValue(TransactionType.DON_HANG_DAT_TRUOC,
                                             TransactionType.DON_HANG_ONLINE,
                                             TransactionType.DON_HANG_TAI_SHOP,
                                             TransactionType.DON_HANG_GIAO_NHAN,
                                             TransactionType.DON_HANG_BU_KHUYEN_MAI,
                                             TransactionType.NHAPTRAHANGMUA,
                                             TransactionType.DON_HANG_NHAP_LAI,
                                             TransactionType.DOIMAHANGMUA,
                                             TransactionType.TRA_LAI_DON_HANG_BAN);
        }

        public static List<TrangThaiBH> GetListBCLoaiNhapHang()
        {
            return StringEnum.GetStringValue(TransactionType.NHAP_PO,
                                             TransactionType.NHAP_THANH_PHAM_SX,
                                             TransactionType.NHAP_NOIBO,
                                             TransactionType.NHAP_BAOHANH,
                                             TransactionType.NHAPHANGLOIBHNCC,
                                             TransactionType.DON_HANG_NHAP_LAI,
                                             TransactionType.NHAP_DOIMA);
        }

        public static List<TrangThaiBH> GetListTrangThaiDonHang()
        {
            return StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_ONLINE, OrderStatus.XAC_NHAN_DON_HANG_ONLINE,
                                             OrderStatus.REJECT_DON_HANG_ONLINE, OrderStatus.DON_HANG_BAN_ONLINE,
                                             OrderStatus.TAO_DON_HANG_DAT_TRUOC, OrderStatus.DON_HANG_BAN_DAT_TRUOC,
                                             OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.PHAN_CONG_GIAO_NHAN,
                                             OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN, OrderStatus.REJECT_DON_HANG_GIAO_NHAN,
                                             OrderStatus.XUAT_KHO, OrderStatus.HUY_DON_HANG,
                                             OrderStatus.HUY_DON_HANG_ONLINE, OrderStatus.HUY_DON_HANG_DAT_TRUOC, OrderStatus.DANG_XUAT_KHO,
                                             OrderStatus.TRA_LAI_DON_HANG_BAN, OrderStatus.TRA_LAI_DON_HANG_ONLINE,
                                             OrderStatus.TRA_LAI_DON_HANG_DAT_TRUOC, OrderStatus.TRA_LAI_DON_HANG_XUAT_KHO);
        }
        public static List<TrangThaiBH> GetListBCTrangThaiDonHang()
        {
            return StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_ONLINE, OrderStatus.XAC_NHAN_DON_HANG_ONLINE,
                                             OrderStatus.REJECT_DON_HANG_ONLINE, OrderStatus.DON_HANG_BAN_ONLINE,
                                             OrderStatus.TAO_DON_HANG_DAT_TRUOC, OrderStatus.DON_HANG_BAN_DAT_TRUOC,
                                             OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.PHAN_CONG_GIAO_NHAN,
                                             OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN, OrderStatus.REJECT_DON_HANG_GIAO_NHAN,
                                             OrderStatus.DANG_XUAT_KHO, OrderStatus.XUAT_KHO, OrderStatus.HUY_DON_HANG,
                                             OrderStatus.HUY_DON_HANG_ONLINE, OrderStatus.HUY_DON_HANG_DAT_TRUOC,
                                             OrderStatus.KHOA_DON_HANG_DAT_TRUOC,
                                             OrderStatus.DE_NGHI_TRA_LAI_HANG_BAN, OrderStatus.XAC_NHAN_TRA_LAI_HANG_BAN,
                                             OrderStatus.HUY_DE_NGHI_TRA_LAI, OrderStatus.DE_NGHI_DOI_MA_VACH,
                                             OrderStatus.XAC_NHAN_DOI_MA_VACH, OrderStatus.HUY_DE_NGHI_DOI_MA_VACH,
                                             OrderStatus.XAC_NHAN_TRA_LAI_KHAC,
                                             OrderStatus.TRA_LAI_DON_HANG_BAN, OrderStatus.TRA_LAI_DON_HANG_ONLINE,
                                             OrderStatus.TRA_LAI_DON_HANG_DAT_TRUOC, OrderStatus.TRA_LAI_DON_HANG_XUAT_KHO);
        }
        public static List<TrangThaiBH> GetListTrangThaiTichDiem()
        {
            return StringEnum.GetStringValue(TrangThaiTichDiem.CHUA_TICH_DIEM,
                                             TrangThaiTichDiem.CHO_DUYET_TICH_DIEM,
                                             TrangThaiTichDiem.DA_TICH_DIEM,
                                             TrangThaiTichDiem.DA_XIN_CHIET_KHAU);

        }
        public static List<TrangThaiBH> GetListTrangThaiGiaoVan()
        {
            return StringEnum.GetStringValue(TrangThaiGiaoNhan.CHO_PHAN_CONG,
                                             TrangThaiGiaoNhan.PHAN_CONG,
                                             TrangThaiGiaoNhan.DANG_GIAO_HANG,
                                             TrangThaiGiaoNhan.DA_GIAO_HANG,
                                             TrangThaiGiaoNhan.HUY_GIAO_HANG,
                                             TrangThaiGiaoNhan.NHAP_LAI_HANG);
        }
        public static List<TrangThaiBH> GetListTrangThaiDaGiaoVan()
        {
            return StringEnum.GetStringValue(TrangThaiGiaoNhan.DA_GIAO_HANG,
                                             TrangThaiGiaoNhan.HUY_GIAO_HANG,
                                             TrangThaiGiaoNhan.NHAP_LAI_HANG);
        }
        public static List<TrangThaiBH> GetListLoaiDonHangTraLai()
        {
            return StringEnum.GetStringValue(TransactionType.NHAPTRAHANGMUA,
                                             TransactionType.DON_HANG_NHAP_LAI);
        }
        public static List<TrangThaiBH> GetListTrangThaiDonHangTraLai()
        {
            return StringEnum.GetStringValue(OrderStatus.DE_NGHI_TRA_LAI_HANG_BAN,
                                             OrderStatus.XAC_NHAN_TRA_LAI_HANG_BAN,
                                             OrderStatus.HUY_DE_NGHI_TRA_LAI);
        }
        public static List<TrangThaiBH> GetListTrangThaiBCTraLai()
        {
            return StringEnum.GetStringValue(OrderStatus.DE_NGHI_TRA_LAI_HANG_BAN,
                                             OrderStatus.XAC_NHAN_TRA_LAI_HANG_BAN,
                                             OrderStatus.HUY_DE_NGHI_TRA_LAI,
                                             OrderStatus.HUY_DE_NGHI_DOI_MA_VACH,
                                             OrderStatus.XAC_NHAN_DOI_MA_VACH,
                                             OrderStatus.HUY_DE_NGHI_DOI_MA_VACH,
                                             OrderStatus.TRA_LAI_DON_HANG_BAN);
        }
        public static List<TrangThaiBH> GetListTrangThaiDonHangDoiMaVach()
        {
            return StringEnum.GetStringValue(OrderStatus.DE_NGHI_DOI_MA_VACH,
                                             OrderStatus.XAC_NHAN_DOI_MA_VACH,
                                             OrderStatus.HUY_DE_NGHI_DOI_MA_VACH);
        }
        public static List<TrangThaiBH> GetListTrangThaiDonHang(LoaiGiaoDichBanHang LoaiGiaoDich)
        {
            List<TrangThaiBH> rs = new List<TrangThaiBH>();
            if (LoaiGiaoDich == LoaiGiaoDichBanHang.LAP_DONHANG_BAN)
            {
                rs = StringEnum.GetStringValue(OrderStatus.XAC_NHAN_DON_HANG_ONLINE, OrderStatus.DON_HANG_BAN_ONLINE,
                                               OrderStatus.TAO_DON_HANG_DAT_TRUOC, OrderStatus.DON_HANG_BAN_DAT_TRUOC,
                                               OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.PHAN_CONG_GIAO_NHAN,
                                               OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN, OrderStatus.HUY_DON_HANG);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.XUAT_BU_KHUYEN_MAI)
            {
                rs = StringEnum.GetStringValue(OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.PHAN_CONG_GIAO_NHAN,
                                               OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN, OrderStatus.HUY_DON_HANG);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.LAP_DONHANG_ONLINE)
            {
                rs = StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_ONLINE, OrderStatus.REJECT_DON_HANG_ONLINE, OrderStatus.HUY_DON_HANG_ONLINE);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.DUYET_DONHANG_ONLINE)
            {
                rs = StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_ONLINE, OrderStatus.XAC_NHAN_DON_HANG_ONLINE, OrderStatus.HUY_DON_HANG);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.LAP_DONHANG_DATTRUOC)
            {
                rs = StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_DAT_TRUOC, OrderStatus.HUY_DON_HANG_DAT_TRUOC, OrderStatus.KHOA_DON_HANG_DAT_TRUOC);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.PHANCONG_GIAONHAN)
            {
                rs = StringEnum.GetStringValue(OrderStatus.DON_HANG_BAN_ONLINE, OrderStatus.DON_HANG_BAN_DAT_TRUOC,
                                               OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.PHAN_CONG_GIAO_NHAN,
                                               OrderStatus.REJECT_DON_HANG_GIAO_NHAN);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.XUATKHO_HANGBAN)
            {
                rs = StringEnum.GetStringValue(OrderStatus.DON_HANG_BAN_ONLINE, OrderStatus.DON_HANG_BAN_DAT_TRUOC,
                                               OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN,
                                               OrderStatus.DANG_XUAT_KHO, OrderStatus.XUAT_KHO);
            }
            else if (LoaiGiaoDich == LoaiGiaoDichBanHang.LAP_PHIEUTHU)
            {
                rs = StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_ONLINE, OrderStatus.XAC_NHAN_DON_HANG_ONLINE,
                                                 OrderStatus.DON_HANG_BAN_ONLINE, OrderStatus.TAO_DON_HANG_DAT_TRUOC,
                                                 OrderStatus.DON_HANG_BAN_DAT_TRUOC, OrderStatus.DON_HANG_BAN_TAI_SHOP,
                                                 OrderStatus.PHAN_CONG_GIAO_NHAN, OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN,
                                                 OrderStatus.REJECT_DON_HANG_GIAO_NHAN, OrderStatus.XUAT_KHO);
            }
            else// if (LoaiGiaoDich == LoaiGiaoDichBanHang.LAP_PHIEUTHU)
            {
                rs = StringEnum.GetStringValue(OrderStatus.TAO_DON_HANG_ONLINE, OrderStatus.XAC_NHAN_DON_HANG_ONLINE,
                                               OrderStatus.REJECT_DON_HANG_ONLINE, OrderStatus.DON_HANG_BAN_ONLINE,
                                               OrderStatus.TAO_DON_HANG_DAT_TRUOC, OrderStatus.DON_HANG_BAN_DAT_TRUOC,
                                               OrderStatus.DON_HANG_BAN_TAI_SHOP, OrderStatus.PHAN_CONG_GIAO_NHAN,
                                               OrderStatus.XAC_NHAN_DON_HANG_GIAO_NHAN,
                                               OrderStatus.REJECT_DON_HANG_GIAO_NHAN,
                                               OrderStatus.XUAT_KHO, OrderStatus.HUY_DON_HANG,
                                               OrderStatus.HUY_DON_HANG_ONLINE, OrderStatus.HUY_DON_HANG_DAT_TRUOC,
                                               OrderStatus.KHOA_DON_HANG_DAT_TRUOC,
                                               OrderStatus.DE_NGHI_TRA_LAI_HANG_BAN,OrderStatus.XAC_NHAN_TRA_LAI_HANG_BAN,
                                               OrderStatus.HUY_DE_NGHI_TRA_LAI, OrderStatus.XAC_NHAN_TRA_LAI_KHAC,
                                               OrderStatus.DE_NGHI_DOI_MA_VACH, OrderStatus.XAC_NHAN_DOI_MA_VACH,
                                               OrderStatus.HUY_DE_NGHI_DOI_MA_VACH, OrderStatus.TRA_LAI_DON_HANG_BAN,
                                               OrderStatus.TRA_LAI_DON_HANG_ONLINE,
                                               OrderStatus.TRA_LAI_DON_HANG_DAT_TRUOC,
                                               OrderStatus.TRA_LAI_DON_HANG_XUAT_KHO);
            }

            return rs;
        }
        public static string GetEnumInfor<T>(T enumItem)
        {
            try
            {
                List<TrangThaiBH> liStatus = StringEnum.GetStringValue(enumItem);
                if (liStatus != null && liStatus.Count > 0)
                    return liStatus[0].Name;
            }
            catch {
            }
            return "";
        }

        public static void SetEDControl(bool visible, bool enable, params ToolStripButton[] ctls)
        {
            foreach (ToolStripButton tlb in ctls)
            {
                tlb.Visible = visible;
                tlb.Enabled = enable;
            }
        }

        public static void SetEDControl(bool visible, bool enable, params ToolStripStatusLabel[] ctls)
        {
            foreach (ToolStripStatusLabel tlb in ctls)
            {
                tlb.Visible = visible;
                tlb.Enabled = enable;
            }
        }

        public static void SetEDControl(bool visible, bool enable, params Control[] ctls)
        {
            foreach (Control tlb in ctls)
            {
                tlb.Visible = visible;
                tlb.Enabled = enable;
            }
        }

        public static bool IsEmptyValue(object obj)
        {
            if (obj != null && !obj.ToString().Equals(""))
                return false;
            return true;
        }
        public static double MaxValues(params double[] values)
        {
            double max = values[0];
            for (int i = 1; i < values.Length; i++)
                if (max < values[i])
                    max = values[i];
            return max;
        }
        public static double MinValues(params double[] values)
        {
            double min = values[0];
            for (int i = 1; i < values.Length; i++)
                if (min > values[i])
                    min = values[i];
            return min;
        }

        public static void DevExport2Excel(GridView grid)
        {
            //gChinhSach.ShowPrintPreview();
            string fileName = ShowSaveFileDialog("Kết xuất dữ liệu ...", "Microsoft Excel 2003|*.xls|Microsoft Excel 2007-2010|*.xlsx|Html document|*.html");
            if (fileName != "")
            {
                if (fileName.EndsWith("xls"))
                    ExportTo(new ExportXlsProvider(fileName), grid);
                else if (fileName.EndsWith("xlsx"))
                    ExportTo(new ExportXlsxProvider(fileName), grid);
                else if (fileName.EndsWith("html"))
                    ExportTo(new ExportHtmlProvider(fileName), grid);
                OpenFile(fileName);
            }
        }

        public static void DevExport2Excel(GridView grid, string reportName)
        {
            //gChinhSach.ShowPrintPreview();
            string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel 2003|*.xls|Microsoft Excel 2007-2010|*.xlsx|Html document|*.html");
            if (fileName != "")
            {
                if (fileName.EndsWith("xls"))
                    ExportTo(new ExportXlsProvider(fileName), grid);
                else if (fileName.EndsWith("xlsx"))
                    ExportTo(new ExportXlsxProvider(fileName), grid);
                else if (fileName.EndsWith("html"))
                    ExportTo(new ExportHtmlProvider(fileName), grid);
                OpenFile(fileName);
            }
        }

        //public static string DexExport2Excel<T>(GridView grid, string reportName)
        //{
        //    try
        //    {
        //        string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel|*.xlsx");
        //        if (String.IsNullOrEmpty(fileName)) return "";

        //        ComExcel.Application oXL;
        //        ComExcel.Workbook oWB;
        //        ComExcel.Worksheet oWS;
        //        oXL = new ComExcel.Application();
        //        oWB = oXL.Workbooks.Add(ComExcel.XlWBATemplate.xlWBATWorksheet);//tao moi
        //        oWS = (ComExcel.Worksheet)oWB.Worksheets[1];
        //        //create header
        //        int nCol = grid.Columns.Count;
        //        object[,] header = new object[1, nCol];
        //        for (int i = 0; i < grid.Columns.Count; i++)
        //            header[0, i] = grid.Columns[i].Caption;
        //        //create content
        //        List<T> liContent = (List<T>)grid.DataSource;
        //        if (liContent != null && liContent.Count > 0)
        //        {
        //            int nRow = liContent.Count;
        //            object[,] contents = new object[nRow, nCol];
        //            PropertyInfo[] pros = typeof(T).GetProperties();
        //            //Sinh ngau nhien mang Ex
        //            for (int c = 0; c < nCol; c++)
        //                for (int r = 0; r < nRow; r++)
        //                {
        //                    contents[r, c] = pros[c].GetValue(liContent[r], null);
        //                }

        //            // in mang Ex ra Excel
        //            ComExcel.Range range = (ComExcel.Range)oWS.Cells[1, 1];
        //            range = range.get_Resize(nRow, nCol);
        //            range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, contents);

        //            //Lưu file
        //            oWB.SaveAs(fileName, ComExcel.XlFileFormat.xlExcel12, null, null, false, false,
        //                       ComExcel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
        //            oWB.Close(false, false, false);
        //            oXL.Workbooks.Close();
        //            oXL.Quit();
        //            OpenFile(fileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //    return "";
        //}

        public static string Export2ExcelFromDevGrid<T>(GridView grid, string reportName)
        {
            string rs = "";
            if (grid.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return "";
            }

            string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel 2007-2010|*.xlsx|Microsoft Excel 2003|*.xls|Html document|*.html");
            if (String.IsNullOrEmpty(fileName)) return "";

            Cursor.Current = Cursors.WaitCursor;
            if (fileName.EndsWith("xls"))
            {
                ExportTo(new ExportXlsProvider(fileName), grid);
                OpenFile(fileName);
            }
            else if (fileName.EndsWith("html"))
            {
                ExportTo(new ExportHtmlProvider(fileName), grid);
                OpenFile(fileName);
            }
            else
            {
                CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                    rs = Gen2ExcelFromDevGrid<T>(grid, fileName);
                }
                catch { }

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;                
            }
            
            Cursor.Current = Cursors.Default;

            return rs;
        }
        public static string Export2ExcelFromDevGridTest<T>(GridView grid, string reportName)
        {
            string rs = "";
            if (grid.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return "";
            }

            string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel 2007-2010|*.xlsx|Microsoft Excel 2003|*.xls|Html document|*.html");
            if (String.IsNullOrEmpty(fileName)) return "";

            Cursor.Current = Cursors.WaitCursor;
            if (fileName.EndsWith("xls"))
            {
                ExportTo(new ExportXlsProvider(fileName), grid);
                OpenFile(fileName);
            }
            else if (fileName.EndsWith("html"))
            {
                ExportTo(new ExportHtmlProvider(fileName), grid);
                OpenFile(fileName);
            }
            else
            {
                CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                try
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture =
                        System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                    rs = Gen2ExcelFromDevGridTest<T>(grid, fileName);
                }
                catch { }

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            }

            Cursor.Current = Cursors.Default;

            return rs;
        }

        private static string Gen2ExcelFromDevGrid<T>(GridView grid, string fileName)
        {
            try
            {
                ExportDialog frm = new ExportDialog(grid, false);
                if (frm.ShowDialog() == DialogResult.Cancel) return "";

                fileName = fileName.Substring(0, fileName.IndexOf("."));

                ComExcel.Application oXL;
                ComExcel.Workbook oWB;
                ComExcel.Worksheet oWS;
                oXL = new ComExcel.Application();

                oWB = oXL.Workbooks.Add(ComExcel.XlWBATemplate.xlWBATWorksheet); //tao moi
                //oWB = oXL.Workbooks.Add(Type.Missing);

                if (oWB == null)
                {
                    MessageBox.Show("Lỗi tạo Excel. Kiểm tra lại xem đã cài Office 2007-2010 đúng chưa!");
                    return "";
                }

                oWS = (ComExcel.Worksheet) oWB.Worksheets[1];
                oWS.Cells.Font.Name = "Tahoma";
                oWS.Cells.Font.Size = 9; //.Name = "Tahoma";
                oWS.Cells.MergeCells = false;

                //create header
                List<string> lstCaptionSelected = frm.ListCaptionSelected;
                List<string> lstCaps = new List<string>();
                List<string> lstFields = frm.ListFiledSelected;
                List<PropertyInfo> lstPros = new List<PropertyInfo>();
                for (int i = 0; i < lstFields.Count; i++)
                {
                    PropertyInfo p = typeof(T).GetProperty(lstFields[i]);
                    if (p != null)
                    {
                        lstCaps.Add(lstCaptionSelected[i]);
                        lstPros.Add(p);
                    }
                }

                for (int i = 0; i < lstPros.Count; i++)
                {
                    if (lstPros[i].PropertyType.Name.ToLower().Contains("string") && frm.FormatText)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = "@";
                    }
                    else if (lstPros[i].PropertyType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = frm.FormatDate ? "dd/MM/yyyy HH:mm:ss" : "dd/MM/yyyy";
                    }
                    else if (lstPros[i].PropertyType.Name.ToLower().Contains("int") && frm.FormatInt)
                    {
                        ComExcel.Range rg = (ComExcel.Range) oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0";
                    }
                    else if (lstPros[i].PropertyType.Name.ToLower().Contains("double") && frm.FormatDouble)
                    {
                        ComExcel.Range rg = (ComExcel.Range) oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0.00";
                    }
                }
                
                int nCol = lstCaps.Count;
                object[,] header = new object[1,nCol];
                for (int i = 0; i < nCol; i++)
                    header[0, i] = lstCaps[i];
                ComExcel.Range range = (ComExcel.Range) oWS.Cells[1, 1];
                range = range.get_Resize(1, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, header);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));
                range.Columns.AutoFit();

                //create content
                //int nRow = liContent.Count;
                int nRow = grid.RowCount;
                object[,] contents = new object[nRow,nCol];
                //Sinh ngau nhien mang Ex
                for (int c = 0; c < nCol; c++)
                {
                    for (int r = 0; r < nRow; r++)
                    {
                        Object obj = grid.GetRow(r);
                        if (obj == null) continue;
                        try
                        {
                            contents[r, c] = lstPros[c].GetValue((T)obj, null);
                            if (lstPros[c].PropertyType.Name.ToLower().Contains("datetime"))
                            {
                                DateTime d = ToDateValue(contents[r, c]);
                                if (d == DateTime.MinValue)
                                    contents[r, c] = "";
                                else if (!frm.FormatDate)
                                    contents[r, c] = d.ToString("MM/dd/yyyy");//DateTimeToString(d);
                                else
                                    contents[r, c] = d.ToString("MM/dd/yyyy HH:mm:ss");//DateTimeToLongString(d);
                            }
                            else if (!IsNumber(grid.GetRowCellDisplayText(r, lstPros[c].Name)) &&
                                Convert.ToString(contents[r, c]) != grid.GetRowCellDisplayText(r, lstPros[c].Name))
                            {
                                contents[r, c] = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                            }
                            //else if (lstPros[c].Name.ToLower().Equals("loaichungtu") ||
                            //    lstPros[c].Name.ToLower().Equals("loaigiaodich"))
                            //    contents[r, c] = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                            ////contents[r, c] = GetEnumInfor((TransactionType)contents[r, c]);
                            //else if (lstPros[c].Name.ToLower().Equals("trangthai") ||
                            //        lstPros[c].Name.ToLower().Equals("tinhtranggiaonhan"))// && IsInteger(contents[r, c]))
                            //    contents[r, c] = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                            ////contents[r, c] = GetEnumInfor((OrderStatus)contents[r, c]);
                            ////contents[r, c] = Convert.ChangeType(lstPros[c].GetValue(liContent[r], null),
                        }
                        catch (Exception ex)
                        {
                            Debug.Print(String.Format("{0}-{1}:\r\n{2}", c, r, ex.ToString()));
                        }
                    }
                }
                // in mang Ex ra Excel
                range = (ComExcel.Range) oWS.Cells[2, 1];
                range = range.get_Resize(nRow, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, contents);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                
                for (int i = 0; i < lstPros.Count; i++)
                {
                    if (lstPros[i].PropertyType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.Columns.AutoFit();
                    }
                }

                //Lưu file
                oWB.SaveAs(fileName, ComExcel.XlFileFormat.xlExcel12, null, null, false, false,
                           ComExcel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                oWB.Close(false, false, false);
                oXL.Workbooks.Close();
                oXL.Quit();
                OpenFile(fileName + ".xlsb");
            }
            catch(OutOfMemoryException)
            {
                MessageBox.Show(@"Máy tính của bạn hiện không đủ bộ nhớ để thực hiện thao tác này.
                /r/nHãy đóng bớt các ứng dụng khác để giải phóng tài nguyên cho máy rồi thử lại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo file excel: " + ex.ToString());
                return ex.ToString();
            }
            return "";
        }

        private static string Gen2ExcelFromDevGridTest<T>(GridView grid, string fileName)
        {
            try
            {
                ExportDialog frm = new ExportDialog(grid, false);
                if (frm.ShowDialog() == DialogResult.Cancel) return "";

                fileName = fileName.Substring(0, fileName.LastIndexOf("."));

                ComExcel.Application oXL;
                ComExcel.Workbooks oWBs;
                ComExcel.Workbook oWB;
                ComExcel.Worksheet oWS;
                oXL = new ComExcel.Application();
                oWBs = oXL.Workbooks;
                oWB = oWBs.Add(ComExcel.XlWBATemplate.xlWBATWorksheet); //tao moi
                //oWB = oXL.Workbooks.Add(Type.Missing);

                if (oWB == null)
                {
                    MessageBox.Show("Lỗi tạo Excel. Kiểm tra lại xem đã cài Office 2007-2010 đúng chưa!");
                    return "";
                }

                oWS = (ComExcel.Worksheet)oWB.Worksheets[1];
                oWS.Cells.Font.Name = "Tahoma";
                oWS.Cells.Font.Size = 9; //.Name = "Tahoma";
                oWS.Cells.MergeCells = false;

                //create header
                List<string> lstCaptionSelected = frm.ListCaptionSelected;
                List<string> lstCaps = new List<string>();
                List<string> lstFields = frm.ListFiledSelected;
                List<PropertyInfo> lstPros = new List<PropertyInfo>();
                for (int i = 0; i < lstFields.Count; i++)
                {
                    PropertyInfo p = typeof(T).GetProperty(lstFields[i]);
                    if (p != null)
                    {
                        lstCaps.Add(lstCaptionSelected[i]);
                        lstPros.Add(p);
                    }
                }

                for (int i = 0; i < lstPros.Count; i++)
                {
                    if (lstPros[i].PropertyType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = frm.FormatDate ? "dd/MM/yyyy HH:mm:ss" : "dd/MM/yyyy";
                    }
                    else if (lstPros[i].PropertyType.Name.ToLower().Contains("string") && frm.FormatText)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = "@";
                    }
                    else if (lstPros[i].PropertyType.Name.ToLower().Contains("int") && frm.FormatInt)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0";
                    }
                    else if (lstPros[i].PropertyType.Name.ToLower().Contains("double") && frm.FormatDouble)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0.00";
                    }
                }

                int nCol = lstCaps.Count;
                object[,] header = new object[1, nCol];
                for (int i = 0; i < nCol; i++)
                    header[0, i] = lstCaps[i];
                ComExcel.Range range = (ComExcel.Range)oWS.Cells[1, 1];
                range = range.get_Resize(1, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, header);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));
                range.Columns.AutoFit();

                //create content
                //int nRow = liContent.Count;
                int nRow = grid.RowCount;
                object[,] contents = new object[nRow, nCol];
                frmProgress.Instance.Description = "Đang nạp dữ liệu...";
                frmProgress.Instance.MaxValue = nRow;
                frmProgress.Instance.Value = 0;

                frmProgress.Instance.DoWork(delegate
                                                {
                                                    //Sinh ngau nhien mang Ex
                                                    for (int r = 0; r < nRow; r++) 
                                                    {
                                                        for (int c = 0; c < nCol; c++) 
                                                        {
                                                            Object obj = grid.GetRow(r);

                                                            if (obj == null) continue;
                                                            try
                                                            {
                                                                contents[r, c] = lstPros[c].GetValue((T)obj, null);
                                                                if (lstPros[c].PropertyType.Name.ToLower().Contains("datetime"))
                                                                {
                                                                    DateTime d = ToDateValue(contents[r, c]);
                                                                    if (d == DateTime.MinValue)
                                                                        contents[r, c] = "";
                                                                    else if (!frm.FormatDate)
                                                                        contents[r, c] = d.ToString("MM/dd/yyyy");//DateTimeToString(d);
                                                                    else
                                                                        contents[r, c] = d.ToString("MM/dd/yyyy HH:mm:ss");//DateTimeToLongString(d);
                                                                }
                                                                else if (!IsNumber(grid.GetRowCellDisplayText(r, lstPros[c].Name)) &&
                                                                    Convert.ToString(contents[r, c]) != grid.GetRowCellDisplayText(r, lstPros[c].Name))
                                                                {
                                                                    contents[r, c] = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                                                                }
                                                                else
                                                                {
                                                                    contents[r, c] =
                                                                        contents[r, c].ToString().TrimStart('=').Replace('\n', ' ');
                                                                }
                                                                //else if (lstPros[c].Name.ToLower().Equals("loaichungtu"))
                                                                //    contents[r, c] = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                                                                ////contents[r, c] = GetEnumInfor((TransactionType)contents[r, c]);
                                                                //else if (lstPros[c].Name.ToLower().Equals("trangthai"))// && IsInteger(contents[r, c]))
                                                                //    contents[r, c] = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                                                                ////contents[r, c] = GetEnumInfor((OrderStatus)contents[r, c]);
                                                                ////contents[r, c] = Convert.ChangeType(lstPros[c].GetValue(liContent[r], null),
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Debug.Print(String.Format("{0}-{1}:\r\n{2}", c, r, ex.ToString()));
                                                            }
                                                        }
                                                        frmProgress.Instance.Value = r;
                                                    }

                                                    int oldbatch, batch = 100;
                                                    int step = nRow / batch + (nRow % batch > 0 ? 1 : 0);
                                                    int index = 1;
                                                    object[,] stepContents;
                                                    frmProgress.Instance.MaxValue = step;
                                                    frmProgress.Instance.Value = 0;
                                                    frmProgress.Instance.Description = "Đang export dữ liệu...";
                                                    try
                                                    {
                                                        while (index <= step)
                                                        {
                                                            oldbatch = batch;

                                                            batch = index < step ? batch : nRow % batch;

                                                            if (batch == 0)
                                                            {
                                                                index++; continue;
                                                            }

                                                            stepContents = new object[batch, nCol];
                                                            for (int r = 0; r < batch; r++)
                                                            {
                                                                for (int c = 0; c < nCol; c++)
                                                                {
                                                                    stepContents[r, c] =
                                                                        contents[r + (index - 1)* oldbatch, c] ?? String.Empty;
                                                                }
                                                            }

                                                            bool pass = true;
                                                            
                                                            do
                                                            {
                                                                try
                                                                {
                                                                    pass = true;
                                                                    frmProgress.Instance.Description = "Đang export dữ liệu...";
                                                                    ComExcel.Range range1 = (ComExcel.Range)oWS.Cells[2 + (index - 1) * oldbatch, 1];
                                                                    range1 = range1.get_Resize(batch, nCol);
                                                                    range1.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, stepContents);
                                                                    range1.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                                                                    frmProgress.Instance.Value = index;
                                                                    index++;
                                                                }
                                                                catch (COMException ex)
                                                                {
                                                                    //var msg = String.Empty;
                                                                    //foreach (var stepContent in stepContents)
                                                                    //{
                                                                    //    msg += "," + stepContent;
                                                                    //}
                                                                    //File.AppendAllText(
                                                                    //    AppDomain.CurrentDomain.BaseDirectory +
                                                                    //    "Trace.log", msg + "\r\n");
                                                                    //File.AppendAllText(
                                                                    //    AppDomain.CurrentDomain.BaseDirectory +
                                                                    //    "Trace.log", ex.ToString() + "\r\n");

                                                                    pass = false;
                                                                    EventLogProvider.Instance.WriteLog(new ManagedException(ex.Message, false, grid, fileName).Message, "Export data");
                                                                    frmProgress.Instance.Description = "Lỗi export dữ liệu, đang thử lại...";
                                                                    index--;
                                                                    Thread.CurrentThread.Join(1000);
                                                                }
                                                            } while (!pass);
                                                        }
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        EventLogProvider.Instance.WriteLog(new ManagedException(ex.Message, false, grid, fileName).Message, "Export data");
                                                        throw;
                                                    }

                                                    frmProgress.Instance.Description = "Đã hoàn thành!";
                                                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                                                    frmProgress.Instance.IsCompleted = true;
                                                });
                //for (int c = 0; c < nCol; c++)
                //{
                //    for (int r = 0; r < nRow; r++)
                //    {
                //        range = (ComExcel.Range)oWS.Cells[r + 1, c + 1];
                //        range = range.get_Resize(1, 1);
                //        range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, contents[r, c]);
                //        range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                //    }
                //}
                // in mang Ex ra Excel
                //range = (ComExcel.Range)oWS.Cells[2, 1];
                //range = range.get_Resize(nRow, nCol);
                //range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, contents);
                //range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));

                for (int i = 0; i < lstPros.Count; i++)
                {
                    if (lstPros[i].PropertyType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.Columns.AutoFit();
                    }
                }

                //Lưu file
                oWB.SaveAs(fileName, ComExcel.XlFileFormat.xlExcel12, null, null, false, false,
                           ComExcel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                oWB.Close(false, false, false);
                Marshal.FinalReleaseComObject(oWB);
                oWBs.Close();
                Marshal.FinalReleaseComObject(oWBs);
                oXL.Quit();
                Marshal.FinalReleaseComObject(oXL);
                OpenFile(fileName + ".xlsb");
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(@"Máy tính của bạn hiện không đủ bộ nhớ để thực hiện thao tác này.
                /r/nHãy đóng bớt các ứng dụng khác để giải phóng tài nguyên cho máy rồi thử lại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo file excel: " + ex.ToString());
                return ex.ToString();
            }

            return "";
        }

        public static void Export2XmlFromDevGrid<T>(GridView grid, string fileName)
        {
            ExportDialog frm = new ExportDialog(grid, false);
            if (frm.ShowDialog() == DialogResult.Cancel) return;

            //fileName = fileName.Substring(0, fileName.LastIndexOf(".") < 0 ? fileName.Length : fileName.LastIndexOf("."));

            //create header
            List<string> lstCaptionSelected = frm.ListCaptionSelected;
            List<string> lstCaps = new List<string>();
            List<string> lstFields = frm.ListFiledSelected;
            List<PropertyInfo> lstPros = new List<PropertyInfo>();

            for (int i = 0; i < lstFields.Count; i++)
            {
                PropertyInfo p = typeof(T).GetProperty(lstFields[i]);
                if (p != null)
                {
                    lstCaps.Add(lstCaptionSelected[i]);
                    lstPros.Add(p);
                }
            }

            int nCol = lstCaps.Count;
            int nRow = grid.RowCount;
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = nRow;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.DoWork(
                delegate
                    {
                        var writer = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        
                        writer.WriteStartElement("Table");

                        writer.WriteStartElement("Row");

                        for (var c = 0; c < nCol; c++)
                        {
                            writer.WriteStartElement(String.Format("F{0}", c));

                            writer.WriteString(lstCaps[c]);

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();

                        for (var r = 0; r < nRow; r++)
                        {
                            var obj = grid.GetRow(r);

                            if (obj == null) continue;

                            createNode<T>(grid, r, frm, writer, nCol, lstPros, obj);

                            frmProgress.Instance.Value = r;
                        }

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();

                        frmProgress.Instance.Description = "Đã hoàn thành!";
                        frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                        frmProgress.Instance.IsCompleted = true;
                    });

            if (XtraMessageBox.Show("Bạn có muốn mở file này?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var oldCultureInfo = Thread.CurrentThread.CurrentCulture;

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                ComExcel.Application excelApp = null;
                ComExcel.Workbook wb = null;
                try
                {
                    excelApp = new ComExcel.Application();

                    excelApp.Workbooks.OpenXML(fileName, Type.Missing, ComExcel.XlXmlLoadOption.xlXmlLoadImportToList);

                    wb = excelApp.ActiveWorkbook;

                    excelApp.Visible = true;

                }
                catch (Exception ex)
                {
                    EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Open file xml");

                    if (excelApp != null) excelApp.Quit();

                    XtraMessageBox.Show("Không thể mở file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Thread.CurrentThread.CurrentCulture = oldCultureInfo;
            }
        }

        private static void createNode<T>(ColumnView grid, int rowHandle, ExportDialog frm, XmlWriter writer, int nCol, IList<PropertyInfo> lstPros, object row)
        {
            writer.WriteStartElement("Row");

            for (var c = 0; c < nCol; c++)
            {
                writer.WriteStartElement(String.Format("F{0}", c));

                var value = Convert.ToString(lstPros[c].GetValue((T)row, null));
                
                if (lstPros[c].PropertyType.Name.ToLower().Contains("datetime"))
                {
                    var d = ToDateValue(lstPros[c].GetValue((T)row, null));

                    value = d == DateTime.MinValue
                                ? String.Empty
                                : frm.FormatDate
                                      ? d.ToString("dd/MM/yyyy HH:mm:ss")
                                      : d.ToString("dd/MM/yyyy");
                }
                else if (lstPros[c].PropertyType.Name.ToLower().Contains("int") && frm.FormatInt)
                {
                    value = String.Format("{0:N0}", lstPros[c].GetValue((T) row, null));
                }
                else if ((lstPros[c].PropertyType.Name.ToLower().Contains("double") ||
                    
                    lstPros[c].PropertyType.Name.ToLower().Contains("single")) && frm.FormatDouble)
                {
                    value = String.Format("{0:N2}", lstPros[c].GetValue((T)row, null));
                }
                else if (!IsNumber(grid.GetRowCellDisplayText(rowHandle, lstPros[c].Name)) &&

                    Convert.ToString(lstPros[c].GetValue((T)row, null)) != grid.GetRowCellDisplayText(rowHandle, lstPros[c].Name))
                {
                    value = grid.GetRowCellDisplayText(rowHandle, lstPros[c].Name);
                }

                value = value.Replace("\"", "\"\"")
                                .Replace("\r\n", " ")
                                .Replace("\t", " ");

                value = new Regex("\\s+").Replace(value, " ");

                value = new Regex("\\(\\s+").Replace(value, "(");

                value = new Regex("\\s+\\)").Replace(value, ")");

                writer.WriteString(value);

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        public static void Export2CsvFromDevGrid<T>(GridView grid, string fileName)
        {
            //var currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            //System.Threading.Thread.CurrentThread.CurrentCulture =
            //    System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

            ExportDialog frm = new ExportDialog(grid, false);
            if (frm.ShowDialog() == DialogResult.Cancel) return;

            //fileName = fileName.Substring(0, fileName.LastIndexOf(".") < 0 ? fileName.Length : fileName.LastIndexOf("."));

            //create header
            List<string> lstCaptionSelected = frm.ListCaptionSelected;
            List<string> lstCaps = new List<string>();
            List<string> lstFields = frm.ListFiledSelected;
            List<PropertyInfo> lstPros = new List<PropertyInfo>();

            for (int i = 0; i < lstFields.Count; i++)
            {
                PropertyInfo p = typeof(T).GetProperty(lstFields[i]);
                if (p != null)
                {
                    lstCaps.Add(lstCaptionSelected[i]);
                    lstPros.Add(p);
                }
            }

            int nCol = lstCaps.Count;
            int nRow = grid.RowCount;
            frmProgress.Instance.Description = "Đang nạp dữ liệu...";
            frmProgress.Instance.MaxValue = nRow;
            frmProgress.Instance.Value = 0;
            frmProgress.Instance.DoWork(
                delegate
                {

                    //fileName = String.Format("{0}.csv", fileName);

                    var writer = new StreamWriter(fileName, false, Encoding.UTF8);

                    for (var c = 0; c < nCol; c++)
                    {
                        writer.Write(String.Format("\"{0}\"", lstCaps[c]));

                        writer.Write(c < nCol - 1 ? "," : String.Empty);
                    }

                    writer.WriteLine();

                    writer.Flush();

                    for (var r = 0; r < nRow; r++)
                    {
                        var obj = grid.GetRow(r);

                        if (obj == null) continue;

                        for (var c = 0; c < nCol; c++)
                        {
                            var value = Convert.ToString(lstPros[c].GetValue((T)obj, null));

                            if (lstPros[c].PropertyType.Name.ToLower().Contains("datetime"))
                            {
                                var d = ToDateValue(lstPros[c].GetValue((T)obj, null));

                                value = d == DateTime.MinValue
                                            ? String.Empty
                                            : frm.FormatDate
                                                  ? d.ToString("dd/MM/yyyy HH:mm:ss")
                                                  : d.ToString("dd/MM/yyyy");
                            }
                            else if (lstPros[c].PropertyType.Name.ToLower().Contains("int") && frm.FormatInt)
                            {
                                value = String.Format("{0:N0}", lstPros[c].GetValue((T)obj, null));
                            }
                            else if ((lstPros[c].PropertyType.Name.ToLower().Contains("double") ||

                                      lstPros[c].PropertyType.Name.ToLower().Contains("single")) && frm.FormatDouble)
                            {
                                value = String.Format("{0:N2}", lstPros[c].GetValue((T)obj, null));
                            }
                            else if (!IsNumber(grid.GetRowCellDisplayText(r, lstPros[c].Name)) &&

                                     Convert.ToString(lstPros[c].GetValue((T)obj, null)) !=
                                     grid.GetRowCellDisplayText(r, lstPros[c].Name))
                            {
                                value = grid.GetRowCellDisplayText(r, lstPros[c].Name);
                            }
                            
                            value = value.Replace("\"", "\"\"")
                                .Replace("\r\n", " ")
                                .Replace("\t", " ");

                            value = new Regex("\\s+").Replace(value, " ");

                            value = new Regex("\\(\\s+").Replace(value, "(");

                            value = new Regex("\\s+\\)").Replace(value, ")");

                            writer.Write(String.Format("\"{0}\"", value));

                            writer.Write(c < nCol - 1 ? "," : String.Empty);
                        }

                        writer.WriteLine();

                        writer.Flush();

                        frmProgress.Instance.Value = r;
                    }

                    writer.Close();

                    frmProgress.Instance.Description = "Đã hoàn thành!";
                    frmProgress.Instance.Value = frmProgress.Instance.MaxValue;
                    frmProgress.Instance.IsCompleted = true;
                }
                );

            if (XtraMessageBox.Show("Bạn có muốn mở file này?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var oldCultureInfo = Thread.CurrentThread.CurrentCulture;

                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                ComExcel.Application excelApp = null;
                ComExcel.Workbook wb = null;
                try
                {
                    excelApp = new ComExcel.Application();

                    excelApp.Workbooks.OpenText(fileName, 65001, 1, ComExcel.XlTextParsingType.xlDelimited,
                        ComExcel.XlTextQualifier.xlTextQualifierDoubleQuote, 
                        Type.Missing, Type.Missing, Type.Missing, true, 
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing);

                    wb = excelApp.ActiveWorkbook;

                    excelApp.Visible = true;

                }
                catch(Exception ex)
                {
                    EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Open file csv");

                    if (excelApp != null) excelApp.Quit();
                    
                    XtraMessageBox.Show("Không thể mở file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Thread.CurrentThread.CurrentCulture = oldCultureInfo;
            }
        }

        public static string Export2ExcelFromListObjects<T>(List<T> liSource, string reportName)
        {
            try
            {
                if (liSource == null || liSource.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu!");
                    return "";
                }
                ExportDialog frm = new ExportDialog();
                if (frm.ShowDialog() == DialogResult.Cancel) return "";

                CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

                System.Threading.Thread.CurrentThread.CurrentCulture =
                    System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

                string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel|*.xlsx");
                if (String.IsNullOrEmpty(fileName)) return "";
                fileName = fileName.Substring(0, fileName.IndexOf("."));

                ComExcel.Application oXL;
                ComExcel.Workbook oWB;
                ComExcel.Worksheet oWS;
                oXL = new ComExcel.Application();
                oWB = oXL.Workbooks.Add(ComExcel.XlWBATemplate.xlWBATWorksheet);//tao moi

                oWS = (ComExcel.Worksheet)oWB.Worksheets[1];
                oWS.Cells.Font.Name = "Tahoma";
                oWS.Cells.Font.Size = 9; //.Name = "Tahoma";
                oWS.Cells.MergeCells = false;

                //create header
                PropertyInfo[] pros = typeof(T).GetProperties();

                for (int i = 0; i < pros.Length; i++)
                {
                    if (pros[i].PropertyType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = frm.FormatDate ? "MM/dd/yyyy HH:mm:ss" : "MM/dd/yyyy";
                    }
                    else if (pros[i].PropertyType.Name.ToLower().Contains("string") && frm.FormatText)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = "@";
                    }
                    else if (pros[i].PropertyType.Name.ToLower().Contains("int") && frm.FormatInt)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0";
                    }
                    else if (pros[i].PropertyType.Name.ToLower().Contains("double") && frm.FormatDouble)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0.00";
                    }
                }

                int nCol = pros.Length;
                int nRow = liSource.Count;
                object[,] header = new object[1, nCol];
                for (int i = 0; i < nCol; i++)
                    header[0, i] = pros[i].Name;
                ComExcel.Range range = (ComExcel.Range)oWS.Cells[1, 1];
                range = range.get_Resize(1, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, header);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                range.Columns.AutoFit();

                //create content
                object[,] contents = new object[nRow, nCol];
                //Sinh ngau nhien mang Ex
                for (int c = 0; c < nCol; c++)
                {
                    for (int r = 0; r < nRow; r++)
                    {
                        contents[r, c] = pros[c].GetValue(liSource[r], null);
                    }
                }

                // in mang Ex ra Excel
                range = (ComExcel.Range)oWS.Cells[2, 1];
                range = range.get_Resize(nRow, nCol);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));

                for (int i = 0; i < pros.Length; i++)
                {
                    if (pros[i].PropertyType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.Columns.AutoFit();
                    }
                }
                //Lưu file
                oWB.SaveAs(fileName, ComExcel.XlFileFormat.xlExcel12, null, null, false, false,
                           ComExcel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                oWB.Close(false, false, false);
                oXL.Workbooks.Close();
                oXL.Quit();
                OpenFile(fileName + ".xlsb");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo file excel: " + ex.ToString());
                return ex.ToString();
            }
            return "";
        }
        
        public static string Export2ExcelFromDataSource(DataSet ds, string reportName)
        {
            if (ds == null || ds.Tables.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!");
                return "";
            }

            return Export2ExcelFromDataSource(ds.Tables[0], reportName);
        }

        public static string Export2ExcelFromDataSource(DataTable dt, string reportName)
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu.");

                    return String.Empty;
                }

                ExportDialog frm = new ExportDialog();
                if (frm.ShowDialog() == DialogResult.Cancel) return "";

                CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

                System.Threading.Thread.CurrentThread.CurrentCulture =
                    System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

                string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel|*.xlsx");
                if (String.IsNullOrEmpty(fileName)) return "";
                fileName = fileName.Substring(0, fileName.IndexOf("."));

                ComExcel.Application oXL;
                ComExcel.Workbook oWB;
                ComExcel.Worksheet oWS;
                oXL = new ComExcel.Application();
                oWB = oXL.Workbooks.Add(ComExcel.XlWBATemplate.xlWBATWorksheet);//tao moi
                oWS = (ComExcel.Worksheet)oWB.Worksheets[1];

                oWS.Cells.Font.Name = "Tahoma";
                oWS.Cells.Font.Size = 9; //.Name = "Tahoma";
                oWS.Cells.MergeCells = false;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].DataType.Name.ToLower().Contains("date"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = frm.FormatDate ? "MM/dd/yyyy HH:mm:ss" : "MM/dd/yyyy";
                    }
                    else if (dt.Columns[i].DataType.Name.ToLower().Contains("string") && frm.FormatText)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = "@";
                    }
                    else if (dt.Columns[i].DataType.Name.ToLower().Contains("int") && frm.FormatInt)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0";
                    }
                    else if (dt.Columns[i].DataType.Name.ToLower().Contains("double") && frm.FormatDouble)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0.00";
                    }
                }

                int nCol = dt.Columns.Count;
                int nRow = dt.Rows.Count;
                object[,] header = new object[1, nCol];
                for (int i = 0; i < nCol; i++)
                    header[0, i] = dt.Columns[i].ColumnName;
                ComExcel.Range range = (ComExcel.Range)oWS.Cells[1, 1];
                range = range.get_Resize(1, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, header);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                range.Columns.AutoFit();

                //create content
                object[,] contents = new object[nRow, nCol];
                //Sinh ngau nhien mang Ex
                for (int c = 0; c < nCol; c++)
                {
                    for (int r = 0; r < nRow; r++)
                    {
                        contents[r, c] = dt.Rows[r][c];
                    }
                }

                // in mang Ex ra Excel
                range = (ComExcel.Range)oWS.Cells[2, 1];
                range = range.get_Resize(nRow, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, contents);

                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].DataType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.Columns.AutoFit();
                    }
                }

                //Lưu file
                oWB.SaveAs(fileName, ComExcel.XlFileFormat.xlExcel12, null, null, false, false,
                           ComExcel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                oWB.Close(false, false, false);
                oXL.Workbooks.Close();
                oXL.Quit();
                OpenFile(fileName + ".xlsb");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo file excel: " + ex.ToString());
                return ex.ToString();
            }
            return "";
        }

        public static string Export2ExcelFromDataSource(GridView gridView, string reportName)
        {
            try
            {
                if (gridView.DataSource == null || !(gridView.DataSource is DataView))
                {
                    MessageBox.Show("Không có dữ liệu.");

                    return String.Empty;
                }

                var dt = (gridView.DataSource as DataView).Table;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu.");

                    return String.Empty;
                }

                string fileName = ShowSaveFileDialog(reportName, "Kết xuất dữ liệu ...", "Microsoft Excel 2007-2010|*.xlsx|Microsoft Excel 2003|*.xls|Html document|*.html");
                if (String.IsNullOrEmpty(fileName)) return "";

                Cursor.Current = Cursors.WaitCursor;
                if (fileName.EndsWith("xls"))
                {
                    ExportTo(new ExportXlsProvider(fileName), gridView);
                    OpenFile(fileName);
                    return String.Empty;
                }

                if (fileName.EndsWith("html"))
                {
                    ExportTo(new ExportHtmlProvider(fileName), gridView);
                    OpenFile(fileName);
                    return String.Empty;
                }

                fileName = fileName.Substring(0, fileName.LastIndexOf("."));

                ExportDialog frm = new ExportDialog(gridView, false);

                if (frm.ShowDialog() == DialogResult.Cancel) return "";

                CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

                System.Threading.Thread.CurrentThread.CurrentCulture =
                    System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

                ComExcel.Application oXL;
                ComExcel.Workbook oWB;
                ComExcel.Worksheet oWS;
                oXL = new ComExcel.Application();
                oWB = oXL.Workbooks.Add(ComExcel.XlWBATemplate.xlWBATWorksheet);//tao moi
                oWS = (ComExcel.Worksheet)oWB.Worksheets[1];

                oWS.Cells.Font.Name = "Tahoma";
                oWS.Cells.Font.Size = 9; //.Name = "Tahoma";
                oWS.Cells.MergeCells = false;

                //create header
                List<string> lstCaptionSelected = frm.ListCaptionSelected;
                //List<string> lstCaps = new List<string>();
                List<string> lstFields = frm.ListFiledSelected;


                for (int i = 0; i < lstFields.Count; i++)
                {
                    if (dt.Columns[lstFields[i]] == null) continue;

                    if (dt.Columns[lstFields[i]].DataType.Name.ToLower().Contains("date"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = frm.FormatDate ? "MM/dd/yyyy HH:mm:ss" : "MM/dd/yyyy";
                    }
                    else if (dt.Columns[lstFields[i]].DataType.Name.ToLower().Contains("string") && frm.FormatText)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[1, i + 1];
                        rg.EntireColumn.NumberFormat = "@";
                    }
                    else if (dt.Columns[lstFields[i]].DataType.Name.ToLower().Contains("int") && frm.FormatInt)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0";
                    }
                    else if (dt.Columns[lstFields[i]].DataType.Name.ToLower().Contains("double") && frm.FormatDouble)
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.EntireColumn.NumberFormat = "#,##0.00";
                    }
                }

                int nCol = lstCaptionSelected.Count;
                object[,] header = new object[1, nCol];
                for (int i = 0; i < nCol; i++)
                    header[0, i] = lstCaptionSelected[i];
                ComExcel.Range range = (ComExcel.Range)oWS.Cells[1, 1];
                range = range.get_Resize(1, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, header);
                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(128, 128, 128));
                range.Columns.AutoFit();

                //create content
                int nRow = gridView.RowCount;
                object[,] contents = new object[nRow, nCol];

                //Sinh ngau nhien mang Ex
                for (int c = 0; c < nCol; c++)
                {
                    if (dt.Columns[lstFields[c]] == null) continue;

                    for (int r = 0; r < nRow; r++)
                    {
                        contents[r, c] = dt.Rows[r][lstFields[c]];

                        //if (lstFields[c].ToLower().Equals("loaichungtu"))
                        
                        //    contents[r, c] = gridView.GetRowCellDisplayText(r, lstFields[c]);
                        
                        //else if (lstFields[c].ToLower().Equals("trangthai"))
                        
                        //    contents[r, c] = gridView.GetRowCellDisplayText(r, lstFields[c]);
                    }
                }

                // in mang Ex ra Excel
                range = (ComExcel.Range)oWS.Cells[2, 1];
                range = range.get_Resize(nRow, nCol);
                range.set_Value(ComExcel.XlRangeValueDataType.xlRangeValueDefault, contents);

                range.Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(64, 64, 64));
                for (int i = 0; i < nCol; i++)
                {
                    if (dt.Columns[lstFields[i]] == null) continue;

                    if (dt.Columns[lstFields[i]].DataType.Name.ToLower().Contains("datetime"))
                    {
                        ComExcel.Range rg = (ComExcel.Range)oWS.Cells[2, i + 1];
                        rg.Columns.AutoFit();
                    }
                }

                //Lưu file
                oWB.SaveAs(fileName, ComExcel.XlFileFormat.xlExcel12, null, null, false, false,
                           ComExcel.XlSaveAsAccessMode.xlExclusive, false, false, null, null, null);
                oWB.Close(false, false, false);
                oXL.Workbooks.Close();
                oXL.Quit();
                OpenFile(fileName + ".xlsb");

                System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo file excel: " + ex.ToString());
                return ex.ToString();
            }
            return "";
        }

        private static string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        private static string ShowSaveFileDialog(string filename, string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = title;
            dlg.FileName = filename;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }

        private static void ExportTo(IExportProvider provider, GridView grid)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                BaseExportLink link = grid.CreateExportLink(provider);
                (link as GridViewExportLink).ExpandAll = false;
                link.ExportCellsAsDisplayText = true;
                link.ExportAll = true;
                link.ExportTo(true);
                provider.Dispose();
            }
            catch
            {
            }

            Cursor.Current = currentCursor;
        }

        private static void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show("Bạn có muốn mở file này?", "Export To...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    XtraMessageBox.Show("Không thể mở file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static string GetSoPhieuKM(string soChinhSach, int stt)
        {
            return string.Format("{0}-{1}", soChinhSach, stt);
        }

        public static bool IsOpenForm(string name)
        {
            bool found = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form fm in fc)
            {
                if (fm.Name.Equals(name))
                {
                    found = true;
                    fm.Activate();
                }

            }
            return found;
        }

        public static string MsgProgress(int soLuong)
        {
            string msg = soLuong != -1
                             ? String.Format("Đang nạp dữ liệu ...")
                             : "Đang nạp toàn bộ dữ liệu ...";
            return msg;
        }
        /// <summary>
        /// Copy 2 List
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu của List</typeparam>
        /// <param name="src">List nguồn</param>
        /// <returns>Trả về List được copy</returns>
        //public static List<T> CopyList<T>(List<T> src)
        //{
        //    List<T> dest = new List<T>();
        //    if (src.Count > 0)
        //    {
        //        T[] arr = new T[src.Count];
        //        src.CopyTo(arr);
        //        dest = new List<T>(arr);
        //    }

        //    return dest;
        //}
        /// <summary>
        /// Tra ve thoi gian bat dau tim kiem
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="supperUser"></param>
        /// <returns></returns>
        public static DateTime GetStartTimeToSearch(object obj, int supperUser, string content, bool loadDefault)
        {
            if (supperUser == 1 || !String.IsNullOrEmpty(content) || loadDefault)
                return Convert.ToDateTime(obj);
            else
            {
                if (obj == null)
                    return CommonProvider.Instance.GetSysDate();
                else
                    return Convert.ToDateTime(obj);
            }
        }
        public static DateTime GetStartTimeToSearch(DevExpress.XtraEditors.DateEdit obj, int supperUser, string content, bool loadDefault)
        {
            DateTime time;
            if (supperUser == 1 || !String.IsNullOrEmpty(content) || loadDefault)
                time = Convert.ToDateTime(obj.EditValue);
            else
            {
                if (obj.EditValue == null)
                    time = CommonProvider.Instance.GetSysDate().AddDays(-Declare.TimeToSearch);
                else
                    time = Convert.ToDateTime(obj.EditValue);
                obj.EditValue = time;
            }
            
            return time;
        }
        /// <summary>
        /// Tra ve thoi gian ket thuc tim kiem
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="supperUser"></param>
        /// <returns></returns>
        public static DateTime GetEndTimeToSearch(object obj, int supperUser, string content, bool loadDefault)
        {
            if (supperUser == 1 || !String.IsNullOrEmpty(content) || loadDefault)
                return Convert.ToDateTime(obj);
            else
            {
                if (obj == null)
                    return CommonProvider.Instance.GetSysDate();
                else
                    return Convert.ToDateTime(obj);
            }
        }

        public static DateTime GetEndTimeToSearch(DevExpress.XtraEditors.DateEdit obj, int supperUser, string content, bool loadDefault)
        {
            DateTime time;
            if (supperUser == 1 || !String.IsNullOrEmpty(content) || loadDefault)
                time = Convert.ToDateTime(obj.EditValue);
            else
            {
                if (obj.EditValue == null)
                    time = CommonProvider.Instance.GetSysDate();
                else
                    time = Convert.ToDateTime(obj.EditValue);
                obj.EditValue = time;
            }
            
            return time;
        }
        /// <summary>
        /// Quản lý trạng thái thực hiện chức năng: Save hay Cancel, Close
        /// </summary>
        /// <param name="formName"></param>
        /// <param name="status"></param>
        public static void SetFormStatus(string formName, bool status)
        {
            if (!Declare.FORM_STATUS.Contains(formName))
                Declare.FORM_STATUS.Add(formName, status);
            else
            {
                Declare.FORM_STATUS.Remove(formName);
                Declare.FORM_STATUS.Add(formName, status);
            }
        }
        public static bool GetFormStatus(string formName)
        {
            if (Declare.FORM_STATUS.Contains(formName))
            {
                return Common.BoolValue(Declare.FORM_STATUS[formName]);
            }
            return false;
        }
        public static string GetMaxString(string str, int max)
        {
            if (str.Length > max)
                return str.Substring(0, max) + "...";
            else
                return str;
        }

        public static bool PortInUse(int port)
        {
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipTcpEndPoints = ipProperties.GetActiveTcpListeners();
            IPEndPoint[] ipUdpEndPoints = ipProperties.GetActiveUdpListeners();

            var ipEndPoints = new List<IPEndPoint>();

            ipEndPoints.AddRange(ipTcpEndPoints);
            ipEndPoints.AddRange(ipUdpEndPoints);

            return ipEndPoints.Exists(
                delegate(IPEndPoint match)
                    {
                        return match.Port == port;
                    });
        }

        public static List<int> GetListIntRandom(int dotIn, int soLuong)
        {
            List<int> lstData = new List<int>();
            Random random = new Random();
            int interval = soLuong >= Declare.INTERVAL_RANDOM ? soLuong : Declare.INTERVAL_RANDOM;
            int min = interval * (dotIn - 1) + 1;
            int max = interval * dotIn;

            for (int i=0; i< soLuong; i++)
            {
                int tmp;
                do
                {
                    tmp = random.Next(min, max);
                } while (lstData.Contains(tmp));

                lstData.Add(tmp);
            }

            return lstData;
        }

        public static List<string> GetListStringRandom(int dotIn, int soLuong)
        {
            List<string> lstData = new List<string>();
            List<int> lstInt = new List<int>();
            Random random = new Random();
            
            DateTime now = CommonProvider.Instance.GetSysDate();
            //now.ToString("yyyy/")
            string tmp_prefix = String.Format("{0}{1}", now.ToString("yyMMdd"), 
                                          (dotIn < 10 ? "0" + dotIn.ToString() : dotIn.ToString()));

            char[] charArr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            //tao chuoi tien to: yyyyMMddxx
            StringBuilder rs1 = new StringBuilder();

            for (int i = 0; i < tmp_prefix.Length; i++)
            {
                int ind = Convert.ToInt32(tmp_prefix[i].ToString());
                rs1.Append(charArr[ind]);
            }

            //tao chuoi hau to: 8 ky tu sinh ngau nhien
            for (int i = 0; i < soLuong; i++)
            {
                int tmp;
                do
                {
                    tmp = random.Next(1, Declare.INTERVAL_RANDOM);
                } while (lstInt.Contains(tmp));

                lstInt.Add(tmp);

                string str = tmp.ToString();
                StringBuilder rs2 = new StringBuilder();
                for (int j = 0; j < str.Length; j++)
                {
                    int ind = Convert.ToInt32(str[j].ToString());
                    rs2.Append(charArr[ind]);
                }
                int rest = Declare.DO_DAI_MA_VACH_THE - tmp_prefix.Length - 2 - str.Length;
                for (int j=0; j<rest; j++)
                {
                    rs2.Insert(0, charArr[0]);
                }

                string data = String.Format("%{0}{1}?", rs1.ToString(), rs2.ToString());
                lstData.Add(data);
            }
            return lstData;
        }

        public static bool IsEnableDoiDiemTien(int idTrungTam)
        {
            return true;
            if (ConnectionUtil.Instance.IsUAT == 1)
            {
                return false;

                if (idTrungTam == 0) return true;
                if (String.IsNullOrEmpty(Declare.LstTrungTamADChinhSachThe) ||
                    Declare.LstTrungTamADChinhSachThe.Contains(";" + idTrungTam.ToString() + ";"))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
    }
}
