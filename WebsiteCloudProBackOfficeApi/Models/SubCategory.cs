using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class SubCategory
    {
        public static int nextid = 0;

        public int ID { get; set; }

        public string Title { get; set; }

        public string Descriptions { get; set; }
        public int FKCategoryId { get; set; }

        public SubCategory(string title, string descriptions, int fkCategory)
        {
            Title = title;
            Descriptions = descriptions;
            FKCategoryId = fkCategory;
        }

        public SubCategory()
        {
            ID = nextid++;
        }
    }
}
