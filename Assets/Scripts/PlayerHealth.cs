using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public GameObject player;
	public GameObject restartText;
	public int lives = 4;
	MeshRenderer textRender;

	public Vector3 textPos; //0,-12,20
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		restartText = GameObject.Find ("Restart");
		textRender = restartText.GetComponent<MeshRenderer> ();

		this.transform.position = player.transform.position+textPos;
	}

	// Update is called once per frame
	void Update () {
		


		if (lives == 0) {
			textRender.enabled = true;

			Invoke ("restart", 5.0f);
			//Time.timeScale = 0.0f;
		} else {
			GetComponent<TextMesh> ().text = "Lives: " + lives;
		}

	}

	void restart(){
		SceneManager.LoadScene ("Game");
	}
}
