using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointMaster : MonoBehaviour
{
    Text pointText, lifeText;
    PlayerShip player;
    UnityEngine.UI.Image hpBar;
    float hpRatio;
    float hpCache;


    // Use this for initialization
    void Start()
    {
        pointText = GameObject.Find("Points").GetComponent<Text>();
        lifeText = GameObject.Find("Lives").GetComponent<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
        hpBar = GameObject.Find("HPBar").GetComponent<Image>();
        GameObject.Find("SFX Source").GetComponent<AudioSource>().Play(44100);
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = " SCORE: " + player.readPoints().ToString();
        lifeText.text = " LIVES: " + player.getLives();
        hpColorLerp();
    }

    void hpColorLerp()
    {
        if (player.Health != hpCache)
        {
            if (player.Health <= 0 || player.respawning)
                hpCache = 0;
            else
                hpCache = player.Health;
            hpRatio = (player.Health / player.MaxHealth);
            hpBar.color = Color.Lerp(Color.red, Color.green, hpRatio);
            hpBar.transform.localScale = new Vector3(hpRatio, 0.2f, 1);
        }
    }

    public int getScore()
    {
        return player.readPoints();
    }
}
