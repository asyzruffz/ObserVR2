using UnityEngine;
using System.Collections;

public class CamPositionManager : MonoBehaviour
{

    public ImageFade fadeImage;
    public float fadeTime = 1;
    public Transform viewingCamera;
    public Transform[] viewingPoints;

    private int currentTarget = 0;
    private int currentPosition = 0;

    void Start()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.FadeOut(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentTarget++;
            currentTarget = currentTarget % viewingPoints.Length;
            MoveCamera(currentTarget);
        }
    }

    public void MoveCamera(int positionIndex)
    {
        if (currentPosition == positionIndex)
            return;
        StartCoroutine(OnMoveCamera(positionIndex));
    }

    IEnumerator OnMoveCamera(int positionIndex)
    {
        fadeImage.FadeIn(fadeTime);
        yield return new WaitForSeconds(fadeTime);
        viewingCamera.position = viewingPoints[positionIndex].position;
        viewingCamera.rotation = viewingPoints[positionIndex].rotation;
        currentPosition = positionIndex;
        fadeImage.FadeOut(fadeTime);
        yield return new WaitForSeconds(fadeTime);
    }
}
