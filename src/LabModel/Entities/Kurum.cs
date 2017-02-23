using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Kurum : SimpleEntity 
    {
        //[Required()]
        [ForeignKey("FiyatTipi_ID")]
        public virtual FiyatTipi FiyatTipi { get; set; }
        public virtual Guid? FiyatTipi_ID { get; set; }

        [ForeignKey("Fihrist_ID")]
        public virtual Fihrist Fihrist { get; set; }
        public virtual Guid? Fihrist_ID { get; set; }

        [StringLength(50)]
        public virtual string VergiDairesi { get; set; }
        [StringLength(50)]
        public virtual string VergiNo { get; set; }

        [StringLength(50)]
        public virtual string WebUsername { get; set; }

        [StringLength(50)]
        [Column("WebPassword")]
        public virtual string WebPassword { get; set; }

        [StringLength(50)]
        public virtual string BakanlikNo { get; set; }

        [NotMapped]
        public string KodAdres 
        {
            get { return Kod + " / " + (Fihrist.Adres ?? ""); }
        }

        [NotMapped]
        public string AciklamaAdres
        {
            get { return ((Aciklama ?? "") + " / " + (Fihrist.Adres ?? "")).Trim(); }
        }

        [NotMapped]
        public List<string> TempPdfNames { get; set; }

    }
}
