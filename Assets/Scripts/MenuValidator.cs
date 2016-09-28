using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MenuValidator : MonoBehaviour
{

    private string clickPlayCommand;
    private string clickExitCommand;

    // Use this for initialization
    void Start()
    {
        clickPlayCommand = "(Star-){3,}Play";
        clickExitCommand = "(Star-){3,}Exit";
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectionManager.Instance.ValidateSelection(clickPlayCommand))
        {
            Invoke("ClickPlay", 1);
        }
        else if (SelectionManager.Instance.ValidateSelection(clickExitCommand))
        {
            Invoke("ClickExit", 1);
        }
    }

    private void ClickPlay()
    {
        //SceneManager.LoadScene("Level");
        SelectionManager.Instance.ClearSelection();
    }

    private void ClickExit()
    {
        SelectionManager.Instance.ClearSelection();
        Application.Quit();
    }
}
