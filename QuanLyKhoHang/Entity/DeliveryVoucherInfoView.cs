namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryVoucherInfoView")]
    public partial class DeliveryVoucherInfoView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ProductName { get; set; }

        public int? SumQuantity { get; set; }

        public int? PriceOutput { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string DeliveryVoucherID { get; set; }
    }
}
