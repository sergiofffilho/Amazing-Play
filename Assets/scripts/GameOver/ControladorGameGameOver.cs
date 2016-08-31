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

	public Button button;

	ParticleSystem particula; 
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


		if (PlayerPrefs.GetFloat ("Pontuacao") >= PlayerPrefs.GetFloat ("Recorde")) {
			RecordeLigado.SetActive(true);
				
		}

		SceneManager.SetActiveScene (SceneManager.GetSceneByName("GameOver"));

	}
	public void returnMenu(){
			Destroy(audio);
			Application.LoadLevel (0);

	
	}

	public void continueGame(){
		if(PlayerPrefs.GetInt("continue") == 0){
			SceneManager.UnloadScene("GameOver");

			controladorPlayer.setIsAlive (true);
			particula.maxParticles=10000;
			ControladorAudio.playGame();
			pontuacaoInGame.SetActive (true);
			PlayerPrefs.SetInt ("continue", 1);

//			SceneManager.LoadScene ("",LoadSceneMode.Additive);
		}

			}
	// Update is called once per frame
	void Update () {


	
	}
}
