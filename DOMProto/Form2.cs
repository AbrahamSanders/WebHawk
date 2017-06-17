using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DOM;
using UBoat.WebHawk.UI;

namespace DOMProto
{
    public partial class Form2 : Form
    {
        private ElementSelector m_Selector;
        private List<ElementIdentifier> m_ElementIdentifiers;

        public Form2()
        {
            InitializeComponent();

            m_ElementIdentifiers = new List<ElementIdentifier>();
            olvColumnTagName.AspectGetter = (obj) => ((ElementIdentifier)obj).GetTagName();
            olvColumnEdit.AspectGetter = (obj) => "Edit...";
            olvColumnDelete.AspectGetter = (obj) => "Delete";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            m_Selector = new ElementSelector(webBrowser1);
            //m_Selector.ForceUseTableRow = true;
            m_Selector.ElementHighlighted += m_Selector_ElementHighlighted;
            
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            webBrowser1.Navigate("http://www.mybrowserinfo.com/");

            zRefreshList();
        }

        private void zRefreshList()
        {
            olvElementIdentifiers.SetObjects(m_ElementIdentifiers);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            m_Selector.Activate();
        }

        void m_Selector_ElementHighlighted(object sender, ElementSelectorEventArgs e)
        {
            if (e.FromUserAction)
            {
                ElementIdentifier identifier = ElementIdentifier.FromHtmlElement(e.Element);
                gbBrowser.Text = identifier.PrimaryIdentifier;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (m_Selector.SelectedElements.Count > 0)
            {
                foreach (HtmlElement element in m_Selector.SelectedElements)
                {
                    ElementIdentifier elementIdentifier = ElementIdentifier.FromHtmlElement(element);
                    m_ElementIdentifiers.Add(elementIdentifier);
                }
                m_Selector.ClearSelection();
                zRefreshList();
            }
            else
            {
                ElementIdentifier elementIdentifier = new ElementIdentifier();
                using (frmElementIdentifierEditor frm = new frmElementIdentifierEditor(elementIdentifier))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        m_ElementIdentifiers.Add(elementIdentifier);
                        zRefreshList();
                    }
                }
            }
        }

        private void olvElementIdentifiers_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnEdit)
            {
                using (frmElementIdentifierEditor frm = new frmElementIdentifierEditor((ElementIdentifier)e.Model))
                {
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        zRefreshList();
                    }
                }
            }
            if (e.Column == olvColumnDelete)
            {
                m_ElementIdentifiers.Remove((ElementIdentifier)e.Model);
                zRefreshList();
            }
        }

        private void olvElementIdentifiers_SelectionChanged(object sender, EventArgs e)
        {
            if (olvElementIdentifiers.SelectedObjects.Count == 1)
            {
                btnParent.Enabled = true;
                btnRemoveSelector.Enabled = true;
                btnRelative.Enabled = false;
                btnAbsolute.Enabled = false;
            }
            else if (olvElementIdentifiers.SelectedObjects.Count == 2)
            {
                btnParent.Enabled = false;
                btnRemoveSelector.Enabled = false;
                btnRelative.Enabled = true;
                btnAbsolute.Enabled = true;
            }
            else
            {
                btnParent.Enabled = false;
                btnRemoveSelector.Enabled = false;
                btnRelative.Enabled = false;
                btnAbsolute.Enabled = false;
            }
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            ElementIdentifier elementIdentifier = (ElementIdentifier)olvElementIdentifiers.SelectedObject;
            ElementIdentifier parent = elementIdentifier.GetParent();
            m_ElementIdentifiers.Add(parent);
            zRefreshList();
        }

        private void btnRemoveSelector_Click(object sender, EventArgs e)
        {
            ElementIdentifier elementIdentifier = (ElementIdentifier)olvElementIdentifiers.SelectedObject;
            ElementIdentifier nonAbsolute = elementIdentifier.RemoveSelector();
            m_ElementIdentifiers.Add(nonAbsolute);
            zRefreshList();
        }

        private void btnRelative_Click(object sender, EventArgs e)
        {
            ElementIdentifier baseElement = (ElementIdentifier)olvElementIdentifiers.SelectedObjects[0];
            ElementIdentifier targetElement = (ElementIdentifier)olvElementIdentifiers.SelectedObjects[1];
            ElementIdentifier relative = targetElement.RelativeTo(baseElement);
            m_ElementIdentifiers.Add(relative);
            zRefreshList();
        }

        private void btnAbsolute_Click(object sender, EventArgs e)
        {
            ElementIdentifier baseElement = (ElementIdentifier)olvElementIdentifiers.SelectedObjects[0];
            ElementIdentifier targetElement = (ElementIdentifier)olvElementIdentifiers.SelectedObjects[1];
            ElementIdentifier absolute = targetElement.AbsoluteTo(baseElement);
            m_ElementIdentifiers.Add(absolute);
            zRefreshList();
        }

        private void olvElementIdentifiers_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ElementIdentifier elementIdentifier = (ElementIdentifier)e.Model;
                WebBrowserHelper wb = new WebBrowserHelper(webBrowser1, TimeSpan.FromSeconds(15));
                List<HtmlElement> elements = wb.FindElements(elementIdentifier);
                foreach (HtmlElement element in elements)
                {
                    if (!m_Selector.SelectedElements.Contains(element))
                    {
                        m_Selector.SelectElement(element);
                    }
                }
            }
        }

        private void btnBrowserVersion_Click(object sender, EventArgs e)
        {
            MessageBox.Show(webBrowser1.Version.ToString());
        }
    }
}
