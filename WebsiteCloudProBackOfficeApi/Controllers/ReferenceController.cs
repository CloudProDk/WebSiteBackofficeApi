using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteCloudProBackOfficeApi.Models;

namespace WebsiteCloudProBackOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {

        #region original
        //// GET: api/Reference
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Reference/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Reference
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Reference/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion


        private static List<Reference> rList;
        private static int id;

        static ReferenceController()
        {
            id = 0;
            rList = new List<Reference>();

            Reference reference1 = new Reference("Laser målling", "lorum ipsum er en god tekst fylder", "https://www.limfjordupdate.dk/wp-content/uploads/smiley-glad.jpg", id++);
            Reference reference2 = new Reference("De bedste praktikanter i verden", "vi er de bedste praktikanter man nogensunde kunne ønske sig", "https://www.limfjordupdate.dk/wp-content/uploads/smiley-glad.jpg", id++);
            Reference reference3 = new Reference("CloudPro", "Cloudpro er det bedste sted at være praktikant", "https://www.limfjordupdate.dk/wp-content/uploads/smiley-glad.jpg", id++);

            rList.Add(reference1);
            rList.Add(reference2);
            rList.Add(reference3);
        }

        // GET: api/Reference
        [HttpGet]
        public List<Reference> Get()
        {
            return rList;
        }

        // GET: api/Reference/
        [HttpGet("{id}", Name = "Get")]
        public Reference Get(int id)
        {
            var item = rList.SingleOrDefault(r => r.ID == id);
            return item;
        }

        //POST: api/Reference
        [HttpPost]
        public Reference InsertCustomer([FromBody] Reference reference)
        {
            Reference r = reference;
            r.ID = id++;
            rList.Add(reference);
            return reference;
        }

        // PUT: api/Reference/
        [HttpPut("{id}")]
        public Reference Put(int id, [FromBody] Reference reference)
        {
            var item = rList.SingleOrDefault(r => r.ID == id);
            reference.ID = item.ID;
            rList.Remove(item);
            rList.Add(reference);

            return reference;
        }
    }
}
