using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhufuMobile.Models.ViewModels;
using KhufuMobile.Business;
using Microsoft.AspNetCore.Authorization;
using KhufuMobile.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;

namespace KhufuMobile.Controllers
{
    //[Authorize]
    public class NumuneAlimController : Controller
    {

        #region NumuenAlimCreate
        [HttpGet]
        [Route("NumuneAlim/Create/{numuneId?}")]
        public IActionResult Create(string numuneId)
        {
            Guid nId = new Guid(numuneId);
            NumuneAlimFisi fis = (from p in AppManager.Db.NumuneAlimFisi where p.Id == nId select p).FirstOrDefault();
            NumuneAlimModel numuneAlim = new NumuneAlimModel();
            numuneAlim.NumuneFisiId = numuneId;
            numuneAlim.NumuneTipleri = (from p in AppManager.Db.NumuneTipi where p.NumuneAlimTipiId == fis.NumuneAlimTipiId select p).ToList();
            numuneAlim.Tipler = (from p in AppManager.Db.NumuneTipi
                                 where p.NumuneAlimTipiId == fis.NumuneAlimTipiId
                                 select new SelectListItem
                                 {
                                     Value = Convert.ToString(p.Id),
                                     Text = p.Kod
                                 }).ToList();
            numuneAlim.Kodeksler = (from p in AppManager.Db.Kodeks orderby p.SiraNo, p.Kod, p.Aciklama select p).ToList();
            numuneAlim.KodeksListe = (from p in numuneAlim.Kodeksler
                                      select new SelectListItem
                                      {
                                          Value = Convert.ToString(p.Id),
                                          Text = p.Kod
                                      }).ToList();

            var x = (from p in numuneAlim.NumuneTipleri
                     select new
                     {
                         id = p.Id,
                         onDegerMiktar = p.OnDegerMiktar,
                         onDegerBirim = p.OnDegerBirim,
                         ondegerSicaklik = p.OndegerSicaklik,
                         onDegerAmbalaji = p.OnDegerAmbalaji,
                         onDegerSeriPartiNo = p.OnDegerSeriPartiNo,
                         onDegerUreticiFirmaAdi = p.OnDegerUreticiFirmaAdi,
                         onDegerUretimSKTarihi = p.OnDegerUretimSktarihi,
                         onDegerKabinCinsi = p.OnDegerKabinCinsi,
                         onDegerAlinmaSekli = p.OnDegerAlinmaSekli
                     }
                    );
            numuneAlim.JsonNumuneTipleri = JsonConvert.SerializeObject(x);
            return View("Create", numuneAlim);
        }

        [HttpPost]
        [Route("NumuneAlim/Create/{numuneId?}")]
        public IActionResult Create(NumuneAlimModel numuneAlim, string numuneId)
        {
            Guid fId = new Guid(numuneId);
            var fis = AppManager.Db.NumuneAlimFisi.Where(_ => _.Id == fId).FirstOrDefault();
            NumuneAlim newRecord = new NumuneAlim()
            {
                Id = Guid.NewGuid(),
                Aciklama = numuneAlim.Aciklama,
                AlimYeri = numuneAlim.AlimYeri,
                BaslamaTarihi = numuneAlim.BasTarih,
                BitisTarihi = numuneAlim.BitTarih,
                BakanlikRaporNo = numuneAlim.BkRNo,
                KayitNo = numuneAlim.KayitNo,
                NumuneTipiId = new Guid(numuneAlim.NumuneTipi),
                KodeksId = new Guid(numuneAlim.KodeksId),
                NumuneAdi = numuneAlim.NumuneAdi,
                Miktar = numuneAlim.Miktar,
                Birim = numuneAlim.Birim,
                Sicaklik = numuneAlim.Sicaklik,
                IstenenAnalizler = numuneAlim.IstAnalizler,
                WebdeGoster = numuneAlim.WebGoster
            };
            newRecord.EkleyenId = AppManager.Personel.Id;
            newRecord.NumuneAlimFisId = fis.Id;
            newRecord.Olumlu = true;

            if (AppManager.Parametre.FisBaslamaBitisTarihiKullan)
                newRecord.BaslamaTarihi = fis.BaslamaTarihi;
            else
                newRecord.BaslamaTarihi = fis.Tarih;
            var siraNo = AppManager.Db.NumuneAlim.Where(_ => _.NumuneAlimFisId == fId).Count();
            newRecord.SiraNo = siraNo + 1;

            AppManager.Db.NumuneAlim.Add(newRecord);
            AppManager.Db.SaveChanges();
            if (fis.NumuneAlimTipi.Tip == Convert.ToInt32(AppManager.EnumNumuneAlimTipi.Gıda))
            {
                NumuneGida gida = new NumuneGida()
                {
                    NumuneAlimId = newRecord.Id,
                    Ambalaji = numuneAlim.Ambalaji,
                    Cinsi = numuneAlim.Cinsi,
                    SeriPartiNo = numuneAlim.SeriPartNo,
                    UretimTarihi = numuneAlim.UretimTarihi,
                    SonKullanimTarihi = numuneAlim.SonKulTarihi,
                    UretimSktarihi = numuneAlim.UretimSkTarihi,
                    UreticiFirmaAdi = numuneAlim.UreticiFirmaAdi
                };
                AppManager.Db.NumuneGida.Add(gida);
            }
            else
            {
                NumuneHavuzSuyu hSuyu = new NumuneHavuzSuyu();
            }
            AppManager.Db.SaveChanges();
            return RedirectToAction("NumuneAlimList", new RouteValueDictionary(
             new { controller = "NumuneAlim", action = "NumuneAlimList", numuneFisiId = numuneId }));
        }

        [HttpGet]
        [Route("NumuneAlim/Tipler/{numuneId?}")]
        public IActionResult Tipler(string numuneId)
        {
            Guid fId = new Guid(numuneId);
            var fis = AppManager.Db.NumuneAlimFisi.Where(_ => _.Id == fId).FirstOrDefault();
            var NumuneTipleri = (from p in AppManager.Db.NumuneTipi where p.NumuneAlimTipiId == fis.NumuneAlimTipiId select p).ToList();
            return new ObjectResult(NumuneTipleri);
        }

        #endregion
        #region NumuenAlimEdit
        [HttpGet]
        [Route("NumuneAlim/Delete/{numuneAlimId?}")]
        public IActionResult Delete(string numuneAlimId)
        {
            Guid gId = new Guid(numuneAlimId);
            var numuneAlim = (from p in AppManager.Db.NumuneAlim where p.Id == gId select p).FirstOrDefault();
            AppManager.Db.NumuneAlim.Remove(numuneAlim);
            AppManager.Db.SaveChanges();
            return RedirectToAction("NumuneAlimList", new RouteValueDictionary(
                 new { controller = "NumuneAlim", action = "NumuneAlimList", numuneFisiId = numuneAlim.NumuneAlimFis.Id }));
        }

        [HttpGet]
        [Route("NumuneAlim/Edit/{numuneAlimId?}")]
        public IActionResult Edit(string numuneAlimId)
        {
            Guid nId = new Guid(numuneAlimId);
            NumuneAlim nAlim = (from p in AppManager.Db.NumuneAlim where p.Id == nId select p).FirstOrDefault();
            NumuneAlimModel nAlimModel = new NumuneAlimModel()
            {
                Id = Convert.ToString(nAlim.Id),
                Aciklama = nAlim.Aciklama,
                AlimYeri = nAlim.AlimYeri,
                BasTarih = nAlim.BaslamaTarihi,
                BitTarih = nAlim.BitisTarihi,
                BkRNo = nAlim.BakanlikRaporNo,
                KayitNo = nAlim.KayitNo,
                NumuneTipi = Convert.ToString(nAlim.NumuneTipiId),
                KodeksId = Convert.ToString(nAlim.KodeksId),
                NumuneAdi = nAlim.NumuneAdi,
                Miktar = nAlim.Miktar,
                Birim = nAlim.Birim,
                Sicaklik = nAlim.Sicaklik,
                IstAnalizler = nAlim.IstenenAnalizler,
                WebGoster = nAlim.WebdeGoster,
                SiraNo = nAlim.SiraNo,
                NumuneFisiId = Convert.ToString(nAlim.NumuneAlimFis.Id)
            };
            nAlimModel.NumuneTipleri = (from p in AppManager.Db.NumuneTipi where p.NumuneAlimTipiId == nAlim.NumuneAlimFis.NumuneAlimTipiId select p).ToList();
            nAlimModel.Tipler = (from p in AppManager.Db.NumuneTipi
                                 where p.NumuneAlimTipiId == nAlim.NumuneAlimFis.NumuneAlimTipiId
                                 select new SelectListItem
                                 {
                                     Value = Convert.ToString(p.Id),
                                     Text = p.Kod
                                 }).ToList();
            nAlimModel.Kodeksler = (from p in AppManager.Db.Kodeks orderby p.SiraNo, p.Kod, p.Aciklama select p).ToList();
            nAlimModel.KodeksListe = (from p in nAlimModel.Kodeksler
                                      select new SelectListItem
                                      {
                                          Value = Convert.ToString(p.Id),
                                          Text = p.Kod
                                      }).ToList();

            var x = (from p in nAlimModel.NumuneTipleri
                     select new
                     {
                         id = p.Id,
                         onDegerMiktar = p.OnDegerMiktar,
                         onDegerBirim = p.OnDegerBirim,
                         ondegerSicaklik = p.OndegerSicaklik,
                         onDegerAmbalaji = p.OnDegerAmbalaji,
                         onDegerSeriPartiNo = p.OnDegerSeriPartiNo,
                         onDegerUreticiFirmaAdi = p.OnDegerUreticiFirmaAdi,
                         onDegerUretimSKTarihi = p.OnDegerUretimSktarihi,
                         onDegerKabinCinsi = p.OnDegerKabinCinsi,
                         onDegerAlinmaSekli = p.OnDegerAlinmaSekli
                     }
                    );
            //gida yada havuz suyu verilerini al 
            if (nAlim.NumuneAlimFis.NumuneAlimTipi.Tip == Convert.ToInt32(AppManager.EnumNumuneAlimTipi.Gıda))
            {
                NumuneGida gida = (from p in AppManager.Db.NumuneGida where p.NumuneAlimId == nAlim.Id select p).FirstOrDefault();
                nAlimModel.Ambalaji = gida.Ambalaji;
                nAlimModel.Cinsi = gida.Cinsi;
                nAlimModel.SeriPartNo = gida.SeriPartiNo;
                nAlimModel.UretimTarihi = gida.UretimTarihi;
                nAlimModel.SonKulTarihi = gida.SonKullanimTarihi;
                nAlimModel.UretimSkTarihi = gida.UretimSktarihi;
                nAlimModel.UreticiFirmaAdi = gida.UreticiFirmaAdi;
            }
            else
            {
                NumuneHavuzSuyu hSuyu = new NumuneHavuzSuyu();
            }

            return View("Edit", nAlimModel);
        }

        [HttpPost]
        [Route("NumuneAlim/Edit/{numuneAlimId?}")]
        public IActionResult Edit(NumuneAlimModel numuneAlim, string numuneAlimId)
        {
            Guid gId = new Guid(numuneAlimId);
            NumuneAlim nAlim = (from p in AppManager.Db.NumuneAlim where p.Id == gId select p).FirstOrDefault();


            nAlim.Aciklama = numuneAlim.Aciklama;
            nAlim.AlimYeri = numuneAlim.AlimYeri;
            nAlim.BaslamaTarihi = numuneAlim.BasTarih;
            nAlim.BitisTarihi = numuneAlim.BitTarih;
            nAlim.BakanlikRaporNo = numuneAlim.BkRNo;
            nAlim.KayitNo = numuneAlim.KayitNo;
            nAlim.KodeksId = new Guid(numuneAlim.KodeksId);
            nAlim.NumuneAdi = numuneAlim.NumuneAdi;
            nAlim.Miktar = numuneAlim.Miktar;
            nAlim.Birim = numuneAlim.Birim;
            nAlim.Sicaklik = numuneAlim.Sicaklik;
            nAlim.IstenenAnalizler = numuneAlim.IstAnalizler;
            nAlim.WebdeGoster = numuneAlim.WebGoster;
            if (nAlim.NumuneAlimFis.NumuneAlimTipi.Tip == Convert.ToInt32(AppManager.EnumNumuneAlimTipi.Gıda))
            {
                NumuneGida gida = (from p in AppManager.Db.NumuneGida where p.NumuneAlimId == nAlim.Id select p).FirstOrDefault();
                gida.Ambalaji = numuneAlim.Ambalaji;
                gida.Cinsi = numuneAlim.Cinsi;
                gida.SeriPartiNo = numuneAlim.SeriPartNo;
                gida.UretimTarihi = numuneAlim.UretimTarihi;
                gida.SonKullanimTarihi = numuneAlim.SonKulTarihi;
                gida.UretimSktarihi = numuneAlim.UretimSkTarihi;
                gida.UreticiFirmaAdi = numuneAlim.UreticiFirmaAdi;
                AppManager.Db.SaveChanges();
            }
            else
            {
                NumuneHavuzSuyu hSuyu = (from p in AppManager.Db.NumuneHavuzSuyu where p.NumuneAlimId == nAlim.Id select p).FirstOrDefault();
                AppManager.Db.SaveChanges();
            }
            return RedirectToAction("NumuneAlimList", new RouteValueDictionary(
             new { controller = "NumuneAlim", action = "NumuneAlimList", numuneFisiId = numuneAlimId }));
        }
        #endregion
        [HttpGet]
        [Route("NumuneAlim/AnalizSonucList/{numuneId?}")]
        public IActionResult AnalizSonucList(string numuneId)
        {
            NumuneModel model = new NumuneModel();
            model.Id = numuneId;
            return View("AnalizSonucList", model);
        }

        [HttpGet]
        [Route("NumuneAlim/NumuneAlimList/{numuneFisiId?}")]
        public IActionResult NumuneAlimList(string numuneFisiId)
        {
            Guid fisId = new Guid(numuneFisiId);
            var retList = (from p in AppManager.Db.NumuneAlimFisi
                           join r in AppManager.Db.NumuneAlim on p.Id equals r.NumuneAlimFisId
                           where p.Id == fisId
                           select new NumuneAlimModel
                           {
                               Id = Convert.ToString(r.Id),
                               Aciklama = r.Aciklama,
                               AlimYeri = r.AlimYeri,
                               BasTarih = r.BaslamaTarihi,
                               BitTarih = r.BitisTarihi,
                               BkRNo = r.BakanlikRaporNo,
                               KayitNo = r.KayitNo,
                               NumuneTipi = r.NumuneTipi.Kod,
                               Kodeks = r.Kodeks.Kod,
                               NumuneAdi = r.NumuneAdi,
                               Miktar = r.Miktar,
                               //Cinsi=r.Cinsi,
                               //Ambalaji=r.Ambalaji
                           }
                        ).ToList();

            NumuneAlimListModel model = new NumuneAlimListModel();
            model.List = retList;
            model.NumuneAlimFisiId = numuneFisiId;

            return View("NumuneAlimList", model);
        }
    }
}
