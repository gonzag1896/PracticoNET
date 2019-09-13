using DataAccessLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BLEmployees : IBLEmployees
    {
       private IDALEmployees _dal;

        public BLEmployees(IDALEmployees dal)
        {
            _dal = dal;
        }

        public void AddEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public double CalcPartTimeEmployeeSalary(int idEmployee, int hours)
        {
            Employee emp = _dal.GetEmployee(idEmployee);
            if (emp != null)
            {
                if (emp.GetType() == typeof(PartTimeEmployee))
                {
                    PartTimeEmployee e = (PartTimeEmployee)emp;
                    return hours * e.HourlyRate;
                }
                else
                    throw new Shared.Exception.TypeException();
            }
            else
                throw new Shared.Exception.ExistException();
        }
    }
}
