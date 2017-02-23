using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Parametre
    {
        public Guid Id { get; set; }
        public string FirmaKodu { get; set; }
        public string FirmaAd { get; set; }
        public int SonFaturaNo { get; set; }
        public bool KdvDahil { get; set; }
        public int KdvOrani { get; set; }
        public Guid YerelDovizId { get; set; }
        public string Dbversion { get; set; }
        public bool Dbguncelleniyor { get; set; }
        public int TerminalSayisi { get; set; }
        public bool OtoTerminalLic { get; set; }
        public byte[] LicenceKey { get; set; }
        public Guid? FihristId { get; set; }
        public Guid? ImageId { get; set; }
        public int SonucGirisSonGun { get; set; }
        public string AnalizAciklamaRtf { get; set; }
        public string AnalizSifirDegerBirimRtf { get; set; }
        public string AnalizNormalDegerRtf { get; set; }
        public string AnalizSonucDegerRtf { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }
        public Guid? HavuzSuyuDezenfeksiyonTuruId { get; set; }
        public bool EimzalamaAktif { get; set; }
        public string PdfSaklamaYolu { get; set; }
        public string EimzaYazi { get; set; }
        public string EimzaReason { get; set; }
        public string EimzaLocation { get; set; }
        public float EimzaLowerLeftX { get; set; }
        public float EimzaLowerLeftY { get; set; }
        public float EimzaUpperRightX { get; set; }
        public float EimzaUpperRightY { get; set; }
        public string EimzaLibraryName { get; set; }
        public string EimzaTokenLabel { get; set; }
        public string SmsServisKullaniciAdi { get; set; }
        public string SmsServisSifre { get; set; }
        public bool SmsAktif { get; set; }
        public string SmsMesajFormat { get; set; }
        public string MailKonuFormat { get; set; }
        public string MailFormat { get; set; }
        public string PdfWebAdresi { get; set; }
        public bool PdfFtpyeKaydet { get; set; }
        public string PdfFtpHostName { get; set; }
        public string PdfFtpPath { get; set; }
        public string PdfFtpUsername { get; set; }
        public string PdfFtpPassword { get; set; }
        public bool MaileRaporEklensin { get; set; }
        public bool EimzaYazisiEkle { get; set; }
        public bool FisBaslamaBitisTarihiKullan { get; set; }
        public bool PdflereKapakEkle { get; set; }
        public string PdfDosyaAdiFormat { get; set; }

        public virtual Personel Degistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual Fihrist Fihrist { get; set; }
        public virtual DezenfeksiyonTuru HavuzSuyuDezenfeksiyonTuru { get; set; }
        public virtual ParametreImage Image { get; set; }
        public virtual Doviz YerelDoviz { get; set; }
    }
}
