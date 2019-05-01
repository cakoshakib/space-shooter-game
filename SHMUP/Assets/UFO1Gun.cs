using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO1Gun : MonoBehaviour {

    public GameObject BossBullet1;
    public float fireRate;

	// Use this for initialization
	void Start () {
      
       InvokeRepeating("Boss1Shoot", fireRate, fireRate);

    }


	// Update is called once per frame
	void Update () {
		

	}

  

    void Boss1Shoot()
    {
        GameObject playership = GameObject.Find("MainShip");

        if (playership != null)
        {
            GameObject bullet = (GameObject)Instantiate(BossBullet1);

            bullet.transform.position = transform.position;

            Vector2 direction = playership.transform.position - bullet.transform.position;

            bullet.GetComponent<BossBullet1>().SetDirection(direction);
        }

    }
}
