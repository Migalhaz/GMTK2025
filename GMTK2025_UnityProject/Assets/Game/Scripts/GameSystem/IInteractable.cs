using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IInteractable
    {
        bool CanInteract();
        void OnInteract();
    }
}
