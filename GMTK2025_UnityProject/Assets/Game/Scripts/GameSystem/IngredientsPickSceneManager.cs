using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class IngredientsPickSceneManager : MonoBehaviour
    {
        [SerializeField] TimeSystem m_sceneTimer;
        [SerializeField, Min(-1)] int m_cookSceneIndex = -1;
        [SerializeField] float m_timeToPlayAlarmSound = 5;
        [SerializeField] AudioSource m_alarmAudioSource;
        bool m_playedAlarmSound;

        private void OnEnable()
        {
            m_sceneTimer.m_OnTimeElapsed.AddListener(SwitchToCookScene);
        }

        private void OnDisable()
        {
            m_sceneTimer.m_OnTimeElapsed.RemoveListener(SwitchToCookScene);
        }

        private void Start()
        {
            StartPickupScene();
        }

        private void Update()
        {
            if (m_sceneTimer.m_CurrentTime > m_timeToPlayAlarmSound) return;
            if (m_playedAlarmSound) return;
            m_alarmAudioSource.Play();
            m_playedAlarmSound = true;
        }

        void StartPickupScene()
        {
            m_playedAlarmSound = false;
            Time.timeScale = 1;
            PlayerInventoryManager.Instance.ClearItems();
            RecipeTargetObserver.RequestRandomizeRecipe();
            m_sceneTimer.SetupTimer();
            m_sceneTimer.StartTimer();
        }

        void SwitchToCookScene()
        {
            if (m_cookSceneIndex == -1) return;
            SceneManager.LoadScene(m_cookSceneIndex);
        }
    }
}
