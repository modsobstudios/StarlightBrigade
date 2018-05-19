using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector2 position;
    float health = 10.0f;
    float speed;
    int points;
    Weapon weapon;
    public Sprite[] splode;
    bool asplode = false;
    int splodeCt = 0;
    SpriteRenderer sr;
    PlayerShip player;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0.0f)
        {
            asplode = true;
            sr.color = Color.white;
            player.awardPoints(points);
        }
        if (asplode)
            esplode();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            takeDamage(collision.gameObject.GetComponent<Projectile>().getDamage());

        }
        if(collision.transform.tag == "PlayerShip")
        {
            player.takeDamage(health);
            takeDamage(health);
        }
    }

    private void esplode()
    {
        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
            Destroy(this.gameObject);
    }

    public void takeDamage(float _hp)
    {
        health -= _hp;
    }
}
