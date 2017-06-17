using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UBoat.Utils.Controls
{
    public partial class IntervalPicker : UserControl
    {
        private IntervalValue m_Value;

        public event EventHandler<IntervalPickerValueChangedEventArgs> ValueChanged;

        public IntervalValue Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                SetValue(value);
            }
        }

        public bool ShowMilliseconds
        {
            get
            {
                return cbIntervalUnit.Items.Contains(IntervalUnit.Milliseconds);
            }
            set
            {
                if (value && !ShowMilliseconds)
                {
                    cbIntervalUnit.Items.Insert(0, IntervalUnit.Milliseconds);
                }
                else if (!value && ShowMilliseconds)
                {
                    cbIntervalUnit.Items.Remove(IntervalUnit.Milliseconds);
                }
                zSetValue();
            }
        }

        public IntervalPicker()
        {
            InitializeComponent();

            cbIntervalUnit.Items.AddRange(new object[]
            {
                IntervalUnit.Milliseconds,
                IntervalUnit.Seconds,
                IntervalUnit.Minutes,
                IntervalUnit.Hours
            });
            cbIntervalUnit.SelectedIndex = 1;
        }

        public void SetValue(TimeSpan value)
        {
            SetValue(IntervalValue.FromTimeSpan(value));
        }

        public void SetValue(IntervalValue value)
        {
            if (value.Unit == IntervalUnit.Milliseconds && !this.ShowMilliseconds)
            {
                throw new InvalidOperationException("In order to display a value with the Milliseconds unit, ShowMilliseconds must be set to true.");
            }

            cbIntervalUnit.SelectedItem = value.Unit;
            switch (value.Unit)
            {
                case IntervalUnit.Milliseconds:
                    nudInterval.Value = (int)value.Value.TotalMilliseconds;
                    break;
                case IntervalUnit.Seconds:
                    nudInterval.Value = (int)value.Value.TotalSeconds;
                    break;
                case IntervalUnit.Minutes:
                    nudInterval.Value = (int)value.Value.TotalMinutes;
                    break;
                case IntervalUnit.Hours:
                    nudInterval.Value = (int)value.Value.TotalHours;
                    break;
            }
            m_Value = value;
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            zSetValue();
        }

        private void cbIntervalUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            zSetValue();
        }

        private void zSetValue()
        {
            m_Value.Unit = (IntervalUnit)cbIntervalUnit.SelectedItem;
            int nudvalue = Convert.ToInt32(nudInterval.Value);
            switch (m_Value.Unit)
            {
                case IntervalUnit.Milliseconds:
                    m_Value.Value = TimeSpan.FromMilliseconds(nudvalue);
                    break;
                case IntervalUnit.Seconds:
                    m_Value.Value = TimeSpan.FromSeconds(nudvalue);
                    break;
                case IntervalUnit.Minutes:
                    m_Value.Value = TimeSpan.FromMinutes(nudvalue);
                    break;
                case IntervalUnit.Hours:
                    m_Value.Value = TimeSpan.FromHours(nudvalue);
                    break;
            }
            zOnValueChanged(new IntervalPickerValueChangedEventArgs() { Value = m_Value });
        }

        protected void zOnValueChanged(IntervalPickerValueChangedEventArgs e)
        {
            EventHandler<IntervalPickerValueChangedEventArgs> evnt = ValueChanged;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }

    public struct IntervalValue
    {
        public static IntervalValue FromTimeSpan(TimeSpan intervalTS)
        {
            IntervalValue intervalValue = new IntervalValue();
            intervalValue.Value = intervalTS;

            if (intervalTS.TotalHours % 1 == 0)
            {
                intervalValue.Unit = IntervalUnit.Hours;
            }
            else if (intervalTS.TotalMinutes % 1 == 0)
            {
                intervalValue.Unit = IntervalUnit.Minutes;
            }
            else if (intervalTS.TotalSeconds % 1 == 0)
            {
                intervalValue.Unit = IntervalUnit.Seconds;
            }
            else
            {
                intervalValue.Unit = IntervalUnit.Milliseconds;
            }

            return intervalValue;
        }

        public TimeSpan Value { get; set; }
        public IntervalUnit Unit { get; set; }
    }

    public enum IntervalUnit
    {
        Milliseconds,
        Seconds,
        Minutes,
        Hours
    }

    public class IntervalPickerValueChangedEventArgs : EventArgs
    {
        public IntervalValue Value { get; set; }
    }
}
