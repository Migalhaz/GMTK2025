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

        private void Update()
        {
            InputListener();
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
