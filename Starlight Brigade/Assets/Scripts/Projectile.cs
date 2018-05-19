using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Vector2 position;
    Vector2 area;
    float speed;
    float damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * 10;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
