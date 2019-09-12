using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    GameObject a,b;
    Rigidbody2D rb;
    public float speed;
    public int health = 3;
    public GameObject bullet,explosion;
    public int delay = 0;
    public AudioSource[] sounds;
    public AudioSource laser;
    public AudioSource damaging;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a=transform.Find("a").gameObject;
        b=transform.Find("b").gameObject;
    }

    void Start()
    {
        
        PlayerPrefs.SetInt("Health", health);
        sounds = GetComponents<AudioSource>();
        laser = sounds[0];
        damaging = sounds[1];
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);

        if (Input.GetKey(KeyCode.Space) && delay > 20)
        {
            
            Shoot();
            laser.Play();
        }
        delay++;
        if(PlayerPrefs.GetInt("Score") >= 9000 )
        {
            SetHealth(0);
        }
    }

    void Move(Vector2 direction)
    {
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos;
    }
    
    public void Damage()
    {
        StartCoroutine(Blink());
        health--;
        PlayerPrefs.SetInt("Health", health);
        damaging.Play();
        if (health == 0)
        {
           
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

    }

    void Shoot()
    {
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
        delay = 0;
    }

    public void SetHealth(int i)
    {
        health = i;
        if (health == 0)
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }
    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }

}
