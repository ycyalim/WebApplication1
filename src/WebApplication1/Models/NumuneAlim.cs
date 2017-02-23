using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumuneAlim
    {
        public NumuneAlim()
        {
            AnalizSonuc = new HashSet<AnalizSonuc>();
            Ileti = new HashSet<Ileti>();
            NumunePdf = new HashSet<NumunePdf>();
            NumunePdfNumuneAlim = new HashSet<NumunePdfNumuneAlim>();
        }

        public Guid Id { get; set; }
        public Guid NumuneAlimFisId { get; set; }
        public int SiraNo { get; set; }
        public Guid NumuneTipiId { get; set; }
        public string NumuneAdi { get; set; }
        public double Miktar { get; set; }
        public string Birim { get; set; }
        public double Sicaklik { get; set; }
        public string AlimYeri { get; set; }
        public DateTime? BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public Guid? KodeksId { get; set; }
        public string IstenenAnalizler { get; set; }
        public int ToplamAnalizSayisi { get; set; }
        public int SonuclananAnalizSayisi { get; set; }
        public int BekleyenAnalizSayisi { get; set; }
        public bool RaporBasildi { get; set; }
        public int RaporBasilmaSayisi { get; set; }
        public bool MailGonderildi { get; set; }
        public bool AnalizFormuBasildi { get; set; }
        public bool KayitFormuBasildi { get; set; }
        public bool DetayFormuBasildi { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public int KayitNo { get; set; }
        public bool WebdeGoster { get; set; }
        public bool? PdfOlusturuldu { get; set; }
        public bool? SmsGonderildi { get; set; }
        public string BakanlikRaporNo { get; set; }
        public bool Olumlu { get; set; }

        public virtual ICollection<AnalizSonuc> AnalizSonuc { get; set; }
        public virtual ICollection<Ileti> Ileti { get; set; }
        public virtual NumuneGida NumuneGida { get; set; }
        public virtual NumuneHavuzSuyu NumuneHavuzSuyu { get; set; }
        public virtual ICollection<NumunePdf> NumunePdf { get; set; }
        public virtual ICollection<NumunePdfNumuneAlim> NumunePdfNumuneAlim { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual Kodeks Kodeks { get; set; }
        public virtual NumuneAlimFisi NumuneAlimFis { get; set; }
        public virtual NumuneTipi NumuneTipi { get; set; }
    }
}
