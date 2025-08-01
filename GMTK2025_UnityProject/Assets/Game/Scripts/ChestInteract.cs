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
        public bool CanInteract() => true;

        public void OnInteract()
        {
            m_canvasController.SwitchCanvas(m_chestCanvas);
        }
    }
}
