using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MenuValidator : MonoBehaviour
{
    public GameObject playButton;
    public GameObject exitButton;

    private string clickPlayCommand;
    private string clickExitCommand;
    private bool playClicked = false;
    private bool exitClicked = false;

    // Use this for initialization
    void Start()
    {
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

        if(Director.Instance.inGame)
        {
            playButton.SetActive(false);
            exitButton.SetActive(false);
        }
        else
        {
            playButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }

    private void ClickPlay()
    {
        SelectionManager.Instance.ClearSelection();
        playClicked = false;
        Debug.Log("Clicked PLAY");
        Director.Instance.inGame = true;
    }

    private void ClickExit()
    {
        SelectionManager.Instance.ClearSelection();
        exitClicked = false;
        Debug.Log("Clicked EXIT");
        Application.Quit();
    }
}
