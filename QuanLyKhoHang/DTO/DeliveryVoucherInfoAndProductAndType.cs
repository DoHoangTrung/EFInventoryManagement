using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class DeliveryVoucherInfoAndProductAndType
    {
        public DeliveryVoucherInfo deliInfo { get; set; }
        public Product product { get; set; }
        public ProductType productType { get; set; }

    }
}
