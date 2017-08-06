using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine;
using Leo.HoloToolkitExtensions;

namespace Leo.HoloToolkitExtensions
{
    public class TapToSelect : MonoBehaviour, IInputClickHandler
    {
        [SerializeField]
        private GameObject arCamera;

        [SerializeField]
        GameObject outSideParent;
        [SerializeField]
        GameObject inSideParent;
        [SerializeField]
        GameObject cursor;

        public Material other_material;
        private Material org_material;
        private bool isShow_material;

        private void Start()
        {
            MeshRenderer my_renderer = transform.GetComponent<MeshRenderer>();
            if (my_renderer != null)
            {
                org_material = my_renderer.material;
                isShow_material = true;
            }
        }
        public void OnInputClicked(InputClickedEventData eventData)
        {

            clickEvent();

        }

         public void clickEvent()
        {
            //transform.GetComponent<MeshRenderer>().enabled = false;
            MeshRenderer my_renderer = transform.GetComponent<MeshRenderer>();
            if (isShow_material)
            {
                if (my_renderer != null)
                {
                    my_renderer.material = other_material;
                }
                transform.parent = outSideParent.transform;
                //arCamera.SetActive(false);
                cursor.SetActive(false);
            }
            else
            {
                if (my_renderer != null)
                {
                    my_renderer.material = org_material;
                }
                transform.parent = inSideParent.transform;
                //arCamera.SetActive(true);
                cursor.SetActive(true);
            }
            isShow_material = !isShow_material;
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
