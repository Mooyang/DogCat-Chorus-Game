using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip[] sounds; 
	private AudioSource source;
	public int NumSounds;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		int index = Random.Range (0, NumSounds-1);
		int vol = Random.Range (0,1);

//		if(!source.isPlaying)
			source.PlayOneShot (sounds [index], vol);
		Debug.Log ("sound " + index);
	}
}
