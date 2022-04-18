using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Satisprogram.Controllers
{
    public class KullaniciController:ApiController
    {
        satisEntities _ent = new satisEntities();
        [HttpGet]
        public List<KullaniciTip> Tumkullanicilarigetir()
        {
            return  _ent.Kullanici.Select(p => new KullaniciTip() { 
            
              KullaniciID = p.KullaniciID,
              AdSoyad=p.AdSoyad
              
            }). ToList();

            
        }
        [HttpGet]
        public List<KullaniciTip> KullaniciEkle(string adsoyad)
        {
            try
            {
                Kullanici k = new Kullanici();
                k.AdSoyad = adsoyad;
                _ent.Kullanici.Add(k);
                _ent.SaveChanges();
                return Tumkullanicilarigetir();
            }
            catch (Exception)
            {

                return null;
            }
        }

    }

    public class KullaniciTip
    {
        public int KullaniciID { get; set; }
        public string AdSoyad { get; set; }
        public bool SilindiMi { get; set; }

    }
}