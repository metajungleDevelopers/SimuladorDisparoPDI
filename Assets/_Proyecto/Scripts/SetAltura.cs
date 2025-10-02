using HurricaneVR.Framework.ControllerInput;
using HurricaneVR.Framework.Core.Player;
using UnityEngine;


namespace HurricaneVR.TechDemo.Scripts
{
        public class SetAltura : MonoBehaviour
        {

            public HVRPlayerController Player;
            public HVRCameraRig CameraRig;
            public HVRPlayerInputs Inputs;



        private void Start()
        {
            CalibrateHeight();
        }


        public void CalibrateHeight()
            {
                if (CameraRig)
                    CameraRig.Calibrate();
            }
        }
        
}
