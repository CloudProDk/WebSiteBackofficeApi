using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class Headline {

        public static int nextid = 0;
        public int ID { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public Headline()
        {
            ID = nextid++;
        }

        public Headline(string title, string descriptions, int ID)
        {
            ID = nextid++;
            Title = title;
            Descriptions = descriptions;
        }
    }
}