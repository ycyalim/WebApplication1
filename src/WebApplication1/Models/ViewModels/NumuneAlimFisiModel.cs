using KhufuMobile.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhufuMobile.Models.ViewModels
{
    public class NumuneAlimFisiModel
    {
        public string Test { get; set; }
        private List<SelectListItem> _kurumlar = null;
        private List<SelectListItem> _personeller = null;

        public NumuneAlimFisi Numune { get; set; }
        public NumuneAlimFisi Numune2 { get; set; }

        public List<SelectListItem> KurumlarList
        {
            get
            {
                if (_kurumlar == null)
                    _kurumlar = (from p in AppManager.Db.Kurum
                                 select new SelectListItem
                                 {
                                     Value = Convert.ToString(p.Id),
                                     Text = p.Aciklama
                                 }).ToList();
                return _kurumlar;
            }
        }

        public List<SelectListItem> PersonelList
        {
            get
            {
                if (_personeller == null)
                    _personeller = (from p in AppManager.Db.Personel
                                    select new SelectListItem
                                    {
                                        Value = Convert.ToString(p.Id),
                                        Text = p.Ad
                                    }).ToList();
                return _personeller;
            }
        }


    }

}
