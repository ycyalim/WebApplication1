using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class GridLayout : BaseEntity
    {
        [ForeignKey("Personel_ID")]
        public virtual Personel Personel { get; set; }
        public virtual Guid Personel_ID { get; set; }

        //[Required()]
        [StringLength(150)]
        public virtual string Form { get; set; }

        //[Required()]
        [StringLength(150)]
        public virtual string GridView { get; set; }

        [Column(TypeName = "image")]
        public virtual byte[] Layout { get; set; }

        [Column(TypeName = "image")]
        public virtual byte[] ViewInfo { get; set; }


    }
}
