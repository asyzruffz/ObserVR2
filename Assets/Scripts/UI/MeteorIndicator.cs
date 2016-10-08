using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeteorIndicator : MonoBehaviour {

    private Text indicator;

	void Awake () {
        indicator = GetComponent<Text>();
    }
	
	void Update () {
        if(Director.Instance.inGame)
        {
            if (MeteorManager.meteorCounter > 0)
            {
                indicator.text = "Incoming Meteor Attack!";
            }
            else
            {
                indicator.text = "You are safe for now...";
            }
        }
        else
        {
            indicator.text = "";
        }
	}
}
