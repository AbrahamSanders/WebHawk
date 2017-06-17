using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBoat.Utils.DataAccess;
using UBoat.Utils.DataAccess.Metadata;

namespace DatabaseSchemaProto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessMetadata metadata;
                using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess((DataAccessType)cbConnectionType.SelectedItem, txtConnString.Text))
                {
                    metadata = dataAccess.GetMetadata((DataAccessMetadataType)cbMetadataType.SelectedItem);
                }

                switch ((DataAccessMetadataType)cbMetadataType.SelectedItem)
                {
                    case DataAccessMetadataType.Tables:
                        dgvMetadata.DataSource = metadata.Tables;
                        break;
                    case DataAccessMetadataType.TableColumns:
                        dgvMetadata.DataSource = metadata.TableColumns;
                        break;
                    case DataAccessMetadataType.Views:
                        dgvMetadata.DataSource = metadata.Views;
                        break;
                    case DataAccessMetadataType.ViewColumns:
                        dgvMetadata.DataSource = metadata.ViewColumns;
                        break;
                    case DataAccessMetadataType.Procedures:
                        dgvMetadata.DataSource = metadata.Procedures;
                        break;
                    case DataAccessMetadataType.ProcedureParameters:
                        dgvMetadata.DataSource = metadata.ProcedureParameters;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCollections_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess((DataAccessType)cbConnectionType.SelectedItem, txtConnString.Text))
                {
                    dgvMetadata.DataSource = dataAccess.GetCollections();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRestrictions_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess((DataAccessType)cbConnectionType.SelectedItem, txtConnString.Text))
                {
                    dgvMetadata.DataSource = dataAccess.GetRestrictions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDataSourceInformation_Click(object sender, EventArgs e)
        {
            try
            {
                using (IDataAccess dataAccess = DataAccessFactory.CreateDataAccess((DataAccessType)cbConnectionType.SelectedItem, txtConnString.Text))
                {
                    dgvMetadata.DataSource = dataAccess.GetDataSourceInformation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbConnectionType.DataSource = Enum.GetValues(typeof(DataAccessType));
            cbMetadataType.DataSource = Enum.GetValues(typeof(DataAccessMetadataType));
        }

        private void cbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((DataAccessType)cbConnectionType.SelectedItem)
            {
                case DataAccessType.SQL:
                    txtConnString.Text = ConfigurationManager.ConnectionStrings["DefaultSQL"].ConnectionString;
                    break;
                case DataAccessType.MySql:
                    txtConnString.Text = ConfigurationManager.ConnectionStrings["DefaultMySql"].ConnectionString;
                    break;
                default:
                    break;
            }
        }
    }
}
