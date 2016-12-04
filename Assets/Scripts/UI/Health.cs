using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    
    public int lives = 4;
    public PlayerStatus player;

    //private Text livesText;
    private CircularPercentage percent;
    private int maxLives;

    void Awake () {
        //livesText = GetComponent<Text>();
        percent = GetComponent<CircularPercentage>();
        maxLives = lives;
	}
    
    void Start () {
        Director.Instance.startEvent += ResetHealth;
        Director.Instance.endEvent += ResetHealth;
        player.hitEvent += OnHit;
    }

	void Update () {
        SetVisible(Director.Instance.inGame);

        if (Director.Instance.inGame) {
            //livesText.text = "Lives: " + lives;
            percent.percentage = (float)lives / maxLives * 100;
        } else {
            //livesText.text = "";
            percent.percentage = 100;
        }

        if(lives <= 0 && Director.Instance.inGame) {
            Director.Instance.inGame = false;
        }
    }

    void ResetHealth() {
        lives = maxLives;
    }

    void OnHit() {
        lives--;
    }

    void SetVisible(bool visible) {
        foreach (Transform child in transform)
            child.gameObject.SetActive(visible);
    }
}
