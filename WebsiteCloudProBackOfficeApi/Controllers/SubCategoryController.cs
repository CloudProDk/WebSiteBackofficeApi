using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebsiteCloudProBackOfficeApi.Models;

namespace WebsiteCloudProBackOfficeApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private string connectionString = "Data Source=cloudprosqlclientserver.database.windows.net;Initial Catalog=CloudProWebsiteDatabase;User ID=CloudProAdmin;Password=Cloudpro4ever;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static SubCategory readSubCategoryFromDB(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            string descriptions = reader.GetString(2);
            int fkCategoryId = reader.GetInt32(3);


            SubCategory subCategory = new SubCategory
            {
                ID = id,
                Title = title,
                Descriptions = descriptions,
                FKCategoryId = fkCategoryId

            };
            return subCategory;

        }

        //private static List<SubCategory> listOfSubCategories;


        //static SubCategoryController()
        //{
        //    listOfSubCategories = new List<SubCategory>();

        //    SubCategory subCat1 = new SubCategory(
        //                                            "Miscrosoft Azure",
        //                                            "Ny løsning, migrering af eksisterende, eller kombination af begge? Vi rådgiver, designer, udvikler, implementerer og drifter sikre IT infrastruktur projekter baseret på Microsoft Azure."
        //                                          );
        //    SubCategory subCat2 = new SubCategory(
        //                                            "Internet of things",
        //                                            "Brug for unikke IoT løsninger, der dækker netop dine behov? Vi laver løsninger til bl.a. overvågning, målinger, logistik og automatiserede processer, som blot er et lille udsnit af hvad vi kan."
        //                                         );
        //    SubCategory subCat3 = new SubCategory(
        //                                            "Databaser",
        //                                            "Ny løsning, migrering af eksisterende, eller kombination af begge? Vi rådgiver, designer, udvikler, implementerer og drifter sikre IT infrastruktur projekter baseret på Microsoft Azure."
        //                                         );

        //    listOfSubCategories.Add(subCat1);
        //    listOfSubCategories.Add(subCat2);
        //    listOfSubCategories.Add(subCat3);
        //}


        // GET: api/SubCategory
        [HttpGet]
        public List<SubCategory> Get()
        {
            //return listOfSubCategories;
            const string selectString = "SELECT * FROM SubCategory order by subCategoryId ";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<SubCategory> subCategoryList = new List<SubCategory>();
                        while (reader.Read())
                        {
                            SubCategory subCategory = readSubCategoryFromDB(reader);
                            subCategoryList.Add(subCategory);
                        }
                        return subCategoryList;
                    }
                }
            }
        }

        // GET: api/SubCategory/5
        [HttpGet("{id}", Name = "Get2")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SubCategory
        [HttpPost]
        public int Post([FromBody] SubCategory subCatObject)
        {
            //listOfSubCategories.Add(subCatObject);

            string postString = $"INSERT INTO subCategory (title, descriptions, fkCategoryId) VALUES (@Title, @Desc, @fk)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(postString, databaseConnection))
                {

                    insertCommand.Parameters.AddWithValue("@Title", subCatObject.Title);
                    insertCommand.Parameters.AddWithValue("@Desc", subCatObject.Descriptions);
                    insertCommand.Parameters.AddWithValue("@fk", subCatObject.FKCategoryId);


                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }

        // PUT: api/SubCategory/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] SubCategory subCatObject)
        {
            //var objectFromList = listOfSubCategories.SingleOrDefault(x => x.ID == id);
            //subCatObject.ID = objectFromList.ID;
            //listOfSubCategories.Remove(objectFromList);
            //listOfSubCategories.Add(subCatObject);

            string updateString = $"UPDATE SubCategory SET title = '{subCatObject.Title}', descriptions = '{subCatObject.Descriptions}', fkCategoryId = '{subCatObject.FKCategoryId}' WHERE subCategoryId = '{id}'";
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
            //var objectToDelete = listOfSubCategories.SingleOrDefault(x => x.ID == id);
            //listOfSubCategories.Remove(objectToDelete);

            string deleteString = $"DELETE FROM SubCategory WHERE subCategoryId='{id}'";
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
