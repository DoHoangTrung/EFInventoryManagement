namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductCanSellDAT
    {
        public string TypeName { get; set; }

        public string ProductID { get; set; }

        public string ProductName { get; set; }

        public string Unit { get; set; }

        public int? SumPriceInput { get; set; }

        public int? SumQuantityInput { get; set; }

        public int? SumQuantityOutput { get; set; }

        public int? Count { get; set; }

        public string IDType { get; set; }

    }
}
