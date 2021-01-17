using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewHouse.Common.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace NewHouse.Common.Helper
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly ConnectionSetting _connectionSetting;

        public DatabaseHelper(ConnectionSetting connectionSetting)
        {
            this._connectionSetting = connectionSetting;
        }

        public string Hangfire => this.GetConnectionString("Hangfire");

        public string House => this.GetConnectionString("House");

        private string GetConnectionString(string key)
        {
            if (this._connectionSetting.Connections.ContainsKey(key))
            {
                return this._connectionSetting.Connections[key];
            }
            return "";
        }
    }
}