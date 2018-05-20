using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Weapon
{

    // Use this for initialization
    void Start()
    {
        fireRate = 3.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && counter >= fireRate)
        {
            counter = 0;
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.tag = "PlayerProjectile";
        }

        if (counter <= fireRate + 0.3f)
            counter += 0.1f;
    }
}
