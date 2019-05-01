using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawns : MonoBehaviour {

    public GameObject UFOBoss1, Boss2;
    private bool isCreated = false;

	void Update () {
        if (isCreated == false)
        {
            if (PlayerPrefs.GetInt("Score") >= 5000)
            {
                Instantiate(UFOBoss1, new Vector2(0, 7.33f), Quaternion.identity);
                isCreated = true;
            }
            if (PlayerPrefs.GetInt("Score") >= 20000)
            {
                Instantiate(Boss2, new Vector3(0, 7.33f), Quaternion.identity);
            }
        }

  
	}


	void Start () {
		
	}
}
