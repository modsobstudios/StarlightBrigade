using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    Vector2 area;
    float speed;
    float damage = 10.0f;
    int points;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(Random.Range(-0.5f, 0.5f), -0.5f, 0) * Time.deltaTime * 10;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "PlayerShip")
        {
            collision.gameObject.GetComponent<PlayerShip>().takeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public float getDamage()
    {
        return damage;
    }
}
