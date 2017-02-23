using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LabKhufu.Model.Entities;

namespace LabKhufu.DAL
{

    public class LKContext : DbContext
    {
        public static Guid PersonelID;

        public DbSet<Yetki> Yetkiler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Doviz> Dovizler { get; set; }

        public DbSet<Parametre> Parametreler { get; set; }

        public DbSet<DovizKur> DovizKurlari { get; set; }
        public DbSet<Fihrist> Fihristler { get; set; }
        public DbSet<FiyatTipi> FiyatTipleri { get; set; }
        public DbSet<Kurum> Kurumlar { get; set; }

        public DbSet<NumuneAlimTipi> NumuneAlimTipleri { get; set; }
        public DbSet<NumuneTipi> NumuneTipleri { get; set; }

        public DbSet<AnalizTipi> AnalizTipleri { get; set; }
        public DbSet<Analiz> Analizler { get; set; }
        public DbSet<Kodeks> Kodeksler { get; set; }

        public DbSet<NumuneAlimFisi> NumuneAlimFisleri { get; set; }
        public DbSet<NumuneAlim> NumuneAlimlari { get; set; }
        public DbSet<AnalizSonuc> AnalizSonuclari { get; set; }
        public DbSet<AnalizSonucAnaliz> AnalizSonucAnalizleri { get; set; }

        public DbSet<DezenfeksiyonTuru> DezenfeksiyonTurleri { get; set; }

        public DbSet<RaporDizayn> RaporDizaynlari { get; set; }
  
        public DbSet<NumunePdf> NumunePdfleri { get; set; }
         
        public DbSet<NumunePdfEImza> NumunePdfEImzalari { get; set; }
        
        
    }

}
