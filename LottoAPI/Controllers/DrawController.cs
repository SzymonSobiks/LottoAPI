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
        private const string CONNECTION_STRING_NAME = "LotteryAppCon";
        private readonly IConfiguration _configuration;

        public DrawController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                      select DrawId, DrawNumber1, DrawNumber2, DrawNumber3, DrawNumber4, DrawNumber5,
                      DrawDateTime from dbo.DrawHistory order by DrawDateTime";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(CONNECTION_STRING_NAME);
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

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Draw draw)
        {

            string query = @"
                      insert into dbo.DrawHistory values
                      (" + draw.DrawNumber1 + @", "+ draw.DrawNumber2 + @", " + draw.DrawNumber3 +
                      @", " + draw.DrawNumber4 + @", " + draw.DrawNumber5 + @", '" + draw.DrawDateTime.Substring(0, 19).Replace('T', ' ') + @"')
                      ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(CONNECTION_STRING_NAME);
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

            string query = @"
                      update dbo.DrawHistory set DrawNumber1 = " + draw.DrawNumber1 + @", DrawNumber2 = " + draw.DrawNumber2 + @", DrawNumber3 = " + draw.DrawNumber3 +
                      @", DrawNumber4 = " + draw.DrawNumber4 + @", DrawNumber5 = " + draw.DrawNumber5 + @", DrawDateTime = '" + draw.DrawDateTime.Substring(0, 19).Replace('T', ' ') + @"'
                      where DrawId = " + draw.DrawId + @"
                      ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(CONNECTION_STRING_NAME);
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

            return new JsonResult("Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

            string query = @"
                      delete from dbo.DrawHistory where DrawId = " + id + @"
                      ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString(CONNECTION_STRING_NAME);
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
