using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public class ParametreImage : BaseEntity
    {
        [Column(TypeName="image")]
        public virtual byte[] Antet { get; set; }
    }
}
