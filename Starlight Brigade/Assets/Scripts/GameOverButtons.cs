using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void quitGame()
    {
        Application.Quit();
    }

    public void replay()
    {
        SceneManager.LoadScene("test");
    }
}
