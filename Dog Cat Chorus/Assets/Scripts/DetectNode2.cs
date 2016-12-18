using UnityEngine;
using System.Collections;

public class DetectNode2 : MonoBehaviour {
	public AudioClip[] sounds;
	public GameObject MissObj;
	public GameObject ButtonEffect;

	private float vol = .5f;
	private AudioSource source;
	private int randSound = 0;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Node" && TouchDetecting.isPress2 == true) {
			GameManager.scoreCount++;
			Destroy (other.gameObject);
			SetSound ();
			Instantiate (ButtonEffect, new Vector3 (this.gameObject.transform.position.x, 
				this.gameObject.transform.position.y,
				this.gameObject.transform.position.z), Quaternion.identity);
			StartCoroutine (Destroy ());
			Debug.Log ("Success2");
		}

	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Node") {
			Instantiate (MissObj, new Vector3(-2.5f, 3.3f, 0), Quaternion.identity);
			StartCoroutine(Destroy ());

		}
	}

	IEnumerator Destroy(){
		yield return new WaitForSeconds (.5f);
		Destroy (GameObject.FindWithTag("Miss"));
		Destroy (GameObject.FindWithTag("ButtonFX"));
	}

	private void SetSound(){
		vol = Random.Range (.2f, .5f);
		randSound = Random.Range (0, sounds.Length);

		source.PlayOneShot (sounds[randSound], vol);
	}


}
