using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class ClockVisual : MonoBehaviour
    {

        [SerializeField] Image m_clockImage;
        [SerializeField] TimeSystem m_timeSystem;

        private void Update()
        {
            m_clockImage.gameObject.SetActive(m_timeSystem.m_IsPlaying);
            if (m_timeSystem.m_StartTime == 0) return;
            m_clockImage.fillAmount = m_timeSystem.m_CurrentTime / m_timeSystem.m_StartTime;
        }
    }
}
