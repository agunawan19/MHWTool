using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using JetBrains.Annotations;

namespace Mhw.DataAccess.Conventions
{
    [UsedImplicitly]
    internal class DefaultValueConvention : Convention
    {
        private const string DefaultValue = "DefaultValue";
        private const string DefaultValueSql = "DefaultValueSql";
        private const string SqlDateTimeColumnType = "DateTime2";
        private const string CreatedDateUtc = "CreatedUtcDate";
        private const string GetUtcDate = "GETUTCDATE()";
        private const string CurrentTimestamp = "CURRENT_TIMESTAMP";

        internal DefaultValueConvention()
        {
            //Properties()
            //    .Where(p => p.Name == p.DeclaringType?.Name + "_ID")
            //    .Configure(p => p.IsKey());
            SetStringDefaultValueConvention();
            SetUtcDateForCreatedDate();
            SetDateTimeDefaultValueConvention();
        }

        private void SetStringDefaultValueConvention() =>
            Properties()
                .Where(p => p.PropertyType.Name == nameof(String))
                .Configure(p =>
                {
                    p.IsRequired()
                        .HasColumnAnnotation(DefaultValue, string.Empty);
                });

        private void SetUtcDateForCreatedDate() =>
            Properties()
                .Where(p => p.PropertyType.Name == nameof(DateTime) && p.Name == CreatedDateUtc)
                .Configure(p =>
                {
                    p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                        .HasColumnAnnotation(DefaultValueSql, GetUtcDate)
                        .HasColumnType(SqlDateTimeColumnType);
                });

        private void SetDateTimeDefaultValueConvention() =>
            Properties()
                .Where(p => p.PropertyType.Name == nameof(DateTime) && p.Name != CreatedDateUtc)
                .Configure(p =>
                    p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                        .HasColumnAnnotation(DefaultValueSql, CurrentTimestamp)
                        .HasColumnType(SqlDateTimeColumnType)
                );
    }
}