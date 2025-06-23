namespace MemoryCardGame.Level
{
    public class LevelConfig
    {
        private int _timePerTurn = DefaultTimePerTurn;
        private int _cardsQuantity = DefaultCardsQuantity;
        private int _bonusQuantity = DefaultBonusQuantity;
        private int _debuffQuantity = DefaultDebuffQuantity;
        
        public const int DefaultTimePerTurn = 30;
        public const int DefaultCardsQuantity = 32;
        public const int DefaultBonusQuantity = 4;
        public const int DefaultDebuffQuantity = 4;
        
        public int TimePerTurn
        {
            get => _timePerTurn;
            set
            {
                if (value < 10)
                    value = 10;
                if (value > 99)
                    value = 99;

                _timePerTurn = value;
            }
        }
        public int CardsQuantity
        {
            get => _cardsQuantity;
            set
            {
                if (value % 2 == 1)
                    value++;
                if (value < 8)
                    value = 8;
                if (value > 48)
                    value = 48;
                
                _cardsQuantity = value;
            }
        }
        public int BonusQuantity
        {
            get => _bonusQuantity;
            set
            {
                if (value < 0)
                    value = 0;
                if (value > 9)
                    value = 9;

                _bonusQuantity = value;
            }
        }
        public int DebuffQuantity
        {
            get => _debuffQuantity;
            set
            {
                if (value < 0)
                    value = 0;
                if (value > 9)
                    value = 9;

                _debuffQuantity = value;
            }
        }
    }
}