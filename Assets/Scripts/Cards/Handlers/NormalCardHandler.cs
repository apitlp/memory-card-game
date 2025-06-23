namespace MemoryCardGame.Cards.Handlers
{
    public class NormalCardHandler : BaseCardHandler
    {
        protected override bool TryHandle(Card card)
        {
            if (card is not NormalCard)
                return false;

            var gameCore = GameCore.Instance;

            if (gameCore.SelectedCards[0] is null)
            {
                gameCore.SelectedCards[0] = card;
                return true;
            }
            
            if (ReferenceEquals(gameCore.SelectedCards[0], card))
                return true;

            if (gameCore.SelectedCards[1] is null)
            {
                gameCore.SelectedCards[1] = card;
                
                gameCore.CheckCardsMatch();

                gameCore.SelectedCards[0] = gameCore.SelectedCards[1] = null;
            }

            return true;
        }
    }
}