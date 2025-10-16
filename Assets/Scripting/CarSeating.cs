using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CarSeating : MonoBehaviour
{
    public bool isSeated = false;
    public XRSimpleInteractable interactable;
    public XROrigin player;
    public Transform seatLocation;
    public CapsuleCollider capsuleCollider;
    public Transform dismountLocation;

    //seat logic, should teleport origin to seat and lock joystick movement when seat is
    //interacted with and free up after another interaction
    public void SelectEntered()
    {
        if(!isSeated)
        {
            isSeated = true;
            player.transform.SetParent(this.transform);
            player.GetComponent<LocomotionSystem>().enabled = false;
            capsuleCollider.enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.MoveCameraToWorldLocation(seatLocation.transform.position);
        }
        else { 
            isSeated = false;
            player.transform.SetParent(null);
            player.MoveCameraToWorldLocation(dismountLocation.transform.position);
            player.GetComponent<LocomotionSystem>().enabled = true;
            capsuleCollider.enabled = true;
            player.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
