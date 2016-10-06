using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public ImageFade blood;
    public float warningDistance;

    public delegate void HitDelegate();
    public event HitDelegate hitEvent;

    GvrAudioSource painSound;
    GvrAudioSource deathSound;
    GvrAudioSource warningSound;

    private bool warning = false;
    private bool warnSounding = false;

    void Start () {
        hitEvent += OnHit;

        //to play different audio
        GvrAudioSource[] aSource = GetComponents<GvrAudioSource>();
        painSound = aSource[0]; //will give error but still working
        deathSound = aSource[1];
        warningSound = aSource[2];
    }
	
	void Update () {
        warning = false;
        var meteoroids = FindObjectsOfType<Meteoroid>();
        foreach(var meteoroid in meteoroids)
        {
            if(meteoroid != null)
            {
                float distance = Vector3.Distance(transform.position, meteoroid.transform.position);
                if(distance < warningDistance)
                {
                    warning = true;
                    break;
                }
            }
        }

        if(warning && !warnSounding)
        {
            warnSounding = true;
            warningSound.Play();
            StartCoroutine(ResetWarning());
        }
    }

    public void Hit()
    {
        if (hitEvent != null)
            hitEvent();
    }

    void OnHit()
    {
        if (GetComponent<CameraShake>() != null)
        {
            GetComponent<CameraShake>().ShakeCamera();
        }

        int lives = GetComponentInChildren<Health>().lives;
        if (lives == 0)
        {
            deathSound.Play();
        }
        else
        {
            painSound.Play();
        }

        StartCoroutine(Dizzy());
    }


    IEnumerator Dizzy()
    {
        blood.FadeIn(0.5f);
        yield return new WaitForSeconds(0.5f);
        blood.FadeOut(1f);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator ResetWarning()
    {
        yield return new WaitForSeconds(3f);
        warnSounding = false;
    }
}
