using System.Collections.Generic;

namespace LabKhufu.Model
{
    public class YetkiTanimlari
    {
        public static readonly string MENU_NUMUNE_ALIM = "MENU NUMUNE ALIM";
        public static readonly string MENU_ANALIZ_SONUC_GIRIS = "MENU ANALIZ SONUC GIRIS";
        public static readonly string MENU_NUMUNE_RAPORLAMA = "MENU NUMUNE RAPORLAMA";
        public static readonly string MENU_ISLEMLER = "MENU ISLEMLER";
        public static readonly string MENU_MUHASEBE = "MENU MUHASEBE";
        public static readonly string MENU_RAPORLAR = "MENU RAPORLAR";
        public static readonly string MENU_TANIMLAR = "MENU TANIMLAR";
        public static readonly string MENU_YONETIM = "MENU YONETIM";
        public static readonly string RAPOR_SILME = "RAPOR SILME";

        private static List<YetkiTanim> _list;

        public static List<YetkiTanim> List
        {
            get
            {
                return null;

                //    if (_list == null)
                //    {
                //        YetkiTanimlari yetkiler = new YetkiTanimlari();
                //        _list = new List<YetkiTanim>();
                //        System.Reflection.FieldInfo[] flds = typeof(YetkiTanimlari);

                //        int i = 1;
                //        foreach (System.Reflection.FieldInfo f in flds)
                //            if (f.FieldType.Name == "String")
                //                List.Add(new YetkiTanim(i++, (string)f.GetValue(yetkiler)));
                //    }
                //    return _list;
                //}
            }
        }
    }
}
