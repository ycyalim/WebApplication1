using System;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class DovizKur : EntityEdit
    {
        //[Required()]
        [ForeignKey("Doviz_ID")]
        public virtual Doviz Doviz { get; set; }
        public virtual Guid Doviz_ID { get; set; }

        //[Required()]
        public virtual DateTime Tarih { get; set; }

        //[Column(TypeName="money")]
        public virtual double Kur { get; set; }

    }
}
