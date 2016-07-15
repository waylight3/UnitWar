using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {
	public Camera cam;
	public GameObject unit;
	
	private GameObject target;
	private bool mouseDown;
	private float lastX, lastY;
	private Vector3 lastpos, newpos, lastMouse, newMouse;
	
	// Use this for initialization
	void Start () {
		mouseDown = false;
		target = null;
	}
	
	// Update is called once per frame
	void Update () {
		// zoom
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.transform.position.y > 5) {
			Vector3 temp = cam.transform.position;
			cam.transform.position = temp + new Vector3(0, -1, 0);
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.transform.position.y < 30) {
			Vector3 temp = cam.transform.position;
			cam.transform.position = temp + new Vector3(0, 1, 0);
		}

		// create unit
		if (Input.GetMouseButtonUp (0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if( Physics.Raycast(ray, out hitInfo, 100f) ) {
				if (hitInfo.transform.tag != "Unit") {
					Vector3 newpos = hitInfo.point;
					newpos.y = 0.2f;
					Instantiate(unit, newpos, Quaternion.identity);
				}				
            }
        }

		// drag
		if (Input.GetMouseButtonDown(1)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100f)) {
				target = hit.collider.gameObject;
				lastpos = new Vector3(hit.point.x, target.transform.position.y, hit.point.z);
				lastMouse = new Vector3(Input.mousePosition.x, target.transform.position.y, Input.mousePosition.y);
				mouseDown = true;
			}
		}
		if (Input.GetMouseButtonUp(1)) {
			mouseDown = false;
		}
		if (mouseDown) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100f) && target != null) {
				// unit
				if (target.tag == "Unit") {
					newpos = new Vector3(hit.point.x, target.transform.position.y, hit.point.z);
					target.transform.position += newpos - lastpos;
					lastpos = newpos;
				}
				// screen
				if (target.tag == "Board") {
					newMouse = new Vector3(Input.mousePosition.x, target.transform.position.y, Input.mousePosition.y);
					cam.transform.position += (newMouse - lastMouse) / -100.0f;
					lastMouse = newMouse;
				}
			}
		}
	}
}
