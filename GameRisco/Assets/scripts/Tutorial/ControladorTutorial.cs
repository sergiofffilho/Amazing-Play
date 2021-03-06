﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorTutorial : MonoBehaviour {
	public GameObject Panel1;
	public GameObject Panel2;
	public GameObject Panel3;
	public GameObject Panel4;
	public GameObject Panel5;
	public GameObject Panel6;
	public GameObject Panel7;
	public GameObject Panel8;
	public GameObject Panel9;
	public GameObject Panel10;
	public GameObject Panel11;
	public GameObject Panel12;
	public GameObject Panel13;

	Image botaoVoltar;
	Image botaoAvancar;

	Color botaoVoltar1;
	Color botaoVoltar2;
	Color botaoAvancar1;
	Color botaoAvancar2;

	public GameObject loadingImage;
	private AsyncOperation async;

	GameObject audio;

	int i;

	// Use this for initialization
	void Start () {
		audio = GameObject.FindGameObjectWithTag ("Audio");

		i = 1;
		Panel1.SetActive(true);

		botaoAvancar = GameObject.FindGameObjectWithTag ("botaoAvancar").GetComponent<Image>();
		botaoVoltar = GameObject.FindGameObjectWithTag ("botaoVoltar").GetComponent<Image>();

		botaoVoltar1 = botaoVoltar.color;
		botaoVoltar2 = botaoVoltar.color;
		botaoVoltar1.a = 0.1f;
		botaoVoltar2.a = 1;
		botaoVoltar.color = botaoVoltar1;

		botaoAvancar1 = botaoAvancar.color;
		botaoAvancar2 = botaoAvancar.color;
		botaoAvancar1.a = 0.1f;
		botaoAvancar2.a = 1;

	}

	public void avacarTutorial(int panel){			
		i += panel;

		if (i > 13) {
			i = 13;
		}

		switch (i){
			case 2:
				Panel1.SetActive (false);
				Panel2.SetActive (true);
				botaoVoltar.color = botaoVoltar2;
				break;
			case 3:
				Panel2.SetActive (false);
				Panel3.SetActive (true);
				break;
			case 4:
				Panel3.SetActive (false);
				Panel4.SetActive (true);
				break;
			case 5:
				Panel4.SetActive (false);
				Panel5.SetActive (true);
				break;
			case 6:
				Panel5.SetActive (false);
				Panel6.SetActive (true);
				break;
			case 7:
				Panel6.SetActive (false);
				Panel7.SetActive (true);
				break;
			case 8:
				Panel7.SetActive (false);
				Panel8.SetActive (true);
				break;
			case 9:
				Panel8.SetActive (false);
				Panel9.SetActive (true);
				break;
			case 10:
				Panel9.SetActive (false);
				Panel10.SetActive (true);
				break;
			case 11:
				Panel10.SetActive (false);
				Panel11.SetActive (true);
				break;
			case 12:
				Panel11.SetActive (false);
				Panel12.SetActive (true);
				break;
			case 13:
				Panel12.SetActive (false);
				Panel13.SetActive (true);
				botaoAvancar.color = botaoAvancar1;
					break;			
		}
	}

	public void voltarTutorial(int panel){		
		i -= panel;

		if (i < 1) {
			i = 1; 
		}

		switch (i){
			case 1:
				Panel1.SetActive (true);
				Panel2.SetActive (false);
				botaoVoltar.color = botaoVoltar1;
				break;
			case 2:
				Panel3.SetActive (false);
				Panel2.SetActive (true);
				break;
			case 3:
				Panel4.SetActive (false);
				Panel3.SetActive (true);
				break;
			case 4:
				Panel5.SetActive (false);
				Panel4.SetActive (true);
				break;
			case 5:
				Panel6.SetActive (false);
				Panel5.SetActive (true);
				break;
			case 6:
				Panel7.SetActive (false);
				Panel6.SetActive (true);
				break;
			case 7:
				Panel8.SetActive (false);
				Panel7.SetActive (true);
				break;
			case 8:
				Panel9.SetActive (false);
				Panel8.SetActive (true);
				break;
			case 9:
				Panel10.SetActive (false);
				Panel9.SetActive (true);
				break;
			case 10:
				Panel11.SetActive (false);
				Panel10.SetActive (true);
				break;
			case 11:
				Panel12.SetActive (false);
				Panel11.SetActive (true);
				break;
			case 12:
				Panel13.SetActive (false);
				Panel12.SetActive (true);
				botaoAvancar.color = botaoAvancar2;
				break;
//			case 13:				
//				Panel13.SetActive (true);
//				botaoAvancar.color = botaoAvancar2;
//				break;			
		}

	}

	public void fecharTutorial(int level){
		loadingImage.SetActive(true);
		StartCoroutine( loadingPlay (level));
	}

	IEnumerator loadingPlay (int level)
	{
		async = Application.LoadLevelAsync(level);
		while (!async.isDone)
		{
			Destroy(audio);
			yield return null;
		}
	}
}
