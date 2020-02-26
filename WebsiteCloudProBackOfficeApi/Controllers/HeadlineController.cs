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
    public class HeadlineController : ControllerBase {
        private static List<Header> hList;
        private static int id;


        static HeadlineController()
        {
            id = 0;
            hList = new List<Header>();

            Header header1 = new Header("Innovative digitale løsninger", "Cloud, Web og Mobil, samt al den IT hjælp du behøver.", id++);

            hList.Add(header1);
        }
        // GET: api/Header/Get
        [HttpGet]
        public List<Header> Get()
        {
            return hList;
        }

        // GET: api/Header/Get
        [HttpGet("{id}", Name = "Get")]
        public Header Get(int id)
        {
            var item = hList.SingleOrDefault(r => r.ID == id);
            return item;
        }


        //POST: api/Header/Set
        [HttpPost]
        public Header InsertText([FromBody] Header header
            )
        {
            Header h = header;
            h.ID = id++;
            hList.Add(header);
            return header;
        }


        //Put: api/Header/Put
        public Header Put(int id, [FromBody] Header header)
        {
            var item = hList.SingleOrDefault(h => h.ID == id);
            hList.Remove(item);
            hList.Add(header);

            return header;
        }

    }
}
