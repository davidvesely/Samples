using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;

namespace Test_MasterDetails_Edm
{
    public partial class Form1 : Form
    {
        NorthwindEntities context;
        public Form1()
        {
            InitializeComponent();
            context = new NorthwindEntities();

            ObjectQuery<Orders> customersQuery = 
                context.Orders.Include("Order_Details");
            //.Where(p => p.OrderDate < new DateTime(9, 7, 1996));
            gridControl2.DataSource = new BindingSource(customersQuery, "");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gridControl2.DataSource = 
            //    context.Orders.Include("Order_Details").Where(o => o.OrderID == 10248);

        }

        private void gridView2_MasterRowEmpty(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs e)
        {
            Orders c = (Orders)gridView2.GetRow(e.RowHandle);
            e.IsEmpty = c.Order_Details.Count == 0;

            //if (e.IsEmpty)
            //{

            //}
        }

        private void gridView2_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e)
        {
            Orders c = (Orders)gridView2.GetRow(e.RowHandle);
            e.ChildList = new BindingSource(c, "Order_Details");

        }

        private void gridView2_MasterRowGetRelationName(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Order_Details";
        }

        private void gridView2_MasterRowGetRelationCount(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs e)
        {
            e.RelationCount = 1;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }

}
