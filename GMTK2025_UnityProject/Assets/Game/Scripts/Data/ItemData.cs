using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Item")]
    public class ItemData : InfoData
    {
        [field:SerializeField] public int m_Id { get; private set; }
        [field: SerializeField] public Sprite m_ItemSprite { get; private set; }
    }
}
