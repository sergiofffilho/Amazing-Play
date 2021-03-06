﻿using UnityEngine;
using System.Collections;

public class OptionsOnClick : MonoBehaviour {
    public GameObject audioImaegeLigado;
    public GameObject audioImaegeDesligado;

	public GameObject recorde;
	public GameObject recordeLigado;
	public GameObject recordeDesligado;

	public GameObject loadingImage;
	private AsyncOperation async;

	void Start(){
		if (PlayerPrefs.GetInt ("mute") == 1) {
			audioImaegeLigado.SetActive(false);
			audioImaegeDesligado.SetActive(true);
		}
		if (PlayerPrefs.GetInt ("mute") == 0) {
			audioImaegeLigado.SetActive (true);
			audioImaegeDesligado.SetActive (false);
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {			
			Application.Quit();
		}
	}

	public void abrirTutorial(int level){
		loadingImage.SetActive(true);
		StartCoroutine( loadingPlay (level));
	}

	IEnumerator loadingPlay (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			yield return null;
		}
	}

    public void LoadClick(int test){
		test = PlayerPrefs.GetInt ("mute");
	
		if (test == 1){	
			audioImaegeLigado.SetActive (true);
			audioImaegeDesligado.SetActive (false);
			PlayerPrefs.SetInt ("mute", 0);
        }

        if (test == 0){			
            audioImaegeLigado.SetActive(false);
            audioImaegeDesligado.SetActive(true);
			PlayerPrefs.SetInt ("mute", 1);
        }
    }

	public void ativarTelaRecord(int test){		
		if (test == 1){	
			
			recorde.SetActive(true);
			recordeLigado.SetActive(false);
			recordeDesligado.SetActive(true);
		}
		if (test == 2) {			
			recorde.SetActive(false);
			recordeLigado.SetActive(true);
			recordeDesligado.SetActive(false);
		}
	}

	public void zerarRecord(){
		PlayerPrefs.SetFloat ("Recorde", 0);
	}

	public void buttonRate(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.amazingplay.risco&hl=pt_BR");
	}
}
