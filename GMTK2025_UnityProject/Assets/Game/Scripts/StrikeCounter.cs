using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StrikeCounter : MonoBehaviour
    {
        [SerializeField] List<GameObject> m_strikeCount;
        void Update()
        {
            UpdateStrikeCount();
        }

        void UpdateStrikeCount()
        {
            int strikeCount = PlayerInventoryManager.Instance?.m_StrikeCount ?? 0;
            for (int i = m_strikeCount.Count - 1; i >= 0; --i)
            {
                m_strikeCount[i].SetActive(i < strikeCount);
            }
        }
    }
}
