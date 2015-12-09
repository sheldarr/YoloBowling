using UnityEngine;

public class DartBehaviour : MonoBehaviour {

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
