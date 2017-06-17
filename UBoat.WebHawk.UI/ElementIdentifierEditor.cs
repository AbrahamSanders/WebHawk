using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DOM;

namespace UBoat.WebHawk.UI
{
    public partial class ElementIdentifierEditor : UserControl
    {
        private ElementIdentifier m_ElementIdentifier;
        private List<String> m_Paths;
        private bool m_AddMode;

        public ElementIdentifierEditor()
        {
            InitializeComponent();

            m_Paths = new List<string>();
            olvColumnPath.AspectGetter = (obj) => obj.ToString();
            olvColumnPath.ImageGetter = zIsPrimaryImageGetter;
            olvColumnDelete.AspectGetter = (obj) => "Delete";
            imageList1.Images.AddRange(new Image[]
            {
                Properties.Resources.goldstar
            });
        }

        public ElementIdentifierEditor(ElementIdentifier elementIdentifier) 
            : this()
        {
            SetElementIdentifier(elementIdentifier);
        }

        public void SetElementIdentifier(ElementIdentifier elementIdentifier)
        {
            m_ElementIdentifier = elementIdentifier;
            m_Paths = m_ElementIdentifier.Identifiers.ToList();
            zRefresh();
        }

        private void zRefresh()
        {
            if (m_Paths != null)
            {
                olvIdentifierPaths.SetObjects(m_Paths);
            }
        }

        public void Save()
        {
            m_ElementIdentifier.Identifiers.Clear();
            m_ElementIdentifier.Identifiers.AddRange(m_Paths);
        }

        private object zIsPrimaryImageGetter(object obj)
        {
            if (m_Paths.Count > 0 && m_Paths[0] == obj.ToString())
            {
                return 0;
            }
            return -1;
        }

        private void olvIdentifierPaths_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == olvColumnPath)
            {
                if (!e.Cancel)
                {
                    m_Paths[e.ListViewItem.Index] = e.NewValue.ToString();
                    zRefresh();
                    e.Cancel = true;
                }
                else if (m_AddMode)
                {
                    m_Paths.RemoveAt(e.ListViewItem.Index);
                    zRefresh();
                }
                m_AddMode = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m_Paths.Add("Insert path here...");
            m_AddMode = true;
            zRefresh();
            olvIdentifierPaths.EditSubItem(olvIdentifierPaths.GetItem(m_Paths.Count - 1), 0);
        }

        private void olvIdentifierPaths_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnDelete)
            {
                m_Paths.Remove((string)e.Model);
                zRefresh();
            }
            e.Handled = true;
        }
    }
}
