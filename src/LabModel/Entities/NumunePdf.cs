using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public class NumunePdf : EntityInsert
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Index(Order = 1)]
        public virtual int SiraNo { get; set; }

        public virtual DateTime Tarih { get; set; }

        [ForeignKey("NumuneAlimFis_ID")]
        public virtual NumuneAlimFisi NumuneAlimFis { get; set; }
        public virtual Guid? NumuneAlimFis_ID { get; set; }

        [ForeignKey("NumuneAlim_ID")]
        public virtual NumuneAlim NumuneAlim { get; set; }
        public virtual Guid? NumuneAlim_ID { get; set; }

        [ForeignKey("NumunePdf_ID")]
        public virtual ICollection<NumunePdfNumuneAlim> Numuneler { get; set; }

        [ForeignKey("NumunePdf_ID")]
        public virtual ICollection<NumunePdfEImza> Imzalar { get; set; }

        [StringLength(250)]
        public virtual string DosyaAd { get; set; }

        [StringLength(250)]
        public virtual string LocalDosyaAd { get; set; }

        [StringLength(50)]
        public virtual string Path { get; set; }

    }

    public partial class NumunePdfNumuneAlim : BaseEntity
    {
        public virtual Guid NumunePdf_ID { get; set; }
        public virtual NumunePdf NumunePdf { get; set; }

        [ForeignKey("NumuneAlim_ID")]
        public virtual NumuneAlim NumuneAlim { get; set; }
        public virtual Guid NumuneAlim_ID { get; set; }
    }

    public partial class NumunePdfEImza : BaseEntity
    {
        public virtual Guid NumunePdf_ID { get; set; }
        public virtual NumunePdf NumunePdf { get; set; }

        
        public virtual Guid EImza_ID { get; set; }
    }

}
