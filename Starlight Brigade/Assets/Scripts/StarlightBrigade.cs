using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarlightBrigade : MonoBehaviour
{
    float worldScreenHeight;
    float worldScreenWidth;
    float counter = 0.0f;
    float spawnRate = 0.5f;
    int numFriends = 35;
    int numSpawned = 0;
    private float spawnRate1 = 1.5f;
    private float offset = -2.0f;
    public GameObject ally;
    [SerializeField]
    private bool spawn = false;

    // Use this for initialization
    void Start()
    {
        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawn)
        {
            counter += 0.1f;
            if (numSpawned <= numFriends)
            {
                if (counter >= spawnRate)
                {
                    GameObject e = Instantiate(ally, new Vector3(Random.Range(-worldScreenWidth / 2, worldScreenWidth / 2), transform.position.y, transform.position.z), Quaternion.identity);
                    numSpawned++;
                    counter = 0.0f;
                }
            }
            else
            {
                spawn = false;
                numSpawned = 0;
                counter = 0.0f;
            }
        }
    }

    public void SpawnBrigade()
    {
        spawn = true;
    }
}