using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Eimza
    {
        public Eimza()
        {
            NumunePdfEimza = new HashSet<NumunePdfEimza>();
            NumuneTipiEimza = new HashSet<NumuneTipiEimza>();
        }

        public Guid Id { get; set; }
        public string SertifikaAd { get; set; }
        public string SertifikaId { get; set; }
        public string Pin { get; set; }
        public string LibraryName { get; set; }
        public string TokenLabel { get; set; }
        public string TokenSerial { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public string AdSoyad { get; set; }

        public virtual ICollection<NumunePdfEimza> NumunePdfEimza { get; set; }
        public virtual ICollection<NumuneTipiEimza> NumuneTipiEimza { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
