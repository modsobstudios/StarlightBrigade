using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattergun : Weapon
{



    // Use this for initialization
    void Start()
    {
        counter = fireRate = 3.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && counter >= fireRate && !transform.parent.GetComponent<PlayerShip>().asplode)
        {
            counter = 0;
            AudioClip au = Resources.Load<AudioClip>("Audio/scatter");
            GameObject.Find("SFX Source").GetComponent<AudioSource>().PlayOneShot(au);
            GameObject proj1 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -30));
            GameObject proj2 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, -15));
            GameObject proj3 = Instantiate(projectile, transform.position, Quaternion.identity);
            GameObject proj4 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 15));
            GameObject proj5 = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 30));
            proj1.tag = "PlayerProjectile";
            proj2.tag = "PlayerProjectile";
            proj3.tag = "PlayerProjectile";
            proj4.tag = "PlayerProjectile";
            proj5.tag = "PlayerProjectile";
            proj1.GetComponent<Scattershot>().setTrajectory(new Vector3(0.2f, 0.5f, 0));
            proj2.GetComponent<Scattershot>().setTrajectory(new Vector3(0.1f, 0.5f, 0));
            proj3.GetComponent<Scattershot>().setTrajectory(new Vector3(0, 0.5f, 0));
            proj4.GetComponent<Scattershot>().setTrajectory(new Vector3(-0.1f, 0.5f, 0));
            proj5.GetComponent<Scattershot>().setTrajectory(new Vector3(-0.2f, 0.5f, 0));
        }

        if (counter <= fireRate + 0.3f)
            counter += 0.1f;
    }
}
