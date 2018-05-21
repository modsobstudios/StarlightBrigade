using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    GameObject laser;
    AudioClip au;
    // Use this for initialization
    void Start()
    {
        au = Resources.Load<AudioClip>("Audio/laser");
        counter = fireRate = 0.0f;
        laser = Instantiate(projectile, transform.position + new Vector3(0, 4.9f, 1), Quaternion.identity);
        laser.transform.parent = transform;
        laser.transform.tag = "PlayerLaser";
        laser.GetComponent<Collider2D>().enabled = false;
        laser.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            laser.GetComponent<Collider2D>().enabled = true;
            laser.GetComponent<SpriteRenderer>().enabled = true;
            laser.GetComponent<AudioSource>().PlayOneShot(au);
        }
        else
        {
            laser.GetComponent<Collider2D>().enabled = false;
            laser.GetComponent<SpriteRenderer>().enabled = false;
            laser.GetComponent<AudioSource>().Pause();
        }
    }
}
