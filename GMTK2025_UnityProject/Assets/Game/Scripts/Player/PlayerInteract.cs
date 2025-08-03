using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [SerializeField, Min(0)] float m_interactAreaRadius = 1;
        [SerializeField] LayerMask m_interactLayer;
        Collider2D m_collider;
        [SerializeField] Canvas m_canvas;

        private void Update()
        {
            InputListener();
            UpdateVisual();
        }

        private void FixedUpdate()
        {
            m_collider = Physics2D.OverlapCircle(transform.position, m_interactAreaRadius, m_interactLayer);
        }

        void InputListener()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryInteract();
            }
        }

        void UpdateVisual()
        {
            if (m_collider != null)
            {
                m_canvas.gameObject.SetActive(true);
                m_canvas.transform.position = m_collider.transform.position;
            }
            else
            {
                m_canvas.gameObject.SetActive(false);
            }

        }

        void TryInteract()
        {
            if (!m_collider) return;
            IInteractable interactableObject = null;
            if (!m_collider.TryGetComponent(out interactableObject)) return;
            if (interactableObject == null) return;
            bool canInteract = interactableObject?.CanInteract() ?? false;
            if (!canInteract) return;
            interactableObject.OnInteract();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, m_interactAreaRadius);
        }
    }
}
