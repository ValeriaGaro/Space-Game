using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject Asteroid;
    public float launchDelay;
    float nextLaunchTime;

   
    void Update()
    {
        if (!GameController.isStarted)
        {
            return;
        }
        if (Time.time > nextLaunchTime)
        {
            var shiftx = Random.Range(- transform.localScale.x/2, transform.localScale.x / 2) ;
            var position = transform.position + new Vector3(shiftx, 0, 0);
            Instantiate(Asteroid, position, Quaternion.identity );
            nextLaunchTime = Time.time + launchDelay;
        }

    }
}
