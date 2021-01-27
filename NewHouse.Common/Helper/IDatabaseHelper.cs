using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Helper
{
    /// <summary>
    /// 資料庫連線字串helper
    /// </summary>
    public interface IDatabaseHelper
    {
        string Hangfire { get; }

        string House { get; }

        string Common { get; }

        string Redis { get; }
    }
}