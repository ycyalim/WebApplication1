using System;

namespace LabKhufu.Model.Lists
{
    public class KurumList : SimpleList 
    {
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Adres { get; set; }
        public string EMail { get; set; }

        public Guid? FiyatTipi_ID { get; set; }
        public string FiyatTipi { get; set; }

        public string BakanlikNo { get; set; }
    }
}
