using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBoat.Utils.Controls
{
    public class TabPageEx : TabPage
    {
        private bool m_HasCloseButton;
        private ContextMenuStrip m_ContextMenuStrip;

        [DefaultValue(true)]
        public bool HasCloseButton
        {
            get
            {
                return m_HasCloseButton;
            }
            set
            {
                string currentText = this.Text;
                m_HasCloseButton = value;
                this.Text = currentText;
            }
        }

        public new string Text
        {
            get
            {
                if (!String.IsNullOrEmpty(base.Text))
                {
                    return HasCloseButton
                        ? base.Text.Substring(1, base.Text.Length - 7)
                        : base.Text.Substring(1, base.Text.Length - 1);
                }
                return base.Text;
            }
            set
            {
                base.Text = HasCloseButton
                    ? String.Format(" {0}      ", value)
                    : String.Format(" {0}", value);
            }
        }

        /// <summary>
        /// Overrides TabPage.ContextMenuStrip to use a local variable. 
        /// This prevents the menu from showing up anywhere on the page that is right clicked, 
        /// only allowing it to show if the tab is right clicked.
        /// </summary>
        public override ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return m_ContextMenuStrip;
            }
            set
            {
                m_ContextMenuStrip = value;
            }
        }

        public TabPageEx()
        {
            m_HasCloseButton = true;
        }
        public TabPageEx(string text) 
            : this()
        {
            this.Text = text;
        }
    }
}
