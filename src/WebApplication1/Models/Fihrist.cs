using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Fihrist
    {
        public Fihrist()
        {
            Kurum = new HashSet<Kurum>();
            Parametre = new HashSet<Parametre>();
        }

        public Guid Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EvTelefonu { get; set; }
        public string IsTelefonu { get; set; }
        public string CepTelefonu { get; set; }
        public string Fax { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public int Tip { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public string CepTelefonu2 { get; set; }
        public string Email2 { get; set; }

        public virtual ICollection<Kurum> Kurum { get; set; }
        public virtual ICollection<Parametre> Parametre { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
