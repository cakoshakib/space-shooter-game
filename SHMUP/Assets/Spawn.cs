using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public int waves=1;
    public float rate;
    public GameObject[] enemies;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
  
    }
    


    void SpawnEnemy()
    {
        for(int i = 0; i < waves; i++)
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.5f,8.5f), 7,0),Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
