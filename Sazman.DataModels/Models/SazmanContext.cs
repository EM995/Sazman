using System.Data.Entity;

namespace Sazman.DataModels.Models
{
    public class SazmanContext : DbContext
    {
        public SazmanContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new SazmanDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sazman");

            modelBuilder.Entity<PersonnelEntity>().ToTable("Personnel");
            modelBuilder.Entity<DaneshgahEntity>().ToTable("Daneshgah");
            modelBuilder.Entity<FarzandEntity>().ToTable("Farzand");
            modelBuilder.Entity<JaygaheSazmaniEntity>().ToTable("JaygaheSazmani");
            modelBuilder.Entity<TahseelEntity>().ToTable("Tahseel");
            modelBuilder.Entity<VahedeSazmaniEntity>().ToTable("VahedeSazmani");


            // Configure Primary Key
            modelBuilder.Entity<PersonnelEntity>().HasKey(p => p.Id);
            modelBuilder.Entity<DaneshgahEntity>().HasKey(d => d.Id);
            modelBuilder.Entity<FarzandEntity>().HasKey(f => f.Id);
            modelBuilder.Entity<JaygaheSazmaniEntity>().HasKey(j => j.Id);
            modelBuilder.Entity<TahseelEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<VahedeSazmaniEntity>().HasKey(v => v.Id);

            // Configure one-to-many relationship
            //
            // between Farzand and Personnel Entity
            modelBuilder.Entity<FarzandEntity>()
                .HasRequired<PersonnelEntity>(f => f.Personnel)
                .WithMany(p => p.Farzandan)
                .HasForeignKey(f => f.PersonnelId);

            // between Tahseel and Personnel Entity
            modelBuilder.Entity<TahseelEntity>()
                .HasRequired<PersonnelEntity>(t => t.Personnel)
                .WithMany(p => p.Tahseelat)
                .HasForeignKey(t => t.PersonnelId);

            // between JaygaheSazmani and Personnel Entity
            modelBuilder.Entity<JaygaheSazmaniEntity>()
                .HasRequired<PersonnelEntity>(j => j.Personnel)
                .WithMany(p => p.Jaygahha)
                .HasForeignKey(j => j.PersonnelId);

            // between Daneshgah and Tahseel
            modelBuilder.Entity<DaneshgahEntity>()
                .HasMany<TahseelEntity>(d => d.Tahseelat)
                .WithRequired(t => t.Daneshgah)
                .HasForeignKey(t => t.DaneshgahId);

            // between JaygaheSazmani and VahedeSazmani
            modelBuilder.Entity<JaygaheSazmaniEntity>()
                .HasRequired<VahedeSazmaniEntity>(j => j.VahedeSazmani)
                .WithMany(v => v.Jaygahha)
                .HasForeignKey(j => j.VahedeSazmaniId);

            // between VahedeSazmani and VahedeSazmani(below it)
            modelBuilder.Entity<VahedeSazmaniEntity>()
                .HasMany<VahedeSazmaniEntity>(V => V.VahedhayeSazmaniZirmajmue)
                .WithOptional(v => v.VahedeSazmaniBalatar)
                .HasForeignKey(v => v.VahedeSazmaniBalatarId);
        }

        public DbSet<PersonnelEntity> Personnels { get; set; }
        public DbSet<DaneshgahEntity> Daneshgahs { get; set; }
        public DbSet<FarzandEntity> Farzands { get; set; }
        public DbSet<JaygaheSazmaniEntity> JaygaheSazmanis { get; set; }
        public DbSet<TahseelEntity> Tahseels { get; set; }
        public DbSet<VahedeSazmaniEntity> VahedeSazmanis { get; set; }
    }
}
