using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image spriteRenderer;
        [SerializeField] private TMP_Text itemsAmount;
        [SerializeField] private Button itemButton;
        private Ingredient _ingredient;


        private void Awake()
        {
            itemButton.onClick.AddListener(OnClick);
        }
        
        public bool IsEmpty()
        {
            return _ingredient == null;
        }

        public void SetIngredient(Ingredient newIngredient)
        {
            _ingredient = newIngredient;
            spriteRenderer.sprite = newIngredient.Sprite;
            itemsAmount.text = newIngredient.IngredientType.ToString();
            gameObject.SetActive(true);
        }

        private void OnClick()
        {
            Debug.Log("ITEM CLICKED");
        }
    }
}