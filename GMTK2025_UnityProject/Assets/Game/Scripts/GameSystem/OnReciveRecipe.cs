using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class OnReciveRecipe : MonoBehaviour
    {
        [SerializeField] UnityEvent<RecipeTarget> m_onReciveRecipe;

        private void OnEnable()
        {
            RecipeTargetObserver.OnRandomizeRecipe += Invoke;
        }

        private void OnDisable()
        {
            RecipeTargetObserver.OnRandomizeRecipe -= Invoke;
        }

        void Invoke(RecipeTarget target)
        {
            m_onReciveRecipe?.Invoke(target);
        }
    }
}
