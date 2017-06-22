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
using UBoat.WebHawk.UI.StepEditors.NotificationEditors;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class NotifyStepEditor : StepEditor
    {
        private List<Notification> m_Notifications;
        private Notification m_Notification;
        private StepEditor m_NotificationEditor;

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
            this.Disposed += NotifyStepEditor_Disposed;

            olvNotifications.HotItemStyle = new BrightIdeasSoftware.HotItemStyle()
            {
                Decoration = new BrightIdeasSoftware.RowBorderDecoration()
                {
                    BorderPen = new Pen(Color.Transparent, 2),
                    BoundsPadding = new Size(1, 1),
                    CornerRounding = 4.0f
                }
            };

            olvColumnTarget.AspectGetter = (obj) => Convert.ToString(obj);
            olvColumnDelete.AspectGetter = (obj) => "Delete";

            cbNotificationType.DisplayMember = "Key";
            cbNotificationType.ValueMember = "Value";
            cbNotificationType.DataSource = new BindingSource(new Dictionary<string, Type>()
            {
                { "Email", typeof(EmailNotification) },
                { "SMS", typeof(SMSNotification) },
                { "Popup", typeof(PopupNotification) }
            }, null);
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

        private void olvNotifications_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            if (e.Model == m_Notification)
            {
                e.Item.Decoration = new BrightIdeasSoftware.RowBorderDecoration()
                {
                    BorderPen = new Pen(Color.Transparent, 2),
                    BoundsPadding = new Size(1, 1),
                    CornerRounding = 4.0f
                };
            }
        }

        private void zRefreshNotifications()
        {
            if (m_Notifications != null)
            {
                olvNotifications.SetObjects(m_Notifications);
            }
        }

        private void btnAddSaveNotification_Click(object sender, EventArgs e)
        {
            if (m_Notification == null)
            { 
                Type selectedItem = (Type)cbNotificationType.SelectedValue;
                if (selectedItem == typeof(EmailNotification))
                {
                    m_Notification = new EmailNotification();
                }
                if (selectedItem == typeof(SMSNotification))
                {
                    m_Notification = new SMSNotification();
                }
                if (selectedItem == typeof(PopupNotification))
                {
                    m_Notification = new PopupNotification();
                }
                m_Notifications.Add(m_Notification);
            }
            else
            { 
                m_NotificationEditor.Save();
                m_Notification = null;
            }
            zRefreshNotifications();
            zUpdateNotificationEditor();
        }

        private void olvNotifications_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            m_Notification = (Notification)e.Model;
            zRefreshNotifications();
            zUpdateNotificationEditor();
        }

        private void zUpdateNotificationEditor()
        {
            zClearNotificationEditor();
            if (m_Notification != null)
            {
                Type notificationType = m_Notification.GetType();
                cbNotificationType.SelectedValue = notificationType;

                gbNotificationEditor.Visible = true;
                m_NotificationEditor = NotificationEditorFactory.GetNotificationEditor(this.StepEditContext, m_Notification);
                m_NotificationEditor.Dock = DockStyle.Fill;
                gbNotificationEditor.Controls.Add(m_NotificationEditor);
                gbNotificationEditor.Text = m_NotificationEditor.Title;
            }
            cbNotificationType.Enabled = m_Notification == null;
            btnAddSaveNotification.BackgroundImage = m_Notification != null 
                ? Properties.Resources.save 
                : Properties.Resources.Add;
        }

        private void olvNotifications_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            if (e.Column == olvColumnDelete)
            {
                Notification notification = (Notification)e.Model;
                m_Notifications.Remove(notification);
                if (notification == m_Notification)
                {
                    m_Notification = null;
                    zUpdateNotificationEditor();
                }
                zRefreshNotifications();
            }
            e.Handled = true;
        }

        private void NotifyStepEditor_Disposed(object sender, EventArgs e)
        {
            zClearNotificationEditor();
        }

        private void zClearNotificationEditor()
        {
            gbNotificationEditor.Visible = false;
            if (m_NotificationEditor != null)
            {
                m_NotificationEditor.Dispose();
                gbNotificationEditor.Controls.Clear();
                m_NotificationEditor = null;
            }
        }

        #endregion

        public override ValidationResult PerformValidation()
        {
            ValidationResult result = base.PerformValidation();
            if (m_NotificationEditor != null)
            {
                result.Append(m_NotificationEditor.PerformValidation());
            }
            return result;
        }

        public override void Save()
        {
            base.Save();

            if (m_NotificationEditor != null)
            {
                m_NotificationEditor.Save();
            }
            Step.Notifications.Clear();
            Step.Notifications.AddRange(m_Notifications);
            Step.TrimVariableValueWhitespace = messageEditor.TrimVariableValueWhitespace;
            Step.Message = messageEditor.Value;
        }
    }
}
