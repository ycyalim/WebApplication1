using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class RaporDizayn : Entity
    {
        [StringLength(50)]
        public virtual string Ad { get; set; }

        [StringLength(50)]
        public virtual string TipAd { get; set; }

        [StringLength(50)]
        public virtual string AltTip { get; set; }

        [Column(TypeName = "image")]
        public virtual byte[] Dizayn { get; set; }
    }
}
