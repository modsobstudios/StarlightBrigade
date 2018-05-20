﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplerPickup : Powerup
{
    Weapons type = Weapons.TRIPLER;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        power = Resources.LoadAll<Sprite>("TripleShotPickup");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animCt++;
        if (animCt % 5 == 0)
        {
            animCt = 0;
            sr.sprite = power[powerCt];
            powerCt++;
            if (powerCt == power.Length)
                powerCt = 0;
        }
        moveTo();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerShip")
        {
            collision.gameObject.GetComponent<PlayerShip>().switchWeapons(type);
            Destroy(this.gameObject);
        }
    }
}
