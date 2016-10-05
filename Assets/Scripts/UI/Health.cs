using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    
    public int lives = 4;
    public PlayerStatus player;

    private Text livesText;
    private int maxLives;

    void Awake () {
        livesText = GetComponent<Text> ();
        maxLives = lives;
	}
    
    void Start () {
        Director.Instance.startEvent += ResetHealth;
        Director.Instance.endEvent += ResetHealth;
        player.hitEvent += OnHit;
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
        }
    }

    void ResetHealth()
    {
        lives = maxLives;
    }

    void OnHit()
    {
        lives--;
    }
}
