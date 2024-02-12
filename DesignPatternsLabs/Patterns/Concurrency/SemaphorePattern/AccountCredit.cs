namespace Patterns.Concurrency.SemaphorePattern;

internal class AccountCredit (Account account)
{
    public double Credit(double amount)
    {
        if(amount <= 0)
            throw new ArgumentException("Amount should be grather than zero.");

        account.Balance += amount;

        return account.Balance;
    }
}