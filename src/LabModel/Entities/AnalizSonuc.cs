using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class AnalizSonuc : EntityEdit
    {
        public AnalizSonuc()
        {
            Deger = "";
        }

        public AnalizSonuc(Analiz analiz, NumuneAlim numune) : this()
        {
            AnalizTanim = analiz;
            Analiz = new AnalizSonucAnaliz(analiz, this);
            OlcumKararsizligi = analiz.OlcumKararsizligi;
            Olumlu = true;
            BaslamaTarihi = numune.BaslamaTarihi;
            BitisTarihi = numune.BitisTarihi;
        }

        [ForeignKey("NumuneAlim_ID")]
        public virtual NumuneAlim NumuneAlim { get; set; }
        public virtual Guid NumuneAlim_ID { get; set; }

        [ForeignKey("Analiz_ID")]
        public virtual Analiz AnalizTanim { get; set; }
        public virtual Guid Analiz_ID { get; set; }

        public virtual AnalizSonucAnaliz Analiz { get; set; }

        [StringLength(50)]
        public virtual string Deger { get; set; }

        public virtual string DegerRtf { get; set; }

        public virtual bool DegerGirildi { get; set; }

        public virtual double? DegerSayisal { get; set; }

        [StringLength(50)]
        public virtual string OlcumKararsizligi { get; set; }

        private bool _olumlu;
        public virtual bool Olumlu
        {
            get { return _olumlu; }
            set
            {
                _olumlu = value;

                if (NumuneAlim != null)
                    NumuneAlim.Olumlu = (NumuneAlim.OlumsuzAnalizSayisi == 0); 
            }
        }

        public virtual DateTime? BaslamaTarihi { get; set; }
        public virtual DateTime? BitisTarihi { get; set; }

    }
}
