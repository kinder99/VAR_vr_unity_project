using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HoverHighlighting : MonoBehaviour
{
    public Material original;
    public Material temp;

    public void HoverEntered()
    {
        //Debug.Log("prout");
        GetComponent<MeshRenderer>().material = temp;
    }

    public void HoverExited()
    {
        GetComponent<MeshRenderer>().material = original;
    }
}
