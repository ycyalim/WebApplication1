using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public class PersonelImage : BaseEntity
    {
        [Column(TypeName="image")]
        public virtual byte[] Kase { get; set; }

        [Column(TypeName = "image")]
        public virtual byte[] KaseImzali { get; set; }
    }
}
