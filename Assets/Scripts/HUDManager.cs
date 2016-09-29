using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HUDManager : MonoBehaviour
{
    //public Health character;
    public Text hpDisplay;
    public Text enemyDisplay;

    void Start()
    {

    }

    void Update()
    {
        hpDisplay.text = "HP: " + "0";// character.GetHealth();
        enemyDisplay.text = "";

        /*if (character.GetHealth() <= 0)
        {
            StartCoroutine("GoToMenu");
        }*/
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
