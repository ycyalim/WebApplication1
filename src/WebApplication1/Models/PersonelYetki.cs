using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class PersonelYetki
    {
        public Guid PersonelId { get; set; }
        public Guid YetkiId { get; set; }

        public virtual Personel Personel { get; set; }
        public virtual Yetki Yetki { get; set; }
    }
}
