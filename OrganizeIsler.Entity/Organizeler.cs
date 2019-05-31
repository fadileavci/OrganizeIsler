namespace OrganizeIsler.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organizeler")]
    public partial class Organizeler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizeler()
        {
            OrganizeKullanicis = new HashSet<OrganizeKullanici>();
        }

        [Key]
        public int OrganizeID { get; set; }

        [StringLength(50)]
        public string OrganizeAdi { get; set; }

        public DateTime? OrganizeKayitTarihi { get; set; }

        public DateTime? OrganizeTarihi { get; set; }

        public int? KatilimciSayisi { get; set; }

        [StringLength(50)]
        public string OrganizeYeri { get; set; }

        public string OrganizeResmi { get; set; }

        public int OrganizatorID { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizeKullanici> OrganizeKullanicis { get; set; }
    }
}
