using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefScript : MonoBehaviour
{
    public bool showScores = false;

    class Score
    {
        public int score;
        public string name;
        public Score(int _sc, string _n) { score = _sc; name = _n; }
    }

    List<Score> scores = new List<Score>
    {
        new Score(820, "Radio Knife"),
        new Score(0, ""),
        new Score(900, "The Condor"),
        new Score(335, "Parker"),
        new Score(650, "Californiac"),
        new Score(1035, "Mickey Mouth"),
        new Score(725, "Carbon Thing"),
        new Score(495, "Hazel"),
        new Score(890, "Alison Cat"),
        new Score(555, "Nova Trail"),
    };




    // Use this for initialization
    void Start()
    {
        if (showScores)
        {

            getScoresFromPref();
            sortScores();
            Text t = GameObject.Find("ScoreText").GetComponent<Text>();
            for (int i = 0; i < scores.Count; i++)
            {
                t.text += ((i + 1) + ". " + scores[i].score + " -|- " + scores[i].name + "\n");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            resetScores();
    }

    public void setPlayerName(string _n)
    {
        PlayerPrefs.SetString("playerName", _n);
    }

    public void addScoreThenTruncate(int _score)
    {
        Score s = new Score(_score, PlayerPrefs.GetString("playerName"));

        if (!scores.Contains(s))
            scores.Add(s);

        sortScores();
    }

    void sortScores()
    {
        for (int i = 0; i < scores.Count; i++)
            for (int j = 0; j < scores.Count - 1; j++)
                if (scores[j].score < scores[j + 1].score)
                    swapInPlace(j, j + 1);
        while (scores.Count > 10)
            scores.RemoveAt(scores.Count - 1);
    }

    void swapInPlace(int one, int two)
    {
        Score t = scores[one];
        scores[one] = scores[two];
        scores[two] = t;
    }

    void getScoresFromPref()
    {
        scores.Clear();
        Score s = new Score(PlayerPrefs.GetInt("score1"), PlayerPrefs.GetString("name1"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score2"), PlayerPrefs.GetString("name2"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score3"), PlayerPrefs.GetString("name3"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score4"), PlayerPrefs.GetString("name4"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score5"), PlayerPrefs.GetString("name5"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score6"), PlayerPrefs.GetString("name6"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score7"), PlayerPrefs.GetString("name7"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score8"), PlayerPrefs.GetString("name8"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score9"), PlayerPrefs.GetString("name9"));
            scores.Add(s);
        s = new Score(PlayerPrefs.GetInt("score10"), PlayerPrefs.GetString("name10"));
            scores.Add(s);
    }

    public void setScoresToPref()
    {
        PlayerPrefs.SetInt("score1", scores[0].score);
        PlayerPrefs.SetInt("score2", scores[1].score);
        PlayerPrefs.SetInt("score3", scores[2].score);
        PlayerPrefs.SetInt("score4", scores[3].score);
        PlayerPrefs.SetInt("score5", scores[4].score);
        PlayerPrefs.SetInt("score6", scores[5].score);
        PlayerPrefs.SetInt("score7", scores[6].score);
        PlayerPrefs.SetInt("score8", scores[7].score);
        PlayerPrefs.SetInt("score9", scores[8].score);
        PlayerPrefs.SetInt("score10", scores[9].score);

        PlayerPrefs.SetString("name1", scores[0].name);
        PlayerPrefs.SetString("name2", scores[1].name);
        PlayerPrefs.SetString("name3", scores[2].name);
        PlayerPrefs.SetString("name4", scores[3].name);
        PlayerPrefs.SetString("name5", scores[4].name);
        PlayerPrefs.SetString("name6", scores[5].name);
        PlayerPrefs.SetString("name7", scores[6].name);
        PlayerPrefs.SetString("name8", scores[7].name);
        PlayerPrefs.SetString("name9", scores[8].name);
        PlayerPrefs.SetString("name10", scores[9].name);
    }

    void resetScores()
    {
        scores = new List<Score>
        {
        new Score(820, "Radio Knife"),
        new Score(0, ""),
        new Score(900, "The Condor"),
        new Score(335, "Parker"),
        new Score(650, "Californiac"),
        new Score(1035, "Mickey Mouth"),
        new Score(725, "Carbon Thing"),
        new Score(495, "Hazel"),
        new Score(890, "Alison Cat"),
        new Score(555, "Nova Trail"),
        };
        sortScores();
        setScoresToPref();
    }

}

