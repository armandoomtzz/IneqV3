using IneqWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class WarehouseController : ApiController
    {
        private IneqDbContext db = new IneqDbContext();
        // GET: api/Warehouse
        public List<Warehouse>Get()
        {
            return db.Warehouse.ToList();
        }

        // GET: api/Warehouse/5
        public List<Warehouse>Get(string Descripcion)
        {
            return db.Warehouse.Where(e => e.Description == Descripcion ).ToList();
        }

        // POST: api/Warehouse
        public bool Post(int id, string Descripcion, string IS, string Responsable, string Activo)
        {
            var e = new Warehouse()
            {
                Id = id,
                Description = Descripcion,
                IS = IS,
                Responsable = Responsable,
                Active = Convert.ToBoolean(Activo)
            };
            db.Warehouse.Attach(e);
            db.Configuration.ValidateOnSaveEnabled = true;
            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Warehouse/5
        public bool Put(int id, string Descripcion, string IS, string Responsable, string Activo)
        {
            var e = new Warehouse()
            {
                Id = id,
                Description = Descripcion,
                IS = IS,
                Responsable = Responsable,
                Active = Convert.ToBoolean(Activo)
            };
            db.Warehouse.Add(e);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Warehouse/5
        public void Delete(int id)
        {
        }
    }
}
