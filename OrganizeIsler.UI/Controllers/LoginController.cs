using OrganizeIsler.BLL;
using OrganizeIsler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizeIsler.UI.Controllers
{
    public class LoginController : Controller
    {

		KullanicilarBLL kullanicilarbll = new KullanicilarBLL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(Kullanicilar  kullanicilar)
		{
	
			Kullanicilar kul = kullanicilarbll.KullaniciGiris(kullanicilar.Email);
			if (kul.Sifre == kullanicilar.Sifre )
			{
				Session["kullanici"] = kul;
				return RedirectToAction("Index", "Home");
			}
			else
				return RedirectToAction("Hata");

		}


		public ActionResult Logout()
		{
			Session.Abandon();
			return RedirectToAction("Index");
		}


		public ActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public ActionResult SignUp(Kullanicilar kul)
		{
			kullanicilarbll.KullaniciEkle(kul);
			Session["kullanici"] = kul;
			return RedirectToAction("Etkinlikler","Etkinlik");
		}

	}


}