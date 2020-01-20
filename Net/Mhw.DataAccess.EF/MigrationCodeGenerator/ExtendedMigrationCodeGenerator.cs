using System;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Model;
using JetBrains.Annotations;
using IndentedTextWriter = System.Data.Entity.Migrations.Utilities.IndentedTextWriter;

namespace Mhw.DataAccess.MigrationCodeGenerator
{
    public class ExtendedMigrationCodeGenerator : CSharpMigrationCodeGenerator
    {
        protected override void Generate(ColumnModel column, IndentedTextWriter writer, bool emitName = false)
        {
            if (column.Annotations.ContainsKey("DefaultValue"))
            {
                var defaultValue = Convert.ChangeType(column.Annotations["DefaultValue"].NewValue, column.ClrDefaultValue.GetType());
                if (defaultValue != null) column.DefaultValue = defaultValue;
            }
            else if (column.Annotations.ContainsKey("DefaultValueSql"))
            {
                column.DefaultValueSql = column.Annotations["DefaultValueSql"].NewValue?.ToString();
            }

            base.Generate(column, writer, emitName);
        }
    }
}