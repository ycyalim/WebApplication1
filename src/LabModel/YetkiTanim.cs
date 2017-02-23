namespace LabKhufu.Model
{
    public class YetkiTanim
    {
        public int Sira { get; set; }
        public string Kod { get; set; }

        public YetkiTanim(int sira, string kod)
        {
            Sira = sira;
            Kod = kod;
        }
    }
}
