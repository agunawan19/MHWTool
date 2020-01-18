namespace EarningTaxationWithVisitorPattern
{
    public class TaxableAmountVisitor : IVisitor
    {
        public decimal TaxableAmount { get; set; }

        public void Visit(MonthlySalaryEarning monthlySalaryEarning) =>
            TaxableAmount += monthlySalaryEarning.BasicSalary +
                             monthlySalaryEarning.HRAExemption +
                             monthlySalaryEarning.MedicalAllowance +
                             monthlySalaryEarning.PersonalAllowance;

        public void Visit(MonthlySalaryDeduction monthlySalaryDeduction) =>
            TaxableAmount -= monthlySalaryDeduction.ProvidentFundEmployeeContribution +
                             monthlySalaryDeduction.ProvidentFundEmployerContribution +
                             monthlySalaryDeduction.ProfessionTax +
                             monthlySalaryDeduction.OtherDeduction;

        public void Visit(MonthlyExpense monthlyExpense) =>
            TaxableAmount -= monthlyExpense.MonthlyRent;

        public void Visit(AnnualInvestment annualInvestment) =>
            TaxableAmount -= annualInvestment.InvestmentAmount;
    }
}