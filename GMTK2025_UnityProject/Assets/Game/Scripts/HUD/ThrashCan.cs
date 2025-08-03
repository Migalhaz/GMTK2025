using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ThrashCan : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Animator m_animator;
        [SerializeField] AudioSource m_audioSource;
        bool m_hoover;
        bool m_hasRecipe => PlayerHandObserver.GetRecipeInHand() != null;

        private void Awake()
        {
            m_animator ??= GetComponent<Animator>();
            m_audioSource ??= GetComponent<AudioSource>();
        }

        private void Update()
        {
            bool playAnimation = m_hoover && m_hasRecipe;
            m_animator.SetBool("isOpened", playAnimation);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!m_hasRecipe) return;
            m_audioSource.Play();
            PlayerHandObserver.RequestSetRecipeInHand(null);
        }

        public void OnPointerEnter(PointerEventData eventData) => m_hoover = true;
        public void OnPointerExit(PointerEventData eventData) => m_hoover = false;
    }
}
