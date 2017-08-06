/*============================================================================== 
 Copyright (c) 2016 PTC Inc. All Rights Reserved.
 
 Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections.Generic;
using Vuforia;
using System;

/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to swap materials for the teapot model depending on what 
/// virtual button has been pressed.
/// </summary>
namespace Leo.HoloToolkitExtensions
{

    public class VirtualButtonEventHandler : MonoBehaviour,
                                             IVirtualButtonEventHandler
    {
        [SerializeField]
        private GameObject mode1_Obj;
        [SerializeField]
        private GameObject mode2_Obj;


        #region MONOBEHAVIOUR_METHODS
        void Start()
        {
            /*
            // Register with the virtual buttons TrackableBehaviour
            VirtualButtonBehaviour vb =
                                GetComponentInChildren<VirtualButtonBehaviour>();
            if (vb)
            {
                vb.RegisterEventHandler(this);
            }
            */
            GameObject virtualButtonObject = GameObject.Find("VirtualButton1");
            virtualButtonObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

            GameObject virtualButtonObject2 = GameObject.Find("VirtualButton2");
            virtualButtonObject2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        }

        #endregion // MONOBEHAVIOUR_METHODS


        /// <summary>
        /// Called when the virtual button has just been pressed:
        /// </summary>
        public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
        {
            Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);

            // Add the material corresponding to this virtual button
            // to the active material list:
            switch (vb.VirtualButtonName)
            {
                case "mode1":
                    TapToSelect mode1 = mode1_Obj.GetComponent<TapToSelect>();
                    mode1.clickEvent();
                break;

                case "mode2":
                    TapToSelect1 mode2 = mode1_Obj.GetComponent<TapToSelect1>();
                    mode2.clickEvent();
                    break;
            }

        }

        public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
        {
            throw new NotImplementedException();
        }
    }
}