using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Features.Interactions;

public class TeleportAnchor : MonoBehaviour
{
    public XRSimpleInteractable interactable;
    public Transform teleportPosition;

    public XROrigin origin;
    public Transform playerCamera;
    public Transform playerCollider;
    public Transform floorReference;

    [SerializeField] private SelectEnterEvent selectEnter;
    // Start is called before the first frame update
    void Start()
    {
        interactable = this.GetComponent<XRSimpleInteractable>();
        selectEnter.AddListener(Test);
        interactable.firstSelectEntered = selectEnter;
    }

    private void Update()
    {
        //Debug.Log("origin : " + origin.transform.position);
    }

    public void Test(SelectEnterEventArgs args)
    {
        this.Teleport();
    }
    
    public void Teleport()
    {

        Vector3 pos = teleportPosition.position;
        origin.MoveCameraToWorldLocation(pos);
    }
}
