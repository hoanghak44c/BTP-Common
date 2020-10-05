namespace QLBH.Common.Objects
{
    public class FormItem
    {
        private string sDisplay;
        private string sValue;

        public FormItem()
        {
        }

        public FormItem(string value, string display)
        {
            this.sValue = value;
            this.sDisplay = display;
        }

        public string Display
        {
            get { return sDisplay; }
            set { sDisplay = value; }
        }

        public string Value
        {
            get { return sValue; }
            set { sValue = value; }
        }

        public override string ToString()
        {
            return sDisplay;
        }
    }
}
