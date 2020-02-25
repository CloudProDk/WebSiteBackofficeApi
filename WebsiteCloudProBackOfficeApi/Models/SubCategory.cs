﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteCloudProBackOfficeApi.Models
{
    public class SubCategory
    {
        public static int nextid = 0;

        public int ID { get; set; }

        public string Titel { get; set; }

        public string Description { get; set; }

        public SubCategory(string titel, string description)
        {
            ID = nextid++;
            Titel = titel;
            Description = description;
        }

        public SubCategory()
        {
            ID = nextid++;
        }
    }
}