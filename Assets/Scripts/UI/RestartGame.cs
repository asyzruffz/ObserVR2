using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGame : MonoBehaviour
{

    public PlayerHealth health;

    private Text restartText;
    private float timer = 0;

    void Start()
    {
        restartText = GetComponent<Text>();
    }

    void Update()
    {
        if (health.lives <= 0)
        {
            int remain = 5 - (int)timer;
            restartText.text = "Wait " + remain + " seconds to Restart";
            timer += Time.deltaTime;

            Invoke("Restart", 5.0f);
            health.ResetHealth();
        }
    }

    void Restart()
    {
        timer = 0;
        SpawnMeteor.meteorCounter = 0;
        SceneManager.LoadScene("Game");
    }
}
