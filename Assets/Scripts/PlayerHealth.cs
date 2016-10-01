using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public GameObject player;
	public GameObject restartText;
	public GameObject scoreText;
    public int lives = 4;
	public int score = 0;
    public Vector3 textPos; //0,-12,20

    private MeshRenderer textRender;
    private float timer = 0;

    void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		restartText = GameObject.Find ("Restart");
		textRender = restartText.GetComponent<MeshRenderer> ();

		this.transform.position = player.transform.position+textPos;
	}

	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			textRender.enabled = true;
            int remain = 5 - (int)timer;
            restartText.GetComponent<TextMesh>().text = "Wait " + remain + " seconds to Restart";
            timer += Time.deltaTime;

            Invoke ("Restart", 5.0f);
		}

        GetComponent<TextMesh>().text = "Lives: " + lives;
        scoreText.GetComponent<TextMesh>().text = "Score: " + score;
    }

	void Restart(){
        timer = 0;
        SpawnMeteor.meteorCounter = 0;
        SceneManager.LoadScene ("Game");
	}
}
