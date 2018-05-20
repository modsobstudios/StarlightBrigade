using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armory : MonoBehaviour
{

    float worldScreenHeight;
    float counter = 0.0f;
    float spawnRate = 50.0f;
    public GameObject[] powers;
    enum PowerEnum { HP, LIFE, BLASTER, MINIGUN, LASER, SCATTER, TRIPLER}
    // Use this for initialization
    void Start()
    {
        worldScreenHeight = Camera.main.orthographicSize * 2.0f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 0.1f;
        if(counter >= spawnRate)
        {
            counter = 0;
            spawnPowerup();
        }
    }

    void spawnPowerup()
    {
        int select = Random.Range(0, 10);

        switch(select)
        {
            case 0:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.HP], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<HealthPickup>().setTrajectory(t);
                break;
            }
            case 1:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.BLASTER], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<BlasterPickup>().setTrajectory(t);
                break;
            }
            case 2:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.LASER], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<LaserPickup>().setTrajectory(t);
                break;
            }
            case 3:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.LIFE], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<LifePickup>().setTrajectory(t);
                break;
            }
            case 4:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.MINIGUN], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<MinigunPickup>().setTrajectory(t);
                break;
            }
            case 5:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.SCATTER], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<ScattergunPickup>().setTrajectory(t);
                break;
            }
            case 6:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.TRIPLER], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<TriplerPickup>().setTrajectory(t);
                break;
            }

            default:
            {
                GameObject pwr = Instantiate(powers[(int)PowerEnum.HP], new Vector3(transform.position.x, Random.Range(-worldScreenHeight, worldScreenHeight), transform.position.z), Quaternion.identity);
                Vector3 t = (GameObject.Find("Player").transform.position - pwr.transform.position).normalized;
                pwr.GetComponent<HealthPickup>().setTrajectory(t);
                break;
            }

        }
    }
}
