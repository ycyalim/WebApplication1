using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumunePdfNumuneAlim
    {
        public Guid NumunePdfId { get; set; }
        public Guid NumuneAlimId { get; set; }
        public Guid Id { get; set; }

        public virtual NumuneAlim NumuneAlim { get; set; }
        public virtual NumunePdf NumunePdf { get; set; }
    }
}
