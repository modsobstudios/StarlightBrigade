using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private Vector2 position;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float health;
    private int points = 5;
    private PlayerShip player;
    private SpriteRenderer sr;
    private Sprite[] splode;
    private int splodeCt = 0;
    private bool Orbit = false;
    private Transform center;
    public Vector3 axis = new Vector3(0, 0, 1);
    public float radius = 5.5f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    private float randZ;

    public bool Stroid = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");

        if (Stroid)
        {
            randZ = Random.Range(-5, 5);
            float scale = Random.Range(0.9f, 1.5f);
            gameObject.transform.localScale = new Vector3(scale, scale, 1);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Orbit)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
            var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        }
        else
        {
            transform.position -= new Vector3(0, 0.33f, 0) * Time.deltaTime * speed;
        }
        if (Stroid)
        {
            transform.Rotate(new Vector3(0, 0, transform.rotation.z + randZ));
        }

        if (health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<Projectile>().getDamage();
            sr.color = Color.white;
            if (health <= 0)
                player.awardPoints(points);
        }
        if (collision.transform.tag == "PlayerShip")
        {
            player.awardPoints(points);
            player.takeDamage(5);
            sr.color = Color.white;
            health = 0;
        }
        if (collision.transform.tag == "Orbit")
        {
            center = collision.transform;
            Orbit = true;
        }
    }
}
