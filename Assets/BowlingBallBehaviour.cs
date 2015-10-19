using UnityEngine;
using System.Collections;

public class BowlingBallBehaviour : MonoBehaviour {
	public bool  IsForwardPressed { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				gameObject.GetComponent<Renderer>().material.color = Color.red;
			}
		}
		
		if (Input.GetKeyDown("w")) {
			 IsForwardPressed = true;
		}
		
		if (Input.GetKeyUp("w"))  {
			IsForwardPressed = false;
		}
		
		if (IsForwardPressed) {
			transform.Translate(Vector3.back * Time.deltaTime);
		}
	}
}