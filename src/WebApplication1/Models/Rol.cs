using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Personel = new HashSet<Personel>();
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

        public virtual ICollection<Personel> Personel { get; set; }
        public virtual ICollection<RolYetki> RolYetki { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
