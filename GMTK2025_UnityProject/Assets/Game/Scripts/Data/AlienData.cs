using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New Alien Data", menuName = "Data/Alien")]
    public class AlienData : InfoData
    {
        [field: SerializeField] public List<Restriction> m_Restrictions { get; private set; }

        public bool AllowItem(ItemData item)
        {
            foreach (Restriction restriction in m_Restrictions)
            {
                if (restriction.m_Item == item) return false;
            }
            return true;
        }

        public Recipe GetRecipe(RecipeData currentRecipe)
        {
            Recipe result = new Recipe();
            foreach (var i in currentRecipe.m_Recipe.m_RecipeIngredients)
            {
                ItemData recipeItem = AllowItem(i) ? i : m_Restrictions.Find(x => x.m_Item == i).m_Replace;
                result.m_RecipeIngredients.Add(recipeItem);
            }
            return result;
        }
    }

    [System.Serializable]
    public class Restriction
    {
        [field: SerializeField] public ItemData m_Item { get; private set; }
        [field: SerializeField] public ItemData m_Replace { get; private set; }
    }
}
