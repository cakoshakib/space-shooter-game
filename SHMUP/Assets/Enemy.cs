using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;
    public GameObject Bullet, explosion, battery;
    public Color bulletcolor;
    public float xSpeed;
    public float ySpeed;
    public int score;
    public bool canShoot;
    public float fireRate;  
    public float health;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start ()
    {
        if (!canShoot) return;
        fireRate = fireRate + (Random.Range(fireRate / -2,fireRate/2));
        InvokeRepeating("Shoot", fireRate, fireRate);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }

    public void Damage()
    { 
        health--;
        StartCoroutine(Blink());
        if (health == 0)
        {
            Die();
        }

    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

    }

    void Die()
    {
        if ((int)Random.Range(0, 5) == 0)
        {
            Instantiate(battery, transform.position, Quaternion.identity);
        }
        Instantiate(explosion,transform.position, Quaternion.identity); 
        Destroy(gameObject);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
    }

    void Shoot()
    {
        GameObject temp = (GameObject) Instantiate(Bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(bulletcolor);
    }
}
