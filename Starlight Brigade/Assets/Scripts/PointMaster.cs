using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMaster : MonoBehaviour
{
    Text pointText;
    PlayerShip player;
    UnityEngine.UI.Image hpBar;
    float hpRatio;
    float hpCache;

    // Use this for initialization
    void Start()
    {
        pointText = GameObject.Find("Points").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
        hpBar = GameObject.Find("HPBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "SCORE: " + player.readPoints().ToString();
        hpColorLerp();
    }

    void hpColorLerp()
    {
        if (player.Health != hpCache)
        {
            hpCache = player.Health;
            hpRatio = (player.Health / player.MaxHealth);
            hpBar.color = Color.Lerp(Color.red, Color.green, hpRatio);
            hpBar.transform.localScale = new Vector3(hpRatio * hpBar.transform.localScale.x, 0.2f, 1);
        }
    }
}
