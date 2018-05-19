﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject projectile;
    float fireRate = 6.0f;
    float counter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible && counter >= fireRate)
        {
            counter = 0;
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            proj.tag = "EnemyProjectile";
        }
        if (counter <= fireRate + 0.3f)
            counter += 0.1f;
    }
}
