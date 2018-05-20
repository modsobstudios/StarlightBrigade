using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    protected float damage = 10.0f;

    protected SpriteRenderer sr;
    protected Sprite[] bullet;
    protected int bulletCt = 0;
    protected int animCt = 0;

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
        if(transform.tag != "PlayerLaser")
            Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }
}
