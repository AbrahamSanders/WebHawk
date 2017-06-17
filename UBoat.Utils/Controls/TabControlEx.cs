using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBoat.Utils.Controls
{
    public class TabControlEx : TabControl
    {
        private Dictionary<int, bool> m_TabMouseTracker;

        [DefaultValue(TabDrawMode.OwnerDrawFixed)]
        public new TabDrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                base.DrawMode = value;
            }
        }

        public TabControlEx()
        {
            m_TabMouseTracker = new Dictionary<int, bool>();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public void CloseTab(TabPage tabPage)
        {
            int tabIndex = this.TabPages.IndexOf(tabPage);
            CloseTab(tabIndex);
        }
        public void CloseTab(int tabIndex)
        {
            if (tabIndex > -1 && tabIndex < this.TabCount && zHasCloseButton(tabIndex))
            {
                TabControlExPageClosingEventArgs closingArgs = new TabControlExPageClosingEventArgs(tabIndex);
                zOnTabPageClosing(closingArgs);
                if (!closingArgs.Cancel)
                {
                    TabPage page = this.TabPages[tabIndex];
                    this.TabPages.Remove(page);
                    page.Dispose();
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Bounds != RectangleF.Empty)
            {
                zDrawTab(e.Index, e.Graphics, false, false);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            
            for (int x = 0; x < this.TabCount; x++)
            {
                if (zHasCloseButton(x))
                {
                    RectangleF tabButtonArea = (RectangleF)this.GetTabRect(x);
                    tabButtonArea = new RectangleF(tabButtonArea.X + tabButtonArea.Width - 22, 4, tabButtonArea.Height - 3, tabButtonArea.Height - 5);
                    if (tabButtonArea.Contains(mousePoint))
                    {
                        if (!zGetTabIsMouseOver(x))
                        {
                            zOnMouseOverButton(x);
                        }
                    }
                    else if (zGetTabIsMouseOver(x))
                    {
                        zOnMouseLeaveButton(x);
                    }
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            for (int x = 0; x < this.TabCount; x++)
            {
                if (zHasCloseButton(x) && zGetTabIsMouseOver(x))
                {
                    zOnMouseLeaveButton(x);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!this.DesignMode && 
                (e.Button == MouseButtons.Left 
                || e.Button == MouseButtons.Middle 
                || e.Button == MouseButtons.Right))
            {
                for (int x = 0; x < this.TabCount; x++)
                {
                    RectangleF tabButtonArea = (RectangleF)this.GetTabRect(x);
                    if (e.Button == MouseButtons.Left)
                    {
                        tabButtonArea = new RectangleF(tabButtonArea.X + tabButtonArea.Width - 22, 4, tabButtonArea.Height - 3, tabButtonArea.Height - 5);
                    }
                    if (tabButtonArea.Contains(e.Location))
                    {
                        if (e.Button != MouseButtons.Right)
                        {
                            this.CloseTab(x);
                        }
                        else
                        {
                            ContextMenuStrip menuStrip = this.TabPages[x].ContextMenuStrip;
                            if (menuStrip != null)
                            {
                                menuStrip.Show(this, e.Location);
                                menuStrip.Tag = this.TabPages[x];
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void zDrawTab(int tabIndex, Graphics tabGraphics, bool mouseOver, bool drawButtonOnly)
        {
            bool isActive = tabIndex == this.SelectedIndex;

            tabGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF tabTextArea = (RectangleF)this.GetTabRect(tabIndex);
            
            using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
            {
                ColorBlend _ColorBlend = new ColorBlend(3);
                _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                if (!drawButtonOnly)
                {
                    //Draw tab area
                    using (GraphicsPath _Path = new GraphicsPath())
                    {
                        _Path.AddRectangle(tabTextArea);
                        if (isActive)
                        {
                            _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight, 
                                            Color.FromArgb(255,SystemColors.Control),SystemColors.ControlLight,
                                            SystemColors.Control};
                        }
                        else
                        {
                            _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight, 
                                            Color.FromArgb(255,SystemColors.ControlLight),SystemColors.ControlDark,
                                            SystemColors.ControlLightLight};
                        }

                        _Brush.InterpolationColors = _ColorBlend;

                        tabGraphics.FillPath(_Brush, _Path);
                        using (Pen pen = new Pen(SystemColors.ActiveBorder))
                        {
                            tabGraphics.DrawPath(pen, _Path);
                        }
                    }
                }

                if (zHasCloseButton(tabIndex))
                {
                    //Draw tab button
                    if (mouseOver)
                    {
                        _ColorBlend.Colors = new Color[] { Color.FromArgb(255, 252, 193, 183),
                                                Color.FromArgb(255, 252, 193, 183), Color.FromArgb(255, 210, 35, 2),
                                                Color.FromArgb(255, 210, 35, 2)};
                    }
                    else if (isActive)
                    {
                        _ColorBlend.Colors = new Color[] { Color.FromArgb(255,231,164,152), 
                                                Color.FromArgb(255,231,164,152),Color.FromArgb(255,197,98,79),
                                                Color.FromArgb(255,197,98,79)};
                    }
                    else
                    {
                        _ColorBlend.Colors = new Color[] { SystemColors.ActiveBorder, 
                                                SystemColors.ActiveBorder,SystemColors.ActiveBorder,
                                                SystemColors.ActiveBorder};
                    }

                    _Brush.InterpolationColors = _ColorBlend;
                    tabGraphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                    tabGraphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                    using (Pen pen = new Pen(Color.White, 2))
                    {
                        tabGraphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                        tabGraphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                    }
                }
            }

            if (!drawButtonOnly)
            {
                //Draw tab text
                string str = this.TabPages[tabIndex].Text;
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Center;
                tabGraphics.DrawString(str, this.Font, new SolidBrush(this.TabPages[tabIndex].ForeColor), tabTextArea, stringFormat);
            }
        }

        private void zOnMouseOverButton(int tabIndex)
        {
            zSetTabIsMouseOver(tabIndex, true);
            using (Graphics tabGraphics = this.CreateGraphics())
            {
                zDrawTab(tabIndex, tabGraphics, true, true);
            }
        }

        private void zOnMouseLeaveButton(int tabIndex)
        {
            zSetTabIsMouseOver(tabIndex, false);
            using (Graphics tabGraphics = this.CreateGraphics())
            {
                zDrawTab(tabIndex, tabGraphics, false, true);
            }
        }

        private bool zGetTabIsMouseOver(int tabIndex)
        {
            bool isMouseOver;
            m_TabMouseTracker.TryGetValue(tabIndex, out isMouseOver);
            return isMouseOver;
        }

        private void zSetTabIsMouseOver(int tabIndex, bool isMouseOver)
        {
            m_TabMouseTracker[tabIndex] = isMouseOver;
        }

        private bool zHasCloseButton(int tabIndex)
        {
            TabPageEx tabPageEx = this.TabPages[tabIndex] as TabPageEx;
            bool hasCloseButton = tabPageEx == null || tabPageEx.HasCloseButton;
            return hasCloseButton;
        }

        public event EventHandler<TabControlExPageClosingEventArgs> TabPageClosing;
        protected void zOnTabPageClosing(TabControlExPageClosingEventArgs e)
        {
            EventHandler<TabControlExPageClosingEventArgs> evnt = TabPageClosing;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }

    public class TabControlExPageClosingEventArgs : EventArgs
    {
        public int TabIndex { get; private set; }
        public bool Cancel { get; set; }

        public TabControlExPageClosingEventArgs(int tabIndex)
        {
            this.TabIndex = tabIndex;
        }
    }
}
