namespace Patterns.Concurrency.SemaphorePattern
{
    public class AccountOperation(AccountOperationType operation, double amount)
    {
        public AccountOperationType Operation { get; set; } = operation;
        public double Amount { get; set; } = amount;
    }
}