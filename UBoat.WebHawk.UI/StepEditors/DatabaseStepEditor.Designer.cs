namespace UBoat.WebHawk.UI.StepEditors
{
    partial class DatabaseStepEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbConnectionType = new System.Windows.Forms.ComboBox();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnBuildConnectionString = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCommand = new System.Windows.Forms.GroupBox();
            this.btnFindStoredProcedure = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCommandType = new System.Windows.Forms.ComboBox();
            this.commandEditor = new UBoat.WebHawk.UI.StepEditors.OutputValueEditor();
            this.tabControlInputOutput = new System.Windows.Forms.TabControl();
            this.tpInputParameters = new System.Windows.Forms.TabPage();
            this.btnDetectInputParameters = new System.Windows.Forms.Button();
            this.olvInputParameters = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnInputParameterName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnInputParameterValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnInputParameterTrim = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnInputParameterDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnAddInputParameter = new System.Windows.Forms.Button();
            this.tpOutputParameters = new System.Windows.Forms.TabPage();
            this.btnDetectOutputParameters = new System.Windows.Forms.Button();
            this.btnAddOutputParameter = new System.Windows.Forms.Button();
            this.olvOutputParameters = new BrightIdeasSoftware.ObjectListView();
            this.olvColumnOutputParameterType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOutputParameterName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOutputParameterStateVariable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOutputParameterXMLOutputMode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOutputParameterPersistenceMode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnOutputParameterDelete = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tpResults = new System.Windows.Forms.TabPage();
            this.gbResultMappingEditor = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbResultType = new System.Windows.Forms.ComboBox();
            this.gbConnection.SuspendLayout();
            this.gbCommand.SuspendLayout();
            this.tabControlInputOutput.SuspendLayout();
            this.tpInputParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvInputParameters)).BeginInit();
            this.tpOutputParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvOutputParameters)).BeginInit();
            this.tpResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbConnectionType
            // 
            this.cbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConnectionType.FormattingEnabled = true;
            this.cbConnectionType.Location = new System.Drawing.Point(106, 19);
            this.cbConnectionType.Name = "cbConnectionType";
            this.cbConnectionType.Size = new System.Drawing.Size(166, 21);
            this.cbConnectionType.TabIndex = 0;
            // 
            // gbConnection
            // 
            this.gbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConnection.Controls.Add(this.btnTestConnection);
            this.gbConnection.Controls.Add(this.btnBuildConnectionString);
            this.gbConnection.Controls.Add(this.label2);
            this.gbConnection.Controls.Add(this.txtConnectionString);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.cbConnectionType);
            this.gbConnection.Location = new System.Drawing.Point(3, 3);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(655, 77);
            this.gbConnection.TabIndex = 1;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.Location = new System.Drawing.Point(603, 44);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(46, 23);
            this.btnTestConnection.TabIndex = 5;
            this.btnTestConnection.Text = "Test...";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnBuildConnectionString
            // 
            this.btnBuildConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildConnectionString.Location = new System.Drawing.Point(565, 44);
            this.btnBuildConnectionString.Name = "btnBuildConnectionString";
            this.btnBuildConnectionString.Size = new System.Drawing.Size(32, 23);
            this.btnBuildConnectionString.TabIndex = 4;
            this.btnBuildConnectionString.Text = "...";
            this.btnBuildConnectionString.UseVisualStyleBackColor = true;
            this.btnBuildConnectionString.Click += new System.EventHandler(this.btnBuildConnectionString_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Connection String:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConnectionString.Location = new System.Drawing.Point(106, 46);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(453, 20);
            this.txtConnectionString.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connection Type:";
            // 
            // gbCommand
            // 
            this.gbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCommand.Controls.Add(this.btnFindStoredProcedure);
            this.gbCommand.Controls.Add(this.label3);
            this.gbCommand.Controls.Add(this.cbCommandType);
            this.gbCommand.Controls.Add(this.commandEditor);
            this.gbCommand.Location = new System.Drawing.Point(3, 86);
            this.gbCommand.Name = "gbCommand";
            this.gbCommand.Size = new System.Drawing.Size(655, 156);
            this.gbCommand.TabIndex = 2;
            this.gbCommand.TabStop = false;
            this.gbCommand.Text = "Command";
            // 
            // btnFindStoredProcedure
            // 
            this.btnFindStoredProcedure.Location = new System.Drawing.Point(278, 17);
            this.btnFindStoredProcedure.Name = "btnFindStoredProcedure";
            this.btnFindStoredProcedure.Size = new System.Drawing.Size(32, 23);
            this.btnFindStoredProcedure.TabIndex = 5;
            this.btnFindStoredProcedure.Text = "...";
            this.btnFindStoredProcedure.UseVisualStyleBackColor = true;
            this.btnFindStoredProcedure.Click += new System.EventHandler(this.btnFindStoredProcedure_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Command Type:";
            // 
            // cbCommandType
            // 
            this.cbCommandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCommandType.FormattingEnabled = true;
            this.cbCommandType.Location = new System.Drawing.Point(106, 19);
            this.cbCommandType.Name = "cbCommandType";
            this.cbCommandType.Size = new System.Drawing.Size(166, 21);
            this.cbCommandType.TabIndex = 2;
            this.cbCommandType.SelectedIndexChanged += new System.EventHandler(this.cbCommandType_SelectedIndexChanged);
            // 
            // commandEditor
            // 
            this.commandEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandEditor.Location = new System.Drawing.Point(9, 46);
            this.commandEditor.Name = "commandEditor";
            this.commandEditor.Size = new System.Drawing.Size(640, 104);
            this.commandEditor.TabIndex = 0;
            this.commandEditor.TrimVariableValueWhitespace = false;
            this.commandEditor.Value = "";
            // 
            // tabControlInputOutput
            // 
            this.tabControlInputOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlInputOutput.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlInputOutput.Controls.Add(this.tpInputParameters);
            this.tabControlInputOutput.Controls.Add(this.tpOutputParameters);
            this.tabControlInputOutput.Controls.Add(this.tpResults);
            this.tabControlInputOutput.Location = new System.Drawing.Point(3, 248);
            this.tabControlInputOutput.Multiline = true;
            this.tabControlInputOutput.Name = "tabControlInputOutput";
            this.tabControlInputOutput.SelectedIndex = 0;
            this.tabControlInputOutput.Size = new System.Drawing.Size(655, 256);
            this.tabControlInputOutput.TabIndex = 3;
            // 
            // tpInputParameters
            // 
            this.tpInputParameters.Controls.Add(this.btnDetectInputParameters);
            this.tpInputParameters.Controls.Add(this.olvInputParameters);
            this.tpInputParameters.Controls.Add(this.btnAddInputParameter);
            this.tpInputParameters.Location = new System.Drawing.Point(4, 25);
            this.tpInputParameters.Name = "tpInputParameters";
            this.tpInputParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tpInputParameters.Size = new System.Drawing.Size(647, 227);
            this.tpInputParameters.TabIndex = 0;
            this.tpInputParameters.Text = "Input Params";
            this.tpInputParameters.UseVisualStyleBackColor = true;
            // 
            // btnDetectInputParameters
            // 
            this.btnDetectInputParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetectInputParameters.Location = new System.Drawing.Point(5, 189);
            this.btnDetectInputParameters.Name = "btnDetectInputParameters";
            this.btnDetectInputParameters.Size = new System.Drawing.Size(75, 23);
            this.btnDetectInputParameters.TabIndex = 3;
            this.btnDetectInputParameters.Text = "Detect...";
            this.btnDetectInputParameters.UseVisualStyleBackColor = true;
            this.btnDetectInputParameters.Click += new System.EventHandler(this.btnDetectInputParameters_Click);
            // 
            // olvInputParameters
            // 
            this.olvInputParameters.AllColumns.Add(this.olvColumnInputParameterName);
            this.olvInputParameters.AllColumns.Add(this.olvColumnInputParameterValue);
            this.olvInputParameters.AllColumns.Add(this.olvColumnInputParameterTrim);
            this.olvInputParameters.AllColumns.Add(this.olvColumnInputParameterDelete);
            this.olvInputParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvInputParameters.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvInputParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnInputParameterName,
            this.olvColumnInputParameterValue,
            this.olvColumnInputParameterTrim,
            this.olvColumnInputParameterDelete});
            this.olvInputParameters.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvInputParameters.EmptyListMsg = "No Parameters Added.";
            this.olvInputParameters.FullRowSelect = true;
            this.olvInputParameters.Location = new System.Drawing.Point(5, 6);
            this.olvInputParameters.Name = "olvInputParameters";
            this.olvInputParameters.ShowGroups = false;
            this.olvInputParameters.Size = new System.Drawing.Size(640, 177);
            this.olvInputParameters.TabIndex = 0;
            this.olvInputParameters.UseCompatibleStateImageBehavior = false;
            this.olvInputParameters.UseHyperlinks = true;
            this.olvInputParameters.View = System.Windows.Forms.View.Details;
            this.olvInputParameters.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvInputParameters_CellEditFinishing);
            this.olvInputParameters.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvInputParameters_CellEditStarting);
            this.olvInputParameters.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvInputParameters_HyperlinkClicked);
            // 
            // olvColumnInputParameterName
            // 
            this.olvColumnInputParameterName.AspectName = "ParameterName";
            this.olvColumnInputParameterName.Groupable = false;
            this.olvColumnInputParameterName.Hideable = false;
            this.olvColumnInputParameterName.Searchable = false;
            this.olvColumnInputParameterName.Sortable = false;
            this.olvColumnInputParameterName.Text = "Parameter Name";
            this.olvColumnInputParameterName.UseFiltering = false;
            this.olvColumnInputParameterName.Width = 192;
            // 
            // olvColumnInputParameterValue
            // 
            this.olvColumnInputParameterValue.AspectName = "ParameterValue";
            this.olvColumnInputParameterValue.Groupable = false;
            this.olvColumnInputParameterValue.Hideable = false;
            this.olvColumnInputParameterValue.Searchable = false;
            this.olvColumnInputParameterValue.Sortable = false;
            this.olvColumnInputParameterValue.Text = "Value";
            this.olvColumnInputParameterValue.UseFiltering = false;
            this.olvColumnInputParameterValue.Width = 288;
            // 
            // olvColumnInputParameterTrim
            // 
            this.olvColumnInputParameterTrim.AspectName = "TrimVariableValueWhitespace";
            this.olvColumnInputParameterTrim.Groupable = false;
            this.olvColumnInputParameterTrim.Hideable = false;
            this.olvColumnInputParameterTrim.Searchable = false;
            this.olvColumnInputParameterTrim.Sortable = false;
            this.olvColumnInputParameterTrim.Text = "Trim Whitespace";
            this.olvColumnInputParameterTrim.UseFiltering = false;
            this.olvColumnInputParameterTrim.Width = 93;
            // 
            // olvColumnInputParameterDelete
            // 
            this.olvColumnInputParameterDelete.Groupable = false;
            this.olvColumnInputParameterDelete.Hideable = false;
            this.olvColumnInputParameterDelete.Hyperlink = true;
            this.olvColumnInputParameterDelete.IsEditable = false;
            this.olvColumnInputParameterDelete.Searchable = false;
            this.olvColumnInputParameterDelete.Sortable = false;
            this.olvColumnInputParameterDelete.Text = "";
            this.olvColumnInputParameterDelete.UseFiltering = false;
            // 
            // btnAddInputParameter
            // 
            this.btnAddInputParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInputParameter.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddInputParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddInputParameter.Location = new System.Drawing.Point(614, 189);
            this.btnAddInputParameter.Name = "btnAddInputParameter";
            this.btnAddInputParameter.Size = new System.Drawing.Size(31, 32);
            this.btnAddInputParameter.TabIndex = 2;
            this.btnAddInputParameter.UseVisualStyleBackColor = true;
            this.btnAddInputParameter.Click += new System.EventHandler(this.btnAddInputParameter_Click);
            // 
            // tpOutputParameters
            // 
            this.tpOutputParameters.Controls.Add(this.btnDetectOutputParameters);
            this.tpOutputParameters.Controls.Add(this.btnAddOutputParameter);
            this.tpOutputParameters.Controls.Add(this.olvOutputParameters);
            this.tpOutputParameters.Location = new System.Drawing.Point(4, 25);
            this.tpOutputParameters.Name = "tpOutputParameters";
            this.tpOutputParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutputParameters.Size = new System.Drawing.Size(647, 227);
            this.tpOutputParameters.TabIndex = 1;
            this.tpOutputParameters.Text = "Output Params";
            this.tpOutputParameters.UseVisualStyleBackColor = true;
            // 
            // btnDetectOutputParameters
            // 
            this.btnDetectOutputParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDetectOutputParameters.Location = new System.Drawing.Point(5, 189);
            this.btnDetectOutputParameters.Name = "btnDetectOutputParameters";
            this.btnDetectOutputParameters.Size = new System.Drawing.Size(75, 23);
            this.btnDetectOutputParameters.TabIndex = 4;
            this.btnDetectOutputParameters.Text = "Detect...";
            this.btnDetectOutputParameters.UseVisualStyleBackColor = true;
            this.btnDetectOutputParameters.Click += new System.EventHandler(this.btnDetectOutputParameters_Click);
            // 
            // btnAddOutputParameter
            // 
            this.btnAddOutputParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOutputParameter.BackgroundImage = global::UBoat.WebHawk.UI.Properties.Resources.Add;
            this.btnAddOutputParameter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddOutputParameter.Location = new System.Drawing.Point(614, 189);
            this.btnAddOutputParameter.Name = "btnAddOutputParameter";
            this.btnAddOutputParameter.Size = new System.Drawing.Size(31, 32);
            this.btnAddOutputParameter.TabIndex = 3;
            this.btnAddOutputParameter.UseVisualStyleBackColor = true;
            this.btnAddOutputParameter.Click += new System.EventHandler(this.btnAddOutputParameter_Click);
            // 
            // olvOutputParameters
            // 
            this.olvOutputParameters.AllColumns.Add(this.olvColumnOutputParameterType);
            this.olvOutputParameters.AllColumns.Add(this.olvColumnOutputParameterName);
            this.olvOutputParameters.AllColumns.Add(this.olvColumnOutputParameterStateVariable);
            this.olvOutputParameters.AllColumns.Add(this.olvColumnOutputParameterXMLOutputMode);
            this.olvOutputParameters.AllColumns.Add(this.olvColumnOutputParameterPersistenceMode);
            this.olvOutputParameters.AllColumns.Add(this.olvColumnOutputParameterDelete);
            this.olvOutputParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvOutputParameters.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvOutputParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnOutputParameterType,
            this.olvColumnOutputParameterName,
            this.olvColumnOutputParameterStateVariable,
            this.olvColumnOutputParameterXMLOutputMode,
            this.olvColumnOutputParameterPersistenceMode,
            this.olvColumnOutputParameterDelete});
            this.olvOutputParameters.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvOutputParameters.EmptyListMsg = "No Parameters Added.";
            this.olvOutputParameters.FullRowSelect = true;
            this.olvOutputParameters.Location = new System.Drawing.Point(5, 6);
            this.olvOutputParameters.Name = "olvOutputParameters";
            this.olvOutputParameters.ShowGroups = false;
            this.olvOutputParameters.Size = new System.Drawing.Size(640, 177);
            this.olvOutputParameters.TabIndex = 1;
            this.olvOutputParameters.UseCompatibleStateImageBehavior = false;
            this.olvOutputParameters.UseHyperlinks = true;
            this.olvOutputParameters.View = System.Windows.Forms.View.Details;
            this.olvOutputParameters.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olvOutputParameters_CellEditFinishing);
            this.olvOutputParameters.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.olvOutputParameters_CellEditStarting);
            this.olvOutputParameters.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvOutputParameters_HyperlinkClicked);
            // 
            // olvColumnOutputParameterType
            // 
            this.olvColumnOutputParameterType.AspectName = "ParameterType";
            this.olvColumnOutputParameterType.Groupable = false;
            this.olvColumnOutputParameterType.Hideable = false;
            this.olvColumnOutputParameterType.Searchable = false;
            this.olvColumnOutputParameterType.Sortable = false;
            this.olvColumnOutputParameterType.Text = "Parameter Type";
            this.olvColumnOutputParameterType.UseFiltering = false;
            this.olvColumnOutputParameterType.Width = 95;
            // 
            // olvColumnOutputParameterName
            // 
            this.olvColumnOutputParameterName.AspectName = "ParameterName";
            this.olvColumnOutputParameterName.Groupable = false;
            this.olvColumnOutputParameterName.Hideable = false;
            this.olvColumnOutputParameterName.Searchable = false;
            this.olvColumnOutputParameterName.Sortable = false;
            this.olvColumnOutputParameterName.Text = "Parameter Name";
            this.olvColumnOutputParameterName.UseFiltering = false;
            this.olvColumnOutputParameterName.Width = 131;
            // 
            // olvColumnOutputParameterStateVariable
            // 
            this.olvColumnOutputParameterStateVariable.AspectName = "StateVariable";
            this.olvColumnOutputParameterStateVariable.Groupable = false;
            this.olvColumnOutputParameterStateVariable.Hideable = false;
            this.olvColumnOutputParameterStateVariable.Searchable = false;
            this.olvColumnOutputParameterStateVariable.Sortable = false;
            this.olvColumnOutputParameterStateVariable.Text = "State Variable";
            this.olvColumnOutputParameterStateVariable.UseFiltering = false;
            this.olvColumnOutputParameterStateVariable.Width = 145;
            // 
            // olvColumnOutputParameterXMLOutputMode
            // 
            this.olvColumnOutputParameterXMLOutputMode.AspectName = "XMLFieldOutputMode";
            this.olvColumnOutputParameterXMLOutputMode.Groupable = false;
            this.olvColumnOutputParameterXMLOutputMode.Hideable = false;
            this.olvColumnOutputParameterXMLOutputMode.Searchable = false;
            this.olvColumnOutputParameterXMLOutputMode.Sortable = false;
            this.olvColumnOutputParameterXMLOutputMode.Text = "XML Output Mode";
            this.olvColumnOutputParameterXMLOutputMode.UseFiltering = false;
            this.olvColumnOutputParameterXMLOutputMode.Width = 100;
            // 
            // olvColumnOutputParameterPersistenceMode
            // 
            this.olvColumnOutputParameterPersistenceMode.AspectName = "PersistenceMode";
            this.olvColumnOutputParameterPersistenceMode.Groupable = false;
            this.olvColumnOutputParameterPersistenceMode.Hideable = false;
            this.olvColumnOutputParameterPersistenceMode.Searchable = false;
            this.olvColumnOutputParameterPersistenceMode.Sortable = false;
            this.olvColumnOutputParameterPersistenceMode.Text = "Persistence Mode";
            this.olvColumnOutputParameterPersistenceMode.UseFiltering = false;
            this.olvColumnOutputParameterPersistenceMode.Width = 100;
            // 
            // olvColumnOutputParameterDelete
            // 
            this.olvColumnOutputParameterDelete.Groupable = false;
            this.olvColumnOutputParameterDelete.Hideable = false;
            this.olvColumnOutputParameterDelete.Hyperlink = true;
            this.olvColumnOutputParameterDelete.IsEditable = false;
            this.olvColumnOutputParameterDelete.Searchable = false;
            this.olvColumnOutputParameterDelete.Sortable = false;
            this.olvColumnOutputParameterDelete.Text = "";
            this.olvColumnOutputParameterDelete.UseFiltering = false;
            // 
            // tpResults
            // 
            this.tpResults.Controls.Add(this.gbResultMappingEditor);
            this.tpResults.Controls.Add(this.label4);
            this.tpResults.Controls.Add(this.cbResultType);
            this.tpResults.Location = new System.Drawing.Point(4, 25);
            this.tpResults.Name = "tpResults";
            this.tpResults.Padding = new System.Windows.Forms.Padding(3);
            this.tpResults.Size = new System.Drawing.Size(647, 227);
            this.tpResults.TabIndex = 2;
            this.tpResults.Text = "Results";
            this.tpResults.UseVisualStyleBackColor = true;
            // 
            // gbResultMappingEditor
            // 
            this.gbResultMappingEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultMappingEditor.Location = new System.Drawing.Point(0, 33);
            this.gbResultMappingEditor.Name = "gbResultMappingEditor";
            this.gbResultMappingEditor.Size = new System.Drawing.Size(647, 194);
            this.gbResultMappingEditor.TabIndex = 2;
            this.gbResultMappingEditor.TabStop = false;
            this.gbResultMappingEditor.Text = "Editor Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Result Type:";
            // 
            // cbResultType
            // 
            this.cbResultType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResultType.FormattingEnabled = true;
            this.cbResultType.Location = new System.Drawing.Point(102, 6);
            this.cbResultType.Name = "cbResultType";
            this.cbResultType.Size = new System.Drawing.Size(166, 21);
            this.cbResultType.TabIndex = 0;
            this.cbResultType.SelectedIndexChanged += new System.EventHandler(this.cbResultType_SelectedIndexChanged);
            // 
            // DatabaseStepEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlInputOutput);
            this.Controls.Add(this.gbCommand);
            this.Controls.Add(this.gbConnection);
            this.Name = "DatabaseStepEditor";
            this.Size = new System.Drawing.Size(661, 507);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbCommand.ResumeLayout(false);
            this.gbCommand.PerformLayout();
            this.tabControlInputOutput.ResumeLayout(false);
            this.tpInputParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvInputParameters)).EndInit();
            this.tpOutputParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvOutputParameters)).EndInit();
            this.tpResults.ResumeLayout(false);
            this.tpResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbConnectionType;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuildConnectionString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.GroupBox gbCommand;
        private OutputValueEditor commandEditor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCommandType;
        private System.Windows.Forms.TabControl tabControlInputOutput;
        private System.Windows.Forms.TabPage tpInputParameters;
        private BrightIdeasSoftware.ObjectListView olvInputParameters;
        private BrightIdeasSoftware.OLVColumn olvColumnInputParameterName;
        private BrightIdeasSoftware.OLVColumn olvColumnInputParameterValue;
        private BrightIdeasSoftware.OLVColumn olvColumnInputParameterTrim;
        private BrightIdeasSoftware.OLVColumn olvColumnInputParameterDelete;
        private System.Windows.Forms.Button btnAddInputParameter;
        private System.Windows.Forms.TabPage tpOutputParameters;
        private System.Windows.Forms.TabPage tpResults;
        private BrightIdeasSoftware.ObjectListView olvOutputParameters;
        private BrightIdeasSoftware.OLVColumn olvColumnOutputParameterName;
        private BrightIdeasSoftware.OLVColumn olvColumnOutputParameterStateVariable;
        private BrightIdeasSoftware.OLVColumn olvColumnOutputParameterDelete;
        private System.Windows.Forms.Button btnAddOutputParameter;
        private System.Windows.Forms.GroupBox gbResultMappingEditor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbResultType;
        private BrightIdeasSoftware.OLVColumn olvColumnOutputParameterType;
        private BrightIdeasSoftware.OLVColumn olvColumnOutputParameterXMLOutputMode;
        private BrightIdeasSoftware.OLVColumn olvColumnOutputParameterPersistenceMode;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnFindStoredProcedure;
        private System.Windows.Forms.Button btnDetectInputParameters;
        private System.Windows.Forms.Button btnDetectOutputParameters;
    }
}
