using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class AnalizSonucAnaliz
    {
        public Guid AnalizSonucId { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public string KisaKod { get; set; }
        public Guid? AnalizTipiId { get; set; }
        public string Birim { get; set; }
        public string KullanilanMethod { get; set; }
        public string NormalDeger { get; set; }
        public string SifirDegerBirim { get; set; }
        public string AciklamaRtf { get; set; }
        public string SifirDegerBirimRtf { get; set; }
        public string NormalDegerRtf { get; set; }
        public string BirimRtf { get; set; }
        public bool Akredite { get; set; }
        public double? AltDeger { get; set; }
        public double? UstDeger { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public string OlcumKararsizligi { get; set; }

        public virtual AnalizSonuc AnalizSonuc { get; set; }
        public virtual AnalizTipi AnalizTipi { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
