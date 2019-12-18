using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHWLibrary.Models;
using MHWLibrary.Models.Interfaces;
using MHWLibraryNet.Models;

namespace MHWToolNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        private static void Test()
        {
            ArmorSet armorSet1 = new ArmorSet
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

            ArmorSet armorSet2 = new ArmorSet
            {
                Id = 2,
                Name = "Test Set 2",
                Armors = GetArmorPieces("Armor Two"),
            };
        }

        private static List<IArmor> GetArmorPieces(string armorName)
        {
            List<IArmor> armorPieces = new List<IArmor>
                {
                    new Helm
                    {
                        Name = $"{armorName} Helm",
                        DecorationSlots = new List<DecorationSlot>
                        {
                            new DecorationSlot { Level = 1 },
                            new DecorationSlot { Level = 1 }
                        },
                        Resistance = new Resistance(),
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
                        }
                    },
                    new Chest
                    {
                        Name = $"{armorName} Chest",
                    },
                    new Arm
                    {
                        Name = $"{armorName} Arm"
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
