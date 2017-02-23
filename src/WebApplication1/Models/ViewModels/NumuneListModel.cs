using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhufuMobile.Models;

namespace KhufuMobile.Models.ViewModels
{ 
    public class NumuneListModel
    {
        public NumuneAlimTipi Tipi { get; set; }
        public List<NumuneAlimFisi> List{get;set;}
        public string SelectedGuid { get; set; }
    }
}
