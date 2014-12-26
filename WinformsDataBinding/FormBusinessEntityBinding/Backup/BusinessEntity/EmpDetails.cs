using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBusinessEntityBinding.BusinessEntity
{
    public class EmpDetails
    {
        private string _projectCode = string.Empty;
        private string _projectManager = string.Empty;
        private string _projectName = string.Empty;

        public string ProjectCode
        {
            get { return _projectCode; }
            set { _projectCode = value; }
        }

        public string ProjectManager
        {
            get { return _projectManager; }
            set { _projectManager = value; }
        }

        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }
    }
}
