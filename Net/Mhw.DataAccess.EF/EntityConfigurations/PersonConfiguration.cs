using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography;
using JetBrains.Annotations;
using Mhw.Library.Models;

namespace Mhw.DataAccess.EntityConfigurations
{
    [UsedImplicitly]
    internal sealed class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        internal PersonConfiguration()
        {
            /*
            modelBuilder.Entity<Person>().Map(m =>
            {
                m.Properties(t => new { t.PersonId, t.Name });
                m.ToTable("People");
            }).Map(m =>
            {
                m.Properties(t => new { t.PersonId, t.AddressLine, t.City, t.ZipCode });
                m.ToTable("PersonDetails");
            });

            modelBuilder.Entity<Person>().Map(m =>
            {
                m.Properties(t => new { t.PersonId });
                m.Property(t => t.Name).HasColumnName("PersonName");
                m.ToTable("People");
                }).Map(m =>
            {
                m.Property(t => t.PersonId).HasColumnName("ProprietorId");
                m.Properties(t => new { t.AddressLine, t.City, t.ZipCode });
                m.ToTable("PersonDetails");
            });
            */
            Property(t => t.Name).HasMaxLength(100);
            Property(t => t.AddressLine).HasMaxLength(200);
            Property(t => t.City).HasMaxLength(50);
            Property(t => t.ZipCode).HasColumnType("varchar").HasMaxLength(10);

            //MapToStoredProcedures();

            Map(m =>
            {
                m.Properties(t => new { t.PersonId });
                m.Property(t => t.Name).HasColumnName("PersonName");
                m.ToTable("People");
            }).Map(m =>
            {
                m.Property(t => t.PersonId).HasColumnName("ProprietorId");
                m.Properties(t => new { t.AddressLine, t.City, t.ZipCode, t.CreatedUtcDate, t.ModifiedDate });
                m.ToTable("PersonDetails");
            });
        }
    }
}