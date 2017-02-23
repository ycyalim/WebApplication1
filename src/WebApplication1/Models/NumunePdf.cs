using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumunePdf
    {
        public NumunePdf()
        {
            IletiMailNumuneAlimFisPdf = new HashSet<IletiMail>();
            IletiMailNumuneAlimPdf = new HashSet<IletiMail>();
            NumunePdfEimza = new HashSet<NumunePdfEimza>();
            NumunePdfNumuneAlim = new HashSet<NumunePdfNumuneAlim>();
        }

        public Guid Id { get; set; }
        public int SiraNo { get; set; }
        public DateTime Tarih { get; set; }
        public Guid? NumuneAlimFisId { get; set; }
        public Guid? NumuneAlimId { get; set; }
        public string DosyaAd { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public string LocalDosyaAd { get; set; }
        public string Path { get; set; }

        public virtual ICollection<IletiMail> IletiMailNumuneAlimFisPdf { get; set; }
        public virtual ICollection<IletiMail> IletiMailNumuneAlimPdf { get; set; }
        public virtual ICollection<NumunePdfEimza> NumunePdfEimza { get; set; }
        public virtual ICollection<NumunePdfNumuneAlim> NumunePdfNumuneAlim { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual NumuneAlimFisi NumuneAlimFis { get; set; }
        public virtual NumuneAlim NumuneAlim { get; set; }
    }
}
