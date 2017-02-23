using System;
using LabKhufu.Model.Entities;

namespace LabKhufu.Model.Lists
{
    public class NumuneAlimList : EntityList 
    {
        public NumuneAlimTipi NumuneAlimTipi { get; set; }

        public bool Secim { get; set; }

        public int No { get; set; }
        public string RaporNo { get; set; }  

        public DateTime Tarih { get; set; }

        public Personel NumuneyiAlan { get; set; }
        public Guid NumuneyiAlan_ID { get; set; }

        public Kurum Kurum { get; set; }
        public Guid Kurum_ID { get; set; }

        public string KurumKod { get; set; }
        public string KurumAciklama { get; set; }

        public string AnalizAmaci { get; set; }

        public bool KapakBasildi { get; set; }

        public int KayitNo { get; set; }

        public string NumuneTipi { get; set; }
        public string NumuneAdi { get; set; }
        public double Miktar { get; set; }
        public string Birim { get; set; }

        public double Sicaklik { get; set; }

        public string AlimYeri { get; set; }

        public DateTime? BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }

        public string Aciklama { get; set; }
        public string Kodeks { get; set; }

        public string IstenenAnalizler { get; set; }

        public int ToplamAnalizSayisi { get; set; }
        public int SonuclananAnalizSayisi { get; set; }
        public int BekleyenAnalizSayisi { get; set; }

        public bool RaporBasildi { get; set; }
        public int RaporBasilmaSayisi { get; set; }

        public bool MailGonderildi { get; set; }
        public bool RaporWebGonderildi { get; set; }

        public bool AnalizFormuBasildi { get; set; }
        public bool KayitFormuBasildi { get; set; }
        public bool DetayFormuBasildi { get; set; }

    }
}
