using System;
using Mhw.DataAccess;
using Mhw.Library.Enumerations;
using Mhw.Library.Models;
using Serilog;

namespace MHWToolNetConsole
{
    internal static class Program
    {
        private static void Main()
        {
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
                .SetName("Habitat 1");
            var habitat2 = Habitat.CreateInstance()
                .SetId(HabitatEnum.AncientForest)
                .SetName("Habitat 2");

            Console.ReadLine();
        }
    }
}