using FromProject.Areas.Country.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FromProject.Areas.Country.Controllers
{
    [Area("Country")]
    
    public class LOC_CountryController : Controller
    {
        
        private IConfiguration Configuration;

        public LOC_CountryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connection = this.Configuration.GetConnectionString("Default");
            DataTable dataTable = new DataTable();
            SqlConnection cnn = new SqlConnection(connection);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_LOC_COUTNRY_SELECTALL";
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            return View(dataTable);
        }

        public IActionResult Form() 
        { 
            return View();
        }

        public IActionResult AddEdit(LOC_CountryModel c,int CountryID) 
        {
            string connection = this.Configuration.GetConnectionString("Default");
            SqlConnection cnn1 = new SqlConnection(connection);
            cnn1.Open();
            SqlCommand cmd = cnn1.CreateCommand();
            cmd.CommandType= CommandType.StoredProcedure;
            if(CountryID == 0)
            {
                cmd.CommandText = "PR_LOC_COUNTRY_INSERT";
                cmd.Parameters.AddWithValue("@COUNTRYNAME", c.CountryName);
                cmd.Parameters.AddWithValue("@COUNTRYCODE", c.CountryCode);
            }
            else
            {
                cmd.CommandText = "PR_LOC_COUNTRY_UPDATE";
                cmd.Parameters.AddWithValue("@COUNTRYID", c.CountryID);
                cmd.Parameters.AddWithValue("@COUNTRYNAME", c.CountryName);
                cmd.Parameters.AddWithValue("@COUNTRYCODE", c.CountryCode);
            }
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int CountryID) 
        {
            string connection = this.Configuration.GetConnectionString("Default");
            SqlConnection cnn2 = new SqlConnection( connection);
            cnn2.Open();
            SqlCommand cmd1 = cnn2.CreateCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "PR_LOC_COUNTRY_DELETE";
            cmd1.Parameters.AddWithValue("@COUNTRYID",CountryID);
            cmd1.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}
