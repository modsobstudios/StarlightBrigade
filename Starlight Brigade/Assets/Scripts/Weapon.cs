﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject projectile;
    float fireRate = 1.5f;
    float counter;


    // Use this for initialization
    void Start()
    {
        counter = fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0) && counter >= fireRate)
        {
            counter = 0;
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.tag = "PlayerProjectile";
        }

        if (counter <= fireRate + 0.3f)
            counter += 0.1f;
    }
}
