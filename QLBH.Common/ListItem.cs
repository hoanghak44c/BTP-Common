// <summary>
// Mô tả class: Lớp đối tượng khai báo 2 thuoc tinh Id va Name, thuong dung cho Combobox va Lisbox
// </summary>
// <remarks>
// Người tạo: Nguyen Gia Dang
// Ngày tạo: 03/10/2007
// </remarks>

namespace QLBH.Common
{
    public class ListItem
    {

        private string sDisplayValue;
        private int iValue;

        public ListItem()
        {
            sDisplayValue = "";
            iValue = 0;
        }

        public ListItem(int ID, string Name)
        {
            this.iValue = ID;
            this.sDisplayValue = Name;
        }

        public string Name
        {
            get { return sDisplayValue; }
            set { sDisplayValue = value; }
        }

        public int ItemData
        {
            get { return iValue; }
            set { iValue = value; }
        }

        public override string ToString()
        {
            return sDisplayValue;
        }

    }
}
