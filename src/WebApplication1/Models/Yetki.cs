using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Yetki
    {
        public Yetki()
        {
            PersonelYetki = new HashSet<PersonelYetki>();
            RolYetki = new HashSet<RolYetki>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual ICollection<PersonelYetki> PersonelYetki { get; set; }
        public virtual ICollection<RolYetki> RolYetki { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
