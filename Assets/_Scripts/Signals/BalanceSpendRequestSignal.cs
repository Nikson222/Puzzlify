namespace _Scripts.Signals
{
    public class BalanceSpendRequestSignal
    {
        public int Amount { get; set; }

        public BalanceSpendRequestSignal(int amount)
        {
            Amount = amount;
        }
    }
}