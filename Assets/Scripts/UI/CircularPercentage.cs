using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

[ExecuteInEditMode]
public class CircularPercentage : MonoBehaviour {

    [Range(0,100)]
    public float percentage = 100f;
    public UICircle fill;
    public Text percentText;
    
	void Update () {
        int roundedPercentage = (int)percentage;
        fill.fillPercent = Math.Min(roundedPercentage + 3, 100); // + 3 is a correction due to weird behavours of circle segments
        percentText.text = roundedPercentage + "%";
	}
}
