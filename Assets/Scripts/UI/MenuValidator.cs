using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MenuValidator : MonoBehaviour
{

    private string clickPlayCommand;
    private string clickExitCommand;
    private bool playClicked = false;
    private bool exitClicked = false;

    // Use this for initialization
    void Start()
    {
        //clickPlayCommand = "(Star-){3,}Play";
        //clickExitCommand = "(Star-){3,}Exit";
        clickPlayCommand = "(?=.*P-)(?=.*L-)(?=.*A-)(?=.*Y-)";
        clickExitCommand = "(?=.*E-)(?=.*X-)(?=.*I-)(?=.*T-)";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playClicked && SelectionManager.Instance.ValidateSelection(clickPlayCommand))
        {
            playClicked = true;
            Invoke("ClickPlay", 1);
        }
        else if (!exitClicked && SelectionManager.Instance.ValidateSelection(clickExitCommand))
        {
            exitClicked = true;
            Invoke("ClickExit", 1);
        }
    }

    private void ClickPlay()
    {
        //SceneManager.LoadScene("Level");
        SelectionManager.Instance.ClearSelection();
        playClicked = false;
        Debug.Log("Clicked PLAY");
    }

    private void ClickExit()
    {
        SelectionManager.Instance.ClearSelection();
        exitClicked = false;
        Debug.Log("Clicked EXIT");
        Application.Quit();
    }
}
