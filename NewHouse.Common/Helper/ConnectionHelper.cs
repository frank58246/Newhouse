using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace NewHouse.Common.Helper
{
    public class ConnectionHelper : IConnectionHelper
    {
        private readonly IDatabaseHelper _databaseHelper;

        public ConnectionHelper(IDatabaseHelper databaseHelper)
        {
            this._databaseHelper = databaseHelper;
        }

        public IDbConnection House =>
            new SqlConnection(this._databaseHelper.House);

        public IDbConnection Common =>
             new SqlConnection(this._databaseHelper.House);
    }
}