using IneqApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IneqWebApp.Data
{
    public class WarehouseData :DataBase<Warehouse>
    {

      
            public override string BaseCatalog
            {
                get { return "/api/equipmentType/"; }
            }

            public bool Save(int id, string description,string Is,string responsable,bool active)
            {
                Warehouse model = new Warehouse();
                model.Id = id;
                model.Description = description;
                model.IS = Is;
                model.Responsable = responsable;
                model.Active = active;
                return Save(model, id > 0).Result;
            }

        public List<Warehouse> Get(string description, bool active)
        {
            return Get("GetByAllFilters", "?description=" + description + "?Is=" + active).Result;
            }
        }
    }
