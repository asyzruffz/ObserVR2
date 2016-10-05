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
        Director.Instance.startEvent += OnStartGame;
    }

    void Update()
    {
        if (health.lives <= 0)
        {
            int remain = 5 - (int)timer;
            restartText.text = "Wait " + remain + " seconds to continue";
            timer += Time.deltaTime;
        }
    }

    void OnStartGame()
    {
        timer = 0;
        restartText.text = "";
    }
}
