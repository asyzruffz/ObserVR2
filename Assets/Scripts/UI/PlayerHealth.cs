using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
    public int lives = 4;
    public GameObject restart;

    private Text livesText;
    private int maxLives;

    void Awake () {
        livesText = GetComponent<Text> ();
        maxLives = lives;
	}
    
    void Start () {
        Director.Instance.startEvent += ResetHealth;
    }

	void Update () {
        if(Director.Instance.inGame)
        {
            livesText.text = "Lives: " + lives;
        }
        else
        {
            livesText.text = "";
        }

        if(lives <= 0 && Director.Instance.inGame)
        {
            Director.Instance.inGame = false;
            restart.SetActive(true);
        }
    }

    void ResetHealth()
    {
        lives = maxLives;
    }
}
