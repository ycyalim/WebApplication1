using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class NumuneGida : BaseEntity 
    {
        [Key]
        public virtual Guid NumuneAlim_ID { get; set; }
        public virtual NumuneAlim NumuneAlim { get; set; }
        
        #region Gıda
        [StringLength(50)]
        public virtual string Cinsi { get; set; }

        [NotMapped]
        public string CinsiAlimYeri
        {
            get
            {
                string s = (Cinsi ?? "");
                if (!string.IsNullOrWhiteSpace(NumuneAlim.AlimYeri) && NumuneAlim.AlimYeri.Trim().Length > 0)
                    s += " (" + (NumuneAlim.AlimYeri ?? "") + ")";
                return s;
            }
        }

        [StringLength(50)]
        public virtual string Ambalaji { get; set; }

        private DateTime? uretimTarihi;
        public virtual DateTime? UretimTarihi 
        {
            get { return uretimTarihi; }
            set
            {
                if (HasChanged(uretimTarihi, value))
                {
                    NotifyPropertyChanging("UretimTarihi");
                    uretimTarihi = value;
                    UretimSKTarihi = uretimSonKullanmaTarihi();
                    NotifyPropertyChanged("UretimTarihi");                    
                }
            }
        }

        private DateTime? sonKullanimTarihi;
        public virtual DateTime? SonKullanimTarihi
        {
            get { return sonKullanimTarihi; }
            set
            {
                if (HasChanged(sonKullanimTarihi, value))
                {
                    NotifyPropertyChanging("SonKullanimTarihi");
                    sonKullanimTarihi = value;
                    UretimSKTarihi = uretimSonKullanmaTarihi();
                    NotifyPropertyChanged("SonKullanimTarihi");
                }
            }
        }


        [StringLength(50)]
        public virtual string UretimSKTarihi { get; set; }

        [StringLength(50)]
        public virtual string SeriPartiNo { get; set; }

        [StringLength(50)]
        public virtual string UreticiFirmaAdi { get; set; }

        private string uretimSonKullanmaTarihi()
        {
            string s = "";

            if (UretimTarihi.HasValue)
                s += UretimTarihi.Value.ToString("dd.MM.yyyy");

            if (SonKullanimTarihi.HasValue)
                s += " / " + SonKullanimTarihi.Value.ToString("dd.MM.yyyy");

            return s;
        }

        #endregion

    }
}
