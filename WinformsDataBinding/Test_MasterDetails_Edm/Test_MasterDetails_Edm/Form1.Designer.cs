namespace Test_MasterDetails_Edm
{
    partial class Form1
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.parentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductID,
            this.colUnitPrice});
            this.gridView4.GridControl = this.gridControl2;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView4.OptionsView.ShowChildrenInGroupPanel = true;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "ProductID";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 0;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "UnitPrice";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 1;
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.First.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Last.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Next.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.NextPage.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.Prev.Enabled = false;
            this.gridControl2.EmbeddedNavigator.Buttons.PrevPage.Enabled = false;
            gridLevelNode1.LevelTemplate = this.gridView4;
            gridLevelNode1.RelationName = "Order_Details";
            this.gridControl2.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl2.Location = new System.Drawing.Point(12, 12);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(681, 471);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.UseEmbeddedNavigator = true;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView4});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsDetail.ShowDetailTabs = false;
            this.gridView2.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView2.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gridView2_MasterRowGetRelationName);
            this.gridView2.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridView2_MasterRowGetChildList);
            this.gridView2.MasterRowEmpty += new DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventHandler(this.gridView2_MasterRowEmpty);
            this.gridView2.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gridView2_MasterRowGetRelationCount);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "OrderId";
            this.gridColumn1.FieldName = "OrderID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.FieldName = "OrderDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(618, 489);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 526);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.gridControl2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.BindingSource parentBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
    }
}

