using Nova;
using System;
using System.Collections.Generic;
using System.Net;
using UnityEditor.XR.Interaction.Toolkit;
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
        public SettingsPanel settings;
        public SphereCollider collider;

        public bool grip;
        public bool raycast;

        public uint id;

        public void Update()
        {
            if (controller == null)
            {
                return;
            }

            grip = controller.selectAction.action.IsPressed();
            //if (grip) { Debug.Log("press"); }
            //Debug.Log(PlayerPrefs.GetInt("raycast"));
            bool doRay = true;
            if (PlayerPrefs.GetInt("raycast") == 0)
            {
                Interaction.Point(collider, id);
                doRay = false;
            }
            //Debug.Log("raycast : " + raycast.ToString());
            if (doRay)
            {
                Ray ray = new Ray(interactor.transform.position, interactor.transform.rotation * Vector3.forward);
                //Debug.Log("pew");
                Interaction.Update pointUpdate = new Interaction.Update(ray, id);
                Interaction.Point(pointUpdate, grip);
            }

        }
    }

    [SerializeField]
    private Controller leftController = new Controller()
    {
        grip = false,
        id = leftControllerID,
        raycast = true,
    };

    [SerializeField]
    private Controller rightController = new Controller()
    {
        grip = false,
        id = rightControllerID,
        raycast = true,
    };

    private void Start()
    {
        PlayerPrefs.SetInt("raycast", 1);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        leftController.Update();
        rightController.Update();
    }
}
