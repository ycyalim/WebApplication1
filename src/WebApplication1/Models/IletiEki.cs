using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class IletiEki
    {
        public Guid IletiId { get; set; }
        public string DosyaAd { get; set; }
        public Guid Id { get; set; }

        public virtual Ileti Ileti { get; set; }
    }
}
