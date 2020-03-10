using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class Reference{
        public static int nextid = 0;
        public int ID { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string ImagePath { get; set; }
        public int FKSubCategoryId { get; set; }
        public Reference()
        {
        }

        public Reference(string title, string descriptions, string imagepath, int fkSubCategoryId)
        {
            Title = title;
            Descriptions = descriptions;
            ImagePath = imagepath;
            FKSubCategoryId = fkSubCategoryId;
        }
    }
  }
