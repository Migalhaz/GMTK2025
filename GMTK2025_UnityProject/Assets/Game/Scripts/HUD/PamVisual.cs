using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class PamVisual : MonoBehaviour, IPointerMoveHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] PanLogic m_panLogic;
        [SerializeField] UnityEngine.UI.Image m_pamImage;
        [SerializeField] Sprite m_closedPan;
        [SerializeField] Sprite m_openedPan;
        [SerializeField] UnityEngine.UI.Image m_doneIndicator;
        [SerializeField] Color m_emptyIndicatorColor = Color.red;
        [SerializeField] Color m_fullIndicatorColor = Color.green;

        [SerializeField] GameObject m_textBackground;
        [SerializeField] TMPro.TextMeshProUGUI m_ingredientsText;

        [SerializeField] float m_animationDuration = .3f;
        [SerializeField] Vector3 m_endScale = new Vector3(1.1f, 1.1f, 1.1f);
        Tween m_currentTween;


        bool m_showIngredients;

        public void OnPointerEnter(PointerEventData eventData) => OnPointerMove(eventData);

        public void OnPointerExit(PointerEventData eventData) 
        {
            m_showIngredients = false;
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            m_showIngredients = true;
        }

        void ShowIngredients()
        {
            if (m_panLogic.m_ItensInPan == null || m_panLogic.m_ItensInPan.Count <= 0 || !m_showIngredients)
            {
                m_textBackground.SetActive(false);
                m_ingredientsText.text = string.Empty;
                return;
            }
            m_showIngredients = true;
            m_textBackground.SetActive(true);
            m_ingredientsText.text = string.Empty;
            foreach (ItemData item in m_panLogic.m_ItensInPan)
            {
                m_ingredientsText.text += $". {item.m_name}\n";
            }
        }

        

        private void Update()
        {
            ShowIngredients();
            UpdateVisual();

            if (m_panLogic.m_CurrentPamState != PamState.Done)
            {
                m_currentTween?.Kill();
                m_currentTween = null;
                transform.localScale = Vector3.one;
            }
            else
            {
                m_currentTween ??= transform.DOScale(m_endScale, m_animationDuration).SetLoops(-1, LoopType.Yoyo);
            }
        }

        void UpdateVisual()
        {
            Sprite currentSprite = m_panLogic.m_CurrentPamState == PamState.Empty ? m_openedPan : m_closedPan;
            m_pamImage.sprite = currentSprite;

            m_doneIndicator.transform.parent.gameObject.SetActive(m_panLogic.m_CurrentPamState != PamState.Empty);

            m_doneIndicator.enabled = m_panLogic.m_CurrentPamState != PamState.Empty;

            float doneIndicatorAmount = 1 - (m_panLogic.m_CurrentTimeCooking / m_panLogic.m_MaxTimeToCook);

            m_doneIndicator.fillAmount = doneIndicatorAmount;
            m_doneIndicator.color = Color.Lerp(m_emptyIndicatorColor, m_fullIndicatorColor, doneIndicatorAmount);
        }
    }
}
