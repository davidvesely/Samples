using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Test_MasterDetails_Edm
{
  public partial class Form1 : Form
  {
    NorthwindEntities context;
    public Form1()
    {
      InitializeComponent();
      context = new NorthwindEntities();
      gridView2.DataController.AllowIEnumerableDetails = true;

      //var customersQuery =
      //    context.Orders.Include("Order_Details").ToList();
      context.Orders.Include("Order_Details").Load();
      gridView2.MasterRowExpanded += gridView2_MasterRowExpanded;
      //.Where(p => p.OrderDate < new DateTime(9, 7, 1996));
      gridControl2.DataSource = new BindingSource(context.Orders.Local.ToBindingList(), "");
    }

    void gridView2_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
    {
        GridView view = gridView2.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
        view.ShownEditor += view_ShownEditor;
    }

    void view_ShownEditor(object sender, EventArgs e)
    {
        
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


    }
    private void gridView2_MasterRowGetChildList(object sender, DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs e) {
        Orders c = (Orders)gridView2.GetRow(e.RowHandle);
            BindingSource newSource = new BindingSource();
            newSource.AllowNew = true;
            newSource.DataSource = c.Order_Details.ToList();
            e.ChildList = newSource;
    }

    void source_AddingNew(AddingNewEventArgs e, Orders order)
    {
      //Order_Details detail = Order_Details.CreateOrder_Details(order.OrderID, -1, 0, 1, 0);
      //Products product = Products.CreateProducts(false, -1, string.Empty);
      //detail.Products = product;
      //e.NewObject = detail;
      //order.Order_Details.Add(detail);

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
        try
        {
            context.SaveChanges();
        }
        catch { }
    }


    private void gridControl2_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
    {
      GridControlNavigator navigator = sender as GridControlNavigator;
      GridControl grid = navigator.NavigatableControl as GridControl;
      GridView view = grid.FocusedView as GridView;
      if (view.IsDetailView && e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
      {
        Orders c = (Orders)gridView2.GetRow(view.SourceRowHandle);
        Order_Details val = view.GetRow(view.FocusedRowHandle) as Order_Details;
        c.Order_Details.Remove(val);
      }
    }

    private void gridView2_InitNewRow(object sender, InitNewRowEventArgs e)
    {
        
    }

    private void gridView4_InitNewRow(object sender, InitNewRowEventArgs e) {

    }

    private void gridView4_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
    {
        try
        {
            Order_Details row = e.Row as Order_Details;
            row.Orders = context.Orders.Where(p => p.OrderID == row.OrderID).Select(p => p).SingleOrDefault();
            row.Products = context.Products.Where(p => p.ProductID == row.ProductID).Select(p => p).SingleOrDefault();
            row.Orders.Order_Details.Add(row);
        }
        catch (Exception ex)
        {
        }
    }
  }
}
