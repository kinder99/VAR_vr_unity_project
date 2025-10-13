using Nova;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public UIBlock root = null;

    public BoolSetting BoolSettingAnchor = new BoolSetting();
    public BoolSetting BoolSettingRaycast = new BoolSetting();
    public ItemView ItemViewAnchor = null;
    public ItemView ItemViewRaycast = null;

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
        root.AddGestureHandler<Gesture.OnPress, RaycastVisuals>(RaycastVisuals.HandlePress);
        root.AddGestureHandler<Gesture.OnRelease, RaycastVisuals>(RaycastVisuals.HandleRelease);

        root.AddGestureHandler<Gesture.OnClick, RaycastVisuals>(HandleToggleClicked);

        BindRaycast(BoolSettingRaycast, ItemViewRaycast.Visuals as RaycastVisuals);
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
