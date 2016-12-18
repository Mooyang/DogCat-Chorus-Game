using UnityEngine;
using System.Collections;

public class NodeMove : MonoBehaviour {

	private float Speed = -0.2f;
	private float CurrentSpeed = -0.2f;
	
	// Update is called once per frame
	void Update () {
		CurrentSpeed = Speed - (Time.deltaTime * 7);
		if(CurrentSpeed < -1)
			CurrentSpeed = -1;

		transform.Translate (0,0,CurrentSpeed);
//		Debug.Log("NodeSpeed : " + CurrentSpeed);
	}
}
