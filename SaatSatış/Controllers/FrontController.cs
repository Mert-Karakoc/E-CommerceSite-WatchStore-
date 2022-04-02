using Models;
using SaatSatış.DAL;
using SaatSatış.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaatSatış.BLL;
using System.Data.Entity;
using PagedList;
using System.Web.UI.WebControls;

namespace SaatSatış.Controllers
{
    public class FrontController : Controller
    {
        private WatchContext db = new WatchContext();
        Filters filters = new Filters();
        // GET: Front
        public ActionResult Index()
        {
            List<WatchVM> list = new List<WatchVM>();
            foreach (Watch watch in db.Watches)
            {
                WatchVM vm = new WatchVM();
                vm.Watch = watch;
                vm.Pictures = watch.Pictures;
                list.Add(vm);
            }
            ViewBag.Brands = db.Brands.ToList();
            return View(list.Take(5));
        }
        public static List<WatchVM> FilteredList { get; set; }
        public ActionResult FilteredWatches(string gender, int? page, FormCollection collection)
        {
            int pageNumber = (page ?? 1);
            
            if (gender == null)
            {
                if (FilteredList == null) { FilteredList = filters.FilterWithCheckBoxes(collection); }

                return View(FilteredList.ToPagedList(pageNumber, 20));
            }
            else
            {
                ViewBag.Gender = gender;
                return View(filters.FilterByGender(gender).ToPagedList(pageNumber, 20));
            }
        }

        [HttpPost]
        public ActionResult FilteredWatches(FormCollection collection, int? page)
        {
            int pageNumber = (page ?? 1);
            FilteredList = filters.FilterWithCheckBoxes(collection);
            return View(FilteredList.ToPagedList(pageNumber, 20));
        }

        public ActionResult Filters()
        {
            ViewBag.Filters = filters.FiltersView();
            return PartialView();
        }
        public ActionResult WatchDetail(int watchId)
        {
            Watch watch = db.Watches.Where(w => w.WatchID == watchId).SingleOrDefault();
            WatchVM watchVM = new WatchVM();
            watchVM.Watch = watch;
            watchVM.Pictures = watch.Pictures;
            return View(watchVM);
        }
        public ActionResult Cart()
        {
            List<Cart> carts = new List<Cart>();
            if (Session["UserID"] != null)
            {
                foreach (var item in db.Carts)
                {
                    if (item.Active == true)
                    {
                        carts.Add(item);
                    }
                }
            }
            decimal sumPrice = 0;
            foreach (var item in carts)
            {
                sumPrice += item.Number * item.Watch.Price;
            }
            ViewBag.SumPrice = sumPrice;
            return View(carts);
        }
        public ActionResult AddCart(int watchId)
        {
            if (Session["UserID"] != null)
            {
                Cart cartExist = db.Carts.Where(c => c.WatchID == watchId && c.Active == true).SingleOrDefault();

                if (db.Carts.ToList().Contains(cartExist) == true && cartExist.Active == true)
                {
                    cartExist.Number++;
                    db.Entry(cartExist).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else if ((db.Carts.ToList().Contains(cartExist) == true && cartExist.Active == false) || db.Carts.ToList().Contains(cartExist) == false || cartExist == null)
                {
                    Cart cart = new Cart();
                    cart.Number = 1;
                    cart.Active = true;
                    cart.UserID = (int)Session["UserID"];
                    cart.WatchID = watchId;
                    db.Carts.Add(cart);
                    db.SaveChanges();
                }
            }
            else
            {
                ViewBag.Message = "Giriş yapmalısınız.";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult Search(string search, int? page)
        {
            ViewData["CurrentFilter"] = search;
            int pageNumber = (page ?? 1);
            return View(filters.Search(search).ToPagedList(pageNumber, 2));
        }
        public ActionResult RemoveCart(int watchId)
        {
            Cart cart = db.Carts.Where(c => c.WatchID == watchId && c.Active == true).SingleOrDefault();
            if (cart.Number > 1)
            {
                cart.Number--;
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (cart.Number == 1)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }
        public ActionResult Purchase(int userId)
        {
            foreach (var item in db.Carts.Where(c => c.UserID == userId))
            {
                if (item.Active == true)
                {
                    item.Active = false;
                    db.Entry(item).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}