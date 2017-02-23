using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumuneTipi
    {
        public NumuneTipi()
        {
            AnalizNumuneTipi = new HashSet<AnalizNumuneTipi>();
            Kodeks = new HashSet<Kodeks>();
            NumuneAlim = new HashSet<NumuneAlim>();
            NumuneTipiEimza = new HashSet<NumuneTipiEimza>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public Guid NumuneAlimTipiId { get; set; }
        public int Tip { get; set; }
        public Guid? RaporDizaynId { get; set; }
        public double OnDegerMiktar { get; set; }
        public string OnDegerBirim { get; set; }
        public double OndegerSicaklik { get; set; }
        public string OnDegerKabinCinsi { get; set; }
        public string OnDegerAmbalaji { get; set; }
        public string OnDegerSeriPartiNo { get; set; }
        public string OnDegerUreticiFirmaAdi { get; set; }
        public string OnDegerUretimSktarihi { get; set; }
        public string OnDegerBosMiktarBirim { get; set; }
        public int OnDegerAnalizGun { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public string OnDegerAlinmaSekli { get; set; }
        public int OnDegerAnalizBaslamaGun { get; set; }
        public string AnaliziIstenenParametreler { get; set; }
        public string IstenilenAnalizler { get; set; }

        public virtual ICollection<AnalizNumuneTipi> AnalizNumuneTipi { get; set; }
        public virtual ICollection<Kodeks> Kodeks { get; set; }
        public virtual ICollection<NumuneAlim> NumuneAlim { get; set; }
        public virtual ICollection<NumuneTipiEimza> NumuneTipiEimza { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual NumuneAlimTipi NumuneAlimTipi { get; set; }
        public virtual RaporDizayn RaporDizayn { get; set; }
    }
}
