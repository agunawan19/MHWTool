using System;

namespace DoFactory.GangOfFour.Visitor.RealWorld.Domains
{
    public class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            if (!(element is Employee employee)) return;

            employee.VacationDays += 3;
            Console.WriteLine(
                $"{employee.GetType().Name} {employee.Name}'s new vacation days: {employee.VacationDays}");
        }
    }
}