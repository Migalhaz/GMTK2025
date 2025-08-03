using MigalhaSystem.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource m_musicBackground;
        [SerializeField] AudioClip m_clickSound;

        public void PlayClickSound()
        {
            Camera cam = Camera.main;
            AudioSource.PlayClipAtPoint(m_clickSound, cam.transform.position);
        }
    }
}
