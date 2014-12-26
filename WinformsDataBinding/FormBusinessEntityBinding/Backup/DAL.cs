using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormBusinessEntityBinding.BusinessEntity;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;

namespace FormBusinessEntityBinding
{
    public class DAL
    {
        public MasterBEList GetStates()
        {
            MasterBEList states = new MasterBEList();
            MasterBE state = new MasterBE();
            state.Code = "WB";
            state.Description = "West Bengal";
            states.Add(state);

            state = new MasterBE();
            state.Code = "MP";
            state.Description = "Madhya Pradesh";
            states.Add(state);

            state = new MasterBE();
            state.Code = "UP";
            state.Description = "Uttar Pradesh";
            states.Add(state);

            state = new MasterBE();
            state.Code = "";
            state.Description = "--Select--";
            states.Add(state);

            return states;
        }

        public EmployeeBEList SearchEmployee(string firstName, string stateCode)
        {
            EmployeeBEList allEmployees = GetAllEmployees();
            EmployeeBEList selectedEmps = new EmployeeBEList();
            bool found = false;
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(stateCode))
            {
                return allEmployees;
            }
            if (!firstName.Equals(string.Empty))
            {
                foreach (EmployeeBE emp in allEmployees)
                {
                    if (emp.FirstName.ToUpper().Equals(firstName.ToUpper()))
                    {
                        if (!stateCode.Equals(string.Empty))
                        {
                            if (emp.StateCode.ToUpper().Equals(stateCode.ToUpper()))
                            {
                                selectedEmps.Add(emp);
                            }
                        }
                        else
                        {
                            selectedEmps.Add(emp);
                        }
                    }
                }
            }
            if (firstName.Equals(string.Empty) &&!stateCode.Equals(string.Empty))
            {
                foreach (EmployeeBE emp in allEmployees)
                {
                    if (emp.StateCode.ToUpper().Equals(stateCode.ToUpper()))
                    {
                        selectedEmps.Add(emp);
                    }
                }
            }

            return selectedEmps;
        }

        public void SaveChanges(EmployeeBEList employees)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(employees.GetType(), "");
                StreamWriter writer = new StreamWriter(ConfigurationManager.AppSettings["DataFile"]);
                serializer.Serialize(writer, employees);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }

        private EmployeeBEList GetAllEmployees()
        {
            EmployeeBEList employees = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(EmployeeBEList), "");
                StreamReader reader = new StreamReader(ConfigurationManager.AppSettings["DataFile"]);
                employees = serializer.Deserialize(reader) as EmployeeBEList;
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employees;
        }
    }
}
