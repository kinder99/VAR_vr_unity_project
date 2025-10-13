using NovaSamples.HandMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMisc : MonoBehaviour
{
    public Transform anchor;
    public SettingsMenu settings;
    public Panel panel;
    public BoolSetting BoolSetting;
    // Start is called before the first frame update
    void Start()
    {
        BoolSetting = settings.BoolSettingAnchor;

    }

    // Update is called once per frame
    void Update()
    {
        if (BoolSetting.state)
        {
            this.gameObject.transform.SetParent(null);
            foreach (CapsuleCollider c in this.GetComponents<CapsuleCollider>())
            {
                c.enabled = true;
            }
            float distance = Vector3.Distance(this.transform.position, anchor.position);
            if (distance > 5.0f ) {
                panel.Exit();
            }
        }
        else
        {
            this.gameObject.transform.SetParent(anchor);
            foreach (CapsuleCollider c in this.GetComponents<CapsuleCollider>())
            {
                c.enabled = false;
            }
        }
        //this.transform.LookAt(mainCamera.transform.position);
        //this.transform.position = anchor.transform.position;
    }
}
