using System;
using Resources;
using UnityEngine;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private CharactersGenerator generator;
        [SerializeField] private int start_lives_amount;


        private void Awake()
        {
            ResourcesController.AddLives(start_lives_amount);
            ResourcesController.AddLivesAmountListener(CheckLivesAmount);
        }

        private void Start()
        {
            StartGame();
        }
        
        public void StartGame()
        {
            generator.CreateNewCharacter();
        }

        private void CheckLivesAmount(int amount)
        {
            if (amount <= 0)
            {
                Debug.Log("Game Ended");
            }
        }
    }
}
