using System.Collections.Generic;
using Diseases;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private List<DiseaseType> positive;
        [SerializeField] private List<DiseaseType> negative;
    }
}
