using UnityEngine;
using System.Collections;

public class ControladorMorte : MonoBehaviour {
	// Use this for initialization
	public void AtualizarPosição(Vector3 novaPosicao) {
		gameObject.transform.position = novaPosicao;
	}
}
