using Nova;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovaSamples.HandMenu
{
    public class SettingsButton : MonoBehaviour
    {
        public UIBlock root = null;

        [Header("Temporary")]
        public BoolSetting BoolSetting = new BoolSetting();
        public ItemView ItemView = null;

        private void Start()
        {
            //Debug.Log("started");
            root.AddGestureHandler<Gesture.OnClick, PanelItemVisuals>(HandleClick);

            Bind(BoolSetting, ItemView.Visuals as PanelItemVisuals);
        }

        private void HandleClick(Gesture.OnClick evt, PanelItemVisuals target)
        {
            BoolSetting.state = !BoolSetting.state;
            target.isChecked = BoolSetting.state;
        }

        private void Bind(BoolSetting setting, PanelItemVisuals visuals)
        {
            visuals.isChecked = setting.state;
        }
    }
}
