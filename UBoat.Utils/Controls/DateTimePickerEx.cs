using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBoat.Utils.Controls
{
    public partial class DateTimePickerEx : UserControl
    {
        public DateTimePickerEx()
        {
            InitializeComponent();
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
        }

        public DateTime Value
        {
            get
            {
                return new DateTime(
                    dtpDate.Value.Year, 
                    dtpDate.Value.Month, 
                    dtpDate.Value.Day, 
                    dtpTime.Value.Hour, 
                    dtpTime.Value.Minute, 
                    dtpTime.Value.Second);
            }
            set
            {
                dtpDate.Value = value.Date;
                dtpTime.Value = new DateTime(1753, 1, 1, value.Hour, value.Minute, value.Second);
            }
        }

        public DateTime MaxDate
        {
            get
            {
                return dtpDate.MaxDate;
            }
            set
            {
                dtpDate.MaxDate = value.Date;
            }
        }

        public DateTime MinDate
        {
            get
            {
                return dtpDate.MinDate;
            }
            set
            {
                dtpDate.MinDate = value.Date;
            }
        }
    }
}
