namespace OrganizeIsler.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrganizeKullanici")]
    public partial class OrganizeKullanici
    {
        [Key]
        public int OrganizeKatilimciID { get; set; }

        public int? OrganizeID { get; set; }

        public int? KatilimciID { get; set; }

        public int? KatılımcıSayisi { get; set; }

        public DateTime? KayitTarihi { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Organizeler Organizeler { get; set; }
    }
}
