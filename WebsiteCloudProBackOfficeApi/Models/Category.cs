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

        public string Title { get; set; }

        public string Descriptions { get; set; }

        public string ImagePath { get; set; }

        public Category(string imagepath, string title, string descriptions)
        {
            ID = nextid++;
            Title = title;
            Descriptions = descriptions;
            ImagePath = imagepath;
        }

        public Category()
        {
            ID = nextid++;
        }
    }
}
