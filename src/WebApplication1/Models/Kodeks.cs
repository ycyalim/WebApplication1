using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Kodeks
    {
        public Kodeks()
        {
            KodeksAnaliz = new HashSet<KodeksAnaliz>();
            NumuneAlim = new HashSet<NumuneAlim>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public Guid NumuneTipiId { get; set; }
        public string AnalizMethodu { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual ICollection<KodeksAnaliz> KodeksAnaliz { get; set; }
        public virtual ICollection<NumuneAlim> NumuneAlim { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual NumuneTipi NumuneTipi { get; set; }
    }
}
