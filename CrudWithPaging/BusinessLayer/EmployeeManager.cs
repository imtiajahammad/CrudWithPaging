using CrudWithPaging.DataLayer;
using CrudWithPaging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudWithPaging.BusinessLayer
{
    public class EmployeeManager
    {
        EmployeeDataLayer employeeDataLayer;
        public EmployeeManager()
        {
            this.employeeDataLayer = new EmployeeDataLayer();
        }
        public List<Employee> GetEmployees()
        {
            return employeeDataLayer.GetEmployees();
        }
        public Employee GetEmployeeById(int id)
        {
            return employeeDataLayer.GetEmployeeById(id);
        }
        public bool AddNewEmployee(Employee employee)
        {
            return employeeDataLayer.AddNewEmployee(employee);
        }
        public bool UpdateEmployeeById(Employee employee)
        {
            return employeeDataLayer.UpdateEmployeeById(employee);
        }
        public bool DeleteEmployeeById(int id)
        {
            return employeeDataLayer.DeleteEmployeeById(id);
        }
    }
}