using Nova;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles one anchor teleport button
public class AnchorOneVisuals : ItemVisuals
{
    public TextBlock label = null;
    public UIBlock root = null;

    public Color defaultColor;
    public Color hoveredColor;

    internal static void HandleHover(Gesture.OnHover evt, AnchorOneVisuals target)
    {
        target.label.Color = target.hoveredColor;
    }

    internal static void HandleUnhover(Gesture.OnUnhover evt, AnchorOneVisuals target)
    {
        target.label.Color = target.defaultColor;
    }
}
