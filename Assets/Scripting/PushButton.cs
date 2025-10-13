using Nova;
using UnityEngine;

namespace NovaSamples.HandMenu
{
    /// <summary>
    /// Converts <see cref="Gesture.OnDrag"/> events along the Z axis into 
    /// <see cref="Gesture.OnClick"/> events. Animates either the Z size or the Y axis
    /// rotation of a provided <see cref="PushVisual"/> to visualize the users' press actions.
    /// </summary>
    [RequireComponent(typeof(Interactable))]
    public class PushButton : MonoBehaviour
    {

        /// <summary>
        /// The interactable component on this.gameObject.
        /// </summary>
        public Interactable interactable = null;
        static public bool isPressed = false;

        private void OnEnable()
        {
            //Debug.Log("here");
            // Ensure initialized
            if (interactable == null)
            {
                // Guaranteed to be there because Interactable is a required component
                interactable = GetComponent<Interactable>();

                // ensure draggable on z
                interactable.Draggable = new ThreeD<bool>(false, false, true);
            }

            // Subscribe to the necessary gesture events to track/trigger click events
            interactable.UIBlock.AddGestureHandler<Gesture.OnClick>(Press);
            interactable.UIBlock.AddGestureHandler<Gesture.OnRelease>(Release);
        }

        private void Update()
        {
            //Debug.Log(isPressed);
        }

        /// <summary>
        /// On press, check the entry point of the collision.
        /// </summary>
        private void Press(Gesture.OnClick evt)
        {
            // Convert the press event intersection point into local space
            //Debug.Log("pressed");
            isPressed = true;
            Gesture.OnClick click = new Gesture.OnClick() { Interaction = evt.Interaction };

            // If the z value is greater than 0, the pointer entered
            // through the back side of the collidable volume.
        }

        /// <summary>
        /// On release, fire a click event if the click threshold has been met. Also reset the tracked push state.
        /// </summary>
        private void Release(Gesture.OnRelease evt)
        {
            // If this release event followed a drag event which,
            // surpassed our configured click threshold, fire a click event.
            // Reading it here because we're about to reset clickThresholdSurpassed.
            bool fireClickEvent = isPressed;

            if (fireClickEvent)
            {
                //Gesture.OnClick click = new Gesture.OnClick() { Interaction = evt.Interaction };
                isPressed = false;
            }
        }

        /// <summary>
        /// An animation which will fire a <see cref="Gesture.OnClick"/> event.
        /// </summary>
        public struct ClickAnimationEvent : IAnimation
        {
            public UIBlock Target;
            public Gesture.OnClick ClickEvent;
            private bool check;

            public void Update(float percentDone)
            {
                check = isPressed;
                if (check)
                {
                    Target.FireGestureEvent(ClickEvent);
                }
            }
        }
    }
}
