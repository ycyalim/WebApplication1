using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class GridLayout
    {
        public Guid Id { get; set; }
        public Guid PersonelId { get; set; }
        public string Form { get; set; }
        public string GridView { get; set; }
        public byte[] Layout { get; set; }
        public byte[] ViewInfo { get; set; }

        public virtual Personel Personel { get; set; }
    }
}
