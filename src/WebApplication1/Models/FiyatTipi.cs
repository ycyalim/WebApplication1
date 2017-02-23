using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class FiyatTipi
    {
        public FiyatTipi()
        {
            Kurum = new HashSet<Kurum>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public Guid DovizId { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual ICollection<Kurum> Kurum { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Doviz Doviz { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
