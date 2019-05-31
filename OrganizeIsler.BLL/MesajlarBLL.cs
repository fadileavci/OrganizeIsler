using OrganizeIsler.DAL;
using OrganizeIsler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeIsler.BLL
{
    public class MesajlarBLL
	{
		RepositoryPattern<Mesaj> repo = new RepositoryPattern<Mesaj>();
		public List<Mesaj> MesajlariListele(int id)
		{
			return repo.List(x=>x.MesajiAlanID==id );
		}

		public void MesajGonder(Mesaj gonderenid)
		{
			repo.Add(gonderenid);
		}

		public List<Mesaj> GonderdigimMesajlar(int id)
		{
			return repo.List(x => x.MesajiAlanID == id || x.MesajiGonderenID == id);
		}
	}
}
