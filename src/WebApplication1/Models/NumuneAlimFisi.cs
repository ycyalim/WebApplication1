using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KhufuMobile.Models
{
    public partial class NumuneAlimFisi
    {
        public NumuneAlimFisi()
        {
            Ileti = new HashSet<Ileti>();
            NumuneAlim = new HashSet<NumuneAlim>();
            NumunePdf = new HashSet<NumunePdf>();
        } 

        public Guid Id { get; set; }
        public Guid NumuneAlimTipiId { get; set; }
        public string RaporNoBaslik { get; set; }
        public int No { get; set; }
        public string RaporNo { get; set; }
        [Required(ErrorMessage = "Tarih giriniz.")]
        public DateTime Tarih { get; set; }
        public Guid NumuneyiAlanId { get; set; }
        public Guid KurumId { get; set; }
        public string AnalizAmaci { get; set; }
        public bool AnalizFormuBasildi { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public bool KapakBasildi { get; set; }
        public bool RaporBasildi { get; set; }
        public int RaporBasilmaSayisi { get; set; }
        public bool MailGonderildi { get; set; }
        public bool KayitFormuBasildi { get; set; }
        public bool DetayFormuBasildi { get; set; }
        [Required(ErrorMessage = "Labaratuvar ulaşım tarihi giriniz.")]
        public DateTime LaboratuvaraUlasmaTarihi { get; set; }
        public Guid? DezenfeksiyonTuruId { get; set; }
        public bool WebdeGoster { get; set; }
        public bool? PdfOlusturuldu { get; set; }
        public bool? SmsGonderildi { get; set; }
        public DateTime? BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }

        public virtual ICollection<Ileti> Ileti { get; set; }
        public virtual ICollection<NumuneAlim> NumuneAlim { get; set; }
        public virtual ICollection<NumunePdf> NumunePdf { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual DezenfeksiyonTuru DezenfeksiyonTuru { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual Kurum Kurum { get; set; }
        public virtual NumuneAlimTipi NumuneAlimTipi { get; set; }
        public virtual Personel NumuneyiAlan { get; set; }
    }
}
