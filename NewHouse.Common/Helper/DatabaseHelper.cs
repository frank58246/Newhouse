using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Helper
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public string Hangfire => "Data Source=localhost:1433;Initial Catalog=Hangfire;User Id=SA;Password=qazwsx";

    }
}
