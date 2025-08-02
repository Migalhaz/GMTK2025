using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RecipeBookController : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI m_recipeTitle;
        [SerializeField] UnityEngine.UI.Image m_recipeImage;
        [SerializeField] TMPro.TextMeshProUGUI m_ingredientsText;
        [SerializeField] string m_ingredientsBaseText = "INGREDIENTS:\n";

        [SerializeField] List<RecipeData> m_allRecipes;

        int m_currentRecipeIndex = 0;

        private void OnEnable()
        {
            UpdateVisual();
        }

        public void AddIndex(int increaser)
        {
            m_currentRecipeIndex += increaser;
            while (m_currentRecipeIndex < 0)
            {
                m_currentRecipeIndex += m_allRecipes.Count;
            }
            m_currentRecipeIndex %= m_allRecipes.Count;

            
            UpdateVisual();
        }

        void UpdateVisual()
        {
            RecipeData currentRecipe = m_allRecipes[m_currentRecipeIndex];
            
            List<ItemData> currentIngredients = currentRecipe.m_Recipe.m_RecipeIngredients;
            
            m_recipeTitle.text = currentRecipe.m_name;
            m_recipeImage.sprite = currentRecipe.m_RecipeImage;
            m_ingredientsText.text = m_ingredientsBaseText;
            foreach (ItemData ingredient in currentIngredients)
            {
                m_ingredientsText.text += ingredient.m_name + '\n';
            }
        }
    }
}
