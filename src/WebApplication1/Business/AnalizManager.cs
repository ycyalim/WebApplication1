using KhufuMobile.Models;
using KhufuMobile.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhufuMobile.Business
{

    public class AnalizManager
    {
        public string Update(List<AnalizSonucModel> list)
        {
            foreach (var item in list)
            {
                var dbRecord = (from p in AppManager.Db.AnalizSonuc
                                where p.Id.CompareTo(new Guid(item.Id)) > 0
                                select p).FirstOrDefault();
                dbRecord.BaslamaTarihi = item.BaslamaTarihi;
                dbRecord.BitisTarihi = item.BitisTarihi;
                dbRecord.DegerGirildi = item.DegerGirildi;
                dbRecord.OlcumKararsizligi = item.OlcumKararsizligi;
                dbRecord.Olumlu = item.Olumlu;
                //dbRecord.Sonuc = string.Empty,//p.DegerRtf
            }
            AppManager.Db.SaveChanges();
            return string.Empty;
        }

        public string Insert(List<AnalizSonucModel> list, string numuneId)
        {
            try
            {
                foreach (var item in list)
                {
                    var dbRecord = new AnalizSonuc();
                    dbRecord.Id = Guid.NewGuid();
                    dbRecord.AnalizId = new Guid(item.AnalizId);
                    dbRecord.BaslamaTarihi = item.BaslamaTarihi;
                    dbRecord.BitisTarihi = item.BitisTarihi;
                    dbRecord.DegerGirildi = item.DegerGirildi;
                    dbRecord.OlcumKararsizligi = item.OlcumKararsizligi;
                    dbRecord.Olumlu = item.Olumlu;
                    dbRecord.NumuneAlimId = new Guid(numuneId);
                    //dbRecord.Sonuc = string.Empty,//p.DegerRtf
                    AppManager.Db.AnalizSonuc.Add(dbRecord);
                }
                AppManager.Db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message == null ? string.Empty : ex.Message;
            }
            return string.Empty;
        }

        public string Delete(List<AnalizSonucModel> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var dbRecord = (from p in AppManager.Db.AnalizSonuc
                                    where p.Id.CompareTo(new Guid(item.Id)) > 0
                                    select p).FirstOrDefault();
                    //dbRecord.Sonuc = string.Empty,//p.DegerRtf
                    AppManager.Db.AnalizSonuc.Remove(dbRecord);
                }
                AppManager.Db.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message == null ? string.Empty : ex.Message;
            }
            return string.Empty;
        }
    }

}
