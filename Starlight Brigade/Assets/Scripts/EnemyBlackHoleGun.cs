using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlackHoleGun : MonoBehaviour
{

    public GameObject projectile;
    float fireRate = 100.0f;
    float counter;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.parent.gameObject.GetComponent<SpriteRenderer>().isVisible && counter >= fireRate && !transform.parent.GetComponent<Boss>().asplode)
        {
            counter = 0;
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            proj.tag = "Orbit";
        }
        if (counter <= fireRate + 0.3f)
            counter += 0.1f;
    }
}
