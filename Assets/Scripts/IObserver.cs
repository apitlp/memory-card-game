using System.Collections.Generic;

namespace MemoryCardGame
{
    public interface IObserver
    {
        void OnPointsChanged(int playerIndex, int newPoints);
        void OnCardsRendered();
        void OnTimeChanged(int playerIndex, float currentTime);
        void OnGameover(List<Player> players);
        void OnPlayerChanged(int playerIndex);
    }
}