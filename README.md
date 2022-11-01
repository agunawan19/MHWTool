Code First Migration Steps
--------------------------
Enable-Migrations -ContextTypeName Mhw.DataAccess.MhwMigrationContext -Verbose
Add-Migration Initial -StartUpProjectName Mhw.DataAccess.EF -Verbose
Add-Migration Test -ProjectName Mhw.DataAccess.EF -StartUpProjectName Mhw.DataAccess.EF -Verbose
Update-Database -ProjectName Mhw.DataAccess.EF -StartUpProjectName Mhw.DataAccess.EF -Verbose
