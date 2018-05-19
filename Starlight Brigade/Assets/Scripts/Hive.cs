using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    float worldScreenHeight;
    float worldScreenWidth;
    float counter = 0.0f;
    float spawnRate = 5.0f;
    public GameObject enemy;
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
            Instantiate(enemy, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            counter = 0.0f;
        }
    }
}
