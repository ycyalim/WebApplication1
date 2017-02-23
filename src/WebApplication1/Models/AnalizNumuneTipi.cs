using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class AnalizNumuneTipi
    {
        public Guid AnalizId { get; set; }
        public Guid NumuneTipiId { get; set; }

        public virtual Analiz Analiz { get; set; }
        public virtual NumuneTipi NumuneTipi { get; set; }
    }
}
