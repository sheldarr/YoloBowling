using UnityEngine;

/// <summary>
/// Created: 09/12/2015
/// CreatedBy: Kewin Polok
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Adds const force to Dart and enables gravity
/// </summary>
public class DartBehaviour : MonoBehaviour {

    /// <summary>
    /// Updates this instance.
    /// </summary>
    void Update ()
    {
	    if (!Input.GetKeyDown(KeyCode.D))
	    {
	        return;
	    }

	    gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 250);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
