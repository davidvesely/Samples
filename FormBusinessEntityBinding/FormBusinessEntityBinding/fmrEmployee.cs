using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusinessEntityBinding.BusinessEntity;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace FormBusinessEntityBinding
{
    public partial class fmrEmployee : Form
    {
        List<int> _addedRowIndexes = new List<int>();
        List<int> _changedRowIndexes = new List<int>();

        public fmrEmployee()
        {
            InitializeComponent();
        }

        private void fmrEmployee_Load(object sender, EventArgs e)
        {
            bindingSourceSearchResult.RaiseListChangedEvents = true;

            DAL objDal = new DAL();
            bindingSourceMaster.DataSource = objDal.GetStates();            

            EmployeeBE searchEmp =  bindingSourceSearchCriteria.AddNew() as EmployeeBE;
            searchEmp.StateCode = "";

            EmployeeBE searcchCriteria = (EmployeeBE)bindingSourceSearchCriteria.Current;
            bindingSourceSearchResult.DataSource = objDal.SearchEmployee(searcchCriteria.FirstName, searcchCriteria.StateCode);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DAL objDal = new DAL();
            EmployeeBE searcchCriteria = (EmployeeBE)bindingSourceSearchCriteria.Current;
            bindingSourceSearchResult.DataSource = objDal.SearchEmployee(searcchCriteria.FirstName, searcchCriteria.StateCode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeBE newEmp = this.bindingSourceSearchResult.AddNew() as EmployeeBE;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DAL objDal = new DAL();
            EmployeeBE selectEmp = this.bindingSourceSearchResult.Current as EmployeeBE;
            this.bindingSourceSearchResult.Remove(selectEmp);
            EmployeeBEList employees = this.bindingSourceSearchResult.List as EmployeeBEList;
            objDal.SaveChanges(employees);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL objDal = new DAL();
            EmployeeBEList employees = this.bindingSourceSearchResult.List as EmployeeBEList;
            objDal.SaveChanges(employees);
            
        }

        private void bindingSourceSearchResult_ListChanged(object sender, ListChangedEventArgs e)
        {
            //int added = 0;
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                    //added = e.NewIndex;
                    if (!_addedRowIndexes.Contains(e.NewIndex))   //fires for each cell changed.  Only add row index once
                        _addedRowIndexes.Add(e.NewIndex);
                    break;
                case ListChangedType.ItemChanged:
                    //Will fire when editing a new row.  Make sure the row editing isn't new
                    if (!_changedRowIndexes.Contains(e.NewIndex) && !_addedRowIndexes.Contains(e.NewIndex))
                        _changedRowIndexes.Add(e.NewIndex);
                    break;
                default:
                    break;
            }

        }



        
    }
}
