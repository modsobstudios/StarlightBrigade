using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Weapon
{

    bool flip = false;

    // Use this for initialization
    void Start()
    {
        counter = fireRate = 0.25f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && counter >= fireRate && !transform.parent.GetComponent<PlayerShip>().asplode)
        {
            flip = !flip;
            counter = 0;
            if (flip)
            {
                GameObject proj1 = Instantiate(projectile, transform.position - new Vector3(0.2f, 0, 0), Quaternion.identity);
                proj1.transform.position = new Vector3(proj1.transform.position.x, proj1.transform.position.y, -10);
                proj1.tag = "PlayerProjectile";

            }
            else
            {

                GameObject proj2 = Instantiate(projectile, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
                proj2.transform.position = new Vector3(proj2.transform.position.x, proj2.transform.position.y, -10);
                proj2.tag = "PlayerProjectile";
            }
        }

        if (counter <= fireRate + 0.3f)
            counter += 0.1f;
    }
}
