using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class Headline {

        public static int nextid = 0;
        public int ID { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public Headline()
        {
            ID = nextid++;
        }

        public Headline(string titel, string description, int ID)
        {
            ID = nextid++;
            Titel = titel;
            Description = description;
        }
    }
}