///Daniel Moore (Firedan1176) - Firedan1176.webs.com/
///26 Dec 2015
///
///Shakes camera parent object
///Changes upon the script were made to suit the current project

using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    public bool debugMode = false; // Test-run/Call ShakeCamera() on start

    public float shakeAmount; // The amount to shake.
    public float shakeDuration; // The duration it shakes.

    //Readonly values...
    float amount; // The current amount shaking.
    float duration; // The duration left to shake.
    float shakePercentage; // A percentage (0-1) representing the amount of shake to be applied when setting rotation.
    float maxAmount; // The initial shake amount (to determine percentage), set when ShakeCamera is called.
    float maxDuration; // The initial shake duration, set when ShakeCamera is called.

    bool isRunning = false; // Is the coroutine running right now?

	public bool smooth; // Smooth rotation?
	[ConditionalHide("smooth", true)]
    public float smoothAmount = 5f; // Amount to smooth

    void Start() {
        if (debugMode) ShakeCamera();
    }

    public void ShakeCamera() {
        // Set default (start) values
        amount = shakeAmount;
        maxAmount = shakeAmount;
        duration = shakeDuration;
        maxDuration = shakeDuration;

        if (!isRunning) StartCoroutine(Shake());// Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
    }

    public void ShakeCamera(float _amount, float _duration) {
        amount += _amount; // Add to the current amount.
        maxAmount = amount; // Reset the start amount, to determine percentage.
        duration += _duration; // Add to the current time.
        maxDuration = duration; // Reset the duration calculation for percentage.

        if (!isRunning) StartCoroutine(Shake()); // Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
    }
    
    IEnumerator Shake() {
        isRunning = true;
        Quaternion originalRotation = transform.localRotation;

        while (duration >= 0f) {
            Vector3 rotationAmount = Random.insideUnitSphere * amount; // A Vector3 to add to the Local Rotation
            rotationAmount.z = 0; // Don't change the Z; it looks funny.

            shakePercentage = Mathf.Pow(duration / maxDuration, 2); // Used to set the amount of shake (% decrease parabolically over time).

            amount = maxAmount * shakePercentage; // Set the amount of shake (% * startAmount).
            duration -= Time.deltaTime;
            
            if (smooth)
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
            else
                transform.localRotation = originalRotation * Quaternion.Euler(rotationAmount); // Set the local rotation the be the rotation amount.

            yield return null;
        }
        transform.localRotation = originalRotation; // Set the local rotation back when done, just to get rid of any fudging stuff.
        isRunning = false;
    }

}