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

	ParticleSystem particula; 
	// Use this for initialization
	void Start () {
		particula = GameObject.FindGameObjectWithTag ("controladorLinha").GetComponent<ParticleSystem> ();
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
		controladorPlataforma =  GameObject.FindGameObjectWithTag("controladorPlat").GetComponent<ControladorPlataformas>();
		ControladorAudio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<ControladorAudio> ();

		audio = GameObject.FindGameObjectWithTag ("Audio");

		textRecorde = GameObject.FindGameObjectWithTag ("Pontuacao").GetComponent<Text> ();


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

		SceneManager.UnloadScene("GameOver");
		controladorPlayer.setIsAlive (true);
		particula.maxParticles=10000;
		ControladorAudio.playGame();

//		SceneManager.LoadScene ("",LoadSceneMode.Additive);

	}
	// Update is called once per frame
	void Update () {


	
	}
}
