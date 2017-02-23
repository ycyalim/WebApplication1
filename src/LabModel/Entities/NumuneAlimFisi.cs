using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class NumuneAlimFisi : Entity
    {
        public NumuneAlimFisi()
        {
            Numuneler = new List<NumuneAlim>();
            AnalizAmaci = "";
        }

        private NumuneAlimTipi numuneAlimTipi;
        [ForeignKey("NumuneAlimTipi_ID")]
        public virtual NumuneAlimTipi NumuneAlimTipi 
        {
            get { return numuneAlimTipi; }
            set
            {
                if (HasChanged(numuneAlimTipi, value))
                {
                    NotifyPropertyChanging("NumuneAlimTipi");
                    numuneAlimTipi = value;
                    NotifyPropertyChanged("NumuneAlimTipi");
                }
            }
        }
        public virtual Guid NumuneAlimTipi_ID { get; set; }

        [StringLength(50)]
        public virtual string RaporNoBaslik { get; set; }

        public virtual int No { get; set; }

        [StringLength(50)]
        public virtual string RaporNo { get; set; }

        private DateTime tarih { get; set; }
        public virtual DateTime Tarih 
        {
            get { return tarih; }
            set
            {
                if (HasChanged(tarih, value))
                {
                    NotifyPropertyChanging("Tarih");
                    tarih = value;
                    NotifyPropertyChanged("Tarih");
                }
            }
        }
        public virtual DateTime LaboratuvaraUlasmaTarihi { get; set; }

        private DateTime? baslamaTarihi;
        public virtual DateTime? BaslamaTarihi
        {
            get { return baslamaTarihi; }
            set
            {
                if (HasChanged(baslamaTarihi, value))
                {
                    NotifyPropertyChanging("BaslamaTarihi");
                    baslamaTarihi = value;
                    NotifyPropertyChanged("BaslamaTarihi");
                }
            }
        }

        public void SetBaslamaTarihi(DateTime tarih)
        {
            baslamaTarihi = tarih;
        }

        private DateTime? bitisTarihi;
        public virtual DateTime? BitisTarihi
        {
            get { return bitisTarihi; }
            set
            {
                if (HasChanged(bitisTarihi, value))
                {
                    NotifyPropertyChanging("BitisTarihi");
                    bitisTarihi = value;
                    NotifyPropertyChanged("BitisTarihi");
                }
            }
        }

        public void SetBitisTarihi(DateTime tarih)
        {
            bitisTarihi = tarih;
        }

        //[Required()]
        [ForeignKey("NumuneyiAlan_ID")]
        public virtual Personel NumuneyiAlan { get; set; }
        public virtual Guid NumuneyiAlan_ID { get; set; }

        //[Required()]
        [ForeignKey("Kurum_ID")]
        public virtual Kurum Kurum { get; set; }
        public virtual Guid Kurum_ID { get; set; }

        [StringLength(50)]
        public virtual string AnalizAmaci { get; set; }

        public virtual bool RaporBasildi { get; set; }
        public virtual int RaporBasilmaSayisi { get; set; }
        
        //public virtual bool RaporWebGonderildi { get; set; }

        public virtual bool AnalizFormuBasildi { get; set; }
        public virtual bool KayitFormuBasildi { get; set; }
        public virtual bool DetayFormuBasildi { get; set; }
        public virtual bool KapakBasildi { get; set; }

        [ForeignKey("DezenfeksiyonTuru_ID")]
        public virtual DezenfeksiyonTuru DezenfeksiyonTuru { get; set; }
        public virtual Guid? DezenfeksiyonTuru_ID { get; set; }

        public virtual bool WebdeGoster { get; set; }

        [Column("MailGonderildi")]
        public virtual bool MailGonderildi { get; set; }
        public virtual bool? PdfOlusturuldu { get; set; }
        public virtual bool? SmsGonderildi { get; set; }

        public virtual ICollection<NumuneAlim> Numuneler { get; set; }

        [ForeignKey("NumuneAlimFis_ID")]
        public virtual ICollection<NumunePdf> Pdfler { get; set; }
        

    }
}
