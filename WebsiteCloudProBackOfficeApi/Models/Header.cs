using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class Header {

        public static int nextid = 0;
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public Header()
        {
            ID = nextid++;
        }

        public Header(string titel, string description)
        {
            ID = nextid++;
            Titel = titel;
            Description = description;
        }
    }
}