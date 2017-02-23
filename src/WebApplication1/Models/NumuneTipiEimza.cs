using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumuneTipiEimza
    {
        public Guid NumuneTipiId { get; set; }
        public Guid EimzaId { get; set; }

        public virtual Eimza Eimza { get; set; }
        public virtual NumuneTipi NumuneTipi { get; set; }
    }
}
