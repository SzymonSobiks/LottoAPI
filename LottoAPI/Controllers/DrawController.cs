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
            string sqlDataSource = _configuration.GetConnectionString("LotteryAppCon");
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
                      @", " + draw.DrawNumber4 + @", " + draw.DrawNumber5 + @", '" + draw.DrawDateTime + @"')
                      ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("LotteryAppCon");
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

    }
}
