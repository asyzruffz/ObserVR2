using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Warning : MonoBehaviour {

    public Camera cam;
    public GameObject indicator;
    public float radiusBorder = 180f;
    public bool rotateTowards = true;
    public Sprite warningSprite;

    private int num = 5;
    private float warningDistance;
    private Sprite origSprite;
    private List<GameObject> instances = new List<GameObject>();

	void Start () {
        for (int i = 0; i < num; i++) {
            GameObject inst = Instantiate(indicator);
            inst.transform.SetParent(transform);
            inst.name = "Warning";
            inst.transform.localScale = Vector3.one;
            inst.SetActive(false);
            instances.Add(inst);
        }

        origSprite = instances[0].GetComponent<Image>().sprite;
        warningDistance = FindObjectOfType<PlayerStatus>().warningDistance;
    }
    
	void Update () {
        var meteoroids = FindObjectsOfType<Meteoroid>();
        for(int i = 0; i < num; i++) {
            if(i < meteoroids.Length) {
                instances[i].SetActive(true);

                Vector3 viewportPos = cam.WorldToViewportPoint(meteoroids[i].transform.position);
                float screenX = Mathf.Clamp(viewportPos.x, 0, 1) * 2 - 1;
                float screenY = Mathf.Clamp(viewportPos.y, 0, 1) * 2 - 1;

                if(viewportPos.z < 0) {
                    screenX = -Mathf.Sign(screenX);
                    screenY = -screenY;
                }

                Vector2 adjust = new Vector2(screenX, screenY);
                if(adjust.magnitude > 1) {
                    screenX = adjust.normalized.x;
                    screenY = adjust.normalized.y;
                }

                bool warn = Vector3.Distance(transform.position, meteoroids[i].transform.position) < warningDistance * 2;

                if (rotateTowards && !warn) {
                    instances[i].transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(screenY, screenX) * Mathf.Rad2Deg);
                }

                if(warn) {
                    instances[i].GetComponent<Image>().sprite = warningSprite;
                    instances[i].transform.localEulerAngles = Vector3.zero;
                } else {
                    instances[i].GetComponent<Image>().sprite = origSprite;
                }

                instances[i].transform.localPosition = new Vector3(screenX * radiusBorder, screenY * radiusBorder, transform.localPosition.z);

            } else {
                instances[i].SetActive(false);
            }
        }
	}
}
