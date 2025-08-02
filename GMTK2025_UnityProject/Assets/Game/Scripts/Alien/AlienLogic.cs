using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class AlienLogic : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] AlienData m_alienData;
        [SerializeField] UnityEngine.UI.Image m_headImage;
        [SerializeField] UnityEngine.UI.Image m_bodyImage;
        [SerializeField] RecipeTaker m_recipeTaker;

        [SerializeField, Min(0)] float m_minAlienPatienceTime;
        [SerializeField, Min(0)] float m_maxAlienPatienceTime;
        float m_alienPatienceTime;

        RecipeTarget target => RecipeTarget.Instance;
        private void OnEnable()
        {
            RandomizeAlien();
        }

        private void Update()
        {
            PatienceLogic();
        }

        void PatienceLogic()
        {
            m_alienPatienceTime -= Time.deltaTime;
            if (m_alienPatienceTime <= 0)
            {
                AlienLogicObserver.AlienPatienceElapsed();
                gameObject.SetActive(false);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Recipe recipe = PlayerHandObserver.GetRecipeInHand();
            if (recipe == null || recipe.m_RecipeIngredients.Count <= 0)
            {
                return;
            }

            PlayerHandObserver.RequestSetRecipeInHand(null);
            RecipeData targetRecipe = target.m_CurrentRecipe;
            bool taken = m_recipeTaker.IsRecipeRight(targetRecipe, m_alienData, recipe);

            if (taken)
            {
                Debug.Log("RECIPE ACCEPTED");
                AlienLogicObserver.AcceptRecipe();
            }
            else
            {
                Debug.Log("RECIPE REJECTED");
                AlienLogicObserver.RejectRecipe();
            }

        }

        public void RandomizeAlien()
        {
            if (target == null) return;
            if (target.m_CurrentAliensData == null || target.m_CurrentAliensData.Count <= 0) return;

            m_alienData = target.m_CurrentAliensData.GetRandom();

            m_alienPatienceTime = Random.Range(m_minAlienPatienceTime, m_maxAlienPatienceTime);
            UpdateVisual();
        }

        void UpdateVisual()
        {
            m_headImage.sprite = m_alienData.m_HeadSprite;
            m_bodyImage.sprite = m_alienData.m_BodySprite;

            m_headImage.color = m_alienData.m_SkinColor;
            m_bodyImage.color = m_alienData.m_SkinColor;
        }
    }

    public static class AlienLogicObserver
    {
        public static event System.Action OnAlienAcceptRecipe = null;
        public static event System.Action OnAlienRejectRecipe = null;
        public static event System.Action OnAlienPatienceElapsed = null;

        public static void AcceptRecipe() => OnAlienAcceptRecipe?.Invoke();
        public static void RejectRecipe() => OnAlienRejectRecipe?.Invoke();
        public static void AlienPatienceElapsed() => OnAlienPatienceElapsed?.Invoke();
    }
}
