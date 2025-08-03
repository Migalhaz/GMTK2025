using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ThrashCan : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Animator m_animator;

        bool m_hoover;


        private void Update()
        {
            bool hasRecipe = PlayerHandObserver.GetRecipeInHand() != null;
            bool playAnimation = m_hoover && hasRecipe;
            m_animator.SetBool("isOpened", playAnimation);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            PlayerHandObserver.RequestSetRecipeInHand(null);
        }

        public void OnPointerEnter(PointerEventData eventData) => m_hoover = true;
        public void OnPointerExit(PointerEventData eventData) => m_hoover = false;
    }
}
