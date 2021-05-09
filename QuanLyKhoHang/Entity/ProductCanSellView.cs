namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCanSellView")]
    public partial class ProductCanSellView
    {
        [StringLength(100)]
        public string TypeName { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        public int? SumPriceInput { get; set; }

        public int? SumQuantityInput { get; set; }

        public int? SumQuantityOutput { get; set; }

        public int? Count { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string IDType { get; set; }
    }
}
