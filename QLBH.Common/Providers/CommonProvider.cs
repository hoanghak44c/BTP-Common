using System;
using QLBH.Common.DAO;
using QLBH.Core.Exceptions;
using QLBH.Core.Infors;

namespace QLBH.Common.Providers
{
    public class CommonProvider
    {
        private static CommonProvider instance;
        
        private CommonProvider(){}

        public static CommonProvider Instance
        {
            get { return instance ?? (instance = new CommonProvider()); }
        }

        public double GetVersion()
        {
            try
            {
                return CommonDAO.Instance.GetVersion();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public double GetVersionTest()
        {
            try
            {
                return CommonDAO.Instance.GetVersionTest();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public int GetMaxApps()
        {
            try
            {
                return CommonDAO.Instance.GetMaxApps();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public string GetPathTest()
        {
            try
            {
                return CommonDAO.Instance.GetPathTest();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public string GetPath()
        {
            try
            {
                return CommonDAO.Instance.GetPath();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public DateTime GetSysDate()
        {
            try
            {
                return CommonDAO.Instance.GetSysDate();
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false);
            }
        }
        /// <summary>
        /// CHÚ Ý (QUAN TRỌNG): Cần update trạng thái isused trong bảng chỉ mục số phiếu nếu sử dụng số phiếu này!!!!!!!!!!!!!
        /// </summary>
        /// <param name="soPhieuPrefix">Tiền tố của phiếu</param>
        /// <returns>Trả về số phiếu theo định dạng [Tiền tố]-[Mã trung tâm]-[Mã kho]-[Mã nhân viên]-[YYYYMMDD][Số thứ tự:000]</returns>
        public string GetSoPhieu(string soPhieuPrefix)
        {
            try
            {
                //hah: cho nguoi dung option format so phieu
                return CommonDAO.Instance.GetSoPhieu(soPhieuPrefix, Declare.IdTrungTam, Declare.IdKho, Declare.UserId);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, soPhieuPrefix);
            }
        }
        public string GetSoPhieu(string soPhieuPrefix, bool autoGenIfDuplicate)
        {
            try
            {
                if (!autoGenIfDuplicate)
                    //hah: cho nguoi dung option format so phieu
                    return CommonDAO.Instance.GetSoPhieu(soPhieuPrefix, Declare.IdTrungTam, Declare.IdKho, Declare.UserId);

                return CommonDAO.Instance.GetSoPhieu(soPhieuPrefix, Declare.IdTrungTam, Declare.IdKho, Declare.UserId, autoGenIfDuplicate);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, soPhieuPrefix, autoGenIfDuplicate);
            }
        }
        public string GetSoPhieu(string soPhieuPrefix, string tableName, string fieldName)
        {
            try
            {
                //hah: cho nguoi dung option format so phieu
                return CommonDAO.Instance.GetSoPhieu(soPhieuPrefix, tableName, fieldName, Declare.UserId);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, soPhieuPrefix, tableName, fieldName);
            }
        }

        public int LogOpenForm(int idNhanVien, int idNguoiDung, string tenMay, string terminal, string chucNang, string tenDangNhap, int processId)
        {
            try
            {
                return CommonDAO.Instance.LogOpenForm(idNhanVien, idNguoiDung, tenMay, terminal, chucNang, tenDangNhap, processId);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, idNhanVien, idNguoiDung, tenMay, chucNang, tenDangNhap);
            }
        }

        public void LogCloseForm(int idNhatKy)
        {
            try
            {
                CommonDAO.Instance.LogCloseForm(idNhatKy);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, idNhatKy);
            }
        }

        public void LogClientInfo()
        {
            try
            {
                CommonDAO.Instance.LogClientInfo();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public void ClearLogClientInfo()
        {
            try
            {
                CommonDAO.Instance.ClearLogClientInfo();
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false);
            }
        }

        public bool Lock_KiemKe(ILockInfo lockObject)
        {
            try
            {
                return CommonDAO.Instance.Lock_KiemKe(lockObject);
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false, lockObject);
            }
        }

        public void UnLock_KiemKe(ILockInfo lockObject)
        {
            try
            {
                CommonDAO.Instance.UnLock_KiemKe(lockObject);
            }
            catch (Exception ex)
            {
                
                throw new ManagedException(ex.Message, false, lockObject);
            }
        }

        public bool Lock_Tn_YeuCau(ILockInfo lockObject)
        {
            try
            {
                return CommonDAO.Instance.Lock_Tn_YeuCau(lockObject);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, lockObject);
            }
        }

        public void UnLock_Tn_YeuCau(ILockInfo lockObject)
        {
            try
            {
                CommonDAO.Instance.UnLock_Tn_YeuCau(lockObject);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, lockObject);
            }
        }

        public bool Lock_ChungTu(ILockInfo lockObject)
        {
            try
            {
                return CommonDAO.Instance.Lock_ChungTu(lockObject);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, lockObject);
            }
        }

        public void UnLock_ChungTu(ILockInfo lockObject)
        {
            try
            {
                CommonDAO.Instance.UnLock_ChungTu(lockObject);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, lockObject);
            }
        }

        //public bool Lock_ChungTu(ChungTuBaseLockInfo lockObject)
        //{
        //    return CommonDAO.Instance.Lock_ChungTu(lockObject);
        //}

        //public void UnLock_ChungTu(ChungTuBaseLockInfo lockObject)
        //{
        //    CommonDAO.Instance.UnLock_ChungTu(lockObject);
        //}

        public bool Lock_Unlock_ChungTu(ChungTuBaseLockInfo lockObject, int lockid)
        {
            try
            {
                return CommonDAO.Instance.Lock_Unlock_ChungTu(lockObject, lockid);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, lockObject, lockid);
            }
        }

        public bool Lock_Unlock_ChungTu(int idChungTu, int lockid)
        {
            try
            {
                return CommonDAO.Instance.Lock_Unlock_ChungTu(idChungTu, lockid);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, idChungTu, lockid);
            }
        }

        public bool Check_Lock_ChungTu(int idChungTu)
        {
            try
            {
                return CommonDAO.Instance.Check_Lock_ChungTu(idChungTu);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, idChungTu);
            }
        }

        public bool IsKhacTinh()
        {
            try
            {
                return CommonDAO.Instance.IsKhacTinh(Declare.IdTrungTam, Declare.IdTrungTamHachToan);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false);
            }
        }

        public bool IsKhacTinh(int idTrungTam1, int idTrungTam2)
        {
            try
            {
                return CommonDAO.Instance.IsKhacTinh(idTrungTam1, idTrungTam2);
            }
            catch (Exception ex)
            {

                throw new ManagedException(ex.Message, false, idTrungTam1, idTrungTam2);
            }
        }
    }
}
