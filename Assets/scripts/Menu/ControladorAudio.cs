using UnityEngine;
using System.Collections;

public class ControladorAudio : MonoBehaviour {

	OptionsOnClick optionsOnClick;

	public AudioSource[] sounds;
	public AudioSource menu;
	public AudioSource game;

	// Use this for initialization
	void Start () {
		optionsOnClick = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<OptionsOnClick> ();
		sounds = GameObject.FindGameObjectWithTag ("Audio").GetComponents<AudioSource> ();

		menu = sounds [0];
		game = sounds [1];
	}
	
	// Update is called once per frame
	void Update () {

		if (optionsOnClick.ligado == 1 && !menu.isPlaying && !game.isPlaying) {
			menu.Play ();

		} if(optionsOnClick.ligado == 2 && menu.isPlaying){
			menu.Pause ();
		}

		if(optionsOnClick.ligado == 2 && game.isPlaying){
			game.Stop ();
		}

		DontDestroyOnLoad(this.gameObject);

	}
}
