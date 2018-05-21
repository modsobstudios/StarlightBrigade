using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform center;
    public Vector3 axis = new Vector3(0, 0, 1);
    public float radius = 5.5f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    Vector2 position;
    public float health = 300.0f;
    float speed;
    public int points = 100;
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

        if (health <= 0.0f)
        {
            asplode = true;
            sr.color = Color.white;
        }
        if (asplode)
            esplode();

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
            player.takeDamage(20);
        }
        if (collision.transform.tag == "Bounds")
        {
            Left = !Left;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
            player.takeDamage(20);
        }
        if (collision.transform.tag == "Bounds")
        {
            Left = !Left;
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
        if (gameObject.transform.position.y > 3.5)
        {
            transform.position += new Vector3(0, -0.05f, 0) * Time.deltaTime * 10;
        }
        else
        {
            if (Left)
            {
                transform.position += new Vector3(-0.2f, 0, 0) * Time.deltaTime * 10;
            }
            else
            {
                transform.position += new Vector3(0.2f, 0, 0) * Time.deltaTime * 10;
            }
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
