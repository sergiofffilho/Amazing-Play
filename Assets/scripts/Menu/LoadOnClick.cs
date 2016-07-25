using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
 	
	AudioSource[] controladorAudio;


	public void LoadScene(int level){
		controladorAudio = GameObject.FindGameObjectWithTag ("Audio").GetComponents<AudioSource> ();
		controladorAudio [0].Stop ();
		controladorAudio [1].Play ();
		Application.LoadLevel (level);
 	}
}
