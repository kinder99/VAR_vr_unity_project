using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NovaSamples.HandMenu
{
    public class PanelUIController : MonoBehaviour
    {
        [SerializeField]
        private Camera headTrackedCamera = null;

        [SerializeField]
        private Transform palmTransform = null;

        [SerializeField]
        private float lowerShowLauncherThreshold = 50f;

        [SerializeField]
        private float upperShowLauncherThreshold = 80f;

        [Header("Panel Launching")]
        [SerializeField]
        private HandLauncher handLauncher = null;
        [SerializeField]
        private Transform handLauncherPivot = null;
        [SerializeField]
        private Transform panelPopupLocation = null;
        [SerializeField]
        private List<Panel> Panels = null;

        [Header("Lights")]
        [SerializeField]
        private Light fingerTipPointLight = null;


        private bool handLauncherActive = false;
        private bool selectedPanelActive = false;

        private bool HandLauncherShouldBeActive //check if settings button should pop up
        {
            get
            {
                return getAngle() < upperShowLauncherThreshold && lowerShowLauncherThreshold < getAngle();
            }
        }

        private void Awake()
        {
            // Subscribe to panel open events
            handLauncher.OnPanelSelected += HandlePanelSelected;

            // Subscribe to panel close events
            for (int i = 0; i < Panels.Count; i++)
            {
                Panels[i].OnClosed += HandleSelectedPanelClosed;
                Panels[i].gameObject.SetActive(false);
            }

            // Start with the hand launcher inactive
            handLauncher.gameObject.SetActive(false);

            PlayerPrefs.SetInt("raycast", 1);
        }

        private void Update()
        {
            //Debug.Log(getAngle());
            if (selectedPanelActive)
            {
                // Don't show hand launcher if a panel is active.
                return;
            }

            if (handLauncherActive) // Currently active
            {
                //Debug.Log("Active");
                if (!HandLauncherShouldBeActive) // Should be inactive
                {
                    // Hide
                    HideHandLauncher();
                }
                else // Should be active
                {
                    // Update position
                    RepositionMenu();
                }
            }
            else if (HandLauncherShouldBeActive) // Not active, but it should be
            {
                // Open
                ShowHandLauncher();

                // Update position
                RepositionMenu();
            }
        }

        private float getAngle()
        {
            float angleBetweenHeadAndPalm = Vector3.Angle(palmTransform.forward, headTrackedCamera.transform.forward);

            return Mathf.Abs(angleBetweenHeadAndPalm);
        }

        public void HideHandLauncher()
        {
            if (!handLauncherActive)
            {
                return;
            }

            handLauncherActive = false;
            handLauncher.Hide();
        }

        private void ShowHandLauncher()
        {
            if (handLauncherActive)
            {
                return;
            }

            handLauncherActive = true;
            handLauncher.Show();
        }

        private void HandleSelectedPanelClosed()
        {
            selectedPanelActive = false;

            //directionLight.enabled = true;
            fingerTipPointLight.enabled = false;
        }

        private void HandlePanelSelected(PanelItem item)
        {
            if (item.Panel == null)
            {
                // Nothing to open
                return;
            }

            // Get the index of the selected panel, should only be settings since it's the only one
            int index = Panels.IndexOf(item.Panel);

            if (index == -1)
            {
                // Not found, nothing to open.
                return;
            }

            Panel panel = Panels[index];
            // Open the panel at the popup location
            panel.Open(panelPopupLocation.position, panelPopupLocation.rotation);
            
            // Indicate a panel is active, so we don't activate the handLauncher
            selectedPanelActive = true;

            // Close
            HideHandLauncher();
        }
        private void RepositionMenu()
        {
            handLauncher.transform.SetPositionAndRotation(handLauncherPivot.position, handLauncherPivot.rotation);
        }
    }
}

