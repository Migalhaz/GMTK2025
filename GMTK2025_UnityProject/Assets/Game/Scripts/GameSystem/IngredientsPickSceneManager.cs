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

        void StartPickupScene()
        {
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
