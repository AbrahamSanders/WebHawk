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
    public partial class Form2 : Form
    {
        private class Something
        {
            public string Name { get; set; }
        }

        public Form2()
        {
            InitializeComponent();

            olvColumnLink.AspectGetter = (obj) => "Click Me";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Something> list = new List<Something>()
            {
                new Something() { Name = "Brick" },
                new Something() { Name = "House" },
                new Something() { Name = "Schwein" },
                new Something() { Name = "Hund" }
            };

            objectListView1.SetObjects(list);
        }

        private void objectListView1_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            MessageBox.Show("Hi");
            e.Handled = true;
        }
    }
}
