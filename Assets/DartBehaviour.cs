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

	    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.25f, -0.5f) * 100);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
