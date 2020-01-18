namespace EarningTaxationWithVisitorPattern
{
    public class MonthlyExpense : ISalary
    {
        public string MonthName { get; set; }
        public decimal MonthlyRent { get; set; }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}