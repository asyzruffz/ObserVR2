using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

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
    }
}
