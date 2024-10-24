using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using People_DataAccessLayer;

namespace People_BusinessLayer
{
    public class Country
    {
        public static DataTable GetAllCountries()
        {
            return CountryData.GetAllCountries();
        }

        public static int Find(string CountryName)
        {
            return CountryData.GetCountryID(CountryName);
        }
        public static string Find(int CountryID)
        {
            return CountryData.GetCountryName(CountryID);
        }



    }
}
