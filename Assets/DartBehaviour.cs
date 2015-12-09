using UnityEngine;

public class DartBehaviour : MonoBehaviour {

    void Update ()
    {
	    if (!Input.GetKey(KeyCode.D))
	    {
	        return;
	    }

	    gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * 70);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
