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
        [SerializeField] RecipeTaker m_recipeTaker;
        [SerializeField] AlienVisual m_visual;

        [SerializeField, Min(0)] float m_minAlienPatienceTime;
        [SerializeField, Min(0)] float m_maxAlienPatienceTime;
        public float m_alienStartPatienceTime { get; private set; }
        public float m_alienPatienceTime { get; private set; }

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
            m_visual.UpdateFill(m_alienPatienceTime/m_alienStartPatienceTime);
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
            gameObject.SetActive(false);
        }

        public void RandomizeAlien()
        {
            if (target == null) return;
            if (target.m_CurrentAliensData == null || target.m_CurrentAliensData.Count <= 0) return;

            m_alienData = target.m_CurrentAliensData.GetRandom();

            m_alienStartPatienceTime = Random.Range(m_minAlienPatienceTime, m_maxAlienPatienceTime);
            m_alienPatienceTime = m_alienStartPatienceTime;
            m_visual.SetVisual(m_alienData);
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
