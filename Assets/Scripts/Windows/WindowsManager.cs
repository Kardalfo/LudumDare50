using System;
using System.Collections.Generic;
using UnityEngine;

namespace Windows
{
    public class WindowsManager : MonoBehaviour
    {
        private static WindowsManager _instance;
        public static WindowsManager Instance => _instance;
        
        
        [SerializeField] private List<BaseWindow> windows;

        private Dictionary<Type, BaseWindow> _windowsByType = new Dictionary<Type, BaseWindow>();


        private void Awake()
        {
            foreach (var window in windows)
            {
                _windowsByType[window.GetType()] = window;
            }
            
            _instance = this;
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
    }
}
