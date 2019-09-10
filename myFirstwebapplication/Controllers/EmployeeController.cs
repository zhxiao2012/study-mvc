using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myFirstwebapplication.Models;
using myFirstwebapplication.Filters;
using myFirstwebapplication.ViewModel;

namespace myFirstwebapplication.Controllers
{
    public class EmployeeController : Controller
    {
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                     

                        return View("CreateEmployee",vm);
                    }   
                    
                    
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        [Authorize]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
         
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach(Employee emp in employees)
            {
                EmployeeViewModel empviewmodel = new EmployeeViewModel();
                empviewmodel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empviewmodel.Salary = emp.Salary.ToString();
                

                if (emp.Salary > 15000)
                {
                    empviewmodel.SalaryColor = "yellow";
                }
                else
                {
                    empviewmodel.SalaryColor = "green";
                }
                empViewModels.Add(empviewmodel);
            }

            employeeListViewModel.Employees = empViewModels;
           
            return View("Index", employeeListViewModel);
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel empListVM = new CreateEmployeeViewModel();
                   
            return View("CreateEmployee", empListVM);
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }

        }
    }
    
}