using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorGameMenu : MonoBehaviour {
	Text textRecorde;

	// Use this for initialization
	void Start () {
		textRecorde = GameObject.FindGameObjectWithTag ("Recorde").GetComponent<Text> ();
	}    
	void Update(){
		textRecorde.text = PlayerPrefs.GetFloat ("Recorde").ToString();

	}
}
