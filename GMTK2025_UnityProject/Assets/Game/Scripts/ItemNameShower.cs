using MigalhaSystem.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class ItemNameShower : Singleton<ItemNameShower>
    {
        [SerializeField] GameObject m_root;
        [SerializeField] TextMeshProUGUI m_itemNameText;
        [SerializeField] Vector3 m_offset;
        
        public void ShowItemName(string itemName, Vector3 position)
        {
            m_itemNameText.text = itemName;
            m_root.transform.position = position+ m_offset;
        }

        public void EnableRoot(bool enabled)
        {
            m_root.SetActive(enabled);
        }
    }
}
