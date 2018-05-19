using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    float health;
    int lives;
    Weapon weapon;
    float speed;
    int points;
    int nukes;
    int maxNukes;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 10;
        }
    }
}
