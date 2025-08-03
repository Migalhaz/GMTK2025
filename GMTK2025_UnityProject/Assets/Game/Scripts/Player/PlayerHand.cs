using UnityEngine;

namespace Game
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] Recipe m_recipeInHand;
        [SerializeField] ItemData m_ItemInHand;
        [SerializeField] Texture2D m_cursor;
        Vector2 m_midVector;
        private void OnEnable()
        {
            m_midVector = new Vector2(0.5f, 0.5f);
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

            Cursor.SetCursor(null, m_midVector, CursorMode.Auto);
        }

        private void Awake()
        {
            m_recipeInHand = null;
            m_ItemInHand = null;
        }

        private void Update()
        {
            if (m_recipeInHand != null)
            {
                Cursor.SetCursor(m_cursor, m_midVector, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, m_midVector, CursorMode.Auto);
            }
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
