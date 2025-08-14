using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace Game
{
    public class PanButton : MonoBehaviour
    {
        [SerializeField] PanLogic m_panLogic;
        [SerializeField] float m_animationDuration;
        [SerializeField] Vector3 m_finalScale = new Vector3(1.1f, 1.1f, 1.1f);
        Vector3 m_startScale = Vector3.one;
        Tween m_currentTween;

        private void Update()
        {
            if (m_panLogic.m_ItensInPan == null || m_panLogic.m_ItensInPan.Count <= 0 || m_panLogic.m_CurrentPamState != PamState.Empty)
            {
                m_currentTween?.Kill();
                m_currentTween = null;
                transform.localScale = m_startScale;
                return;
            }

            m_currentTween ??= transform.DOScale(m_finalScale, m_animationDuration).SetLoops(-1, LoopType.Yoyo);   
        }
    }
}
