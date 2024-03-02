namespace _Scripts.Signals
{
    public class BalanceSpendResponseSignal
    {
        public bool Success { get; set; }

        public BalanceSpendResponseSignal(bool success)
        {
            Success = success;
        }
    }
}