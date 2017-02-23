using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class DovizKur
    {
        public Guid Id { get; set; }
        public Guid DovizId { get; set; }
        public DateTime Tarih { get; set; }
        public double Kur { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual Personel Degistiren { get; set; }
        public virtual Doviz Doviz { get; set; }
        public virtual Personel Ekleyen { get; set; }
    }
}
