using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InventoryCellVisual : MonoBehaviour
    {
        [SerializeField, Min(0)] protected int m_cellIndex;
        [SerializeField] UnityEngine.UI.Image m_foregroundItemImage;
        protected PlayerInventoryManager m_inventoryManager => PlayerInventoryManager.Instance;
        protected AudioManager m_audioManager => AudioManager.Instance;

        protected virtual void OnEnable()
        {
            UpdateVisual();
        }
        private void Update()
        {
            UpdateVisual();
        }

        void UpdateVisual()
        {
            if (m_inventoryManager == null) return;

            if (m_cellIndex >= m_inventoryManager.m_MaxItemCount)
            {
                gameObject.SetActive(false);
                return;
            }

            if (m_cellIndex >= m_inventoryManager.m_PlayerItems.Count)
            {
                m_foregroundItemImage.enabled = false;
                m_foregroundItemImage.sprite = null;
            }
            else
            {
                m_foregroundItemImage.enabled = true;
                m_foregroundItemImage.sprite = m_inventoryManager.m_PlayerItems[m_cellIndex].m_ItemSprite;
            }
        }
    }
}
