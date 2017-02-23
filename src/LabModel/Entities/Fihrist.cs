using System.ComponentModel.DataAnnotations;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Fihrist : Entity
    {
        [StringLength(50)]
        public virtual string Ad { get; set; }
        [StringLength(50)]
        public virtual string Soyad { get; set; }
        [StringLength(16)]
        public virtual string EvTelefonu { get; set; }
        [StringLength(16)]
        public virtual string IsTelefonu { get; set; }
        [StringLength(100)]
        public virtual string CepTelefonu { get; set; }
        [StringLength(100)]
        public virtual string CepTelefonu2 { get; set; }
        [StringLength(16)]
        public virtual string Fax { get; set; }
        [StringLength(250)]
        public virtual string Adres { get; set; }

        [StringLength(250)]
        public virtual string EMail { get; set; }

        [StringLength(250)]
        public virtual string EMail2 { get; set; }

        [EnumDataType(typeof(FihristTipi))]
        public virtual FihristTipi Tip { get; set; }
    }
}
