using System;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Model;
using System.Runtime.InteropServices;
using IndentedTextWriter = System.Data.Entity.Migrations.Utilities.IndentedTextWriter;

namespace MHWEntity.MigrationCodeGenerator
{
    public class ExtendedMigrationCodeGenerator : CSharpMigrationCodeGenerator
    {
        protected override void Generate(ColumnModel column, IndentedTextWriter writer, bool emitName = false)
        {
            if (column.Annotations.Keys.Contains("DefaultValue"))
            {
                var defaultValue = Convert.ChangeType(column.Annotations["DefaultValue"].NewValue, column.ClrDefaultValue.GetType());
                if (defaultValue != null) column.DefaultValue = defaultValue;
            }
            else if (column.Annotations.Keys.Contains("DefaultValueSql"))
            {
                column.DefaultValueSql = column.Annotations["DefaultValueSql"].NewValue?.ToString();
            }

            base.Generate(column, writer, emitName);
        }
    }
}