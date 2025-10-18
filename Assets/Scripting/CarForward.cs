using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarForward : MonoBehaviour
{
    public GameObject car;
    public GameObject control;
    public Transform controlSpawn;
    public CarSeating carSeating;
    public float cooldown = 0;

    //some problems with the grabbing not interacting well with the position reset when still grabbed
    private void OnTriggerEnter(Collider other)
    {
        if(carSeating.isSeated && cooldown <= 0)
        {
            cooldown = 5;
            StartCoroutine(MoveOverSpeed(car, new Vector3(35.15f, -0.001f, 0.85f), 3.6f));
        }
    }

    private void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
    }

    public IEnumerator MoveOverSpeed(GameObject objectToMove, Vector3 end, float speed)
    {
        // speed should be 1 unit per second
        while (objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        control.GetComponent<Rigidbody>().velocity = Vector3.zero;
        control.transform.position = controlSpawn.position;
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }
}
