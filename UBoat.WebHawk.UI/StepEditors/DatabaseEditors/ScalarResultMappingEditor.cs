using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.WebHawk.Controller.Model.Database;
using UBoat.Utils.Validation;
using UBoat.WebHawk.Controller.Model.Data;

namespace UBoat.WebHawk.UI.StepEditors.DatabaseEditors
{
    public partial class ScalarResultMappingEditor : ScalarResultMappingEditorBase
    {
        public override string Title
        {
            get
            {
                return "Scalar Result";
            }
        }
        public ScalarResultMappingEditor()
        {
            InitializeComponent();
        }

        public ScalarResultMappingEditor(StepEditContext context, ScalarResultMapping mapping)
            : this()
        {
            this.SetContext(context, mapping);
        }

        public override void SetContext(StepEditContext context, ScalarResultMapping mapping)
        {
            base.SetContext(context, mapping);

            cbVariableName.BindEditableStateVariables(context.StateVariables.Primitives(), mapping.StateVariable);
            cbPersistVariable.Checked = mapping.PersistenceMode == PersistenceMode.Persisted;
            rbXMLElement.Checked = mapping.XMLFieldOutputMode == XMLFieldOutputMode.Element;
            rbXMLAttribute.Checked = mapping.XMLFieldOutputMode == XMLFieldOutputMode.Attribute;
            rbXMLNone.Checked = mapping.XMLFieldOutputMode == XMLFieldOutputMode.None;
        }

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            this.Target.StateVariable = cbVariableName.Text;
            this.Target.PersistenceMode = cbPersistVariable.Checked ? PersistenceMode.Persisted : PersistenceMode.None;
            this.Target.XMLFieldOutputMode = rbXMLAttribute.Checked
                ? XMLFieldOutputMode.Attribute
                : rbXMLElement.Checked
                    ? XMLFieldOutputMode.Element
                    : XMLFieldOutputMode.None;
        }
    }

    /// <summary>
    /// BULLSHIT intermediate base class becuase the winforms designer can't load anything whos immediate base class is generic... FUCK!
    /// Just pretend this isn't here and go on with your day.
    /// http://stackoverflow.com/questions/13345551/why-do-base-windows-forms-form-class-with-generic-types-stop-the-designer-loadin
    /// </summary>
    public class ScalarResultMappingEditorBase : StepEditor<ScalarResultMapping>
    {
    }
}
