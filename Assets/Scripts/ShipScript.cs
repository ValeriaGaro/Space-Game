using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    public GameObject laserShot;
    public GameObject laserGun;
    public float shotDelay;

    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;
    Rigidbody ship;

    float nextShotTime;

    void Start()
    {
        ship = GetComponent<Rigidbody>();
        
    }

    
    void Update()
    {
        if (!GameController.isStarted)
        {
            return;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(correctX, 0, correctZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x*tilt);


        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(laserShot, laserGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;

            if (GameController.score > 100)
            {
                GameController.score -= 15;
            }
        }
       
       
    }
}
