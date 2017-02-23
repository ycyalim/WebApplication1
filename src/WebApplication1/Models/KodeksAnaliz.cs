using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class KodeksAnaliz
    {
        public Guid KodeksId { get; set; }
        public Guid AnalizId { get; set; }

        public virtual Analiz Analiz { get; set; }
        public virtual Kodeks Kodeks { get; set; }
    }
}
