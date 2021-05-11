namespace QuanLyKhoHang.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryVoucher")]
    public partial class DeliveryVoucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryVoucher()
        {
            DeliveryVoucherInfoes = new HashSet<DeliveryVoucherInfo>();
        }

        [StringLength(30)]
        public string ID { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(30)]
        public string IDCustomer { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryVoucherInfo> DeliveryVoucherInfoes { get; set; }
    }
}
