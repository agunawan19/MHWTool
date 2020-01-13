﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MHWLibrary.Models;

namespace MHWEntity.EntityConfigurations
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
            Map(m =>
            {
                m.Properties(t => new { t.PersonId });
                m.Property(t => t.Name).HasColumnName("PersonName");
                m.ToTable("People");
            }).Map(m =>
            {
                m.Property(t => t.PersonId).HasColumnName("ProprietorId");
                m.Properties(t => new { t.AddressLine, t.City, t.ZipCode, t.ModifiedDate });
                m.ToTable("PersonDetails");
            });
        }
    }
}