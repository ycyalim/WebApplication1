using System.ComponentModel.DataAnnotations;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Doviz : SimpleEntity
    {
        [StringLength(50)]
        public virtual string MBKod { get; set; }
    }
}
