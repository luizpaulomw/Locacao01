using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;


namespace Views
{
    public class FormBase : Form{
        public FormBase(){
            
            this.BackColor = Color.WhiteSmoke;
            this.Size = new Size(300,400);
        }
    }
}