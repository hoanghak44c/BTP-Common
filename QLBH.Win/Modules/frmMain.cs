using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using QLBanHang.Modules.HeThong;
using QLBanHang.Modules.HeThong.Infors;
using QLBH.Common;
using QLBH.Common.Providers;
using QLBH.Core;
using QLBH.Core.Data;
using QLBH.Core.Exceptions;
using QLBH.Core.Form;
using QLBH.Core.Providers;
using QLBH.Core.Version;

namespace QLBanHang.Modules
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private DateTime lastAction = DateTime.Now;
        private bool closedByTimeOut = false;

        public frmMain()
        {
            InitializeComponent();
            //this.SuspendLayout();
            //Common.LoadStyle(this);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ////this.BackgroundImage = Resources.bg;
            this.Closing += new CancelEventHandler(frmMain_Closing);
        }

        void CheckTimeOut()
        {
            //while (!closedByTimeOut)
            //{
            if (Declare.Authenticating == 1) return;

            if (ConnectionUtil.Instance.HasTransaction ||
                (frmProgress.Instance.IsHandleCreated && !frmProgress.Instance.IsCompleted))
            {
                Declare.LastAction = DateTime.Now;
            }

            if (Declare.LastAction < ConnectionUtil.Instance.LastTimeQuery)
            {
                Declare.LastAction = ConnectionUtil.Instance.LastTimeQuery;
            }

            if (Declare.LastAction.AddMinutes(Declare.LOGIN_TIMEOUT) < DateTime.Now)
            {
                //CallCenter.Instance.Stop();

                //unload plugins
                foreach (string notify in Declare.NotifierPlugins.Notifies)
                {
                    ((NotifiyBase)QLBHUtils.GetObject(notify)).Stop();
                }

                CommonProvider.Instance.ClearLogClientInfo();

                closedByTimeOut = false;
                //this.Close();

                int userId = Declare.UserId;
                int trungTamHachToan = Declare.IdTrungTamHachToan;
                int idKho = Declare.IdKho;

                ConnectionUtil.Instance.CloseConnections();

                DialogResult dialogResult = DialogResult.Cancel;

                frmLogin objLG;

                do
                {
                    objLG = new frmLogin(Declare.UserName);

                    Declare.Authenticating = 1;

                    dialogResult = objLG.ShowDialog(this);

                    if (dialogResult == DialogResult.Cancel)
                    {
                        if (MessageBox.Show(this,

                            "Bạn có chắc chắn đóng phiên làm việc này không?",

                            "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            closedByTimeOut = true;

                            break;
                        }
                    }
                    else if (dialogResult == DialogResult.OK)
                    {
                        closedByTimeOut = false;

                        try
                        {
                            CommonProvider.Instance.LogClientInfo();

                            if (userId != Declare.UserId ||
                                trungTamHachToan != Declare.IdTrungTamHachToan ||
                                idKho != Declare.IdKho)
                            {
                                if (MessageBox.Show(this, "Tài khoản đăng nhập không còn phù hợp với phiên làm việc cũ. Bạn có muốn tiếp tục không?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                                    == DialogResult.No)
                                {
                                    dialogResult = DialogResult.Cancel;

                                    continue;
                                }

                                for (int i = Application.OpenForms.Count - 1; i > 0; i--)
                                {
                                    if (!Application.OpenForms[i].Equals(this))

                                        Application.OpenForms[i].Close();
                                }

                                this.SetPermission();
                                //CallCenter.Instance.Stop();
                                //CallCenter.Instance.Start();
                            }

                            Declare.Authenticating = 0;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                            dialogResult = DialogResult.Cancel;
                        }
                    }
                    else
                    {
                        closedByTimeOut = true;
                    }

                } while (dialogResult == DialogResult.Cancel);

                //frmLogin objLG = new frmLogin(Declare.UserName);

                //DialogResult dialogResult = objLG.ShowDialog(this);

                //if (dialogResult == DialogResult.Cancel)
                //{
                //    DialogResult result = DialogResult.No;
                //    while (result == DialogResult.No)
                //    {
                //        if (objLG.ClosedByTimeOut)
                //        {
                //            closedByTimeOut = true;
                //            break;
                //        }

                //        result = MessageBox.Show(this, "Bạn có chắc chắn đóng phiên làm việc này không?",
                //                                 "Xác nhận", MessageBoxButtons.YesNo);

                //        if(result == DialogResult.No)
                //        {
                //            if(objLG.ShowDialog(this) == DialogResult.OK)
                //            {
                //                closedByTimeOut = false;
                //                break;
                //            }
                //        }
                //        else
                //        {
                //            closedByTimeOut = true;
                //            break;
                //        }
                //    }
                //}
                //else if (dialogResult == DialogResult.OK)
                //{
                //    closedByTimeOut = false;
                //}

                if (closedByTimeOut)
                {
                    //if(dialogResult == DialogResult.Cancel)
                    if(true)
                    {
                        Declare.Authenticating = 2;

                        ConnectionUtil.Instance.IsTimeOutApp = true;

                        for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                        {
                            Application.OpenForms[i].Close();
                        }

                        ConnectionUtil.Instance.CloseConnections();

                        Application.Exit();
                    }
                }
            }

            Debug.Print("{0}: Running check time out from frmMain", DateTime.Now);

            //Thread.CurrentThread.Join(10000);
            //}
        }

        void frmMain_Closing(object sender, CancelEventArgs e)
        {
            if (!closedByTimeOut && MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không (Yes/No)?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            
            closedByTimeOut = true;

            try
            {
                //clear log
                CommonProvider.Instance.ClearLogClientInfo();
                //unload plugins
                foreach (string notify in Declare.NotifierPlugins.Notifies)
                {
                    ((NotifiyBase)QLBHUtils.GetObject(notify)).Stop();
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteLog(ex.ToString(), "Unload plugins");
            }
        }

        public frmMain(System.Drawing.Bitmap imgBG)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.BackgroundImage = imgBG;
            //DieuChuyenNotify.Instance.Start(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            //ViewAllSkin();
            //LoadThamSoHeThong();
            //Phan quyen nguoi dung
            this.SetPermission();
            
            //Thiet lap Help
            mainHelp.HelpNamespace = Declare.HelpFilePath;
            mainHelp.SetHelpNavigator(this, HelpNavigator.TableOfContents);

            ribbon.SelectedPage = rbpQuanTriHeThong;

            if ((Declare.HienThiChonKho || Declare.IdKho == 0) && Declare.LogIn == 2)
            {
                frmThietLapCaLamViec frm = new frmThietLapCaLamViec(2, this);
                if (frm.ShowDialog() == DialogResult.OK)
                    ShowInfor();

                //this.ShowForm(Declare.HeThongNamespace.frmKhoHienTai, null);    
            }
            verTimer.Start();
            mainTimer.Start();

            //timeOutThread = new Thread(CheckTimeOut);
            //timeOutThread.Start();

            try
            {
                //load plugins
                foreach (string notify in Declare.NotifierPlugins.Notifies)
                {
                    //((NotifiyBase)QLBHUtils.GetObject(notify)).Start(this);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteLog(ex.ToString(), "Load plugins");
            }
        }

        #region phanQuyen_Menu
        /// <summary>
        /// 10/10: TuanLM sưa - thiết lập quyền hạn menu
        /// </summary>
        private void SetPermission()
        {
            //Thong tin dang nhap
            ShowInfor();

            //phan quyen chuc nang
            if (Declare.LogIn == 1 || Declare.LogIn == 0)//logout
            {
                bbiLogin.Enabled = true;
                bbiLogout.Enabled = false;
                bbiChangePassWord.Enabled = false;
            }
            else if (Declare.LogIn == 2)//logged on
            {
                bbiLogin.Enabled = false;
                bbiLogout.Enabled = true;
                bbiChangePassWord.Enabled = true;
            }

            //Thao tác với ribbon menu
            BarItem frmDefault = ShowHideBarMenu();

            if (frmDefault != null && frmDefault.Visibility != BarItemVisibility.Never)
            {
                frmDefault.PerformClick();
            }
        }
        /// <summary>
        /// Ẩn hiện Ribbon Menu
        /// TuanLM: 19/10
        /// </summary>
        private BarItem ShowHideBarMenu()
        {
            BarItem frmDefault = null;
            for (int k = 0; k < this.ribbon.Pages.Count; k++)
            {
                RibbonPageGroupCollection pgColection = this.ribbon.Pages[k].Groups;

                int hidGroups = 0;//dem so group an trong 1 page
                for (int j = 0; j < pgColection.Count; j++)
                {
                    if (pgColection[j].Name.Contains("_ck")) continue;//bỏ qua những group tên có dạng _ck vì ko có trong bảng danh mục chức năng
                    RibbonPageGroupItemLinkCollection colection = pgColection[j].ItemLinks;
                    int hidItems = 0;//dem so item an trong 1 group
                    for (int i = 0; i < colection.Count; i++)
                    {
                        if (colection[i].Item.Name.Equals(Declare.GiaoDienMacDinh))
                            frmDefault = colection[i].Item;

                        if (colection[i].Item.Name.Contains("_ck"))
                        {
                            if (colection[i].Item.Visibility == BarItemVisibility.Never)
                                hidItems++;

                            continue;//bỏ qua những item tên có dạng _ck vì ko có trong bảng danh mục chức năng
                        }
                        colection[i].Item.Visibility = ItemVisibility(colection[i].Item.Name);
                        if (colection[i].Item.Visibility == BarItemVisibility.Never)
                            hidItems++;
                        else
                        {
                            if (colection[i].Item.GetType() == typeof(BarSubItem))
                            {
                                int hidChild = 0;
                                BarItemLinkCollection links = ((BarSubItem)colection[i].Item).ItemLinks;

                                for (int n = 0; n < links.Count; n++)
                                {
                                    if (links[n].Item.Name.Contains("_ck")) continue;//bỏ qua những item tên có dạng _ck vì ko có trong bảng danh mục chức năng
                                    links[n].Item.Visibility = ItemVisibility(links[n].Item.Name);
                                    if (links[n].Item.Visibility == BarItemVisibility.Never)
                                        hidChild++;
                                }
                                if (hidChild == links.Count)
                                {
                                    colection[i].Item.Visibility = BarItemVisibility.Never;
                                    hidItems++;
                                }

                            }
                        }
                    }
                    //an hien cac group
                    if (hidItems == colection.Count)
                    {
                        pgColection[j].Visible = false;//neu ko co item nao visible => an luon ca group
                        hidGroups++;
                    }
                    else
                    {
                        pgColection[j].Visible = true;
                    }
                }
                //an hien cac page
                if (hidGroups == pgColection.Count)
                {
                    this.ribbon.Pages[k].Visible = false;//neu ko co group nao visible => an luon ca page
                }
                else
                {
                    if (!this.ribbon.Pages[k].Name.Contains("_ck"))
                        this.ribbon.Pages[k].Visible = true;
                }
            }
            return frmDefault;
        }

        /// <summary>
        /// Ẩn hiện ribbon menu item
        /// TuanLM: 13/10
        /// </summary>
        /// <param name="IDItem"></param>
        /// <returns></returns>
        private BarItemVisibility ItemVisibility(string IDItem)
        {
            if (Declare.USER_INFOR != null)
            {
                NguoiDungInfor user = (NguoiDungInfor)Declare.USER_INFOR;
                if (user.SupperUser == 1)
                    return BarItemVisibility.Always;
                foreach (ChucNangInfor cn in user.ChucNangNguoiDung)
                    if (cn.MaChucNang.Equals(IDItem))
                        return BarItemVisibility.Always;
            }
            return BarItemVisibility.Never;
        }
        /// <summary>
        /// Hiên thị thông tin đăng nhập hệ thống
        /// </summary>
        private void ShowInfor()
        {
            if (Declare.USER_INFOR != null)
            {
                NguoiDungInfor user = (NguoiDungInfor)Declare.USER_INFOR;
                barPhongBanStatus.Caption = Declare.TenTrungTam;
                barKhoStatus.Caption = Declare.TenKho;
                barUserStatus.Caption = user.TenDangNhap;
                barNhanVienStatus.Caption = user.TenNhanVien;
            }
            else
            {
                barPhongBanStatus.Caption = "QL Bán hàng";
                barKhoStatus.Caption = "Chưa chọn kho";
                barUserStatus.Caption = "Chưa đăng nhập vào hệ thống!";
                barNhanVienStatus.Caption = "Khách!";
            }

            barLicenseStatus.Caption = Declare.LICENSE;
            barLicenseStatus.Caption += (ConnectionUtil.Instance.IsUAT == 1 ? " Golive_" : " Test_") + VerBase.CurrentVersion.ToString();
            //lblPBTest.Visible = ConnectionUtil.Instance.IsUAT != 1 ? true : false;
        }
        #endregion

        private Form ShowAndLockForm(string qualifiedName, params object[] args)
        {
            try
            {
                string sql = String.Format("select lk.IdUser, nd.TenDangNhap, lk.Computer from tbl_Function_Locking lk inner join tbl_dm_nguoidung nd on lk.IdUser = nd.IdNguoidung where lk.FormName='{0}' and lk.IdKho={1}", qualifiedName, Declare.IdKho);
                DataTable dt = DBTools.getData("Temp", sql).Tables["Temp"];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!String.Equals(dt.Rows[0]["Computer"], Common.GetComputerName()))
                    {
                        MessageBox.Show(String.Format("Chức năng này đang được chạy bởi một máy khác [{0}]", dt.Rows[0]["Computer"].ToString()));
                        return null;
                    }
                    if (Common.IntValue(dt.Rows[0]["IdUser"]) != Declare.UserId)
                    {
                        MessageBox.Show(String.Format("Chức năng này đang được chạy bởi một người dùng khác [{0}]", dt.Rows[0]["TenDangNhap"].ToString()));
                        return null;
                    }
                }
                GtidCommand sqlCmd = ConnectionUtil.Instance.GetConnection().CreateCommand();
                sqlCmd.CommandText = "sp_LockFunction_Insert";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@FormName", qualifiedName);
                sqlCmd.Parameters.AddWithValue("@IdKho", Declare.IdKho);
                sqlCmd.Parameters.AddWithValue("@IdUser", Declare.UserId);
                sqlCmd.Parameters.AddWithValue("@Computer", Common.GetComputerName());
                sqlCmd.ExecuteNonQuery();
                return this.ShowForm(qualifiedName, args);
            }
            catch (System.Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
            return null;
        }
        private void ShowModalForm(string qualifiedName, params object[] args)
        {
            try
            {
                Form frm = (Form)QLBHUtils.GetObject(qualifiedName, args);
                Common.LogOpenForm(frm);                
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("This form {0} is not implemented.", qualifiedName));
                this.Cursor = Cursors.Default;
#if DEBUG
                Debug.Print(ex.ToString());
#endif
            }
        }

        private Form ShowForm(string qualifiedName)
        {
            return ShowForm(qualifiedName, null);
        }

        private Form ShowFormDialog(string qualifiedName, bool modalForm, params object[] args)
        {
            try
            {
                bool found = false;
                Form rs = null;
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm != null && !frm.IsDisposed && frm.GetType().FullName == qualifiedName)
                    {
                        frm.Activate();
                        found = true;
                        rs = frm;
                    }
                    else
                        frm.WindowState = FormWindowState.Normal;
                }

                if (!found)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Form frm1 = (Form)QLBHUtils.GetObject(qualifiedName, args);
                    if (modalForm)
                        frm1.ShowDialog();
                    else
                        frm1.Show();
                    this.Cursor = Cursors.Default;
                    rs = frm1;
                    Common.LogOpenForm(rs);                
                }
                //todo: @HaH frmTimPhieuXuat.SQLSearch = "" trong ShowForm
                //frmTimPhieuXuat.SQLSearch = "";
                return rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("This form {0} is not implemented.", qualifiedName));
                this.Cursor = Cursors.Default;
#if DEBUG
                Debug.Print(ex.ToString());
#endif
            }
            return null;
        }

        private Form ShowForm(string qualifiedName, params object[] args)
        {
            try
            {
                bool found = false;
                Form rs = null;
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm != null && !frm.IsDisposed && frm.GetType().FullName == qualifiedName)
                    {
                        frm.Activate();
                        found = true;
                        rs = frm;
                    }
                    else
                        frm.WindowState = FormWindowState.Normal;
                }

                if (!found)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Form frm1 = (Form)QLBHUtils.GetObject(qualifiedName, args);
                    frm1.MdiParent = this;
                    frm1.MaximumSize = new System.Drawing.Size(0, 0);
                    frm1.MinimumSize = new System.Drawing.Size(0, 0);
                    frm1.Show();
                    this.Cursor = Cursors.Default;
                    rs = frm1;
                    Common.LogOpenForm(rs);                
                }
                //todo: @HaH frmTimPhieuXuat.SQLSearch = "" trong ShowForm
                //frmTimPhieuXuat.SQLSearch = "";
                return rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                EventLogProvider.Instance.WriteLog(ex.ToString(), "ShowForm");
                MessageBox.Show(String.Format("This form {0} is not implemented.", qualifiedName));
                this.Cursor = Cursors.Default;
#if DEBUG
                Debug.Print(ex.ToString());
#endif
            }
            return null;
        }
        
        private Form ShowForm(Type type, params object[] args)
        {
            bool found = false;
            Form rs = null;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != null && !frm.IsDisposed && frm.GetType() == type)
                {
                    frm.Activate();
                    found = true;
                    rs = frm;
                }
                else
                    frm.WindowState = FormWindowState.Normal;
            }

            if (!found)
            {
                this.Cursor = Cursors.WaitCursor;
                Form frm1 = (Form)QLBHUtils.GetObject(type, args);
                frm1.MdiParent = this;
                frm1.MaximumSize = new System.Drawing.Size(0, 0);
                frm1.MinimumSize = new System.Drawing.Size(0, 0);
                frm1.Show();
                this.Cursor = Cursors.Default;
                rs = frm1;
                Common.LogOpenForm(rs);                
            }
            //todo: @HaH frmTimPhieuXuat.SQLSearch = "" trong ShowForm
            //frmTimPhieuXuat.SQLSearch = "";
            return rs;
        }

        private Form ShowMultiForm(string qualifiedName, string title, params object[] args)
        {
            try
            {
                bool found = false;
                Form rs = null;
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm != null && !frm.IsDisposed && frm.GetType().FullName == qualifiedName && frm.Text.Equals(title))
                    {
                        frm.Activate();
                        found = true;
                        rs = frm;
                    }
                    else
                        frm.WindowState = FormWindowState.Normal;
                }

                if (!found)
                {
                    this.Cursor = Cursors.WaitCursor;
                    Form frm1 = (Form)QLBHUtils.GetObject(qualifiedName, args);
                    frm1.Text = title;
                    frm1.MdiParent = this;
                    frm1.MaximumSize = new System.Drawing.Size(0, 0);
                    frm1.MinimumSize = new System.Drawing.Size(0, 0);
                    frm1.Show();
                    this.Cursor = Cursors.Default;
                    rs = frm1;
                    Common.LogOpenForm(rs);                
                }
                //todo: @HaH frmTimPhieuXuat.SQLSearch = "" trong ShowForm
                //frmTimPhieuXuat.SQLSearch = "";
                return rs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("This form {0} is not implemented.", qualifiedName));
                this.Cursor = Cursors.Default;
#if DEBUG
                Debug.Print(ex.ToString());
#endif
            }
            return null;
        }

        private void LoadForm(string qualifiedName, string formName)
        {
            if (Application.OpenForms[formName] == null)
            {
                Form frm = (Form)QLBHUtils.GetObject(qualifiedName, null);
                frm.MdiParent = this;
                frm.MaximumSize = new System.Drawing.Size(0, 0);
                frm.MinimumSize = new System.Drawing.Size(0, 0);
                frm.Show();
                Common.LogOpenForm(frm);                
            }
            else
            {
                xtmManager.SelectedPage = xtmManager.Pages[(Form)(Application.OpenForms[formName])];
            }
        }

        void xtmManager_SelectedPageChanged(object sender, System.EventArgs e)
        {
            if (xtmManager.SelectedPage != null)
                this.ActivateMdiChild(xtmManager.SelectedPage.MdiChild);
        }

        void xtmManager_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)

                return;

            DevExpress.XtraTab.ViewInfo.BaseTabHitInfo hi = xtmManager.CalcHitInfo(new Point(e.X, e.Y));

            if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader) {

                PopupMenu popupMenu = new PopupMenu();
                BarButtonItem bbiCloseThis = new BarButtonItem();
                bbiCloseThis.Caption = "Đóng trang này";
                bbiCloseThis.ItemClick += new ItemClickEventHandler(bbiCloseThis_ItemClick);
                popupMenu.Ribbon = this.ribbon;
                popupMenu.MenuAppearance.SideStrip.Options.UseImage = false;
                popupMenu.MenuAppearance.SideStrip.Options.UseTextOptions = true;
                popupMenu.AddItem(bbiCloseThis);
                if (xtmManager.Pages.Count > 1)
                {
                    BarButtonItem bbiCloseOthers = new BarButtonItem();
                    BarButtonItem bbiCloseAll = new BarButtonItem();
                    
                    bbiCloseOthers.Caption = "Đóng các trang khác";
                    bbiCloseOthers.ItemClick += new ItemClickEventHandler(bbiCloseOthers_ItemClick);
                    bbiCloseAll.Caption = "Đóng toàn bộ";
                    bbiCloseAll.ItemClick += new ItemClickEventHandler(bbiCloseAll_ItemClick);

                    popupMenu.AddItem(bbiCloseOthers);
                    popupMenu.AddItem(bbiCloseAll);
                }
                popupMenu.ShowPopup(Cursor.Position);

            }
        }

        void bbiCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < xtmManager.Pages.Count; i++)
            {
                xtmManager.Pages[i].MdiChild.Close();
                i--;
            }
        }

        void bbiCloseOthers_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < xtmManager.Pages.Count; i++ )
            {
                if (!xtmManager.SelectedPage.Equals(xtmManager.Pages[i]))
                {
                    (xtmManager.Pages[i]).MdiChild.Close();
                    i--;
                }
            }
        }

        void bbiCloseThis_ItemClick(object sender, ItemClickEventArgs e)
        {
            xtmManager.SelectedPage.MdiChild.Close();
        }

        private void bbiClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không (Yes/No)?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CommonProvider.Instance.ClearLogClientInfo();
                closedByTimeOut = true;
                Application.Exit();    
            }
        }

        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin objLG = new frmLogin();
            objLG.ShowDialog();
            if (objLG.DialogResult == DialogResult.OK)
            {
                CommonProvider.Instance.LogClientInfo();

                this.SetPermission();
            }
        }

        private void bbiLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            //TaiKhoanModel modTaiKhoan = new TaiKhoanModel();
            //clsConst.USER_INFOR.Status = false;
            //modTaiKhoan.UpdateUserStatus(clsConst.USER_INFOR);

            foreach (Form frm in this.MdiChildren)
                frm.Close();

            Declare.LogIn = 1;//logout
            Declare.USER_INFOR = null;
            Declare.IS_SUPPER_USER = false;

            this.SetPermission();

            CommonProvider.Instance.ClearLogClientInfo();
        }

        private void bbiChangePassWord_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmHT_ChangePass().ShowDialog();
        }

        private void bbiDMChucNang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ListChucNang, this.ribbon);
        }

        private void bbiDMNhomTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ListNhomNguoiDung, null);
        }

        private void bbiDMTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ListNguoiDung, null);
        }

        private void bbiDMPhongBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_PhongBan, null);
        }

        private void bbiDMChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_ChucVu, null);    
        }

        private void bbiDMNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_NhanVien, null);    
        }

        private void bbiDMTrungTam_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_TrungTam, null);    
        }

        private void bbiHuongDan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Help.ShowHelp(this, Declare.HelpFilePath);
        }

        private void bbiCapNhatPhienBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.HeThongNamespace.frmNangCapPhienBanMoi, true);
        }

        private void bbiGioiThieu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiBanQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiDMKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_Kho, null);    
        }

        private void bbiDMKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_KhachHang, null);    
        }

        private void bbiDMDonViTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_DonViTinh, null);
        }

        private void bbiDMNhomHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiSanPham, null);
        }

        private void bbiDMHangHoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_MatHang, null);
        }

        private void bbiDMOrdertype_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_OrderType, null);
        }

        private void bbiDMTaxcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_TaxCode, null);
        }

        private void bbiDMHoadon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_QuyenHoaDon, null);
        }

        private void bbiDMHinhthucTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_ThanhToan, null);
        }

        private void bbiDMThoihanTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiThuChi, null);
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            barTimeStatus.Caption = DateTime.Now.ToLongTimeString() + " - Ngày " + Utils.GetCurrentDate();
        }

        private void bbiDMLoaiDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiDichVu, null);
        }

        private void bbiDMLoaiItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiItem, null);
        }

        private void bbiListDM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_ListDM, null);
        }

        private void bbiDMDuAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_DuAn, null);
        }

        private void bbiDMThe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_The, null);
        }

        private void bbiDongBoCtNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowAndLockForm(Declare.KhoHangNamespace.DanhSachNhapHangMua);
        }

        private void bbiCauHinhNhomHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDMCauHinh_LoaiSanPham);
        }

        private void bbiDMLyDoTraHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LyDoTraHang);
        }

        //tuong duong danh muc chi phi
        //private void bbiDMLyDoGiaoDich_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    this.ShowForm(Declare.DanhMucNamespace.frmDM_LyDoGiaoDich);
        //}

        private void bbiDMLoaiHoaDon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiHoaDon);
        }

        private void bbiThietLapDanhMuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_ListDM);
        }

        private void bbiDMLoaiKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiDoiTuong);
        }

        private void bbiDMDichVuBH_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bbiDMMaLoiBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_MaLoi, null);
        }

        private void bbiDMKhachLe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_KhachHangLe, null);
        }

        private void bbiThietLapGiaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmCS_ListBangGia, "Thiết lập bảng giá bán", null);
        }

        private void bbiDeNghiXuatTieuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmDeNghiXuatTieuHao, null);
        }

        private void bbiXuatTieuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmXuatTieuHao, null);
        }

        private void bbiDatHangOnline_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListDonHangOnline, null);
        }

        private void bbiDatHangMua_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListDonHangDatTruoc, null);
        }

        private void bbiLapDonHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowMultiForm(Declare.BanHangNamespace.frmBH_ListDonHangBan, "Lập đơn hàng bán", null);
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_ListDonHangBanTheTVien, "Lập đơn hàng bán", null);
        }

        private void bbiDmChiPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_ChiPhi);
        }

        private void bbiCachGiaoHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_CachGiaoHang);
        }

        //tuong tu danh muc loai hoa don
        //private void bbiBangKeThue_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    this.ShowForm(Declare.DanhMucNamespace.frmDM_BangKeThue);
        //}

        private void bbiPhuongThucBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_PhuongThucBanHang);
        }

        private void bbiLinhVuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LinhVuc);
        }

        private void bbiNganhHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_NganhHang);
        }

        private void bbiLoaiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_LoaiHang);
        }

        private void bbiChungHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_ChungHang);
        }

        private void bbiNhomHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_NhomHang);
        }

        private void bbiModel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_Model);
        }

        private void bbiHangSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_Hang);
        }

        void bbiNhapPO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.DanhSachNhapHangMua);
        }

        void bbiNhapNoiBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frm_DanhSachPhieuNhapNoiBo);
        }

        void bbiXuatNoiBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frm_DanhSachPhieuXuatNoiBo);
        }

        private void bbiThongKeHangTon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmThongKeHangTonKho);
        }

        private void bbiKhoHienTai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowModalForm(Declare.HeThongNamespace.frmThietLapCaLamViec, 2, this, true);//0-mac dinh: reset all trong 1 page, 1-reset trong 1 session (luu vao static), 2-resset all session (luu vao CSDL)
            this.ShowInfor();
        }

        private void bbiYCauChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frm_DanhSachDeNghiDieuChuyen);
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachDeNghiXuatDieuChuyen);
        }

        private void bbiXuatChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frm_DanhSachDieuChuyen);
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachXuatDieuChuyen);
        }

        private void bbiTiepNhanYCau_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMYeuCau);
        }

        private void bbiPhanCongXL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMYeuCauPhanCong);
        }

        void bbiPhanCongBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhanCongBH);
        }

        void bbiThucHienBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMThucHienBaoHanhKT);
        }

        void bbiXuatTraBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMXuatTraHangBHKho);
        }

        void bbiYCXuatLK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMXuatTraLinhKien);
        }

        void bbiXuatTraLK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMXuatTraLinhKienKho);
        }

        private void bbiNhanHangLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhieuNhanHangLoi);
        }

        private void bbiXNhanChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.DanhSachDeNghiNhanDieuChuyen);
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachDeNghiNhapDieuChuyen);
        }

        private void bbiNhapChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.DanhSachNhanDieuChuyen);
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachNhapDieuChuyen);
        }

        private void bbiXuatLinhKienSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.DanhSachXuatLinhKienSX);
        }

        private void bbiXuatTraNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.DanhSachTraNhaCungCap);
        }

        private void bbiNhapKhoBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhieuNhapKho);
        }

        private void bbiPhanLoaiBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhanLoaiBaoHanh);
        }

        private void bbiBaohanhSP_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMThucHienBaoHanh);
        }

        void bbiXuatLKBH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMThucHienBaoHanhKho);
        }


        private void bbiKiemTraBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMKiemTraTongHop);
        }

        private void bbiTraHangBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMXuatTraHangBH);
        }

        private void bbiXuatHangBHNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMXuatHangLoiBHNCC);
        }

        private void bbiXuatMuonBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhieuYeuCauXM);
        }

        private void bbiNhapTraMuon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMKhachMuonTra);
        }

        void bbiXacNhanTraHangMuon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMKhachMuonTraKT);
        }

        private void bbiXuatMuonBHKeToanDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhieuYeuCauXM_KT);
        }

        private void bbiXuatMuonBHThuKhoXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMPhieuYeuCauXM_Kho);
        }

        private void bbiKiemKeKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.DanhSachPhieuKiemKe);
        }

        private void bbiBangKeHangLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMBangKeHangLoi);
        }

        private void bbiNhanHangNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMNhanHangBHNCC);
        }

        private void bbiNhapThanhPhamSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.DanhSachNhapThanhPhamSX);
        }

        private void bbiTachThanhPhamSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.DanhSachTachThanhPhamSX);
        }

        private void bbiTinhTrangBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMTraCuuBaoHanh);
        }

        private void bbiXuatHangBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListPhieuXuatKho, null);
        }

        private void bbiPhanCongGNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListPhanCongGiaoNhan, null);
        }

        private void bbiKhaiBaoSuDungHD_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowModalForm(Declare.BanHangNamespace.frmCS_SuDungHoaDon, null);    
        }

        private void bbiTimKiemChungTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_TimChungTu, null);
        }

        private void bbiDuyetDonHangOL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListDuyetDonHangOnline, null);
        }

        private void bbiTraLaiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmXacNhanNhapHangTraLai);
            //frmChiTietYeuCauNhapLaiHangMua frm = new frmChiTietYeuCauNhapLaiHangMua();
            //frm.MdiParent = this;
            //frm.MaximumSize = new System.Drawing.Size(0, 0);
            //frm.MinimumSize = new System.Drawing.Size(0, 0);
            //frm.Show();

        }

        private void bbiLapPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListPhieuThanhToan, null);
        }

        private void bbiLapPhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListPhieuChi, null);
        }

        private void bbiDamPhanNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMDamPhanNCC, null);
        }

        private void bbiThamSoBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ThietLapPheDuyetGiaBan, null);
        }

        private void bbiDuyetGiaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.BanHangNamespace.frmCS_DuyetBangGia, null);
            this.ShowMultiForm(Declare.BanHangNamespace.frmCS_ListBangGia, "Duyệt bảng giá bán", true);
        }

        private void bbiChinhSachThuongNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ThietLapThuongNhanVien, null);
        }

        private void bbiThietLapChinhSachGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_BangGia_ChinhSach, null);
        }

        private void bbiXuLyYC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMHangXuLy, null);
        }

        private void bbiKhaiBaoTon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmCapNhatTonDauKy, null);
        }

        private void bbiHoTroKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHHoTroKhachHang, null);
        }

        private void bbiBaoCaoNoKhach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoNoKhach, null);
        }

        private void bbiBaoCaoXuatMuon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMBHBaoCaoXM, null);
        }

        private void bbiNoBaoHanhNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMBaoCaoNoNCC, null);
        }

        private void bbiBHTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoTonKho, null);
        }

        private void bbiHangLoiKD_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMHangLoiKinhDoanh, null);
        }

        private void bbiKyThuatXuLyYC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmKiThuatXuLyTaiNha, null);
        }

        private void bbiTimKiemBangGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_TimKiem_BangGia, null);
        }

        private void bbiTimKiemChinhSach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_TimKiem_ChinhSachGia, null);
        }

        private void bbiBCBangGiaChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmCSBCBangGiaChiTiet, null);
        }

        private void bbiBCTinhTrangBangGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmCSBCTinhTrangBangGia, null);
        }

        private void bbiTinhTrangDonHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_DonHangChiTietXuatKho, null);
        }

        private void bbiLichSuThayDoiGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frmCSBCLichSuThayDoiGia, null);
            this.ShowForm(Declare.BanHangNamespace.frmBH_BangGiaBanHang_LichSu, null);
        }

        private void bbiBangGiaChuaDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_BangGia_ChuaDuyet, null);
        }

        private void bbiDeNghiNhapLai_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.BanHangNamespace.frmBH_TraLaiHangBan, 1);
            this.ShowMultiForm(Declare.BanHangNamespace.frmDMDnTraHangMua, "Đề nghị nhập trả lại", false);
            //frmChiTietYeuCauNhapLaiHangMua frm = new frmChiTietYeuCauNhapLaiHangMua(1);
            //frm.MdiParent = this;
            //frm.MaximumSize = new System.Drawing.Size(0, 0);
            //frm.MinimumSize = new System.Drawing.Size(0, 0);
            //frm.Show();

            
        }

        private void bbiKTraHLNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmChiTietKiemSoatNhanBHNCC, null);
        }

        private void bbiBCYCKyThuatXuLy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBCYeuCauKTXuLy, null);
        }

        private void bbiBCYCHangXuLy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBaoCaoHangXuLyYC, null);
        }

        private void bbiBCYeuCauTaiNha_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBCDSYeuCauTaiNha, null);
        }

        private void bbiBCKTraNhapNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBaoCaoKiemSoatNhanBHNCC, null);
        }

        private void bbiDNDoiMa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmDMDeNghiDoiMa, null);
        }

        private void bbiXNDoiMa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmDMXacNhanDoiMa, null);
        }

        private void bbiDMNganHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_NganHang, null);
        }

        private void bbiBaoCaoTonMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoTonMaVach, null);
        }

        private void bbiBangGiaHienTai_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.BanHangNamespace.frmBH_BangGiaBanHang, null);
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_BangGiaBanHang, "Bảng giá hiện tại", false);
        }

        private void bbiChoXuatKinhDoanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMChoXuatKinhDoanh, null);
        }

        private void bbiTraCuuMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMTraCuuMaVach, null);
        }

        private void bbiInMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(ConnectionUtil.Instance.IsUAT == 1)
                this.ShowForm(Declare.HeThongNamespace.frm_InMaVach, null);
            else
                this.ShowForm(Declare.HeThongNamespace.frm_InMaVach2, null);
        }

        private void bbiBaoCaoThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBaoCaoThuChi, null);
        }

        private void bbiBaoCaoNoCty_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBaoCaoNoCongTy, null);
        }

        private void bbiBCPhieuThuTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_PhieuThuTien, null);
        }

        private void bbiBCPhieuThuChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_PhieuThuChiTiet, null);
        }

        private void bbiBCBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_DonHang, null);
        }

        private void bbiBCBanHangChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_DonHangChiTiet, null);
        }

        private void bbiBCNhanHangNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoNhanHangNCC, null);
        }

        private void bbiCSBaoHanhNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHDSChinhSachNCC, null);
        }

        private void bbiNgayLamViec_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowModalForm(Declare.HeThongNamespace.frmThietLapCaLamViec, null);//0-mac dinh: reset all trong 1 page, 1-reset trong 1 session (luu vao static), 2-resset all session (luu vao CSDL)
        }

        private void bbiChiTietGiaoDichNhapXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietGiaoDichNhapHang, null);
        }

        private void bbiChiTietChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietChuyenKho, null);
        }

        private void bbiTinhTrangGiaoNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_GiaoNhan, null);
        }

        private void bbiKichHoatBaoHanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmKT_KichHoatBaoHanh, null);
        }

        private void bbiKichHoatDTTon_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmKT_KichHoatBHHangTon, null);
        }

        private void bbiBCChiTietGNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_GiaoNhanChiTiet, null);
        }

        private void bbiBCChinhSachGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_ChinhSachGia, null);
        }

        private void bbiBCCSGChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_ChinhSachGiaChiTiet, null);
        }

        private void bbiSanPhamChuaGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_HangChuaCoGia, null);
        }

        private void bbiTHHangLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoTongHopHangLoi, null);
        }

        private void bbiBCXuatHangBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoHangXuatHang, null);
        }
        private void bbiBCDoiMa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoDoiMa, null);
        }

        private void bbiCapNhatTTKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmCapNhapThongTinKhach, null);
        }

        private void bbiBCLenKHTraKh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoLenKeHoach, null);
        }

        private void bbiBCBangKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoBangKe, null);
        }

        private bool verTimerTickCompleted = true;

        private void verTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                CheckTimeOut();

                if(!verTimerTickCompleted) return;

                Debug.Print("{0}: Checking new version...", DateTime.Now);

                if (btnUpdateVersion.Visibility == BarItemVisibility.Always) return;
                if (Declare.LastAction.AddMinutes(Declare.LOGIN_TIMEOUT) < DateTime.Now) return;
                if (!Common.ApplicationIsActivated()) return;

                //hah: check pending process (here and notifier)
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = String.Format("{0}\\{1}.config", Application.StartupPath, Process.GetCurrentProcess().MainModule.ModuleName);
                if (!File.Exists(fileMap.ExeConfigFilename)) throw new ManagedException("Không tìm thấy file cấu hình hệ thống!");
                Configuration configuration;
                try
                {
                    configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                    if (configuration.AppSettings.Settings["PendingProcess"] != null &&
                                !String.IsNullOrEmpty(configuration.AppSettings.Settings["PendingProcess"].Value))
                    {
                        return;
                    } 
                    
                }
                catch (ConfigurationErrorsException ex)
                {
                    EventLogProvider.Instance.WriteOfflineLog(ex.ToString(), "Configuration Error");

                    throw new ManagedException("Cấu hình hệ thống không hợp lệ!");
                }
                                
                verTimerTickCompleted = false;

                Declare.SYSDATE = CommonProvider.Instance.GetSysDate();

                var commingNewVersion = CrmTidVer.Instance.CommingNewVersion;

                if (commingNewVersion > 0)
                {
                    if (Convert.ToDouble(Declare.SYSDATE.AddDays(-1).ToString("yyyyMMddHHmmss")) > commingNewVersion

                        && !ConnectionUtil.Instance.IsInTransaction)
                    {
                        Environment.Exit(124);
                    }

                    btnUpdateVersion.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    btnUpdateVersion.Visibility = BarItemVisibility.Never;
                }
                
                verTimerTickCompleted = true;

                Debug.Print("{0}: Completed checking version.", DateTime.Now);
            }
            catch (Exception ex)
            {
                verTimerTickCompleted = true;

                string localLogFile = Application.StartupPath + "\\QLBH_Log.txt";
                if (File.Exists(localLogFile))
                {
                    string logContent = File.ReadAllText(localLogFile);
                    EventLogProvider.Instance.WriteLog(logContent, "local logs");
                    File.Delete(localLogFile);
                }
                //MessageBox.Show("Cập nhật phiên bản mới không thành công");
            }
        }

        private void btnUpdateVersion_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SaleTidVer.Instance.CheckUpdate();
                //string sPath = CommonProvider.Instance.GetPath();
                //if (!String.IsNullOrEmpty(sPath)) Declare.PathToLoadFile = sPath;
                //double lastVersion = CommonProvider.Instance.GetVersion();
                //ProcessStartInfo processStartInfo = new ProcessStartInfo("LiveUpdate.exe", Declare.PathToLoadFile + ";" + Convert.ToString(lastVersion));
                //if (System.Environment.OSVersion.Version.Major >= 6)
                //{
                //    processStartInfo.Verb = "runas";
                //}
                //Process.Start(processStartInfo);
                closedByTimeOut = true;
                Application.Exit();
            }
            catch (Exception ex)
            {
                EventLogProvider.Instance.WriteLog(ex.ToString(), "Update version.");

                string localLogFile = Application.StartupPath + "\\QLBH_Log.txt";
                if (File.Exists(localLogFile))
                {
                    string logContent = File.ReadAllText(localLogFile);
                    EventLogProvider.Instance.WriteLog(logContent, "local logs" + ex.ToString());
                    File.Delete(localLogFile);
                }
                MessageBox.Show("Cập nhật phiên bản mới không thành công");
            }
        }

        private void bbiChinhSachGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_SuDungHoaDon, null);
        }

        private void bbiDanhSachMVHienCo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_TonMaVachHienCo, null);
        }

        private void bbiNhatKyHoatDongMVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_LichSuMaVach, null);
        }

        private void bbiBCTongHopXL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHLichSuPhanCong, null);
        }

        private void bbiHoanThienYCXL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmKetThucXuLyYeuCau, null);
        }

        private void bbiThietLapTruongCa_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BaoHanhNamespace.frmBHThietLapTruongCa, true, null);
        }

        private void bbiImportDataPOS_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmImport_ChungTuChiTiet, null);
        }

        private void bbiCapNhatTTGiaoNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_TinhTrangGiaoNhan, "Cập nhật tình trạng giao nhận", null);
            //this.ShowForm(Declare.BanHangNamespace.frmBH_TinhTrangGiaoNhan, null);
        }

        //private void bbiBCXuatLKLR_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoXuatLinhKienLapRap, null);
        //}

        private void bbiImportBG_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_ImportBangGia, null);
        }

        private void bbiBCLenhSXChuaXuatLK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoLenhSXChuaXuatLK, null);
        }

        private void bbiBCXuatTieuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoXuatTieuHao, null);
        }

        private void bbiBCTHChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopChuyenKho, null);
        }

        private void bbiBCTHNhapXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopGiaoDichNhapHang, null);
        }

        private void bbiBCDongBoPO_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDongBoPO, null);
        }

        private void bbiDoiTinhChatHangCTy_ItemClick(object sender, ItemClickEventArgs e)
        {
            return;
            //this.ShowForm(Declare.BaoHanhNamespace.frmUpdateTinhChatHang, null);
        }

        private void bbiDinhGiaSanPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhDinhGiaSanPham, null);
        }

        private void bbiBHUnlock_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHUnlock, null);
        }

        private void bbiNhapXuatCombo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachNhapCombo, null);
        }

        private void bbiDoiMaSanPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachNhapDoiMa, null);
        }

        private void bbiSetKhoHangLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BaoHanhNamespace.frmBHSetKhoLoiCongTy, true, null);
        }

        private void bbiSuaMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmSuaMaVach, null);
        }

        private void bbiBCTHNhapDieuChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopNhapChuyenKho, null);
        }

        private void bbiBCCTNhapDieuChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietNhapChuyenKho, null);
        }

        private void bbiBCDoiTinhChat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoDoiTinhChat, null);
        }

        private void bbiBCGDDoiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoGDDoiHang, null);
        }

        private void bbiBCGDSetLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoGiaoDichSetLoi, null);
        }

        private void bbiBCGiaoDichXuatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHGiaoDichXuatHang, null);
        }

        private void bbiDanhGiaBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhDanhGiaBaoHanh, null);
        }

        private void bbiBCNoKhuyenMai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_NoKhuyenMai, null);
        }

        private void bbiBCCongNoBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_PhieuThuCongNo, null);
        }

        private void bbiBCDanhMuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDanhMuc, null);
        }

        private void bbiBCaoTonLichSu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTonLichSu, null);
        }

        private void bbiBCTongHopSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopSanXuat, null);
        }

        private void bbiBCChiTietSX_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietSanXuat, null);
        }

        private void bbiDMCheckLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmDMLoiCheck, null);
        }

        private void bbiKSNhanBHNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmChiTietKiemSoatNhanBHNCC1, null);
        }

        private void bbiBCKSNhanBHNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBaoCaoKiemTraNhapKho, null);
        }

        private void bbiHoaDonTraLai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListDonHangTraLai, null);
        }

        private void bbiBCTHXuatTH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopXuatTieuHao, null);
        }

        private void bbiBCTonKhoHienCo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_SanPhamHienCo, null);
        }

        private void bbiSuaDonHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.BanHangNamespace.frmBH_SuaDonHangBan, null);
            this.ShowFormDialog(Declare.BanHangNamespace.frmBH_SuaDonHangBan, false, 1);//sua thong tin don hang
        }

        private void bbiDNNhapTH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmDeNghiNhapTieuHao, null);
        }

        private void bbiNhapTieuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmNhapTieuHao, null);

        }

        private void bbiBCTongHopNhapMua_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDanhSachNhapHangMua, null);
        }

        private void bbiBCChiTietNhapMua_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietNhapHangMua, null);
        }

        private void bbiChuaXuatHet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_DonHangChiTietChuaXuatKho, null);
        }

        private void bbiBCTHNhapNoiBo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDanhSachXuatNoiBo, null);
        }

        private void bbiBCCTietNhapNoiBo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietXuatNoiBo, null);
        }

        private void bbiTHGDichNhapNoiBo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDanhSachNhapNoiBo, null);
        }

        private void bbiCTGDichNhapNoiBo_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietNhapNoiBo, null);
        }

        private void bbiBCTongHopBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_TongHopBanHang, null);
        }

        private void bbiBCDinhGia_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoDinhGia, null);
        }

        private void bbiBCTHNhapTieuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopNhapTieuHao, null);
        }

        private void bbiBCChiTietNhapTieuHao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietNhapTieuHao, null);
        }

        private void bbiBCItemPending_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoPending, null);
        }

        private void bbiBCTHNhapXuatLK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopNhapXuatLK, null);
        }

        private void bbiBCCTNhapXuatLK_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietNhapXuatLK, null);
        }

        private void bbiBCTHNXThanhPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoTongHopNhapXuatTP, null);
        }

        private void bbiBCCTNXThanhPham_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoChiTietNhapXuatTP, null);
        }

        private void bbiBCGNhanKyThuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_GiaoNhanChiTietKThuat, null);
        }

        private void bbiBCTHGDBaoHanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoNhapXuatBH, null);
        }

        private void bbiDongBoGiaWebsite_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_BangGiaBanHang, "Đồng bộ giá Website", true);
        }

        private void bbiBCPOChuaXuatSerial_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoNhapXuatPOChuaXuat, null);
        }

        private void bbiBCXuatTraBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHBaoCaoXuatTra, null);
        }

        private void bbiBCTachCauHinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoTachCauHinh, null);
        }

        private void bbiPhieuThuBoSung_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BaoHanhNamespace.frmBhPhieuThuChiBoXung, true);
        }

        private void bbiTestYCDieuChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frmDanhSachDeNghiXuatDieuChuyen, null);
        }

        private void bbiTestXuatChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frmDanhSachXuatDieuChuyen, null);
        }

        private void bbiTestXNChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frmDanhSachDeNghiNhapDieuChuyen, null);
        }

        private void bbiTestNhapChuyenKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowForm(Declare.KhoHangNamespace.frmDanhSachNhapDieuChuyen, null);
        }

        private void bbiBCDoanhThuBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_DoanhThuBanHang, null);
        }

        private void bbiBCTHKiemKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            //thay bang kiem ke ma vach ban nhieu lan
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoKiemKeMaVachBanNhieuLan, null);
        }

        private void bbiBCDCChoNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDieuChuyenChoNhan, null);
        }

        private void bbiBCTPChuaXacNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoNhapTPChuaNhap, null);
        }

        private void bbiDMCauHinhSP_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.DanhMucNamespace.frmDM_CauHinhSanPham, null);
        }

        private void bbiBHKhuVuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhKhuVuc, null);
        }

        private void bbiBCKSXLTaiTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoKSXLTrungTam, null);
        }

        private void bbiDotKiemKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachTongHopKiemKe, null);
        }

        private void bbiBCCTKTGNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_GiaoNhanChiTietKThuatCT, null);
        }

        private void bbiBCKiemKeTonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoKiemKeTonKho, null);
        }

        private void bbiBCKiemKeTonMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoKiemKeTonMaVach, null);
        }

        private void bbiBCThongKeKTGN_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_GiaoNhanThongKeKThuat, null);
        }

        private void bbiNhatKyNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_NhatKyNSD, null);
        }

        private void bbiQuanLyPhienLamViec_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_SessionDB, null);
        }

        private void bbiXuatBuKhuyenMai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_ListDonHangBan, "Xuất bù khuyến mại", true);
        }

        private void bbiLichSuBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHNhatKyBaoHanh, null);
        }

        private void bbiDeNghiNhapLaiKhac_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmDMDnTraHangMua, "Đề nghị nhập lại khác", true);
        }

        private void bbiBCDamPhanKhachLe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoDamPhanKhachLe, null);
        }

        private void bbiBCTiepNhanBaoHanh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoTiepNhanHL, null);
        }

        private void bbiCapNhatPhieuNHL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BaoHanhNamespace.frmBHCapNhatPhieuNhan, true, null);
        }

        private void bbiDSPhieuKiemKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoDanhSachPhieuKiemKe, null);
        }

        private void bbiDuyetHuyPhieuNHL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhDuyetHuyPhieuNhan, null);
        }

        private void bbiBCHuyPhieuNHL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBhBaoCaoHuyPhieuNhan, null);
        }

        private void bbiDoiLinhKien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.KhoHangNamespace.frmDoiMaLinhKien, true, null);
        }

        private void bbiBCTonTrungChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBCTonTrungChuyen, null);
        }

        private void bbiTLapSLuongMaVach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BanHangNamespace.frmThietLapSoLuongMaVachXuat, true, null);
        }

        private void bbiKhoaDonHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_KhoaDonHang, null);
        }

        private void btnDayKhuyenMai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_DayKhuyenMai, null);
        }

        private void bbiBCPQuyenNDungCNang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmBC_PhanQuyenChucNang, null);
        }

        private void bbiBCPQuyenNDungNgHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmBC_PhanQuyenNganhHang, null);
        }

        private void bbiBCPQuyenNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmBC_PhanQuyenNhomNguoiDung, null);
        }

        private void bbiBCPQuyenNgDungCNang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmBC_PhanQuyenChucNangNguoiDung, null);
        }

        private void bbiDoiHangKhuyenMai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BanHangNamespace.frmBH_SuaDonHangBan, false, 2);//doi khuyen mai
        }

        private void bbiXoaNoKhuyenMai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_NoKhuyenMai, true);
        }

        private void bbiSuaPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BanHangNamespace.frmBH_SuaDonHangBan, false, 3);//sua phieu thu/chi
        }

        private void bbiBCGiaoDichKhongDayORC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBaoCaoGiaoDichKhongDongBo, null);
        }

        private void bbiSuaTTGiaoNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_TinhTrangGiaoNhan, "Sửa thông tin đơn hàng giao nhận", true);
        }

        private void bbiUnLockChungTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ManageLockChungTu, null);
        }

        private void bbiBCCongNoKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_CongNoKhachHang, null);
        }

        private void bbiBCCongNoSieuThi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_CongNoTrungTam, null);
        }

        private void bbiSuaPhieuDieuChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmDanhSachDeNghiXuatDieuChuyen, true);
        }

        private void bbiLichSuGiaTrongNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_LichSuGiaBan);
        }

        private void bbiThietLapChinhSachKM_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmCS_BangGia_ChinhSachKM, "Thiết lập chính sách khuyến mại", null);
        }

        private void bbiDuyetChinhSachKM_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmCS_BangGia_ChinhSachKM, "Duyệt chính sách khuyến mại", true);
        }
        
        private void bbiKiemTraChinhSachKM_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCS_CheckKhuyenMai, null);
        }

        private void bbiSuaThongTinGiaoVan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BanHangNamespace.frmBH_SuaDonHangBan, false, 4);//sua thong tin don hang
        }

        private void bbiBangGiaOnline_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowMultiForm(Declare.BanHangNamespace.frmBH_BangGiaOnline, "Bảng giá online");
        }

        private void bbiCapNhatPhieuNhanNCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmBHPhieuNCC, null);
        }

        private void bbiBCCongNoAr0400_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmCongNoPOSAR0400, null);
        }

        private void bbiBCTHopDoanhThuBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBC_TongHopDoanhThuBanHang, null);
        }

        private void bbiPhanDonGNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //this.ShowMultiForm(Declare.BanHangNamespace.frmBH_ListPhanDonGiaoNhan, "Phân đơn hàng giao vận", null);//phan don giao nhan
            //this.ShowMultiForm(Declare.BanHangNamespace.frmBH_ListPhanDonGiaoNhan, "Xác nhận phân đơn hàng giao vận", true);//xac nhan phan don giao nhan
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListPhanDonGiaoNhan, null);
        }

        private void bbiXacNhanGNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BanHangNamespace.frmBH_ListXacNhanGiaoNhan, null);
        }

        private void bbiKhoTongGiao_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.KhoHangNamespace.frmBCDieuChuyenKhoTongGiao, null);
        }

        private void bbiHangLoiCanChuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmHangLoiCanChuyen, null);
        }

        private void bbiYeuCauChuyenHangLoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmYeuCauChuyen, null);
        }

        private void bbiYeuCauChuyenHangKhach_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.BaoHanhNamespace.frmYeuCauChuyen, null);
        }

        private void bbiBCGiaoDichDoiDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_TheoDoiQuyDoiDiem, null);
        }

        private void bbiSuaDonHangTraLai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BanHangNamespace.frmBH_SuaDonHangTraLai, false);
        }

        private void bbiSuaDonNhapLai_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowFormDialog(Declare.BanHangNamespace.frmBH_SuaDonHangNhapLai, false);
        }

        private void bbiBCTheoDoiTheTVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_TheoDoiTheThanhVien, null);
        }

        private void bbiBCHoatDongThe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_HoatDongTheThanhVien, null);
        }

        private void bbiBCTheThanhVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_ThongKeTheThanhVien, null);
        }

        private void bbiBCGiaoDichBuTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_TheoDoiBoiHoanTien, null);
        }

        private void bbiBCGiaoDichRaDoiDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_TheoDoiQuyDoiDiem, null);
        }

        private void bbiBCLichSuGiaoDich_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_LichSuGiaoDich, null);
        }

        private void bbiBCTongHopTichDiemThe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_TongHopTichDiemThe, null);
        }

        private void bbiBCTongHopDiemTichLuy_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.TheThanhVienNamespace.frmBC_TongHopDiemTichLuy, null);
        }

        private void bbiTSBanHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ShowForm(Declare.HeThongNamespace.frmHT_ThamSoBanHang, null);
        }
    }
}