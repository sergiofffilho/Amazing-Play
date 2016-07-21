﻿using UnityEngine;
using System.Collections;

public class ControladorPlataformas : MonoBehaviour {

	// Plataformasa a serem invocadas
	public Transform plataformaDireita;
	public Transform plataformaEsquerda;
	public Transform plataformaCima;
	public Transform plataformaBaixo;

	// Posição de invocação das plataformas
	float posicaoX;
	float posicaoY;
	float tamanhoPlataformaEmpe;
	float tamanhoPlataformaDeitada;
	// cria um player
	ControladorPlayer controladorPlayer;

	//variavel para salvar pos. player
	Vector3 posicaoPlayer;

	// direção da proxima plataforma invocada
	int direcaoFuturaX;
	int direcaoFuturaY;


	void Start () {
		//verificar: valores
		tamanhoPlataformaEmpe = 4.4f;
		tamanhoPlataformaDeitada = 10;
		posicaoX = 5;
		posicaoY = -0.2f;

		//salva pos. plaer no vector3
		controladorPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ControladorPlayer> ();
		posicaoPlayer = controladorPlayer.getPosicaoPlayer ();

		Instantiate (plataformaDireita, new Vector3(posicaoX, posicaoY), Quaternion.identity);


		//InicializarPlataformas ();

    }
	
	void Update () {
		posicaoPlayer = controladorPlayer.getPosicaoPlayer ();
	}
		
	public void InicializarPlataformas(){

		int verificador = Random.Range (0, 100);
		int verificadorAleatorio = Random.Range (25, 35);

		//Indo para direita
		if (controladorPlayer.DirecaoX() == 1){
			if (verificador <= verificadorAleatorio) {	
				posicaoX = posicaoX + tamanhoPlataformaEmpe;
				posicaoY = posicaoY + tamanhoPlataformaEmpe;
				Instantiate (plataformaCima, new Vector3 ( posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = 0;
				direcaoFuturaY = 1;
			}

			if (verificador > verificadorAleatorio && verificador <= verificadorAleatorio + 40) {	
				posicaoX = posicaoX + tamanhoPlataformaDeitada;	
				Instantiate (plataformaDireita, new Vector3 (posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = 1;
				direcaoFuturaY = 0;
			}

			if (verificador > verificadorAleatorio + 40) {
				posicaoX = posicaoX + tamanhoPlataformaEmpe;
				posicaoY = posicaoY - tamanhoPlataformaEmpe;
				Instantiate (plataformaBaixo, new Vector3 (posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = 0;
				direcaoFuturaY = -1;
			}
		}

		//Indo para esqueda
		if (controladorPlayer.DirecaoX() == -1){

			if (verificador <= verificadorAleatorio) {
				posicaoX = posicaoX - tamanhoPlataformaEmpe;
				posicaoY = posicaoY + tamanhoPlataformaEmpe;
				Instantiate (plataformaCima, new Vector3 (posicaoX, posicaoY ), Quaternion.identity);
				direcaoFuturaX = 0;
				direcaoFuturaY = 1;
			}

			if (verificador > verificadorAleatorio && verificador <= verificadorAleatorio + 40) {	
				posicaoX = posicaoX - tamanhoPlataformaDeitada;	
				Instantiate (plataformaEsquerda, new Vector3 (posicaoX, posicaoY), Quaternion.identity);
				direcaoFuturaX = -1;
				direcaoFuturaY = 0;
			}

			if (verificador > verificadorAleatorio + 40) {
				posicaoX = posicaoX - tamanhoPlataformaEmpe;
				posicaoY = posicaoY - tamanhoPlataformaEmpe;
				Instantiate (plataformaBaixo, new Vector3 (posicaoX, posicaoY), Quaternion.identity);
				direcaoFuturaX = 0;
				direcaoFuturaY = -1;
			}
		}

		//Indo para cima
		if (controladorPlayer.DirecaoY() == 1){

			if (verificador <= verificadorAleatorio) {	
				posicaoX = posicaoX - tamanhoPlataformaEmpe;
				posicaoY = posicaoY + tamanhoPlataformaEmpe;
				Instantiate (plataformaEsquerda, new Vector3 (posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = -1;
				direcaoFuturaY = 0;
			}

			if (verificador > verificadorAleatorio && verificador <= verificadorAleatorio + 40) {		
				posicaoY = posicaoY + tamanhoPlataformaDeitada;
				Instantiate (plataformaCima, new Vector3 (posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = 0;
				direcaoFuturaY = 1;
			}

			if (verificador > verificadorAleatorio + 40) {
				posicaoX = posicaoX + tamanhoPlataformaEmpe;
				posicaoY = posicaoY + tamanhoPlataformaEmpe;
				Instantiate (plataformaDireita, new Vector3 (posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = 1;
				direcaoFuturaY = 0;

			}
		}

		//Indo para baixo
		if (controladorPlayer.DirecaoY() == -1){

			if (verificador <= verificadorAleatorio) {	
				posicaoX = posicaoX - tamanhoPlataformaEmpe;
				posicaoY = posicaoY - tamanhoPlataformaEmpe;
				Instantiate (plataformaEsquerda, new Vector3 (posicaoX, posicaoY), Quaternion.identity);
				direcaoFuturaX = -1;
				direcaoFuturaY = 0;
			}

			if (verificador > verificadorAleatorio && verificador <= verificadorAleatorio + 40) {
				posicaoY = posicaoY - tamanhoPlataformaDeitada;
				Instantiate (plataformaBaixo, new Vector3 (posicaoX,posicaoY), Quaternion.identity);
				direcaoFuturaX = 0;
				direcaoFuturaY = -1;
			}

			if (verificador > verificadorAleatorio + 40) {
				posicaoX = posicaoX + tamanhoPlataformaEmpe;
				posicaoY = posicaoY - tamanhoPlataformaEmpe;
				Instantiate (plataformaDireita, new Vector3 (posicaoX, posicaoY), Quaternion.identity);
				direcaoFuturaX = 1;
				direcaoFuturaY = 0;
			}
		}

	}
		

	void OnTriggerEnter2D(Collider2D coll)
	{			
		
	}

}
