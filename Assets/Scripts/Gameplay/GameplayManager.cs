using System;
using Characters;
using Inventory;
using Resources;
using UnityEngine;
using UnityEngine.UI;
using Workspace;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private CharactersGenerator generator;
        [SerializeField] private int startLivesAmount;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private WorkspaceController workspaceController;
        [SerializeField] private Button restartButton;


        private void Awake()
        {
            ResourcesController.SetVisitorsCount(0);
            ResourcesController.SetLives(startLivesAmount);
            ResourcesController.SetLivesAmountListener(CheckLivesAmount);
            restartButton.onClick.AddListener(RestartOnButton);
        }
        
        public void StartGame()
        {
            generator.CreateNewCharacter();
        }

        private void CheckLivesAmount(int amount)
        {
            if (amount <= 0)
                Restart();
        }

        private void Restart()
        {
            ResourcesController.SetVisitorsCount(0);
            ResourcesController.SetLives(startLivesAmount);
            workspaceController.FreeWorkspaceItems();
            inventoryController.Restart();
        }
        
        private void RestartOnButton()
        {
            Restart();
            generator.CreateNewCharacter();
        }
    }
}
