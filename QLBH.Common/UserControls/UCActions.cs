using System;
using System.Windows.Forms;

namespace QLBH.Common.UserControls
{

    public partial class UCActions<T> : UserControl
    {
        private bool isAddMode, isEditMode;
        private T editItem;
        public event Action<T> OnLoadEditor;
        public event Action OnDisableEditor;
        public event Action OnEnableEditor;
        public event Action<T> OnValidate;
        public event Action<T> OnAdd;
        public event Action<T> OnUpdate;

        public class UcActionArgs : EventArgs
        {
            public readonly object EditItem;
            public UcActionArgs(object editItem)
            {
                EditItem = editItem;
            }
        }

        public UCActions()
        {
            InitializeComponent();
            btnThem.Enabled = true; 

            //lúc form hiện lên có thể chưa có edit item nào được chọn
            btnCapNhat.Enabled = false;
            btnDel.Enabled = false;

            //disable editor
            if (OnDisableEditor != null)
                OnDisableEditor();

        }

        public void LoadEditor(T editObject)
        {
            this.editItem = editObject;
            btnCapNhat.Enabled = true;
            btnDel.Enabled = true;
            if (editItem == null)
            {
                btnCapNhat.Enabled = false;
                btnDel.Enabled = false;
            }
            if(OnLoadEditor != null)
                OnLoadEditor(editItem);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAddMode && !isEditMode)
                {
                    isAddMode = true;
                    isEditMode = false;
                    //clean editor
                    editItem = default(T);
                    if (OnLoadEditor != null)
                        OnLoadEditor(editItem);
                    //enable editor
                    if (OnEnableEditor != null)
                        OnEnableEditor();

                    btnThem.Text = "&Lưu";
                    btnCapNhat.Text = "&Hủy bỏ";
                    return;
                }
                //check validate
                if (OnValidate != null)
                    OnValidate(editItem);
                if (isAddMode)
                {
                    //insert data
                    if (OnAdd != null)
                        OnAdd(editItem);
                    isAddMode = false;
                    return;
                }
                //update data
                if (OnUpdate != null)
                    OnUpdate(editItem);
                isEditMode = false;
                return;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAddMode && !isEditMode)
                {
                    isAddMode = false;
                    isEditMode = true;
                    //enable editor
                    btnThem.Text = "&Lưu";
                    btnCapNhat.Text = "&Hủy bỏ";
                    return;
                }
                // raise cancel event

                // reset editor to before state
                if (OnLoadEditor != null)
                    OnLoadEditor(editItem);
                btnThem.Text = "&Thêm mới";
                btnCapNhat.Text = "&Sửa đổi";
                isEditMode = false;
                
                // disable editor
                if (OnDisableEditor != null)
                    OnDisableEditor();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                MessageBox.Show(ex.Message);
#endif
            }
        }
    }
}
