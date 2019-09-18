using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'practicoObligatorioDataSet.EmployeesTPH' Puede moverla o quitarla según sea necesario.
            this.employeesTPHTableAdapter.Fill(this.practicoObligatorioDataSet.EmployeesTPH);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataAccessLayer.DALEmployeesEF dalef = new DataAccessLayer.DALEmployeesEF();
            BusinessLogicLayer.BLEmployees bl = new BusinessLogicLayer.BLEmployees(dalef);
            List<Shared.Entities.Employee> empleados = bl.GetAllEmployees();
            List<Shared.Entities.EmployeeMuestraWF> empTabla = new List<Shared.Entities.EmployeeMuestraWF>();
            empleados.ForEach(x =>
            {
                if (x.GetType() == typeof(Shared.Entities.FullTimeEmployee))
                {
                    Shared.Entities.FullTimeEmployee emp = (Shared.Entities.FullTimeEmployee)x;
                    empTabla.Add(new Shared.Entities.EmployeeMuestraWF()
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        StartDate = emp.StartDate,
                        Type_Emp = "FullTime"
                    });
                }
                else
                {
                    Shared.Entities.PartTimeEmployee emp = (Shared.Entities.PartTimeEmployee)x;
                    empTabla.Add(new Shared.Entities.EmployeeMuestraWF()
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        StartDate = emp.StartDate,
                        Type_Emp = "PartTime"
                    });
                }
            });
            dataGridView1.DataSource = empTabla;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DataAccessLayer.DALEmployeesEF dalef = new DataAccessLayer.DALEmployeesEF();
            BusinessLogicLayer.BLEmployees bl = new BusinessLogicLayer.BLEmployees(dalef);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            DataAccessLayer.DALEmployeesEF dalef = new DataAccessLayer.DALEmployeesEF();
            BusinessLogicLayer.BLEmployees bl = new BusinessLogicLayer.BLEmployees(dalef);
            if (textBox3.Text == "FullTime")
            {
                Shared.Entities.FullTimeEmployee empFT = new Shared.Entities.FullTimeEmployee()
                {
                    Name = textBox1.Text,
                    StartDate = Convert.ToDateTime(textBox5.Text),
                    Salary = Convert.ToInt32(textBox4.Text)
                };
                bl.AddEmployee(empFT);
            }
            else if (textBox3.Text == "PartTime")
            {
                Shared.Entities.PartTimeEmployee empPT = new Shared.Entities.PartTimeEmployee()
                {
                    Name = textBox1.Text,
                    StartDate = Convert.ToDateTime(textBox5.Text),
                    HourlyRate = Convert.ToDouble(textBox3.Text)
                };
                bl.AddEmployee(empPT);
            }
        }
    }
}
