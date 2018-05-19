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
    private int points;
    private PlayerShip player;
    private SpriteRenderer sr;
    private Sprite[] splode;
    private int splodeCt = 0;

    private float randZ;

    public bool Stroid = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");

        if(Stroid)
        {
            randZ = Random.Range(-5, 5);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * speed;
        if(Stroid)
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
        player.awardPoints(points);
        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<Projectile>().getDamage();
            sr.color = Color.white;
        }
        if(collision.transform.tag == "PlayerShip")
        {
            sr.color = Color.white;
            die();
        }
    }
}
