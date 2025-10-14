using Nova;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SettingsMenu : MonoBehaviour
{
    public UIBlock root = null;

    public BoolSetting BoolSettingAnchor = new BoolSetting();
    public BoolSetting BoolSettingRaycast = new BoolSetting();
    public ItemView ItemViewAnchor = null;
    public ItemView ItemViewRaycast = null;
    public ActionBasedController leftController = null;
    public ActionBasedController rightController = null;

    private void Start()
    {
        root.AddGestureHandler<Gesture.OnHover, ToggleVisuals>(ToggleVisuals.HandleHover);
        root.AddGestureHandler<Gesture.OnUnhover, ToggleVisuals>(ToggleVisuals.HandleUnhover);
        root.AddGestureHandler<Gesture.OnPress, ToggleVisuals>(ToggleVisuals.HandlePress);
        root.AddGestureHandler<Gesture.OnRelease, ToggleVisuals>(ToggleVisuals.HandleRelease);

        root.AddGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleToggleClicked);

        BindAnchor(BoolSettingAnchor, ItemViewAnchor.Visuals as ToggleVisuals);

        root.AddGestureHandler<Gesture.OnHover, RaycastVisuals>(RaycastVisuals.HandleHover);
        root.AddGestureHandler<Gesture.OnUnhover, RaycastVisuals>(RaycastVisuals.HandleUnhover);
        root.AddGestureHandler<Gesture.OnPress, RaycastVisuals>(HandlePress);
        root.AddGestureHandler<Gesture.OnRelease, RaycastVisuals>(RaycastVisuals.HandleRelease);

        root.AddGestureHandler<Gesture.OnClick, RaycastVisuals>(HandleToggleClicked);

        BindRaycast(BoolSettingRaycast, ItemViewRaycast.Visuals as RaycastVisuals);
    }

    private void HandlePress(Gesture.OnPress evt, ToggleVisuals target)
    {
        BoolSettingAnchor.state = !BoolSettingAnchor.state;
        target.isChecked = BoolSettingAnchor.state;
    }

    private void HandlePress(Gesture.OnPress evt, RaycastVisuals target)
    {
        //BoolSettingRaycast.state = !BoolSettingRaycast.state;
        target.isChecked = BoolSettingRaycast.state;
        //Debug.Log(target.isChecked);
        if (target.isChecked)
        {
            leftController.GetComponent<XRRayInteractor>().enabled = true;
            leftController.GetComponent<XRInteractorLineVisual>().enabled = true;
            leftController.GetComponent<LineRenderer>().enabled = true;
            leftController.GetComponentInChildren<XRDirectInteractor>().enabled = false;

            rightController.GetComponent<XRRayInteractor>().enabled = true;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = true;
            rightController.GetComponent<LineRenderer>().enabled = true;
            rightController.GetComponentInChildren<XRDirectInteractor>().enabled = false;
        }
        else
        {
            leftController.GetComponent<XRRayInteractor>().enabled = false;
            leftController.GetComponent<XRInteractorLineVisual>().enabled = false;
            leftController.GetComponent<LineRenderer>().enabled = false;
            leftController.GetComponentInChildren<XRDirectInteractor>().enabled = true;

            rightController.GetComponent<XRRayInteractor>().enabled = false;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = false;
            rightController.GetComponent<LineRenderer>().enabled = false;
            rightController.GetComponentInChildren<XRDirectInteractor>().enabled = true;
        }
    }

    private void HandleToggleClicked(Gesture.OnClick evt, ToggleVisuals target)
    {
        BoolSettingAnchor.state = !BoolSettingAnchor.state;
        target.isChecked = BoolSettingAnchor.state;
    }

    private void HandleToggleClicked(Gesture.OnClick evt, RaycastVisuals target)
    {
        BoolSettingRaycast.state = !BoolSettingRaycast.state;
        target.isChecked = BoolSettingRaycast.state;
        if (target.isChecked)
        {
            PlayerPrefs.SetInt("raycast", 1);
            PlayerPrefs.Save();
            leftController.GetComponent<XRRayInteractor>().enabled = true;
            leftController.GetComponent<XRInteractorLineVisual>().enabled = true;
            leftController.GetComponent<LineRenderer>().enabled = true;
            leftController.GetComponentInChildren<XRDirectInteractor>().enabled = false;
            leftController.GetComponentInChildren<SphereCollider>().enabled = false;

            rightController.GetComponent<XRRayInteractor>().enabled = true;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = true;
            rightController.GetComponent<LineRenderer>().enabled = true;
            rightController.GetComponentInChildren<XRDirectInteractor>().enabled = false;
            rightController.GetComponentInChildren<SphereCollider>().enabled = false;
        }
        else
        {
            PlayerPrefs.SetInt("raycast", 0);
            PlayerPrefs.Save();
            leftController.GetComponent<XRRayInteractor>().enabled = false;
            leftController.GetComponent<XRInteractorLineVisual>().enabled = false;
            leftController.GetComponent<LineRenderer>().enabled = false;
            leftController.GetComponentInChildren<XRDirectInteractor>().enabled = true;
            leftController.GetComponentInChildren<SphereCollider>().enabled = true;

            rightController.GetComponent<XRRayInteractor>().enabled = false;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = false;
            rightController.GetComponent<LineRenderer>().enabled = false;
            rightController.GetComponentInChildren<XRDirectInteractor>().enabled = true;
            rightController.GetComponentInChildren<SphereCollider>().enabled = true;
        }
    }

    private void BindAnchor(BoolSetting setting, ToggleVisuals visuals)
    {
        visuals.label.Text = setting.name;
        visuals.isChecked = setting.state;
    }

    private void BindRaycast(BoolSetting setting, RaycastVisuals visuals)
    {
        visuals.label.Text = setting.name;
        visuals.isChecked = setting.state;
    }
}
