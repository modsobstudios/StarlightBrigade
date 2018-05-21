using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        Text t = GameObject.Find("InputField").GetComponentInChildren<Text>();
        if (t != null)
            PlayerPrefs.SetString("playerName", t.text);
        SceneManager.LoadScene("test");
    }
}
