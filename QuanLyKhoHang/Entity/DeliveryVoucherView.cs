namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryVoucherView")]
    public partial class DeliveryVoucherView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string VoucherID { get; set; }

        public DateTime? Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(20)]
        public string Unit { get; set; }

        public int? SumQuantity { get; set; }

        public int? PriceOutput { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string CustomerID { get; set; }
    }
}
