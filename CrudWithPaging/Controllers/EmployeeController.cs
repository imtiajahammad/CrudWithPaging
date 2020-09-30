using CrudWithPaging.BusinessLayer;
using CrudWithPaging.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudWithPaging.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager employeeManager;
        public EmployeeController()
        {
            this.employeeManager = new EmployeeManager();
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 2;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Employee> emp = null;
            List<Employee> employees = employeeManager.GetEmployees();
            emp = employees.ToPagedList(pageIndex, pageSize);
            return View(emp);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = employeeManager.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            bool updatedFlag=employeeManager.UpdateEmployeeById(employee);
            if (updatedFlag)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee employee = employeeManager.GetEmployeeById(id);
            return View(employee);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = employeeManager.GetEmployeeById(id);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            bool deletedFlag = employeeManager.DeleteEmployeeById(employee.id);
            if (deletedFlag)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            bool addedFlag = employeeManager.AddNewEmployee(employee);
            if (addedFlag)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }



    }
}