using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace LottoAPI
{
    public class Startup
    {
        private const string ConnectionStringName = "LotteryAppCon";
        private const string TableName = "DrawHistory";
        private const string DatabaseName = "LotteryDB";
        private readonly string _connectionString;
        

        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _connectionString = Configuration.GetConnectionString(ConnectionStringName);

            if (!IsConnectionPossible())
            {
                Console.WriteLine("Connection to database failed. Trying again...");
                Environment.Exit(1);
            }
        }
        
        private bool IsConnectionPossible()
        {

            if (!IsDatabaseExists())
            {
                if (!CreateDatabase())
                {
                    return false;
                }
            }
            
            if (!IsConnectionStringValid())
            {
                return false;
            }
            
            if (!IsTableExists())
            {    
                if (!CreateDbTable())
                {
                    Console.WriteLine("Error! Table could not be created.");
                    return false;
                }
            }
            return true;
        }

        //This method creates the database
        private bool CreateDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("CREATE DATABASE " + DatabaseName + @"", connection);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Check if sql database exists
        private bool IsDatabaseExists()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM sys.databases WHERE name = '" + DatabaseName + @"'", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //This method creates the table
        private bool CreateDbTable()
        {
            try
            {
                //check if table already exists
                using (SqlConnection connection = new(_connectionString))
                {
                    connection.Open();
                    //create table
                    SqlCommand createTable = new("USE " + DatabaseName + @"; 
                    CREATE TABLE " + TableName + @"(DrawId int identity(1,1),
                                                    DrawNumber1 int,
                                                    DrawNumber2 int,
                                                    DrawNumber3 int,
                                                    DrawNumber4 int,
                                                    DrawNumber5 int,
                                                    DrawDateTime char(19));", connection);
                    
                    createTable.ExecuteReader();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //This method checks if the database exists
        private bool IsConnectionStringValid()
        {
            using SqlConnection connection = new(_connectionString);
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                Console.WriteLine("Invalid connection string or access denied. Check if database is set-up correctly.");
                return false;
            }
        }

        //This method checks if the table exists
        private bool IsTableExists()
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                connection.Open();
                SqlCommand command = new("USE LotteryDB; SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + TableName + "'", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        
        
    }
}
