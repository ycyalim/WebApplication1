using LabKhufu.Model.Entities;

namespace LabKhufu.Model.Lists
{
    public class NumuneTipiList : SimpleList
    {
        public NumuneAlimTipi NumuneAlimTipi { get; set; }
        public EnumNumuneTipi Tip { get; set; }

        public double OnDegerMiktar { get; set; }
        public string OnDegerBirim { get; set; }
        public double OndegerSicaklik { get; set; }
        public string OnDegerKabinCinsi { get; set; }
        public string OnDegerAmbalaji { get; set; }
        public string OnDegerSeriPartiNo { get; set; }
        public string OnDegerUreticiFirmaAdi { get; set; }
        public string OnDegerUretimSKTarihi { get; set; }
        public string OnDegerBosMiktarBirim { get; set; }
        public int OnDegerAnalizGun { get; set; }
        public int OnDegerAnalizBaslamaGun { get; set; }

        public string AnaliziIstenenParametreler { get; set; }
        public string IstenilenAnalizler { get; set; }

    }
}
