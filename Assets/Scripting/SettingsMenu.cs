using Nova;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public UIBlock root = null;

    [Header("Temporary")]
    public BoolSetting BoolSetting = new BoolSetting();
    public ItemView ItemView = null;

    private void Start()
    {
        root.AddGestureHandler<Gesture.OnHover, ToggleVisuals>(ToggleVisuals.HandleHover);
        root.AddGestureHandler<Gesture.OnUnhover, ToggleVisuals>(ToggleVisuals.HandleUnhover);
        root.AddGestureHandler<Gesture.OnPress, ToggleVisuals>(ToggleVisuals.HandlePress);
        root.AddGestureHandler<Gesture.OnRelease, ToggleVisuals>(ToggleVisuals.HandleRelease);

        root.AddGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleToggleClicked);

        Bind(BoolSetting, ItemView.Visuals as ToggleVisuals);
    }

    private void HandleToggleClicked(Gesture.OnClick evt, ToggleVisuals target)
    {
        BoolSetting.state = !BoolSetting.state;
        target.isChecked = BoolSetting.state;
    }

    private void Bind(BoolSetting setting, ToggleVisuals visuals)
    {
        visuals.label.Text = setting.name;
        visuals.isChecked = setting.state;
    }
}
