using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class PauseController : MonoBehaviour
    {
        [SerializeField] Canvas m_rootCanvas;
        [SerializeField] CanvasController m_controller;
        [SerializeField] Button m_resumeButton;
        [SerializeField] Button m_mainMenuButton;
        [SerializeField] Button m_quitButton;
        [SerializeField] int m_mainMenuIndex;

        private void OnEnable()
        {
            Time.timeScale = 0;
            m_resumeButton.onClick.AddListener(Resume);
            m_mainMenuButton.onClick.AddListener(MainMenu);
            m_quitButton.onClick.AddListener(Quit);
        }

        private void OnDisable()
        {
            m_resumeButton.onClick.RemoveListener(Resume);
            m_mainMenuButton.onClick.RemoveListener(MainMenu);
            m_quitButton.onClick.RemoveListener(Quit);
        }

        private void Awake()
        {
            m_rootCanvas ??= GetComponent<Canvas>();
            m_rootCanvas.gameObject.SetActive(false);
        }

        void Resume()
        {
            Time.timeScale = 1;
            m_controller.SwitchCanvas(m_rootCanvas);
        }

        void MainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(m_mainMenuIndex);
        }

        void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
