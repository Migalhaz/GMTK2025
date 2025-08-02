using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] Recipe m_recipeInHand;
        [SerializeField] ItemData m_ItemInHand;

        private void OnEnable()
        {
            PlayerHandObserver.OnRequestSetRecipeInHand += SetRecipe;
            PlayerHandObserver.OnRequestSetItemInHand += SetItem;

            PlayerHandObserver.OnGetItemInHand += GetItem;
            PlayerHandObserver.OnGetRecipeInHand += GetRecipe;
        }

        private void OnDisable()
        {
            PlayerHandObserver.OnRequestSetRecipeInHand -= SetRecipe;
            PlayerHandObserver.OnRequestSetItemInHand -= SetItem;

            PlayerHandObserver.OnGetItemInHand -= GetItem;
            PlayerHandObserver.OnGetRecipeInHand -= GetRecipe;
        }

        public void SetRecipe(Recipe recipeData) => m_recipeInHand = recipeData;
        public void SetItem(ItemData itemData) => m_ItemInHand = itemData;

        public Recipe GetRecipe() => m_recipeInHand;
        public ItemData GetItem() => m_ItemInHand;
    }

    public static class PlayerHandObserver
    {
        public static event System.Action<Recipe> OnRequestSetRecipeInHand = null;
        public static event System.Action<ItemData> OnRequestSetItemInHand = null;

        public static event System.Func<Recipe> OnGetRecipeInHand = null;
        public static event System.Func<ItemData> OnGetItemInHand = null;

        public static void RequestSetRecipeInHand(Recipe newRecipe) => OnRequestSetRecipeInHand?.Invoke(newRecipe);
        public static void RequestSetItemInHand(ItemData newItem) => OnRequestSetItemInHand?.Invoke(newItem);

        public static Recipe GetRecipeInHand() => OnGetRecipeInHand?.Invoke();
        public static ItemData GetItemInHand() => OnGetItemInHand?.Invoke();
    }
}
