using System;
using LabKhufu.Model.Entities;

namespace LabKhufu.Model.Lists
{
    public class NumuneAlimFisiList : EntityList 
    {
        public NumuneAlimTipi NumuneAlimTipi { get; set; }

        public bool Secim { get; set; }

        public int No { get; set; }
        public string RaporNo { get; set; }  

        public DateTime Tarih { get; set; }

        public Personel NumuneyiAlan { get; set; }
        public Guid NumuneyiAlan_ID { get; set; }

        public Kurum Kurum { get; set; }
        public Guid Kurum_ID { get; set; }

        public string KurumKod { get; set; }
        public string KurumAciklama { get; set; }

        public string AnalizAmaci { get; set; }

        public bool KapakBasildi { get; set; }

        public bool WebdeGoster { get; set; }
    }
}
