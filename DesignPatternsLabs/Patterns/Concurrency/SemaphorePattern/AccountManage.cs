namespace Patterns.Concurrency.SemaphorePattern
{
    public class AccountManage
    {
        private static readonly SemaphoreSlim semaphore = new (1, 1);

        public static async Task Movement(Account account, double value, AccountOperationType operation)
        {
            try
            {
                await semaphore.WaitAsync();

                Thread.Sleep(TimeSpan.FromSeconds(2));

                _ = operation == AccountOperationType.Debit
                    ? new AccountDebit(account).Debit(value)
                    : new AccountCredit(account).Credit(value);
            }finally
            {
                semaphore.Release();
                Console.WriteLine($"{Environment.CurrentManagedThreadId} {operation} operation of R$ {value:c2}, current balance R$ {account.Balance}...");
            }
        }
    }
}