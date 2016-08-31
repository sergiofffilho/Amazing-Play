using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControladorGame : MonoBehaviour {

	ControladorPlayer controladorPlayer;
	Text textPontuacao;

	// Use this for initialization
	void Start () {

		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
		textPontuacao = GameObject.FindGameObjectWithTag ("pontuacaoInGame").GetComponent<Text> ();


	}    

	void Update(){
		textPontuacao.text = controladorPlayer.pontuacao.ToString ();
	}
}
