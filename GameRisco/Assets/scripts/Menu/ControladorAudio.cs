using UnityEngine;
using System.Collections;

public class ControladorAudio : MonoBehaviour {
	OptionsOnClick optionsOnClick;

	public static ControladorAudio _instance;

	public AudioSource[] sounds;
	public AudioSource menu;
	public AudioSource game;
	public AudioSource gameOver;
	public AudioSource pingo;
	public AudioSource move;
	public AudioSource recorde;

	public bool derrota;

	void Awake(){
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		optionsOnClick = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<OptionsOnClick> ();
		sounds = GameObject.FindGameObjectWithTag ("Audio").GetComponents<AudioSource> ();

		menu = sounds [0];
		game = sounds [1];
		gameOver = sounds [2];
		pingo = sounds [3];
		move = sounds [4];
		recorde = sounds[5];
		derrota = false;
//		PlayerPrefs.SetFloat ("Recorde", 0);
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("mute") == 0 && !menu.isPlaying && !game.isPlaying && !derrota) {
				menu.Play ();
				pingo.Play ();

		} if(PlayerPrefs.GetInt("mute") == 1 && menu.isPlaying){
			menu.Pause ();
			pingo.Pause ();
		}

		if(PlayerPrefs.GetInt("mute")  == 1 && game.isPlaying){
			game.Stop ();
			move.mute = true;
			gameOver.mute = true;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	public void playGameOver(){
		game.Stop ();
		gameOver.Play ();
		derrota = true;
	}

	public void playPingo(){
		pingo.Play ();
	}

	public void playMove(){
		move.Play ();
	}

	public void playGame(){
		game.Play ();
	}
		
	IEnumerator playRecord()
	{	
		if(!(PlayerPrefs.GetInt("mute") == 1)){
			game.volume = 0.4f;
			recorde.Play ();
			yield return new WaitForSeconds(5.0f);
			game.volume = 1;
			recorde.volume = 0.4f;
		}
	}
}
