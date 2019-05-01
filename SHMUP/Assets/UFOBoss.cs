using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBoss : MonoBehaviour {

    public float movementSpeed;
    public float moveSpeed;
    Rigidbody2D rb;
    public int health;  
    public int score;
    public GameObject explosion;
    public GameObject healthBar;
    private Vector3 endPosition = new Vector3(0, 3.11f, 0);
    private Vector3 leftWall = new Vector3(-6, 3.11f, 0);
    private Vector3 rightWall = new Vector3(6, 3.11f, 0);
    private bool check = false;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
   
    }

    void Update()
    {
        SetHealthBar();
        if (health > 180)
        {
            if (transform.position != endPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
            }
        }
        if (health <= 100)
        {
            Phase2();
        }


    }

    public void SetHealthBar()
    { 
        healthBar.transform.localScale = new Vector3(health/200f * 1, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            health--;
        }
    }

    


    void Phase2()
    {

        if (check == false) //checks if they are in the middle then moves to left wall
        {
            if (transform.position != leftWall)
            {
                transform.position = Vector3.MoveTowards(transform.position, leftWall, moveSpeed * Time.deltaTime);
                if (transform.position == leftWall)
                {
                    check = true;
                }
            }
        }
        else if (check == true)
        {
            if (transform.position != rightWall)
            {
                transform.position = Vector3.MoveTowards(transform.position, rightWall, moveSpeed * Time.deltaTime);
                if(transform.position == rightWall)
                {
                    check = false;
                }
            }
        }
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            Die();
        }
     

    }

    void Die()
    { 
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
    }

}
