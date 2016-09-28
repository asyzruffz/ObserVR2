using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Starable : MonoBehaviour, IGvrGazeResponder
{

    public bool stared = false;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
    
    public void SetGazedAt(bool gazedAt)
    {
        stared = gazedAt;
    }

    #region IGvrGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        SetGazedAt(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        SetGazedAt(false);
    }

    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger()
    {
        // #TODO Call function to trigger when clicking the object
    }

    #endregion
}
