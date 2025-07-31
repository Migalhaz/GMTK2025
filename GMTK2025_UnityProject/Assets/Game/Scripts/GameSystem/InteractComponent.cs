using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class InteractComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] UnityEvent m_onInteract;

        public bool CanInteract() => true;

        public void OnInteract()
        {
            m_onInteract?.Invoke();
        }
    }
}
