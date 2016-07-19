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
	float posicaoXcurva;
	float posicaoYcurva;

	ControladorPlayer controladorPlayer;

	Vector3 posicaoPlayer;

	int direcaoFuturaX;
	int direcaoFuturaY;


	void Start () {
		posicaoX = 9.25f;
		posicaoY = 8.2f;
		posicaoXcurva = 7.9f;
		posicaoYcurva = 9.25f;

		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
		posicaoPlayer = controladorPlayer.getPosicaoPlayer ();

		Instantiate (plataformaRetaHorizontal, new Vector3(posicaoPlayer.x, posicaoPlayer.y - 0.4f), Quaternion.identity);

		InicializarPlataformas ();

    }
	
	void Update () {
		posicaoPlayer = controladorPlayer.getPosicaoPlayer ();
	}

	void OnTriggerEnter2D(Collider2D coll){
		
		 
	}

	void InicializarPlataformas(){
		
		int verificador = Random.Range (0, 100);

		if (verificador <= 33) {					
			Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x + posicaoX, posicaoPlayer.y - 0.4f), Quaternion.identity);
			direcaoFuturaX = 1;
			direcaoFuturaY = 0;
		}

		if (verificador > 33 && verificador <= 66) {		
			Instantiate (plataformaCimaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX, posicaoPlayer.y - 0.4f), Quaternion.identity);
			direcaoFuturaX = 0;
			direcaoFuturaY = 1;
		}

		if (verificador > 66) {
			Instantiate (plataformaBaixaDireita, new Vector3 (posicaoPlayer.x + posicaoX, posicaoPlayer.y - 0.4f), Quaternion.identity);
			direcaoFuturaX = 0;
			direcaoFuturaY = -1;
		}

	}

	public void ProceduralPlats(){
		
		int verificador = 30;//Random.Range (0, 100);

		int[] plataformas = new int[3];
		plataformas = GetPlataforma();

		if (verificador <= 33) {			
			if (plataformas [0] == 1) {
				if (direcaoFuturaX == 1 && direcaoFuturaX == controladorPlayer.DirecaoX()) {
					Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x + posicaoX + 1.8f, posicaoPlayer.y - 0.4f), Quaternion.identity);
					direcaoFuturaX = 1;
					direcaoFuturaY = 0;
				}

				if (direcaoFuturaX == 1 && direcaoFuturaX != controladorPlayer.DirecaoX()) {
					Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x + posicaoX + 1.8f, posicaoPlayer.y - 0.4f + posicaoY), Quaternion.identity);
					direcaoFuturaX = 1;
					direcaoFuturaY = 0;
				}

				if (direcaoFuturaX == -1 && direcaoFuturaX == controladorPlayer.DirecaoX()) {
					Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x - (posicaoX * 2) - 2, posicaoPlayer.y - 0.4f), Quaternion.identity);
					direcaoFuturaX = -1;
					direcaoFuturaY = 0;
				}

				if (direcaoFuturaX == -1 && direcaoFuturaX != controladorPlayer.DirecaoX()) {
					Instantiate (plataformaRetaHorizontal, new Vector3 (posicaoPlayer.x - (posicaoX * 2) - 2, posicaoPlayer.y - 0.4f - posicaoY), Quaternion.identity);
					direcaoFuturaX = -1;
					direcaoFuturaY = 0;
				}
					
			}

			if (plataformas [0] == 2) {
				if (direcaoFuturaY == 1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaRetaVertical, new Vector3 (posicaoPlayer.x + 0.6f, posicaoPlayer.y + posicaoY + 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}
				if (direcaoFuturaY == 1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaRetaVertical, new Vector3 (posicaoPlayer.x + posicaoX + 1, posicaoPlayer.y + posicaoY ), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaRetaVertical, new Vector3 (posicaoPlayer.x , posicaoPlayer.y - (posicaoY*2) - 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaRetaVertical, new Vector3 (posicaoPlayer.x + posicaoX + 0.8f, posicaoPlayer.y - (posicaoY*2) - 0.5f) , Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

			}
		}

		if (verificador > 33 && verificador <= 66) {		
			if (plataformas [1] == 3) {
				if (direcaoFuturaX == 1 && direcaoFuturaX == controladorPlayer.DirecaoX() &&) {
					Instantiate (plataformaCimaEsquerda, new Vector3 (posicaoPlayer.x + 0.6f, posicaoPlayer.y + posicaoY + 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}
				if (direcaoFuturaX == 1 && direcaoFuturaX != controladorPlayer.DirecaoX()) {
					Instantiate (plataformaCimaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX + 1, posicaoPlayer.y + posicaoY ), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}

				if (direcaoFuturaX == -1 && direcaoFuturaX == controladorPlayer.DirecaoX()) {
					Instantiate (plataformaCimaEsquerda, new Vector3 (posicaoPlayer.x , posicaoPlayer.y - (posicaoY*2) - 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

				if (direcaoFuturaX == -1 && direcaoFuturaX != controladorPlayer.Direcao()) {
					Instantiate (plataformaCimaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX + 0.8f, posicaoPlayer.y - (posicaoY*2) - 0.5f) , Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

			}

			if (plataformas [1] == 4) {
				if (direcaoFuturaY == 1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaCimaDireita, new Vector3 (posicaoPlayer.x + 0.6f, posicaoPlayer.y + posicaoY + 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}
				if (direcaoFuturaY == 1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaCimaDireita, new Vector3 (posicaoPlayer.x + posicaoX + 1, posicaoPlayer.y + posicaoY ), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaCimaDireita, new Vector3 (posicaoPlayer.x , posicaoPlayer.y - (posicaoY*2) - 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaCimaDireita, new Vector3 (posicaoPlayer.x + posicaoX + 0.8f, posicaoPlayer.y - (posicaoY*2) - 0.5f) , Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}
			}

			if (plataformas [1] == 5) {
				if (direcaoFuturaY == 1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x + 0.6f, posicaoPlayer.y + posicaoY + 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}
				if (direcaoFuturaY == 1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX + 1, posicaoPlayer.y + posicaoY ), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x , posicaoPlayer.y - (posicaoY*2) - 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX + 0.8f, posicaoPlayer.y - (posicaoY*2) - 0.5f) , Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}
			}
		}

		if (verificador > 66) {
			if (plataformas [2] == 4) {
				if (direcaoFuturaY == 1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x + 0.6f, posicaoPlayer.y + posicaoY + 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}
				if (direcaoFuturaY == 1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX + 1, posicaoPlayer.y + posicaoY ), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = 1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY == controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x , posicaoPlayer.y - (posicaoY*2) - 2), Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}

				if (direcaoFuturaY == -1 && direcaoFuturaY != controladorPlayer.DirecaoY()) {
					Instantiate (plataformaBaixaEsquerda, new Vector3 (posicaoPlayer.x + posicaoX + 0.8f, posicaoPlayer.y - (posicaoY*2) - 0.5f) , Quaternion.identity);
					direcaoFuturaX = 0;
					direcaoFuturaY = -1;
				}
			}

			if (plataformas [2] == 5) {

			}

			if (plataformas [2] == 6) {

			}
		}

	}

	int[] GetPlataforma(){

		if (direcaoFuturaX == 1) {
			int[] plats = new int[3] { 1, 3, 6 };
			return plats;
		}

		if (direcaoFuturaX == -1) {
			int[] plats = new int[3] { 1, 4, 5 };
			return plats;
		}

		if (direcaoFuturaY == 1) {
			int[] plats = new int[3] { 2, 5, 6 };
			return plats;
		}

		if (direcaoFuturaY == -1) {
			int[] plats = new int[3] { 2, 3, 4 };
			return plats;
		}

		return null;
	}

}
