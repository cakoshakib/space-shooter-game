using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    int dir = 1;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection () {
        dir *= -1;
	}
	
    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
    }

	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0, 12 * dir);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Boss")
        {
            col.gameObject.GetComponent<UFOBoss>().Damage();
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Boss2")
        {
            col.gameObject.GetComponent<Boss2>().Damage();
            Destroy(gameObject);
        }

        if (dir == 1)
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
        
        }
        else
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<Spaceship>().Damage();
                Destroy(gameObject);
            }
        }
    }

}
