using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;

namespace LabKhufu.Model.Entities
{
    public partial class NumuneAlim : Entity
    {
        public NumuneAlim()
        {
            Sonuclar = new List<AnalizSonuc>();
        }

        [ForeignKey("NumuneAlimFis_ID")]
        public virtual NumuneAlimFisi NumuneAlimFis { get; set; }
        public virtual Guid NumuneAlimFis_ID { get; set; }
        
        public virtual int SiraNo { get; set; }

        public virtual int KayitNo { get; set; }

        private NumuneTipi numuneTipi;
        [ForeignKey("NumuneTipi_ID")]
        public virtual NumuneTipi NumuneTipi 
        {
            get { return numuneTipi; }
            set
            {
                if (HasChanged(numuneTipi, value))
                {
                    NotifyPropertyChanging("NumuneTipi");
                    numuneTipi = value;
                    NotifyPropertyChanged("NumuneTipi");
                }
            }
        }
        public virtual Guid NumuneTipi_ID { get; set; }

        private string numuneAdi;
        [StringLength(50)]
        public virtual string NumuneAdi
        {
            get { return numuneAdi; }
            set
            {
                if (HasChanged(numuneAdi, value))
                {
                    NotifyPropertyChanging("NumuneAdi");
                    numuneAdi = value;
                    NotifyPropertyChanged("NumuneAdi");
                }
            }
        }

        public virtual double Miktar { get; set; }
        [StringLength(50)]
        public virtual string Birim { get; set; }
        
        public virtual double Sicaklik { get; set; }

        [StringLength(50)]
        public virtual string AlimYeri { get; set; }

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

        [StringLength(50)]
        public virtual string BakanlikRaporNo { get; set; }

        public virtual NumuneGida NumuneGida { get; set; }
        public virtual NumuneHavuzSuyu NumuneHavuzSuyu { get; set; }

        [StringLength(100)]
        public virtual string Aciklama { get; set; }

        private Kodeks kodeks;
        [ForeignKey("Kodeks_ID")]
        public virtual Kodeks Kodeks 
        {
            get { return kodeks; }
            set
            {
                if (HasChanged(kodeks, value))
                {
                    NotifyPropertyChanging("Kodeks");
                    kodeks = value;
                    NotifyPropertyChanged("Kodeks");
                }
            }
        }
        public virtual Guid? Kodeks_ID { get; set; }

        [StringLength(250)]
        public virtual string IstenenAnalizler { get; set; }

        public virtual int ToplamAnalizSayisi { get; set; }
        public virtual int SonuclananAnalizSayisi { get; set; }
        public virtual int BekleyenAnalizSayisi { get; set; }

        public virtual bool RaporBasildi { get; set; }
        public virtual int RaporBasilmaSayisi { get; set; }

        //public virtual bool RaporWebGonderildi { get; set; }

        public virtual bool AnalizFormuBasildi { get; set; }
        public virtual bool KayitFormuBasildi { get; set; }
        public virtual bool DetayFormuBasildi { get; set; }

        public virtual bool WebdeGoster { get; set; }

        [Column("MailGonderildi")]
        public virtual bool MailGonderildi { get; set; }
        public virtual bool? PdfOlusturuldu { get; set; }
        public virtual bool? SmsGonderildi { get; set; }

        private bool olumlu;
        public virtual bool Olumlu
        {
            get { return olumlu; }
            set
            {
                if (HasChanged(olumlu, value))
                {
                    NotifyPropertyChanging("Olumlu");
                    olumlu = value;
                    NotifyPropertyChanged("Olumlu");
                }
            }
        }

        public virtual ICollection<AnalizSonuc> Sonuclar { get; set; }

        public override string ToString()
        {
            return NumuneAdi;
        }
    }
}
