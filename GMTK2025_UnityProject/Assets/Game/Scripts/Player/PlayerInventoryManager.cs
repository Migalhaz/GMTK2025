using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInventoryManager : MigalhaSystem.Singleton.Singleton<PlayerInventoryManager>
    {
        [SerializeField] List<ItemData> m_playerItem;
        [SerializeField, Min(1)] int m_maxItemCount = 16;
        public int m_MaxItemCount => m_maxItemCount;

        public List<ItemData> m_PlayerItems => (m_playerItem ??= new List<ItemData>());

        public void ClearItems() => m_PlayerItems?.Clear();
        public void AddItem(ItemData newItem)
        {
            if (m_playerItem.Count >= m_maxItemCount) return;

            if (m_playerItem.Contains(newItem))
            {
                return;
            }
            m_playerItem.Add(newItem);  
        }
    }
}
