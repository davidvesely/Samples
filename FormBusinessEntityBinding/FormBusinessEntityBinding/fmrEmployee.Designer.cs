namespace FormBusinessEntityBinding
{
    partial class fmrEmployee
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.bindingSourceSearchCriteria = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceMaster = new System.Windows.Forms.BindingSource(this.components);
            this.lblFName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.dgEmployees = new System.Windows.Forms.DataGridView();
            this.stateCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceSearchResult = new System.Windows.Forms.BindingSource(this.components);
            this.grpEmployees = new System.Windows.Forms.GroupBox();
            this.grpEmpDetails = new System.Windows.Forms.GroupBox();
            this.gdEmpDetails = new System.Windows.Forms.DataGridView();
            this.empDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectManagerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSearchCriteria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSearchResult)).BeginInit();
            this.grpEmployees.SuspendLayout();
            this.grpEmpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdEmpDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.lblFName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(574, 56);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(494, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(414, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(334, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(21, 65);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 13);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "State";
            // 
            // cmbState
            // 
            this.cmbState.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceSearchCriteria, "StateCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbState.DataSource = this.bindingSourceMaster;
            this.cmbState.DisplayMember = "Description";
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(104, 57);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(223, 21);
            this.cmbState.TabIndex = 2;
            this.cmbState.ValueMember = "Code";
            // 
            // bindingSourceSearchCriteria
            // 
            this.bindingSourceSearchCriteria.DataSource = typeof(FormBusinessEntityBinding.BusinessEntity.EmployeeBE);
            // 
            // bindingSourceMaster
            // 
            this.bindingSourceMaster.DataSource = typeof(FormBusinessEntityBinding.BusinessEntity.MasterBEList);
            // 
            // lblFName
            // 
            this.lblFName.AutoSize = true;
            this.lblFName.Location = new System.Drawing.Point(21, 22);
            this.lblFName.Name = "lblFName";
            this.lblFName.Size = new System.Drawing.Size(57, 13);
            this.lblFName.TabIndex = 1;
            this.lblFName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceSearchCriteria, "FirstName", true));
            this.txtFirstName.Location = new System.Drawing.Point(104, 19);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(223, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // dgEmployees
            // 
            this.dgEmployees.AllowUserToResizeRows = false;
            this.dgEmployees.AutoGenerateColumns = false;
            this.dgEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stateCodeDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.lastNameDataGridViewTextBoxColumn,
            this.empIdDataGridViewTextBoxColumn});
            this.dgEmployees.DataSource = this.bindingSourceSearchResult;
            this.dgEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEmployees.Location = new System.Drawing.Point(3, 16);
            this.dgEmployees.MultiSelect = false;
            this.dgEmployees.Name = "dgEmployees";
            this.dgEmployees.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgEmployees.RowHeadersVisible = false;
            this.dgEmployees.Size = new System.Drawing.Size(652, 162);
            this.dgEmployees.TabIndex = 1;
            // 
            // stateCodeDataGridViewTextBoxColumn
            // 
            this.stateCodeDataGridViewTextBoxColumn.DataPropertyName = "StateCode";
            this.stateCodeDataGridViewTextBoxColumn.HeaderText = "StateCode";
            this.stateCodeDataGridViewTextBoxColumn.Name = "stateCodeDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            this.lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            this.lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            this.lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // empIdDataGridViewTextBoxColumn
            // 
            this.empIdDataGridViewTextBoxColumn.DataPropertyName = "EmpId";
            this.empIdDataGridViewTextBoxColumn.HeaderText = "EmpId";
            this.empIdDataGridViewTextBoxColumn.Name = "empIdDataGridViewTextBoxColumn";
            // 
            // bindingSourceSearchResult
            // 
            this.bindingSourceSearchResult.DataSource = typeof(FormBusinessEntityBinding.BusinessEntity.EmployeeBEList);
            this.bindingSourceSearchResult.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSourceSearchResult_ListChanged);
            // 
            // grpEmployees
            // 
            this.grpEmployees.Controls.Add(this.dgEmployees);
            this.grpEmployees.Location = new System.Drawing.Point(12, 137);
            this.grpEmployees.Name = "grpEmployees";
            this.grpEmployees.Size = new System.Drawing.Size(658, 181);
            this.grpEmployees.TabIndex = 2;
            this.grpEmployees.TabStop = false;
            this.grpEmployees.Text = "Employees";
            // 
            // grpEmpDetails
            // 
            this.grpEmpDetails.Controls.Add(this.gdEmpDetails);
            this.grpEmpDetails.Location = new System.Drawing.Point(12, 336);
            this.grpEmpDetails.Name = "grpEmpDetails";
            this.grpEmpDetails.Size = new System.Drawing.Size(658, 185);
            this.grpEmpDetails.TabIndex = 3;
            this.grpEmpDetails.TabStop = false;
            this.grpEmpDetails.Text = "Employee Details";
            // 
            // gdEmpDetails
            // 
            this.gdEmpDetails.AutoGenerateColumns = false;
            this.gdEmpDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdEmpDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.projectCodeDataGridViewTextBoxColumn,
            this.projectManagerDataGridViewTextBoxColumn,
            this.projectNameDataGridViewTextBoxColumn});
            this.gdEmpDetails.DataSource = this.empDetailsBindingSource;
            this.gdEmpDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdEmpDetails.Location = new System.Drawing.Point(3, 16);
            this.gdEmpDetails.Name = "gdEmpDetails";
            this.gdEmpDetails.RowHeadersVisible = false;
            this.gdEmpDetails.Size = new System.Drawing.Size(652, 166);
            this.gdEmpDetails.TabIndex = 0;
            // 
            // empDetailsBindingSource
            // 
            this.empDetailsBindingSource.DataMember = "EmpDetails";
            this.empDetailsBindingSource.DataSource = this.bindingSourceSearchResult;
            // 
            // projectCodeDataGridViewTextBoxColumn
            // 
            this.projectCodeDataGridViewTextBoxColumn.DataPropertyName = "ProjectCode";
            this.projectCodeDataGridViewTextBoxColumn.HeaderText = "ProjectCode";
            this.projectCodeDataGridViewTextBoxColumn.Name = "projectCodeDataGridViewTextBoxColumn";
            // 
            // projectManagerDataGridViewTextBoxColumn
            // 
            this.projectManagerDataGridViewTextBoxColumn.DataPropertyName = "ProjectManager";
            this.projectManagerDataGridViewTextBoxColumn.HeaderText = "ProjectManager";
            this.projectManagerDataGridViewTextBoxColumn.Name = "projectManagerDataGridViewTextBoxColumn";
            // 
            // projectNameDataGridViewTextBoxColumn
            // 
            this.projectNameDataGridViewTextBoxColumn.DataPropertyName = "ProjectName";
            this.projectNameDataGridViewTextBoxColumn.HeaderText = "ProjectName";
            this.projectNameDataGridViewTextBoxColumn.Name = "projectNameDataGridViewTextBoxColumn";
            // 
            // fmrEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 526);
            this.Controls.Add(this.grpEmpDetails);
            this.Controls.Add(this.grpEmployees);
            this.Controls.Add(this.groupBox1);
            this.Name = "fmrEmployee";
            this.Text = "Employee Form";
            this.Load += new System.EventHandler(this.fmrEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSearchCriteria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSearchResult)).EndInit();
            this.grpEmployees.ResumeLayout(false);
            this.grpEmpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdEmpDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.BindingSource bindingSourceMaster;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgEmployees;
        private System.Windows.Forms.BindingSource bindingSourceSearchCriteria;
        private System.Windows.Forms.GroupBox grpEmployees;
        private System.Windows.Forms.GroupBox grpEmpDetails;
        private System.Windows.Forms.DataGridView gdEmpDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn empIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSourceSearchResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectManagerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource empDetailsBindingSource;

    }
}

