using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using UBoat.Utils;
using UBoat.WebHawk.Controller.Model.Automation;
using UBoat.WebHawk.Controller.Model.Automation.Steps;
using UBoat.WebHawk.Controller.Integration.SequenceTranslators;

namespace SequenceRecorderDriver
{
    public partial class RecorderDriver : Form
    {
        public RecorderDriver()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            List<Step> sequence = new List<Step>()
            {
                new NavigateStep()
                {
                    URL = txtURL.Text
                }
            };

            sequenceRecorder1.SetSequence(sequence);
            sequenceRecorder1.RecordingEnabled = true;
            sequenceRecorder1.ExecuteSequence();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            sequenceRecorder1.ExecuteSequence();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sequenceRecorder1.StopExecution();
        }

        private void btnGenerateXML_Click(object sender, EventArgs e)
        {
            if (sequenceRecorder1.AutomationEngine != null && sequenceRecorder1.AutomationEngine.DataContext != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "XML Files (*.xml)|*.xml";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string xml = sequenceRecorder1.AutomationEngine.DataContext.ToXml();
                    File.WriteAllText(dlg.FileName, xml);
                    MessageBox.Show("Saved.");
                }
            }
        }

        private void btnGenerateXSLT_Click(object sender, EventArgs e)
        {
            if (sequenceRecorder1.AutomationEngine != null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "XSLT Files (*.xslt)|*.xslt";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ISequenceTranslator translator = SequenceTranslatorFactory.GetSequenceTranslator(SequenceTranslationType.XSLT);
                    string xslt = translator.Translate(sequenceRecorder1.AutomationEngine.Sequence).ToString();
                    File.WriteAllText(dlg.FileName, xslt);
                    MessageBox.Show("Saved.");
                }
            }
        }

        private void RecorderDriver_Load(object sender, EventArgs e)
        {
            zCheckIEBrowserMode();
        }

        private void zCheckIEBrowserMode()
        {
            IEBrowserMode? installedIEVersion = RegistryUtils.GetInstalledIEBrowserVersion();
            if (installedIEVersion == null)
            {
                MessageBox.Show("Could not determine installed IE version. If the application browser emulation mode is not synchronized with the installed IE version, some unexpected behavior can occur.",
                    "Browser Detection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            IEBrowserMode? applicationIEBrowserMode = RegistryUtils.GetApplicationIEBrowserMode();
            if (applicationIEBrowserMode != installedIEVersion)
            {
                RegistryUtils.SetApplicationIEBrowserMode(installedIEVersion.Value);
            }
        }
    }
}
