using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabKhufu.Model.Entities.Base
{

    public abstract class Entity : EntityEdit
    {
        //[Timestamp]
        //[ConcurrencyCheck]
        //[Timestamp]
        //public virtual byte[] TimeStamp { get; set; }

        public virtual bool KullanimDisi { get; set; }                
    }

    public abstract class EntityEdit : EntityInsert
    {
        [ForeignKey("Degistiren_ID")]
        public virtual Personel Degistiren { get; set; }
        public virtual Guid? Degistiren_ID { get; set; }

        public virtual DateTime? DegistirmeTarihi { get; set; }
    }

    public abstract class EntityInsert : BaseEntity
    {
        [ForeignKey("Ekleyen_ID")]
        public virtual Personel Ekleyen { get; set; }
        public virtual Guid? Ekleyen_ID { get; set; }

        public virtual DateTime? EklemeTarihi { get; set; }
    }


}
