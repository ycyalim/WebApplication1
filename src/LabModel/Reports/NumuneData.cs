using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKhufu.Model.Reports
{
    public partial class NumuneData
    {
        public NumuneData()
        {

        }

        public int Adet { get; set; }
        public string RaporNo { get; set; }
        public DateTime Tarih { get; set; }
        public string NumuneyiAlan { get; set; }
        public string Kurum { get; set; }
        public string AnalizAmaci { get; set; }

        public int KayitNo { get; set; }
        public string NumuneAlimTipi { get; set; }
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

        //public string Cinsi { get; set; }
        //public string Ambalaji { get; set; }
        //public DateTime? UretimTarihi { get; set; }
        //public DateTime? SonKullanimTarihi { get; set; }
        //public string UretimSKTarihi { get; set; }
        //public string SeriPartiNo { get; set; }
        //public string UreticiFirmaAdi { get; set; }

        //public string KabinCinsi { get; set; }
        //public double? pH { get; set; }
        //public double? SerbestCL { get; set; }
        //public double? BagliCL { get; set; }
        //public double? H2O2 { get; set; }
        //public double? Biguanid { get; set; }

        public int ToplamAnalizSayisi { get; set; }
        public int SonuclananAnalizSayisi { get; set; }
        public int BekleyenAnalizSayisi { get; set; }

        //public bool RaporBasildi { get; set; }
        //public int RaporBasilmaSayisi { get; set; }

        //public bool MailGonderildi { get; set; }
        //public bool RaporWebGonderildi { get; set; }

        //public bool AnalizFormuBasildi { get; set; }
        //public bool KayitFormuBasildi { get; set; }
        //public bool DetayFormuBasildi { get; set; }
        //public bool KapakBasildi { get; set; }

        public string AnalizSonuc { get; set; }

        public override string ToString()
        {
            return NumuneAdi;
        }
    }
}
