using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] List<Canvas> m_allCanvas = new List<Canvas>();
        [SerializeField] Canvas m_pauseCanvas;
        [SerializeField] Canvas m_recipeCanvas;
        [SerializeField] bool m_showRecipeOnStart = false;
        private void Awake()
        {
            if (!m_allCanvas.Contains(m_pauseCanvas))
            {
                m_allCanvas.Add(m_pauseCanvas);
            }
            //DisableAllCanvas();
        }

        private void Start()
        {
            DisableAllCanvas();
            if (m_showRecipeOnStart)
            {
                EnableCanvas(m_recipeCanvas);
            }
        }

        private void Update()
        {
            InputListener();
        }

        void InputListener()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }
            if (m_pauseCanvas.gameObject.activeSelf)
            {
                Time.timeScale = 1.0f;
                DisableAllCanvas();
            }
            else
            {
                bool m_allDisable = true;
                foreach (Canvas cv in m_allCanvas)
                {
                    if (cv == m_pauseCanvas || !cv.gameObject.activeSelf)
                    {
                        continue;
                    }
                    m_allDisable = false;
                }

                if (m_allDisable)
                {
                    EnableCanvas(m_pauseCanvas);
                }
                else
                {
                    Time.timeScale = 1;
                    DisableAllCanvas();

                }
            }
        }

        public void SwitchCanvas(Canvas canvas)
        {
            if (!m_allCanvas.Contains(canvas)) return;
            if (canvas.gameObject.activeSelf)
            {
                DisableAllCanvas();
            }
            else
            {
                EnableCanvas(canvas);
            }
        }

        public void EnableCanvas(Canvas canvas)
        {
            if (!m_allCanvas.Contains(canvas)) return;
            foreach (Canvas c in m_allCanvas)
            {
                c.gameObject.SetActive(c == canvas);
            }
        }

        public void DisableAllCanvas()
        {
            foreach (Canvas c in m_allCanvas)
            {
                c.gameObject.SetActive(false);
            }
        }
    }
}
