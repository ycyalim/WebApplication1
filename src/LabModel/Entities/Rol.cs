using System.Collections.Generic;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Rol : SimpleEntity
    {
        public Rol()
        {
            Yetkiler = new List<Yetki>();
            Personeller = new List<Personel>();
        }

        public virtual ICollection<Yetki> Yetkiler { get; set; }
        public virtual ICollection<Personel> Personeller { get; set; }
    }
}
