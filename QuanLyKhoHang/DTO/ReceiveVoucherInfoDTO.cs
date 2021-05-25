using QuanLyKhoHang.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class ReceiveVoucherInfoDTO
    {
        public string IDProduct { get; set; }

        public string ProductName { get; set; }

        public string IDReceiveVoucher { get; set; }

        public int? QuantityInput { get; set; }

        public int? PriceInput { get; set; }

        public int? QuantityOutput { get; set; }

        public string Note { get; set; }

        public ReceiveVoucherInfoDTO() { }

        public ReceiveVoucherInfoDTO(string idProduct, string productName, string idVoucher, int quantityInput, int priceInput, int quantityOutput, string note)
        {
            this.IDProduct = idProduct;
            this.ProductName = productName;
            this.IDReceiveVoucher = idVoucher;
            this.QuantityInput = quantityInput;
            this.PriceInput = priceInput;
            this.QuantityOutput = quantityOutput;
            this.Note = note;
        }
    }
}
