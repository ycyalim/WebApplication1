using System;
using System.ComponentModel.DataAnnotations;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class NumuneHavuzSuyu : BaseEntity
    {
        [Key]
        public virtual Guid NumuneAlim_ID { get; set; }
        public virtual NumuneAlim NumuneAlim { get; set; }

        #region HavuzSuyu
        [StringLength(150)]
        public virtual string KabinCinsi { get; set; }

        [StringLength(100)]
        public virtual string AlinmaSekli { get; set; }

        public virtual double pH { get; set; }
        public virtual double SerbestCL { get; set; }
        public virtual double BagliCL { get; set; }
        public virtual double H2O2 { get; set; }
        public virtual double Biguanid { get; set; }
        #endregion 

    }
}
