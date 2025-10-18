using Nova;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

//handles teleporting the player to the predefined anchors when one of the buttons is clicked
public class TeleportMenu : MonoBehaviour
{
    public UIBlock root = null;

    public ItemView AnchorOne;
    public ItemView AnchorTwo;

    public Transform AnchorOneLocation;
    public Transform AnchorTwoLocation;

    public XROrigin player;
    public CarSeating car;
    void Start()
    {
        root.AddGestureHandler<Gesture.OnHover, AnchorOneVisuals>(AnchorOneVisuals.HandleHover);
        root.AddGestureHandler<Gesture.OnHover, AnchorTwoVisuals>(AnchorTwoVisuals.HandleHover);
        root.AddGestureHandler<Gesture.OnUnhover, AnchorOneVisuals>(AnchorOneVisuals.HandleUnhover);
        root.AddGestureHandler<Gesture.OnUnhover, AnchorTwoVisuals>(AnchorTwoVisuals.HandleUnhover);
        root.AddGestureHandler<Gesture.OnClick, AnchorOneVisuals>(HandleOneClicked);
        root.AddGestureHandler<Gesture.OnClick, AnchorTwoVisuals>(HandleTwoClicked);
    }

    private void HandleOneClicked(Gesture.OnClick evt, AnchorOneVisuals target)
    {
        if (!car.isSeated)
        {
            player.MoveCameraToWorldLocation(AnchorOneLocation.position);
        }
    }

    private void HandleTwoClicked(Gesture.OnClick evt, AnchorTwoVisuals target)
    {
        if(!car.isSeated)
        {
            player.MoveCameraToWorldLocation(AnchorTwoLocation.position);
        }
    }
}
