using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PanLogic : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] PlateLogic m_plate;
        [SerializeField] List<ItemData> m_itensInPan;
        [SerializeField, Min(0)] float m_timeToCook;
        float m_currentTime;
        [SerializeField] PamState m_currentState;
        [SerializeField, Min(-1)] int m_maxItemCount;

        private void Update()
        {
            CookTime();
        }

        void CookTime()
        {
            if (m_currentState != PamState.Cooking)
            {
                return;
            }

            m_currentTime -= Time.deltaTime;
            if (m_currentTime <= 0)
            {
                m_currentState = PamState.Done;
                m_currentTime = 0;
            }
        }

        public void AddItemInHand()
        {
            if (m_currentState != PamState.Empty) return;
            ItemData itemInHand = PlayerHandObserver.GetItemInHand();
            if (!itemInHand) return;
            if (m_maxItemCount == -1)
            {
                m_itensInPan.Add(itemInHand);
                return;
            }

            if (m_itensInPan.Count >= m_maxItemCount)
            {
                return;
            }
            m_itensInPan.Add(itemInHand);

        }

        public Recipe GetRecipeResult()
        {
            Recipe result = new Recipe();
            foreach (ItemData item in m_itensInPan)
            {
                result.m_RecipeIngredients.Add(item);
            }
            return result;
        }

        public void StartCook()
        {
            m_currentTime = m_timeToCook;
            m_currentState = PamState.Cooking;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (m_currentState == PamState.Empty)
            {
                AddItemInHand();
                return;
            }

            if (m_currentState == PamState.Done)
            {
                Recipe recipe = GetRecipeResult();
                if (m_plate.TrySetRecipe(recipe))
                {
                    m_itensInPan.Clear();
                    m_currentState = PamState.Empty;
                }
                return;
            }
        }
    }

    public enum PamState
    { 
        Empty = 0, Cooking = 1, Done = 2
    }

}
