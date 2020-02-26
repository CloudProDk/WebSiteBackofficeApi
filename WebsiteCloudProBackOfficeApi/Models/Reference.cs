using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class Reference{
        public static int nextid = 0;
        public int ID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Reference()
        {
        }

        public Reference(string header, string description, string imagepath, int id)
        {
            ID = id;
            Header = header;
            Description = description;
            ImagePath = imagepath;
        }
    }
  }
