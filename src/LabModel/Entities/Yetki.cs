using System.Collections.Generic;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Yetki : SimpleEntity
    {
        public Yetki()
        {
            Roller = new List<Rol>();
            Personeller = new List<Personel>();
        }

        public virtual ICollection<Rol> Roller { get; set; }
        public virtual ICollection<Personel> Personeller { get; set; }

    }
}
