using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;

namespace LabKhufu.Model.Entities
{
    public partial class NumuneAlimFisi 
    {
        private bool secim;
        [NotMapped]
        public bool Secim 
        {
            get { return secim; }
            set
            {
                if (HasChanged(secim, value))
                {
                    NotifyPropertyChanging("Secim");
                    secim = value;
                    foreach (var numune in Numuneler)
                    {
                        numune.Secim = secim;
                    }
                    NotifyPropertyChanged("Secim");
                }
            }
        }

        [NotMapped]
        public string RaporNumaralari
        {
            get
            {
                if (NumuneAlimlari.Count == 0) return "";

                int minNumuneAlimNo = NumuneAlimlari.Min(x => x.SiraNo);
                int maxNumuneAlimNo = NumuneAlimlari.Max(x => x.SiraNo);

                return RaporNo + "-" + minNumuneAlimNo.ToString().PadLeft(2, '0') + "/" +
                    RaporNo + "-" + maxNumuneAlimNo.ToString().PadLeft(2, '0');
            }
        }

        [NotMapped]
        public string BaslangicRaporNo
        {
            get
            {
                if (NumuneAlimlari.Count == 0) return "";

                int minNumuneAlimNo = NumuneAlimlari.Min(x => x.SiraNo);

                return RaporNo + "-" + minNumuneAlimNo.ToString().PadLeft(2, '0');
            }
        }

        [NotMapped]
        public string BitisRaporNo
        {
            get
            {
                if (NumuneAlimlari.Count == 0) return "";

                int maxNumuneAlimNo = NumuneAlimlari.Max(x => x.SiraNo);

                return RaporNo + "-" + maxNumuneAlimNo.ToString().PadLeft(2, '0');
            }
        }

        [NotMapped]
        public string RaporSayfaBilgisi
        {
            get
            {
                return NumuneAlimlari.Count.ToString() + " ADET NUMUNE RAPORU/1'ER SAYFA";
            }
        }

        [NotMapped]
        public NumuneAlim IlkNumune
        {
            get
            {
                return NumuneAlimlari.Select(x => x).OrderBy(x => x.SiraNo).FirstOrDefault();
            }
        }

        [NotMapped]
        public List<NumuneAlim> NumuneAlimlari
        {
            get { return Numuneler.OrderBy(x => x.SiraNo).ToList(); }
        }

        [NotMapped]
        public List<NumuneAlim> SeciliNumuneAlimlari
        {
            get { return Numuneler.Where(x => x.Secim).OrderBy(x => x.SiraNo).ToList(); }
        }

        [NotMapped]
        public List<Guid> SeciliNumuneAlimIDleri
        {
            get { return Numuneler.Where(x => x.Secim).OrderBy(x => x.SiraNo).Select(x => x.ID).ToList(); }
        }

        [NotMapped]
        public bool Hata { get; set; }

        private string hataMesaj;
        [NotMapped]
        public string HataMesaj
        {
            get { return hataMesaj; }
            set
            {
                hataMesaj = value;
                Hata = hataMesaj.Trim().Length > 0;
            }
        }

        public NumunePdf SonPdf
        {
            get
            {
                if (Pdfler.Count == 0)
                    return null;

                return Pdfler.OrderByDescending(x => x.SiraNo).First();
            }
        }

        public string SonPdfDosyaAd
        {
            get
            {
                return SonPdf == null ? "" : SonPdf.DosyaAd;
            }
        }

        public bool PdfDosyasiVarMi(Parametre p)
        {
            if (PdfOlusturuldu.HasValue && PdfOlusturuldu.Value)
            {
                if (!string.IsNullOrEmpty(SonPdfDosyaAd))
                {
                    if (!p.PdfFtpyeKaydet)
                        return File.Exists(SonPdfDosyaAd);

                    return false;
                    //return FtpUtil.FileExist(p.PdfFtpHostName, p.PdfFtpUsername, p.PdfFtpPassword, SonPdfDosyaAd);
                }
            }

            return false;
        }

        public string PdfDosyaAdi(string _dosyaAdFormat, int revision = 0)
        {
            string dosyaAdFormat = _dosyaAdFormat;
            string tarihFormat = "dd_MM_yyyy";
            //012345678901234567890
            if (dosyaAdFormat.Contains("{tarih"))
            {
                int tarihFormatNdx = dosyaAdFormat.IndexOf("{tarih:");
                int guzelParantezNdx = dosyaAdFormat.IndexOf("}", tarihFormatNdx);
                if (guzelParantezNdx > 1)
                {
                    tarihFormat = dosyaAdFormat.Substring(tarihFormatNdx + 7, guzelParantezNdx - (tarihFormatNdx + 7));
                    dosyaAdFormat = dosyaAdFormat.Substring(0, tarihFormatNdx) + "{tarih}" +
                        dosyaAdFormat.Substring(guzelParantezNdx + 1);
                }
            }

            dosyaAdFormat = dosyaAdFormat.ToLower();

            string resultFile = dosyaAdFormat.Replace("{raporno}", RaporNo);
            resultFile = resultFile.Replace("{kurumaciklama}", Kurum.Aciklama);
            resultFile = resultFile.Replace("{tarih}", string.Format("{0:" + tarihFormat + "}", Tarih));

            // string.Format("{0:dd_MM_yyyy}", fis.SeciliNumuneAlimlari.FirstOrDefault().NumuneAlimFis.Tarih) + "_" + fis.RaporNo + ".pdf"

            //resultFile = Utils.Util.RemoveInvalidFielNameChars(resultFile).Replace(" ", "_");
            //string resultFile = Util.RemoveInvalidFielNameChars(fis.RaporNo + " " + fis.Kurum.Aciklama + ".pdf").Replace(" ", "_");

            if (revision > 0)
                resultFile = resultFile + "_Rev" + revision;

            return resultFile + ".pdf";
        }

        public string PdfSaklamaYolu(string pdfSaklamaYolu)
        {
            return string.Empty;
            //return Utils.Util.RemoveInvalidPathChars(Path.Combine(pdfSaklamaYolu, Kurum.Aciklama.Trim(), NumuneAlimTipi.Kod.Trim())).Replace(" ", "_");
            //string pdfPath = Util.RemoveInvalidPathChars(Path.Combine(App.Parametre.PdfSaklamaYolu, fis.Kurum.Aciklama)).Replace(" ", "_");
        }

    }
}
