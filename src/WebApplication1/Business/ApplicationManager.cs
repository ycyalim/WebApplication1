using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhufuMobile.Models;

namespace KhufuMobile.Business
{

    public static class AppManager
    {
        private static KhufuDataContext _ctx = null;
        private static Parametre _parametre = null;
        public static KhufuDataContext Db
        {
            get
            {
                if (_ctx == null) _ctx = new KhufuDataContext();
                return _ctx;
            }
        }
        
        private static Personel _personel;
        public static Personel Personel
        {
            get { return _personel; }
            set { _personel = value; }
        }

        public static Parametre Parametre
        {
            get
            {
                if (_parametre == null)
                {
                    _parametre = (from p in _ctx.Parametre select p).First();
                }
                return _parametre;
            }
        }

        public static object Kodeksler()
        {
          var  listItems = (from x in Db.Kodeks
                         orderby x.SiraNo, x.Kod, x.Aciklama
                         select new
                         {
                             ID = x.Id,
                             Kod = x.Kod,
                             Aciklama = x.Aciklama,
                             NumuneTipi = x.NumuneTipi,
                             SiraNo = x.SiraNo,
                             AnalizMethodu = x.AnalizMethodu,
                             Degistiren = x.Degistiren.Kod,
                             Degistiren_ID = x.DegistirenId,
                             DegistirmeTarihi = x.DegistirmeTarihi,
                             Ekleyen = x.Ekleyen.Kod,
                             Ekleyen_ID = x.EkleyenId,
                             EklemeTarihi = x.EklemeTarihi
                         }).ToList();
            return listItems;
        }

        public  enum EnumNumuneAlimTipi
        {
            Gıda = 64,
            HavuzSuyu = 128,
            Diğer = 2048
        }
    }

}

