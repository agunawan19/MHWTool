using System;
using System.Collections.Generic;
using MHWLibrary.Models;

namespace MHWToolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Test();
                Console.WriteLine("Hello World!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Test()
        {
            ArmorSet armorSet = new ArmorSet
            {
                Id = 1,
                Name = "Test",
                ArmorSetBonusSkill = null,
                Armors = new List<IArmor>
                {
                    new Head
                    {
                        Defense = 10
                    }
                }
            };
        }
    }
}
