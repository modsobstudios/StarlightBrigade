using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector2 position;
    float health;
    float speed;
    int points;
    Weapon weapon;
    public Sprite[] splode;
    bool asplode = false;
    int splodeCt = 0;
    SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (asplode)
            esplode();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerProjectile")
        {
            Destroy(collision.gameObject);
            asplode = true;
            sr.color = Color.white;
        }
        if(collision.transform.tag == "PlayerShip")
        {
            asplode = true;
            sr.color = Color.white;
        }
    }

    private void esplode()
    {
        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
            Destroy(this.gameObject);
    }
}
