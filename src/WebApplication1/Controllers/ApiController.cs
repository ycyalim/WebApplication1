using KhufuMobile.Business;
using KhufuMobile.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KhufuMobile.Controllers
{

    [Authorize]
    public class ApiController : Controller
    {

        public struct Result
        {
            public object analizler { get; set; }
            public object sonuclar { get; set; }
            public string numuneId { get; set; }
        }

        [Route("api/SaveAnaliz")]
        [HttpPost]
        public string SaveAnaliz(HttpRequestMessage request, [FromBody] dynamic obj)
        {
            AnalizManager manager = new AnalizManager();
            List<AnalizSonucModel> inList = obj.inList.ToObject<List<AnalizSonucModel>>();
            List<AnalizSonucModel> outList = obj.outList.ToObject<List<AnalizSonucModel>>();
            string numuneId =Convert.ToString(obj.numuneId);

            manager.Update(inList.Where(_ => _.isUpated).ToList());
            manager.Delete(outList.Where(_ => _.Id != string.Empty).ToList());
            manager.Insert(inList.Where(_ => _.Id == string.Empty).ToList(), numuneId);

            return "Data Reached";
        }

        [HttpGet()]
        [Route("api/Analizler/{numuneId?}")]
        public IActionResult Analizler(string numuneId)
        {
            Guid nId = new Guid(numuneId);

            var sonuc = (from p in AppManager.Db.AnalizSonuc
                         join r in AppManager.Db.Analiz on p.AnalizId equals r.Id
                         where p.NumuneAlimId.Equals(nId)
                         select new AnalizSonucModel
                         {
                             Analiz = r.Kod,
                             BaslamaTarihi = p.BaslamaTarihi,
                             BitisTarihi = p.BitisTarihi,
                             Id = Convert.ToString(p.Id),
                             DegerGirildi = p.DegerGirildi,
                             OlcumKararsizligi = p.OlcumKararsizligi,
                             Olumlu = p.Olumlu,
                             Sonuc = string.Empty,//p.DegerRtf
                             AnalizId = Convert.ToString(r.Id),
                             showEdit = false
                         }).ToList();


            var analiz = (
                     from p in AppManager.Db.Analiz
                     join r in AppManager.Db.AnalizSonuc.Where(_ => _.NumuneAlimId.Equals(nId)) on p.Id equals r.AnalizId into pr
                     from r in pr.DefaultIfEmpty()
                     where r.AnalizId == null
                     select new AnalizSonucModel
                     {
                         Analiz = p.Kod,
                         BaslamaTarihi = DateTime.Now,
                         BitisTarihi = DateTime.Now,
                         Id = string.Empty,
                         DegerGirildi = false,
                         OlcumKararsizligi = p.OlcumKararsizligi,
                         Olumlu = false,
                         Sonuc = string.Empty,//p.DegerRtf
                         AnalizId = Convert.ToString(p.Id),
                         showEdit = false
                     }).ToList();


            Result res = new Result();
            res.sonuclar = sonuc;
            res.analizler = analiz;
            res.numuneId = numuneId;
            return new ObjectResult(res);
        }



    }
}
