using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormBusinessEntityBinding.BusinessEntity
{
    public class MasterBE
    {
        private string _code = string.Empty;
        private string _description = string.Empty;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }


    

    
}
