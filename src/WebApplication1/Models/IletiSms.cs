using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class IletiSms
    {
        public IletiSms()
        {
            IletiSmsDurum = new HashSet<IletiSmsDurum>();
        }

        public Guid IletiId { get; set; }
        public string Gsm { get; set; }
        public string Message { get; set; }

        public virtual ICollection<IletiSmsDurum> IletiSmsDurum { get; set; }
        public virtual Ileti Ileti { get; set; }
    }
}
