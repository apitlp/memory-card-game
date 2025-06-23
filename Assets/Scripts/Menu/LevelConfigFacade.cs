using TMPro;
using MemoryCardGame.Level;
using static MemoryCardGame.Menu.MenuInputHelper;

namespace MemoryCardGame.Menu
{
    public static class LevelConfigFacade
    {
        public static LevelConfig BuildLevelConfig
        (
            TMP_InputField timePerTurnInput,
            TMP_InputField cardsQuantityInput,
            TMP_InputField bonusQuantityInput,
            TMP_InputField debuffQuantityInput
        ) {
            var builder = new LevelBuilder(); 
            
            return builder
                .SetTimePerTurn(ReadInput(timePerTurnInput, LevelConfig.DefaultTimePerTurn))
                .SetCardsQuantity(ReadInput(cardsQuantityInput, LevelConfig.DefaultCardsQuantity))
                .SetBonusQuantity(ReadInput(bonusQuantityInput, LevelConfig.DefaultBonusQuantity))
                .SetDebuffQuantity(ReadInput(debuffQuantityInput, LevelConfig.DefaultDebuffQuantity))
                .GetConfig();
        }
    }
}