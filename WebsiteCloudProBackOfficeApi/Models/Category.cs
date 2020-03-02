using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class Category
    {
        public static int nextid =  0;

        public int ID { get; set; }

        public string Titel { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public Category(string imagepath, string titel, string description)
        {
            ID = nextid++;
            Titel = titel;
            Description = description;
            ImagePath = imagepath;
        }

        public Category()
        {
            ID = nextid++;
        }
    }
}
