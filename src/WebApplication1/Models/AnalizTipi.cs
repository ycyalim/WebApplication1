using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class AnalizTipi
    {
        public AnalizTipi()
        {
            Analiz = new HashSet<Analiz>();
            AnalizSonucAnaliz = new HashSet<AnalizSonucAnaliz>();
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

        public virtual ICollection<Analiz> Analiz { get; set; }
        public virtual ICollection<AnalizSonucAnaliz> AnalizSonucAnaliz { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
