using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DoFactory.GangOfFour.Visitor.RealWorld.Domains;
using Mhw.DataAccess;
using Mhw.Library.Enumerations;
using Mhw.Library.Models;
using Serilog;
using Employee = Mhw.Library.Models.Employee;
using EarningTaxationWithVisitorPattern;
using Mhw.Repository;
using System.Data.Entity;

namespace MHWToolNetConsole
{
    internal static class Program
    {
        private static void Main()
        {
            //using (var mhwContext = new MhwContext2())
            //{
            //    var record = mhwContext.Skills.Find(1);
            //    record.ModifiedDate = DateTime.Now;
            //    mhwContext.SaveChanges();
            //}

            //SampleOfUsingNoTracking();

            //GenerateReport();
            GenericRepositoryTest();
            //AnotherVisitorPatternTest();
            //GangOfFourVisitorPatternTest();
            //Test();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(@"logs\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello, world!");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }

            Log.CloseAndFlush();
            Console.ReadKey();

            var repository = new MhwRepository();

            var singleResult2 = repository.GetPersons();
            var singleResult1 = repository.GetMaterial(1);

            var result = repository.GetMaterials();

            var result2 = repository.GetSkills();

            var result3 = repository.GetMaterialTypes();

            Console.ReadLine();

            //var armorSets = GetArmorSetList();
            //var armors = armorSets.SelectMany(
            //    armorSet => armorSet.Armors,
            //    (armorSet, armor) => new
            //    {
            //        armor.Id,
            //        armor.Name,
            //        armor.Resistance,
            //        armor.Piece,
            //        ArmorSetName = armorSet.Name
            //    });

            //var query2 =
            //    (from armor in armors
            //     where armor.Resistance.Fire == 2
            //           && armor.Piece == ArmorPiece.Helm
            //     select armor).ToList();

            //armors
            //    .Where(armor => armor.Name.Contains(" Arms")).ToList()
            //    .ForEach(armor => Console.WriteLine(armor.Name));
        }

        private static void SampleOfUsingNoTracking()
        {
            using (var context = new MhwContext())
            {
                var skills = context.Skills.AsNoTracking().ToList();
                var skill = skills.First();
                skill.Name = "Skill 1 (Modified)";
                context.Skills.Attach(skill);
                context.Entry(skill).Property(t => t.Name).IsModified = true;

                var skill2 = new Skill
                {
                    Name = "New Skill 2",
                    MaximumLevel = 2
                };

                context.Skills.Add(skill2);

                context.SaveChanges();
            }
        }

        //private static List<IArmorSet> GetArmorSetList()
        //{
        //    var armorSets = new ArmorSet[3];
        //    var armorFactory = ArmorFactory.Instance;

        //    armorSets[0] = new ArmorSet
        //    {
        //        Id = 1,
        //        Name = "Test Set 1",
        //        Armors = GetArmorPieces("Armor One"),
        //        ArmorSetBonusSkill = new ArmorSetBonusSkill
        //        {
        //            Id = 1,
        //            Name = "Bonus Set",
        //            Description = "Bonus set desription",
        //            Skill = new Skill
        //            {
        //                SkillLevels = new List<SkillLevel>
        //                {
        //                    new SkillLevel
        //                    {
        //                        Description = "Skill Description 1"
        //                    }
        //                }
        //            }
        //        }
        //    };

        //    armorSets[1] = new ArmorSet
        //    {
        //        Id = 2,
        //        Name = "Test Set 2",
        //        Armors = GetArmorPieces("Armor Two"),
        //    };

        //    armorSets[2] = new ArmorSet
        //    {
        //        Id = 3,
        //        Name = "Test Set 3",
        //        Armors = armorFactory.Build(
        //            new List<(ArmorPiece Piece, string Name)>
        //            {
        //                (ArmorPiece.Helm, "Armor Three Helm"),
        //                (ArmorPiece.Chest, "Armor Three Chest"),
        //                (ArmorPiece.Arms, "Armor Three Arms"),
        //                (ArmorPiece.Waist, "Armor Three Waist"),
        //                (ArmorPiece.Leg, "Armor Three Leg")
        //            }).ToList()
        //    };

        //    return new List<IArmorSet>
        //    {
        //        armorSets[0],
        //        armorSets[1],
        //        armorSets[2]
        //    };
        //}

        //private static List<IArmor> GetArmorPieces(string armorName)
        //{
        //    var armorPieces = new List<IArmor>
        //    {
        //        new Head
        //        {
        //            Name = $"{armorName} Helm",
        //            DecorationSlots = new List<DecorationSlot>
        //            {
        //                new DecorationSlot { Level = 1 },
        //                new DecorationSlot { Level = 1 }
        //            },
        //            Resistance = new Resistance
        //            {
        //                Fire = 2
        //            },
        //            Skills = new List<ISkill>
        //            {
        //                new Skill
        //                {
        //                    Id = 1,
        //                    Name = "Skill Description",
        //                    MaximumLevel = 3,
        //                    SkillLevels = new List<SkillLevel>
        //                    {
        //                        new SkillLevel
        //                        {
        //                            Level = 2,
        //                            Description = "Skill Description",
        //                        }
        //                    }
        //                }
        //            },
        //            Materials = new List<IMaterial>
        //            {
        //                new Carving
        //                {
        //                    Name = "Carving Description",
        //                    Rank = Rank.Master,
        //                    Monster = new MonsterBase
        //                    {
        //                        Name = "Barroth",
        //                    }
        //                },
        //                new Material
        //                {
        //                    Name = "IMaterial Description"
        //                }
        //            }
        //        },
        //        new Chest
        //        {
        //            Name = $"{armorName} Chest",
        //            Materials = new List<IMaterial> {
        //                new Carving
        //                {
        //                    Name = "Carving Description",
        //                    Rank = Rank.Master,
        //                    Monster = new Monster
        //                    {
        //                        Name = "Barroth"
        //                    }
        //                }
        //            }
        //        },
        //        new Arm
        //        {
        //            Name = $"{armorName} Arms"
        //        },
        //        new Waist
        //        {
        //            Name = $"{armorName} Waist"
        //        },
        //        new Leg
        //        {
        //            Name = $"{armorName} Leg"
        //        }
        //    };

        //    return armorPieces;
        //}

        private static void Test()
        {
            var employee =
                Employee.CreateInstance()
                    .NameOfEmployee("First", "Last")
                    .WorkingOn("R & D")
                    .Born("10/10/1970")
                    .StaysAt("England");

            Console.WriteLine(employee);

            var habitat1 = Habitat.CreateInstance()
                .SetId(HabitatEnum.AncientForest)
                .SetName("Habitat 1")
                .SetModifiedDate(DateTime.MinValue);
            var habitat2 = Habitat.CreateInstance()
                .SetId(HabitatEnum.AncientForest)
                .SetName("Habitat 2");

            Console.ReadLine();
        }

        private static void GangOfFourVisitorPatternTest()
        {
            var e = new DoFactory.GangOfFour.Visitor.RealWorld.Domains.Employees();
            e.Attach(new Clerk())
                .Attach(new Director())
                .Attach(new President())
                .Accept(new IncomeVisitor())
                .Accept(new VacationVisitor());

            Console.ReadKey();
        }

        private static void AnotherVisitorPatternTest()
        {
            var employee = new EarningTaxationWithVisitorPattern.Employee
            {
                EmployeeId = "XYZ1001",
                EmployeeName = "Banketeshvar Narayan Sharma",
            };

            AddDataForEmployee(employee);

            var netAnnualEarningVisitor = new NetAnnualEarningVisitor();
            var annualTaxableAmount = new TaxableAmountVisitor();
            employee.Accept(netAnnualEarningVisitor);
            employee.Accept(annualTaxableAmount);

            Console.WriteLine($"Annual Net Earning Amount : {netAnnualEarningVisitor.NetEarningOfTheYear}");
            Console.WriteLine($"Annual Taxable Amount : {annualTaxableAmount.TaxableAmount}");
            Console.ReadKey();
        }

        private static void AddDataForEmployee(EarningTaxationWithVisitorPattern.Employee employee)
        {
            for (var i = 1; i <= 12; i++)
            {
                employee.Salaries.Add(new MonthlySalaryEarning
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo?.GetMonthName(i),
                    BasicSalary = 120_000,
                    HRAExemption = 50_000,
                    ConveyanceAllowance = 1_600,
                    PersonalAllowance = 45_000,
                    MedicalAllowance = 1_500,
                    TelephoneBill = 2_500,
                    FoodCardBill = 3_000,
                    OtherBills = 35_000
                });

                employee.Salaries.Add(new MonthlySalaryDeduction
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo?.GetMonthName(i),
                    ProvidentFundEmployeeContribution = 8_000,
                    ProvidentFundEmployerContribution = 8_000,
                    OtherDeduction = 700,
                    ProfessionTax = 200,
                    TDS = 15_000
                });

                employee.Salaries.Add(new MonthlyExpense
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo?.GetMonthName(1),
                    MonthlyRent = 10_000
                });
            }

            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "MediclaimPolicy",
                InvestmentAmount = 15_000
            });
            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "MediclaimPolicyforParents",
                InvestmentAmount = 25_000
            });
            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "HouseLoan",
                InvestmentAmount = 0
            });
            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "EducationLoan",
                InvestmentAmount = 0
            });
            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "OtherInvestment",
                InvestmentAmount = 5_000
            });
            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "RGESS",
                InvestmentAmount = 5_500
            });
            employee.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "Section80Cn80CCD_ExceptPF",
                InvestmentAmount = 100_000
            });
        }

        private static void GenericRepositoryTest()
        {
            using (var unitOfWork = new UnitOfWork<MhwContext>())
            {
                try
                {
                    //using (IPersonRepository personRepository = new PersonRepository(unitOfWork))
                    using (ISkillRepository skillRepository = new SkillRepository(unitOfWork))
                    //using (var personGenericRepository = new GenericRepository<Person>(unitOfWork))
                    //using (var skillGenericRepository = new GenericRepository<Skill>(unitOfWork))
                    using (var skillLevelGenericRepository = new GenericRepository<SkillLevel>(unitOfWork))
                    using (var habitatGenericRepository = unitOfWork.GenericRepository<Habitat>())
                    {
                        //var habitatGenericRepository = unitOfWork.GenericRepository<Habitat>();
                        //var personCollection = personGenericRepository.GetAll();
                        //var skillCollection = skillGenericRepository.GetAll();
                        var skillDetailCollection = skillRepository.GetDetailAll(false);
                        var skill = skillDetailCollection.First();
                        //var skillLevels = skillLevelGenericRepository.Find(t => t.SkillId == skill.Id, false).ToList();
                        //skillLevelGenericRepository.DeleteRange(skillLevels);
                        //skill.Name += "[Modified II]";
                        //skill.ModifiedDate = DateTime.Now;
                        //skillRepository.UpdateRange(skill);
                        //skillRepository.InsertOrUpdate(skill);
                        skillRepository.Delete(skill);

                        var skill2 = new Skill
                        {
                            Name = "New Skill Test InsertOrUpdate",
                            MaximumLevel = 3
                        };

                        //skillRepository.Insert(skill2);
                        skillRepository.InsertOrUpdate(skill2);


                        //var habitatQuery = habitatGenericRepository.FirstOrDefault(t => t.Name == "AncientForest");
                        //if (habitatQuery != null)
                        //{
                        //    habitatQuery.SetModifiedDate(DateTime.Now);
                        //    habitatGenericRepository.Update(habitatQuery);
                        //}
                        //var query = from habitat in habitatGenericRepository.Table
                        //    join tt in skillLevelGenericRepository.Table on (int)habitat.Id equals tt.Id
                        //    where habitat.Id == HabitatEnum.AncientForest
                        //    select habitat;

                            habitatGenericRepository.Update(new Habitat
                            {
                                Id = HabitatEnum.AncientForest,
                                Name = "AncientForest",
                                ModifiedDate = new DateTime(2020, 1, 20)
                            });

                        //var collection = personCollection.ToList();
                        //foreach (var person in collection)
                        //{
                        //    ProcessProperties(person);
                        //    person.Name += " Modified";
                        //    person.AddressLine += " Modified";
                        //    person.ModifiedDate = DateTime.Now;
                        //    //person.SetModifiedDate(DateTime.Today);
                        //}

                        //var updated = collection.Find(p => p.PersonId == 1);
                        //if (updated != null) updated.City = "City 1 Updated";

                        //personGenericRepository.UpdateRange(collection);
                        ////var singleOrDefault = collection.SingleOrDefault(p => p.Name.IndexOf("andri", StringComparison.OrdinalIgnoreCase) >= 0);
                        ////personRepository.Delete(singleOrDefault);

                        //personGenericRepository?.Insert(new Person
                        //{
                        //    Name = "Person One Name",
                        //    AddressLine = "Person One St",
                        //    City = "City",
                        //    ZipCode = "12345"
                        //});

                        //var enumerable = skillCollection.ToList();
                        //foreach (var skill in enumerable)
                        //{
                        //    skill.Name += " Modified";
                        //    skill.SetModifiedDate(DateTime.Now);
                        //}

                        //skillGenericRepository?.UpdateRange(enumerable);

                        unitOfWork.CreateTransaction();
                        var returnValue = unitOfWork.Save();
                        unitOfWork.Commit();
                    }
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private static void ProcessProperties(Person person)
        {
            var properties = typeof(Person).GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($@"{property.Name}: {property.GetValue(person)}");
            }

            Console.WriteLine(Enumerable.Repeat('-', 20).ToArray());
        }

        private static void GenerateReport()
        {
            var list = GenerateList();
            decimal totalHour = 0;
            var report = new StringBuilder();
            var groupedReport = new StringBuilder();

            report.Append("<Report>\r\n");

            for (var i = 0; i < list.Count; i++)
            {
                var (id, hour) = list[i];

                totalHour += hour;
                groupedReport.Append(GenerateRecord(id, hour));

                if (i < list.Count - 1 && list[i + 1].Id == id) continue;

                report.AppendFormat("<RECORD_{0}>\r\n", id);
                report.Append(GenerateHeader(id, totalHour));
                report.Append(groupedReport);
                report.AppendFormat("</RECORD_{0}>\r\n", id);
                groupedReport.Clear();
                totalHour = 0;
            }

            report.Append("</Report>\r\n");

            WriteToFileAsync($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\report.txt",
                new UTF8Encoding(true),
                report);

            //File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\report.txt", report.ToString(), Encoding.UTF8);

            Console.WriteLine(report.ToString());
        }

        private static List<(string Id, decimal Hour)> GenerateList() =>
            new List<(string, decimal)>
            {
                ("EMP000", 0.5m),
                ("EMP000", 0.5m),
                ("EMP001", 1.0m),
                ("EMP001", 1.1m),
                ("EMP002", 2.1m),
                ("EMP002", 2.1m),
                ("EMP003", 3.1m),
                ("EMP003", 3.1m),
                ("EMP003", 3.1m),
                ("EMP004", 4.0m),
                ("EMP005", 5.0m),
                ("EMP005", 5.0m),
                ("EMP006", 6.1m),
                ("EMP006", 6.2m),
                ("EMP006", 6.3m),
                ("EMP006", 6.4m),
                ("EMP006", 6.5m),
                ("EMP006", 6.6m),
                ("EMP007", 7.7m),
            };

        private static string GenerateHeader(string id, decimal totalHour) =>
            $"\t=================\r\n" +
            $"\tId = {id}\r\n" +
            $"\tTotal Hour = {totalHour}\r\n" +
            $"\t=================\r\n";

        private static string GenerateRecord(string id, decimal hour) =>
            $"\tEmployee Id = {id}\r\n" +
            $"\tHour = {hour}\r\n";

        private static StringBuilder GroupRecords(StringBuilder text, string id) =>
            text.Insert(0, $"<RECORD_{id}>\r\n").Append($"<RECORD_{id}/>\r\n");

        private static async void WriteToFileAsync(string filename, Encoding encoding, StringBuilder text)
        {
            byte[] result = encoding.GetBytes(text.ToString());

            using (var fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite,
                FileShare.ReadWrite, 1024, true))
            {
                fileStream.Seek(0, SeekOrigin.End);
                await fileStream.WriteAsync(result, 0, result.Length).ConfigureAwait(false);
            }

            //using (var sourceStream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{
            //    sourceStream.Seek(0, SeekOrigin.End);
            //    await sourceStream.WriteAsync(result, 0, result.Length).ConfigureAwait(false);
            //}

            //using (var writer = File.CreateText(filename))
            //{
            //    await writer.WriteAsync(text.ToString());
            //}
        }
    }
}