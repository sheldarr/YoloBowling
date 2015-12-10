using UnityEngine;
using System.Collections;

public class HingeDartBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -0.25f, -0.25f) * 100);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
