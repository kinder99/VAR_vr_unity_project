using Nova;
using UnityEngine;

/// <summary>
/// The UI panel responsible for managing a set of interactive toggles/buttons/sliders to adjust certain system settings (e.g. volume).
/// </summary>
public class SettingsPanel : Panel
{
    //[Header("Quick Toggles")]
    //[SerializeField]
    //[Tooltip("The UIBlock parent of all the quick toggles.")]
    //private UIBlock quickToggleRoot = null;

    //[Header("Volume")]
    [SerializeField]
    private ItemView AnchorView = null;

    //[Header("Volume")]
    [SerializeField]
    private ItemView RaycastView = null;
    private ToggleVisuals AnchorVisuals => AnchorView.Visuals as ToggleVisuals;
    private RaycastVisuals RaycastVisuals => RaycastView.Visuals as RaycastVisuals;

    public bool isAnchored
    {
        get => !AnchorVisuals.isChecked;
        set => AnchorVisuals.isChecked = value;
    }

    public bool isRaycasting
    {
        get => RaycastVisuals.isChecked;
        set => RaycastVisuals.isChecked = value;
    }

    private float volumePercent = 0.5f;

    private void OnEnable()
    {
        //quickToggleRoot.AddGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleQuickToggleClicked);

        AnchorView.UIBlock.AddGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleAnchorToggled);

        RaycastView.UIBlock.AddGestureHandler<Gesture.OnClick, RaycastVisuals>(HandleRaycastToggled);
    }

    private void OnDisable()
    {
        //unsubscribe from the gesture events
        //quickToggleRoot.RemoveGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleQuickToggleClicked);
        AnchorView.UIBlock.RemoveGestureHandler<Gesture.OnClick, ToggleVisuals>(HandleAnchorToggled);
        RaycastView.UIBlock.RemoveGestureHandler<Gesture.OnClick, RaycastVisuals> (HandleRaycastToggled);
    }


    private void HandleAnchorToggled(Gesture.OnClick evt, ToggleVisuals target)
    {
        target.Toggle();
    }

    private void HandleRaycastToggled(Gesture.OnClick evt, RaycastVisuals target)
    {
        target.Toggle();
    }

    private void HandleQuickToggleClicked(Gesture.OnClick evt, ToggleVisuals target)
    {
        target.Toggle();
    }

    private void Update()
    {
    }
}

