using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Week5.DapperAPI.Models;

namespace Week5.DapperAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DapperSampleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DapperSampleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult DapperSelect()
        {
            /*
             Person.Person tablosundaki bütün verileri listelemek için bir sql komutu oluşturdum ve Query methodu yardımıyla 
            Databasede sql komutumu çalıştırmış oldum. Geriye dönen datayı Person classıma map ettim ve kullanıcıların ıd, firtname, lastname datalarını
            kullanıma hazır şekilde databaseden çekmiş oldum.
            Sql komutunun profilerdaki hali : select * from [Person].[Person]
             */
            IEnumerable<Person> persons;
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sql = "select * from [Person].[Person]";

                persons = db.Query<Person>(sql);
            }
                return Ok(persons);
        }
    }
}
