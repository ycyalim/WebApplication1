using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Kodeks : SimpleEntity
    {
        public Kodeks()
        {
            Analizler = new List<Analiz>();
        }

        [ForeignKey("NumuneTipi_ID")]
        public virtual NumuneTipi NumuneTipi { get; set; }
        public virtual Guid NumuneTipi_ID { get; set; }        

        [StringLength(50)]
        public virtual string AnalizMethodu { get; set; }

        public virtual ICollection<Analiz> Analizler { get; set; }
    }
}
