using Nova;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaycastVisuals : ItemVisuals
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

    public void Toggle()
    {
        isChecked = !isChecked;
    }

    internal static void HandleHover(Gesture.OnHover evt, RaycastVisuals target)
    {
        target.checkbox.Color = target.HoveredColor;
    }

    internal static void HandlePress(Gesture.OnPress evt, RaycastVisuals target)
    {
        target.checkbox.Color = target.PressedColor;
    }

    internal static void HandleRelease(Gesture.OnRelease evt, RaycastVisuals target)
    {
        target.checkbox.Color = target.HoveredColor;
    }

    internal static void HandleUnhover(Gesture.OnUnhover evt, RaycastVisuals target)
    {
        target.checkbox.Color = target.DefaultColor;
    }
}
