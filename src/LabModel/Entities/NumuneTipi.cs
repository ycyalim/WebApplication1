using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;
 
namespace LabKhufu.Model.Entities
{
    public class NumuneTipi : SimpleEntity
    {
        public NumuneTipi()
        {
            
        }

        [ForeignKey("NumuneAlimTipi_ID")]
        public virtual NumuneAlimTipi NumuneAlimTipi { get; set; }
        public virtual Guid NumuneAlimTipi_ID { get; set; }

        public virtual EnumNumuneTipi Tip { get; set; }

        [ForeignKey("RaporDizayn_ID")]
        public virtual RaporDizayn RaporDizayn { get; set; }
        public virtual Guid? RaporDizayn_ID { get; set; }

    
        public virtual double OnDegerMiktar { get; set; }

        [StringLength(50)]
        public virtual string OnDegerBirim { get; set; }

        public virtual double OndegerSicaklik { get; set; }

        [StringLength(100)]
        public virtual string OnDegerKabinCinsi { get; set; }

        [StringLength(100)]
        public virtual string OnDegerAlinmaSekli { get; set; }

        [StringLength(100)]
        public virtual string OnDegerAmbalaji { get; set; }

        [StringLength(50)]
        public virtual string OnDegerSeriPartiNo { get; set; }

        [StringLength(50)]
        public virtual string OnDegerUreticiFirmaAdi { get; set; }

        [StringLength(50)]
        public virtual string OnDegerUretimSKTarihi { get; set; }

        [StringLength(50)]
        public virtual string OnDegerBosMiktarBirim { get; set; }
        
        public virtual int OnDegerAnalizGun { get; set; }

        public virtual int OnDegerAnalizBaslamaGun { get; set; }

        [StringLength(50)]
        public virtual string AnaliziIstenenParametreler { get; set; }

        [StringLength(50)]
        public virtual string IstenilenAnalizler { get; set; }

        public override string ToString()
        {
            return Kod;
        }
    }
}
