using System.Collections.Generic;
using UnityEngine;
using MemoryCardGame.Cards;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MemoryCardGame
{
    public class GameController : MonoBehaviour, IObserver
    {
        public Transform CardPanel;
        public GameObject Card;
        public Transform PlayerOnePanel;
        public Transform PlayerTwoPanel;

        private static string MenuScene = "MenuScene";

        private void Start()
        {
            GameCore.Instance.SubscribeObserver(this);
            InstantiateCards();
        }

        private void OnDestroy()
        {
            GameCore.Instance.UnsubscribeObserver(this);
        }

        private void InstantiateCards()
        {
            foreach (Transform prevCard in CardPanel)
                Destroy(prevCard.gameObject);

            foreach (var card in GameCore.Instance.Cards)
            {
                var cardGameObject = Instantiate(Card, CardPanel);
                var image = cardGameObject.GetComponent<Image>();
                var button = cardGameObject.GetComponent<Button>();

                if (card is null)
                {
                    image.color = new Color(1, 1, 1, 0);
                    button.interactable = false;

                    continue;
                }
             
                Card actualCard = Cards.Card.GetBaseCard(card); 
                
                var sprite = Resources.Load<Sprite>("Images/Cards/" + actualCard.Path);
                
                image.color = Color.white;

                var capturedCard = card;
                button.onClick.AddListener(() =>
                {
                    if (!GameCore.Instance.IsCardInteractionEnabled)
                        return;
                    
                    capturedCard.OnClick();
                    
                    image.sprite = sprite;
                    
                    GameCore.Instance.RegisterCardClick(actualCard);
                });
            }
        }

        public void OnPointsChanged(int playerIndex, int newPoints)
        {
            var currentPanel = playerIndex == 0 ? PlayerOnePanel : PlayerTwoPanel;
            var currentPlayerName = playerIndex == 0 ? "One" : "Two";

            var pointsLabel = currentPanel.Find($"Player{currentPlayerName}Points");
            var pointsTextComponent = pointsLabel.GetComponent<TMP_Text>();
            pointsTextComponent.text = $"Points: {newPoints}";
        }

        public void OnCardsRendered()
        {
            InstantiateCards();
        }

        public void OnTimeChanged(int playerIndex, float currentTime)
        {
            var currentPanel = playerIndex == 0 ? PlayerOnePanel : PlayerTwoPanel;
            var currentPlayerName = playerIndex == 0 ? "One" : "Two";

            var timeLabel = currentPanel.Find($"Player{currentPlayerName}Time");
            var timeTextComponent = timeLabel.GetComponent<TMP_Text>();
            timeTextComponent.text = $"Time: {Mathf.Round(currentTime)} s";
        }

        public void OnGameover(List<Player> players)
        {
            string winner = null;
            if (players[0].Points > players[1].Points)
                winner = "One";
            if (players[0].Points < players[1].Points)
                winner = "Two";

            var playerOneLabel = PlayerOnePanel.Find($"PlayerOneVictory");
            var playerOneTextComponent = playerOneLabel.GetComponent<TMP_Text>();
            
            var playerTwoLabel = PlayerTwoPanel.Find($"PlayerTwoVictory");
            var playerTwoTextComponent = playerTwoLabel.GetComponent<TMP_Text>();

            if (winner == null)
            {
                playerOneTextComponent.text = playerTwoTextComponent.text = "Tie";
                return;
            }

            playerOneTextComponent.text = winner == "One" ? "Winner" : "Loser";
            playerTwoTextComponent.text = winner == "Two" ? "Winner" : "Loser";
        }

        public void OnPlayerChanged(int playerIndex)
        {
            var currentPanel = playerIndex == 0 ? PlayerOnePanel : PlayerTwoPanel;
            var oppositePanel = playerIndex == 0 ? PlayerTwoPanel : PlayerOnePanel;

            var currentPanelImageComponent = currentPanel.GetComponent<Image>();
            var oppositePanelImageComponent = oppositePanel.GetComponent<Image>();
            
            currentPanelImageComponent.color = new Color(0, 255, 0, 0.6f);
            oppositePanelImageComponent.color = new Color(255, 0, 0, 0.6f);
        }

        public void ResetButtonClicked()
        {
            SceneManager.LoadScene(MenuScene);
        }
    }
}