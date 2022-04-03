using System;


namespace Resources
{
    public static class ResourcesController
    {
        public static int CoinsAmount { get; private set; }
        public static int TriesAmount { get; private set; }
        public static int MaxTriesAmount { get; private set; }
        
        public static int LivesAmount { get; private set; }

        private static Action<int> _coinsAmountChangedEvent;
        private static Action<int, int> _triesAmountChangedEvent;
        private static Action<int> _livesAmountChangedEvent;
        

        public static void AddCoins(int amount)
        {
            CoinsAmount += amount;
            _coinsAmountChangedEvent?.Invoke(CoinsAmount);
        }
        
        public static void SetCoins(int amount)
        {
            CoinsAmount = amount;
            _coinsAmountChangedEvent?.Invoke(CoinsAmount);
        }
        
        public static void AddLives(int amount)
        {
            LivesAmount += amount;
            _livesAmountChangedEvent?.Invoke(LivesAmount);
        }

        public static void SetTries(int amount)
        {
            TriesAmount = amount;
            MaxTriesAmount = amount;
            
            _triesAmountChangedEvent?.Invoke(TriesAmount, MaxTriesAmount);
        }

        public static bool TrySubtractCoins(int amount)
        {
            if (CoinsAmount < amount) 
                return false;
            
            AddCoins(-amount);
            return true;
        }
        
        public static void SubtractTries()
        {
            TriesAmount -= 1;
            _triesAmountChangedEvent?.Invoke(TriesAmount, MaxTriesAmount);
        }
        
        public static void SubtractLives(int amount = 1)
        {
            AddLives(-amount);
        }

        public static void AddCoinsAmountListener(Action<int> listener)
        {
            _coinsAmountChangedEvent += listener;
        }

        public static void RemoveCoinsAmountListener(Action<int> listener)
        {
            _coinsAmountChangedEvent -= listener;
        }

        public static void AddTriesAmountListener(Action<int, int> listener)
        {
            _triesAmountChangedEvent += listener;
        }

        public static void RemoveTriesAmountListener(Action<int, int> listener)
        {
            _triesAmountChangedEvent -= listener;
        }

        public static void AddLivesAmountListener(Action<int> listener)
        {
            _livesAmountChangedEvent += listener;
        }

        public static void RemoveLivesAmountListener(Action<int> listener)
        {
            _livesAmountChangedEvent -= listener;
        }
    }
}
