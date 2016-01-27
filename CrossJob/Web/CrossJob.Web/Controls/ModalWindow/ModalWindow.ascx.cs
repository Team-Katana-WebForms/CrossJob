using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestASCX
{
    public partial class ModalWindow : System.Web.UI.UserControl
    {
        public delegate void OKButtonClickedEventHandler(object sender, EventArgs e);
        public event OKButtonClickedEventHandler OKButtonClicked;

        protected void ModalWindow_OKButtonClicked(object sender, EventArgs e)
        {
            if (this.OKButtonClicked != null)
            {
                this.TextBox.Text = "0";
                this.OKButtonClicked(sender, e);
            }
        }

        public void Show()
        {
            this.TextBox.Text = "1";
        }

        public string ModalWindowText 
        {
            get { return this.ModalText.Text; }
            set { this.ModalText.Text = value; }
        }

        public string OKButtonText
        {
            get { return this.OKBtn.Text; }
            set { this.OKBtn.Text = value; }
        }
    }
}