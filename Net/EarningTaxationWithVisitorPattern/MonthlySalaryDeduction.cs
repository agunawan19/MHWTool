namespace EarningTaxationWithVisitorPattern
{
    public class MonthlySalaryDeduction : ISalary
    {
        public string MonthName { get; set; }
        public decimal ProvidentFundEmployeeContribution { get; set; }
        public decimal ProvidentFundEmployerContribution { get; set; }
        public decimal ProfessionTax { get; set; }
        public decimal TDS { get; set; }
        public decimal OtherDeduction { get; set; }
        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}