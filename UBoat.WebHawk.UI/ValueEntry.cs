using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI
{
    public partial class ValueEntry : UserControl
    {
        private Control m_InputControl;

        public ValueEntry()
        {
            InitializeComponent();
        }

        public ValueEntry(DataType type) : this()
        {
            this.SetDataType(type);
        }

        public void SetDataType(DataType type)
        {
            zCleanupInputControl();
            switch (type)
            {
                case DataType.String:
                    m_InputControl = new TextBox();
                    m_InputControl.TextChanged += m_InputControl_TextChanged;
                    break;
                case DataType.Boolean:
                    m_InputControl = new CheckBox();
                    ((CheckBox)m_InputControl).CheckedChanged += m_InputControl_CheckedChanged;
                    break;
                case DataType.DateTime:
                    m_InputControl = new DateTimePicker();
                    ((DateTimePicker)m_InputControl).ValueChanged += m_InputControl_ValueChanged;
                    break;
                case DataType.Numeric:
                    m_InputControl = new NumericUpDown()
                    {
                        Minimum = Decimal.MinValue,
                        Maximum = Decimal.MaxValue,
                        DecimalPlaces = 2
                    };
                    ((NumericUpDown)m_InputControl).ValueChanged += m_InputControl_ValueChanged;
                    break;
                default:
                    throw new NotSupportedException();
            }
            m_InputControl.Dock = DockStyle.Fill;
            this.Controls.Add(m_InputControl);
        }

        void m_InputControl_ValueChanged(object sender, EventArgs e)
        {
            zOnValueChanged();
        }

        void m_InputControl_CheckedChanged(object sender, EventArgs e)
        {
            zOnValueChanged();
        }

        void m_InputControl_TextChanged(object sender, EventArgs e)
        {
            zOnValueChanged();
        }

        public void SetList(IEnumerable<string> list)
        {
            zCleanupInputControl();
            m_InputControl = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                DataSource = list
            };
            m_InputControl.Dock = DockStyle.Fill;
            this.Controls.Add(m_InputControl);
        }

        public string GetValue()
        {
            if (m_InputControl is TextBox)
            {
                return ((TextBox)m_InputControl).Text;
            }
            if (m_InputControl is CheckBox)
            {
                return ((CheckBox)m_InputControl).Checked.ToString();
            }
            if (m_InputControl is DateTimePicker)
            {
                return ((DateTimePicker)m_InputControl).Value.ToString();
            }
            if (m_InputControl is NumericUpDown)
            {
                return ((NumericUpDown)m_InputControl).Value.ToString();
            }
            if (m_InputControl is ComboBox)
            {
                return ((ComboBox)m_InputControl).SelectedItem.ToString();
            }
            throw new NotSupportedException();
        }

        public void SetValue(string value)
        {
            if (m_InputControl is TextBox)
            {
                ((TextBox)m_InputControl).Text = value;
                return;
            }
            if (m_InputControl is CheckBox)
            {
                ((CheckBox)m_InputControl).Checked = Convert.ToBoolean(value);
                return;
            }
            if (m_InputControl is DateTimePicker)
            {
                ((DateTimePicker)m_InputControl).Value = Convert.ToDateTime(value);
                return;
            }
            if (m_InputControl is NumericUpDown)
            {
                ((NumericUpDown)m_InputControl).Value = Convert.ToDecimal(value);
                return;
            }
            if (m_InputControl is ComboBox)
            {
                ((ComboBox)m_InputControl).SelectedItem = value;
                return;
            }
            throw new NotSupportedException();
        }

        public event EventHandler<ValueEntryValueChangedEventArgs> ValueChanged;
        protected void zOnValueChanged()
        {
            ValueEntryValueChangedEventArgs e = new ValueEntryValueChangedEventArgs(GetValue());
            EventHandler<ValueEntryValueChangedEventArgs> evnt = ValueChanged;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                zCleanupInputControl();
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void zCleanupInputControl()
        {
            if (m_InputControl != null)
            {
                this.Controls.Remove(m_InputControl);
                m_InputControl.Dispose();
                m_InputControl = null;
            }
        }
    }

    public class ValueEntryValueChangedEventArgs : EventArgs
    {
        public string NewValue { get; set; }

        public ValueEntryValueChangedEventArgs(string newValue)
        {
            this.NewValue = newValue;
        }
    }
}
