using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Player
{
    public class PlayerInventoryManager : MigalhaSystem.Singleton.Singleton<PlayerInventoryManager>
    {
        [SerializeField] List<ItemData> m_playerItem;
        [SerializeField, Min(1)] int m_maxItemCount = 16;
        public int m_MaxItemCount => m_maxItemCount;


        [SerializeField, Min(0)] int m_maxStrikeCount = 3;
        int m_strikeCount = 0;
        public int m_StrikeCount => m_strikeCount;

        public List<ItemData> m_PlayerItems => (m_playerItem ??= new List<ItemData>());
        [SerializeField, Min(-1)] int m_deathScreen;

        private void OnEnable()
        {
            AlienLogicObserver.OnAlienRejectRecipe += AddStrike;
            AlienLogicObserver.OnAlienPatienceElapsed += AddStrike;
        }

        private void OnDisable()
        {
            AlienLogicObserver.OnAlienRejectRecipe -= AddStrike;
            AlienLogicObserver.OnAlienPatienceElapsed -= AddStrike;
        }

        public void ResetSave()
        {
            m_strikeCount = 0;
            ClearItems();
        }

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

        public void AddStrike()
        {
            ++m_strikeCount;
            if (m_strikeCount < m_maxStrikeCount) return;

            if (m_deathScreen == -1) return;
            ResetSave();
            SceneManager.LoadScene(m_deathScreen);
        }
    }
}
