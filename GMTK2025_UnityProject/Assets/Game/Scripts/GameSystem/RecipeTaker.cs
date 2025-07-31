using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RecipeTaker : MonoBehaviour
    {
        public bool IsRecipeRight(RecipeData currentRecipe, AlienData alienData, Recipe receivedRecipe)
        {
            Recipe waitedRecipe = alienData.GetRecipe(currentRecipe);
            if (waitedRecipe.m_RecipeIngredients.Count != receivedRecipe.m_RecipeIngredients.Count) return false;

            foreach (var i in waitedRecipe.m_RecipeIngredients)
            {
                receivedRecipe.m_RecipeIngredients.Remove(i);
            }

            return receivedRecipe.m_RecipeIngredients.Count == 0;
        }
    }
}
