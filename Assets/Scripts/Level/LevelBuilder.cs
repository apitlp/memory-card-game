namespace MemoryCardGame.Level
{
    public class LevelBuilder
    {
        private LevelConfig _levelConfig = new();

        public LevelBuilder Reset()
        {
            _levelConfig = new();
            return this;
        }

        public LevelBuilder SetTimePerTurn(int timePerTurn)
        {
            _levelConfig.TimePerTurn = timePerTurn;
            return this;
        }

        public LevelBuilder SetCardsQuantity(int cardsQuantity)
        {
            _levelConfig.CardsQuantity = cardsQuantity;
            return this;
        }

        public LevelBuilder SetBonusQuantity(int bonusQuantity)
        {
            _levelConfig.BonusQuantity = bonusQuantity;
            return this;
        }

        public LevelBuilder SetDebuffQuantity(int debuffQuantity)
        {
            _levelConfig.DebuffQuantity = debuffQuantity;
            return this;
        }

        public LevelConfig GetConfig() => _levelConfig;
    }
}