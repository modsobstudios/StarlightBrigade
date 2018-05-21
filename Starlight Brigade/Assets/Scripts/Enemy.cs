using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform center;
    public Vector3 axis = new Vector3(0, 0, 1);
    public float radius = 5.5f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    Vector2 position;
    public float health = 30.0f;
    float speed;
    public int points = 10;
    Weapon weapon;
    public Sprite[] splode, ship;
    public bool asplode = false;
    bool visible = false;
    int splodeCt = 0;
    int shipCt = 0;
    int animCt = 0;
    public bool Left = false;
    public bool Side = false;
    public bool Orbit = false;
    SpriteRenderer sr;
    PlayerShip player;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");
        ship = Resources.LoadAll<Sprite>("EnemyShip1");
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null)
            player = GameObject.Find("Player").GetComponent<PlayerShip>();

        if (health <= 0.0f && !asplode)
        {
            AudioClip au = Resources.Load<AudioClip>("Audio/splode");
            GameObject.Find("SFX Source").GetComponent<AudioSource>().PlayOneShot(au);
        }
        if (health <= 0.0f)
        {
            asplode = true;
            sr.color = Color.white;
        }

        if (asplode)
            esplode();
        else
        {
            animCt++;
            if (animCt % 5 == 0)
            {
                animCt = 0;
                sr.sprite = ship[shipCt];
                shipCt++;
                if (shipCt == ship.Length)
                    shipCt = 0;
            }
        }

        move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            takeDamage(collision.gameObject.GetComponent<Projectile>().getDamage());
            if (health <= 0)
                player.awardPoints(points);
        }
        if (collision.transform.tag == "PlayerShip")
        {
            player.takeDamage(health);
            takeDamage(health);
        }
        //if (collision.transform.tag == "PlayerLaser" && GetComponent<SpriteRenderer>().isVisible)
        //{
        //    takeDamage(health);
        //}
        if (collision.transform.tag == "Bounds")
        {
            Left = !Left;
        }
        if (collision.transform.tag == "Orbit")
        {
            center = collision.transform;
            Orbit = true;
            Side = false;
        }
    }

    private void esplode()
    {

        GetComponent<BoxCollider2D>().enabled = false;
        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(float _hp)
    {
        health -= _hp;
    }

    void move()
    {
        if (Side)
        {
            if (Left)
            {
                transform.position += new Vector3(-0.2f, -0.05f, 0) * Time.deltaTime * 10;
            }
            else
            {
                transform.position += new Vector3(0.2f, -0.05f, 0) * Time.deltaTime * 10;
            }
        }
        else if (Orbit)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        else
        {
            transform.position += new Vector3(0, -0.2f, 0) * Time.deltaTime * 10;
        }
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        if (visible)
            Destroy(this.gameObject);
    }
}

