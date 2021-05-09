using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class DTGViewAddDeliveryVoucherDTO
    {
        public string TypeID { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal DeliveryQuantity { get; set; }
        public decimal DeliveryPrice { get; set; }

        public DTGViewAddDeliveryVoucherDTO(string productType,string productID, string productName,decimal deliveryQuantity, decimal deliveryPrice, string typeID)
        {
            TypeID = typeID;
            ProductName = productName;
            ProductID = productID;
            ProductTypeName = productType;
            DeliveryQuantity = deliveryQuantity;
            DeliveryPrice = deliveryPrice;
        }
        public DTGViewAddDeliveryVoucherDTO()
        {
            TypeID = string.Empty;
            ProductName = string.Empty;
            ProductID = string.Empty;
            ProductTypeName = string.Empty;
            DeliveryQuantity = 0;
            DeliveryPrice = 0;
        }
    }
}
