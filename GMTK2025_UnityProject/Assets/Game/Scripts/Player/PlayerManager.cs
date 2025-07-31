using MigalhaSystem.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        [field: SerializeField] public PlayerMove m_PlayerMove { get; private set; }
        [field: SerializeField] public PlayerInteract m_PlayerInteract { get; private set; }
    }
}
