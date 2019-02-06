using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReactOnboarding.Models;
using Newtonsoft.Json;

namespace ReactOnboarding.Controllers
{
    public class StoreController : Controller
    {
        OnboardingContext db = new OnboardingContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET Products
        public JsonResult GetStoreList()
        {
            try
            {
                var storeList = db.Stores.Select(x => new StoreModel
                {
                    StoreId = x.Id,
                    StoreName = x.Name,
                    StoreAddress = x.Address,
                }).ToList();

                return Json(storeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Data Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // CREATE Store
        public JsonResult CreateStore(Store store)
        {
            try
            {
                db.Stores.Add(store);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Store Create Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // DELETE Product
        public JsonResult DeleteStore(int id)
        {
            try
            {
                var store = db.Stores.Where(p => p.Id == id).SingleOrDefault();
                if (store != null)
                {
                    db.Stores.Remove(store);
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
        public JsonResult GetUpdateStore(int id)
        {
            try
            {
                Store store = db.Stores.Where(x => x.Id == id).SingleOrDefault();
                string value = JsonConvert.SerializeObject(store, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Json(value, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Store Not Found", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult UpdateStore(Store store)
        {
            try
            {
                Store sto = db.Stores.Where(p => p.Id == store.Id).SingleOrDefault();
                sto.Name = store.Name;
                sto.Address = store.Address;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.Data + "Exception Occured");
                return new JsonResult { Data = "Store Update Failed", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            return new JsonResult { Data = "Success", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}