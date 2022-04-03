using System.Collections.Generic;
using Diseases;
using Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace InfoBubble
{
    public class InfoBubble : MonoBehaviour
    {
        [SerializeField] private DiseaseManager diseaseManager;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private List<Image> healImages;
        [SerializeField] private List<Image> diseaseImages;


        public void SetIngredient(Ingredient ingredient)
        {
            var healTypes = ingredient.Positive;
            for (var i = 0; i < healImages.Count; i++)
            {
                if (i >= healTypes.Count)
                {
                    healImages[i].gameObject.SetActive(false);
                    continue;
                }
                healImages[i].gameObject.SetActive(true);
                
                var disease = diseaseManager.GetDiseaseByType(healTypes[i]);
                healImages[i].sprite = disease.Sprite;
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
                
                var disease = diseaseManager.GetDiseaseByType(diseaseTypes[i]);
                diseaseImages[i].sprite = disease.Sprite;
            }
        }

        public void SetPosition(Vector3 position)
        {
            var offsetX = rectTransform.rect.width / 2;
            transform.position = new Vector3(position.x - offsetX - 50, position.y, position.z);
        }
    }
}
