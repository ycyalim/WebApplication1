using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;

namespace LabKhufu.Model.Entities
{
    public partial class NumuneAlim 
    {
        
        [NotMapped]
        public string TempPdfName
        {
            get;
            set;
        }

        private string AnalizSonuc(string analizKisaKodu, Func<AnalizSonuc, string> deger)
        {
            AnalizSonuc sonuc = Sonuclar.Where(x => analizKisaKodu.ToLower().Equals(x.Analiz.KisaKod.ToLower())).FirstOrDefault();
            if (sonuc == null) return "";
            return deger(sonuc); // sonuc.DegerGetir(deger);
        }

        private AnalizDegerBirimRtf analizDegerBirimRtf;
        [NotMapped]
        public AnalizDegerBirimRtf AnalizDegerBirimRtf
        {
            get
            {
                if (analizDegerBirimRtf == null)
                    analizDegerBirimRtf = new AnalizDegerBirimRtf(AnalizSonuclari);
                return analizDegerBirimRtf;
            }
        }

        private AnalizDegerRtf analizDegerRtf;
        [NotMapped]
        public AnalizDegerRtf AnalizDegerRtf
        {
            get
            {
                if (analizDegerRtf == null)
                    analizDegerRtf = new AnalizDegerRtf(AnalizSonuclari);
                return analizDegerRtf;
            }
        }

        private AnalizDeger analizDeger;
        [NotMapped]
        public AnalizDeger AnalizDeger
        {
            get
            {
                if (analizDeger == null)
                    analizDeger = new AnalizDeger(AnalizSonuclari);
                return analizDeger;
            }
        }

        [NotMapped]
        public bool Secim { get; set; }

        [NotMapped]
        public string RaporNo
        {
            get { return NumuneAlimFis.RaporNo + "-" + SiraNo.ToString().PadLeft(2, '0'); }
        }

        [NotMapped]
        public string FisSiraNo
        {
            get { return NumuneAlimFis.No + "-" + SiraNo.ToString().PadLeft(2, '0'); }
        }

        [NotMapped]
        private int? kayitNoRapor;
        [NotMapped]
        public int? KayitNoRapor
        {
            get
            {
                if (KayitNo > 0)
                    return KayitNo;
                return kayitNoRapor;
            }
            set { kayitNoRapor = value; }
        }

        [NotMapped]
        public string AnalizKisaKodlari
        {
            get
            {
                return string.Join(", ", AnalizSonuclari.Select(x => x.Analiz.KisaKod ?? "").ToArray());
            }
        }

        [NotMapped]
        public string OlumsuzAnalizler
        {
            get
            {
                return string.Join(", ", AnalizSonuclari.Where(x => !x.Olumlu).Select(x => x.Analiz.AciklamaRtf ?? ""));
            }
        }

        public int OlumsuzAnalizSayisi
        {
            get
            {
                return AnalizSonuclari.Count(x => !x.Olumlu);
            }
        }

        [NotMapped]
        public string AnalizKisaKodlariSatir
        {
            get
            {
                return string.Join("\r\n", AnalizSonuclari.Select(x => x.Analiz.KisaKod ?? "").ToArray());
            }
        }

        [NotMapped]
        public string AnalizMethodlari
        {
            get
            {
                return string.Join(", ", AnalizSonuclari.Select(x => x.Analiz.KullanilanMethod ?? "").ToArray());
            }
        }

        [NotMapped]
        public string NumuneAdiAlimYeri
        {
            get
            {
                string s = (NumuneAdi ?? "");
                if (!string.IsNullOrWhiteSpace(AlimYeri) && AlimYeri.Trim().Length > 0)
                    s += " (" + (AlimYeri ?? "") + ")";
                return s;
            }
        }

        [NotMapped]
        public string MiktarBirim
        {
            get
            {
                if (Miktar <= 0)
                    return NumuneTipi.OnDegerBosMiktarBirim;
                else
                    return Miktar.ToString() + " " + Birim ?? "";
            }
        }

        [NotMapped]
        public string BaslamaBitisTarihi
        {
            get
            {
                string s = "";
                if (BaslamaTarihi.HasValue)
                    s += BaslamaTarihi.Value.ToString("dd.MM.yyyy");
                if (BitisTarihi.HasValue)
                    s += " / " + BitisTarihi.Value.ToString("dd.MM.yyyy");
                return s;
            }
        }

        [NotMapped]
        public List<AnalizSonuc> AnalizSonuclari
        {
            get 
            { 
                return Sonuclar.OrderBy(x => x.Analiz.AnalizTipi.SiraNo)
                    .ThenBy(x => x.Analiz.SiraNo)
                    .ThenBy(x => x.Analiz.Kod)
                    .ToList(); }
        }
    }

    public class AnalizDegerBirimRtf
    {
        List<AnalizSonuc> sonuclar;
        public AnalizDegerBirimRtf(List<AnalizSonuc> sonuclar)
        {
            this.sonuclar = sonuclar;
        }

        public string this[string kisaKod]
        {
            get
            {
                AnalizSonuc sonuc = sonuclar.Where(x => kisaKod.ToLower().Equals(x.Analiz.KisaKod.ToLower())).FirstOrDefault();
                if (sonuc == null) return "";
                return sonuc.DegerAnalizBirimRtf;
            }
        }
    }

    public class AnalizDegerRtf
    {
        List<AnalizSonuc> sonuclar;
        public AnalizDegerRtf(List<AnalizSonuc> sonuclar)
        {
            this.sonuclar = sonuclar;
        }

        public string this[string kisaKod]
        {
            get
            {
                AnalizSonuc sonuc = sonuclar.Where(x => kisaKod.ToLower().Equals(x.Analiz.KisaKod.ToLower())).FirstOrDefault();
                if (sonuc == null) return "";
                return sonuc.DegerRtf;
            }
        }
    }

    public class AnalizDeger
    {
        List<AnalizSonuc> sonuclar;
        public AnalizDeger(List<AnalizSonuc> sonuclar)
        {
            this.sonuclar = sonuclar;
        }

        public string this[string kisaKod]
        {
            get
            {
                AnalizSonuc sonuc = sonuclar.Where(x => kisaKod.ToLower().Equals(x.Analiz.KisaKod.ToLower())).FirstOrDefault();
                if (sonuc == null) return "";
                return sonuc.Deger;
            }
        }
    }

}
