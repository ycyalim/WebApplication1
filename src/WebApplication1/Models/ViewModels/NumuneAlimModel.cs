using KhufuMobile.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhufuMobile.Models.ViewModels
{
    public class NumuneAlimModel
    {
      
        public string Id { get; set; }
        public string NumuneFisiId { get; set; }
        public int SiraNo { get; set; }
        public int KayitNo { get; set; }
        public bool WebGoster { get; set; }
        public string NumuneTipi { get; set; } //swap,gida,sıvı
        public string NumuneAdi { get; set; }
        public string AlimYeri { get; set; }
        public string KodeksId { get; set; }
        public string Kodeks { get; set; }
        public string BkRNo { get; set; }
        public string IstAnalizler { get; set; }
        public double Miktar { get; set; }
        public string Birim { get; set; }
        public double Sicaklik { get; set; }
        public string Aciklama { get; set; }
        public DateTime? BasTarih { get; set; }
        public DateTime? BitTarih { get; set; }
        //
        public string Cinsi { get; set; }
        public string Ambalaji { get; set; }
        public DateTime? UretimTarihi { get; set; }
        public DateTime? SonKulTarihi { get; set; }
        public string UretimSkTarihi { get; set; }
        public string SeriPartNo { get; set; }
        public string UreticiFirmaAdi { get; set; }
       
        //Properties
        public List<SelectListItem> Tipler { get;set; }

        public List<SelectListItem> KodeksListe { get; set; }

        public List<NumuneTipi> NumuneTipleri { get; set; }

        public List<Kodeks> Kodeksler { get; set; }

        public string JsonNumuneTipleri { get; set; }
    }
}

