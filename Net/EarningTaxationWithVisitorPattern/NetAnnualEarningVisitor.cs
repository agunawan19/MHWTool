using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarningTaxationWithVisitorPattern
{
    public class NetAnnualEarningVisitor : IVisitor
    {
        public decimal NetEarningOfTheYear { get; set; }

        public void Visit(MonthlySalaryEarning monthlySalaryEarning) =>
            NetEarningOfTheYear += monthlySalaryEarning.BasicSalary +
                                   monthlySalaryEarning.ConveyanceAllowance +
                                   monthlySalaryEarning.FoodCardBill +
                                   monthlySalaryEarning.HRAExemption +
                                   monthlySalaryEarning.MedicalAllowance +
                                   monthlySalaryEarning.OtherBills +
                                   monthlySalaryEarning.PersonalAllowance +
                                   monthlySalaryEarning.TelephoneBill;

        public void Visit(MonthlySalaryDeduction monthlySalaryDeduction) =>
            NetEarningOfTheYear -= monthlySalaryDeduction.ProvidentFundEmployeeContribution +
                                   monthlySalaryDeduction.ProvidentFundEmployerContribution +
                                   monthlySalaryDeduction.ProfessionTax +
                                   monthlySalaryDeduction.OtherDeduction;

        public void Visit(MonthlyExpense monthlyExpense)
        {

        }

        public void Visit(AnnualInvestment annualInvestment)
        {

        }
    }
}
