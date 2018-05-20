using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector2 area;
    float speed;
    protected float damage = 10.0f;
    int points;

    private SpriteRenderer sr;
    private Sprite[] bullet;
    private int bulletCt = 0;
    private int animCt = 0;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bullet = Resources.LoadAll<Sprite>("PlayerBullet");
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
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }
}
