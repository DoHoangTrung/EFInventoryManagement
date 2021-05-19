using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.Helper
{
    public class SearchModel
    {
        public string KeyWords { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

    }
}
