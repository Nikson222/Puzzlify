using System;
using System.Collections.Generic;
using _Scripts.Signals;
using Zenject;

namespace Models
{
    public class PlayerModel
    {
        private readonly SignalBus _signalBus;
        
        private int _balance = 1000;
        private HashSet<int> _unlockedPuzzlesIDs;
        
        public event Action<int> OnBalanceChanged;
        
        public PlayerModel(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            _signalBus.Subscribe<BalanceSpendRequestSignal>(SpendMoney);
        }
        
        private void SpendMoney(BalanceSpendRequestSignal signal)
        {
            if (_balance >= signal.Amount)
            {
                _balance -= signal.Amount;
                OnBalanceChanged?.Invoke(_balance);
                _signalBus.Fire(new BalanceSpendResponseSignal(true)); 
            }
            else
                _signalBus.Fire(new BalanceSpendResponseSignal(false));
        }

        public void SendUpdateSignal()
        {
            OnBalanceChanged?.Invoke(_balance);
        }
    }
}