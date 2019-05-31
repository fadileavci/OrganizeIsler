namespace OrganizeIsler.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mesaj")]
    public partial class Mesaj
    {
        public int MesajID { get; set; }

        public int? MesajiGonderenID { get; set; }

        public int? MesajiAlanID { get; set; }

        [Column("Mesaj")]
        public string Mesaj1 { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Kullanicilar Kullanicilar1 { get; set; }
    }
}
