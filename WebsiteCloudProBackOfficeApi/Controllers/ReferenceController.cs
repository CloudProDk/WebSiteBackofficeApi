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
    public class ReferenceController : ControllerBase
    {

        #region original
        //// GET: api/Reference
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Reference/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Reference
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Reference/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion


        //private static List<Reference> rList;
        //private static int id;

        //static ReferenceController()
        //{
        //    id = 0;
        //    rList = new List<Reference>();

        //    Reference reference1 = new Reference("Laser målling", "lorum ipsum er en god tekst fylder", "https://www.limfjordupdate.dk/wp-content/uploads/smiley-glad.jpg", id++);
        //    Reference reference2 = new Reference("De bedste praktikanter i verden", "vi er de bedste praktikanter man nogensunde kunne ønske sig", "https://www.limfjordupdate.dk/wp-content/uploads/smiley-glad.jpg", id++);
        //    Reference reference3 = new Reference("CloudPro", "Cloudpro er det bedste sted at være praktikant", "https://www.limfjordupdate.dk/wp-content/uploads/smiley-glad.jpg", id++);

        //    rList.Add(reference1);
        //    rList.Add(reference2);
        //    rList.Add(reference3);
        //}

        private string connectionString = "Data Source=cloudprosqlclientserver.database.windows.net;Initial Catalog=CloudProWebsiteDatabase;User ID=CloudProAdmin;Password=Cloudpro4ever;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static Reference readReferenceFromDB(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string hdr = reader.GetString(1);
            string descriptions = reader.GetString(2);
            string imagePath = reader.GetString(3);


            Reference reference = new Reference
            {
                ID = id,
                Header = hdr,
                Description = descriptions,
                ImagePath = imagePath

            };
            return reference;
        }



        // GET: api/Reference
        [HttpGet]
        public List<Reference> Get()
        {
            //return rList;

            const string selectString = "SELECT * FROM Reference order by referenceId";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Reference> referenceList = new List<Reference>();
                        while (reader.Read())
                        {
                            Reference reference = readReferenceFromDB(reader);
                            referenceList.Add(reference);
                        }
                        return referenceList;
                    }
                }
            }
        }

        // GET: api/Reference/
        [HttpGet("{id}", Name = "Get")]
        public Reference Get(int id)
        {
            //var item = rList.SingleOrDefault(r => r.ID == id);
            //return item;

            string selectString = $"SELECT * FROM Reference Where referenceId = '{id}' ";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        Reference reference = new Reference();
                        while (reader.Read())
                        {
                            reference = readReferenceFromDB(reader);

                        }
                        return reference;
                    }
                }
            }
        }

        //POST: api/Reference
        [HttpPost]
        public int Post([FromBody] Reference reference)
        {
            //Reference r = reference;
            //r.ID = id++;
            //rList.Add(reference);
            //return reference;

            const string postString = "INSERT INTO Reference (title, descriptions, imagePath) VALUES (@Header, @Desc, @ImagePath)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(postString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@Header", reference.Header);
                    insertCommand.Parameters.AddWithValue("@Desc", reference.Description);
                    insertCommand.Parameters.AddWithValue("@ImagePath", reference.ImagePath);


                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
            }

        }

        // PUT: api/Reference/
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Reference reference)
        {
            //var item = rList.SingleOrDefault(r => r.ID == id);
            //reference.ID = item.ID;
            //rList.Remove(item);
            //rList.Add(reference);

            //return reference;

            string updateString = $"UPDATE Reference SET title = '{reference.Header}', descriptions = '{reference.Description}' WHERE categoryId = '{id}'";
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

            string deleteString = $"DELETE FROM Reference WHERE referenceId='{id}'";
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
