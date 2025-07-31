using MigalhaSystem.Extensions;
using MigalhaSystem.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RecipeTarget : Singleton<RecipeTarget>
    {
        [Header("Recipes")]
        [SerializeField] List<RecipeData> m_allRecipesData;

        RecipeData m_currentRecipe;
        public RecipeData m_CurrentRecipe => m_currentRecipe;


        [Header("Aliens")]
        [SerializeField] List<AlienData> m_allAliensData;
        [SerializeField] IntRange m_alienCountRange;
        
        List<AlienData> m_currentAliensData = new List<AlienData>();
        public List<AlienData> m_CurrentAliensData => m_currentAliensData;

        private void OnEnable()
        {
            RecipeTargetObserver.OnRequestRandomizeRecipe += Randomize;
        }

        private void OnDisable()
        {
            RecipeTargetObserver.OnRequestRandomizeRecipe -= Randomize;
        }

        protected override void Awake()
        {
            base.Awake();
            ResetTarget();
        }

        private void Update()
        {
#if DEBUG
            if (Input.GetKey(KeyCode.R)) Randomize();
#endif
        }

        [ContextMenu("Randomize")]
        public void Randomize()
        {
            m_currentRecipe = m_allRecipesData.GetRandom();

            (m_currentAliensData ?? new())?.Clear();

            List<AlienData> availableAliens = new List<AlienData>(m_allAliensData);

            m_alienCountRange.minValue = Mathf.Clamp(m_alienCountRange.minValue, 1, availableAliens.Count);
            m_alienCountRange.maxValue = Mathf.Clamp(m_alienCountRange.maxValue, 1, availableAliens.Count);

            int alienCount = m_alienCountRange.GetRandomValue(false);

            for (int i = 0; i < alienCount; ++i)
            {
                AlienData alien = availableAliens.GetRandom();
                availableAliens.Remove(alien);
                m_currentAliensData.AddOnce(alien);
            }

            RecipeTargetObserver.RandomizeRecipe(this);
        }

        public void ResetTarget()
        {
            m_currentRecipe = null;
            (m_currentAliensData ?? new())?.Clear();
        }
    }

    public static class RecipeTargetObserver
    {
        public static event System.Action<RecipeTarget> OnRandomizeRecipe = null;
        public static event System.Action OnRequestRandomizeRecipe = null;

        public static void RandomizeRecipe(RecipeTarget target) => OnRandomizeRecipe?.Invoke(target);
        public static void RequestRandomizeRecipe() => OnRequestRandomizeRecipe?.Invoke();
    }
}
