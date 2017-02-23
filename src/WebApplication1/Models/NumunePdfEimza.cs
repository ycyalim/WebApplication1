using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumunePdfEimza
    {
        public Guid NumunePdfId { get; set; }
        public Guid EimzaId { get; set; }
        public Guid Id { get; set; }

        public virtual Eimza Eimza { get; set; }
        public virtual NumunePdf NumunePdf { get; set; }
    }
}
