using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBusinessEntityBinding.BusinessEntity
{
    public class EmployeeBE
    {
        private string _stateCode = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _empID = string.Empty;
        

        private EmpDetailsList _empDetails = null;

        public EmployeeBE()
        {
            this._empDetails = new EmpDetailsList();
        }
        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string EmpId
        {
            get { return _empID; }
            set { _empID = value; }
        }

        public EmpDetailsList EmpDetails
        {
            get { return _empDetails; }
            set { _empDetails = value; }
        }
    }

    
}
