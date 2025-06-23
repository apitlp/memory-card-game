using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MemoryCardGame.Level;
using MemoryCardGame.Cards;
using MemoryCardGame.Cards.Factory;
using MemoryCardGame.Cards.Handlers;
using UnityEngine;

namespace MemoryCardGame
{
    public class GameCore : MonoBehaviour
    {
        #region Singleton
        
        public static GameCore Instance { get; private set; }

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        #endregion
        
        #region Observer

        public List<IObserver> Observers { get; set; } = new();
        
        public void SubscribeObserver(IObserver observer)
        {
            if (!Observers.Contains(observer))
                Observers.Add(observer);
        }

        public void UnsubscribeObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }
        
        public void NotifyPointsChanged()
        {
            foreach (var observer in Observers)
                observer.OnPointsChanged(CurrentPlayerIndex, Players[CurrentPlayerIndex].Points);
        }

        public void NotifyCardsRendered()
        {
            foreach (var observer in Observers)
                observer.OnCardsRendered();
        }

        public void NotifyTimeChanged()
        {
            foreach (var observer in Observers)
                observer.OnTimeChanged(CurrentPlayerIndex, CurrentTime);
        }

        public void NotifyGameover()
        {
            foreach (var observer in Observers)
                observer.OnGameover(Players);
        }
        
        public void NotifyPlayerChanged()
        {
            foreach (var observer in Observers)
                observer.OnPlayerChanged(CurrentPlayerIndex);
        }
        
        #endregion
        
        #region Chain Of Responsibility
        
        private BaseCardHandler _cardHandlersChain;

        private void SetCardHandlersChain()
        {
            var debuff = new DebuffCardHandler();
            var bonus = new BonusCardHandler();
            var normal = new NormalCardHandler();
            
            debuff.SetNext(bonus);
            bonus.SetNext(normal);

            _cardHandlersChain = debuff;
        }
        
        #endregion

        private Coroutine _turnCoroutine;
        
        public LevelConfig LevelConfig { get; set; }
        public List<Card> Cards { get; } = new();
        public List<Player> Players { get; } = new()
        {
            new(),
            new()
        };
        public int CurrentPlayerIndex { get; private set; } = 0;
        public float CurrentTime { get; set; }
        public List<Card> SelectedCards { get; } = new()
        {
            null,
            null
        };
        public bool IsCardInteractionEnabled { get; private set; } = true;
        
        public void StartGame(LevelConfig levelConfig)
        {
            LevelConfig = levelConfig;
            FillCards();
            SetCardHandlersChain();
            
            StartTurn();
        }

        private void FillCards()
        {
            Cards.Clear();
            
            FabricateCards(new NormalCardFactory(), LevelConfig.CardsQuantity);
            FabricateCards(new BonusCardFactory(), LevelConfig.BonusQuantity);
            FabricateCards(new DebuffCardFactory(), LevelConfig.DebuffQuantity);

            Cards.Shuffle();
        }

        private void FabricateCards(ICardFactory cardFactory, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (cardFactory is NormalCardFactory && i >= quantity / 2)
                {
                    Cards.Add(Cards[i - quantity / 2].Clone() as Card);
                    continue;
                }
                
                Cards.Add(cardFactory.CreateCard());
            }
        }

        private void DeleteCard(Card card)
        {
            if (card is null)
                return;
            
            var baseCard = Card.GetBaseCard(card);
            var index = Cards.GetIndex(baseCard);

            if (index >= 0)
                Cards[index] = null;
        }
        
        public void RegisterCardClick(Card card)
        {
            if (!IsCardInteractionEnabled)
                return;
            
            _cardHandlersChain.Handle(card);
        }

        public void CheckCardsMatch()
        {
            if (SelectedCards.Any(c => c is null))
                return;

            IsCardInteractionEnabled = false;

            var (left, right) = SelectedCards;

            if (left.Content == right.Content)
            {
                ChangePoints();
                StartCoroutine(RenderCards(true));
            }

            StartCoroutine(RenderCards(false));
            ChangePlayer();
        }

        private void ChangePoints()
        {
            Players[CurrentPlayerIndex].AddPoint();
            NotifyPointsChanged();
        }

        private void ChangePlayer()
        {
            CurrentPlayerIndex = 1 - CurrentPlayerIndex;
            StartTurn();
            
            NotifyPlayerChanged();
        }

        private void StartTurn()
        {
            if (_turnCoroutine != null)
                StopCoroutine(_turnCoroutine);

            _turnCoroutine = StartCoroutine(StartTurnCoroutine());
        }

        private IEnumerator StartTurnCoroutine()
        {
            CurrentTime = LevelConfig.TimePerTurn + 2f;

            while (CurrentTime > 0f)
            {
                yield return new WaitForSeconds(1f);
                
                CurrentTime -= 1f;
                NotifyTimeChanged();
            }

            StartCoroutine(RenderCards(false));
            SelectedCards[0] = SelectedCards[1] = null;
            IsCardInteractionEnabled = false;
            ChangePlayer();
        }

        public void HandleEffect(Card card)
        {
            IsCardInteractionEnabled = false;
            DeleteCard(card);
                
            SelectedCards[0] = SelectedCards[1] = null;
            StartCoroutine(RenderCards(false));
        }

        private IEnumerator RenderCards(bool isMatch)
        {
            if (isMatch)
                foreach (var selectedCard in SelectedCards)
                    DeleteCard(selectedCard);

            yield return new WaitForSeconds(2f);

            if (!Cards.Any(c => Card.GetBaseCard(c) is NormalCard))
            {
                foreach (var card in Cards.ToList())
                    DeleteCard(card);
                
                StopCoroutine(_turnCoroutine);
                NotifyGameover();
            }
                
            NotifyCardsRendered();
            IsCardInteractionEnabled = true;
        }
    }
}
