using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInventoryManager : MigalhaSystem.Singleton.Singleton<PlayerInventoryManager>
    {
        [SerializeField] List<ItemData> m_playerItem;
        public List<ItemData> m_PlayerItems => (m_playerItem ??= new List<ItemData>());

        public void ClearItems() => m_PlayerItems?.Clear();
        public void AddItem(ItemData newItem) => m_PlayerItems?.AddOnce(newItem);
    }
}
