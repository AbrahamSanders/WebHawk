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
using UBoat.WebHawk.Controller.Model.Automation.Iterations;
using UBoat.WebHawk.UI.StepEditors.IterationEditors;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class GroupStepEditor : StepEditor
    {
        protected GroupStep Step
        {
            get
            {
                return (GroupStep)StepEditContext.Step;
            }
        }
        Iteration m_Iteration;
        StepEditor m_IterationEditor;

        public GroupStepEditor()
        {
            InitializeComponent();
            this.Disposed += GroupStepEditor_Disposed;

            cbIteration.DisplayMember = "Key";
            cbIteration.ValueMember = "Value";
            cbIteration.DataSource = new BindingSource(new Dictionary<string, Type>()
            {
                { "None", null },
                { "Fixed Iteration", typeof(FixedIteration) },
                { "Conditional Iteration", typeof(ConditionalIteration) },
                { "Element Set Iteration", typeof(ElementSetIteration) },
                { "Data Set Iteration", typeof(DataSetIteration) }
            }, null);
        }

        public GroupStepEditor(StepEditContext context)
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            m_Iteration = Step.Iteration;
            if (m_Iteration != null)
            {
                cbIteration.SelectedValue = m_Iteration.GetType();
            }
        }

        private void cbIteration_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type selectedItem = (Type)cbIteration.SelectedValue;
            if (selectedItem == null && m_Iteration != null)
            {
                m_Iteration = null;
            }
            if (selectedItem == typeof(FixedIteration) && !(m_Iteration is FixedIteration))
            {
                m_Iteration = new FixedIteration()
                {
                    Iterations = 1
                };
            }
            if (selectedItem == typeof(ConditionalIteration) && !(m_Iteration is ConditionalIteration))
            {
                m_Iteration = new ConditionalIteration();
            }
            if (selectedItem == typeof(ElementSetIteration) && !(m_Iteration is ElementSetIteration))
            {
                m_Iteration = new ElementSetIteration()
                {
                    IncludeInXML = true
                };
            }
            if (selectedItem == typeof(DataSetIteration) && !(m_Iteration is DataSetIteration))
            {
                m_Iteration = new DataSetIteration();
            }

            zUpdateIterationEditor();
        }

        private void zUpdateIterationEditor()
        {
            zClearIterationEditor();
            if (m_Iteration != null)
            {
                gbIterationEditor.Visible = true;
                m_IterationEditor = IterationEditorFactory.GetIterationEditor(this.StepEditContext, m_Iteration);
                m_IterationEditor.Dock = DockStyle.Fill;
                gbIterationEditor.Controls.Add(m_IterationEditor);
                gbIterationEditor.Text = m_IterationEditor.Title;
            }
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            if (m_IterationEditor != null)
            {
                result.Append(m_IterationEditor.PerformValidation());
            }
            return result;
        }

        public override void Save()
        {
            if (m_IterationEditor != null)
            {
                m_IterationEditor.Save();
            }
            Step.Iteration = m_Iteration;
        }

        void GroupStepEditor_Disposed(object sender, EventArgs e)
        {
            zClearIterationEditor();
        }

        private void zClearIterationEditor()
        {
            gbIterationEditor.Visible = false;
            if (m_IterationEditor != null)
            {
                m_IterationEditor.Dispose();
                gbIterationEditor.Controls.Clear();
                m_IterationEditor = null;
            }
        }
    }
}
