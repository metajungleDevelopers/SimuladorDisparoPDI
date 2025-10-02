using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRIKMovementAnimator : MonoBehaviour
{
    public Animator animator;

    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;

    void Start()
    {
        TryInitializeDevices();
    }

    void Update()
    {
        if (!leftHandDevice.isValid || !rightHandDevice.isValid)
            TryInitializeDevices();

        Vector2 primary2DAxis;
        // Puedes cambiar leftHandDevice por rightHandDevice si el joystick derecho controla el movimiento
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxis))
        {
            float horizontal = primary2DAxis.x;
            float vertical = primary2DAxis.y;
            float speed = new Vector2(horizontal, vertical).magnitude;

            // Asignar valores al Animator
            animator.SetFloat("VRIK_Horizontal", horizontal);
            animator.SetFloat("VRIK_Vertical", vertical);
            animator.SetFloat("VRIK_Speed", speed);
            animator.SetBool("VRIK_IsMoving", speed > 0.1f); // Threshold para "está moviéndose"
        }
    }

    void TryInitializeDevices()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller, devices);

        if (devices.Count > 0)
            leftHandDevice = devices[0];

        devices.Clear();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller, devices);

        if (devices.Count > 0)
            rightHandDevice = devices[0];
    }
}
