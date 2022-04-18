using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class SatisController : ApiController
    {
        satisEntities muhammetburak = new satisEntities();
        [HttpGet]
        public List<SatisTip> TumSatislariGetir()
        {
            return muhammetburak.Satis.Select(p => new SatisTip()
            {
                SatisID = p.SatisID,
                SatisAdedi = p.SatisAdedi,
                KullaniciID = p.KullaniciID,
                SatisZamani = p.SatisZamani,
                ToplamTutar = p.ToplamTutar,
                UrunID = p.UrunID,
                KullaniciAdi = p.Kullanici.AdSoyad,
                UrunAdi = p.Urun.UrunAdi
            }).ToList();
        }
        [HttpPost]
        public List<SatisTip> SatisEkle(SatisTip satisverisi)
        {
            try
            {
                // ürün id ile ürün bulunup fiyat bilgisine ulaşıyoruz
                Urun secilenurun = muhammetburak.Urun.Find(satisverisi.UrunID);
                if (satisverisi.SatisAdedi > secilenurun.StokAdedi)
                    satisverisi.SatisAdedi = secilenurun.StokAdedi;
                Satis s = new Satis();
                s.KullaniciID = satisverisi.KullaniciID;
                s.SatisAdedi = satisverisi.SatisAdedi;
                //satış zamanı boş da geçilebilir
                s.SatisZamani = DateTime.Now;
                s.ToplamTutar = satisverisi.SatisAdedi * secilenurun.UrunFiyat;
                s.UrunID = satisverisi.UrunID;
                muhammetburak.Satis.Add(s);
                muhammetburak.SaveChanges();
                secilenurun.StokAdedi = secilenurun.StokAdedi - satisverisi.SatisAdedi;
                //secilenurun.StokAdedi -= satisverisi.SatisAdedi;
                muhammetburak.SaveChanges();
                return TumSatislariGetir();
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpGet]
        public List<SatisTip> SatisSil(int SatisID)
        {
            try
            {
                Satis silineceksatis = muhammetburak.Satis.Find(SatisID);
                muhammetburak.Urun.Find(silineceksatis.UrunID).StokAdedi += silineceksatis.SatisAdedi;
                muhammetburak.Satis.Remove(silineceksatis);
                muhammetburak.SaveChanges();
                return TumSatislariGetir();
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
        //sonradan eklenen alanlar
        public string KullaniciAdi { get; set; }
        public string UrunAdi { get; set; }
    }
}