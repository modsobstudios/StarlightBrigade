using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public float colliderDepth = 4.0f;
    public float zPos = 0.0f;
    private Vector2 screenSize;
    private Transform topCollider;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Transform rightCollider;
    private Vector3 cameraPos;

    // Use this for initialization
    void Start () {

        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        topCollider = new GameObject().transform;
        topCollider.name = "TopCollider";
        topCollider.gameObject.AddComponent<BoxCollider2D>();
        topCollider.parent = transform;
        topCollider.localScale = new Vector3(screenSize.x * 2, colliderDepth, colliderDepth);
        topCollider.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (topCollider.localScale.y * 0.5f), zPos);

        bottomCollider = new GameObject().transform;
        bottomCollider.name = "BottomCollider";
        bottomCollider.gameObject.AddComponent<BoxCollider2D>();
        bottomCollider.parent = transform;
        bottomCollider.localScale = new Vector3(screenSize.x * 2, colliderDepth, colliderDepth);
        bottomCollider.position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (bottomCollider.localScale.y * 0.5f), zPos);

        rightCollider = new GameObject().transform;
        rightCollider.name = "RightCollider";
        rightCollider.gameObject.AddComponent<BoxCollider2D>();
        rightCollider.parent = transform;
        rightCollider.localScale = new Vector3(colliderDepth, screenSize.y * 2, colliderDepth);
        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPos);

        leftCollider = new GameObject().transform;
        leftCollider.name = "LeftCollider";
        leftCollider.gameObject.AddComponent<BoxCollider2D>();
        leftCollider.parent = transform;
        leftCollider.localScale = new Vector3(colliderDepth, screenSize.y * 2, colliderDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPos);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
