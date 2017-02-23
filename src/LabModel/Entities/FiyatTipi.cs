using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class FiyatTipi : SimpleEntity
    {
        public FiyatTipi()
        {
            Kurumlar = new List<Kurum>();
        }

        [ForeignKey("Doviz_ID")]
        public virtual Doviz Doviz { get; set; }
        public virtual Guid Doviz_ID { get; set; }

        public virtual ICollection<Kurum> Kurumlar { get; set; } 
    }
}
