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
        [SerializeField] Color m_startColor = Color.red;
        [SerializeField] Color m_endColor = Color.green;

        private void Update()
        {
            m_clockImage.gameObject.SetActive(m_timeSystem.m_IsPlaying);
            if (m_timeSystem.m_StartTime == 0) return;

            float percentageAmount = m_timeSystem.m_CurrentTime / m_timeSystem.m_StartTime;
            m_clockImage.fillAmount = percentageAmount;
            m_clockImage.color = Color.Lerp(m_startColor, m_endColor, percentageAmount);
        }
    }
}
