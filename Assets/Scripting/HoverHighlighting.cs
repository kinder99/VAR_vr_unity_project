using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverHighlighting : MonoBehaviour
{
    public Material original;
    public Material temp;

    //simple methods to call on hover entered and exited events
    public void HoverEntered()
    {
        GetComponent<MeshRenderer>().material = temp;
    }

    public void HoverExited()
    {
        GetComponent<MeshRenderer>().material = original;
    }
}
