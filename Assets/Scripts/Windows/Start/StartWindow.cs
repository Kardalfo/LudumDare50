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
            startButton.onClick.AddListener(gameplayManager.StartGame);
            WindowsManager.Instance.Close<StartWindow>();
        }
    }
}
