using System.Threading;

namespace EarningTaxationWithVisitorPattern
{
    public interface IVisitor
    {
        void Visit(MonthlySalaryEarning monthlySalaryEarning);
        void Visit(MonthlySalaryDeduction monthlySalaryDeduction);
        void Visit(MonthlyExpense monthlyExpense);
        void Visit(AnnualInvestment annualInvestment);
    }
}