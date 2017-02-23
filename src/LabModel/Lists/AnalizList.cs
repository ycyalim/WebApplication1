namespace LabKhufu.Model.Lists
{
    public class AnalizList : SimpleList
    {
        //public NumuneTipi NumuneTipi { get; set; }

        public string KisaKod { get; set; }

        public int? TipSiraNo { get; set; }

        public string AnalizTipi { get; set; }

        public string AciklamaRtf { get; set; }

        public string Birim { get; set; }
        public string BirimRtf { get; set; }

        public string KullanilanMethod { get; set; }

        public string NormalDeger { get; set; }
        public string NormalDegerRtf { get; set; }

        public string SifirDegerBirim { get; set; }
        public string SifirDegerBirimRtf { get; set; }

        public double? AltDeger { get; set; }
        public double? UstDeger { get; set; }
        public bool Akredite { get; set; }
                
    }
}
