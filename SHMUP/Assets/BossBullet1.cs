using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet1 : MonoBehaviour {

    private bool isReady;
    private float speed;
    private Vector2 dir;


    void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        dir = direction.normalized;
        isReady = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Destroy(gameObject);
        }
    }
    void Update () {
        if(isReady)
        {
            Vector2 position = transform.position;
            position += dir * speed * Time.deltaTime;

            transform.position = position;
                

        }
        
	}
}
