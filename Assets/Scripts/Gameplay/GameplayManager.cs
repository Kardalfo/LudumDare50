using UnityEngine;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private CharactersGenerator generator;


        private void Start()
        {
            StartGame();
        }
        
        public void StartGame()
        {
            generator.CreateNewCharacter();
        }
    }
}
