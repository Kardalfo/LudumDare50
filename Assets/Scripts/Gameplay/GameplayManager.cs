using UnityEngine;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private CharactersGenerator generator;


        public void StartGame()
        {
            generator.CreateNewCharacter();
        }
    }
}
