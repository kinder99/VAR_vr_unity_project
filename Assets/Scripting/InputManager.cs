using Nova;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using XRController = UnityEngine.InputSystem.XR.XRController;

public class InputManager : MonoBehaviour
{
    private const uint leftControllerID = 1;
    private const uint rightControllerID = 2;

    [Serializable]
    private struct Controller
    {
        public ActionBasedController controller;
        public XRRayInteractor interactor;
        public InputDevice device;

        public bool grip;

        public uint id;

        public void Update()
        {
            if (controller == null)
            {
                return;
            }
            grip = controller.selectAction.action.IsPressed();
            if (grip) { Debug.Log("press"); }
            Ray ray = new Ray(interactor.transform.position, interactor.transform.rotation * Vector3.forward);
            Debug.Log(interactor.transform.rotation);
            Interaction.Update pointUpdate = new Interaction.Update(ray, id);
            Interaction.Point(pointUpdate, grip);
        }
    }

    [SerializeField]
    private Controller leftController = new Controller()
    {
        grip = false,
        id = leftControllerID,
    };

    [SerializeField]
    private Controller rightController = new Controller()
    {
        grip = false,
        id = rightControllerID,
    };

    private void Update()
    {
        leftController.Update();
        rightController.Update();
    }
}
