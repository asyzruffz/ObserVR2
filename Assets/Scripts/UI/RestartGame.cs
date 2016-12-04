using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGame : MonoBehaviour {

    public Health health;

    private Text restartText;
    private float timer = 0;
    private bool timing = false;

    void Start() {
        restartText = GetComponent<Text>();
        Director.Instance.startEvent += OnStartGame;
    }

    void Update() {
        if (health.lives <= 0)
            timing = true;

        if (timing) {
            if (timer < 5) {
                int remain = 5 - (int)timer;
                restartText.text = "Wait " + remain + " seconds to continue";
                timer += Time.deltaTime;
            } else if (timer > 5) {
                timing = false;
            }
        } else {
            restartText.text = "";
        }
    }

    void OnStartGame() {
        timer = 0;
    }
}
