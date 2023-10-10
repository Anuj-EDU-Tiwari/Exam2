using Exam2.Db_conn;
using Exam2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Exam2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //public int Id { get; private set; }

        public ActionResult Index()
        {
            List<Class1> emplist = new List<Class1>();
            cshar5batchEntities db = new cshar5batchEntities();
            var kt = db.Table_1.ToList();
            foreach (var item in kt)
            {
                emplist.Add(new Class1()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    Address = item.Address,
                    Gender = item.Gender,
                    Zipcode = item.Zipcode,
                    Salary = item.Salary,


                });
            }
            return View(emplist);
        }
        public ActionResult Delete(int Id)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            var deletedata = db.Table_1.Where(x => x.Id == Id).First();
            //var deletedata = db.tbl_Emp.Where(x => x.Id == Id).First();
            db.Table_1.Remove(deletedata);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddUpdate()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult AddUpdate(Class1 obj)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            Table_1 objemp = new Table_1();
            objemp.Id = obj.Id;
            objemp.Name = obj.Name;
            objemp.Email = obj.Email;
            objemp.Mobile = obj.Mobile;
            objemp.Address = obj.Address;
            objemp.Gender = obj.Gender;
            objemp.Zipcode = obj.Zipcode;
            objemp.Salary = obj.Salary;
           

            if (obj.Id == 0)
            {
                //add new record
                db.Table_1.Add(objemp);
                db.SaveChanges();
            }
            else
            {
                //update/edit new record
                db.Entry(objemp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            Class1 emp = new Class1();
            cshar5batchEntities db = new cshar5batchEntities();
            var editdata = db.Table_1.Where(a => a.Id == Id).First(); //gets data
            emp.Address = editdata.Address; // in these lines we give data to our model emp
            emp.Salary = editdata.Salary;
            emp.Zipcode = editdata.Zipcode;
            emp.Gender = editdata.Gender;
            emp.Email = editdata.Email;
            emp.Mobile = editdata.Mobile;
            emp.Name = editdata.Name;
            emp.Id = Id;
            //return View("AddEmp",editdata); //earlier
            return View("AddUpdate", emp); //updated
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Table_2 log)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            var login = db.Table_2.Where(a => a.Email == log.Email).FirstOrDefault();

            if (login == null) 
            {
                TempData["usenofound"] = "not found try again";

            }
            else
            {
                if (login.Email.ToLower()==log.Email.ToLower()&&login.Password==log.Password)
                {
                    Session["Name"] = login.Name;
                    Session["Email"] = login.Email;
                    FormsAuthentication.SetAuthCookie(login.Email, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Password"] = "Invalid Password";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
           

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Table_2 l)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            db.Table_2.Add(l);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult NewPassword()
        {
            
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult NewPassword(Table_2 lr)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            var p = db.Table_2.Where(a => a.Email.ToLower() == lr.Email.ToLower()).FirstOrDefault();
            if (lr.NewPassword == lr.Password)
            {
                p.Password = lr.NewPassword;
                db.Entry(p).State=System.Data.Entity.EntityState.Modified;
                //db.SaveChanges ();
                db.SaveChanges();
                TempData["msg"] = "<script>alter('Password has been changed successfully');</script>";

            }
            else
            {
                TempData["msg"] = "<script>alter('Password matched');</script>";
            }
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}