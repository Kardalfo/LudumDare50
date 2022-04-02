using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TMP_Text _itemsAmount;
        public UnityEvent clickEvent;
        private Ingredient ingredient;


        private void Awake()
        {
            clickEvent.AddListener(OnClick);
        }
        
        public bool IsEmpty()
        {
            return ingredient == null;
        }

        public void SetIngredient(Ingredient newIngredient)
        {
            ingredient = newIngredient;
            _itemsAmount.text = newIngredient.IngredientType.ToString();
            gameObject.SetActive(true);
        }

        private void OnClick()
        {
            Debug.Log("ITEM CLICKED NAHUI");
        }
    }
}