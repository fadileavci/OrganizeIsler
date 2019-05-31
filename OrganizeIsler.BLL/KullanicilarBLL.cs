using OrganizeIsler.DAL;
using OrganizeIsler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeIsler.BLL
{
	public class KullanicilarBLL

		
	{

		RepositoryPattern<Kullanicilar> repo = new RepositoryPattern<Kullanicilar>();

		public Kullanicilar KullaniciGiris(string email)
		{
			return repo.Find(x=>x.Email==email);
		}

		public void KullaniciEkle(Kullanicilar kul)
		{
			repo.Add(kul);
		}

	}
}
