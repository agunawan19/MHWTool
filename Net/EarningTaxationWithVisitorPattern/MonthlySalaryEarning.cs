namespace EarningTaxationWithVisitorPattern
{
    public class MonthlySalaryEarning : ISalary
    {
        public string MonthName { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HRAExemption { get; set; }
        public decimal ConveyanceAllowance { get; set; }
        public decimal PersonalAllowance { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal TelephoneBill { get; set; }
        public decimal FoodCardBill { get; set; }
        public decimal OtherBills { get; set; }

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}