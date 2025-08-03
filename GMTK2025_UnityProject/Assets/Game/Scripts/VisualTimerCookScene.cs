using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class VisualTimerCookScene : MonoBehaviour
    {
        [SerializeField] Image m_foregroundImage;
        [SerializeField] TimeSystem m_sceneTimer;

        [SerializeField] List<Sprite> m_hours;

        private void Update()
        {
            if (m_sceneTimer == null || m_sceneTimer.m_StartTime == 0) return;
            float timeAmount = m_sceneTimer.m_CurrentTime / m_sceneTimer.m_StartTime;
            int index = m_hours.Count - Mathf.RoundToInt((m_hours.Count) * timeAmount);
            index = Mathf.Clamp(index, 0, m_hours.Count - 1);

            m_foregroundImage.sprite = m_hours[index];  
        }

    }
}
