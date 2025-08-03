using Game.Player;
using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ChestInteract : MonoBehaviour, IInteractable
    {
        [SerializeField] Canvas m_chestCanvas;
        [SerializeField] CanvasController m_canvasController;
        [SerializeField] AudioSource m_audio;

        private void Awake()
        {
            m_audio ??= GetComponent<AudioSource>();
        }

        public bool CanInteract() => true;

        public void OnInteract()
        {
            if (m_audio.clip != null)
            {
                m_audio.Play();
            }
            m_canvasController.SwitchCanvas(m_chestCanvas);
        }
    }
}
