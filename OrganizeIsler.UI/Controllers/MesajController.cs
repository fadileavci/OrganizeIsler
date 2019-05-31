using OrganizeIsler.BLL;
using OrganizeIsler.Entity;
using OrganizeIsler.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizeIsler.UI.Controllers
{
    public class MesajController : Controller
    {
		MesajlarBLL mesajbll = new MesajlarBLL();
		EtkinliklerBLL etkinlikbll = new EtkinliklerBLL();

		public ActionResult MesajlarimiListele()
		{
			Kullanicilar kul = Session["kullanici"] as Kullanicilar;
			List<Mesaj> mesaj = mesajbll.MesajlariListele(kul.KullaniciID);
			return View(mesaj);
		}

		public ActionResult MesajGonder()
		{
			return View();
		}

		[HttpPost]
		public ActionResult MesajGonder(OrganizeKatilimModel okm)
		{
			Organizeler organizeler = etkinlikbll.GetOrganizeDetay(okm.organizeler.OrganizeID);
			Kullanicilar kul = Session["kullanici"] as Kullanicilar;
			
		
			Mesaj msj = new Mesaj();
			msj.MesajiGonderenID = kul.KullaniciID;
			msj.MesajiAlanID = organizeler.OrganizatorID;
			msj.Mesaj1 = okm.MesajIcerik;
			mesajbll.MesajGonder(msj);
			return RedirectToAction("MesajlarimiListele");

		}

		public ActionResult GidenMesajlar()
		{
			Kullanicilar kul = Session["kullanici"] as Kullanicilar;
			List<Mesaj> mesaj = mesajbll.GonderdigimMesajlar(kul.KullaniciID);
			return View(mesaj);
		}


	}
}