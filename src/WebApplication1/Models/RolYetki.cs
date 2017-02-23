using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class RolYetki
    {
        public Guid RolId { get; set; }
        public Guid YetkiId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Yetki Yetki { get; set; }
    }
}
