using System.Collections.Generic;
using UnityEngine;


namespace Ingredients
{
    public class IngredientsManager : MonoBehaviour
    {
        [SerializeField] private List<Ingredient> ingredients;

        public List<Ingredient> Ingredients => ingredients;
    }
}