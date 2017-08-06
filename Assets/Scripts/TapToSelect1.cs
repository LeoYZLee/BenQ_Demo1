using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine;
using Leo.HoloToolkitExtensions;
using System.Collections.Generic;

namespace Leo.HoloToolkitExtensions
{
    public class TapToSelect1 : MonoBehaviour, IInputClickHandler
    {
         [SerializeField]
        GameObject cursor;
        [SerializeField]
        private List<GameObject> hideObjects;

        bool isShow = true;


        public void OnInputClicked(InputClickedEventData eventData)
         {
            clickEvent();
        }

        public void clickEvent()
        {
            if (isShow)
            {
                foreach (GameObject item in hideObjects)
                {
                    item.transform.GetComponent<MeshRenderer>().gameObject.SetActive(false);
                }
                cursor.SetActive(false);
            }
            else
            {
                foreach (GameObject item in hideObjects)
                {
                    item.transform.GetComponent<MeshRenderer>().gameObject.SetActive(true);
                }
                cursor.SetActive(true);
            }
            isShow = !isShow;
        }

        private AudioSource GetAudioSource(GameObject obj)
        {
            var audioSource = gameObject.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.GetComponentInParent<AudioSource>();
            }
            return audioSource;
        }

   
     


    }
}
