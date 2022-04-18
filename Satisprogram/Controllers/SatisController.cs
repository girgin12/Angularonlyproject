using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Satisprogram.Controllers
{
    public class SatisController:ApiController
    {
        satisEntities muhammetburak = new satisEntities();
        [HttpGet]
        public List<SatisTip> Tumsatislarigetir()
        {
             return muhammetburak.Satis.Select(p=> new SatisTip() { 

                SatisID=p.SatisID,
                SatisAdedi=p.SatisAdedi,
                KullaniciID=p.KullaniciID,
                SatisZamani=p.SatisZamani,
                ToplamTutar=p.ToplamTutar,
                UrunID=p.UrunID,
                KullaniciAdi=p.Kullanici.AdSoyad,
                UrunAdi=p.Urun.UrunAdi


            }).ToList();
        }
        [HttpPost]
        public List<SatisTip> Satisekle(SatisTip satisverisi)
            
        {
            try
            {
                Satis s = new Satis();
                s.KullaniciID = satisverisi.KullaniciID;
                s.SatisAdedi = satisverisi.SatisAdedi;
                s.SatisZamani = DateTime.Now;
                s.ToplamTutar = satisverisi.ToplamTutar;
                s.UrunID = satisverisi.UrunID;
                muhammetburak.Satis.Add(s);
                muhammetburak.SaveChanges();
                return Tumsatislarigetir();
            }
            catch (Exception)
            {

                return null;
            }
        }
    }

    public class SatisTip
    {
        public int SatisID { get; set; }
        public int KullaniciID { get; set; }
        public int UrunID { get; set; }
        public int SatisAdedi { get; set; }
        public double ToplamTutar { get; set; }
        public System.DateTime SatisZamani { get; set; }
        // sonradan eklenen alanlar
        public string KullaniciAdi { get; set; }
        public string UrunAdi { get; set; }
    }
}