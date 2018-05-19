using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMaster : MonoBehaviour
{
    Text pointText;
    PlayerShip player;

    // Use this for initialization
    void Start()
    {
        pointText = GameObject.Find("Points").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "SCORE: " + player.readPoints().ToString();
    }
}
