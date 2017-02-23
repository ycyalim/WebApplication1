
namespace LabKhufu.Model.Lists
{
    public class FihristList : EntityList
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string IsTelefonu { get; set; }
        public string EvTelefonu { get; set; }
        public string CepTelefonu { get; set; }

        public string Fax { get; set; }
        public string Adres { get; set; }
        public string EMail { get; set; }

        public FihristTipi Tip { get; set; }
    }
}
