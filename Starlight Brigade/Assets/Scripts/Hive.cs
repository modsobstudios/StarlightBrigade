using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hive : MonoBehaviour
{
    float worldScreenHeight;
    float worldScreenWidth;
    float counter = 0.0f;
    float spawnRate = 3.0f;
    int numEnemies = 10;
    int numSpawned = 0;
    private float spawnRate1 = 1.5f;
    private float offset = -2.0f;
    public GameObject enemy, asteroid,boss;
    private int wave = 0;
    [SerializeField]
    private int pattern = 0;
    // Use this for initialization
    void Start()
    {
        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
        ChoosePattern();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(wave >= 10)
        {
            GameObject e = Instantiate(boss, new Vector3(0, transform.position.y, transform.position.z), Quaternion.identity);
            wave = 0;
        }

        switch (pattern)
        {
            case 0: //Random Spawn
                counter += 0.1f;
                if (numSpawned <= numEnemies)
                {
                    if (counter >= spawnRate)
                    {
                        switch (Random.Range(0, 2))
                        {
                            case 0:
                                {
                                    GameObject e = Instantiate(enemy, new Vector3(Random.Range(-worldScreenWidth / 2, worldScreenWidth / 2), transform.position.y, transform.position.z), Quaternion.identity);

                                    break;
                                }
                            case 1:
                                {
                                    Instantiate(asteroid, new Vector3(Random.Range(-worldScreenWidth / 2, worldScreenWidth / 2), transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 180)));

                                    break;
                                }
                        }
                        numSpawned++;
                        counter = 0.0f;
                    }
                }
                else
                {
                    numSpawned = 0;
                    counter = 0;
                    //Choose new pattern
                    ChoosePattern();
                    wave++;
                }
                break;
            case 1: // Pattern 1
                counter += 0.1f;
                if (numSpawned <= numEnemies)
                {
                    if (counter >= spawnRate1)
                    {
                        GameObject e = Instantiate(enemy, new Vector3(0, transform.position.y + offset, transform.position.z), Quaternion.identity);
                        e.GetComponent<Enemy>().Left = true;
                        e.GetComponent<Enemy>().Side = true;
                        e.GetComponent<Enemy>().health /= 2;
                        e.GetComponent<Enemy>().points /= 2;
                        e.GetComponent<SpriteRenderer>().color = Color.red;
                        numSpawned++;
                        counter = 0;
                    }
                }
                else
                {
                    numSpawned = 0;
                    counter = 0;
                    //Choose new pattern
                    pattern = 0;
                    wave++;
                }
                break;
            case 2: // Pattern 2
                counter += 0.1f;
                if (numSpawned <= numEnemies)
                {
                    if (counter >= spawnRate1)
                    {
                        GameObject e = Instantiate(enemy, new Vector3(0, transform.position.y + offset, transform.position.z), Quaternion.identity);
                        e.GetComponent<Enemy>().Left = false;
                        e.GetComponent<Enemy>().Side = true;
                        e.GetComponent<Enemy>().health /= 2;
                        e.GetComponent<Enemy>().points /= 2;
                        e.GetComponent<SpriteRenderer>().color = Color.red;
                        numSpawned++;
                        counter = 0;
                    }
                }
                else
                {
                    numSpawned = 0;
                    counter = 0;
                    //Choose new pattern
                    pattern = 0;
                    wave++;
                }


                break;
            case 3: // Pattern 3
                counter += 0.1f;
                if (numSpawned <= numEnemies)
                {
                    if (counter >= spawnRate1)
                    {
                        GameObject e = Instantiate(enemy, new Vector3(0, transform.position.y + offset, transform.position.z), Quaternion.identity);
                        e.GetComponent<Enemy>().Left = true;
                        e.GetComponent<Enemy>().Side = true;
                        e.GetComponent<Enemy>().health /= 2;
                        e.GetComponent<Enemy>().points /= 2;
                        e.GetComponent<SpriteRenderer>().color = Color.red;


                        GameObject e1 = Instantiate(enemy, new Vector3(0, transform.position.y + offset, transform.position.z), Quaternion.identity);
                        e1.GetComponent<Enemy>().Left = false;
                        e1.GetComponent<Enemy>().Side = true;
                        e1.GetComponent<Enemy>().health /= 2;
                        e1.GetComponent<Enemy>().points /= 2;
                        e1.GetComponent<SpriteRenderer>().color = Color.red;

                        numSpawned+=2;
                        counter = 0;
                    }
                }
                else
                {
                    numSpawned = 0;
                    counter = 0;
                    //Choose new pattern
                    pattern = 0;
                    wave++;
                }
                break;
            default:
                counter += 0.1f;
                if (numSpawned <= numEnemies)
                {
                    if (counter >= spawnRate)
                    {
                        switch (Random.Range(0, 2))
                        {
                            case 0:
                                {
                                    GameObject e = Instantiate(enemy, new Vector3(Random.Range(-worldScreenWidth / 2, worldScreenWidth / 2), transform.position.y, transform.position.z), Quaternion.identity);

                                    break;
                                }
                            case 1:
                                {
                                    Instantiate(asteroid, new Vector3(Random.Range(-worldScreenWidth / 2, worldScreenWidth / 2), transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 180)));

                                    break;
                                }
                        }
                        numSpawned++;
                        counter = 0.0f;
                    }
                }
                else
                {
                    numSpawned = 0;
                    counter = 0;
                    //Choose new pattern
                    ChoosePattern();
                    wave++;
                }
                break;
        }
    }

    private void ChoosePattern()
    {
        pattern = Random.Range(0, 4);
    }

}
