
using OrganizeIsler.DAL;
using OrganizeIsler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeIsler.BLL
{
	public class EtkinliklerBLL
	{
		RepositoryPattern<Organizeler> repo = new RepositoryPattern<Organizeler>();
		RepositoryPattern<OrganizeKullanici> repo1 = new RepositoryPattern<OrganizeKullanici>();
		DataContext db = new DataContext();

		public List<Organizeler> GetOrganizeler()
		{
			return repo.List();
		}

		public Organizeler GetOrganizeDetay(int Organizeid)
		{

			return repo.Find(x=>x.OrganizeID==Organizeid);
		}

		public void AddOrganize(Organizeler org)
		{
			repo.Add(org);		
		}

		public List<OrganizeKullanici> GetMyOrganizes(int kullaniciID)
		{
			return repo1.List(x=>x.KatilimciID == kullaniciID);
		}

		public void EtkinligeKatil(OrganizeKullanici organizeKullanici)
		{

			repo1.Add(organizeKullanici);
		}


		//public void EtkinligeKatil(int organizeid, OrganizeKullanici org)
		//{
		//	if (db.OrganizeKullanicis.Any(x => x.OrganizeID == organizeid)) return;
		//	OrganizeKullanici ok = new OrganizeKullanici();
		//	ok.OrganizeID = org.OrganizeID;
		//	ok.KatilimciID = org.KatilimciID;
		//	ok.KayitTarihi = org.KayitTarihi;
		//	ok.KatılımcıSayisi = org.KatılımcıSayisi;

		//	db.OrganizeKullanicis.Add(ok);
		//	db.SaveChanges();
		//}


		public void OrganizeKullaniciUpdate(OrganizeKullanici organizeKullanici)
		{
			repo1.Update(organizeKullanici);
		}

		public OrganizeKullanici GetOrganizeKullanici(int OrganizeKullaniciID)
		{
			return repo1.Find(x => x.OrganizeKatilimciID == OrganizeKullaniciID);
		}

		public void OrganizeKullaniciDelete(OrganizeKullanici org)
		{
			repo1.Delete(org);
		}
	}
}
