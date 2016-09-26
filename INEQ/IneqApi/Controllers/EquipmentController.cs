using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IneqApi.Controllers
{
    public class EquipmentController : ApiController
    {
        // GET: api/Equipment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Equipment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equipment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Equipment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Equipment/5
        public void Delete(int id)
        {
        }
    }
}
