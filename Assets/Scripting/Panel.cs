using Nova;
using System;
using UnityEngine;


public abstract class Panel : MonoBehaviour
{
    public event Action OnClosed;

    [SerializeField]
    [Tooltip("The UIBlock root of the exit button. This panel will close and fire an event when the given Exit Button is \"clicked\".")]
    private UIBlock exitButton = null;

    private void Awake()
    {
        // Subscribe to close button click events
        exitButton.AddGestureHandler<Gesture.OnClick>(HandleExitClicked);
    }

    public virtual void Open(Vector3 worldPosition, Quaternion worldRotation)
    {
        // Enable this panel object
        gameObject.SetActive(true);

        // Assign position and rotation
        transform.position = worldPosition;
        transform.rotation = worldRotation;
    }

    private void HandleExitClicked(Gesture.OnClick evt)
    {
        // Disable panel and fire that it's been closed.
        gameObject.SetActive(false);

        // Notify listeners the panel has been closed
        OnClosed?.Invoke();
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        OnClosed?.Invoke();
    }
}

