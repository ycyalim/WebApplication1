using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class IletiMail
    {
        public Guid IletiId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SmtpServer { get; set; }
        public int SmptpPort { get; set; }
        public bool Ssl { get; set; }
        public bool DeliveryNotification { get; set; }
        public Guid? NumuneAlimFisPdfId { get; set; }
        public Guid? NumuneAlimPdfId { get; set; }

        public virtual Ileti Ileti { get; set; }
        public virtual NumunePdf NumuneAlimFisPdf { get; set; }
        public virtual NumunePdf NumuneAlimPdf { get; set; }
    }
}
