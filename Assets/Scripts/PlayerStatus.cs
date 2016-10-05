using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public ImageFade blood;

    public delegate void HitDelegate();
    public event HitDelegate hitEvent;

    AudioSource painSound;
    AudioSource deathSound;

    void Start () {
        hitEvent += OnHit;

        //to play different audio
        AudioSource[] aSource = GetComponents<AudioSource>();
        painSound = aSource[0]; //will give error but still working
        deathSound = aSource[1];
    }
	
	void Update () {
	
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
            AudioSource.PlayClipAtPoint(deathSound.clip, transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(painSound.clip, transform.position);
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
}
