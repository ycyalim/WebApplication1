namespace LabKhufu.Model.Lists
{
    public class NumuneAlimTipiList : SimpleList
    {
        public EnumNumuneAlimTipi Tip { get; set; }
        public string RaporNoBaslik { get; set; }
        public int SonRaporNo { get; set; }
        public int SonNumuneKayitNo { get; set; }
        public string OnDegerAnalizAmaci { get; set; }        
    }
}
