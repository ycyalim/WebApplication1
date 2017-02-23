using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Ileti
    {
        public Ileti()
        {
            IletiEki = new HashSet<IletiEki>();
        }

        public Guid Id { get; set; }
        public int SiraNo { get; set; }
        public DateTime Tarih { get; set; }
        public int Tip { get; set; }
        public Guid? NumuneAlimFisId { get; set; }
        public Guid? NumuneAlimId { get; set; }
        public bool Gonderildi { get; set; }
        public DateTime? GonderildigiTarih { get; set; }
        public bool Hata { get; set; }
        public string HataMesaj { get; set; }
        public bool Iptal { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }

        public virtual ICollection<IletiEki> IletiEki { get; set; }
        public virtual IletiMail IletiMail { get; set; }
        public virtual IletiSms IletiSms { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual NumuneAlimFisi NumuneAlimFis { get; set; }
        public virtual NumuneAlim NumuneAlim { get; set; }
    }
}
