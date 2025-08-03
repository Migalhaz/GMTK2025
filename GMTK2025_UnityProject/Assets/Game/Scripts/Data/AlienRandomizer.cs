using MigalhaSystem.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Game
{
    public class AlienRandomizer : MonoBehaviour
    {
        [SerializeField] List<AlienData> m_data;

        [Header("Restrictions")]
        [SerializeField] List<ItemData> m_allItemData;
        [SerializeField] int m_minRestrictionCount;
        [SerializeField] int m_maxRestrictionCount;

        [Header("Visuals")]
        [SerializeField] List<Color> m_colorList;
        [SerializeField] List<Sprite> m_headSprites;
        [SerializeField] List<Sprite> m_bodySprites;
        [SerializeField] List<Sprite> m_eyeSprites;
        [SerializeField] List<Sprite> m_mouthSprites;
        [SerializeField] List<Sprite> m_headAddonSprites;


        [ContextMenu("Randomize")]
        public void Randomize()
        {
            foreach (AlienData a in m_data)
            {
                RandomizeAlien(a);
            }
        }

        void RandomizeAlien(AlienData alien)
        {
            RandomizeRestrictions(alien);
            RandomizeVisual(alien);
        }

        void RandomizeRestrictions(AlienData alien)
        {
            alien.m_Restrictions.Clear();

            List<ItemData> data = new List<ItemData>(m_allItemData);
            int restrictionCount = Random.Range(m_minRestrictionCount, m_maxRestrictionCount + 1);
            for (int i = 0; i < restrictionCount; ++i)
            {
                if (data.Count < 2) break;

                Restriction restriction = new Restriction();
                restriction.m_Item = data.GetRandom();
                data.Remove(restriction.m_Item);

                restriction.m_Replace = data.GetRandom();
                data.Remove(restriction.m_Replace);
                alien.m_Restrictions.Add(restriction);
            }
        }

        void RandomizeVisual(AlienData alien)
        {
            alien.m_BodySprite = m_bodySprites.GetRandom();
            alien.m_HeadSprite = m_headSprites.GetRandom();
            alien.m_MouthSprite = m_mouthSprites.GetRandom();
            alien.m_EyeSprite = m_eyeSprites.GetRandom();
            alien.m_HeadAddonSprite = m_headAddonSprites.GetRandom();
            alien.m_SkinColor = m_colorList.GetRandom();
        }
    }
}
