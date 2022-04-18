using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class KullaniciController : ApiController
    {
        satisEntities _ent = new satisEntities();
        [HttpGet]
        public List<KullaniciTip> TumKullanicilariGetir()
        {
            return _ent.Kullanici.Where(p => p.SilindiMi == false).Select(p => new KullaniciTip()
            {
                KullaniciID = p.KullaniciID,
                AdSoyad = p.AdSoyad
            }).ToList();
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
                return TumKullanicilariGetir();
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpGet]
        public List<KullaniciTip> KullaniciSil(int kullaniciid)
        {
            // kullanıcı silme işlemi silindi mi alanını true yaparak gerçekleştirildi
            _ent.Kullanici.Find(kullaniciid).SilindiMi = true;
            _ent.SaveChanges();
            return TumKullanicilariGetir();
        }
        [HttpGet]
        public List<KullaniciTip> KullaniciGuncelle(int guncellenecekid, string yeniadsoyad)
        {
            try
            {
                _ent.Kullanici.Find(guncellenecekid).AdSoyad = yeniadsoyad;
                _ent.SaveChanges();
                return TumKullanicilariGetir();
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
    }
}