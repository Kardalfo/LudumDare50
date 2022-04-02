using System;


namespace Resources
{
    public static class ResourcesController
    {
        public static int CoinsAmount { get; private set; }

        private static Action<int> _coinsAmountChangedEvent;


        public static void AddCoins(int amount)
        {
            CoinsAmount += amount;
            _coinsAmountChangedEvent?.Invoke(CoinsAmount);
        }

        public static bool TrySubtract(int amount)
        {
            if (CoinsAmount < amount) 
                return false;
            
            AddCoins(-amount);
            return true;
        }

        public static void AddCoinsAmountListener(Action<int> listener)
        {
            _coinsAmountChangedEvent += listener;
        }

        public static void RemoveCoinsAmountListener(Action<int> listener)
        {
            _coinsAmountChangedEvent -= listener;
        }
    }
}
