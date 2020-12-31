using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramworkWithSP.Models;

namespace EntityFramworkWithSP.Controllers
{
    public class EmployeeController : Controller
    {
        
        // GET: Employee
        public ActionResult Index()
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();
                var data = ef.Database.SqlQuery<Employee>("exec sp_getdata").ToList();
                return View(data);
            }
            catch (Exception)
            {
                return View();
            }
        
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();
                SqlParameter param1 = new SqlParameter("@id", id);
                var data = ef.Database.SqlQuery<Employee>("exec sp_getdatabyid @id", param1).SingleOrDefault();
                return View(data);
            }
            catch (Exception)
            {
                return View();
            }
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee collection)
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();

                int data = ef.sp_insertdata(
                    collection.Name, 
                    collection.Age,
                    collection.Job, 
                    collection.Salary);
                ef.SaveChanges();

                if (data > 0)
                {
                    ViewBag.msg = "Insert Sucessfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();
                SqlParameter param1 = new SqlParameter("@id", id);
                var data = ef.Database.SqlQuery<Employee>("exec sp_getdatabyid @id", param1).SingleOrDefault();
                return View(data);
            }
            catch (Exception)
            {
                return View();
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee collection)
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();
                // TODO: Add update logic here
                int data = ef.sp_updatedata(
                    collection.EmpId,
                    collection.Name,
                    collection.Age,
                    collection.Job,
                    collection.Salary);
                ef.SaveChanges();

                if (data > 0)
                {
                    ViewBag.msg = "Update Sucessfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();
                SqlParameter param1 = new SqlParameter("@id", id);
                var data = ef.Database.SqlQuery<Employee>("exec sp_getdatabyid @id", param1).SingleOrDefault();
                return View(data);

            }
            catch (Exception)
            {
                return View();
            }
            
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee collection)
        {
            try
            {
                EntityframworkEntities ef = new EntityframworkEntities();
                // TODO: Add delete logic here
                int data = ef.sp_deletedata(id);
                ef.SaveChanges();
                if (data > 0)
                {
                    ViewBag.msg = "Delete Sucessfully";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
