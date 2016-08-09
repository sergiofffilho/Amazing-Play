using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorGameGameOver : MonoBehaviour {
	public GameObject RecordeLigado;
	Text textRecorde;
	GameObject audio;
	// Use this for initialization
	void Start () {
		audio = GameObject.FindGameObjectWithTag ("Audio");

		textRecorde = GameObject.FindGameObjectWithTag ("Pontuacao").GetComponent<Text> ();


		//RecordeLigado.SetActive(true);

		textRecorde.text = PlayerPrefs.GetFloat ("Pontuacao").ToString();

		//PlayerPrefs.SetFloat ("Recorde",0);


		if (PlayerPrefs.GetFloat ("Pontuacao") >= PlayerPrefs.GetFloat ("Recorde")) {
			RecordeLigado.SetActive(true);
				
		}
	}
	public void returnMenu(){
			Destroy(audio);
			Application.LoadLevel (0);

	
	}
	// Update is called once per frame
	void Update () {


	
	}
}
