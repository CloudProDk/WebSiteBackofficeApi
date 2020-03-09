using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteCloudProBackOfficeApi.Models;

namespace WebsiteCloudProBackOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private string connectionString = "Data Source=cloudprosqlclientserver.database.windows.net;Initial Catalog=CloudProWebsiteDatabase;User ID=CloudProAdmin;Password=Cloudpro4ever;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static Category readCategoryFromDB(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            string descriptions = reader.GetString(2);
            string imagePath = reader.GetString(3);


            Category category = new Category
            {
                ID = id,
                Titel = title,
                Description = descriptions,
                ImagePath = imagePath
                
            };
            return category;

        }


        //private static List<Category> listOfCategories;
        

        //static CategoryController()
        //{
        //    listOfCategories = new List<Category>();

        //    Category cat1 = new Category(
        //                                    "https://previews.123rf.com/images/yupiramos/yupiramos1706/yupiramos170603259/79414771-cute-round-icon-blue-clouds-cartoon-vector-graphic-design.jpg",
        //                                    "Cloud",
        //                                    "Vi kan hjælpe dig uanset om det er migrering af eksisterende infrastruktur, design af en ny infrastruktur i skyen, sikkerhedshåndtering af forskellige løsninger eller rådgivning omkring Microsoft Cloud."
        //                                );
        //    Category cat2 = new Category(
        //                                    "https://www.logolynx.com/images/logolynx/s_08/087dd16819b99456866c0dc88cf5369d.jpeg",
        //                                    "Web",
        //                                    "Vi laver webløsninger tilpasset dine krav og ønsker Uanset om det er websites, platforme eller integrationer kan vi sikre dig en fremtidssikret og responsiv løsning. Vi benytter bl.a. Angular i vores webprogrammering"
        //                                 );
        //    Category cat3 = new Category(
        //                                    "https://cdn0.iconfinder.com/data/icons/mobile-device/512/mobile-phone-blue-round-2-512.png",
        //                                    "Mobile",
        //                                    "Vi kan udvikle din næste mobilapp eller mobile projekt Vi laver native apps til IOS og Android som både er hurtige og samtidig overholder stigende krav fra Apple og Google. Vi laver også mobilapps til din Cloud- eller webløsning."
        //                                );

        //    Category cat4 = new Category(
        //                                    "https://www.seekpng.com/png/detail/28-287453_outbound-call-support-tech-support-icon-blue.png",
        //                                    "Support",
        //                                    "Lad os håndtere din IT for dig Vi leverer abonnements baserede IT løsninger til mindre virksomheder som ikke kan eller vil selv. Det kalder vi IT-as-a-Service."
        //                                );
        //    listOfCategories.Add(cat1);
        //    listOfCategories.Add(cat2);
        //    listOfCategories.Add(cat3);
        //    listOfCategories.Add(cat4);
        //}
        

        // GET: api/Category
        [HttpGet]
        public List<Category> Get()
        {
            //return listOfCategories;
            const string selectString = "SELECT * FROM Category order by categoryId";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Category> categoryList = new List<Category>();
                        while (reader.Read())
                        {
                            Category category = readCategoryFromDB(reader);
                            categoryList.Add(category);
                        }
                        return categoryList;
                    }
                }
            }
        } 

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get1")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost]
        public int Post([FromBody] Category catObject)
        {
            const string postString = "INSERT INTO Category (title, descriptions, imagePath) VALUES (@Title, @Desc, @ImagePath)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(postString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@Title", catObject.Titel);
                    insertCommand.Parameters.AddWithValue("@Desc", catObject.Description);
                    insertCommand.Parameters.AddWithValue("@ImagePath", catObject.ImagePath);


                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
            }


        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Category catObject)
        {
            //var objectFromList = listOfCategories.SingleOrDefault(x => x.ID == id);
            //catObject.ID = objectFromList.ID;
            //listOfCategories.Remove(objectFromList);
            //listOfCategories.Add(catObject);

            string updateString = $"UPDATE Category SET title = '{catObject.Titel}', descriptions = '{catObject.Description}' WHERE categoryId = '{id}'";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand updateCommand = new SqlCommand(updateString, databaseConnection))
                {
                    int rowsAffected = updateCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            //var objectFromList = listOfCategories.SingleOrDefault(x => x.ID == id);
            //listOfCategories.Remove(objectFromList);
            string deleteString = $"DELETE FROM Category WHERE categoryId='{id}'";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand deleteCommand = new SqlCommand(deleteString, databaseConnection))
                {

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }
    }
}
