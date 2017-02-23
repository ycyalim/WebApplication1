using System;
using System.Collections.Generic;

namespace KhufuMobile.Models
{
    public partial class Personel
    {
        public Personel()
        {
            AnalizDegistiren = new HashSet<Analiz>();
            AnalizEkleyen = new HashSet<Analiz>();
            AnalizSonucDegistiren = new HashSet<AnalizSonuc>();
            AnalizSonucEkleyen = new HashSet<AnalizSonuc>();
            AnalizSonucAnalizDegistiren = new HashSet<AnalizSonucAnaliz>();
            AnalizSonucAnalizEkleyen = new HashSet<AnalizSonucAnaliz>();
            AnalizTipiDegistiren = new HashSet<AnalizTipi>();
            AnalizTipiEkleyen = new HashSet<AnalizTipi>();
            DezenfeksiyonTuruDegistiren = new HashSet<DezenfeksiyonTuru>();
            DezenfeksiyonTuruEkleyen = new HashSet<DezenfeksiyonTuru>();
            DovizDegistiren = new HashSet<Doviz>();
            DovizEkleyen = new HashSet<Doviz>();
            DovizKurDegistiren = new HashSet<DovizKur>();
            DovizKurEkleyen = new HashSet<DovizKur>();
            EimzaDegistiren = new HashSet<Eimza>();
            EimzaEkleyen = new HashSet<Eimza>();
            FihristDegistiren = new HashSet<Fihrist>();
            FihristEkleyen = new HashSet<Fihrist>();
            FiyatTipiDegistiren = new HashSet<FiyatTipi>();
            FiyatTipiEkleyen = new HashSet<FiyatTipi>();
            GridLayout = new HashSet<GridLayout>();
            IletiDegistiren = new HashSet<Ileti>();
            IletiEkleyen = new HashSet<Ileti>();
            KodeksDegistiren = new HashSet<Kodeks>();
            KodeksEkleyen = new HashSet<Kodeks>();
            KurumDegistiren = new HashSet<Kurum>();
            KurumEkleyen = new HashSet<Kurum>();
            NumuneAlimDegistiren = new HashSet<NumuneAlim>();
            NumuneAlimEkleyen = new HashSet<NumuneAlim>();
            NumuneAlimFisiDegistiren = new HashSet<NumuneAlimFisi>();
            NumuneAlimFisiEkleyen = new HashSet<NumuneAlimFisi>();
            NumuneAlimFisiNumuneyiAlan = new HashSet<NumuneAlimFisi>();
            NumuneAlimTipiDegistiren = new HashSet<NumuneAlimTipi>();
            NumuneAlimTipiEkleyen = new HashSet<NumuneAlimTipi>();
            NumunePdf = new HashSet<NumunePdf>();
            NumuneTipiDegistiren = new HashSet<NumuneTipi>();
            NumuneTipiEkleyen = new HashSet<NumuneTipi>();
            ParametreDegistiren = new HashSet<Parametre>();
            ParametreEkleyen = new HashSet<Parametre>();
            PersonelYetki = new HashSet<PersonelYetki>();
            RaporDizaynDegistiren = new HashSet<RaporDizayn>();
            RaporDizaynEkleyen = new HashSet<RaporDizayn>();
            RolDegistiren = new HashSet<Rol>();
            RolEkleyen = new HashSet<Rol>();
            YetkiDegistiren = new HashSet<Yetki>();
            YetkiEkleyen = new HashSet<Yetki>();
        }

        public Guid Id { get; set; }
        public string Kod { get; set; }
        public int SiraNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public string EmailKullaniciAdi { get; set; }
        public string EmailSifre { get; set; }
        public string SmtpSunucu { get; set; }
        public int SmtpPort { get; set; }
        public bool Ssl { get; set; }
        public string Cc { get; set; }
        public Guid? RolId { get; set; }
        public Guid? ImageId { get; set; }
        public bool KullanimDisi { get; set; }
        public Guid? EkleyenId { get; set; }
        public DateTime? EklemeTarihi { get; set; }
        public Guid? DegistirenId { get; set; }
        public DateTime? DegistirmeTarihi { get; set; }

        public virtual ICollection<Analiz> AnalizDegistiren { get; set; }
        public virtual ICollection<Analiz> AnalizEkleyen { get; set; }
        public virtual ICollection<AnalizSonuc> AnalizSonucDegistiren { get; set; }
        public virtual ICollection<AnalizSonuc> AnalizSonucEkleyen { get; set; }
        public virtual ICollection<AnalizSonucAnaliz> AnalizSonucAnalizDegistiren { get; set; }
        public virtual ICollection<AnalizSonucAnaliz> AnalizSonucAnalizEkleyen { get; set; }
        public virtual ICollection<AnalizTipi> AnalizTipiDegistiren { get; set; }
        public virtual ICollection<AnalizTipi> AnalizTipiEkleyen { get; set; }
        public virtual ICollection<DezenfeksiyonTuru> DezenfeksiyonTuruDegistiren { get; set; }
        public virtual ICollection<DezenfeksiyonTuru> DezenfeksiyonTuruEkleyen { get; set; }
        public virtual ICollection<Doviz> DovizDegistiren { get; set; }
        public virtual ICollection<Doviz> DovizEkleyen { get; set; }
        public virtual ICollection<DovizKur> DovizKurDegistiren { get; set; }
        public virtual ICollection<DovizKur> DovizKurEkleyen { get; set; }
        public virtual ICollection<Eimza> EimzaDegistiren { get; set; }
        public virtual ICollection<Eimza> EimzaEkleyen { get; set; }
        public virtual ICollection<Fihrist> FihristDegistiren { get; set; }
        public virtual ICollection<Fihrist> FihristEkleyen { get; set; }
        public virtual ICollection<FiyatTipi> FiyatTipiDegistiren { get; set; }
        public virtual ICollection<FiyatTipi> FiyatTipiEkleyen { get; set; }
        public virtual ICollection<GridLayout> GridLayout { get; set; }
        public virtual ICollection<Ileti> IletiDegistiren { get; set; }
        public virtual ICollection<Ileti> IletiEkleyen { get; set; }
        public virtual ICollection<Kodeks> KodeksDegistiren { get; set; }
        public virtual ICollection<Kodeks> KodeksEkleyen { get; set; }
        public virtual ICollection<Kurum> KurumDegistiren { get; set; }
        public virtual ICollection<Kurum> KurumEkleyen { get; set; }
        public virtual ICollection<NumuneAlim> NumuneAlimDegistiren { get; set; }
        public virtual ICollection<NumuneAlim> NumuneAlimEkleyen { get; set; }
        public virtual ICollection<NumuneAlimFisi> NumuneAlimFisiDegistiren { get; set; }
        public virtual ICollection<NumuneAlimFisi> NumuneAlimFisiEkleyen { get; set; }
        public virtual ICollection<NumuneAlimFisi> NumuneAlimFisiNumuneyiAlan { get; set; }
        public virtual ICollection<NumuneAlimTipi> NumuneAlimTipiDegistiren { get; set; }
        public virtual ICollection<NumuneAlimTipi> NumuneAlimTipiEkleyen { get; set; }
        public virtual ICollection<NumunePdf> NumunePdf { get; set; }
        public virtual ICollection<NumuneTipi> NumuneTipiDegistiren { get; set; }
        public virtual ICollection<NumuneTipi> NumuneTipiEkleyen { get; set; }
        public virtual ICollection<Parametre> ParametreDegistiren { get; set; }
        public virtual ICollection<Parametre> ParametreEkleyen { get; set; }
        public virtual ICollection<PersonelYetki> PersonelYetki { get; set; }
        public virtual ICollection<RaporDizayn> RaporDizaynDegistiren { get; set; }
        public virtual ICollection<RaporDizayn> RaporDizaynEkleyen { get; set; }
        public virtual ICollection<Rol> RolDegistiren { get; set; }
        public virtual ICollection<Rol> RolEkleyen { get; set; }
        public virtual ICollection<Yetki> YetkiDegistiren { get; set; }
        public virtual ICollection<Yetki> YetkiEkleyen { get; set; }
        public virtual Personel Degistiren { get; set; }
        public virtual ICollection<Personel> InverseDegistiren { get; set; }
        public virtual Personel Ekleyen { get; set; }
        public virtual ICollection<Personel> InverseEkleyen { get; set; }
        public virtual PersonelImage Image { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
