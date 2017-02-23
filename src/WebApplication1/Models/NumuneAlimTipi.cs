using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumuneAlimTipi
    {
        public NumuneAlimTipi()
        {
            NumuneAlimFisi = new HashSet<NumuneAlimFisi>();
            NumuneTipi = new HashSet<NumuneTipi>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public string Aciklama { get; set; }
        public int SiraNo { get; set; }
        public int Tip { get; set; }
        public string RaporNoBaslik { get; set; }
        public int SonRaporNo { get; set; }
        public string OnDegerAnalizAmaci { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public int SonNumuneKayitNo { get; set; }
        public int OnDegerAnalizGun { get; set; }
        public int OnDegerAnalizBaslamaGun { get; set; }

        public virtual ICollection<NumuneAlimFisi> NumuneAlimFisi { get; set; }
        public virtual ICollection<NumuneTipi> NumuneTipi { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
