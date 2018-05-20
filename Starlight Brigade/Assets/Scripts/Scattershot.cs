using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattershot : Projectile
{

    Vector3 trajectory;

    // Use this for initialization
    void Start()
    {
        damage = 5.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += trajectory * Time.deltaTime * 10;
    }

    public void setTrajectory(Vector3 _traj)
    {
        trajectory = _traj;
    }

    new public float getDamage()
    {
        return damage;
    }

    public void setDamage(float _dmg)
    {
        damage = _dmg;
    }
}
