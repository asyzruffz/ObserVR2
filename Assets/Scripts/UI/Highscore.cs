using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    void Update()
    {
        scoreText.GetComponent<Text>().text = Director.Instance.HighScore + " Highscore";
    }
}
