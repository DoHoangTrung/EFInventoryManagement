namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceicveVoucherInfo")]
    public partial class ReceicveVoucherInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string IDProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string IDReceiveVoucher { get; set; }

        public int? QuatityInput { get; set; }

        public int? PriceInput { get; set; }

        public int? PriceOutput { get; set; }

        public int? QuatityOutput { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public virtual Product Product { get; set; }

        public virtual ReceiveVoucher ReceiveVoucher { get; set; }
    }
}
