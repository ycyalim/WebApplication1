using System;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace LabKhufu.Model.Entities
{
    public partial class AnalizSonuc
    {
        public string DegerGetir(Func<AnalizSonuc, string> deger)
        {
            return deger(this);
        }

        [NotMapped]
        [Obsolete]
        public string DegerAnalizBirim
        {
            get
            {
                if (Deger == null || Deger.Trim() == "" || Deger == "0")
                    return Analiz.SifirDegerBirimRtf;
                else
                    return DegerRtf + " " + Analiz.Birim;
            }
        }

        [NotMapped]
        public string DegerAnalizBirimRtf
        {
            get
            {
                if (Deger == null || Deger.Trim() == "" || Deger == "0")
                    return Analiz.SifirDegerBirimRtf;
                else
                    return DegerRtf + Analiz.BirimRtf;
            }
        }

        [NotMapped]
        public string DegerAnalizSifirDeger
        {
            get
            {
                if (Deger == null || Deger.Trim() == "" || Deger == "0")
                    return Analiz.SifirDegerBirimRtf;
                else
                    return DegerRtf;
            }
        }

        [NotMapped]
        public int AnalizTipiSiraNo
        {
            get { return Analiz.AnalizTipi.SiraNo; }
        }

        [NotMapped]
        public string AnalizKod
        {
            get { return Analiz.Kod; }
        }

        [NotMapped]
        public string AnalizTipiKod
        {
            get { return Analiz.AnalizTipi.Kod; }
        }

    }
}
