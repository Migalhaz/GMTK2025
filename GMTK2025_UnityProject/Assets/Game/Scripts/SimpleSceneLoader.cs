using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class SimpleSceneLoader : MonoBehaviour
    {
        [SerializeField, Min(-1)] int m_sceneIndex = -1;

        public void LoadScene()
        {
            if (m_sceneIndex == -1) return;
            SceneManager.LoadScene(m_sceneIndex);
        }
    }
}
