using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;

namespace UBoat.WebHawk.UI.Wizards.Scrape
{
    public partial class ScrapeWizardName : WizardPage
    {
        public ScrapeWizardName()
        {
            InitializeComponent();
            txtURL1.TextChanged += URLTextbox_TextChanged;
            txtURL2.TextChanged += URLTextbox_TextChanged;
            txtURL3.TextChanged += URLTextbox_TextChanged;
        }

        protected override void InitPage()
        {
            if (this.Task.TaskSequence.Name != null)
            {
                txtName.Text = this.Task.TaskSequence.Name;
            }

            //List<NavigateStep> navSteps = this.Task.TaskSequence.SequenceSteps.OfType<NavigateStep>().ToList();
            //zPopulateURLTextboxes(navSteps);
        }

        private void zPopulateURLTextboxes(List<NavigateStep> navSteps)
        {
            List<TextBox> textboxes = URLPanel.Controls.OfType<TextBox>().ToList();
            for (int x = 0; x < navSteps.Count; x++)
            {
                if (x < textboxes.Count)
                {
                    textboxes[x].Text = navSteps[x].URL;
                }
                else
                {
                    TextBox newTextbox = zAddURLTextbox();
                    newTextbox.Text = navSteps[x].URL;
                }
            }
        }

        private TextBox zAddURLTextbox()
        {
            TextBox model = URLPanel.Controls.OfType<TextBox>().Last();
            TextBox newTextbox = new TextBox();
            newTextbox.Size = model.Size;
            newTextbox.Location = new Point(model.Location.X, model.Bottom + 6);
            newTextbox.Text = "http://";
            newTextbox.TextChanged += URLTextbox_TextChanged;
            URLPanel.Controls.Add(newTextbox);
            btnAddUrl.Location = new Point(btnAddUrl.Location.X, newTextbox.Bottom + 6);
            return newTextbox;
        }

        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            zAddURLTextbox();
        }

        void URLTextbox_TextChanged(object sender, EventArgs e)
        {
            ValidateNext();
        }

        private List<string> zGetURLs()
        {
            List<string> urls = new List<string>();
            foreach (TextBox textbox in URLPanel.Controls.OfType<TextBox>())
            {
                if (Regex.IsMatch(textbox.Text, @"\b(https?|ftp|file)://[-A-Z0-9+&@#/%?=~_|$!:,.;]*[A-Z0-9+&@#/%=~_|$]", RegexOptions.IgnoreCase))
                {
                    urls.Add(textbox.Text);
                }
            }
            return urls;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblNameExists.Visible = false;
            ValidateNext();
        }

        protected override void ValidateNext()
        {
            if (!String.IsNullOrWhiteSpace(txtName.Text) && zGetURLs().Any())
            {
                if (txtName.Text == this.Task.TaskSequence.Name || WebHawkAppContext.AutomationController.ValidateNewSequenceName(txtName.Text))
                {
                    zOnEnableNext(EventArgs.Empty);
                    return;
                }
                else
                {
                    lblNameExists.Visible = true;
                }
            }
            zOnDisableNext(EventArgs.Empty);
        }

        public override void OnNext()
        {
            //List<NavigateStep> navSteps = this.Task.TaskSequence.SequenceSteps.OfType<NavigateStep>().ToList();
            //List<string> urls = zGetURLs();
            //for (int x = 0; x < urls.Count; x++)
            //{
            //    if (x < navSteps.Count)
            //    {
            //        navSteps[x].URL = urls[x];
            //    }
            //    else
            //    {
            //        NavigateStep navStep = new NavigateStep();
            //        navStep.URL = urls[x];
            //        this.Task.TaskSequence.SequenceSteps.Add(navStep);
            //    }
            //}
        }
    }
}
