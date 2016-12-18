using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public Transform[] Nodes = new Transform[4];
	public GameObject ScoreUI;

	private float xPos;
	private float SpawnTime = 1f;
	private int highScore = 0;

	public static int scoreCount = 0 ;
	public static int hp = 20;

	private bool isSpawn = true;
	private bool isDead = false;

	public Text CurrentScore;
	public Text ScoreText;
	public Text HighScoreText;
	public Text HPText;

	void Start () {
		ScoreUI.SetActive (false);

		if(PlayerPrefs.GetInt("HighScore") != null){
			highScore = PlayerPrefs.GetInt ("HighScore");
		}
	}
	
	void Update () {
		if (isDead)
			return;
		else { 
			if (isSpawn) {
				StartCoroutine (Spawn ());
				isSpawn = false;
			}
			Scores ();
			GameOver ();
		}

	}

	IEnumerator Spawn(){
		int randPos = Random.Range(1,10);
		float CurrentSpawnTime = SpawnTime - Time.deltaTime * 10; /*Random.Range (SpawnTime - (Time.deltaTime * 7), SpawnTime - (Time.deltaTime * 10));*/

		yield return new WaitForSeconds (CurrentSpawnTime);
		if(CurrentSpawnTime < 0.1f)
			CurrentSpawnTime = 0.1f;
//		Debug.Log("SpawnTime : " + CurrentSpawnTime);

		if (randPos == 1)
			Instantiate (Nodes[0], new Vector3 (-3.75f, 0, 10), Nodes[0].rotation);
		else if (randPos == 2)
			Instantiate (Nodes[1], new Vector3 (-1.25f, 0, 10), Nodes[1].rotation);
		else if (randPos == 3)
			Instantiate (Nodes[2], new Vector3 (1.25f, 0, 10), Nodes[2].rotation);
		else if (randPos == 4)
			Instantiate (Nodes[3], new Vector3 (3.75f, 0, 10), Nodes[3].rotation);
		else if (randPos == 5) {
			Instantiate (Nodes[0], new Vector3 (-3.75f, 0, 10), Nodes[0].rotation);
			Instantiate (Nodes[1], new Vector3 (-1.25f, 0, 10), Nodes[1].rotation);
		}
		else if (randPos == 6) {
			Instantiate (Nodes[0], new Vector3 (-3.75f, 0, 10), Nodes[0].rotation);
			Instantiate (Nodes[2], new Vector3 (1.25f, 0, 10), Nodes[2].rotation);
		}
		else if (randPos == 7) {
			Instantiate (Nodes[0], new Vector3 (-3.75f, 0, 10), Nodes[0].rotation);
			Instantiate (Nodes[3], new Vector3 (3.75f, 0, 10), Nodes[3].rotation);
		}
		else if (randPos == 8) {
			Instantiate (Nodes[1], new Vector3 (-1.25f, 0, 10), Nodes[1].rotation);
			Instantiate (Nodes[2], new Vector3 (1.25f, 0, 10), Nodes[2].rotation);
		}
		else if (randPos == 9) {
			Instantiate (Nodes[1], new Vector3 (-1.25f, 0, 10), Nodes[1].rotation);
			Instantiate (Nodes[3], new Vector3 (3.75f, 0, 10), Nodes[3].rotation);
		}
		else if (randPos == 10) {
			Instantiate (Nodes[2], new Vector3 (1.25f, 0, 10), Nodes[2].rotation);
			Instantiate (Nodes[3], new Vector3 (3.75f, 0, 10), Nodes[3].rotation);
		}
		
		isSpawn = true;
	}

	private void Scores(){
		if (scoreCount > highScore) {
			highScore = scoreCount;
		}

		CurrentScore.text = scoreCount.ToString ();
		ScoreText.text = scoreCount.ToString ();
		HPText.text = "HP : " + hp.ToString ();
		HighScoreText.text = highScore.ToString ();
		PlayerPrefs.SetInt ("HighScore", highScore);

	}

	private void GameOver(){
		if (hp <= 0) {
			isDead = true;
			ShowScore ();
		}	
	}

	private void ShowScore(){
		ScoreUI.SetActive (true);
		Destroy (GameObject.Find("ButtonEffect"));
		Destroy (GameObject.Find("MissObj"));
	}

	public void ReplayScene(){
		SceneManager.LoadScene ("DogCatChorus");
		Debug.Log ("Restart");
		ScoreUI.SetActive (false);
		hp = 20;
		scoreCount = 0;
	}

	public void LoadHome(){
		SceneManager.LoadScene ("Home");
		Debug.Log ("Home");
	}

}
