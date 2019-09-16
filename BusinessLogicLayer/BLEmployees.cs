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
            _dal.AddEmployee(emp);
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
        }

        public void UpdateEmployee(Employee emp)
        {
            _dal.UpdateEmployee(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return _dal.GetAllEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _dal.GetEmployee(id);
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
