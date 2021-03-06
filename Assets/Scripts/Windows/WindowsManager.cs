using System;
using System.Collections.Generic;
using Ingredients;
using UnityEngine;

namespace Windows
{
    public class WindowsManager : MonoBehaviour
    {
        private static WindowsManager _instance;
        public static WindowsManager Instance => _instance;
        
        
        [SerializeField] private List<BaseWindow> windows;
        [SerializeField] private GameObject startWindow;
        [SerializeField] private InfoBubble.InfoBubble infoBubble;

        private readonly Dictionary<Type, BaseWindow> _windowsByType = new Dictionary<Type, BaseWindow>();


        private void Awake()
        {
            _instance = this;
            
            foreach (var window in windows)
            {
                _windowsByType[window.GetType()] = window;
                window.gameObject.SetActive(false);
            }
            
            startWindow.SetActive(true);
        }

        public void Open<T>() where T : BaseWindow
        {
            var window = _windowsByType[typeof(T)];
            window.gameObject.SetActive(true);
        }

        public void Close<T>() where T : BaseWindow
        {
            var window = _windowsByType[typeof(T)];
            window.gameObject.SetActive(false);
        }

        public void ShopIngredientInfo(Ingredient ingredient, Vector3 position)
        {
            infoBubble.SetPosition(position);
            infoBubble.SetIngredient(ingredient);
            infoBubble.gameObject.SetActive(true);
        }

        public void HideIngredientInfo()
        {
            infoBubble.gameObject.SetActive(false);
        }
    }
}
