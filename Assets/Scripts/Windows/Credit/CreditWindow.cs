

using System;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Credit
{
    public class CreditWindow : BaseWindow
    {
        [SerializeField] private Button button;
        [SerializeField] private int priceLivesAmount = 1;
        [SerializeField] private int rewardCoinsAmount = 50;
        [SerializeField] private TMP_Text livesAmount;
        [SerializeField] private TMP_Text coinsAmount;


        private void Awake()
        {
            button.onClick.AddListener(OnButtonClick);

            livesAmount.text = $"{priceLivesAmount}";
            coinsAmount.text = $"{rewardCoinsAmount}";
        }

        private void OnButtonClick()
        {
            WindowsManager.Instance.Close<CreditWindow>();
            
            ResourcesController.AddCoins(rewardCoinsAmount);
            ResourcesController.AddLives(-priceLivesAmount);
        }
    }
}
