using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class NumuneHavuzSuyu
    {
        public Guid Id { get; set; }
        public Guid NumuneAlimId { get; set; }
        public string KabinCinsi { get; set; }
        public double PH { get; set; }
        public double SerbestCl { get; set; }
        public double BagliCl { get; set; }
        public double H2o2 { get; set; }
        public double Biguanid { get; set; }
        public string AlinmaSekli { get; set; }

        public virtual NumuneAlim NumuneAlim { get; set; }
    }
}
