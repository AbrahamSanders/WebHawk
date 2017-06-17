using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DataAccess;

namespace UBoat.WebHawk.UI.StepEditors
{
    public partial class ConnectionStringEditor : Form
    {
        private DbConnectionStringBuilder m_ConnectionStringBuilder;

        public DataAccessType DataAccessType { get; private set; }
        public string ConnectionString { get; private set; }

        public ConnectionStringEditor()
        {
            InitializeComponent();

            olvColumnPropertyName.AspectGetter = olvColumnPropertyName_AspectGetter;
            olvColumnPropertyValue.AspectGetter = olvColumnPropertyValue_AspectGetter;
        }

        public ConnectionStringEditor(DataAccessType dataAccessType, string connectionString)
            : this()
        {
            SetContext(dataAccessType, connectionString);
        }

        private object olvColumnPropertyName_AspectGetter(object rowObject)
        {
            return rowObject;
        }

        private object olvColumnPropertyValue_AspectGetter(object rowObject)
        {
            string key = rowObject.ToString();
            object value = null;
            m_ConnectionStringBuilder.TryGetValue(key, out value);
            return value;
        }

        public void SetContext(DataAccessType dataAccessType, string connectionString)
        {
            this.DataAccessType = dataAccessType;
            gbConnectionProperties.Text = String.Format("{0} Connection Properties", dataAccessType);

            m_ConnectionStringBuilder = DataAccessFactory.GetConnectionStringBuilder(dataAccessType);
            try
            {
                m_ConnectionStringBuilder.ConnectionString = connectionString;
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Unable to read connection string: {0}", ex.Message), "Connection String Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_ConnectionStringBuilder.ConnectionString = String.Empty;
            }

            olvConnectionProperties.SetObjects(m_ConnectionStringBuilder.Keys);
            olvConnectionProperties.AutoResizeColumn(olvColumnPropertyName.Index, ColumnHeaderAutoResizeStyle.ColumnContent);
            zUpdateConnectionString();
        }

        private void olvConnectionProperties_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            string key = e.RowObject.ToString();
            object value;
            if (m_ConnectionStringBuilder.TryGetValue(key, out value) && value != e.NewValue)
            {
                m_ConnectionStringBuilder[key] = e.NewValue;
            }

            olvConnectionProperties.RefreshObject(e.RowObject);
            zUpdateConnectionString();
        }

        private void zUpdateConnectionString()
        {
            this.ConnectionString = m_ConnectionStringBuilder.ToString();
            txtConnectionStringPreview.Text = this.ConnectionString;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
