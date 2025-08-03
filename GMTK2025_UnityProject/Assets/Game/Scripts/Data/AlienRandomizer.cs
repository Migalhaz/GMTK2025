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
        [SerializeField] List<ColorByLabel> m_colorList;
        [SerializeField] List<SpriteByLabel> m_headSprites;
        [SerializeField] List<SpriteByLabel> m_bodySprites;
        [SerializeField] List<SpriteByLabel> m_eyeSprites;
        [SerializeField] List<SpriteByLabel> m_mouthSprites;
        [SerializeField] List<SpriteByLabel> m_headAddonSprites;


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
            //RandomizeRestrictions(alien);
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
            SpriteByLabel body = m_bodySprites.GetRandom();
            alien.m_BodySprite = body.sprite;
            alien.m_description += $"{body.label}, ";
            
            SpriteByLabel head = m_headSprites.GetRandom();
            alien.m_HeadSprite = head.sprite;
            alien.m_description += $"{head.label}, ";

            SpriteByLabel mouth = m_mouthSprites.GetRandom();
            alien.m_MouthSprite = mouth.sprite;
            alien.m_description += $"{mouth.label}, ";

            SpriteByLabel eyes = m_eyeSprites.GetRandom();
            alien.m_EyeSprite = eyes.sprite;
            alien.m_description += $"{eyes.label}, ";

            SpriteByLabel headAddon = m_headAddonSprites.GetRandom();
            alien.m_HeadAddonSprite = headAddon.sprite;
            if (headAddon.sprite != null)
            {
                alien.m_description += $"{headAddon.label}, ";
            }

            ColorByLabel color = m_colorList.GetRandom();

            alien.m_SkinColor = color.color;
            alien.m_description += $"{color.label} skin color.";
        }

    }

    [System.Serializable]
    public class SpriteByLabel
    {
        public Sprite sprite;
        public string label;
    }

    [System.Serializable]
    public class ColorByLabel
    {
        public Color color;
        public string label;
    }
}
