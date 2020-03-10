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
    public class HeadlineController : ControllerBase {
        //private static List<Headline> hList;
        //private static int id;


        //static HeadlineController()
        //{
        //    id = 0;
        //    hList = new List<Headline>();

        //    Headline header1 = new Headline("Innovative digitale løsninger", "Cloud, Web og Mobil, samt al den IT hjælp du behøver.", id++);

        //    hList.Add(header1);
        //}

        private string connectionString = "Data Source=cloudprosqlclientserver.database.windows.net;Initial Catalog=CloudProWebsiteDatabase;User ID=CloudProAdmin;Password=Cloudpro4ever;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static Headline readHeadlineFromDB(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            string descriptions = reader.GetString(2);


            Headline headline = new Headline
            {
                ID = id,
                Title = title,
                Descriptions = descriptions

            };
            return headline;

        }

        // GET: api/Headline
        [HttpGet]
        public List<Headline> Get()
        {
            //return hList;

            const string selectString = "SELECT * FROM Headline order by headlineId";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Headline> headlineList = new List<Headline>();
                        while (reader.Read())
                        {
                            Headline headline = readHeadlineFromDB(reader);
                            headlineList.Add(headline);
                        }
                        return headlineList;
                    }
                }
            }
        }

        // GET: api/Headline/5
        [HttpGet("{id}", Name = "Get3")]

        public Headline Get(int id)
        
        {
            //var item = hList.SingleOrDefault(r => r.ID == id);
            //return item;

            string selectString = $"SELECT * FROM Headline Where headlineId = '{id}' ";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectString, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        Headline headline = new Headline();
                        while (reader.Read())
                        {
                            headline = readHeadlineFromDB(reader);

                        }
                        return headline;
                    }
                }
            }


        }


        //POST: api/Headline
        [HttpPost]
        public int Post([FromBody] Headline headline)
        {
            //Headline h = header;
            //h.ID = id++;
            //hList.Add(header);
            //return header;

            const string postString = "INSERT INTO Headline (title, descriptions) VALUES (@Header, @Desc)";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(postString, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@Header", headline.Title);
                    insertCommand.Parameters.AddWithValue("@Desc", headline.Descriptions);


                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    return rowsAffected;
                }
            }
        }


        //Put: api/Headline/5
        public int Put(int id, [FromBody] Headline headline)
        {
            //var item = hList.SingleOrDefault(h => h.ID == id);
            //hList.Remove(item);
            //hList.Add(header);

            //return header;

            string updateString = $"UPDATE Headline SET title = '{headline.Title}', descriptions = '{headline.Descriptions}' WHERE headlineId = '{id}'";
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

            string deleteString = $"DELETE FROM Headline WHERE headlineId='{id}'";
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
