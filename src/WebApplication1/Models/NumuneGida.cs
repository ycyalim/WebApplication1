using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumuneGida
    {
        public Guid Id { get; set; }
        public Guid NumuneAlimId { get; set; }
        public string Cinsi { get; set; }
        public string Ambalaji { get; set; }
        public DateTime? UretimTarihi { get; set; }
        public DateTime? SonKullanimTarihi { get; set; }
        public string UretimSktarihi { get; set; }
        public string SeriPartiNo { get; set; }
        public string UreticiFirmaAdi { get; set; }

        public virtual NumuneAlim NumuneAlim { get; set; }
    }
}
