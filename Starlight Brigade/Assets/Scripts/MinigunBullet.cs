using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : Projectile
{


    // Use this for initialization
    void Start()
    {
        damage = 3.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    new public float getDamage()
    {
        return damage;
    }
}
