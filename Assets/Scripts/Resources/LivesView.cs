using System.Collections.Generic;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesView : MonoBehaviour
{
    [SerializeField] private TMP_Text amount;
    [SerializeField] private Image lives1;
    [SerializeField] private Image lives2;
    [SerializeField] private Image lives3;


    private void Awake()
    {
        SetAmount(ResourcesController.LivesAmount);
        ResourcesController.SetLivesAmountListener(SetAmount);
    }

    private void SetAmount(int livesAmount)
    {
        /*amount.text = livesAmount.ToString();*/
        switch(livesAmount)
        {
            case 0:
                lives1.gameObject.SetActive(false);
                lives2.gameObject.SetActive(false);
                lives3.gameObject.SetActive(false);
                break;
            case 1:
                lives1.gameObject.SetActive(true);
                lives2.gameObject.SetActive(false);
                lives3.gameObject.SetActive(false);
                break;
            case 2:
                lives1.gameObject.SetActive(true);
                lives2.gameObject.SetActive(true);
                lives3.gameObject.SetActive(false);
                break;
            case 3:
                lives1.gameObject.SetActive(true);
                lives2.gameObject.SetActive(true);
                lives3.gameObject.SetActive(true);
                break;
        }
    }
}
