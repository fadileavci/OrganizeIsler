using OrganizeIsler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizeIsler.UI.Models
{
	public class OrganizeKatilimModel
	{
		public Organizeler organizeler { get; set; }

		public int KatilimciSayisi { get; set; }

		public Mesaj mesajlar { get; set; }

		public string MesajIcerik { get; set; }
	}
}