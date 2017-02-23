using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public class NumuneAlimTipi : SimpleEntity 
    {        
        public virtual EnumNumuneAlimTipi Tip { get; set; }

        [StringLength(50)]
        public virtual string RaporNoBaslik { get; set; }

        public virtual int SonRaporNo { get; set; }

        public virtual int SonNumuneKayitNo { get; set; }

        public virtual string OnDegerAnalizAmaci { get; set; }

        public virtual int OnDegerAnalizGun { get; set; }

        public virtual int OnDegerAnalizBaslamaGun { get; set; }

        public override string ToString()
        {
            return Kod;
        }
    }
}
