using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class Analiz : SimpleEntity 
    {
        public Analiz()
        {
            NumuneTipleri = new List<NumuneTipi>();
        }

        public virtual ICollection<NumuneTipi> NumuneTipleri { get; set; }

        [NotMapped]
        public string AciklamaAkrediteli
        {
            get
            {
                if (Akredite)
                    return "(*)" + (Aciklama ?? "");
                return (Aciklama ?? "");
            }
        }

        [StringLength(50)]
        public virtual string KisaKod { get; set; }

        [ForeignKey("AnalizTipi_ID")]
        public virtual AnalizTipi AnalizTipi { get; set; }
        public virtual Guid? AnalizTipi_ID { get; set; }

        [StringLength(50)]
        public virtual string Birim { get; set; }

        [StringLength(50)]
        public virtual string KullanilanMethod { get; set; }

        [StringLength(50)]
        public virtual string NormalDeger { get; set; }

        [StringLength(50)]
        public virtual string SifirDegerBirim { get; set; }

        [StringLength(50)]
        public virtual string OlcumKararsizligi { get; set; }

        public virtual string AciklamaRtf { get; set; }

        public virtual string SifirDegerBirimRtf { get; set; }

        public virtual string NormalDegerRtf { get; set; }

        public virtual string BirimRtf { get; set; }

        public virtual bool Akredite { get; set; }

        public virtual double? AltDeger { get; set; }
        public virtual double? UstDeger { get; set; }

    }
}
