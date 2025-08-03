using MigalhaSystem.Extensions;
using UnityEngine;
using UnityEngine.Events;


namespace Game
{
    public class TimeSystem : MonoBehaviour
    {
        [SerializeField] FloatRange m_timeToInvoke = new FloatRange(60, 60);

        public float m_StartTime { get; private set; }
        public float m_CurrentTime { get; private set; }

        public bool m_IsPlaying { get; private set; }
        [field:SerializeField] public UnityEvent m_OnTimeElapsed { get; private set; }
        [SerializeField] bool m_onAwake;

        private void Start()
        {
            if (m_onAwake)
            {
                SetupTimer();
                StartTimer();
            }
        }

        public void SetupTimer()
        {
            m_StartTime = m_timeToInvoke.GetRandomValue();
            m_CurrentTime = m_StartTime;
            m_IsPlaying = false;
        }

        public void StartTimer()
        {
            m_IsPlaying = true;
        }

        public void PauseTime()
        {
            m_IsPlaying = false;
        }

        private void Update()
        {
            Elapse();
        }

        void Elapse()
        {
            if (!m_IsPlaying) return;

            m_CurrentTime -= Time.deltaTime;
            if (m_CurrentTime <= 0)
            {
                FinishTimer();
            }
        }

        void BreakTime()
        {
            m_CurrentTime = 0;
            m_IsPlaying = false;
        }

        void InvokeEvent()
        {
            m_OnTimeElapsed?.Invoke();
        }

        public void FinishTimer()
        {
            BreakTime();
            InvokeEvent();
        }
    }
}
