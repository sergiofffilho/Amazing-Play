using UnityEngine;
using System.Collections;

public class ControladorPlataformas : MonoBehaviour {

	public Transform plataformaRetaHorizontal;
	public Transform plataformaRetaVertical;
	public Transform plataformaCimaDireita;
	public Transform plataformaCimaEsquerda;
	public Transform plataformaBaixaDireita;
	public Transform plataformaBaixaEsquerda;

	float posicaoX;
	float posicaoY;

	ControladorPlayer controladorPlayer;

	Vector3 posicaoPlayer;


	void Start () {
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
		posicaoPlayer = controladorPlayer.getPosicaoPlayer ();

		Instantiate (plataformaRetaHorizontal, new Vector3(posicaoPlayer.x + 3.25f, posicaoPlayer.y - 0.4f), Quaternion.identity);
		//Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x + 9.75f, posicaoPlayer.y - 0.4f), Quaternion.identity);


		InicializarPlataformas ();


    }
	
	void Update () {
	}

	void InicializarPlataformas(){
		
			int verificador = Random.Range (0, 100);

			int[] plataformas = new int[3];
			plataformas = GetPlataforma ();

			if (verificador <= 33) {					
				Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x + 12.25f, posicaoPlayer.y - 0.4f), Quaternion.identity);
			}

			if (verificador > 33 && verificador <= 66) {		
			  	Instantiate (plataformaCimaEsquerda, new Vector3 (posicaoPlayer.x + 14.4f, posicaoPlayer.y +1.9f), Quaternion.identity);
			}

			if (verificador > 66) {
				Instantiate (plataformaBaixaDireita, new Vector3 (posicaoPlayer.x + 14.4f, posicaoPlayer.y + 1.9f), Quaternion.identity);
			}


	}

	int[] GetPlataforma(){

		if (controladorPlayer.DirecaoX() == 1) {
			int[] plats = new int[3] { 1, 3, 6 };
			return plats;
		}

		if (controladorPlayer.DirecaoX() == -1) {
			int[] plats = new int[3] { 1, 4, 5 };
			return plats;
		}

		if (controladorPlayer.DirecaoY() == 1) {
			int[] plats = new int[3] { 2, 5, 6 };
			return plats;
		}

		if (controladorPlayer.DirecaoY() == -1) {
			int[] plats = new int[3] { 2, 3, 4 };
			return plats;
		}

		return null;
	}

}
