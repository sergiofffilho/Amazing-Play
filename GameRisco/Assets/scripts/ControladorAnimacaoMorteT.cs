using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControladorAnimacaoMorteT : MonoBehaviour {
	
	public static ControladorAnimacaoMorteT _instance;
	ControladorPlayer controladorPlayer;

	GameObject player;

	void Awake () {
		_instance = this;
		player = GameObject.FindGameObjectWithTag ("player");
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();

	}

	IEnumerator AnimarMorte()
	{	
		controladorPlayer.velocidade = controladorPlayer.velocidadeGameOver;
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("GameOver",LoadSceneMode.Additive);
	}

}
