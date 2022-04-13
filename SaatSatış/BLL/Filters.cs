using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaatSatış.DAL;
using SaatSatış.Models;
using System.Web.Mvc;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Drawing;

namespace SaatSatış.BLL
{
    public class Filters
    {
        WatchContext db = new WatchContext();
        public LayoutVM FiltersView()
        {
            LayoutVM layoutVM = new LayoutVM();
            layoutVM.Genders = db.Genders.ToList();
            layoutVM.Brands = db.Brands.ToList();
            layoutVM.StrapTypes = db.StrapTypes.ToList();
            layoutVM.GlassTypes = db.GlassTypes.ToList();
            layoutVM.CaseShapes = db.CaseShapes.ToList();
            layoutVM.Colors = db.Colors.ToList();
            layoutVM.Technologies = db.Technologies.ToList();

            return layoutVM;
        }
        public Func<WatchVM, bool> FuncFilter(string str, int id)
        {
            if (str == "gender")
                return w => w.Watch.Gender.GenderID == id;
            else if (str == "brand")
                return w => w.Watch.Brand.BrandID == id;
            else if (str == "caseShape")
                return w => w.Watch.CaseShape.CaseShapeID == id;
            else if (str == "color")
                return w => w.Watch.Color.ColorID == id;
            else if (str == "glassType")
                return w => w.Watch.GlassType.GlassTypeID == id;
            else if (str == "strapType")
                return w => w.Watch.StrapType.StrapTypeID == id;
            else if (str == "technology")
                return w => w.Watch.Technology.TechnologyID == id;
            return null;
        }
        public List<WatchVM> Search(string str)
        {
            List<WatchVM> list = new List<WatchVM>();
            foreach (var watch in db.Watches.Where(w => w.Gender.GenderName.Contains(str) || w.Brand.BrandName.Contains(str) || w.CaseShape.CaseShapeName.Contains(str) || w.Color.ColorName.Contains(str) || w.GlassType.GlassTypeName.Contains(str) || w.StrapType.StrapTypeName.Contains(str) || w.Technology.TechnologyName.Contains(str) || w.WatchModel.Contains(str)))
            {
                WatchVM vm = new WatchVM();
                vm.Watch = watch;
                vm.Pictures = watch.Pictures;
                list.Add(vm);
            }
            return list;
        }
        public List<WatchVM> FilterByGender(string gender)
        {
            
            List<WatchVM> list = new List<WatchVM>();
            foreach(var watch in db.Watches.Where(w => w.Gender.GenderName.Contains(gender)))
            {
                WatchVM vm = new WatchVM();
                vm.Watch = watch;
                vm.Pictures = watch.Pictures;
                list.Add(vm);
            }
            
            return list;
        }
        public List<WatchVM> FilterByBrand(string brand)
        {
            List<WatchVM> list = new List<WatchVM>();
            foreach (var watch in db.Watches.Where(w => w.Brand.BrandName.Contains(brand)))
            {
                WatchVM vm = new WatchVM();
                vm.Watch = watch;
                vm.Pictures = watch.Pictures;
                list.Add(vm);
            }
            return list;
        }

        public List<WatchVM> FilterWithCheckBoxes(FormCollection collection) //FormCollection
        {
            List<WatchVM> filteredWatches = new List<WatchVM>();
            foreach (var item in db.Watches)
            {
                WatchVM watchVM = new WatchVM();
                watchVM.Watch = item;
                watchVM.Pictures = item.Pictures;
                filteredWatches.Add(watchVM);
            }
          
            List<WatchVM> removedList = new List<WatchVM>();
            foreach (string name in collection)
            {
                 removedList.Clear();
                 foreach (string id in collection.GetValues(name))
                {
                    foreach (var watch in filteredWatches.Where(FuncFilter(name, Convert.ToInt32(id))).ToList())
                    {
                         removedList.Add(watch);
                    }
                }
                filteredWatches.Clear();
                filteredWatches.AddRange(removedList);
            }
             return filteredWatches;
        }
    }
}