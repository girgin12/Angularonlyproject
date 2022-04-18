using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Satisprogram.Controllers
{
    public class UrunController:ApiController
    {
        satisEntities _ent = new satisEntities();
        [HttpGet]
        public List<UrunTip> TumurunleriGetir()
        {
           return  _ent.Urun.Select(p=> new UrunTip() { 
           
               UrunID=p.UrunID,
               StokAdedi=p.StokAdedi,
               UrunAdi=p.UrunAdi,
               UrunFiyat=p.UrunFiyat,
               UrunMarkasi=p.UrunMarkasi
            
            
            }).ToList();
        }
        [HttpPost]
         public Boolean Urunekle(UrunTip yeniurun)
        {

            try
            {
                Urun u = new Urun();
                u.StokAdedi = yeniurun.StokAdedi;
                u.UrunAdi = yeniurun.UrunAdi;
                u.UrunFiyat = yeniurun.UrunFiyat;
                u.UrunMarkasi = yeniurun.UrunMarkasi;

                _ent.Urun.Add(u);
                _ent.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public class UrunTip
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunMarkasi { get; set; }
        public double UrunFiyat { get; set; }
        public int StokAdedi { get; set; }
    }
}