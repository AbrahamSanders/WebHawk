using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.Utils.DOM;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class ElementAttributeSelector : UserControl
    {
        public ElementValueMode ElementValueMode
        {
            get
            {
                return rbAttribute.Checked ? ElementValueMode.Attribute : ElementValueMode.InnerText;
            }
        }

        public string AttributeName
        {
            get
            {
                return rbAttribute.Checked ? cbAttribute.Text : null;
            }
        }

        public ElementAttributeSelector()
        {
            InitializeComponent();
        }

        public ElementAttributeSelector(ElementValueMode elementValueMode, ElementIdentifier elementIdentifier, string attributeName) 
            : this()
        {
            SetContext(elementValueMode, elementIdentifier, attributeName);
        }

        public void SetContext(ElementValueMode elementValueMode, ElementIdentifier elementIdentifier, string attributeName)
        {
            cbAttribute.DataSource = zGetAttributeOptions(elementIdentifier, attributeName);
            cbAttribute.SelectedIndex = 0;

            rbAttribute.Checked = elementValueMode == ElementValueMode.Attribute;
            rbInnerText.Checked = elementValueMode == ElementValueMode.InnerText;
            cbAttribute.Enabled = rbAttribute.Checked;
            if (rbAttribute.Checked && !String.IsNullOrWhiteSpace(attributeName))
            {
                cbAttribute.Text = attributeName;
            }
        }

        private List<string> zGetAttributeOptions(ElementIdentifier elementIdentifier, string existingValue)
        {
            List<string> options = new List<string>()
            {
                "id",
                "name",
                "class",
                "style",
                "title"
            };
            string tagName = elementIdentifier.GetTagName();
            if (tagName != null)
            {
                switch (tagName.ToLower())
                {
                    case "input":
                        options.Insert(0, "value");
                        break;
                    case "img":
                        options.Insert(0, "src");
                        options.Insert(1, "alt");
                        break;
                    case "a":
                        options.Insert(0, "href");
                        break;
                }
            }
            if (!String.IsNullOrWhiteSpace(existingValue) && !options.Any(o => o.ToLower() == existingValue.ToLower()))
            {
                options.Insert(0, existingValue);
            }
            return options;
        }

        private void rbAttribute_CheckedChanged(object sender, EventArgs e)
        {
            cbAttribute.Enabled = rbAttribute.Checked;
        }
    }
}
