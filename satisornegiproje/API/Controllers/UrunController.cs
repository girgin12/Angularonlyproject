using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class UrunController : ApiController
    {
        satisEntities _ent = new satisEntities();
        [HttpGet]
        public List<UrunTip> TumUrunleriGetir()
        {
            return _ent.Urun.Select(p => new UrunTip()
            {
                UrunID = p.UrunID,
                StokAdedi = p.StokAdedi,
                UrunAdi = p.UrunAdi,
                UrunFiyat = p.UrunFiyat,
                UrunMarkasi = p.UrunMarkasi
            }).ToList();
        }

        [HttpPost]
        public List<UrunTip> UrunGuncelle(UrunTip guncellenecekveri)
        {
            try
            {
                Urun u = _ent.Urun.Find(guncellenecekveri.UrunID);
                u.StokAdedi = guncellenecekveri.StokAdedi;
                u.UrunAdi = guncellenecekveri.UrunAdi;
                u.UrunFiyat = guncellenecekveri.UrunFiyat;
                u.UrunMarkasi = guncellenecekveri.UrunMarkasi;
                _ent.SaveChanges();
                return TumUrunleriGetir();
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        public Boolean UrunEkle(UrunTip yeniurun)
        {
            try
            {
                Urun u = new Urun();
                u.StokAdedi = yeniurun.StokAdedi;
                u.UrunAdi = yeniurun.UrunAdi;
                u.UrunFiyat = yeniurun.UrunFiyat;
                u.UrunMarkasi = yeniurun.UrunMarkasi;
                /*
                Urun yu = new Urun()
                {
                    StokAdedi = yeniurun.StokAdedi,
                    UrunAdi = yeniurun.UrunAdi,
                    UrunFiyat = yeniurun.UrunFiyat,
                    UrunMarkasi = yeniurun.UrunMarkasi
                };*/
                _ent.Urun.Add(u);
                _ent.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet]
        public List<UrunTip> UrunSil(int UrunID)
        {
            // ürün silme aşamasında ürün ile ilgili satışlar temizlenip ürün silinecek
            /*List<Satis> silineceksatislar = _ent.Satis.Where(p => p.UrunID == UrunID).ToList();
            _ent.Satis.RemoveRange(silineceksatislar);
            _ent.SaveChanges();
            Urun u = _ent.Urun.Find(UrunID);
            _ent.Urun.Remove(u);
            _ent.SaveChanges();*/
            try
            {
                _ent.Satis.RemoveRange(_ent.Satis.Where(p => p.UrunID == UrunID));
                _ent.SaveChanges();
                _ent.Urun.Remove(_ent.Urun.Find(UrunID));
                _ent.SaveChanges();
                return TumUrunleriGetir();
            }
            catch (Exception)
            {
                return null;
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