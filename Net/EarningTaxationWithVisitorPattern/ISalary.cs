namespace EarningTaxationWithVisitorPattern
{
    public interface ISalary
    {
        void Accept(IVisitor visitor);
    }
}