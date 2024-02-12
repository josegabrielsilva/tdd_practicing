namespace Patterns.Concurrency.SemaphorePattern;

internal class AccountDebit(Account account)
{
    public double Debit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount should be grather than zero.");

        if (amount > account.Balance)
            throw new ArgumentException("Account havent enought balance.");

        account.Balance -= amount;

        return account.Balance;
    }
}