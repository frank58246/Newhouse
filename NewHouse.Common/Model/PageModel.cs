using System;
using System.Collections.Generic;
using System.Text;

namespace NewHouse.Common.Model
{
    public class PageModel<T>
    {
        public long Total { get; set; }

        public int Start { get; set; }

        public int Size { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}