using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    float worldScreenHeight;
    float worldScreenWidth;
    float counter = 0.0f;
    float spawnRate = 5.0f;
    public GameObject enemy, asteroid;
    // Use this for initialization
    void Start()
    {
        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 0.1f;
        if(counter >= spawnRate)
        {
            switch(Random.Range(0, 2))
            {
                case 0:
                {
            Instantiate(enemy, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                    break;
                }
                case 1:
                {
                    Instantiate(asteroid, new Vector3(Random.Range(-worldScreenWidth/2, worldScreenWidth/2), transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 180)));
                    break;
                }
            }
            counter = 0.0f;
        }
    }
}
