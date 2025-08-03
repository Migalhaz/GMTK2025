using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class MenuScript : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 1;
            PlayerInventoryManager.Instance.ResetSave();
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
