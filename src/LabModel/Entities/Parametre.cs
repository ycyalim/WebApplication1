using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabKhufu.Model.Entities.Base;
 
namespace LabKhufu.Model.Entities
{
    public partial class Parametre : EntityEdit
    {
        //[Required()]
        [StringLength(50)]
        public virtual string FirmaKodu { get; set; }
        //[Required()]
        [StringLength(50)]
        public virtual string FirmaAd { get; set; }
        
        public virtual int SonFaturaNo { get; set; }

        public virtual bool KdvDahil { get; set; }
        public virtual int KdvOrani { get; set; }

        //[Required()]
        [ForeignKey("YerelDoviz_ID")]
        public virtual Doviz YerelDoviz { get; set; }
        public virtual Guid YerelDoviz_ID { get; set; }

        [StringLength(50)]
        public virtual string DBVersion { get; set; }
        public virtual bool DBGuncelleniyor { get; set; }

        public virtual int TerminalSayisi { get; set; }
        public virtual bool OtoTerminalLic { get; set; }
        public virtual byte[] LicenceKey { get; set; }

        [ForeignKey("Fihrist_ID")]
        public virtual Fihrist Fihrist { get; set; }
        public virtual Guid? Fihrist_ID { get; set; }

        [ForeignKey("Image_ID")]
        public virtual ParametreImage Image { get; set; }
        public virtual Guid? Image_ID { get; set; }

        public int SonucGirisSonGun { get; set; }

        public virtual string AnalizAciklamaRtf { get; set; }
        public virtual string AnalizSifirDegerBirimRtf { get; set; }
        public virtual string AnalizNormalDegerRtf { get; set; }

        public virtual string AnalizSonucDegerRtf { get; set; }

        [ForeignKey("HavuzSuyuDezenfeksiyonTuru_ID")]
        public virtual DezenfeksiyonTuru HavuzSuyuDezenfeksiyonTuru { get; set; }
        public virtual Guid? HavuzSuyuDezenfeksiyonTuru_ID { get; set; }

        public virtual bool EImzalamaAktif { get; set; }

        [StringLength(150)]
        [Required(AllowEmptyStrings = true)]
        public virtual string PdfSaklamaYolu { get; set; }

        [StringLength(250)]
        [Required(AllowEmptyStrings = false)]
        public virtual string EImzaYazi { get; set; }
        [StringLength(150)]
        [Required(AllowEmptyStrings = false)]
        public virtual string EImzaReason { get; set; }
        [StringLength(150)]
        [Required(AllowEmptyStrings = true)]
        public virtual string EImzaLocation { get; set; }

        public virtual float EImzaLowerLeftX { get; set; }
        public virtual float EImzaLowerLeftY { get; set; }
        public virtual float EImzaUpperRightX { get; set; }
        public virtual float EImzaUpperRightY { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public virtual string EImzaLibraryName { get; set; }
        [StringLength(50)]
        [Required(AllowEmptyStrings = false)]
        public virtual string EImzaTokenLabel { get; set; }

        public virtual bool SmsAktif { get; set; }

        [StringLength(50)]
        public string SmsServisKullaniciAdi { get; set; }

        [StringLength(50)]
        public string SmsServisSifre { get; set; }

        [StringLength(140)]
        public string SmsMesajFormat { get; set; }

        [StringLength(250)]
        public string MailKonuFormat { get; set; }

        public string MailFormat { get; set; }

        [StringLength(250)]
        public string PdfWebAdresi { get; set; }

        public bool PdfFtpyeKaydet { get; set; }

        [StringLength(50)]
        public string PdfFtpHostName { get; set; }

        [StringLength(50)]
        public string PdfFtpPath { get; set; }

        [StringLength(50)]
        public string PdfFtpUsername { get; set; }

        [StringLength(50)]
        public string PdfFtpPassword { get; set; }

        public bool MaileRaporEklensin { get; set; }

        public bool EImzaYazisiEkle { get; set; }

        public bool FisBaslamaBitisTarihiKullan { get; set; }

        public bool PdflereKapakEkle { get; set; }

        private string _pdfDosyaAdiFormat;
        [StringLength(150)]
        public string PdfDosyaAdiFormat
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_pdfDosyaAdiFormat))
                    return "{tarih:dd_MM_yyyy}_{raporno}";

                return _pdfDosyaAdiFormat;
            }
            set { _pdfDosyaAdiFormat = value; }
        }

        public Parametre()
        {
            //EImzaLowerLeftX = EImzaLowerLeftX == 0 ? 13 : EImzaLowerLeftX;
            //EImzaLowerLeftY = EImzaLowerLeftY == 0 ? 42 : EImzaLowerLeftY;
            //EImzaUpperRightX = EImzaUpperRightX == 0 ? 300 : EImzaUpperRightX;
            //EImzaUpperRightY = EImzaUpperRightY == 0 ? 62 : EImzaUpperRightY;

            //EImzaLibraryName = string.IsNullOrEmpty(EImzaLibraryName) ? "akisp11.dll" : EImzaLibraryName;
            //EImzaTokenLabel = string.IsNullOrEmpty(EImzaTokenLabel) ? "Akis" : EImzaTokenLabel;

            //if (string.IsNullOrEmpty(EImzaYazi))
            //    EImzaYazi = "Bu Belge \"{0}\" tarafından 5070 sayılı elektronik imza kanununa göre güvenli elektronik imza ile imzalanmıştır.";

            //if (string.IsNullOrEmpty(EImzaReason))
            //    EImzaReason = "Lab Khufu Rapor İmzalama";

            //if (string.IsNullOrEmpty(EImzaLocation))
            //    EImzaLocation = FirmaAd;
        }
    }
}
