using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        
        protected virtual void Awake()
        {
            closeButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
