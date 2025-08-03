using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class DebugAlien : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI nome;
        public TMPro.TextMeshProUGUI desc;
        public Image corpo;
        public Image cabeca;
        public Image olhos;
        public Image boca;
        public Image chifre;

        public List<AlienData> allaliendata;
        int index;


        private void Awake()
        {
            index = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                index++;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                index--;
            }

            if (index >= allaliendata.Count)
            {
                index = 0;
            }
            if (index < 0)
            {
                index = allaliendata.Count - 1;
            }

            AlienData a = allaliendata[index];

            nome.text = a.m_name;
            desc.text = a.m_description;

            cabeca.sprite = a.m_HeadSprite;
            cabeca.color = a.m_SkinColor;
            
            corpo.sprite = a.m_BodySprite;
            corpo.color = a.m_SkinColor;

            boca.sprite = a.m_MouthSprite;
            olhos.sprite = a.m_EyeSprite;
            chifre.sprite = a.m_HeadAddonSprite;
            chifre.color = a.m_SkinColor;


        }
    }
}
