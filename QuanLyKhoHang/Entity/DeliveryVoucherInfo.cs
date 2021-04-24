namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryVoucherInfo")]
    public partial class DeliveryVoucherInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string IDProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string IDDeliveryVoucher { get; set; }

        public int? Quantity { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public virtual DeliveryVoucher DeliveryVoucher { get; set; }

        public virtual Product Product { get; set; }
    }
}
