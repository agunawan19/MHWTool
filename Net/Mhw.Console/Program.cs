using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using DoFactory.GangOfFour.Visitor.RealWorld.Domains;
using Mhw.DataAccess;
using Mhw.Library.Enumerations;
using Mhw.Library.Models;
using Serilog;
using Employee = Mhw.Library.Models.Employee;
using EarningTaxationWithVisitorPattern;
using Mhw.Repository;

namespace MHWToolNetConsole
{
    internal static class Program
    {
        private static void Main()
        {
            GenericRepositoryTest();
            AnotherVisitorPatternTest();
            GangOfFourVisitorPatternTest();
            Test();

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
                    using (IPersonRepository personRepository = new PersonRepository(unitOfWork))
                    using (var personGenericRepository = new GenericRepository<Person>(unitOfWork))
                    using (var skillGenericRepository = new GenericRepository<Skill>(unitOfWork))
                    {
                        var personCollection = personGenericRepository.GetAll();
                        var skillCollection = skillGenericRepository.GetAll();

                        var habitatGenericRepository = unitOfWork.GenericRepository<Habitat>();
                        var habitatQuery = habitatGenericRepository.FirstOrDefault(t => t.Name == "AncientForest");

                        var collection = personCollection.ToList();
                        foreach (var person in collection)
                        {
                            ProcessProperties(person);
                            person.Name += " Modified";
                            person.AddressLine += " Modified";
                            person.ModifiedDate = DateTime.Now;
                            //person.SetModifiedDate(DateTime.Today);
                        }

                        var updated = collection.Find(p => p.PersonId == 1);
                        if (updated != null) updated.City = "City 1 Updated";

                        //personGenericRepository.Update(collection);
                        //var singleOrDefault = collection.SingleOrDefault(p => p.Name.IndexOf("andri", StringComparison.OrdinalIgnoreCase) >= 0);
                        //personRepository.Delete(singleOrDefault);

                        personRepository?.Insert(new Person
                        {
                            Name = "Andri Gunawan",
                            AddressLine = "Pilario St.",
                            City = "Rowland Heights",
                            ZipCode = "91748"
                        });

                        var enumerable = skillCollection.ToList();
                        foreach (var skill in enumerable)
                        {
                            skill.Name += " Modified";
                            skill.SetModifiedDate(DateTime.Now);
                        }

                        skillGenericRepository?.Update(enumerable);

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
    }
}