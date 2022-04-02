using Ingredients;
using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public UnityEvent clickEvent;
        private Ingredient ingredient;

        private int _itemsAmount;

        public bool IsEmpty()
        {
            return ingredient == null;
        }

        public void SetIngredient(Ingredient newIngredient)
        {
            ingredient = newIngredient;
        }
    }
}