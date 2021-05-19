using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class ReceiveVoucherDTO
    {
        public string ReceiveVoucherID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public DateTime Date { get; set; }
        public int QuantityInput { get; set; }
        public int PriceInput { get; set; }
        public string Note { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
