using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabKhufu.Model.Entities
{
    public class NumuneTipiEImza
    {
        [Key, Column(Order = 1)]
        public Guid NumuneTipi_ID { get; set; }

        [Key, Column(Order = 2)]
        public Guid EImza_ID { get; set; }
    }
}
