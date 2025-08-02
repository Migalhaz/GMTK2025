using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New Recipe Data", menuName = "Data/Recipe")]
    public class RecipeData : InfoData
    {
        [field:SerializeField] public Sprite m_RecipeImage { get; private set; }
        [field:SerializeField] public Recipe m_Recipe {  get; private set; }
    }

    [System.Serializable]
    public class Recipe
    {
        [field: SerializeField] public List<ItemData> m_RecipeIngredients { get; private set; }
        public Recipe()
        {
            m_RecipeIngredients = new List<ItemData>();
        }
    }
}
