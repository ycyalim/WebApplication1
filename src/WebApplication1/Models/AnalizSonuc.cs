using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class AnalizSonuc
    {
        public Guid Id { get; set; }
        public Guid NumuneAlimId { get; set; }
        public Guid AnalizId { get; set; }
        public string Deger { get; set; }
        public string DegerRtf { get; set; }
        public double? DegerSayisal { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public bool DegerGirildi { get; set; }
        public string OlcumKararsizligi { get; set; }
        public bool Olumlu { get; set; }
        public DateTime? BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }

        public virtual AnalizSonucAnaliz AnalizSonucAnaliz { get; set; }
        public virtual Analiz Analiz { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual NumuneAlim NumuneAlim { get; set; }
    }
}
