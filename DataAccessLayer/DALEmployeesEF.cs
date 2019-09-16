using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        public void AddEmployee(Employee emp)
        {
            using (Model.PracticoEntities en = new Model.PracticoEntities())
            {
                Model.Employee empNuevo;
                if (emp.GetType() == typeof(FullTimeEmployee))
                {
                    FullTimeEmployee empFT = (FullTimeEmployee)emp;
                    empNuevo = new Model.FullTimeEmployee()
                    {
                        EmployeeId = empFT.Id,
                        Name = empFT.Name,
                        Salary = empFT.Salary,
                        StartDate = empFT.StartDate
                    };
                    en.EmployeeTPH.Add(empNuevo);
                    en.SaveChanges();
                }
                else
                {
                    PartTimeEmployee empPT = (PartTimeEmployee)emp;
                    empNuevo = new Model.PartTimeEmployee()
                    {
                        EmployeeId = empPT.Id,
                        Name = empPT.Name,
                        StartDate = empPT.StartDate,
                        HourlyRate = empPT.HourlyRate
                    };
                    en.EmployeeTPH.Add(empNuevo);
                    en.SaveChanges();
                }

            }
        }

        public void DeleteEmployee(int id)
        {
            using (Model.PracticoEntities en = new Model.PracticoEntities())
            {
                Model.Employee e = en.EmployeeTPH.FirstOrDefault(x => x.EmployeeId == id);
                if (e != null)
                {
                    en.EmployeeTPH.Remove(e);
                }
                else
                    return;
            }
        }

        public void UpdateEmployee(Employee emp)
        {
            using (Model.PracticoEntities en = new Model.PracticoEntities())
            {
                if (emp.GetType() == typeof(FullTimeEmployee))
                {
                    FullTimeEmployee FullTimeEmp = (FullTimeEmployee)emp;
                    Model.Employee e = en.EmployeeTPH.Find(emp.Id);
                    if (e != null)
                    {
                        Model.FullTimeEmployee empFT = (Model.FullTimeEmployee)e;
                        empFT.Name = FullTimeEmp.Name;
                        empFT.Salary = FullTimeEmp.Salary;
                        empFT.StartDate = FullTimeEmp.StartDate;
                        en.SaveChanges();
                    }
                }
                else
                {
                    PartTimeEmployee PartTimeEmp = (PartTimeEmployee)emp;
                    Model.Employee e = en.EmployeeTPH.Find(emp.Id);
                    if (e != null)
                    {
                        Model.PartTimeEmployee empFT = (Model.PartTimeEmployee)e;
                        empFT.Name = PartTimeEmp.Name;
                        empFT.StartDate = PartTimeEmp.StartDate;
                        empFT.HourlyRate = PartTimeEmp.HourlyRate;
                        en.SaveChanges();
                    }
                }
            }
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();

            using (Model.PracticoEntities en = new Model.PracticoEntities())
            {
                en.EmployeeTPH.ToList().ForEach(emp =>
                {
                    if (emp.GetType() == typeof(FullTimeEmployee))
                    {
                        Model.FullTimeEmployee empFT = new Model.FullTimeEmployee();
                        empFT = (Model.FullTimeEmployee)emp;
                        FullTimeEmployee empleado = new FullTimeEmployee()
                        {
                             Id = empFT.EmployeeId,
                             Name = empFT.Name,
                             StartDate = empFT.StartDate,
                             Salary = empFT.Salary,
                        };
                        result.Add(empleado);
                    }
                     else
                     {
                         Model.PartTimeEmployee empPT = new Model.PartTimeEmployee();
                         empPT = (Model.PartTimeEmployee)emp;

                         PartTimeEmployee empleado = new PartTimeEmployee()
                         {
                             Id = empPT.EmployeeId,
                             Name = empPT.Name,
                             StartDate = empPT.StartDate,
                             HourlyRate = empPT.HourlyRate,
                         };
                         result.Add(empleado);
                     }
                 });
            }
            return result;
        }
        public Employee GetEmployee(int id)
        {
            using (Model.PracticoEntities en = new Model.PracticoEntities())
            {
                Model.Employee e = en.EmployeeTPH.Find(id);
                if (e.GetType() == typeof(FullTimeEmployee))
                {
                    Model.FullTimeEmployee fullTime = new Model.FullTimeEmployee();
                    fullTime = (Model.FullTimeEmployee)e;
                    return new FullTimeEmployee()
                    {
                        Id = fullTime.EmployeeId,
                        Name = fullTime.Name,
                        Salary = fullTime.Salary,
                        StartDate = fullTime.StartDate,
                    };
                }
                else
                {
                    Model.PartTimeEmployee partTime = new Model.PartTimeEmployee();
                    partTime = (Model.PartTimeEmployee)e;
                    return new PartTimeEmployee()
                    {
                        Id = partTime.EmployeeId,
                        Name = partTime.Name,
                        HourlyRate = partTime.HourlyRate,
                        StartDate = partTime.StartDate,
                    };
                }
            }
        }
    }
}
