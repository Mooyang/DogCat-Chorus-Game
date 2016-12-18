using UnityEngine;
using System.Collections;

public class TouchDetecting : MonoBehaviour {
	public static bool isPress1;
	public static bool isPress2;
	public static bool isPress3;
	public static bool isPress4;
	public GameObject MissText;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int count = Input.touchCount;
		GameObject Button1 = GameObject.FindWithTag ("Button1");
		GameObject Button2 = GameObject.FindWithTag ("Button2");
		GameObject Button3 = GameObject.FindWithTag ("Button3");
		GameObject Button4 = GameObject.FindWithTag ("Button4");

		if (count > 0) {
			for (int i = 0; i < count; i++) {
				Touch touch = Input.GetTouch (i);
//				Debug.Log ("Touch");

				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag == "Button1") {
//						Debug.Log ("Touch1");
						if (touch.phase == TouchPhase.Began) {
							Button1.transform.position = new Vector3 (Button1.transform.position.x, -.1f, Button1.transform.position.z);
							isPress1 = true;						
						} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
							Button1.transform.position = new Vector3 (Button1.transform.position.x, .25f, Button1.transform.position.z);
							isPress1 = false;
						}
					}

					if (hit.collider.tag == "Button2") {
//						Debug.Log ("Touch2");
						if (touch.phase == TouchPhase.Began) {
							Button2.transform.position = new Vector3 (Button2.transform.position.x, -.1f, Button2.transform.position.z);
							isPress2 = true;
						} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
							Button2.transform.position = new Vector3 (Button2.transform.position.x, .25f, Button2.transform.position.z);
							isPress2 = false;
						}
					}

					if (hit.collider.tag == "Button3") {
//						Debug.Log ("Touch3");
						if (touch.phase == TouchPhase.Began) {
							Button3.transform.position = new Vector3 (Button3.transform.position.x, -.1f, Button3.transform.position.z);
							isPress3 = true;
						} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
							Button3.transform.position = new Vector3 (Button3.transform.position.x, .25f, Button3.transform.position.z);
							isPress3 = false;
						}
					}

					if (hit.collider.tag == "Button4") {
//						Debug.Log ("Touch4");
						if (touch.phase == TouchPhase.Began) {
							Button4.transform.position = new Vector3 (Button4.transform.position.x, -.1f, Button4.transform.position.z);
							isPress4 = true;
						} else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
							Button4.transform.position = new Vector3 (Button4.transform.position.x, .25f, Button4.transform.position.z);
							isPress4 = false;
						}
					}
				}

			}
				
		} 
	}
}
