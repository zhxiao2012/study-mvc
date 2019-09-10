using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using myFirstwebapplication.Models;
using myFirstwebapplication.Data_Access_Layer;

namespace myFirstwebapplication.Data_Access_Layer
{
    public class SalesERPDAL: DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmp");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
    

    }

    public class DatabaseSettings
    {
        public static void SetDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesERPDAL>());
        }



    }
}