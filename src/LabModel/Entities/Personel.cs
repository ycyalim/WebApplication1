using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Personel : SimpleEntity
    {
        public Personel()
        {
            Yetkiler = new List<Yetki>();
            GridLayouts = new List<GridLayout>();
        }

        [StringLength(50)]
        [Column(Order = 5)]
        public virtual string Ad { get; set; }

        [StringLength(50)]
        [Column(Order = 6)]
        public virtual string Soyad { get; set; }

        [StringLength(50)]
        public virtual string Sifre { get; set; }

        [StringLength(50)]
        public virtual string EMail { get; set; }

        [StringLength(50)]
        public virtual string EMailKullaniciAdi { get; set; }

        [StringLength(50)]
        public virtual string EMailSifre { get; set; }

        [StringLength(50)]
        public virtual string SmtpSunucu { get; set; }

        public virtual int SmtpPort { get; set; }
        public virtual bool SSL { get; set; }

        [StringLength(50)]
        public virtual string CC { get; set; }

        [ForeignKey("Rol_ID")]
        public virtual Rol Rol { get; set; }        
        public virtual Guid? Rol_ID { get; set; }

        [ForeignKey("Image_ID")]
        public virtual PersonelImage Image { get; set; }
        public virtual Guid? Image_ID { get; set; }

        public virtual ICollection<Yetki> Yetkiler { get; set; }
        public virtual ICollection<GridLayout> GridLayouts { get; set; }
    }
}
