using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myFirstwebapplication.Data_Access_Layer;


namespace myFirstwebapplication.Models
{
    public class EmployeeBusinessLayer
    {
        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL SalesDal = new SalesERPDAL();
            SalesDal.Employees.AddRange(employees);
            SalesDal.SaveChanges();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public List<Employee> GetEmployees()
        {
            
            SalesERPDAL salesDal = new SalesERPDAL();

            return (salesDal.Employees.ToList());
        }
       
        public UserStatus GetUserValidity(UserDetails u)
        {
            if(u.UserName=="Admin" && u.PassWord == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if(u.UserName=="peter" && u.PassWord == "xiao")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
        
        
        /*
        public bool IsValidUser(UserDetails u)
        {
            if(u.UserName=="Admin" && u.PassWord == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
     */
    }
}