using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {
	public GameObject cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.transform.position.z > 10) {
			Vector3 temp = cam.transform.position;
			cam.transform.position = temp + new Vector3(0, 0, -1);
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
			Vector3 temp = cam.transform.position;
			cam.transform.position = temp + new Vector3(0, 0, 1);
		}
	}
}
