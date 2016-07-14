using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {
	public Camera cam;
	public GameObject unit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.transform.position.y > 5) {
			Vector3 temp = cam.transform.position;
			cam.transform.position = temp + new Vector3(0, -1, 0);
		} else if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.transform.position.y < 30) {
			Vector3 temp = cam.transform.position;
			cam.transform.position = temp + new Vector3(0, 1, 0);
		}

		if (Input.GetMouseButtonUp (0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if( Physics.Raycast(ray, out hitInfo, 100f) ) {
                Debug.Log("hit point : " + hitInfo.point);
				Vector3 newpos = hitInfo.point;
				newpos.y = 0.2f;
				Instantiate(unit, newpos, Quaternion.identity);
            }
        }
	}
}
