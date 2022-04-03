using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Resources
{
    public class TriesView : MonoBehaviour
    {
        [SerializeField] private Image fill;
        [SerializeField] private TMP_Text amount;


        private void Awake()
        {
            ResourcesController.AddTriesAmountListener(OnTriesChanged);
            OnTriesChanged(ResourcesController.TriesAmount, ResourcesController.MaxTriesAmount);
        }

        private void OnTriesChanged(int current, int max)
        {
            fill.fillAmount = current / (float) max;
            amount.text = $"{current}/{max}";
        }
    }
}
