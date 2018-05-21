using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripler : Weapon
{
    // Use this for initialization
    void Start()
    {
        counter = fireRate = 2.0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!ai)
        {

            if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Space)) && counter >= fireRate && !transform.parent.GetComponent<PlayerShip>().asplode)
            {
                counter = 0;

                GameObject proj1 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -30));
                GameObject proj2 = Instantiate(projectile, transform.position, Quaternion.identity);
                GameObject proj3 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 30));
                proj1.tag = "PlayerProjectile";
                proj2.tag = "PlayerProjectile";
                proj3.tag = "PlayerProjectile";
                proj1.GetComponent<Scattershot>().setTrajectory(new Vector3(0.2f, 0.5f, 0));
                proj2.GetComponent<Scattershot>().setTrajectory(new Vector3(0, 0.5f, 0));
                proj3.GetComponent<Scattershot>().setTrajectory(new Vector3(-0.2f, 0.5f, 0));
                proj1.GetComponent<Scattershot>().setDamage(7.0f);
                proj2.GetComponent<Scattershot>().setDamage(7.0f);
                proj3.GetComponent<Scattershot>().setDamage(7.0f);
            }

            if (counter <= fireRate + 0.3f)
                counter += 0.1f;
        }
        else
        {
            if (counter >= fireRate && !transform.parent.GetComponent<FriendlyShip>().asplode)
            {
                counter = 0;

                GameObject proj1 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -30));
                GameObject proj2 = Instantiate(projectile, transform.position, Quaternion.identity);
                GameObject proj3 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 30));
                proj1.tag = "PlayerProjectile";
                proj2.tag = "PlayerProjectile";
                proj3.tag = "PlayerProjectile";
                proj1.GetComponent<Scattershot>().setTrajectory(new Vector3(0.2f, 0.5f, 0));
                proj2.GetComponent<Scattershot>().setTrajectory(new Vector3(0, 0.5f, 0));
                proj3.GetComponent<Scattershot>().setTrajectory(new Vector3(-0.2f, 0.5f, 0));
                proj1.GetComponent<Scattershot>().setDamage(7.0f);
                proj2.GetComponent<Scattershot>().setDamage(7.0f);
                proj3.GetComponent<Scattershot>().setDamage(7.0f);
            }

            if (counter <= fireRate + 0.3f)
                counter += 0.1f;
        }
    }
}
