using UnityEngine;
using UnityEngine.UI;

namespace Windows
{
    [RequireComponent(typeof(Button))]
    public class WindowButton<T> : MonoBehaviour
        where T : BaseWindow
    {
        private Button _button;


        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
            WindowsManager.Instance.Open<T>();
        }
    }
}
