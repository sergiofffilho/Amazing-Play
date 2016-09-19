using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorGameGameOver : MonoBehaviour {
	public GameObject RecordeLigado;
	Text textRecorde;
	GameObject audio;

	ControladorPlayer controladorPlayer;
	ControladorPlataformas controladorPlataforma;
	ControladorAudio ControladorAudio;

	GameObject pontuacaoInGame;

	Image botaoContinue;

	Button button;

	ParticleSystem particula; 

	Color c1;
	Color c2;

	public GameObject loadingImage;
	private AsyncOperation async;

	// Use this for initialization
	void Start () {
		particula = GameObject.FindGameObjectWithTag ("controladorLinha").GetComponent<ParticleSystem> ();
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
		controladorPlataforma =  GameObject.FindGameObjectWithTag("controladorPlat").GetComponent<ControladorPlataformas>();
		ControladorAudio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<ControladorAudio> ();

		pontuacaoInGame = GameObject.FindGameObjectWithTag ("pontuacaoInGame");

		audio = GameObject.FindGameObjectWithTag ("Audio");

		textRecorde = GameObject.FindGameObjectWithTag ("Pontuacao").GetComponent<Text> ();

		pontuacaoInGame.SetActive (false);
		//RecordeLigado.SetActive(true);

		textRecorde.text = PlayerPrefs.GetFloat ("Pontuacao").ToString();

		//PlayerPrefs.SetFloat ("Recorde",0);

		botaoContinue = GameObject.FindGameObjectWithTag ("botaoContinue").GetComponent<Image>();
		c1 = botaoContinue.color;
		c2 = botaoContinue.color;
		c1.a = 0.5f;
		c2.a = 1;

		if (PlayerPrefs.GetInt ("continue") == 0) {
			botaoContinue.color = c2;
		} else {
			botaoContinue.color = c1;
		}

		if (PlayerPrefs.GetFloat ("Pontuacao") >= PlayerPrefs.GetFloat ("Recorde")) {
			RecordeLigado.SetActive(true);
				
		}

		SceneManager.SetActiveScene (SceneManager.GetSceneByName("GameOver"));

	}
	public void returnMenu(){
		loadingImage.SetActive(true);
		int level = 0;
		StartCoroutine( loadingPlay (level));

		Destroy(audio);
		Application.LoadLevel (0);	
	}

	IEnumerator loadingPlay (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			Debug.Log ("df");
			yield return null;
		}
	}

	public void continueGame(){
		if(PlayerPrefs.GetInt("continue") == 0){
			SceneManager.UnloadScene("GameOver");
			controladorPlayer.detectSwipe = true;
			controladorPlayer.setIsAlive (true);
			particula.maxParticles=10000;
			ControladorAudio.playGame();
			pontuacaoInGame.SetActive (true);
			PlayerPrefs.SetInt ("continue", 1);

//			SceneManager.LoadScene ("",LoadSceneMode.Additive);
		}

	}



	public void buttonRate(){

		Application.OpenURL("http://unity3d.com/");

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {

			Application.Quit();

		}

	
	}
}
