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
using UBoat.WebHawk.Controller.Model.Notification;
using UBoat.Utils.Validation;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class NotifyStepEditor : StepEditor
    {
        private List<Notification> m_Notifications;
        private bool m_AddNotificationMode;

        protected NotifyStep Step
        {
            get
            {
                return (NotifyStep)StepEditContext.Step;
            }
        }

        public NotifyStepEditor()
        {
            InitializeComponent();

            olvColumnDelete.AspectGetter = (obj) => "Delete";
        }

        public NotifyStepEditor(StepEditContext context)
            : this()
        {
            this.SetContext(context);
        }

        public override void SetContext(StepEditContext context)
        {
            base.SetContext(context);

            m_Notifications = Step.Notifications.Select(n => n.Clone()).ToList();
            zRefreshNotifications();

            messageEditor.SetContext(StepEditContext.StateVariables, Step.Message, Step.TrimVariableValueWhitespace);
        }

        #region Notifications

        private void zRefreshNotifications()
        {
            if (m_Notifications != null)
            {
                olvNotifications.SetObjects(m_Notifications);
            }
        }

        private void zRefreshNotification(Notification notification)
        {
            olvNotifications.RefreshObject(notification);
        }

        private void btnAddNotification_Click(object sender, EventArgs e)
        {
            m_Notifications.Add(new Notification()
            {
                NotificationType = NotificationType.Email,
                Address = "Address here..."
            });
            m_AddNotificationMode = true;
            zRefreshNotifications();
            olvNotifications.EditSubItem(olvNotifications.GetItem(m_Notifications.Count - 1), 0);
        }

        private void olvNotifications_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == olvColumnType)
            {
                ComboBox cb = new ComboBox();
                cb.Bounds = e.CellBounds;
                cb.Font = ((BrightIdeasSoftware.ObjectListView)sender).Font;
                cb.DropDownStyle = ComboBoxStyle.DropDownList;
                e.Control = cb;

                //DataBinding with enum source causes issue where cb.Items is empty, so items are added manually.
                foreach (NotificationType notificationType in Enum.GetValues(typeof(NotificationType)))
                {
                    cb.Items.Add(notificationType);
                }
                cb.SelectedItem = ((Notification)e.RowObject).NotificationType;
            }
        }

        private void olvNotifications_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column.IsEditable)
            {
                if (!e.Cancel)
                {
                    Notification notification = (Notification)e.RowObject;
                    if (e.Column == olvColumnType)
                    {
                        ComboBox cb = (ComboBox)e.Control;
                        notification.NotificationType = (NotificationType)cb.SelectedItem;
                    }
                    if (e.Column == olvColumnAddress)
                    {
                        notification.Address = e.NewValue.ToString();
                    }
                    zRefreshNotification(notification);
                    e.Cancel = true;
                }
                else if (m_AddNotificationMode)
                {
                    m_Notifications.RemoveAt(e.ListViewItem.Index);
                    zRefreshNotifications();
                }
                m_AddNotificationMode = false;
            }
        }

        private void olvNotifications_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnDelete)
            {
                m_Notifications.Remove((Notification)e.Model);
                zRefreshNotifications();
            }
            e.Handled = true;
        }

        #endregion

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            return result;
        }

        public override void Save()
        {
            base.Save();

            Step.Notifications.Clear();
            Step.Notifications.AddRange(m_Notifications);
            Step.TrimVariableValueWhitespace = messageEditor.TrimVariableValueWhitespace;
            Step.Message = messageEditor.Value;
        }
    }
}
