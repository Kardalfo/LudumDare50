using Windows;
using Ingredients;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InfoBubble
{
    public class IngredientItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        protected Ingredient Ingredient;
        
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            WindowsManager.Instance.ShopIngredientInfo(Ingredient, Input.mousePosition);
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            
            WindowsManager.Instance.HideIngredientInfo();
        }
    }
}
