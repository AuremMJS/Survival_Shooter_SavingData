using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{

    private static int score;

    Text text;
    
    void Awake ()
    {
        text = GetComponent <Text> ();

        // Getting the score from game data manager
        score = GameDataManager.Instance.GetScore();
    }

    void Update ()
    {
        text.text = "Score: " + score;
    }

    // Setting the score in game data manager whenever score is changed
    public static void AddScore(int scoreValue)
    {
        score += scoreValue;
        GameDataManager.Instance.SetScore(score);
    }

}