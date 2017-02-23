using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KhufuMobile.Business;
using Microsoft.EntityFrameworkCore;
using KhufuMobile.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using KhufuMobile.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace KhufuMobile.Controllers
{
    [Authorize]
    public class NumuneController : Controller
    {
        [Route("NumuneAlimFisiList/{name?}")]
        public IActionResult NumuneAlimFisiList(string name)
        {
            switch (name)
            {
                case "HAVUZSUYUOZEL":
                    name = "H.SUYU ÖZEL";
                    break;
                case "KIMYASAL":
                    name = "KİMYASAL";
                    break;
                case "SUOZEL":
                    name = "SU ÖZEL";
                    break;
                case "LEGIONELLA":
                    name = "LEGİONELLA";
                    break;
            }
            var numuneTipi = (from p in AppManager.Db.NumuneAlimTipi where p.Kod == name select p).FirstOrDefault();
            var list = (from p in AppManager.Db.NumuneAlimFisi
                        join nt in AppManager.Db.NumuneAlimTipi on p.NumuneAlimTipiId equals nt.Id
                        join na in AppManager.Db.Personel on p.NumuneyiAlanId equals na.Id
                        join kurum in AppManager.Db.Kurum on p.KurumId equals kurum.Id
                        where nt.Kod == name
                        select new
                        {
                            fis = p,
                            nt = nt,
                            na = na,
                            k = kurum,
                            nSelect = false
                        }).ToList();
            List<Models.NumuneAlimFisi> retList = new List<Models.NumuneAlimFisi>();
            foreach (var item in list)
            {
                item.fis.NumuneAlimTipi = item.nt;
                item.fis.NumuneyiAlan = item.na;
                item.fis.Kurum = item.k;
                retList.Add(item.fis);
            }
            NumuneListModel model = new NumuneListModel();
            model.Tipi = numuneTipi;
            model.List = retList;
            return View("NumuneAlimFisiList", model);
        }

        [HttpGet]
        [Route("NumuneAlimFisi/Create/{operation?}")]
        [Route("NumuneAlimFisi/Create/{operation?}/{id?}")]
        public IActionResult Create(string operation, string id)
        {
            NumuneAlimFisiModel model = new NumuneAlimFisiModel();
            Guid gId = new Guid(id);
            model.Numune = new NumuneAlimFisi();
            model.Numune.NumuneAlimTipi = (from p in AppManager.Db.NumuneAlimTipi where p.Id.CompareTo(gId) > 0 select p).FirstOrDefault();
            model.Numune.NumuneAlimTipiId = model.Numune.NumuneAlimTipi.Id;
            return View("Create", model);
        }

        [HttpPost]
        [Route("NumuneAlimFisi/Create/{operation?}")]
        [Route("NumuneAlimFisi/Create/{operation?}/{id?}")]
        public IActionResult Create(NumuneAlimFisiModel alimFisi, string operation, string id)
        {
            if (!ModelState.IsValid)
                return View(alimFisi);
            else
                try
                {

                    if (alimFisi.Numune.Tarih == DateTime.MinValue)
                    {
                        ModelState.AddModelError("", "Lütfren Tarih giriniz.");
                        return View(alimFisi);
                    }
                    Guid gId = new Guid(id);
                    NumuneAlimTipi tip = (from p in AppManager.Db.NumuneAlimTipi where p.Id == gId  select p).FirstOrDefault();
                    alimFisi.Numune.NumuneAlimTipi = tip;
                    alimFisi.Numune.NumuneAlimTipiId = gId;
                    alimFisi.Numune.Id = Guid.NewGuid();
                    alimFisi.Numune.RaporNoBaslik = tip.RaporNoBaslik;
                    // eğer elle fis no girilmemişse
                    if (alimFisi.Numune.No == 0)
                    {
                        tip.SonRaporNo++;
                        alimFisi.Numune.No = tip.SonRaporNo;
                    }
                    alimFisi.Numune.RaporNo = alimFisi.Numune.RaporNoBaslik + "-" + alimFisi.Numune.Tarih.Year.ToString().Substring(2, 2) + "-" + alimFisi.Numune.No.ToString().PadLeft(4, '0');
                    if (AppManager.Db.NumuneAlimFisi.Count(x => x.RaporNo == alimFisi.Numune.RaporNo && x.NumuneAlimTipiId == alimFisi.Numune.NumuneAlimTipi.Id) > 0)
                    {
                        ModelState.AddModelError("", alimFisi.Numune.NumuneAlimTipi.Kod + " için " + alimFisi.Numune.RaporNo + " nolu Numune Alım Fişi Zaten Kayıtlı!");
                    }
                    if (alimFisi.Numune.No > alimFisi.Numune.NumuneAlimTipi.SonRaporNo)
                        alimFisi.Numune.NumuneAlimTipi.SonRaporNo = alimFisi.Numune.No;
                    alimFisi.Numune.EklemeTarihi = DateTime.Now;
                    alimFisi.Numune.EkleyenId = AppManager.Personel.Id;

                    AppManager.Db.NumuneAlimFisi.Add(alimFisi.Numune);
                    AppManager.Db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
            string name = alimFisi.Numune.NumuneAlimTipi.Kod;
            switch (name)
            {
                case "H.SUYU ÖZEL":
                    name = "HAVUZSUYUOZEL";
                    break;
                case "KİMYASAL":
                    name = "KIMYASAL";
                    break;
                case "SU ÖZEL":
                    name = "SUOZEL";
                    break;
                case "LEGİONELLA":
                    name = "LEGIONELLA";
                    break;
            }
            return RedirectToAction("NumuneAlimFisiList", new RouteValueDictionary(
                 new { controller = "Numune", action = "NumuneList", name = name }));
        }


        [HttpGet]
        [Route("NumuneAlimFisi/Edit/{id?}")]
        public IActionResult Edit(string id)
        {
            NumuneAlimFisiModel model = new NumuneAlimFisiModel();
            Guid gId = new Guid(id);
            model.Numune = (from p in AppManager.Db.NumuneAlimFisi where p.Id == gId select p).FirstOrDefault();
            //model.Numune.NumuneAlimTipi = (from p in AppManager.Db.NumuneAlimTipi where p.Id.CompareTo(model.Numune.NumuneAlimTipiId) > 0 select p).FirstOrDefault();
            //model.Numune.NumuneAlimTipiId = model.Numune.NumuneAlimTipi.Id;
            return View("Edit", model);
        }

        [HttpPost]
        [Route("NumuneAlimFisi/Edit/{id?}")]
        public IActionResult Edit(NumuneAlimFisiModel alimFisi, string id)
        {
            NumuneAlimFisi numune = null;
            Guid gId = new Guid(id);

            if (!ModelState.IsValid)
                return View(alimFisi);
            else
                try
                {
                    numune = AppManager.Db.NumuneAlimFisi.Where(_ => _.Id ==gId).FirstOrDefault();
                    numune.NumuneyiAlanId = alimFisi.Numune.NumuneyiAlanId;
                    numune.KurumId = alimFisi.Numune.KurumId;
                    numune.AnalizAmaci = alimFisi.Numune.AnalizAmaci;
                    numune.Tarih = alimFisi.Numune.Tarih;
                    numune.LaboratuvaraUlasmaTarihi = alimFisi.Numune.LaboratuvaraUlasmaTarihi;
                    AppManager.Db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
                }

            string name = numune.NumuneAlimTipi.Kod;

            switch (name)
            {
                case "H.SUYU ÖZEL":
                    name = "HAVUZSUYUOZEL";
                    break;
                case "KİMYASAL":
                    name = "KIMYASAL";
                    break;
                case "SU ÖZEL":
                    name = "SUOZEL";
                    break;
                case "LEGİONELLA":
                    name = "LEGIONELLA";
                    break;
            }
            return RedirectToAction("NumuneAlimFisiList", new RouteValueDictionary(
                 new { controller = "Numune", action = "NumuneList", name = name }));
        }

        [HttpGet]
        [Route("NumuneAlimFisi/Delete/{id?}")]
        public IActionResult Delete(string id)
        {
            Guid gId = new Guid(id);
            var numunefisi = AppManager.Db.NumuneAlimFisi.Where(_ => _.Id == gId).FirstOrDefault();
            string tipKod = numunefisi.NumuneAlimTipi.Kod;
            switch (tipKod)
            {
                case "H.SUYU ÖZEL":
                    tipKod = "HAVUZSUYUOZEL";
                    break;
                case "KİMYASAL":
                    tipKod = "KIMYASAL";
                    break;
                case "SU ÖZEL":
                    tipKod = "SUOZEL";
                    break;
                case "LEGİONELLA":
                    tipKod = "LEGIONELLA";
                    break;
            }
            AppManager.Db.NumuneAlimFisi.Remove(numunefisi);
            AppManager.Db.SaveChanges();
            return RedirectToAction("NumuneAlimFisiList", new RouteValueDictionary(
                   new { controller = "Numune", action = "NumuneList", name = tipKod }));
        }
    }
}
