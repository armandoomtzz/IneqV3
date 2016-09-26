using IneqApi.Models;
using IneqWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IneqWebApp.Controllers
{
    public class WarehouseController : Controller
    {
        // GET: Warehouse
        public ActionResult Index()
        {
            List<Warehouse> model = new List<Warehouse>();
            model = new WarehouseData().Get("", true);
            return View(model);   
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Warehouse/Create
        [HttpPost]
        public ActionResult Create(int id, string description,string Is,string responsable,bool active)
        {
            WarehouseData wh = new WarehouseData();
            wh.Save( id, description,  Is, responsable,  active);
          return  RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(int id, string description, string Is, string responsable, bool active)
        {
            WarehouseData wh = new WarehouseData();
            wh.Save(id, description, Is, responsable, active);
            return RedirectToAction("Index");
        }
    }
}
