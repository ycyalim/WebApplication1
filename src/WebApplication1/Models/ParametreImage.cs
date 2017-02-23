using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class ParametreImage
    {
        public ParametreImage()
        {
            Parametre = new HashSet<Parametre>();
        }

        public Guid Id { get; set; }
        public byte[] Antet { get; set; }

        public virtual ICollection<Parametre> Parametre { get; set; }
    }
}
