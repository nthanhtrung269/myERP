using System.Data.Entity;

namespace QrCodeManagementApi.EntityManager.DbEntity
{
    /// <summary>
    /// Document: https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
    /// https://www.entityframeworktutorial.net/code-first/configure-entity-mappings-using-fluent-api.aspx
    /// </summary>
    public partial class QRCodeManagementEntities : DbContext
    {
        public QRCodeManagementEntities()
            : base("name=QRCodeManagementEntitiesConnection")
        {
            // Reference: https://stackoverflow.com/questions/13077328/serialization-of-entity-framework-objects-with-one-to-many-relationship/13077670
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logo>()
                .HasKey(e => e.Id)
                .ToTable("Logo");

            modelBuilder.Entity<Frame>()
                .HasKey(e => e.Id)
                .ToTable("Frame");

            modelBuilder.Entity<QRCode>()
                .HasKey(e => e.Id)
                .ToTable("QRCode");

            modelBuilder.Entity<Statictic>()
                .HasKey(e => e.Id)
                .ToTable("Statictics")
                .HasRequired(q => q.QRCode)
                .WithMany(q => q.Statictics)
                .HasForeignKey(v => v.QrId);

            modelBuilder.Entity<Template>()
                .HasKey(e => e.Id)
                .ToTable("Template");

            // Document: https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx
            modelBuilder.Entity<VCardDetail>()
                .HasKey(v => v.Id)
                .ToTable("VCardDetail")
                .HasRequired(q => q.QRCode)
                .WithMany(q => q.VCardDetails)
                .HasForeignKey(v => v.QrId);
        }

        public virtual DbSet<Logo> Logoes { get; set; }
        public virtual DbSet<Frame> Frames { get; set; }
        public virtual DbSet<QRCode> QRCodes { get; set; }
        public virtual DbSet<Statictic> Statictics { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<VCardDetail> VCardDetails { get; set; }
    }
}
