namespace EarningTaxationWithVisitorPattern
{
    public class AnnualInvestment : ISalary
    {
        public string InvestmentDetails { get; set; }
        public decimal InvestmentAmount { get; set; }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}