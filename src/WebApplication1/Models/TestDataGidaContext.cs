using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KhufuMobile.Models
{
    public partial class KhufuDataContext : DbContext
    {
        public virtual DbSet<Analiz> Analiz { get; set; }
        public virtual DbSet<AnalizNumuneTipi> AnalizNumuneTipi { get; set; }
        public virtual DbSet<AnalizSonuc> AnalizSonuc { get; set; }
        public virtual DbSet<AnalizSonucAnaliz> AnalizSonucAnaliz { get; set; }
        public virtual DbSet<AnalizTipi> AnalizTipi { get; set; }
        public virtual DbSet<DezenfeksiyonTuru> DezenfeksiyonTuru { get; set; }
        public virtual DbSet<Doviz> Doviz { get; set; }
        public virtual DbSet<DovizKur> DovizKur { get; set; }
        public virtual DbSet<Eimza> Eimza { get; set; }
        public virtual DbSet<Fihrist> Fihrist { get; set; }
        public virtual DbSet<FiyatTipi> FiyatTipi { get; set; }
        public virtual DbSet<GridLayout> GridLayout { get; set; }
        public virtual DbSet<Ileti> Ileti { get; set; }
        public virtual DbSet<IletiEki> IletiEki { get; set; }
        public virtual DbSet<IletiMail> IletiMail { get; set; }
        public virtual DbSet<IletiSms> IletiSms { get; set; }
        public virtual DbSet<IletiSmsDurum> IletiSmsDurum { get; set; }
        public virtual DbSet<Kodeks> Kodeks { get; set; }
        public virtual DbSet<KodeksAnaliz> KodeksAnaliz { get; set; }
        public virtual DbSet<Kurum> Kurum { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<NumuneAlim> NumuneAlim { get; set; }
        public virtual DbSet<NumuneAlimFisi> NumuneAlimFisi { get; set; }
        public virtual DbSet<NumuneAlimTipi> NumuneAlimTipi { get; set; }
        public virtual DbSet<NumuneGida> NumuneGida { get; set; }
        public virtual DbSet<NumuneHavuzSuyu> NumuneHavuzSuyu { get; set; }
        public virtual DbSet<NumunePdf> NumunePdf { get; set; }
        public virtual DbSet<NumunePdfEimza> NumunePdfEimza { get; set; }
        public virtual DbSet<NumunePdfNumuneAlim> NumunePdfNumuneAlim { get; set; }
        public virtual DbSet<NumuneTipi> NumuneTipi { get; set; }
        public virtual DbSet<NumuneTipiEimza> NumuneTipiEimza { get; set; }
        public virtual DbSet<Parametre> Parametre { get; set; }
        public virtual DbSet<ParametreImage> ParametreImage { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<PersonelImage> PersonelImage { get; set; }
        public virtual DbSet<PersonelYetki> PersonelYetki { get; set; }
        public virtual DbSet<RaporDizayn> RaporDizayn { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolYetki> RolYetki { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=93.89.72.167;User=sa;Password=Best1993;Initial Catalog=TestDataGida");
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Analiz>(entity =>
            {
                entity.HasIndex(e => e.AnalizTipiId)
                    .HasName("IX_AnalizTipi_ID");

                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.AnalizTipiId).HasColumnName("AnalizTipi_ID");

                entity.Property(e => e.Birim).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.KisaKod).HasMaxLength(50);

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KullanilanMethod).HasMaxLength(50);

                entity.Property(e => e.NormalDeger).HasMaxLength(50);

                entity.Property(e => e.OlcumKararsizligi).HasMaxLength(50);

                entity.Property(e => e.SifirDegerBirim).HasMaxLength(50);

                entity.HasOne(d => d.AnalizTipi)
                    .WithMany(p => p.Analiz)
                    .HasForeignKey(d => d.AnalizTipiId)
                    .HasConstraintName("FK_dbo.Analiz_dbo.AnalizTipi_AnalizTipi_ID");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.AnalizDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Analiz_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.AnalizEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Analiz_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<AnalizNumuneTipi>(entity =>
            {
                entity.HasKey(e => new { e.AnalizId, e.NumuneTipiId })
                    .HasName("PK_dbo.AnalizNumuneTipi");

                entity.HasIndex(e => e.AnalizId)
                    .HasName("IX_Analiz_ID");

                entity.HasIndex(e => e.NumuneTipiId)
                    .HasName("IX_NumuneTipi_ID");

                entity.Property(e => e.AnalizId).HasColumnName("Analiz_ID");

                entity.Property(e => e.NumuneTipiId).HasColumnName("NumuneTipi_ID");

                entity.HasOne(d => d.Analiz)
                    .WithMany(p => p.AnalizNumuneTipi)
                    .HasForeignKey(d => d.AnalizId)
                    .HasConstraintName("FK_dbo.AnalizNumuneTipi_dbo.Analiz_Analiz_ID");

                entity.HasOne(d => d.NumuneTipi)
                    .WithMany(p => p.AnalizNumuneTipi)
                    .HasForeignKey(d => d.NumuneTipiId)
                    .HasConstraintName("FK_dbo.AnalizNumuneTipi_dbo.NumuneTipi_NumuneTipi_ID");
            });

            modelBuilder.Entity<AnalizSonuc>(entity =>
            {
                entity.HasIndex(e => e.AnalizId)
                    .HasName("IX_Analiz_ID");

                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.NumuneAlimId)
                    .HasName("IX_NumuneAlim_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnalizId).HasColumnName("Analiz_ID");

                entity.Property(e => e.BaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Deger).HasMaxLength(50);

                entity.Property(e => e.DegerGirildi).HasDefaultValueSql("0");

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.NumuneAlimId).HasColumnName("NumuneAlim_ID");

                entity.Property(e => e.OlcumKararsizligi).HasMaxLength(50);

                entity.Property(e => e.Olumlu).HasDefaultValueSql("1");

                entity.HasOne(d => d.Analiz)
                    .WithMany(p => p.AnalizSonuc)
                    .HasForeignKey(d => d.AnalizId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.AnalizSonuc_dbo.Analiz_Analiz_ID");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.AnalizSonucDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.AnalizSonuc_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.AnalizSonucEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.AnalizSonuc_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.NumuneAlim)
                    .WithMany(p => p.AnalizSonuc)
                    .HasForeignKey(d => d.NumuneAlimId)
                    .HasConstraintName("FK_dbo.AnalizSonuc_dbo.NumuneAlim_NumuneAlim_ID");
            });

            modelBuilder.Entity<AnalizSonucAnaliz>(entity =>
            {
                entity.HasKey(e => e.AnalizSonucId)
                    .HasName("PK_dbo.AnalizSonucAnaliz");

                entity.HasIndex(e => e.AnalizTipiId)
                    .HasName("IX_AnalizTipi_ID");

                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.Property(e => e.AnalizSonucId)
                    .HasColumnName("AnalizSonuc_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.AnalizTipiId).HasColumnName("AnalizTipi_ID");

                entity.Property(e => e.Birim).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.KisaKod).HasMaxLength(50);

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KullanilanMethod).HasMaxLength(50);

                entity.Property(e => e.NormalDeger).HasMaxLength(50);

                entity.Property(e => e.OlcumKararsizligi).HasMaxLength(50);

                entity.Property(e => e.SifirDegerBirim).HasMaxLength(50);

                entity.HasOne(d => d.AnalizSonuc)
                    .WithOne(p => p.AnalizSonucAnaliz)
                    .HasForeignKey<AnalizSonucAnaliz>(d => d.AnalizSonucId)
                    .HasConstraintName("FK_dbo.AnalizSonucAnaliz_dbo.AnalizSonuc_AnalizSonuc_ID");

                entity.HasOne(d => d.AnalizTipi)
                    .WithMany(p => p.AnalizSonucAnaliz)
                    .HasForeignKey(d => d.AnalizTipiId)
                    .HasConstraintName("FK_dbo.AnalizSonucAnaliz_dbo.AnalizTipi_AnalizTipi_ID");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.AnalizSonucAnalizDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.AnalizSonucAnaliz_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.AnalizSonucAnalizEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.AnalizSonucAnaliz_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<AnalizTipi>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.AnalizTipiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.AnalizTipi_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.AnalizTipiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.AnalizTipi_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<DezenfeksiyonTuru>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.DezenfeksiyonTuruDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.DezenfeksiyonTuru_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.DezenfeksiyonTuruEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.DezenfeksiyonTuru_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<Doviz>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mbkod)
                    .HasColumnName("MBKod")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.DovizDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Doviz_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.DovizEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Doviz_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<DovizKur>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.DovizId)
                    .HasName("IX_Doviz_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => new { e.DovizId, e.Tarih })
                    .HasName("IX_Doviz_ID_Tarih")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DovizId).HasColumnName("Doviz_ID");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.DovizKurDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.DovizKur_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Doviz)
                    .WithMany(p => p.DovizKur)
                    .HasForeignKey(d => d.DovizId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.DovizKur_dbo.Doviz_Doviz_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.DovizKurEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.DovizKur_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<Eimza>(entity =>
            {
                entity.ToTable("EImza");

                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdSoyad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.LibraryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'akisp11.dll'");

                entity.Property(e => e.Pin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SertifikaAd)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SertifikaId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TokenLabel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'Akis'");

                entity.Property(e => e.TokenSerial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.EimzaDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.EImza_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.EimzaEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.EImza_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<Fihrist>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => new { e.Ad, e.Soyad, e.Tip })
                    .HasName("IX_Ad_Soyad_Tip")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Adres).HasMaxLength(250);

                entity.Property(e => e.CepTelefonu).HasMaxLength(100);

                entity.Property(e => e.CepTelefonu2).HasMaxLength(100);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(250);

                entity.Property(e => e.Email2)
                    .HasColumnName("EMail2")
                    .HasMaxLength(250);

                entity.Property(e => e.EvTelefonu).HasMaxLength(16);

                entity.Property(e => e.Fax).HasMaxLength(16);

                entity.Property(e => e.IsTelefonu).HasMaxLength(16);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.FihristDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Fihrist_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.FihristEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Fihrist_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<FiyatTipi>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.DovizId)
                    .HasName("IX_Doviz_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DovizId).HasColumnName("Doviz_ID");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.FiyatTipiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.FiyatTipi_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Doviz)
                    .WithMany(p => p.FiyatTipi)
                    .HasForeignKey(d => d.DovizId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.FiyatTipi_dbo.Doviz_Doviz_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.FiyatTipiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.FiyatTipi_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<GridLayout>(entity =>
            {
                entity.HasIndex(e => e.PersonelId)
                    .HasName("IX_Personel_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Form).HasMaxLength(150);

                entity.Property(e => e.GridView).HasMaxLength(150);

                entity.Property(e => e.Layout).HasColumnType("image");

                entity.Property(e => e.PersonelId).HasColumnName("Personel_ID");

                entity.Property(e => e.ViewInfo).HasColumnType("image");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.GridLayout)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.GridLayout_dbo.Personel_Personel_ID");
            });

            modelBuilder.Entity<Ileti>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.NumuneAlimFisId)
                    .HasName("IX_NumuneAlimFis_ID");

                entity.HasIndex(e => e.NumuneAlimId)
                    .HasName("IX_NumuneAlim_ID");

                entity.HasIndex(e => e.SiraNo)
                    .HasName("IX_SiraNo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.GonderildigiTarih).HasColumnType("datetime");

                entity.Property(e => e.NumuneAlimFisId).HasColumnName("NumuneAlimFis_ID");

                entity.Property(e => e.NumuneAlimId).HasColumnName("NumuneAlim_ID");

                entity.Property(e => e.SiraNo).ValueGeneratedOnAdd();

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.IletiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Ileti_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.IletiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Ileti_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.NumuneAlimFis)
                    .WithMany(p => p.Ileti)
                    .HasForeignKey(d => d.NumuneAlimFisId)
                    .HasConstraintName("FK_dbo.Ileti_dbo.NumuneAlimFisi_NumuneAlimFis_ID");

                entity.HasOne(d => d.NumuneAlim)
                    .WithMany(p => p.Ileti)
                    .HasForeignKey(d => d.NumuneAlimId)
                    .HasConstraintName("FK_dbo.Ileti_dbo.NumuneAlim_NumuneAlim_ID");
            });

            modelBuilder.Entity<IletiEki>(entity =>
            {
                entity.HasIndex(e => e.IletiId)
                    .HasName("IX_Ileti_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("'00000000-0000-0000-0000-000000000000'");

                entity.Property(e => e.DosyaAd).HasMaxLength(250);

                entity.Property(e => e.IletiId).HasColumnName("Ileti_ID");

                entity.HasOne(d => d.Ileti)
                    .WithMany(p => p.IletiEki)
                    .HasForeignKey(d => d.IletiId)
                    .HasConstraintName("FK_dbo.IletiEki_dbo.Ileti_Ileti_ID");
            });

            modelBuilder.Entity<IletiMail>(entity =>
            {
                entity.HasKey(e => e.IletiId)
                    .HasName("PK_dbo.IletiMail");

                entity.HasIndex(e => e.NumuneAlimFisPdfId)
                    .HasName("IX_NumuneAlimFisPdf_ID");

                entity.HasIndex(e => e.NumuneAlimPdfId)
                    .HasName("IX_NumuneAlimPdf_ID");

                entity.Property(e => e.IletiId)
                    .HasColumnName("Ileti_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasMaxLength(250);

                entity.Property(e => e.From).HasMaxLength(50);

                entity.Property(e => e.NumuneAlimFisPdfId).HasColumnName("NumuneAlimFisPdf_ID");

                entity.Property(e => e.NumuneAlimPdfId).HasColumnName("NumuneAlimPdf_ID");

                entity.Property(e => e.SmtpServer).HasMaxLength(50);

                entity.Property(e => e.Ssl).HasColumnName("SSL");

                entity.Property(e => e.Subject).HasMaxLength(250);

                entity.Property(e => e.To)
                    .HasColumnName("TO")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Ileti)
                    .WithOne(p => p.IletiMail)
                    .HasForeignKey<IletiMail>(d => d.IletiId)
                    .HasConstraintName("FK_dbo.IletiMail_dbo.Ileti_Ileti_ID");

                entity.HasOne(d => d.NumuneAlimFisPdf)
                    .WithMany(p => p.IletiMailNumuneAlimFisPdf)
                    .HasForeignKey(d => d.NumuneAlimFisPdfId)
                    .HasConstraintName("FK_dbo.IletiMail_dbo.NumunePdf_NumuneAlimFisPdf_ID");

                entity.HasOne(d => d.NumuneAlimPdf)
                    .WithMany(p => p.IletiMailNumuneAlimPdf)
                    .HasForeignKey(d => d.NumuneAlimPdfId)
                    .HasConstraintName("FK_dbo.IletiMail_dbo.NumunePdf_NumuneAlimPdf_ID");
            });

            modelBuilder.Entity<IletiSms>(entity =>
            {
                entity.HasKey(e => e.IletiId)
                    .HasName("PK_dbo.IletiSms");

                entity.Property(e => e.IletiId)
                    .HasColumnName("Ileti_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gsm).HasMaxLength(100);

                entity.Property(e => e.Message).HasMaxLength(140);

                entity.HasOne(d => d.Ileti)
                    .WithOne(p => p.IletiSms)
                    .HasForeignKey<IletiSms>(d => d.IletiId)
                    .HasConstraintName("FK_dbo.IletiSms_dbo.Ileti_Ileti_ID");
            });

            modelBuilder.Entity<IletiSmsDurum>(entity =>
            {
                entity.HasIndex(e => e.IletiId)
                    .HasName("IX_Ileti_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Durum).HasMaxLength(50);

                entity.Property(e => e.Gsm).HasMaxLength(20);

                entity.Property(e => e.IletiId).HasColumnName("Ileti_ID");

                entity.Property(e => e.MessageId)
                    .HasColumnName("MessageID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Ileti)
                    .WithMany(p => p.IletiSmsDurum)
                    .HasForeignKey(d => d.IletiId)
                    .HasConstraintName("FK_dbo.IletiSmsDurum_dbo.IletiSms_Ileti_ID");
            });

            modelBuilder.Entity<Kodeks>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.NumuneTipiId)
                    .HasName("IX_NumuneTipi_ID");

                entity.HasIndex(e => new { e.NumuneTipiId, e.Kod })
                    .HasName("IX_NumuneTipi_ID_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.AnalizMethodu).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumuneTipiId).HasColumnName("NumuneTipi_ID");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.KodeksDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Kodeks_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.KodeksEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Kodeks_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.NumuneTipi)
                    .WithMany(p => p.Kodeks)
                    .HasForeignKey(d => d.NumuneTipiId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.Kodeks_dbo.NumuneTipi_NumuneTipi_ID");
            });

            modelBuilder.Entity<KodeksAnaliz>(entity =>
            {
                entity.HasKey(e => new { e.KodeksId, e.AnalizId })
                    .HasName("PK_dbo.KodeksAnaliz");

                entity.HasIndex(e => e.AnalizId)
                    .HasName("IX_Analiz_ID");

                entity.HasIndex(e => e.KodeksId)
                    .HasName("IX_Kodeks_ID");

                entity.Property(e => e.KodeksId).HasColumnName("Kodeks_ID");

                entity.Property(e => e.AnalizId).HasColumnName("Analiz_ID");

                entity.HasOne(d => d.Analiz)
                    .WithMany(p => p.KodeksAnaliz)
                    .HasForeignKey(d => d.AnalizId)
                    .HasConstraintName("FK_dbo.KodeksAnaliz_dbo.Analiz_Analiz_ID");

                entity.HasOne(d => d.Kodeks)
                    .WithMany(p => p.KodeksAnaliz)
                    .HasForeignKey(d => d.KodeksId)
                    .HasConstraintName("FK_dbo.KodeksAnaliz_dbo.Kodeks_Kodeks_ID");
            });

            modelBuilder.Entity<Kurum>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.FihristId)
                    .HasName("IX_Fihrist_ID");

                entity.HasIndex(e => e.FiyatTipiId)
                    .HasName("IX_FiyatTipi_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.BakanlikNo).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.FihristId).HasColumnName("Fihrist_ID");

                entity.Property(e => e.FiyatTipiId).HasColumnName("FiyatTipi_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VergiDairesi).HasMaxLength(50);

                entity.Property(e => e.VergiNo).HasMaxLength(50);

                entity.Property(e => e.WebPassword).HasMaxLength(50);

                entity.Property(e => e.WebUsername).HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.KurumDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Kurum_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.KurumEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Kurum_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.Fihrist)
                    .WithMany(p => p.Kurum)
                    .HasForeignKey(d => d.FihristId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.Kurum_dbo.Fihrist_Fihrist_ID");

                entity.HasOne(d => d.FiyatTipi)
                    .WithMany(p => p.Kurum)
                    .HasForeignKey(d => d.FiyatTipiId)
                    .HasConstraintName("FK_dbo.Kurum_dbo.FiyatTipi_FiyatTipi_ID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory2");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<NumuneAlim>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.KodeksId)
                    .HasName("IX_Kodeks_ID");

                entity.HasIndex(e => e.NumuneAlimFisId)
                    .HasName("IX_NumuneAlimFis_ID");

                entity.HasIndex(e => e.NumuneTipiId)
                    .HasName("IX_NumuneTipi_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(100);

                entity.Property(e => e.AlimYeri).HasMaxLength(50);

                entity.Property(e => e.BakanlikRaporNo).HasMaxLength(50);

                entity.Property(e => e.BaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.Birim).HasMaxLength(50);

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.IstenenAnalizler).HasMaxLength(250);

                entity.Property(e => e.KayitNo).HasDefaultValueSql("0");

                entity.Property(e => e.KodeksId).HasColumnName("Kodeks_ID");

                entity.Property(e => e.NumuneAdi).HasMaxLength(50);

                entity.Property(e => e.NumuneAlimFisId).HasColumnName("NumuneAlimFis_ID");

                entity.Property(e => e.NumuneTipiId).HasColumnName("NumuneTipi_ID");

                entity.Property(e => e.Olumlu).HasDefaultValueSql("0");

                entity.Property(e => e.WebdeGoster).HasDefaultValueSql("0");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.NumuneAlimDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.NumuneAlim_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.NumuneAlimEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.NumuneAlim_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.Kodeks)
                    .WithMany(p => p.NumuneAlim)
                    .HasForeignKey(d => d.KodeksId)
                    .HasConstraintName("FK_dbo.NumuneAlim_dbo.Kodeks_Kodeks_ID");

                entity.HasOne(d => d.NumuneAlimFis)
                    .WithMany(p => p.NumuneAlim)
                    .HasForeignKey(d => d.NumuneAlimFisId)
                    .HasConstraintName("FK_dbo.NumuneAlim_dbo.NumuneAlimFisi_NumuneAlimFis_ID");

                entity.HasOne(d => d.NumuneTipi)
                    .WithMany(p => p.NumuneAlim)
                    .HasForeignKey(d => d.NumuneTipiId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumuneAlim_dbo.NumuneTipi_NumuneTipi_ID");
            });

            modelBuilder.Entity<NumuneAlimFisi>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.DezenfeksiyonTuruId)
                    .HasName("IX_DezenfeksiyonTuru_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.KurumId)
                    .HasName("IX_Kurum_ID");

                entity.HasIndex(e => e.NumuneAlimTipiId)
                    .HasName("IX_NumuneAlimTipi_ID");

                entity.HasIndex(e => e.NumuneyiAlanId)
                    .HasName("IX_NumuneyiAlan_ID");

                entity.HasIndex(e => new { e.NumuneAlimTipiId, e.RaporNo })
                    .HasName("IX_NumuneAlimTipi_ID_RaporNo")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnalizAmaci).HasMaxLength(50);

                entity.Property(e => e.BaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.DetayFormuBasildi).HasDefaultValueSql("0");

                entity.Property(e => e.DezenfeksiyonTuruId).HasColumnName("DezenfeksiyonTuru_ID");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.KapakBasildi).HasDefaultValueSql("0");

                entity.Property(e => e.KayitFormuBasildi).HasDefaultValueSql("0");

                entity.Property(e => e.KurumId).HasColumnName("Kurum_ID");

                entity.Property(e => e.LaboratuvaraUlasmaTarihi)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'1900-01-01T00:00:00.000'");

                entity.Property(e => e.MailGonderildi).HasDefaultValueSql("0");

                entity.Property(e => e.NumuneAlimTipiId).HasColumnName("NumuneAlimTipi_ID");

                entity.Property(e => e.NumuneyiAlanId).HasColumnName("NumuneyiAlan_ID");

                entity.Property(e => e.RaporBasildi).HasDefaultValueSql("0");

                entity.Property(e => e.RaporBasilmaSayisi).HasDefaultValueSql("0");

                entity.Property(e => e.RaporNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RaporNoBaslik).HasMaxLength(50);

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.Property(e => e.WebdeGoster).HasDefaultValueSql("0");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.NumuneAlimFisiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.NumuneAlimFisi_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.DezenfeksiyonTuru)
                    .WithMany(p => p.NumuneAlimFisi)
                    .HasForeignKey(d => d.DezenfeksiyonTuruId)
                    .HasConstraintName("FK_dbo.NumuneAlimFisi_dbo.DezenfeksiyonTuru_DezenfeksiyonTuru_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.NumuneAlimFisiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.NumuneAlimFisi_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.Kurum)
                    .WithMany(p => p.NumuneAlimFisi)
                    .HasForeignKey(d => d.KurumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumuneAlimFisi_dbo.Kurum_Kurum_ID");

                entity.HasOne(d => d.NumuneAlimTipi)
                    .WithMany(p => p.NumuneAlimFisi)
                    .HasForeignKey(d => d.NumuneAlimTipiId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumuneAlimFisi_dbo.NumuneAlimTipi_NumuneAlimTipi_ID");

                entity.HasOne(d => d.NumuneyiAlan)
                    .WithMany(p => p.NumuneAlimFisiNumuneyiAlan)
                    .HasForeignKey(d => d.NumuneyiAlanId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumuneAlimFisi_dbo.Personel_NumuneyiAlan_ID");
            });

            modelBuilder.Entity<NumuneAlimTipi>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OnDegerAnalizBaslamaGun).HasDefaultValueSql("0");

                entity.Property(e => e.OnDegerAnalizGun).HasDefaultValueSql("0");

                entity.Property(e => e.RaporNoBaslik).HasMaxLength(50);

                entity.Property(e => e.SonNumuneKayitNo).HasDefaultValueSql("0");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.NumuneAlimTipiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.NumuneAlimTipi_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.NumuneAlimTipiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.NumuneAlimTipi_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<NumuneGida>(entity =>
            {
                entity.HasKey(e => e.NumuneAlimId)
                    .HasName("PK_dbo.NumuneGida");

                entity.Property(e => e.NumuneAlimId)
                    .HasColumnName("NumuneAlim_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ambalaji).HasMaxLength(50);

                entity.Property(e => e.Cinsi).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SeriPartiNo).HasMaxLength(50);

                entity.Property(e => e.SonKullanimTarihi).HasColumnType("datetime");

                entity.Property(e => e.UreticiFirmaAdi).HasMaxLength(50);

                entity.Property(e => e.UretimSktarihi)
                    .HasColumnName("UretimSKTarihi")
                    .HasMaxLength(50);

                entity.Property(e => e.UretimTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.NumuneAlim)
                    .WithOne(p => p.NumuneGida)
                    .HasForeignKey<NumuneGida>(d => d.NumuneAlimId)
                    .HasConstraintName("FK_dbo.NumuneGida_dbo.NumuneAlim_NumuneAlim_ID");
            });

            modelBuilder.Entity<NumuneHavuzSuyu>(entity =>
            {
                entity.HasKey(e => e.NumuneAlimId)
                    .HasName("PK_dbo.NumuneHavuzSuyu");

                entity.Property(e => e.NumuneAlimId)
                    .HasColumnName("NumuneAlim_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlinmaSekli).HasMaxLength(100);

                entity.Property(e => e.BagliCl).HasColumnName("BagliCL");

                entity.Property(e => e.H2o2).HasColumnName("H2O2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KabinCinsi).HasMaxLength(150);

                entity.Property(e => e.PH).HasColumnName("pH");

                entity.Property(e => e.SerbestCl).HasColumnName("SerbestCL");

                entity.HasOne(d => d.NumuneAlim)
                    .WithOne(p => p.NumuneHavuzSuyu)
                    .HasForeignKey<NumuneHavuzSuyu>(d => d.NumuneAlimId)
                    .HasConstraintName("FK_dbo.NumuneHavuzSuyu_dbo.NumuneAlim_NumuneAlim_ID");
            });

            modelBuilder.Entity<NumunePdf>(entity =>
            {
                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.NumuneAlimFisId)
                    .HasName("IX_NumuneAlimFis_ID");

                entity.HasIndex(e => e.NumuneAlimId)
                    .HasName("IX_NumuneAlim_ID");

                entity.HasIndex(e => e.SiraNo)
                    .HasName("IX_SiraNo");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DosyaAd).HasMaxLength(250);

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.LocalDosyaAd).HasMaxLength(250);

                entity.Property(e => e.NumuneAlimFisId).HasColumnName("NumuneAlimFis_ID");

                entity.Property(e => e.NumuneAlimId).HasColumnName("NumuneAlim_ID");

                entity.Property(e => e.Path).HasMaxLength(50);

                entity.Property(e => e.SiraNo).ValueGeneratedOnAdd();

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.NumunePdf)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.NumunePdf_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.NumuneAlimFis)
                    .WithMany(p => p.NumunePdf)
                    .HasForeignKey(d => d.NumuneAlimFisId)
                    .HasConstraintName("FK_dbo.NumunePdf_dbo.NumuneAlimFisi_NumuneAlimFis_ID");

                entity.HasOne(d => d.NumuneAlim)
                    .WithMany(p => p.NumunePdf)
                    .HasForeignKey(d => d.NumuneAlimId)
                    .HasConstraintName("FK_dbo.NumunePdf_dbo.NumuneAlim_NumuneAlim_ID");
            });

            modelBuilder.Entity<NumunePdfEimza>(entity =>
            {
                entity.ToTable("NumunePdfEImza");

                entity.HasIndex(e => e.EimzaId)
                    .HasName("IX_EImza_ID");

                entity.HasIndex(e => e.NumunePdfId)
                    .HasName("IX_NumunePdf_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("'00000000-0000-0000-0000-000000000000'");

                entity.Property(e => e.EimzaId).HasColumnName("EImza_ID");

                entity.Property(e => e.NumunePdfId).HasColumnName("NumunePdf_ID");

                entity.HasOne(d => d.Eimza)
                    .WithMany(p => p.NumunePdfEimza)
                    .HasForeignKey(d => d.EimzaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumunePdfEImza_dbo.EImza_EImza_ID");

                entity.HasOne(d => d.NumunePdf)
                    .WithMany(p => p.NumunePdfEimza)
                    .HasForeignKey(d => d.NumunePdfId)
                    .HasConstraintName("FK_dbo.NumunePdfEImza_dbo.NumunePdf_NumunePdf_ID");
            });

            modelBuilder.Entity<NumunePdfNumuneAlim>(entity =>
            {
                entity.HasIndex(e => e.NumuneAlimId)
                    .HasName("IX_NumuneAlim_ID");

                entity.HasIndex(e => e.NumunePdfId)
                    .HasName("IX_NumunePdf_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("'00000000-0000-0000-0000-000000000000'");

                entity.Property(e => e.NumuneAlimId).HasColumnName("NumuneAlim_ID");

                entity.Property(e => e.NumunePdfId).HasColumnName("NumunePdf_ID");

                entity.HasOne(d => d.NumuneAlim)
                    .WithMany(p => p.NumunePdfNumuneAlim)
                    .HasForeignKey(d => d.NumuneAlimId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumunePdfNumuneAlim_dbo.NumuneAlim_NumuneAlim_ID");

                entity.HasOne(d => d.NumunePdf)
                    .WithMany(p => p.NumunePdfNumuneAlim)
                    .HasForeignKey(d => d.NumunePdfId)
                    .HasConstraintName("FK_dbo.NumunePdfNumuneAlim_dbo.NumunePdf_NumunePdf_ID");
            });

            modelBuilder.Entity<NumuneTipi>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.HasIndex(e => e.NumuneAlimTipiId)
                    .HasName("IX_NumuneAlimTipi_ID");

                entity.HasIndex(e => e.RaporDizaynId)
                    .HasName("IX_RaporDizayn_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.AnaliziIstenenParametreler).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.IstenilenAnalizler).HasMaxLength(50);

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumuneAlimTipiId).HasColumnName("NumuneAlimTipi_ID");

                entity.Property(e => e.OnDegerAlinmaSekli).HasMaxLength(100);

                entity.Property(e => e.OnDegerAmbalaji).HasMaxLength(100);

                entity.Property(e => e.OnDegerAnalizBaslamaGun).HasDefaultValueSql("0");

                entity.Property(e => e.OnDegerBirim).HasMaxLength(50);

                entity.Property(e => e.OnDegerBosMiktarBirim).HasMaxLength(50);

                entity.Property(e => e.OnDegerKabinCinsi).HasMaxLength(100);

                entity.Property(e => e.OnDegerSeriPartiNo).HasMaxLength(50);

                entity.Property(e => e.OnDegerUreticiFirmaAdi).HasMaxLength(50);

                entity.Property(e => e.OnDegerUretimSktarihi)
                    .HasColumnName("OnDegerUretimSKTarihi")
                    .HasMaxLength(50);

                entity.Property(e => e.RaporDizaynId).HasColumnName("RaporDizayn_ID");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.NumuneTipiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.NumuneTipi_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.NumuneTipiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.NumuneTipi_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.NumuneAlimTipi)
                    .WithMany(p => p.NumuneTipi)
                    .HasForeignKey(d => d.NumuneAlimTipiId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.NumuneTipi_dbo.NumuneAlimTipi_NumuneAlimTipi_ID");

                entity.HasOne(d => d.RaporDizayn)
                    .WithMany(p => p.NumuneTipi)
                    .HasForeignKey(d => d.RaporDizaynId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.NumuneTipi_dbo.RaporDizayn_RaporDizayn_ID");
            });

            modelBuilder.Entity<NumuneTipiEimza>(entity =>
            {
                entity.HasKey(e => new { e.NumuneTipiId, e.EimzaId })
                    .HasName("PK_dbo.NumuneTipiEImza");

                entity.ToTable("NumuneTipiEImza");

                entity.HasIndex(e => e.EimzaId)
                    .HasName("IX_EImza_ID");

                entity.HasIndex(e => e.NumuneTipiId)
                    .HasName("IX_NumuneTipi_ID");

                entity.Property(e => e.NumuneTipiId).HasColumnName("NumuneTipi_ID");

                entity.Property(e => e.EimzaId).HasColumnName("EImza_ID");

                entity.HasOne(d => d.Eimza)
                    .WithMany(p => p.NumuneTipiEimza)
                    .HasForeignKey(d => d.EimzaId)
                    .HasConstraintName("FK_dbo.NumuneTipiEImza_dbo.EImza_EImza_ID");

                entity.HasOne(d => d.NumuneTipi)
                    .WithMany(p => p.NumuneTipiEimza)
                    .HasForeignKey(d => d.NumuneTipiId)
                    .HasConstraintName("FK_dbo.NumuneTipiEImza_dbo.NumuneTipi_NumuneTipi_ID");
            });

            modelBuilder.Entity<Parametre>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.FihristId)
                    .HasName("IX_Fihrist_ID");

                entity.HasIndex(e => e.HavuzSuyuDezenfeksiyonTuruId)
                    .HasName("IX_HavuzSuyuDezenfeksiyonTuru_ID");

                entity.HasIndex(e => e.ImageId)
                    .HasName("IX_Image_ID");

                entity.HasIndex(e => e.YerelDovizId)
                    .HasName("IX_YerelDoviz_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dbguncelleniyor).HasColumnName("DBGuncelleniyor");

                entity.Property(e => e.Dbversion)
                    .HasColumnName("DBVersion")
                    .HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EimzaLibraryName)
                    .IsRequired()
                    .HasColumnName("EImzaLibraryName")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'akisp11.dll'");

                entity.Property(e => e.EimzaLocation)
                    .IsRequired()
                    .HasColumnName("EImzaLocation")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.EimzaLowerLeftX)
                    .HasColumnName("EImzaLowerLeftX")
                    .HasDefaultValueSql("13");

                entity.Property(e => e.EimzaLowerLeftY)
                    .HasColumnName("EImzaLowerLeftY")
                    .HasDefaultValueSql("42");

                entity.Property(e => e.EimzaReason)
                    .IsRequired()
                    .HasColumnName("EImzaReason")
                    .HasMaxLength(150)
                    .HasDefaultValueSql("'Lab Khufu Rapor Imzalama'");

                entity.Property(e => e.EimzaTokenLabel)
                    .IsRequired()
                    .HasColumnName("EImzaTokenLabel")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'Akis'");

                entity.Property(e => e.EimzaUpperRightX)
                    .HasColumnName("EImzaUpperRightX")
                    .HasDefaultValueSql("300");

                entity.Property(e => e.EimzaUpperRightY)
                    .HasColumnName("EImzaUpperRightY")
                    .HasDefaultValueSql("62");

                entity.Property(e => e.EimzaYazi)
                    .IsRequired()
                    .HasColumnName("EImzaYazi")
                    .HasMaxLength(250)
                    .HasDefaultValueSql("'Bu Belge \"{0}\" tarafindan 5070 sayili elektronik imza kanununa göre güvenli elektronik imza ile imzalanmistir.'");

                entity.Property(e => e.EimzaYazisiEkle)
                    .HasColumnName("EImzaYazisiEkle")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EimzalamaAktif)
                    .HasColumnName("EImzalamaAktif")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.FihristId).HasColumnName("Fihrist_ID");

                entity.Property(e => e.FirmaAd).HasMaxLength(50);

                entity.Property(e => e.FirmaKodu).HasMaxLength(50);

                entity.Property(e => e.FisBaslamaBitisTarihiKullan).HasDefaultValueSql("0");

                entity.Property(e => e.HavuzSuyuDezenfeksiyonTuruId).HasColumnName("HavuzSuyuDezenfeksiyonTuru_ID");

                entity.Property(e => e.ImageId).HasColumnName("Image_ID");

                entity.Property(e => e.MailKonuFormat).HasMaxLength(250);

                entity.Property(e => e.MaileRaporEklensin).HasDefaultValueSql("0");

                entity.Property(e => e.PdfDosyaAdiFormat).HasMaxLength(150);

                entity.Property(e => e.PdfFtpHostName).HasMaxLength(50);

                entity.Property(e => e.PdfFtpPassword).HasMaxLength(50);

                entity.Property(e => e.PdfFtpPath).HasMaxLength(50);

                entity.Property(e => e.PdfFtpUsername).HasMaxLength(50);

                entity.Property(e => e.PdfFtpyeKaydet).HasDefaultValueSql("0");

                entity.Property(e => e.PdfSaklamaYolu)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PdfWebAdresi).HasMaxLength(250);

                entity.Property(e => e.PdflereKapakEkle).HasDefaultValueSql("0");

                entity.Property(e => e.SmsAktif).HasDefaultValueSql("0");

                entity.Property(e => e.SmsMesajFormat).HasMaxLength(140);

                entity.Property(e => e.SmsServisKullaniciAdi).HasMaxLength(50);

                entity.Property(e => e.SmsServisSifre).HasMaxLength(50);

                entity.Property(e => e.YerelDovizId).HasColumnName("YerelDoviz_ID");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.ParametreDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Parametre_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.ParametreEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Parametre_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.Fihrist)
                    .WithMany(p => p.Parametre)
                    .HasForeignKey(d => d.FihristId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.Parametre_dbo.Fihrist_Fihrist_ID");

                entity.HasOne(d => d.HavuzSuyuDezenfeksiyonTuru)
                    .WithMany(p => p.Parametre)
                    .HasForeignKey(d => d.HavuzSuyuDezenfeksiyonTuruId)
                    .HasConstraintName("FK_dbo.Parametre_dbo.DezenfeksiyonTuru_HavuzSuyuDezenfeksiyonTuru_ID");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Parametre)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.Parametre_dbo.ParametreImage_Image_ID");

                entity.HasOne(d => d.YerelDoviz)
                    .WithMany(p => p.Parametre)
                    .HasForeignKey(d => d.YerelDovizId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_dbo.Parametre_dbo.Doviz_YerelDoviz_ID");
            });

            modelBuilder.Entity<ParametreImage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Antet).HasColumnType("image");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.ImageId)
                    .HasName("IX_Image_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.HasIndex(e => e.RolId)
                    .HasName("IX_Rol_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ad).HasMaxLength(50);

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.EmailKullaniciAdi)
                    .HasColumnName("EMailKullaniciAdi")
                    .HasMaxLength(50);

                entity.Property(e => e.EmailSifre)
                    .HasColumnName("EMailSifre")
                    .HasMaxLength(50);

                entity.Property(e => e.ImageId).HasColumnName("Image_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RolId).HasColumnName("Rol_ID");

                entity.Property(e => e.Sifre).HasMaxLength(50);

                entity.Property(e => e.SmtpSunucu).HasMaxLength(50);

                entity.Property(e => e.Soyad).HasMaxLength(50);

                entity.Property(e => e.Ssl).HasColumnName("SSL");

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.InverseDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Personel_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.InverseEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Personel_dbo.Personel_Ekleyen_ID");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Personel)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_dbo.Personel_dbo.PersonelImage_Image_ID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Personel)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_dbo.Personel_dbo.Rol_Rol_ID");
            });

            modelBuilder.Entity<PersonelImage>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Kase).HasColumnType("image");

                entity.Property(e => e.KaseImzali).HasColumnType("image");
            });

            modelBuilder.Entity<PersonelYetki>(entity =>
            {
                entity.HasKey(e => new { e.PersonelId, e.YetkiId })
                    .HasName("PK_dbo.PersonelYetki");

                entity.HasIndex(e => e.PersonelId)
                    .HasName("IX_Personel_ID");

                entity.HasIndex(e => e.YetkiId)
                    .HasName("IX_Yetki_ID");

                entity.Property(e => e.PersonelId).HasColumnName("Personel_ID");

                entity.Property(e => e.YetkiId).HasColumnName("Yetki_ID");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.PersonelYetki)
                    .HasForeignKey(d => d.PersonelId)
                    .HasConstraintName("FK_dbo.PersonelYetki_dbo.Personel_Personel_ID");

                entity.HasOne(d => d.Yetki)
                    .WithMany(p => p.PersonelYetki)
                    .HasForeignKey(d => d.YetkiId)
                    .HasConstraintName("FK_dbo.PersonelYetki_dbo.Yetki_Yetki_ID");
            });

            modelBuilder.Entity<RaporDizayn>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ad).HasMaxLength(50);

                entity.Property(e => e.AltTip).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Dizayn).HasColumnType("image");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.TipAd).HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.RaporDizaynDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.RaporDizayn_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.RaporDizaynEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.RaporDizayn_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.RolDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Rol_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.RolEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Rol_dbo.Personel_Ekleyen_ID");
            });

            modelBuilder.Entity<RolYetki>(entity =>
            {
                entity.HasKey(e => new { e.RolId, e.YetkiId })
                    .HasName("PK_dbo.RolYetki");

                entity.HasIndex(e => e.RolId)
                    .HasName("IX_Rol_ID");

                entity.HasIndex(e => e.YetkiId)
                    .HasName("IX_Yetki_ID");

                entity.Property(e => e.RolId).HasColumnName("Rol_ID");

                entity.Property(e => e.YetkiId).HasColumnName("Yetki_ID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolYetki)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_dbo.RolYetki_dbo.Rol_Rol_ID");

                entity.HasOne(d => d.Yetki)
                    .WithMany(p => p.RolYetki)
                    .HasForeignKey(d => d.YetkiId)
                    .HasConstraintName("FK_dbo.RolYetki_dbo.Yetki_Yetki_ID");
            });

            modelBuilder.Entity<Yetki>(entity =>
            {
                entity.HasIndex(e => e.DegistirenId)
                    .HasName("IX_Degistiren_ID");

                entity.HasIndex(e => e.EkleyenId)
                    .HasName("IX_Ekleyen_ID");

                entity.HasIndex(e => e.Kod)
                    .HasName("IX_Kod")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aciklama).HasMaxLength(50);

                entity.Property(e => e.DegistirenId).HasColumnName("Degistiren_ID");

                entity.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.EkleyenId).HasColumnName("Ekleyen_ID");

                entity.Property(e => e.Kod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Degistiren)
                    .WithMany(p => p.YetkiDegistiren)
                    .HasForeignKey(d => d.DegistirenId)
                    .HasConstraintName("FK_dbo.Yetki_dbo.Personel_Degistiren_ID");

                entity.HasOne(d => d.Ekleyen)
                    .WithMany(p => p.YetkiEkleyen)
                    .HasForeignKey(d => d.EkleyenId)
                    .HasConstraintName("FK_dbo.Yetki_dbo.Personel_Ekleyen_ID");
            });
        }
    }
}