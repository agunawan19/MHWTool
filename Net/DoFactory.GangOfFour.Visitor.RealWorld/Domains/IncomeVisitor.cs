using System;

namespace DoFactory.GangOfFour.Visitor.RealWorld.Domains
{
    public class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            if (!(element is Employee employee)) return;

            employee.Income *= 1.10;
            Console.WriteLine($"{employee.GetType().Name} {employee.Name}'s new income {employee.Income:C}");
        }
    }
}