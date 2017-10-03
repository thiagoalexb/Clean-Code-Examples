
namespace CleanCode.SwitchStatements
{
    public abstract class Customer
    {
        public abstract MonthlyStatement GenerateStatment(MonthlyUsage monthlyUsage);
    }

    public enum CustomerType
    {
        PayAsYouGo = 1,
        Unlimited
    }
}
