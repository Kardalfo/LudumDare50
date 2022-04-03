using TMPro;
using UnityEngine;


namespace Resources
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text amount;


        private void Awake()
        {
            SetAmount(ResourcesController.CoinsAmount);
            ResourcesController.AddCoinsAmountListener(SetAmount);
        }

        private void SetAmount(int coinsAmount)
        {
            amount.text = coinsAmount.ToString();
        }
    }
}
