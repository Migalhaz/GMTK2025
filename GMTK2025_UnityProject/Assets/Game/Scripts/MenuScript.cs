using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MenuScript : MonoBehaviour
    {
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
