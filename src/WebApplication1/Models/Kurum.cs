using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Kurum
    {
        public Kurum()
        {
            NumuneAlimFisi = new HashSet<NumuneAlimFisi>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public Guid? FiyatTipiId { get; set; }
        public Guid? FihristId { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public string WebPassword { get; set; }
        public string BakanlikNo { get; set; }
        public string WebUsername { get; set; }

        public virtual ICollection<NumuneAlimFisi> NumuneAlimFisi { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual Fihrist Fihrist { get; set; }
        public virtual FiyatTipi FiyatTipi { get; set; }
    }
}
