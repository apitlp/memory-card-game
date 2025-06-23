using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MemoryCardGame.Menu
{
    public class MenuController : MonoBehaviour
    {
        public TMP_InputField TimePerTurnInput;
        public TMP_InputField CardsQuantityInput;
        public TMP_InputField BonusQuantityInput;
        public TMP_InputField DebuffQuantityInput;
        
        private const string GameScene = "GameScene";
        
        public void StartButtonClicked()
        {
            var levelConfig = LevelConfigFacade.BuildLevelConfig(TimePerTurnInput, CardsQuantityInput, 
                BonusQuantityInput, DebuffQuantityInput);
            
            GameCore.Instance.StartGame(levelConfig);
            SceneManager.LoadScene(GameScene);
        }

        public void ExitButtonClicked()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
