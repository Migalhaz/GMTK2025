using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AlienBookController : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI m_alienNameText;
        [SerializeField] TMPro.TextMeshProUGUI m_alienDescriptionText;
        [SerializeField] List<RestrictionUICell> m_restrictionCell;

        [SerializeField] List<AlienData> m_allAliensData;
        int m_currentAlienIndex = 0;

        private void OnEnable()
        {
            UpdateVisual();
        }

        public void AddIndex(int increaser)
        {
            m_currentAlienIndex += increaser;
            while (m_currentAlienIndex < 0)
            {
                m_currentAlienIndex += m_allAliensData.Count;
            }
            m_currentAlienIndex %= m_allAliensData.Count;


            UpdateVisual();
        }

        void UpdateVisual()
        {
            AlienData currentAlien = m_allAliensData[m_currentAlienIndex];
            m_alienNameText.text = currentAlien.m_name;
            m_alienDescriptionText.text = currentAlien.m_description;

#if DEBUG
            if (currentAlien.m_Restrictions.Count > m_restrictionCell.Count)
            {
                Debug.LogWarning("TEM MAIS RESTRICAO DO QUE CELULAS NA LISTA!!!");
            }
#endif

            for (int i = 0; i < m_restrictionCell.Count; ++i)
            {
                Restriction currentRestriction = null;
                if (i < currentAlien.m_Restrictions.Count)
                {
                    currentRestriction = currentAlien.m_Restrictions[i];
                }
                m_restrictionCell[i].SetupRestrictionCell(currentRestriction);
            }
        }
    }

    [System.Serializable]
    public class RestrictionUICell
    {
        [SerializeField] GameObject m_rootObject;
        [SerializeField] TMPro.TextMeshProUGUI m_notAllowText;
        [SerializeField] TMPro.TextMeshProUGUI m_allowText;

        public void SetupRestrictionCell(Restriction restriction)
        {
            if (restriction == null)
            {
                m_rootObject.SetActive(false);
                return;
            }

            m_rootObject.SetActive(true);
            m_notAllowText.text = restriction.m_Item.m_name;
            m_allowText.text = restriction.m_Replace.m_name;
        }
    }
}
