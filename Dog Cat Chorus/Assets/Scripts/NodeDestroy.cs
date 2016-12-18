using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NodeDestroy : MonoBehaviour {

	public GameObject MissObj;

	void Start () {
		
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Node" ){
			GameManager.hp--;
			Destroy (other.gameObject);

		}
	}
		
}
