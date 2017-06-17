using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeListViewDriver
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
    }

    public class SchweinhundListView : ListView
    {
        bool trace = true;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            trace = false;
            base.OnMouseUp(e);
        }

        protected override void WndProc(ref Message m)
        {
            if (trace)
            {
                System.Diagnostics.Debug.WriteLine(m.ToString());
            }
            base.WndProc(ref m);
        }
    }
}
