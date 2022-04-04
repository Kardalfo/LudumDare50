using System.Collections.Generic;
using Diseases;
using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InfoBubble
{
    public class InfoBubble : MonoBehaviour
    {
        [SerializeField] private DiseaseManager diseaseManager;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Image icon;
        [SerializeField] private List<Image> healImages;
        [SerializeField] private List<Image> diseaseImages;
        [SerializeField] private Sprite questionMark;


        public void SetIngredient(Ingredient ingredient)
        {
            icon.sprite = ingredient.Sprite;
            
            var healTypes = ingredient.Positive;
            for (var i = 0; i < healImages.Count; i++)
            {
                if (i >= healTypes.Count)
                {
                    healImages[i].gameObject.SetActive(false);
                    continue;
                }
                healImages[i].gameObject.SetActive(true);

                var ingredientData = healTypes[i];
                if (ingredientData.known)
                {
                    var disease = diseaseManager.GetDiseaseByType(ingredientData.diseaseType);
                    healImages[i].sprite = disease.Sprite;
                }
                else
                {
                    healImages[i].sprite = questionMark;
                }
            }
            
            var diseaseTypes = ingredient.Negative;
            for (var i = 0; i < diseaseImages.Count; i++)
            {
                if (i >= diseaseTypes.Count)
                {
                    diseaseImages[i].gameObject.SetActive(false);
                    continue;
                }
                diseaseImages[i].gameObject.SetActive(true);
                
                var ingredientData = diseaseTypes[i];
                if (ingredientData.known)
                {
                    var disease = diseaseManager.GetDiseaseByType(ingredientData.diseaseType);
                    diseaseImages[i].sprite = disease.Sprite;
                }
                else
                {
                    diseaseImages[i].sprite = questionMark;
                }
            }
        }

        public void SetPosition(Vector3 position)
        {
            var offsetX = rectTransform.rect.width / 2;
            transform.position = new Vector3(position.x - offsetX - 50, position.y, position.z);
        }
    }
}
