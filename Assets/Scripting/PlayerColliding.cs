using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliding : MonoBehaviour
{

    public Transform head;
    public Transform floorReference;

    CapsuleCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float height = head.position.y - floorReference.position.y;
        collider.height = height;
        transform.position = head.position - Vector3.up * height / 2;
    }
}
