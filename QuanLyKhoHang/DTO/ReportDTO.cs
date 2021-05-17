using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class ReportDTO
    {
        public string ProductID { get; set; }
        public string  ProductName { get; set; }

        public string ProductUnit { get; set; }

        public int ReceiveQuantity { get; set; }
        public int ReceivePrice { get; set; }
        public decimal ReceiveTotalPrice { get; set; }
        public int DeliveryQuantity { get; set; }
        public int DeliveryPrice { get; set; }

        public decimal DeliveryTotalPrice { get; set; }

        public int InventoryNumber { get; set; }

        public decimal Profit { get; set; }
    }
}
