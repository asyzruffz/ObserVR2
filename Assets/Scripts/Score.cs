using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score = 0;

    private Text scoreText;
    
    void Awake () {
        scoreText = GetComponent<Text>();
    }
	
	void Update ()
    {
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
