using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool ai = false;
    public GameObject projectile;
    protected float fireRate = 1.5f;
    protected float counter;


    // Use this for initialization
    void Start()
    {
        counter = fireRate;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ai)
        {

            if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)) && counter >= fireRate && !transform.parent.GetComponent<PlayerShip>().asplode)
            {
                counter = 0;
                GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
                proj.tag = "PlayerProjectile";
            }

            if (counter <= fireRate + 0.3f)
                counter += 0.1f;
        }
        else
        {
            if (counter >= fireRate && !transform.parent.GetComponent<FriendlyShip>().asplode)
            {
                counter = 0;
                GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
                proj.tag = "PlayerProjectile";
            }

            if (counter <= fireRate + 0.3f)
                counter += 0.1f;
        }
    }
}
