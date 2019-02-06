using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReactOnboarding.Models;
using Newtonsoft.Json;

namespace ReactOnboarding.Controllers
{
    public class CustomerController : Controller
    {
        OnboardingContext db = new OnboardingContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET Products
        public JsonResult GetCustomerList()
        {
            try
            {
                var customerList = db.Customers.Select(x => new CustomerModel
                {
                    CustomerId = x.Id,
                    CustomerName = x.Name,
                    CustomerAddress = x.Address,
                }).ToList();

                return Json(customerList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Data Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // CREATE Product
        public JsonResult CreateCustomer(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                Console.Write("Success");
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Customer Create Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // DELETE Product
        public JsonResult DeleteCustomer(int id)
        {
            try
            {
                var customer = db.Customers.Where(p => p.Id == id).SingleOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Deletion Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // UPDATE Product
        public JsonResult GetUpdateCustomer(int id)
        {
            try
            {
                Customer customer = db.Customers.Where(x => x.Id == id).SingleOrDefault();
                string value = JsonConvert.SerializeObject(customer, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(value, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Customer Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult UpdateCustomer(Customer customer)
        {
            try
            {
                Customer cust = db.Customers.Where(p => p.Id == customer.Id).SingleOrDefault();
                cust.Name = customer.Name;
                cust.Address = customer.Address;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Customer Update Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}