using Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Start
{
    public class StartWindow : BaseWindow
    {
        [SerializeField] private GameplayManager gameplayManager;
        [SerializeField] private Button startButton;


        private void Awake()
        {
            startButton.onClick.AddListener(OnStartButton);
        }

        private void OnStartButton()
        {
            gameplayManager.StartGame();
            WindowsManager.Instance.Close<StartWindow>();
        }
    }
}
