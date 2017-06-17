using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using web = System.Web.UI.WebControls;

namespace UBoat.Utils.DOM
{
    public class ElementSelector
    {
        #region Private members

        private WebBrowser m_Browser;
        private bool m_IsActive;

        private readonly object m_Lock;
        private bool m_BrowserContextMenuEnabled;
        private bool m_BrowserNavigationEnabled;
        private bool m_BrowserDropEnabled;
        private web.BorderStyle m_HighlightBorderStyle;
        private Color m_HighlightBorderColor;
        private web.BorderStyle m_SelectBorderStyle;
        private Color m_SelectBorderColor;
        private int m_MaxUserSelectionCount;
        private bool m_ForceUseTableRow;

        private Dictionary<HtmlElement, string> m_SelectedElements;
        private Dictionary<HtmlElement, string> m_ModifiedTables;
        private int m_UserSelectionCount;
        private HtmlElement m_HighlightedElement;
        private string m_HighlightedElementStyle;

        #endregion

        #region Public Properties

        private bool CanUserSelect
        {
            get
            {
                return m_UserSelectionCount < m_MaxUserSelectionCount;
            }
        }

        public bool IsActive
        {
            get
            {
                return m_IsActive;
            }
        }

        public web.BorderStyle HighlightBorderStyle
        {
            get
            {
                return m_HighlightBorderStyle;
            }
            set
            {
                m_HighlightBorderStyle = value;
            }
        }
        public Color HighlightBorderColor
        {
            get
            {
                return m_HighlightBorderColor;
            }
            set
            {
                m_HighlightBorderColor = value;
            }
        }
        public web.BorderStyle SelectBorderStyle
        {
            get
            {
                return m_SelectBorderStyle;
            }
            set
            {
                m_SelectBorderStyle = value;
            }
        }
        public Color SelectBorderColor
        {
            get
            {
                return m_SelectBorderColor;
            }
            set
            {
                m_SelectBorderColor = value;
            }
        }
        public int MaxUserSelectionCount
        {
            get
            {
                return m_MaxUserSelectionCount;
            }
            set
            {
                m_MaxUserSelectionCount = value;
            }
        }
        public bool ForceUseTableRow
        {
            get
            {
                return m_ForceUseTableRow;
            }
            set
            {
                m_ForceUseTableRow = value;
            }
        }
        public Dictionary<HtmlElement, string>.KeyCollection SelectedElements
        {
            get
            {
                return m_SelectedElements.Keys;
            }
        }

        #endregion

        #region Constructor

        public ElementSelector(WebBrowser browser)
        {
            m_HighlightBorderStyle = web.BorderStyle.Solid;
            m_HighlightBorderColor = Color.Red;
            m_SelectBorderStyle = web.BorderStyle.Solid;
            m_SelectBorderColor = Color.Green;
            m_MaxUserSelectionCount = Int32.MaxValue;

            m_SelectedElements = new Dictionary<HtmlElement, string>();
            m_ModifiedTables = new Dictionary<HtmlElement, string>();
            m_Lock = new object();
            m_Browser = browser;
        }

        #endregion

        #region Public Methods

        public bool Activate()
        {
            if (m_IsActive || m_Browser == null || m_Browser.Document == null)
            {
                return false;
            }

            m_BrowserContextMenuEnabled = m_Browser.IsWebBrowserContextMenuEnabled;
            m_BrowserNavigationEnabled = m_Browser.AllowNavigation;
            m_BrowserDropEnabled = m_Browser.AllowWebBrowserDrop;
            m_Browser.AllowNavigation = false;
            m_Browser.AllowWebBrowserDrop = false;
            m_Browser.IsWebBrowserContextMenuEnabled = false;

            m_Browser.Document.MouseOver += Document_MouseOver;
            m_Browser.Document.MouseUp += Document_MouseUp;

            if (m_ForceUseTableRow)
            {
                zPrepareTablesForRowSelection();
            }

            m_IsActive = true;
            return true;
        }

        public bool Deactivate()
        {
            if (!m_IsActive)
            {
                return false;
            }

            zUnhighlightElement(false);

            m_Browser.Document.MouseOver -= Document_MouseOver;
            m_Browser.Document.MouseUp -= Document_MouseUp;

            m_Browser.IsWebBrowserContextMenuEnabled = m_BrowserContextMenuEnabled;
            m_Browser.AllowNavigation = m_BrowserNavigationEnabled;
            m_Browser.AllowWebBrowserDrop = m_BrowserDropEnabled;

            zRestoreTables();

            m_IsActive = false;
            return true;
        }

        public void BlinkSelectedElement(HtmlElement element)
        {
            if (element != null && m_SelectedElements.ContainsKey(element))
            {
                Task.Run(() =>
                {
                    for (int x = 0; x < 3; x++)
                    {
                        lock (m_Lock)
                        {
                            zUnselectElement(element, false);
                            Thread.Sleep(100);
                            zHighlightElement(element, false);
                            zSelectElement(element, m_SelectBorderStyle, m_SelectBorderColor, false);
                            Thread.Sleep(100);
                        }
                    }
                });
            }
        }

        public void ClearSelection()
        {
            foreach (HtmlElement element in m_SelectedElements.Keys.ToList())
            {
                zUnselectElement(element, false);
            }
        }

        public void SelectElement(HtmlElement element)
        {
            SelectElement(element, m_SelectBorderStyle, m_SelectBorderColor);
        }

        public void SelectElement(HtmlElement element, web.BorderStyle borderStyle, Color borderColor)
        {
            if (element != null)
            {
                zHighlightElement(element, false);
                zSelectElement(element, borderStyle, borderColor, false);
            }
        }

        #endregion

        #region Private methods

        void Document_MouseUp(object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = m_Browser.Document.GetElementFromPoint(e.ClientMousePosition);
            zToggleSelectElement(element);
        }

        void Document_MouseOver(object sender, HtmlElementEventArgs e)
        {
            //Hover Off
            zUnhighlightElement(true);
            if (e.ToElement != null)
            {
                //Hover On
                HtmlElement toElement = e.ToElement;
                if (m_ForceUseTableRow)
                {
                    toElement = zForceUseTableRow(toElement);
                }
                zHighlightElement(toElement, true);
            }
        }

        private void zToggleSelectElement(HtmlElement element)
        {
            if (m_ForceUseTableRow)
            {
                element = zForceUseTableRow(element);
            }
            if (m_SelectedElements.ContainsKey(element))
            {
                zUnselectElement(element, true);
            }
            else
            {
                if (CanUserSelect)
                {
                    zSelectElement(element, m_SelectBorderStyle, m_SelectBorderColor, true);
                }
            }
        }

        private void zHighlightElement(HtmlElement element, bool fromUserAction)
        {
            if (!m_SelectedElements.ContainsKey(element))
            {
                m_HighlightedElement = element;
                m_HighlightedElementStyle = element.Style;
                element.Style = String.Format("{0}; {1}", element.Style, zGetStyleString(m_HighlightBorderStyle, m_HighlightBorderColor));

                zOnElementHighlighted(new ElementSelectorEventArgs(element, fromUserAction));
            }
        }

        private void zUnhighlightElement(bool fromUserAction)
        {
            if (m_HighlightedElement != null && !m_SelectedElements.ContainsKey(m_HighlightedElement))
            {
                HtmlElement element = m_HighlightedElement;
                element.Style = m_HighlightedElementStyle;
                m_HighlightedElement = null;
                m_HighlightedElementStyle = null;

                zOnElementUnhighlighted(new ElementSelectorEventArgs(element, fromUserAction));
            }
        }

        private void zSelectElement(HtmlElement element, web.BorderStyle borderStyle, Color borderColor, bool fromUserAction)
        {
            if (!m_SelectedElements.ContainsKey(element))
            {
                m_SelectedElements.Add(element, m_HighlightedElementStyle);
                element.Style = String.Format("{0}; {1}", m_HighlightedElementStyle, zGetStyleString(borderStyle, borderColor));

                if (fromUserAction)
                {
                    m_UserSelectionCount++;
                }
                zOnElementSelected(new ElementSelectorEventArgs(element, fromUserAction));
            }
        }

        private void zUnselectElement(HtmlElement element, bool fromUserAction)
        {
            if (m_SelectedElements.ContainsKey(element))
            {
                element.Style = m_SelectedElements[element];
                m_SelectedElements.Remove(element);

                if (fromUserAction)
                {
                    m_UserSelectionCount--;
                    zHighlightElement(element, fromUserAction);
                }
                zOnElementUnselected(new ElementSelectorEventArgs(element, fromUserAction));
            }
        }

        private string zGetStyleString(web.BorderStyle borderStyle, Color color)
        {
            return String.Format("border-style:{0};border-color:{1};border-width:2px;", Enum.GetName(typeof(web.BorderStyle), borderStyle).ToLower(), color.Name.ToLower());
        }

        private HtmlElement zForceUseTableRow(HtmlElement element)
        {
            HtmlElement parent = element.Parent;
            while (parent != null)
            {
                string parentTagName = parent.TagName.ToLower();
                if (parentTagName == "tr" || parentTagName == "li" || parentTagName == "div")
                {
                    return parent;
                }
                parent = parent.Parent;
            }
            return element;
        }

        private void zPrepareTablesForRowSelection()
        {
            foreach (HtmlElement table in m_Browser.Document.GetElementsByTagName("table"))
            {
                m_ModifiedTables.Add(table, table.Style);
                table.Style = String.Format("{0}; {1}", table.Style, "border-collapse: collapse;");
            }
        }

        private void zRestoreTables()
        {
            foreach (KeyValuePair<HtmlElement, string> modifiedTable in m_ModifiedTables)
            {
                modifiedTable.Key.Style = modifiedTable.Value;
            }
            m_ModifiedTables.Clear();
        }

        #endregion

        #region Events

        public event EventHandler<ElementSelectorEventArgs> ElementHighlighted;
        protected void zOnElementHighlighted(ElementSelectorEventArgs e)
        {
            EventHandler<ElementSelectorEventArgs> evnt = ElementHighlighted;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler<ElementSelectorEventArgs> ElementUnhighlighted;
        protected void zOnElementUnhighlighted(ElementSelectorEventArgs e)
        {
            EventHandler<ElementSelectorEventArgs> evnt = ElementUnhighlighted;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler<ElementSelectorEventArgs> ElementSelected;
        protected void zOnElementSelected(ElementSelectorEventArgs e)
        {
            EventHandler<ElementSelectorEventArgs> evnt = ElementSelected;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        public event EventHandler<ElementSelectorEventArgs> ElementUnselected;
        protected void zOnElementUnselected(ElementSelectorEventArgs e)
        {
            EventHandler<ElementSelectorEventArgs> evnt = ElementUnselected;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        #endregion
    }

    public class ElementSelectorEventArgs : EventArgs
    {
        public HtmlElement Element { get; set; }
        public bool FromUserAction { get; set; }

        public ElementSelectorEventArgs(HtmlElement element, bool fromUserAction)
        {
            this.Element = element;
            this.FromUserAction = fromUserAction;
        }
    }
}
