using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    Vector2 area;
    float speed;
    float damage = 10.0f;
    int points;
    Vector3 dir;
    private SpriteRenderer sr;
    private Sprite[] bullet;
    private int bulletCt = 0;
    private int animCt = 0;
    // Use this for initialization
    void Start()
    {
        dir = new Vector3(Random.Range(-0.15f, 0.15f), -0.5f, 0);
        sr = GetComponent<SpriteRenderer>();
        bullet = Resources.LoadAll<Sprite>("EnemyBullet");
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
        transform.position +=  dir * Time.deltaTime * 10;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerShip")
        {
            collision.gameObject.GetComponent<PlayerShip>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public float getDamage()
    {
        return damage;
    }
}
