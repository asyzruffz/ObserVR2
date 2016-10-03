using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
    public int lives = 4;
    public GameObject restart;

    private Text livesText;
    private bool dead = false;

    void Awake () {
        livesText = GetComponent<Text> ();
	}
    
	void Update () {
		livesText.text = "Lives: " + lives;

        if(!dead && lives <= 0)
        {
            dead = true;
            restart.SetActive(true);
        }
    }
}
