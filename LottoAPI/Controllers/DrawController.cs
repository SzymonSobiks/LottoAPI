using LottoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LottoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private const string ConnectionStringName = "LotteryAppCon";
        private const string DatabaseName = "LotteryDB";
        private const string TableName = "DrawHistory";
        private readonly IConfiguration _configuration;

        public DrawController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"USE "+DatabaseName+@";
                           select DrawId, 
                                  DrawNumber1, 
                                  DrawNumber2, 
                                  DrawNumber3, 
                                  DrawNumber4, 
                                  DrawNumber5,
                                  DrawDateTime 
                                  from "+TableName+" order by DrawDateTime";
            DataTable table = new();
            string sqlDataSource = _configuration.GetConnectionString(ConnectionStringName);
            SqlDataReader myReader;
            using (SqlConnection myCon = new(sqlDataSource))
            {
                myCon.Open();
                using SqlCommand myCommand = new(query, myCon);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Draw draw)
        {

            string query = @"USE " + DatabaseName + @"; 
                           insert into " + TableName + @" values("
                                + draw.DrawNumber1 + @", "
                                + draw.DrawNumber2 + @", " 
                                + draw.DrawNumber3 + @", " 
                                + draw.DrawNumber4 + @", " 
                                + draw.DrawNumber5 + @", '" 
                                + draw.DrawDateTime.Substring(0, 19).Replace('T', ' ') + @"')
                                ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(ConnectionStringName);
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Succesfully");
        }

        [HttpPut]
        public JsonResult Put(Draw draw)
        {

            string query = @"USE " + DatabaseName + @"; 
                           update " + TableName + 
                           @" set DrawNumber1 = " + draw.DrawNumber1 +
                              @", DrawNumber2 = " + draw.DrawNumber2 + 
                              @", DrawNumber3 = " + draw.DrawNumber3 +
                              @", DrawNumber4 = " + draw.DrawNumber4 + 
                              @", DrawNumber5 = " + draw.DrawNumber5 +
                              @", DrawDateTime = '" + draw.DrawDateTime.Substring(0, 19).Replace('T', ' ') 
                              + @"' where DrawId = " + draw.DrawId + @"
                              ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(ConnectionStringName);
            SqlDataReader myReader;
            using (SqlConnection myCon = new(sqlDataSource))
            {
                myCon.Open();
                using SqlCommand myCommand = new SqlCommand(query, myCon);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
            }

            return new JsonResult("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            string query = @"USE " + DatabaseName + @"; 
                      delete from " + TableName + " where DrawId = " + id + @"
                      ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(ConnectionStringName);
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Succesfully");
        }

    }
}
