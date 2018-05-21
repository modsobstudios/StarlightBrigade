using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : Projectile
{

    float counter = 2.0f;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bullet = Resources.LoadAll<Sprite>("Lazarr");
        damage = 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animCt++;
        if (animCt % 5 == 0)
        {
            animCt = 0;
            sr.sprite = bullet[bulletCt];
            bulletCt++;
            if (bulletCt == bullet.Length)
                bulletCt = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "EnemyShip")
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        counter -= 0.1f;
        if (counter <= 0.0f)
        {
            counter = 2.0f;
            if (collision.transform.tag == "EnemyShip")
            {
                collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
            }
        }
    }
}
