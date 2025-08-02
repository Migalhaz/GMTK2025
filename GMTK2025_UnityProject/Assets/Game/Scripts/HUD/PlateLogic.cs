using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PlateLogic : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] Recipe m_currentRecipe;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (m_currentRecipe == null || m_currentRecipe.m_RecipeIngredients.Count <= 0)
            {
                return;
            }

            Recipe recipeInHand = PlayerHandObserver.GetRecipeInHand();
            if (recipeInHand != null && recipeInHand.m_RecipeIngredients.Count > 0)
            {
                return;
            }

            PlayerHandObserver.RequestSetRecipeInHand(m_currentRecipe);
            m_currentRecipe = null;
        }

        public bool TrySetRecipe(Recipe recipe)
        {
            if (m_currentRecipe != null)
            {
                if (m_currentRecipe.m_RecipeIngredients.Count > 0)
                {
                    return false;
                }
            }
            m_currentRecipe = recipe;
            return true;
        }
    }
}
