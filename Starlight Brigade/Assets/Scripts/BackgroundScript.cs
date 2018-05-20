using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public bool animated = false;
    SpriteRenderer sr;
    Sprite[] stars;
    int starCt = 0;
    int animCt = 0;
    float worldScreenHeight;
    float worldScreenWidth;
    float width;
    float height;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        stars = Resources.LoadAll<Sprite>("stars");
        transform.localScale = new Vector3(1, 1, 1);

        width = sr.sprite.bounds.size.x;
        height = sr.sprite.bounds.size.y;

        worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
    }

    void FixedUpdate()
    {
        if (animated)
        {

            animCt++;
            if (animCt % 5 == 0)
            {
                animCt = 0;
                sr.sprite = stars[starCt];
                starCt++;
                if (starCt == stars.Length)
                    starCt = 0;
                //transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);

            }
        }
    }

}
