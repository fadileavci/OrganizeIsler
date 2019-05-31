namespace OrganizeIsler.DAL
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using OrganizeIsler.Entity;

	public partial class DataContext : DbContext
	{
		public DataContext()
			: base("name=DataContext")
		{
		}

		public virtual DbSet<Kullanicilar> Kullanicilars { get; set; }
		public virtual DbSet<Mesaj> Mesajs { get; set; }
		public virtual DbSet<OrganizeKullanici> OrganizeKullanicis { get; set; }
		public virtual DbSet<Organizeler> Organizelers { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Kullanicilar>()
				.HasMany(e => e.Mesajs)
				.WithOptional(e => e.Kullanicilar)
				.HasForeignKey(e => e.MesajiGonderenID);

			modelBuilder.Entity<Kullanicilar>()
				.HasMany(e => e.Mesajs1)
				.WithOptional(e => e.Kullanicilar1)
				.HasForeignKey(e => e.MesajiAlanID);

			modelBuilder.Entity<Kullanicilar>()
				.HasMany(e => e.OrganizeKullanicis)
				.WithOptional(e => e.Kullanicilar)
				.HasForeignKey(e => e.KatilimciID);

			modelBuilder.Entity<Kullanicilar>()
				.HasMany(e => e.Organizelers)
				.WithRequired(e => e.Kullanicilar)
				.HasForeignKey(e => e.OrganizatorID)
				.WillCascadeOnDelete(false);
		}
	}
}
