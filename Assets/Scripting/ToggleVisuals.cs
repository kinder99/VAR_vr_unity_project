using Nova;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ToggleVisuals : ItemVisuals
{
    public TextBlock label = null;
    public UIBlock2D checkbox = null;
    public UIBlock2D checkmark = null;

    public Color DefaultColor;
    public Color HoveredColor;
    public Color PressedColor;

    public bool isChecked
    {
        get => checkmark.gameObject.activeSelf;
        set => checkmark.gameObject.SetActive(value);
    }

    internal static void HandleHover(Gesture.OnHover evt, ToggleVisuals target)
    {
        target.checkbox.Color = target.HoveredColor;
    }

    internal static void HandlePress(Gesture.OnPress evt, ToggleVisuals target)
    {
        target.checkbox.Color = target.PressedColor;
    }

    internal static void HandleRelease(Gesture.OnRelease evt, ToggleVisuals target)
    {
        target.checkbox.Color = target.HoveredColor;
    }

    internal static void HandleUnhover(Gesture.OnUnhover evt, ToggleVisuals target)
    {
        target.checkbox.Color = target.DefaultColor;
    }
}
