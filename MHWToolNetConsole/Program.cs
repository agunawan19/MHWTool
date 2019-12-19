using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary;
using MHWLibrary.Enums;
using MHWLibrary.Models;
using Rank = MHWLibrary.Enums.Rank;

namespace MHWToolNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var armorSets = GetArmorSetList();
            var armors = armorSets.SelectMany(
                armorSet => armorSet.Armors,
                (armorSet, armor) => new
                {
                    armor.Id,
                    armor.Name,
                    armor.Resistance,
                    armor.Piece,
                    ArmorSetName = armorSet.Name
                });

            var query2 =
                (from armor in armors
                where armor.Resistance.Fire == 2
                      && armor.Piece == ArmorPiece.Helm
                select armor).ToList();

            armors
                .Where(armor => armor.Name.Contains(" Arms")).ToList()
                .ForEach(armor => Console.WriteLine(armor.Name));
        }

        private static List<IArmorSet> GetArmorSetList()
        {
            ArmorSet[] armorSets = new ArmorSet[3];
            ArmorFactory armorFactory = ArmorFactory.Instance;

            armorSets[0] = new ArmorSet
            {
                Id = 1,
                Name = "Test Set 1",
                Armors = GetArmorPieces("Armor One"),
                ArmorSetBonusSkill = new ArmorSetBonusSkill
                {
                    Id = 1,
                    Name = "Bonus Set",
                    Description = "Bonus set desription",
                    Skill = new Skill
                    {
                        SkillLevels = new List<ISkillLevel>
                        {
                            new SkillLevel
                            {
                                Description = "Skill Description 1"
                            }
                        }
                    }
                }
            };

            armorSets[1] = new ArmorSet
            {
                Id = 2,
                Name = "Test Set 2",
                Armors = GetArmorPieces("Armor Two"),
            };

            armorSets[2] = new ArmorSet
            {
                Id = 3,
                Name = "Test Set 3",
                Armors = armorFactory.Build(
                    new List<(ArmorPiece Piece, string Name)>
                    {
                        (ArmorPiece.Helm, "Armor Three Helm"),
                        (ArmorPiece.Chest, "Armor Three Chest"),
                        (ArmorPiece.Arms, "Armor Three Arms"),
                        (ArmorPiece.Waist, "Armor Three Waist"),
                        (ArmorPiece.Leg, "Armor Three Leg")
                    }).ToList()
            };

            return new List<IArmorSet>
            {
                armorSets[0],
                armorSets[1],
                armorSets[2]
            };
        }

        private static List<IArmor> GetArmorPieces(string armorName)
        {
            List<IArmor> armorPieces = new List<IArmor>
                {
                    new Head
                    {
                        Name = $"{armorName} Helm",
                        DecorationSlots = new List<DecorationSlot>
                        {
                            new DecorationSlot { Level = 1 },
                            new DecorationSlot { Level = 1 }
                        },
                        Resistance = new Resistance
                        {
                            Fire = 2
                        },
                        Skills = new List<ISkill>
                        {
                            new Skill
                            {
                                Id = 1,
                                Name = "Skill Name",
                                MaximumLevel = 3,
                                SkillLevels = new List<ISkillLevel>
                                {
                                    new SkillLevel
                                    {
                                        Level = 2,
                                        Description = "Skill Description",
                                    }
                                }
                            }
                        },
                        Materials = new List<IMaterial>
                        {
                            new Carving
                            {
                                Name = "Carving Name",
                                Rank = Rank.Master,
                                Monster = new MonsterBase
                                {
                                    Name = "Barroth",
                                }
                            },
                            new Material
                            {
                                Name = "IMaterial Name"
                            }
                        }
                    },
                    new Chest
                    {
                        Name = $"{armorName} Chest",
                        Materials = new List<IMaterial> {
                            new Carving
                            {
                                Name = "Carving Name",
                                Rank = Rank.Master,
                                Monster = new Monster
                                {
                                    Name = "Barroth"
                                }
                            }
                        }
                    },
                    new Arm
                    {
                        Name = $"{armorName} Arms"
                    },
                    new Waist
                    {
                        Name = $"{armorName} Waist"
                    },
                    new Leg
                    {
                        Name = $"{armorName} Leg"
                    }
                };

            return armorPieces;
        }
    }
}
