using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBH.Common;

namespace QLBanHang.Modules
{
    public partial class InputDialog : Form
    {
        public int InputedNumber;
        public bool IsInput = false;
        private int MIN = Int32.MinValue;
        private int MAX = Int32.MaxValue;
        public InputDialog()
        {
            InitializeComponent();
            Common.LoadStyle(this);
        }
        public InputDialog(int min, int max)
        {
            InitializeComponent();
            Common.LoadStyle(this);
            this.MIN = min;
            this.MAX = max;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                InputedNumber = Common.IntValue(txtNumber.Text);
                if (InputedNumber > MAX || InputedNumber < MIN)
                {
                    MessageBox.Show("Số nhập phải nằm trong khoảng (" + MIN + "," + MAX + ")");
                    txtNumber.Focus();
                }
                else
                {
                    IsInput = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không đúng định dạng số");
                txtNumber.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsInput = false;
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            label1.Text = "Nhập vào một số trong khoảng (" + MIN + "," + MAX + ")";
        }
    }
}