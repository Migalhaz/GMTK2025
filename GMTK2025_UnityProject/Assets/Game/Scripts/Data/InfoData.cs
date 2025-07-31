using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class InfoData : ScriptableObject
    {
        [field: SerializeField] public string m_name { get; private set; }
        [field: SerializeField, TextArea(3, 10)] public string m_description { get; private set; }
    }
}
