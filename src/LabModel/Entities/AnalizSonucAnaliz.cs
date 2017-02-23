using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class AnalizSonucAnaliz : SimpleEntity
    {
        public AnalizSonucAnaliz()
        {
        }

        public AnalizSonucAnaliz(Analiz analiz, AnalizSonuc analizSonuc)
        {
            this.Aciklama = analiz.Aciklama;
            this.AciklamaRtf = analiz.AciklamaRtf;
            this.Akredite = analiz.Akredite;
            this.AltDeger = analiz.AltDeger;
            this.AnalizSonuc_ID = analizSonuc.ID;
            this.AnalizTipi_ID = analiz.AnalizTipi_ID;
            this.Birim = analiz.Birim;
            this.BirimRtf = analiz.BirimRtf;
            this.KisaKod = analiz.KisaKod;
            this.Kod = analiz.Kod;
            this.KullanilanMethod = analiz.KullanilanMethod;
            this.NormalDeger = analiz.NormalDeger;
            this.NormalDegerRtf = analiz.NormalDegerRtf;
            this.SifirDegerBirim = analiz.SifirDegerBirim;
            this.SifirDegerBirimRtf = analiz.SifirDegerBirimRtf;
            this.SiraNo = analiz.SiraNo;
            this.UstDeger = analiz.UstDeger;

            this.AnalizTipi = analiz.AnalizTipi;
            this.OlcumKararsizligi = analiz.OlcumKararsizligi;
        }

        [Column(Order = 1)]
        [Key]
        public virtual Guid AnalizSonuc_ID { get; set; }

        [ForeignKey("AnalizSonuc_ID")]
        public virtual AnalizSonuc AnalizSonuc { get; set; }

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
