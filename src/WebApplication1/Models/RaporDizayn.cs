using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class RaporDizayn
    {
        public RaporDizayn()
        {
            NumuneTipi = new HashSet<NumuneTipi>();
        }

        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string TipAd { get; set; }
        public string AltTip { get; set; }
        public byte[] Dizayn { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual ICollection<NumuneTipi> NumuneTipi { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
