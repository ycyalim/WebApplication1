using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class PersonelImage
    {
        public PersonelImage()
        {
            Personel = new HashSet<Personel>();
        }

        public Guid Id { get; set; }
        public byte[] Kase { get; set; }
        public byte[] KaseImzali { get; set; }

        public virtual ICollection<Personel> Personel { get; set; }
    }
}
