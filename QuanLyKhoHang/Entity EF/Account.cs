namespace QuanLyKhoHang.Entity_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string PassWord { get; set; }

        [StringLength(30)]
        public string IDType { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
