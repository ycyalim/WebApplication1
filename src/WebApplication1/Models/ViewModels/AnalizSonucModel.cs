using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhufuMobile.Models.ViewModels
{
    public class AnalizSonucModel
    {
        public string Id { get; set; }
        public string Analiz { get; set; }
        public string Sonuc { get; set; } //DegerRtf
        public string OlcumKararsizligi { get; set; } //OlcumKararsizligi
        public bool DegerGirildi { get; set; } //Sonuç Girildi
        public bool Olumlu { get; set; } //Olumlu
        public DateTime? BaslamaTarihi { get; set; }//BaslamaTarihi
        public DateTime? BitisTarihi { get; set; } //BitisTarihi
        public string AnalizId { get; set; }
        public bool showEdit { get; set; }
        public bool isUpated { get; set; }

    }
}
