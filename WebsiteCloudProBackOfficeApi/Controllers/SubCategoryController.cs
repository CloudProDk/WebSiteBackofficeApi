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
    public class SubCategoryController : ControllerBase
    {
        private static List<SubCategory> listOfSubCategories;


        static SubCategoryController()
        {
            listOfSubCategories = new List<SubCategory>();

            SubCategory subCat1 = new SubCategory(
                                                    "Miscrosoft Azure",
                                                    "Ny løsning, migrering af eksisterende, eller kombination af begge? Vi rådgiver, designer, udvikler, implementerer og drifter sikre IT infrastruktur projekter baseret på Microsoft Azure."
                                                  );
            SubCategory subCat2 = new SubCategory(
                                                    "Internet of things",
                                                    "Brug for unikke IoT løsninger, der dækker netop dine behov? Vi laver løsninger til bl.a. overvågning, målinger, logistik og automatiserede processer, som blot er et lille udsnit af hvad vi kan."
                                                 );
            SubCategory subCat3 = new SubCategory(
                                                    "Databaser",
                                                    "Ny løsning, migrering af eksisterende, eller kombination af begge? Vi rådgiver, designer, udvikler, implementerer og drifter sikre IT infrastruktur projekter baseret på Microsoft Azure."
                                                 );

            listOfSubCategories.Add(subCat1);
            listOfSubCategories.Add(subCat2);
            listOfSubCategories.Add(subCat3);
        }


        // GET: api/SubCategory
        [HttpGet]
        public List<SubCategory> Get()
        {
            return listOfSubCategories;
        }

        // GET: api/SubCategory/5
        [HttpGet("{id}", Name = "Get2")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SubCategory
        [HttpPost]
        public void Post([FromBody] SubCategory subCatObject)
        {
            listOfSubCategories.Add(subCatObject);
        }

        // PUT: api/SubCategory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SubCategory subCatObject)
        {
            var objectFromList = listOfSubCategories.SingleOrDefault(x => x.ID == id);
            subCatObject.ID = objectFromList.ID;
            listOfSubCategories.Remove(objectFromList);
            listOfSubCategories.Add(subCatObject);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var objectToDelete = listOfSubCategories.SingleOrDefault(x => x.ID == id);
            listOfSubCategories.Remove(objectToDelete);
        }
    }
}
