using Windows;
using Ingredients;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InfoBubble
{
    public class IngredientItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Ingredient Ingredient { get; protected set; }


        public void OnPointerEnter(PointerEventData eventData)
        {
            WindowsManager.Instance.ShopIngredientInfo(Ingredient, Input.mousePosition);
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            WindowsManager.Instance.HideIngredientInfo();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            WindowsManager.Instance.HideIngredientInfo();
        }
    }
}
