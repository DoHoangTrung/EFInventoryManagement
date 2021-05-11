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

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string IDReceiveVoucher { get; set; }

        public int? Quantity { get; set; }

        public int? PriceOutput { get; set; }

        public virtual DeliveryVoucher DeliveryVoucher { get; set; }

        public virtual Product Product { get; set; }

        public virtual ReceiveVoucher ReceiveVoucher { get; set; }
    }
}
