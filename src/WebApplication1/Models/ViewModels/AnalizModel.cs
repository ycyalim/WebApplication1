using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhufuMobile.Models.ViewModels
{

    public class AnalizModel
    {
        public string Id { get; set; }
        public string Kod { get; set; }
        public string Tip { get; set; }
        public DateTime? BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public string OlcumKararsizligi { get; set; }
    }
 
}
