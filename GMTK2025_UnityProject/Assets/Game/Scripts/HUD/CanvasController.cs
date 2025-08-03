using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] List<Canvas> m_allCanvas = new List<Canvas>();
        [SerializeField] Canvas m_pauseCanvas;
        private void Awake()
        {
            if (!m_allCanvas.Contains(m_pauseCanvas))
            {
                m_allCanvas.Add(m_pauseCanvas);
            }
            DisableAllCanvas();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                SwitchCanvas(m_pauseCanvas);
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
