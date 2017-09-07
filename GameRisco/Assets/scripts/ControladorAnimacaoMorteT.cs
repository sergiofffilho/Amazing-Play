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
		GameObject.Find ("Canvas").transform.GetChild (1).gameObject.SetActive (false);
//		GameObject.Find("Player").transform.GetChild(2).gameObject.SetActive (false); 	

	}

}
