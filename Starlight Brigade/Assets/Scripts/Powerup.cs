using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //public enum Weapons { BLASTER, MINIGUN, TRIPLER, SCATTER, LASER}
    protected SpriteRenderer sr;
    protected Sprite[] power;
    protected int powerCt;
    protected int animCt;
    protected Vector3 trajectory;


    protected void moveTo()
    {
        transform.position += trajectory * Time.deltaTime;
    }

    public void setTrajectory(Vector3 _traj)
    {
        trajectory = _traj;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnDestroy()
    {
    }
}
