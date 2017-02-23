using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class IletiSmsDurum
    {
        public Guid Id { get; set; }
        public Guid IletiId { get; set; }
        public string Gsm { get; set; }
        public string MessageId { get; set; }
        public string Durum { get; set; }

        public virtual IletiSms Ileti { get; set; }
    }
}
