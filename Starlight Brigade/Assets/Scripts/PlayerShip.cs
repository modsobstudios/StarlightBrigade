using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{

    float health = 10.0f;
    int lives;
    Weapon weapon;
    float speed;
    int points;
    int nukes;
    int maxNukes;
    SpriteRenderer sr;
    Sprite[] splode, ship;
    bool asplode = false;
    int splodeCt = 0;
    int shipCt = 0;
    int animCt = 0;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        splode = Resources.LoadAll<Sprite>("splode");
        ship = Resources.LoadAll<Sprite>("PlayerShip");
    }

    private void Update()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
            asplode = true;
        if (asplode)
            esplode();
        else
        {
            animCt++;
            if (animCt % 5 == 0)
            {
                animCt = 0;
                sr.sprite = ship[shipCt];
                shipCt++;
                if (shipCt == ship.Length)
                    shipCt = 0;
            }
        }

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

    public void awardPoints(int _p)
    {
        points += _p;
    }

    public int readPoints()
    {
        return points;
    }

    public void takeDamage(float _hp)
    {
        Debug.Log("Taking damage!");
        health -= _hp;
    }

    private void esplode()
    {
        sr.sprite = splode[splodeCt];
        splodeCt++;
        if (splodeCt == splode.Length)
        {
            Destroy(this.gameObject);
        }
    }
}
