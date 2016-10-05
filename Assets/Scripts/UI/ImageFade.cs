using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour
{

    public Color opaqueColour;
    public Color transparentColor;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        image.color = Color.white;
        FadeOut(0.1f);
    }

    public void FadeIn(float fadeTime)
    {
        GetComponent<Image>().CrossFadeColor(opaqueColour, fadeTime, true, true);
    }

    public void FadeOut(float fadeTime)
    {
        GetComponent<Image>().CrossFadeColor(transparentColor, fadeTime, true, true);
    }
}
