using MigalhaSystem.Extensions;
using UnityEngine;
using UnityEngine.Events;


namespace Game
{
    public class TimeSystem : MonoBehaviour
    {
        [SerializeField] FloatRange m_timeToInvoke = new FloatRange(60, 60);
        float m_currentTime;
        bool m_isPlaying;
        [field:SerializeField] public UnityEvent m_OnTimeElapsed { get; private set; }

        public void SetupTimer()
        {
            m_currentTime = m_timeToInvoke.GetRandomValue();
            m_isPlaying = false;
        }

        public void StartTimer()
        {
            m_isPlaying = true;
        }

        public void PauseTime()
        {
            m_isPlaying = false;
        }

        private void Update()
        {
            Elapse();
        }

        void Elapse()
        {
            if (!m_isPlaying) return;

            m_currentTime -= Time.deltaTime;
            if (m_currentTime <= 0)
            {
                FinishTimer();
            }
        }

        void BreakTime()
        {
            m_currentTime = 0;
            m_isPlaying = false;
        }

        void InvokeEvent()
        {
            m_OnTimeElapsed?.Invoke();
        }

        void FinishTimer()
        {
            BreakTime();
            InvokeEvent();
        }
    }
}
