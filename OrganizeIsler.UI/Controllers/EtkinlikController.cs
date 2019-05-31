using OrganizeIsler.BLL;
using OrganizeIsler.Entity;
using OrganizeIsler.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OrganizeIsler.UI.Controllers
{
	public class EtkinlikController : Controller
	{
		EtkinliklerBLL etkinliklerBLL = new EtkinliklerBLL();

		// GET: Etkinlik
		public ActionResult Index()
		{
			return View();
		}
		
		public ActionResult Etkinlikler()
		{
			List<Organizeler> etkinlikler = etkinliklerBLL.GetOrganizeler();
			return View(etkinlikler);
		}
		public ActionResult Detay(int id)
		{
			Organizeler org = etkinliklerBLL.GetOrganizeDetay(id);
			
			OrganizeKatilimModel model = new OrganizeKatilimModel
			{
				organizeler = org,
			
			};
			return View(model);
		}

		public ActionResult Etkinliklerim()
		{
			Kullanicilar kul = Session["kullanici"] as Kullanicilar;
			List<OrganizeKullanici> etkinlik = etkinliklerBLL.GetMyOrganizes(kul.KullaniciID);			
			return View(etkinlik);
		}

		public ActionResult KullaniciEtkinlikDuzenle(int id)
		{
			OrganizeKullanici organizeKullanici = etkinliklerBLL.GetOrganizeKullanici(id);
			return View(organizeKullanici);
		}

		[HttpPost]
		public ActionResult KullaniciEtkinlikDuzenle(OrganizeKullanici model)
		{
			OrganizeKullanici organizeKullanici = etkinliklerBLL.GetOrganizeKullanici(model.OrganizeKatilimciID);
			organizeKullanici.KatılımcıSayisi = model.KatılımcıSayisi;
			organizeKullanici.KayitTarihi = DateTime.Now;

			etkinliklerBLL.OrganizeKullaniciUpdate(organizeKullanici);
			return RedirectToAction("Etkinliklerim");
		}
		public ActionResult KullaniciEtkinlikSil(int id)
		{
			OrganizeKullanici ok = etkinliklerBLL.GetOrganizeKullanici(id);
			etkinliklerBLL.OrganizeKullaniciDelete(ok);
			return RedirectToAction("Etkinliklerim","Etkinlik");
		}
		public ActionResult EtkinlikEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult EtkinlikEkle(Organizeler org,HttpPostedFileBase OrganizeResmi)
		{
			Kullanicilar kullanicilar = Session["kullanici"] as Kullanicilar;
			if (ModelState.IsValid)
			{
				if (OrganizeResmi != null)
				{
					WebImage img = new WebImage(OrganizeResmi.InputStream);
					FileInfo fotoinfo = new FileInfo(OrganizeResmi.FileName);

					string newfoto = Guid.NewGuid().ToString() + fotoinfo.Extension;
					img.Save("~/Content/images/" + newfoto);
					org.OrganizeResmi = "/Content/images/" + newfoto;

				}

				org.OrganizatorID = kullanicilar.KullaniciID;
				etkinliklerBLL.AddOrganize(org);
				return RedirectToAction("Etkinlikler", "Etkinlik");
			}
			
			return RedirectToAction("Etkinlikler", "Etkinlik");
	
		}
		
		[HttpPost]
		public ActionResult EtkinligeKatil(OrganizeKatilimModel model)
		{
			Kullanicilar kul = Session["kullanici"] as Kullanicilar;
			
			List<OrganizeKullanici> organizeler = etkinliklerBLL.GetMyOrganizes(kul.KullaniciID);
			
			foreach (var item in organizeler)
			{
				if(kul.KullaniciID==item.KatilimciID && model.organizeler.OrganizeID == item.OrganizeID)
				{
					return RedirectToAction("Etkinliklerim");
				}
			}
			OrganizeKullanici ork = new OrganizeKullanici();
			ork.KatilimciID = kul.KullaniciID;
			ork.OrganizeID = model.organizeler.OrganizeID;
			ork.KatılımcıSayisi = model.KatilimciSayisi;
			ork.KayitTarihi = DateTime.Now;
			etkinliklerBLL.EtkinligeKatil(ork);
			return RedirectToAction("Detay", new { id = model.organizeler.OrganizeID });
		}

		public ActionResult MesajGonder() {
			return View();
		}

        [HttpPost]
		public ActionResult MesajGonder(int id)
		{
			return View();
		}

	}
}